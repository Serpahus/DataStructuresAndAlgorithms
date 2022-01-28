using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures.BinarySearchTree
{
    public class BinaryTree<T> : IEnumerable<T>
    where T : IComparable<T>
    {
        private BinaryTreeNode<T> root;
        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
        }
        public void Clear()
        {
            root  = null;
            _count = 0;
        }

        public void Add(T value)
        {
            // Первый случай: дерево пустое     

            if (root == null)
            {
                root = new BinaryTreeNode<T>(value);
            }

            // Второй случай: дерево не пустое, поэтому применяем рекурсивный алгоритм 
            //                для поиска места добавления узла        

            else
            {
                AddTo(root, value);
            }
            _count++;
        }

        // Рекурсивный алгоритм 

        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            // Первый случай: значение добавляемого узла меньше чем значение текущего. 

            if (value.CompareTo(node.Value) < 0)
            {
                // если левый потомок отсутствует - добавляем его          

                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // повторная итерация               
                    AddTo(node.Left, value);
                }
            }
            // Второй случай: значение добавляемого узла равно или больше текущего значения      
            else
            {
                // Если правый потомок отсутствует - добавлем его.          

                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // повторная итерация

                    AddTo(node.Right, value);
                }
            }
        }
        public bool Contains(T value)
        {
            //Поиск узла осуществляется другим методом.
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;

            // Находим удаляемый узел.
            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            _count--;

            //Случай 1: Если нет детей справа,
            //левый ребенок встает на место удаляемого.
            if (current.Right == null)
            {
                if (parent == null)
                {
                    root = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        //Если значение родителя больше текущего,
                        //левый ребенок текущего узла становится левым ребенком родителя.
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        //Если значение родителя меньше текущего,
                        // левый ребенок текущего узла становится правым ребенком родителя.
                        parent.Right = current.Left;
                    }
                }
            }
            //Случай 2: Если у правого ребенка нет детей слева
            //то он занимает место удаляемого узла.
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    root = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        //Если значение родителя больше текущего,
                        //правый ребенок текущего узла становится левым ребенком родителя.
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        //Если значение родителя меньше текущего,
                        // правый ребенок текущего узла становится правым ребенком родителя.
                        parent.Right = current.Right;
                    }
                }
            }
            //Случай 3: Если у правого ребенка есть дети слева,
            //крайний левый ребенок 
            //из правого поддерева заменяет удаляемый узел.
            else
            {

                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                // поиск крайнего левого потомка 
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // Правое поддерево крайнего левого узла, становится левым поддеревом его родительского узла.         
                leftmostParent.Left = leftmost.Right;

                // Присваиваем крайнему левому узлу в качестве левого потомка - левый потомок удаляемого узла,
                // а в качестве правого потомка - правый потомок удаляемого узла. 

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    root = leftmost;
                }

                else
                {
                    int result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {

                        // Если значение родительского узла(parent), больше значения удаляемого узла (current) -                  
                        // сделать левого крайнего потомка удаляемого узла(leftmost)  - левым потомком его родителя(parent). 

                        parent.Left = leftmost;
                    }

                    else if (result < 0)
                    {

                        // Если значение родительского узла(parent), меньше значения удаляемого узла (current) -                  
                        // сделать левого крайнего потомка удаляемого узла(leftmost) - правым потомком его родителя(parent).

                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            //Попробуем найти значение в дереве.
            BinaryTreeNode<T> current = root;
            parent = null;

            //До тех пор, пока не нашли...
            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    //Если искомое значение меньше, идем налево.
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    //Если искомое значение больше, идем направо.
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    //Если равны, то останавливаемся
                    break;
                }
            }

            return current;
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
        }

        private void InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
                InOrderTraversal(node.Left);

            Console.WriteLine(node.Value);

            if (node.Right != null)
                InOrderTraversal(node.Right);
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(root);
        }

        private void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
                PostOrderTraversal(node.Left);

            if (node.Right != null)
                PostOrderTraversal(node.Right);

            Console.WriteLine(node.Value);
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(root);
        }

        private void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            Console.WriteLine(node.Value);

            if (node.Left != null)
                PreOrderTraversal(node.Left);

            if (node.Right != null)
                PreOrderTraversal(node.Right);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
    

      