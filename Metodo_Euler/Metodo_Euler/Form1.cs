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
            c2.HeaderText = "Xi";
            c2.Width = 80;
            c2.ReadOnly = true;

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "f(xi)";
            c3.Width = 80;
            c3.ReadOnly = true;

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.HeaderText = "f'(x)";
            c4.Width = 80;
            c4.ReadOnly = true;

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.HeaderText = "|xi-xi-1|";
            c5.Width = 150;
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
            if (txtXi.Text == "")
            {
                DialogResult error = MessageBox.Show("Por favor, revise que no haya ninguna caja de texto en blanco.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {                
                double x = double.Parse(txtXi.Text, CultureInfo.InvariantCulture);
                int n = 0;
                double xi;
                double errorabs = 9999999;
                try
                {
                    while (errorabs != 0)
                    {
                        if (errorabs == 9999999)
                        {               
                            
                            double ecuacion = Math.Round((Math.Round(Math.Pow(x, 3), 6, MidpointRounding.AwayFromZero) + Math.Round((4 * Math.Pow(x, 2)), 6, MidpointRounding.AwayFromZero) - 10), 6, MidpointRounding.AwayFromZero);           
                            double ecuacionDerivada = (3 * (Math.Round(Math.Pow(x, 2), 6, MidpointRounding.AwayFromZero)) + (8 * x));               
                            xi = Math.Round((x - (ecuacion / ecuacionDerivada)), 6, MidpointRounding.AwayFromZero);                                                   
                            dgvEuler.Rows.Add(
                            Convert.ToString(n),
                            Convert.ToString(x),
                            Convert.ToString(Math.Round(ecuacion, 6, MidpointRounding.AwayFromZero)),
                            Convert.ToString(Math.Round(ecuacionDerivada, 6, MidpointRounding.AwayFromZero)),
                            Convert.ToString("No existe"));
                            errorabs = xi - x;
                            x = xi;
                            n++;

                        }
                        else
                        {
                            double ecuacion = Math.Round((Math.Round(Math.Pow(x, 3), 6, MidpointRounding.AwayFromZero) + Math.Round((4 * Math.Pow(x, 2)), 6, MidpointRounding.AwayFromZero) - 10), 6, MidpointRounding.AwayFromZero);                            
                            double ecuacionDerivada = (3 * (Math.Round(Math.Pow(x, 2), 6, MidpointRounding.AwayFromZero)) + (8 * x));                            
                            xi = Math.Round((x - (ecuacion / ecuacionDerivada)), 6, MidpointRounding.AwayFromZero);
                            dgvEuler.Rows.Add(
                            Convert.ToString(n),
                            Convert.ToString(Math.Round(x, 6, MidpointRounding.AwayFromZero)),
                            Convert.ToString(Math.Round(ecuacion, 6, MidpointRounding.AwayFromZero)),
                            Convert.ToString(Math.Round(ecuacionDerivada, 6, MidpointRounding.AwayFromZero)),
                            Convert.ToString(Math.Abs(Math.Round(errorabs, 6, MidpointRounding.AwayFromZero))) + "%");
                            errorabs = xi - x;
                            x = xi;
                            n++;

                            if (errorabs == 0)
                            {
                                ecuacion = Math.Round((Math.Round(Math.Pow(x, 3), 6, MidpointRounding.AwayFromZero) + Math.Round((4 * Math.Pow(x, 2)), 6, MidpointRounding.AwayFromZero) - 10), 6, MidpointRounding.AwayFromZero);   
                                ecuacionDerivada = (3 * (Math.Round(Math.Pow(x, 2), 6, MidpointRounding.AwayFromZero)) + (8 * x));
                                Console.WriteLine("F'(X):  " + ecuacionDerivada);
                                xi = Math.Round((x - (ecuacion / ecuacionDerivada)), 6, MidpointRounding.AwayFromZero);                     
                                dgvEuler.Rows.Add(
                                Convert.ToString(n),
                                Convert.ToString(Math.Round(x, 6, MidpointRounding.AwayFromZero)),
                                Convert.ToString(Math.Round(ecuacion, 6, MidpointRounding.AwayFromZero)),
                                Convert.ToString(Math.Round(ecuacionDerivada, 6, MidpointRounding.AwayFromZero)),
                                Convert.ToString(Math.Abs(Math.Round(errorabs, 6, MidpointRounding.AwayFromZero))) + "%");
                                errorabs = xi - x;
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    DialogResult error = MessageBox.Show("Error en el formato de los datos introducidos. Por favor, introduzca sólo números.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtH_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
