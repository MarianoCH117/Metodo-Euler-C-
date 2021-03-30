using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metodo_Euler
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "Iteracion";
            c1.Width = 100;
            c1.ReadOnly = true;
            dgvEuler.Columns.Add(c1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvEuler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCalcularEuler_Click(object sender, EventArgs e)
        {
            double xn = 0;
            double yn = 4;
            double h = 0;
            double y = 0;
            double tope = 2f;
            int contador = 0;

            while (xn < tope)
            {
                double raiz = Math.Sqrt(y);
                double denominador = (2 * xn) + 1;
                double porcentajes;
                y = yn + (h * (raiz / denominador));
                //Console.Write("Vuelta: " + contador + "El valor de la ecuacion es:");
                //Console.WriteLine("{0:N6}", y);
                contador++;
                xn = xn + h;
                h = 0.25f;
                yn = y;
                double ecuacion = Math.Pow((Math.Log((2 * xn) + 1) / 4) + 2, 2);
                //Console.Write("El valor de la ecuacion chido es :");
                //Console.WriteLine("{0:N6}", ecuacion);
                porcentajes = ((ecuacion - y) / ecuacion) * 100;
                //Console.Write("Porcentaje: ");
                //Console.WriteLine("{0:N1}", +Math.Abs(porcentajes));
                dgvEuler.Rows.Add(contador);
            }

            

        }
    }
}
