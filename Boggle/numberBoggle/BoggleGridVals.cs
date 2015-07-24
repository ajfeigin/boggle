using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using LoreSoft.MathExpressions;

namespace Boggle {
    public class BoggleGridVals {
        protected static int rows_ = 4;
        protected static int cols_ = 4;
        protected readonly Random rand = new Random();
        //array to hold the grid values
        protected object[,] values_;
        protected string allvalues_;
        protected Dictionary<string, IList<int[]>> locations_ = new Dictionary<string, IList<int[]>>();
        protected List<List<int[]>> adjacentLocations_ = new List<List<int[]>>();
        protected Dictionary<int, int> scores;

        public List<CheckedWords> Verified { get; set; }

        public int Rows {
            get { return rows_; }
            set {
                rows_ = value;
                //reset the array
                values_ = new Array[rows_, cols_];
            }
        }

        public int Cols {
            get { return cols_; }
            set {
                cols_ = value;
                //reset the array
                values_ = new Array[rows_, cols_];
            }
        }

        public virtual object[,] GetValues() {
            return values_;
        }

        protected string AllValues { get { return allvalues_; } }

        protected void SetLocation_(string value, int row, int col) {
            var tmp = new[] { row, col };
            var tmplist = new List<int[]> { tmp };
            if (!locations_.ContainsKey(value)) locations_.Add(value, tmplist);
            else locations_[value].Add(tmp);
        }
        public virtual void Validate(object text) {
            var usertext = text as string[];
            if (usertext == null) throw new InvalidCastException("Text provided is not in an appropriate format");
            if (usertext.Length < 1) return;
            Verified = new List<CheckedWords>();
            usertext = Dedupe(usertext);
            foreach (string word in usertext) {
                if (word.Length >= 2) {
                    bool indictionary = CheckDictionary(word.ToUpper());
                    //currently only tests if the string appears in the specific order not just anywhere. Also doesn't check yet if letters are touching
                    CheckGrid(PrepareWord(word), indictionary);
                }
            }
        }

        private string[] Dedupe(IEnumerable<string> usertext){
            var res=new List<string>();
            foreach (string s in usertext){
                string upper = s.ToUpper();
                if (!ContainsDuplicate(res, upper)) {
                    res.Add(upper);
                }
            }
            return res.ToArray();
        }

        protected virtual bool ContainsDuplicate(List<string> userwords, string tocheck) { return userwords.Contains(tocheck); }

        protected virtual object PrepareWord(string word) { return word.ToUpper(); }

        protected virtual bool CheckDictionary(string word) { return true; }

        protected bool CheckGrid(object valToCheck, bool indictionary) {
            var word = ((string)valToCheck).ToUpper();
            //if there's nothing in the 1st cell of the grid the grid is empty
            if (null == values_[0, 0]) return false;
            //check that the combination of letters is in the grid (quick check) and then if so that they're 
            // adjacent
            if (IsInGrid(word)) {
                var correctsequences = CorrectPositions(word);
                //if there's at least 1 correct set of locations then the sequence being tested is a valid answer (ie all letters/numbers correctly adjacent to each other)
                bool res = correctsequences.Count > 0;
                int score = 0;
                if (indictionary && res) score = getscore(word);
                //add an entry to the results set used to populated the results grid on the form
                Verified.Add(new CheckedWords(word, res, indictionary, correctsequences,score));
                return res;
            }
            Verified.Add(new CheckedWords(word, false,indictionary, new List<List<int[]>>(),0));
            return false;
        }

        protected virtual int getscore(string word){
            return 0;
            }
        //Check that all the letters in the supplied sequence appear in the grid in sufficient frequency
        protected bool IsInGrid(object valToCheck) {
            var val = (string)valToCheck;
            //clone the location dictionary b/c we'll remove letters that get used
            Dictionary<string, IList<int[]>> locationsclone = cloneDict(locations_);
            //recursively check if each letter appears in the grid
            return InKeys(val, locationsclone);
        }

