using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema2_CalculadoraBasica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double valor1;
        private double valor2;
        private string signo;
        public MainWindow()
        {
            InitializeComponent();
            calculaButton.IsDefault = true;
            limpiaButton.IsCancel = true;

        }

        private void CalculaOperacion(object sender, RoutedEventArgs e)
        {
            Comprueba();

            this.valor1 = int.Parse(operando1Text.Text);
            this.valor2 = int.Parse(operando2Text.Text);
            this.signo = operadorSign.Text;

            switch(signo)
            {
                case "+":
                    resultado.Text = "" + (valor1 + valor2);
                    break;
                case "-":
                    resultado.Text = "" + (valor1 - valor2);
                    break;
                case "*":
                    resultado.Text = "" + (valor1 * valor2);
                    break;
                case "/":
                    resultado.Text = "" + (valor1 / valor2);
                    break;
            }
        }

        private void Comprueba()
        {
            if (operando1Text.Text is null || operando2Text.Text is null || operadorSign.Text is null)
            {
                MessageBox.Show("¡Los campos deben contener un valor!");
                throw new ArgumentNullException("¡Los campos deben contener un valor!");
            }
            else if (!operadorSign.Text.Contains("+") && !operadorSign.Text.Contains("-") && !operadorSign.Text.Contains("*") && !operadorSign.Text.Contains("/"))
            {
                MessageBox.Show("¡El campo no contiene los carácteres válidos!");
                throw new Exception("¡El campo no contiene los carácteres válidos!");
            }
            else if(operadorSign.Text.Length > 1)
            {
                MessageBox.Show("¡El campo no puede contener más de un signo!");
                throw new ArgumentException("¡El campo no puede contener más de un signo!");
            }
        }

        private void Limpiar(object sender, RoutedEventArgs e)
        {
            this.valor1 = 0;
            this.valor2 = 0; // Reseteamos los valores de las variables;
            this.signo = "";

            operando1Text.Text = "";
            operando2Text.Text = ""; // Vaciamos los campos
            operadorSign.Text = "";
            resultado.Text = "";
        }

        private void operadorSign_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (operadorSign.Text.Contains("+") || operadorSign.Text.Contains("-") || operadorSign.Text.Contains("*") || operadorSign.Text.Contains("/"))
            {
                if(operadorSign.Text.Length == 1)
                {
                    calculaButton.IsEnabled = true;
                }
                else
                {
                    calculaButton.IsEnabled = false;
                }
            }
            else
            {
                calculaButton.IsEnabled = false;
            }
        }
    }
}
