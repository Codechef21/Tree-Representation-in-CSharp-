using System;
using System.Collections.Generic;

namespace RepresentationOfTree
{
    public class TreeNode<T>
    {
        //Contains the value of the node
        private T value;

        //shows wether the current node has a parent or not
        private bool hasParent;

        //Contains the children of the node(zero or more)
        private List<TreeNode<T>> children;

        //Constructing a tree node
        //Taking parameter "Value" as the value of the node
        public TreeNode(T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value), "Can not insert null value");
            }
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        //Getting and setting the value of the node
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        //Number of nodes children
        public int CountingChildren
        {
            get
            {
                return this.children.Count;
            }
        }

        //Adding method of the children to the node
        //The parameter is taken child

        public void AddChild(TreeNode<T> child)
        {
            if(child == null)
            {
                throw new ArgumentNullException(nameof(child), "Cannot insert value");
            }
            if(child.hasParent)
            {
                throw new ArgumentException("The node has already a parent");
            }

            child.hasParent = true;
            this.children.Add(child);

        }

        //Get the children of the node in the given index
        //return the child in the desired position

        public TreeNode<T>GetChild(int index)
        {
            return this.children[index];
        }

    }

    //Reprensting a tree data structure
    //Parameter type T is the type of values in the tree
    public class Tree<T>
    {
        //The root of the tree
        private TreeNode<T> root;

        //Constructing the tree
        //value the of the node will be in the parameter value
        public Tree (T  value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value), "Cannot insert null value");
            }

            this.root = new TreeNode<T>(value);
        }

        //Constructing the whole tree

        public Tree(T value, params Tree<T>[]children):this(value)
        {
            foreach(Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        //The root node is null if the tree is empty then only return root node
        public TreeNode<T>Root
        {
            get
            {
                return this.root;
            }
        }

        //Traversing and prints tree in DFS(Depth First Search) manner
        //The parameter spaces is used to represent the parent-child relationship

        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if(this.root == null)
            {
                return;
            }
            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;
            for (int i = 0; i < root.CountingChildren; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + " ");
            }
        }
        public void TraverseDFS()
        {
            this.PrintDFS(this.root, string.Empty);
        }
    }
    public static class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree =
                new Tree<int>(7,
                new Tree<int>(19,
                new Tree<int>(1),
                new Tree<int>(12),
                new Tree<int>(31)),
                new Tree<int>(21),
                new Tree<int>(14,
                new Tree<int>(23),
                new Tree<int>(6))
                );
            //Traverse and print using DFS
            tree.TraverseDFS();
        }
    }
}