        //Check if the provided word/sequence is in the grid NOT WORKING
        protected List<List<int[]>> CorrectPositions(object valToCheck) {
            var val = (string)valToCheck;
            // get the first letter of the word to check
            var correct = new List<List<int[]>>();
            string remainder;
            string firstletter = GetFirstLetter(val, out remainder);
            if (locations_.ContainsKey(firstletter)) {
                // creates a list of trees that start with the 1st letter of the word and connect subsequent letters
                // where possible. 1 tree for each instance of the 1st letter of the word in the grid
                var trees = locations_[firstletter].Select(location => MakeTree(location, firstletter, val)).ToList();
                foreach (var tree in trees) {
                    var lists = tree.AllLocations();
                    foreach (var list in lists) {
                        int length = val.Length;
                        //if there are Qu's reduce the required number of locations to match as QU appear together in 1 cell
                        length -= val.Split("Q".ToCharArray()).Length - 1;
                        int distinct = list.Distinct().Count();
                        //We only have a true match if each location is distinct and there are enough locations
                        //for each letter. Being distinct is required to prevent reusing a cell in a word
                        if (distinct == list.Count && distinct == length) correct.Add(list);
                    }
                }
            }
            return correct;
        }

        private Tree MakeTree(int[] location, string firstletter, string val) {
            //create a tree
            var tree = new Tree();
            //set the head of the tree to take the location of this copy of the first letter of the word
            var head = new TreeNode(location, firstletter);
            tree.Head = head;
            string remainingletters;
            GetFirstLetter(val, out remainingletters);
            //setup the trees branches with the tree, and all but the first letter of the string
            ConstructBranches(remainingletters, head);
            return tree;
        }

        private void ConstructBranches(string val, TreeNode currentnode) {
            if (val.Length == 0) return;
            string remainder;
            var first = GetFirstLetter(val, out remainder);
            foreach (var cell in locations_[first]) {
                if (NextTo(currentnode.Location, cell)) {
                    //if the location of the current node is adjactent to a location for the next letter
                    // add a child node to the tree with that location
                    var node = new TreeNode(currentnode, cell, first);
                    //then proceed through to the next letter
                    ConstructBranches(remainder, node);
                }
            }
        }

        //deep clone a dictionary
        private static Dictionary<string, IList<int[]>> cloneDict(Dictionary<string, IList<int[]>> dictionary) {
            var res = new Dictionary<string, IList<int[]>>();
            foreach (KeyValuePair<string, IList<int[]>> keyValuePair in dictionary) {
                IList<int[]> list = keyValuePair.Value.ToList();
                res.Add(keyValuePair.Key, list);
            }

            return res;
        }

        private static bool NextTo(int[] location, int[] location2) {
            // check that the row and column of 2 locations are at most one apart each
            return Math.Abs(location[0] - location2[0]) < 2 && Math.Abs(location[1] - location2[1]) < 2;
        }

        private bool InKeys(string val, Dictionary<string, IList<int[]>> locationsclone) {
            int length = val.Length;
            if (length < 1) return true;
            string remainder;
            string firstletter = GetFirstLetter(val, out remainder);
            //if the dictionary of locations contains the current letter as a key then that letter appears in the 
            // grid so proceed to the next letter
            if (locationsclone.ContainsKey(firstletter)) {
                //if there's only 1 location for this letter remove the key from the dictionary (ie after this use
                // there will be no more instances of the letter to use
                if (locationsclone[firstletter].Count == 1) locationsclone.Remove(firstletter);
                //if there's more than 1 copy of the letter just remove the one at this location and proceed
                else locationsclone[firstletter].Remove(locationsclone[firstletter][1]);
                return InKeys(remainder, locationsclone);
            }
            return false;
        }

        //Q's are a special case need to check for them and make the string to be looked for QU
        protected string GetFirstLetter(string word, out string remainder) {
            string firstletter = word.Substring(0, 1);
            if (word.Length == 1) {
                remainder = "";
                return firstletter;
            }
            if (firstletter == "Q" && word.Substring(1, 1) == "U") {
                firstletter = "QU";
                remainder = word.Substring(2, word.Length - 2);
            } else remainder = word.Substring(1, word.Length - 1);
            return firstletter;
        }
    }

