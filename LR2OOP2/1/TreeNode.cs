using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA
{   
        public class TreeNode<T>
        {
            public T Data { get; set; }
            public TreeNode<T> Left { get; set; }
            public TreeNode<T> Right { get; set; }

            public TreeNode(T data)
            {
                this.Data = data;
                this.Left = null;
                this.Right = null;
            }
        }
}
