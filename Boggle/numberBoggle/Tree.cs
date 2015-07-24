using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boggle {
    public class Tree {
        public TreeNode Head { get; set; }

        //create a list of all the locations used in the tree
        public List<List<int[]>> AllLocations() {
            var locs = new List<List<int[]>>();
            var loc1 = new List<int[]>();
            GetLocations(loc1, locs, Head);
            return locs;
        }

        private static void GetLocations(List<int[]> loc1, List<List<int[]>> locs, TreeNode curr) {
            loc1.Add(curr.Location);
            if (curr.IsLeaf) locs.Add(loc1);
            else {
                int i = 0;
                List<List<int[]>> clonedlists = new List<List<int[]>>();
                for (int j = 0; j < curr.NumChildren-1; j++){
                    List<int[]> l = new List<int[]>();
                    foreach (int[] coords in loc1) l.Add(coords);
                    clonedlists.Add(l);
                }
                foreach (var treeNode in curr.Children) {
                    List<int[]> list;
                    if (i == 0) list = loc1;
                    else list = clonedlists[i - 1];
                    GetLocations(list, locs, treeNode);
                    i++;
                }
            }
        }
    }

    public class TreeNode {
        private TreeNode parent_;
        private readonly List<TreeNode> children_;

        public string Value { get; set; }

        public int Row {
            get {
                if (null == Location) return -1;
                return Location[0];
            }
        }
        public int Column {
            get {
                if (null == Location) return -1;
                return Location[1];
            }
        }

        public int[] Location { get; set; }

        public List<TreeNode> Children {
            get { return children_; }
            //            private set { children_ = value; }
        }

        public TreeNode(int[] location, string val) {
            Value = val;
            Location = location;
            children_ = new List<TreeNode>();
        }
        public TreeNode(TreeNode parent, int[] location, string val)
            : this(location, val) {
            Parent = parent;
        }

        public TreeNode Parent {
            get { return parent_; }
            set {
                if (parent_ == value) return;
                if (null != parent_) parent_.Children.Remove(this);
                if (null != value && !value.children_.Contains(this)) value.Children.Add(this);
                parent_ = value;
            }
        }

        public int NumChildren { get { return Children.Count; } }
        public bool IsLeaf { get { return 0 == NumChildren; } }
    }
}
