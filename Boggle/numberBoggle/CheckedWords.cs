using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boggle {
    public class CheckedWords{
        public string Word { get; set; }
        public bool InGrid { get; set; }
        public bool MatchesTarget { get; set; }
        public List<List<int[]>> Locations { get; set; }
        public int Score { get; set; }
        public string FirstMatch{
            get {
                //return the first set of cells that match this word
                if (Locations.Count == 0) return "";
                var list = Locations[0];
                string res="";
                foreach (var loc in list){
                    if(res.Length>0) res = res + ",";
                    res = res + loc[0] + loc[1];
                }
                return res;
            }
        }

        public CheckedWords(string word,bool match,List<List<int[]>> locs,int score):this(word,match,true,locs,score){}
        public CheckedWords(string word,bool ingrid,bool indict,List<List<int[]>> locs, int score){
            Word = word;
            InGrid = ingrid;
            MatchesTarget = indict;
            Locations = locs;
            Score = score;
        }
    }

}
