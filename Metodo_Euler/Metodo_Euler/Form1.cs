using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

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
            c1.HeaderText = "n";
            c1.Width = 30;
            c1.ReadOnly = true;

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "Xn";
            c2.Width = 80;
            c2.ReadOnly = true;

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "Yreal";
            c3.Width = 80;
            c3.ReadOnly = true;

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.HeaderText = "Yeuler";
            c4.Width = 80;
            c4.ReadOnly = true;

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.HeaderText = "Ere";
            c5.Width = 80;
            c5.ReadOnly = true;

            dgvEuler.Columns.Add(c1);
            dgvEuler.Columns.Add(c2);
            dgvEuler.Columns.Add(c3);
            dgvEuler.Columns.Add(c4);
            dgvEuler.Columns.Add(c5);
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
            this.dgvEuler.Rows.Clear();
            double xn = double.Parse(txtXo.Text);
            double yn = double.Parse(txtYo.Text);
            double h = 0;
            double y = 0;
            double tope = double.Parse(txtMaxX.Text);
            
            
            int contador = 0;


            while (xn < tope)
            {
                double raiz = Math.Sqrt(y);
                double denominador = (2 * xn) + 1;
                double porcentajes;
                y = yn + (h * (raiz / denominador));
                //Console.Write("Vuelta: " + contador + "El valor de la ecuacion es:");
                //Console.WriteLine("{0:N6}", y);                
                xn = xn + h;
                label1.Text = Convert.ToString(txtH.Text);
                h = double.Parse(txtH.Text, CultureInfo.InvariantCulture);
                yn = y;
                double ecuacion = Math.Pow((Math.Log((2 * xn) + 1) / 4) + 2, 2);
                //Console.Write("El valor de la ecuacion chido es :");
                //Console.WriteLine("{0:N6}", ecuacion);
                porcentajes = Math.Abs(((ecuacion - y) / ecuacion) * 100);
                //Console.Write("Porcentaje: ");
                //Console.WriteLine("{0:N1}", +Math.Abs(porcentajes));
                dgvEuler.Rows.Add(
                    Convert.ToString(contador),
                    Convert.ToString(Math.Round(xn, 7)),
                    Convert.ToString(Math.Round(ecuacion, 7)),
                    Convert.ToString(Math.Round(y, 7)),
                    Convert.ToString(Math.Round(porcentajes, 7)) + "%");
                contador++;
            }
        }
    }
}
