using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CustomDataStructures
{
    public class Tree<T>
    {
        private TreeNode root;

        public Tree()
        {
            root = new TreeNode();
        }

        public Tree(T t)
            : this()
        {
            root.Data = t;
        }


        private class TreeNode
        {
            private T data;

            public TreeNode()
            {
                data = default(T);
                children = new System.Collections.Generic.List<TreeNode>();
            }

            public TreeNode( T t ) : this()
            {
                this.data = t;
            }

            public T Data
            {
                get { return data; }
                set { data = value; }
            }

            private List<TreeNode> children;

            public void addChild( T t )
            {
                children.Add(new TreeNode(t));
            }

            public TreeNode getChild(T t)
            {
                return children.Find((TreeNode x) => x.data.Equals(t));
            }
        }
    }

    
}
