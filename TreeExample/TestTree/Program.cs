using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeExample;
using TreeExample.TestTDA;
using System.IO;
using TreeExample.Util;

namespace TestTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var estudiantes = new List<Estudiante>
            {
                new Estudiante
                {
                    Id = 1205917,
                    Name = "Rodrigo",
                    LastName = "Aguilar",
                    Facultity = "Ingeniería",
                    Career = "Ingeniería en Inormática y Sistemas"
                },

                new Estudiante
                {
                    Id = 1109117,
                    Name = "Emmanuel",
                    LastName = "Alvarado",
                    Facultity = "Ingeniería",
                    Career = "Ingeniería en Inormática y Sistemas"
                },
            };

            //Internamente hace Open y Close
            using (var fs = new FileStream("C:\\Users\\llaaj\\Desktop\\test.txt", FileMode.OpenOrCreate))
            {
                foreach (var item in estudiantes)
                {
                    fs.Write(ByteGenerator.ConvertToBytes(item.ToFixedSizeString()), 0, item.FixedSizeText);
                    //fs.Write(ByteGenerator.ConvertToBytes())
                }
            }

            //Leer
            var raiz = 2;
            var buffer = new byte[Estudiante.FixedSize];
            using (var fs = new FileStream("C:\\Users\\llaaj\\Desktop\\test.txt", FileMode.OpenOrCreate))
            {
                fs.Seek((raiz -1) * Estudiante.FixedSize, SeekOrigin.Begin);
                fs.Read(buffer, 0, Estudiante.FixedSize);
            }

            //Mostrar
            var nodeString = ByteGenerator.ConvertToString(buffer);
            var values = nodeString.Split('|');
            var student = new Estudiante
            {
                Id = Convert.ToInt32(values[0]),
                Name = values[1].Trim(),
                LastName = values[2].Trim(),
                Facultity = values[3].Trim(),
                Career = values[4].Trim()
            };
            Console.Write(student.ToString());

            Console.ReadKey();
        }
    }
}
