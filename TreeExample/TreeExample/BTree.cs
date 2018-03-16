using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeExample.Interface;

namespace TreeExample
{
    public class Node<T> where T: IComparable
    {
        //Listado de elementos (nodos)
        //Listado de hijos (nodos)
        public List<T> Values { get; set; }
        public List<int> Children { get; set; }
        public int Parent { get; set; }
        public int Position { get; set; }
    }

    public class BTree<T> where T: IComparable, IFixedSizeText
    {
        //Se guarda en disco
        //Tiene raíz
        //Tiene un orden
        //Siempre está balanceado
        //No repetir valores

        public int Orden { get; set; }

        //public Node<T> Raiz { get; set; }
        //para no crearlo en memoria y solo obtener la posición en la que esté en el archivo
        public int Root { get; set; }

        public FileStream MyProperty { get; set; }
    }
}
