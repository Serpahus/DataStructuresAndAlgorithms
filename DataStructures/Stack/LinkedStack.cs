using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures.Stack
{
    public class LinkedStack<T>
    {
        public Item<T> Head { get; set; }
        public int Count { get; set; }


        public LinkedStack()
        {
            Head = null;
            Count = 0;
        }

        public LinkedStack(T data)
        {
            Head = new Item<T>(data);
            Count = 1;
        }
        //добавить новый элемент в стек. При этом этот элемент станет верхним. Add new element in stack
        public void Push(T data)
        {
            var item = new Item<T>(data);
            item.Previous = Head;
            Head = item;
            Count++;
        }
        //удалить верхний элемент из стека сохранив в переменную.При этом верхним станет элемент расположенный ниже удаленного.Remove first element in stack
        public T Pop()
        {
            if (Count > 0)
            {
                var item = Head;
                Head = Head.Previous;
                Count--;
                return item.Data;
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }
        }
       // прочитать верхний элемент стека, без удаления.При этом верхний элемент останется неизменным. Read first element without Remove
        public T Peek()
        {
            if (Count > 0)
            {
                return Head.Data;
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }
        }
    }
}
