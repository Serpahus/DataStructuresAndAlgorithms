using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures.BinarySearchTree
{
    class BinaryTreeNode<TNode> : IComparable<TNode>
     where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        public TNode Value { get; private set; }

        /// 
        /// Сравнивает текущий узел с данным.
        /// 
        /// Сравнение производится по полю Value.
        /// Метод возвращает 1, если значение текущего узла больше,
        /// чем переданного методу, -1, если меньше и 0, если они равны
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }


}
