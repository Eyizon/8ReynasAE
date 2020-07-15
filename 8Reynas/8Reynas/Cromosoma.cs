using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Reynas
{
    /// <summary>
    /// Un cromosoma es una posible solucion, en este caso se compone de una seed de 8 digitos similar a  "[03476251]"
    /// </summary>
    public class Cromosoma
    {
        public int[] cromosoma;
        public int aptitud;
        public int index;

        private Random rnd;
        public Cromosoma()
        {
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 4));

            rnd = new Random(seed);
            cromosoma = new int[8];
            aptitud = 0;
            GenerarCromosoma();
            SetAptitud();
            ImprimirCromosomaConsola();
        }
        private void GenerarCromosoma()
        {
            for (int i = 0; i < 8; i++)
            {
                cromosoma[i] = rnd.Next(0, 8);
            }
        }

        public void SetAptitud()
        {
            aptitud = ComprobarAptitud();
        }
        public int ComprobarAptitud()
        {
            int i = 0, j = 0;
            int choqueReynas = 0;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (i != j)
                    {
                        if (cromosoma[i] == cromosoma[j])
                        {
                            choqueReynas++;
                        }
                        else if (cromosoma[i] - i == cromosoma[j] - j)
                        {
                            choqueReynas++;
                        }
                        else if (cromosoma[i] + i == cromosoma[j] + j)
                        {
                            choqueReynas++;
                        }
                    }
                }
            }
            return choqueReynas;
        }
        
        public void ImprimirCromosomaConsola()
        {
            string croma = "";
            for (int i = 0; i < cromosoma.Length; i++)
            {
                croma = croma + cromosoma[i];
            }
            Console.WriteLine("seed de este cromo: "+croma);
        }
    }
}
