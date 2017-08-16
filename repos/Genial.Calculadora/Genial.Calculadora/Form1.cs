using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genial.Calculadora
{
    public partial class Form1 : Form
    {
        string op = string.Empty;
        double n = 0;
        bool validacao = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumerador_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtValor.Text += btn.Text;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ((validacao) && (!String.IsNullOrEmpty(txtValor.Text)) && op == btn.Text)
            {
                n = op == "+" ? n + Convert.ToDouble(txtValor.Text) :
                   (op == "-" ? n - Convert.ToDouble(txtValor.Text) :
                   (op == "/" ? n / Convert.ToDouble(txtValor.Text) : n * Convert.ToDouble(txtValor.Text)));
                
                label1.Text = Convert.ToString(n) + btn.Text;
            }
            else
            {
                label1.Text = txtValor.Text + btn.Text;
                n = Convert.ToDouble(txtValor.Text);
                validacao = true;
            }
            op = btn.Text;
            txtValor.Text = string.Empty;
        }

        private void btnIgual_Click_1(object sender, EventArgs e)
        {
            switch (op)
            {
                case "+":
                    CalcularSoma();
                    break;
                case "-":
                    CalcularSubtracao();
                    break;
                case "/":
                    CalcularDivisao();
                    break;
                case "x":
                    CalcularMultiplicacao();
                    break;
            }
        }

        private void CalcularSoma()
        {
            txtValor.Text = new Business.Calculadora(n, Convert.ToDouble(txtValor.Text)).Somar().ToString();
            PreencherLabel();
        }

        private void CalcularSubtracao()
        {
            txtValor.Text = new Business.Calculadora(n, Convert.ToDouble(txtValor.Text)).Subtrair().ToString();
            PreencherLabel();
        }

        private void CalcularDivisao()
        {
            txtValor.Text = new Business.Calculadora(n, Convert.ToDouble(txtValor.Text)).Dividir().ToString();
            PreencherLabel();
        }

        private void CalcularMultiplicacao()
        {
            txtValor.Text = new Business.Calculadora(n, Convert.ToDouble(txtValor.Text)).Multiplicar().ToString();
            PreencherLabel();
        }

        private void PreencherLabel()
        {
            label1.Text += txtValor.Text + "=";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtValor.Text) && label1.Text == string.Empty)
            {
                txtValor.Text = txtValor.Text.Remove(txtValor.Text.Length - 1);
            }
            else
            {
                LimparCampos();
            }
        }

        private void LimparCampos()
        {
            txtValor.Text = string.Empty;
            label1.Text = string.Empty;
            n = 0;
            validacao = false;
        }
    }
}
