using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA
{ 
        public class BinaryTree<T> where T : class
        {
            public TreeNode<T> Root { get; set; }

            public BinaryTree()
            {
                Root = null;
            }

            public void DisplayTree()
            {
                Console.WriteLine("Binary Tree Structure:");
                PrintNode(Root, 0);
            }

            private void PrintNode(TreeNode<T> node, int indent)
            {
                if (node == null)
                {
                    return;
                }

                string indentString = new string(' ', indent * 4);
                Console.WriteLine($"{indentString}+-- {node.Data.ToString()}");

                PrintNode(node.Left, indent + 1);
                PrintNode(node.Right, indent + 1);
            }
        }
}