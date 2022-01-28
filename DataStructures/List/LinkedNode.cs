using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures.List
{
    public class LinkedNode<T> : IEnumerable
    {
        private Node<T> head;

        private Node<T> tail;

        private int Count { get; set; }

        public void Add (T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            Count++;
        }

        public void AddFirst (T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (Count == 0)
            {
                tail = head;
            }
            Count++;
        }
        public void AddWithoutTail(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                Node<T> current = head;
                // ищем последний элемент
                while (current.Next != null)
                {
                    current = current.Next;
                }
                //устанавливаем последний элемент
                current.Next = node;
            }
            Count++;
        }
        public bool Delete(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
