using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeExample.Interface;

namespace TreeExample.TestTDA
{
    public class Estudiante : IComparable, IFixedSizeText
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Facultity { get; set; }
        public string Career { get; set; }

        public int CompareTo(object obj)
        {
            var s2 = (Estudiante)obj;
            return Id.CompareTo(s2.Id);
        }

        public int FixedSizeText
        {
            //return suma de todos los caracteres en ToFixedSizeString
            get { return FixedSize; }
        }

        public static int FixedSize { get { return 127; } }

        public string ToFixedSizeString()
        {
            //{0}|{1}|{2}|{3}|{4} para poner las propiedades
            //00000000000;-0000000000 nos devuelve un entero de longitud fija
            //"{0,-20}", Name  -- Nombre de 20 caracteres sin importar la longitud
            return string.Format("{0}|{1}|{2}|{3}|{4}\r\n", Id.ToString("00000000000;-0000000000"), string.Format("{0,-20}", Name)
                , string.Format("{0,-20}", LastName), string.Format("{0,-20}", Facultity), string.Format("{0,-50}", Career));
        }

        public override string ToString()
        {
            return string.Format("Carné: {0}\r\nNombre: {1}\r\nApellido: {2}\r\nFacultado: {3}\r\nCarrera: {4}\r\n"
                , Id.ToString("00000000000;-0000000000"), string.Format("{0,-20}", Name)
                , string.Format("{0,-20}", LastName), string.Format("{0,-20}", Facultity), string.Format("{0,-50}", Career));
        }
    }
}
