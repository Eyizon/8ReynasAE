using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8Reynas
{
    public partial class Reynas : Form
    {
        public int[] primerHijo = new int[8];
        public int[] segundoHijo = new int[8];

        public int[] tableroCorrecto = new int[8];
        public int solucionCorrecta = 0;
        private int numeroEjecuciones;
        private int numeroEjecucionesCorrectas;
        bool detener = false;
        public Reynas()
        {
            InitializeComponent();
            numeroEjecuciones = 0;
        }

        public void BuscarSolucion()
        {
            Cromosoma cromocorrecto = new Cromosoma();
            Poblacion poblation = new Poblacion();
            int i = 0;
            detener = false;
            while (i < 10000)
            {
                cromocorrecto = poblation.CromosomaMayorAptitud();
                if (cromocorrecto.aptitud == 0)
                {
                    TablerosBinarios.AppendText("Ejecucion: "+ (numeroEjecuciones + 1) + Environment.NewLine + Environment.NewLine);
                    TablerosBinarios.AppendText("Iteracion: "+ i + " Aptitud Amenazas: "+ cromocorrecto.aptitud + Environment.NewLine + Environment.NewLine);
                    Tablero(cromocorrecto);
                    numeroEjecucionesCorrectas++;
                    break;
                }
                poblation.Cruza();                
                i += 1;                
                //Console.WriteLine("iteracion "+i);
            }
            numeroEjecuciones++;
            labelEjecuciones.Text = numeroEjecuciones.ToString();
            labelExecCorrectas.Text = numeroEjecucionesCorrectas.ToString();
        }


        public void Tablero(Cromosoma cromo)
        {
            char[,] matriz = new char[8,8];
            int X = 0, Y = 0;
            for (X = 0; X < 8; X++)
            {
                for (Y = 0; Y < 8; Y++)
                {
                    matriz[X,Y] = '0';
                    if (X == cromo.cromosoma[Y])
                    {
                        matriz[X,Y] = '1';
                    }
                    TablerosBinarios.Text = TablerosBinarios.Text + matriz[X, Y];                    
                }
                TablerosBinarios.AppendText(Environment.NewLine);
            }
            TablerosBinarios.AppendText(Environment.NewLine);
        }

        public void TableroGrafico(Cromosoma cromo)
        {
            char[,] matriz = new char[8, 8];
            int X = 0, Y = 0;
            int contador = 1;
            for (X = 0; X < 8; X++)
            {
                for (Y = 0; Y < 8; Y++)
                {
                    matriz[X, Y] = '0';
                    if (X == cromo.cromosoma[Y])
                    {

                    }
                    contador++;
                }
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if(txtNumExec.Text != null && txtNumExec.Text != "")
            {
                int numExec = int.Parse(txtNumExec.Text);
                for(int i = 0; i < numExec; i++)
                {
                    BuscarSolucion();
                }

            }
            else
            {
                BuscarSolucion();
            }
            
        }

        private void btnAcomodarReynas_Click(object sender, EventArgs e)
        {
            AsignarColorReyna(pictureBox3);
        }
        public void AsignarColorReyna(PictureBox picture)
        {
            if(picture.Name == "pictureBox" + 3)
            {
                picture.Image = Reyna1.Image;
                picture.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            detener = true;
        }

        private void txtNumExec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
