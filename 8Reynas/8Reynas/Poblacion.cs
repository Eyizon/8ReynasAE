using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _8Reynas
{
    public class Poblacion
    {
        private Random rnd = new Random();
        public Cromosoma[] poblacionCromosomas { get; set; }
        public Cromosoma[] padres { get; set; }
        Cromosoma primerHijo = new Cromosoma();
        Cromosoma segundoHijo = new Cromosoma();

        public Poblacion()
        {
            poblacionCromosomas = new Cromosoma[100];
            padres = new Cromosoma[5];
            CrearPoblacion();
        }

        private void CrearPoblacion()
        {
            Console.WriteLine("creo una poblacion de "+poblacionCromosomas.Length);
            for (int i = 0; i < poblacionCromosomas.Length; i++)
            {
                poblacionCromosomas[i] = new Cromosoma();
                
            }
        }

        public void Cruza()
        {
            SeleccionarPadres();
            SustituirMenorAptitudPorHijo(CromosomaMenorAptitud(), primerHijo);
            SustituirMenorAptitudPorHijo(CromosomaMenorAptitud(), segundoHijo);
            padres = new Cromosoma[5];
        }

        public Cromosoma CromosomaMenorAptitud()
        {
            int index = 0;
            Cromosoma menorAptitud = poblacionCromosomas[0];
            foreach (var cromomosoma in poblacionCromosomas)
            {
                if (cromomosoma.aptitud > menorAptitud.aptitud)
                {
                    menorAptitud = cromomosoma;
                    menorAptitud.index = index;
                }
                index++;
            }
            return menorAptitud;
        }
        public Cromosoma CromosomaMayorAptitud()
        {
            Cromosoma mayorAptitud = CromosomaMenorAptitud();
            foreach (var cromomosoma in poblacionCromosomas)
            {
                if (cromomosoma.aptitud < mayorAptitud.aptitud)
                {
                    mayorAptitud = cromomosoma;
                }
            }
            return mayorAptitud;
        }

        public void SeleccionarPadres()
        {
            for (int i = 0; i < 5; i++)
            {
                int numero = rnd.Next(0, 100);
                padres[i] = poblacionCromosomas[numero];
            }
            int j;
            for (int i = 0; i < padres.Length; i++)
            {
                j = 1;
                while (j > 0 && j<padres.Length && padres[j - 1].aptitud > padres[j].aptitud)
                {
                    var aux = padres[j];
                    padres[j] = padres[j - 1];
                    padres[j - 1] = aux;
                    j = j - 1;
                }
            }
            crear_hijos(padres[0],padres[1]);
        }

        public void crear_hijos(Cromosoma primerPadre, Cromosoma segundoPadre)
        {
            
            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    primerHijo.cromosoma[i] = primerPadre.cromosoma[i];
                    segundoHijo.cromosoma[i] = segundoPadre.cromosoma[i];
                }
                else
                {
                    primerHijo.cromosoma[i] = segundoPadre.cromosoma[i];
                    segundoHijo.cromosoma[i] = primerPadre.cromosoma[i];
                }
            }
            primerHijo.cromosoma = mutar(primerHijo.cromosoma);
            primerHijo.SetAptitud();
            segundoHijo.cromosoma = mutar(segundoHijo.cromosoma);
            segundoHijo.SetAptitud();
        }

        public int[] mutar(int[] cromoMutacion)
        {
            int probabilidad = rnd.Next(0, 11);
            if (probabilidad > 1)
            {
                cromoMutacion[rnd.Next(0, 8)] = rnd.Next(0, 8);
            }
            return cromoMutacion;
        }

        public void SustituirMenorAptitudPorHijo(Cromosoma cromo,Cromosoma hijo)
        {
            Cromosoma[] aux = new Cromosoma[poblacionCromosomas.Length];
            int j = 0;
            for (int i = 0;i< poblacionCromosomas.Length; i++)
            {
                if(poblacionCromosomas[i] == cromo)
                {
                    poblacionCromosomas[i] = hijo;
                }
            }
        }

    }
}
