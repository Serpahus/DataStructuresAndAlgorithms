using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures.List
{
    public class DuplexNode<T>
    {
        
            public T Data { get; set; }
            public DuplexNode<T> Previous { get; set; }
            public DuplexNode<T> Next { get; set; }

            public DuplexNode(T data)
            {
                Data = data;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        
    }
}
