using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


namespace DataStructuresAndAlgorithms.DataStructures.SetWithList
{
    public class ListSet<T> : IEnumerable
    {
        private List<T> items = new List<T>();

        public int Count => items.Count;

        public ListSet()
        {

        }

        //for work methonds with linq 
        public ListSet(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }
        public ListSet(T item)

        {
            items.Add(item);
        }
        //добавление элемента. Если такой элемент уже присутствует, то он не будет добавлен.
        public void Add (T item)
        {
            //1 with linq 
            //if(items.Contains(item))
            //{
            //    return;
            //} 

            //2 add without using Linq
            foreach (var element in items)
            {
                if (element.Equals(item))
                {
                    return;
                }
            }

            items.Add(item);
        }
        //удаление элемента из множества.
        public void Remove (T item)
        {
            items.Remove(item);
        }
        //объединение множеств.Создается новое множество, включающее в себя все элементы из множества А и множества В.Если элемент содержится в обоих множествах, он будет добавлен однократно.
        public ListSet<T> Union (ListSet<T> set)
        {
            //with linq
            //return new ListSet<T>(items.Union(set.items));

            ListSet<T> result = new ListSet<T>();

             foreach (var item in items)
             {
              result.Add(item);
             }

             foreach (var item in set.items)
             {
                result.Add(item);
             }

            return result;
        }
        //пересечение множеств. Создается новое множество, включающее в себя все элементы входящие одновременно и в множество А, и в множество В.
        public ListSet<T> Intersection (ListSet<T> set)
        {
            //With linq
            //return new ListSet<T>(items.Intersect(set.items));

            ListSet<T> result = new ListSet<T>();
            ListSet<T> big;
            ListSet<T> small;
            if (Count >= set.Count)
            {
                big = this;
                small = set;
            }    
            else
            {
                big = set;
                small = this;
            }
            foreach (var item1 in small.items)
            {
                foreach (var item2 in big.items)
                {
                    if(item1.Equals(item2))
                    {
                        result.Add(item1);
                        break;
                    }
                }
            }
            return result;
        }
        // разность множеств. Создается новое множество, включающее в себя все элементы множества А, которые не входят в множество В
        public ListSet<T> Difference (ListSet<T> set)
        {
            //with linq 
            //return new ListSet<T>(items.Except(set.items));
            var result = new ListSet<T>(items);
            foreach (var item in set.items)
            {
                result.Remove(item);

            }
            return result;
        }
        //проверка на подмножество. Чтобы быть подмножеством, все элементы множества А должны содержаться в множестве В. Тогда А является подмножеством множества В.
        public bool Subset (ListSet<T> set)
        {
            //with linq 
          //return items.All(i => set.items.Contains(i));

            var result = new ListSet<T>();
           foreach(var item1 in items)
           {
                var equals = false;

                foreach(var item2 in items)
                {
                    equals = true;
                    break;
                }
                if (!equals)
                {
                    result.Add(item1);
                }
           }
            return true;       
        }

        public ListSet<T> SymmetricDifference(ListSet<T> set)
        {
            //With Linq
            // return new ListSet<T>(items.Except(set.items).Union(set.items.Except(items)));
            var result = new ListSet<T>();
            foreach(var item1 in items)
            {
                var equals = false;
                
                foreach(var item2 in set.items)
                {
                    if (item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }    
                } 
                
                if (equals == false)
                {
                    result.Add(item1);
                }
            
            }
            foreach (var item1 in set.items)
            {
                var equals = false;

                foreach (var item2 in items)
                {
                    if (item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }
                }

                if (equals == false)
                {
                    result.Add(item1);
                }

            }
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
        
}