    public class NumberBoggleGridVals : BoggleGridVals {
        private double target_;
        public override object[,] GetValues() {
            string tmpallvalues = "";
            values_ = new Object[Rows, Cols];
            locations_ = new Dictionary<string, IList<int[]>>();
            //loop through rows and columns and insert a random number in each cell
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Cols; j++) {

                    int value = getSkewedRandNum();
                    values_.SetValue(value, i, j);
                    SetLocation_(value.ToString(), i, j);
                    //store the value in a list of all values
                    tmpallvalues += value;
                }
            }
            allvalues_ = (string)tmpallvalues.Clone();
            return values_;
        }
        // trying to get a number with a min of 0 and max of 9, skewed to lower numbers but not too many 0s
        // NextDouble gives a number b/w 0 and 1, so this gives 1 number in (0.3,3.3) and one number in 
        // (0,3). Taking their product gives a number in (0,9.9) and flooring gives an int in [0,9]
        //NQR
        private int getSkewedRandNum() {
            double v1 = rand.NextDouble() * 3 + .3;
            double v2 = rand.NextDouble() * 3 + .2;
            return Math.Min((int)Math.Floor(v1 * v2), 9);
        }

        protected override object PrepareWord(string word) {
            var nums = Regex.Split(word, @"\D+");
            string str = "";
            foreach (string num in nums) str += num;
            return str;
        }
        protected override bool CheckDictionary(string word) {
            var eval = new MathEvaluator();
            return target_ == eval.Evaluate(word);
        }
        public string GetTarget(int numdigs) {
            int result = 0;
            string returnval="";
            //first digit returned is the ones, then tens and then hundreds (if needed)
            for (int i = 0; i < numdigs; i++){
                int skewedRandNum = getSkewedRandNum();
                result += skewedRandNum*(int)Math.Pow(10,i);
                returnval = skewedRandNum + returnval;
            }
            target_ = result;
            return returnval;
        }

        protected override bool ContainsDuplicate(List<string> userwords, string tocheck){
            string backwards = "";
            for (int i = tocheck.Length; i >0;i--)backwards += tocheck[i-1];
            bool res = userwords.Contains(backwards);
            return res || base.ContainsDuplicate(userwords, tocheck);
        }

    }

    public class WordBoggleGridVals : BoggleGridVals {
        private readonly List<string> dictionary_ = new List<string>();
        //cube values in regular 4x4 boggle
        private readonly string[] regularCubes = new[]{
                                        "AAEEGN","ELRTTY","AOOTTW","ABBJOO","EHRTVW","CIMOTV","DISTTY","EIOSST","DELRVY","ACHOPS","HIMNQU","EEINSU","EEGHNW","AFFKPS",
                                        "HLNNRZ","DEILRX"};

        // cube values in BigBoggle
        private readonly string[] bigCubes = new[]{
                                             "AFIRSY","ADENNN",	"AEEEEM",	"AAAFRS",	"AEGMNN",	"AAEEEE",	"AEEGMU",	"AAFIRS",	"BJKQXZ",	"CCENST",	
                                             "CEILPT",	"CEIILT","CEIPST",	"DHLNOR",	"DHLNOR",	"DDHNOT",	"DHHLOR",	"ENSSSU",	"EMOTTT",	"EIIITT",	
                                             "FIPRSY",	"GORRVW",	"IPRRRY",	"NOOTUW",	"OOOTTU"};
        // indicator for whether big or small boggle is being used

        public bool Big { get; set; }

        public WordBoggleGridVals(bool biggame) {
            Big = biggame;
            if (Big) Rows = Cols = 5;
            else Rows = Cols = 4;
            //the list of #letters used to score
            scores = new Dictionary<int, int> { { 3, 1 }, { 4, 1 }, { 5, 2 }, { 6, 3 }, { 7, 5 }, { 8, 11 } };
        }

        protected override int getscore(string word) {
            //words of less than 3 letters get nothing
            int length = word.Length;
            if (length < 3) return 0;
            //more than 8 letters gets the same score as 8 letters
            if (length > 8) return 11;
            return scores[length];
        }

        public override object[,] GetValues() {
            values_ = new Object[Rows, Cols];
            var remainingcubes = new string[Rows * Cols];
            string[] cubes;
            if (Big) cubes = bigCubes.Clone() as string[];
            else cubes = regularCubes.Clone() as string[];
            string tmpallvalues = "";
            //loop through rows and columns and insert a random number in each cell)
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Cols; j++) {
                    // trying to get a number with a min of 0 and max of 9, skewed to lower numbers but not too many 0s
                    // NextDouble gives a number b/w 0 and 1, so this gives 1 number in (0.3,3.3) and one number in 
                    // (0,3). Taking their product gives a number in (0,9.9) and flooring gives an int in [0,9]
                    //NQR
                    //randomly get an integer in [0,6] to pick which letter from the cube to choose
                    int letterfromcube = rand.Next(6);
                    //get a random integer in [0,remaining unused cubes) to pick the letter from
                    int numRemainingCubes = Rows * Cols - Cols * i - j;
                    int whichcube = rand.Next(numRemainingCubes);
                    //get the cube that corresponds the one chosen above
                    if (cubes != null){
                        var cubestring = cubes[whichcube];
                        //get the chosen letter from the cube specified
                        var value = cubestring.Substring(letterfromcube, 1);
                        //Q really means Qu
                        if (value == "Q") value = "Qu";
                        tmpallvalues += value;
                        SetLocation_(value.ToUpper(), i, j);
                        if (numRemainingCubes > 1) remainingcubes = new string[numRemainingCubes - 1];
                        int pos = 0;
                        //for debugging/testing algorithm write out the cube numbers and letter numbers used
                        /*using (StreamWriter file = new StreamWriter(@"d:\tmp.txt", true)){
                        file.WriteLine(letterfromcube);
                        if (numRemainingCubes == 1) file.WriteLine("end of game\n\n");
                    }
                    using (StreamWriter file = new StreamWriter(@"d:\whichcube.txt", true)){
                        file.WriteLine(whichcube);
                        if (numRemainingCubes == 1) file.WriteLine("end of game\n\n");
                    }  */
                        //Make the cubes array just contain the unused cubes (effectively remove the cube that has just been used)
                        for (int k = 0; k < cubes.Length; k++) {
                            if (k != whichcube) {
                                remainingcubes.SetValue(cubes[k], pos);
                                pos++;
                            }
                        }
                        cubes = (string[])remainingcubes.Clone();
                        values_.SetValue(value, i, j);
                    }
                }
            }
            allvalues_ = (string)tmpallvalues.Clone();
            return values_;
        }

        protected override bool CheckDictionary(string word){
            bool res = EnglishDictionary.Contains(word);
            return res || InDictionaryDotCom(word);
        }

        private static bool InDictionaryDotCom(string word){
            string url = "http://api-pub.dictionary.com/v001?vid=8138tjj32k0rvcqrdj0ftkp1p4umibpqdtz7diag2b&q=" + word +
                                      "&type=define&site=dictionary";
            var request =
                (HttpWebRequest)
                WebRequest.Create(
                    url);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            int tmp=-1;
            if (stream != null){
                var streamReader =
            new StreamReader(stream, Encoding.ASCII);
                string web = streamReader.ReadToEnd();
                int loc = web.IndexOf("totalresults");
                string numresults = web.Substring(loc + 14, 1);
                int.TryParse(numresults,out tmp);
            }
            return tmp >0;
        }

        private List<string> EnglishDictionary {
            get {
                //only reload the dictionary if it isn't already loaded
                if (dictionary_.Count == 0) {
                    // load the dictionary from a file either in the development folder
                    const string file = @"D:\Docs\Personal\Personalsvn\code\boggle\wordnet\wn_lemmaIndexes.lst";
                    // or from the current directory which should be the install directory for an installer version
                    const string defaultLoc = @"wn_lemmaIndexes.lst";
                    StreamReader sr;
                    if (File.Exists(file)) {
                        sr = new StreamReader(file);
                    }else if(File.Exists(defaultLoc))sr = new StreamReader(defaultLoc);
                    else {return dictionary_;}
                    //run through the whole file and load in each line
                    while (!sr.EndOfStream) {
                        string readLine = sr.ReadLine();
                        if (readLine != null) {
                            //find the first white space
                            int i = readLine.IndexOf(" ");
                            //load into the dictionary the text up to the white space
                            dictionary_.Add(readLine.Substring(0, i).ToUpper());
                        }
                    }
                }
                return dictionary_;
            }
        }
    }
}