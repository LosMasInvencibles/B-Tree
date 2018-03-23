using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeExample.Interface;

namespace TreeExample
{
    #region firstCommit
    //public class Node<T> where T: IComparable
    //{
    //    //Listado de elementos (nodos)
    //    //Listado de hijos (nodos)
    //    public List<T> Values { get; set; }
    //    public List<int> Children { get; set; }
    //    public int Parent { get; set; }
    //    public int Position { get; set; }
    //}

    //public class BTree<T> where T: IComparable, IFixedSizeText
    //{
    //    //Se guarda en disco
    //    //Tiene raíz
    //    //Tiene un orden
    //    //Siempre está balanceado
    //    //No repetir valores

    //    public int Orden { get; set; }

    //    //public Node<T> Raiz { get; set; }
    //    //para no crearlo en memoria y solo obtener la posición en la que esté en el archivo
    //    public int Root { get; set; }

    //    public FileStream MyProperty { get; set; }
    //}
    #endregion

    /// <summary>
    /// B-Tree Node
    /// </summary>
    /// <typeparam name="T">Object type in B-Tree</typeparam>
    public class NodeB<T> where T: IComparable
    {
        /// <summary>
        /// Node Values
        /// </summary>
        public List<T> Values { get; private set; }
        /// <summary>
        /// Node Children
        /// </summary>
        public List<NodeB<T>> Children { get; set; }
        /// <summary>
        /// Order of Owner Tree
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Node Builder
        /// </summary>
        /// <param name="order">Order of Owner Tree</param>
        public NodeB(int order)
        {
            Order = order;
            Values = new List<T>();
            Children = new List<NodeB<T>>();
        }

        /// <summary>
        /// Node Values Invalid Count
        /// </summary>
        public bool OverFlowNodeValues
        {
            get
            {
                return Values.Count > Order - 1;
            }
        }

        /// <summary>
        /// Node Children Invalid Count
        /// </summary>
        public bool OverFlowNodeChildren
        {
            get
            {
                return Children.Count > Order;
            }
        }

        /// <summary>
        /// Node Value Invalid Count
        /// </summary>
        public bool UnderFlowNodeValues
        {
            get
            {
                return Values.Count < Order / 2 - 1;
            }
        }

        /// <summary>
        /// Node Children Invalid Count
        /// </summary>
        public bool UnderFlowNodeChildren
        {
            get
            {
                return Children.Count < Order / 2;
            }
        }

        /// <summary>
        /// Add Value to List Values
        /// </summary>
        /// <param name="value">Value to Add</param>
        public void AddValueToList(T value)
        {
            Values.Add(value);
            Values.Sort();
        }

        /// <summary>
        /// Divides Nodo into 2 parts by the middle value
        /// </summary>
        /// <param name="nodeLeft">Left partition</param>
        /// <param name="nodeRight">Right partition</param>
        /// <param name="valueToRoot">Middle value</param>
        public void SplitNode(out NodeB<T> nodeLeft, out NodeB<T> nodeRight, out T valueToRoot)
        {
            nodeLeft = new NodeB<T>(Order);
            nodeRight = new NodeB<T>(Order);
            int i = 0;
            while (i < Values.Count / 2)
            {
                nodeLeft.Values.Add(Values[i]);
                nodeLeft.addChildren(Children, i);
                i++;
            }
            valueToRoot = Values[i];
            i++;
            while (i < Values.Count)
            {
                nodeRight.Values.Add(Values[i]);
                nodeRight.addChildren(Children, i + 1);
                i++;
            }
        }

        /// <summary>
        /// Add children nodes from another node
        /// </summary>
        /// <param name="PrevchildrenList">List of children from other node</param>
        /// <param name="position">Position in List</param>
        private void addChildren(List<NodeB<T>> PrevchildrenList, int position)
        {
            try
            {
                Children.Add(PrevchildrenList[position]);
            }
            catch { }
        }
    }

}
