using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures.List
{
    class DuplexLinkedList<T> : IEnumerable<T>
    {

        public DuplexNode<T> Head { get; set; }
        public DuplexNode<T> Tail { get; set; }
        public int Count { get; set; }

        public DuplexLinkedList() { }

        public DuplexLinkedList(T data)
        {
            var item = new DuplexNode<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        public void Add(T data)
        {

            var item = new DuplexNode<T>(data);

            if (Count == 0)
            {
                Head = item;
                Tail = item;
                Count = 1;
                return;
            }


            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            Count++;
        }

        public void Delete(T data)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return;
                }

                current = current.Next;
            }
        }

        public DuplexLinkedList<T> Reverse()
        {
            var result = new DuplexLinkedList<T>();

            var current = Tail;
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Previous;
            }

            return result;
        }
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        public IEnumerable<T> BackEnumerator()
        {
            DuplexNode<T> current = Tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

    }   
}

