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
            calcularEuler();
            calcularEulerMejorado();
        }

        private void txtMaxX_KeyPress(object sender, KeyPressEventArgs e)
        {
            checarDatosIntroducidos(sender, e);
            llamarCalculoConEnter(e);
        }

        private void txtXo_KeyPress(object sender, KeyPressEventArgs e)
        {
            checarDatosIntroducidos(sender, e);
            llamarCalculoConEnter(e);
        }

        private void txtYo_KeyPress(object sender, KeyPressEventArgs e)
        {
            checarDatosIntroducidos(sender, e);
            llamarCalculoConEnter(e);
        }

        private void txtH_KeyPress(object sender, KeyPressEventArgs e)
        {
            checarDatosIntroducidos(sender, e);
            llamarCalculoConEnter(e);
        }
        private void llamarCalculoConEnter(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                calcularEuler();
                calcularEulerMejorado();
                e.Handled = true;
            }
        }
        private void checarDatosIntroducidos(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Sólo permite un punto decimal.
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void calcularEuler()
        {
            this.dgvEuler.Rows.Clear();
            if (txtH.Text == "" || txtMaxX.Text == "" || txtXo.Text == "" || txtYo.Text == "")
            {
                DialogResult error = MessageBox.Show("Por favor, revise que no haya ninguna caja de texto en blanco.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double xn = 0, yn = 4, h = 0, y = 0, tope = 2;
                int contador = 0;
                try
                {
                    xn = double.Parse(txtXo.Text);
                    yn = double.Parse(txtYo.Text);
                    h = 0;
                    y = 0;
                    tope = double.Parse(txtMaxX.Text);

                    while (xn < tope)
                    {
                        double raiz = Math.Sqrt(y);
                        double denominador = (2 * xn) + 1;
                        double porcentajes;
                        y = yn + (h * (raiz / denominador));
                        xn = xn + h;
                        h = double.Parse(txtH.Text, CultureInfo.InvariantCulture);
                        yn = y;
                        double ecuacion = Math.Pow((Math.Log((2 * xn) + 1) / 4) + 2, 2);
                        porcentajes = Math.Abs(((ecuacion - y) / ecuacion) * 100);
                        dgvEuler.Rows.Add(
                            Convert.ToString(contador),
                            Convert.ToString(Math.Round(xn, 6, MidpointRounding.AwayFromZero)),
                            Convert.ToString(Math.Round(ecuacion, 6, MidpointRounding.AwayFromZero)),
                            Convert.ToString(Math.Round(y, 6, MidpointRounding.AwayFromZero)),
                            Convert.ToString(Math.Round(porcentajes, 6, MidpointRounding.AwayFromZero)) + "%");
                        contador++;
                    }
                }
                catch (FormatException)
                {
                    DialogResult error = MessageBox.Show("Error en el formato de los datos introducidos. Por favor, introduzca sólo números.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void calcularEulerMejorado()
        {
            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.HeaderText = "YEulerMejorado";
            c6.Width = 80;
            c6.ReadOnly = true;

            DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            c7.HeaderText = "PorcentajeMejorado";
            c7.Width = 80;
            c7.ReadOnly = true;

            dgvEuler.Columns.Add(c6);
            dgvEuler.Columns.Add(c7);

            if (txtH.Text == "" || txtMaxX.Text == "" || txtXo.Text == "" || txtYo.Text == "")
            {
                DialogResult error = MessageBox.Show("Por favor, revise que no haya ninguna caja de texto en blanco.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double x0 = 0;
                double y0 = 0;
                double h = 0;
                double tope = 0f;
                double y = 0;
                double yn = 0;
                double xn = 0;
                double ecua;
                double ecuaum;
                try
                {
                    x0 = double.Parse(txtXo.Text);
                    y0 = double.Parse(txtYo.Text);
                    h = 0;
                    y = 0;
                    tope = double.Parse(txtMaxX.Text);

                    while (xn < tope)
                    {
                        double porcentajes;
                        double raiz = (double)Math.Sqrt(y0);
                        double denominador = (2 * x0) + 1;
                        ecua = raiz / denominador;
                        yn = (y0 + (h * ecua));
                        xn = x0 + h;
                        double raizaum = (double)Math.Sqrt(yn);
                        double denominadoraum = (2 * xn) + 1;
                        ecuaum = raizaum / denominadoraum;
                        y = y0 + (h / 2) * (ecua + ecuaum);
                        double yreal = (double)Math.Pow((Math.Log((2 * xn) + 1) / 4) + 2, 2);
                        h = double.Parse(txtH.Text, CultureInfo.InvariantCulture);
                        porcentajes = Math.Abs(((yreal - y) / yreal) * 100);
                        x0 = xn;
                        y0 = y;

                        dgvEuler.Rows.Add(
                            Convert.ToString(Math.Round(y, 6, MidpointRounding.AwayFromZero)),
                            Convert.ToString(Math.Round(porcentajes, 6, MidpointRounding.AwayFromZero)) + "%");
                    }

                }
                catch (FormatException)
                {
                    DialogResult error = MessageBox.Show("Error en el formato de los datos introducidos. Por favor, introduzca sólo números.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void llenado(double n, double xn, double yreal, double Ere, double ynem, double erem)
        {


        }


    }
}
