using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora() //laCalculadora?
        {
            InitializeComponent();

            this.cmbOperator.Items.Add("+"); /*tambien se podria hacer un string con todos los operadores y un foreach que los cargue como por ejemplo cuando cragamos los colores. considere ams facil esta forma siendo que son solo estos los operadores y que no estan precargados*/
            this.cmbOperator.Items.Add("-");
            this.cmbOperator.Items.Add("*");
            this.cmbOperator.Items.Add("/");

            btnConvABinario.Enabled = false;
            btnConvADecimal.Enabled = false;
        }

        //botones
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvABinario_Click(object sender, EventArgs e)
        {
            Numero aBinario = new Numero();
            lblResultado.Text = aBinario.DecimalBinario(lblResultado.Text);
            btnConvABinario.Enabled = false;
            btnConvADecimal.Enabled = true;
        }

        private void btnConvADecimal_Click(object sender, EventArgs e)
        {
            Numero aDecimal = new Numero();
            lblResultado.Text = aDecimal.BinarioDecimal(lblResultado.Text);
            btnConvADecimal.Enabled = false;
            btnConvABinario.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        ///Boton para realizar operacion llamando a operar y poner el resultado en lblRes. Tambien, al existir un resultado, permite el paso a bin/dec
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = (Operar(txtBoxNum1.Text, txtBoxNum2.Text, cmbOperator.Text)).ToString();
            btnConvABinario.Enabled = true;
            btnConvADecimal.Enabled = false;
        }


        /// <summary>
        /// Metodo para limpiar TextBox, ComboBox y Label de la pantalla. Tambien ddesactiva conv a dec/bin
        /// </summary>
        private void Limpiar()
        {
            this.txtBoxNum1.Text = "";
            this.txtBoxNum2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperator.SelectedIndex = -1;
            btnConvABinario.Enabled = false;
            btnConvADecimal.Enabled = false;
        }

        /// <summary>
        /// Opera valores pasados
        /// </summary>
        /// <param name="numero1">Numero 1 string pasado</param>
        /// <param name="numero2">Numero 2 string pasado</param>
        /// <param name="operador">Operador string pasado</param>
        /// <returns>Resultado</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
