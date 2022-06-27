using Rhino.Mocks.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RDI_Credit_Card
{
    public partial class Form1 : Form
    {
      

        public static string cardNumber { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparTela();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //they are number max
            const long textcardNumber = 16;
            const int textcardVal = 5;
            const int textcardDate = 4;


         
            if (textCreditCard.Text.Length < textcardNumber)
            {
                MessageBox.Show("Número do cartão de Credito tem que ser 16 Digitos !");
            }

            if (textCvv.Text.Length < textcardVal && textCvv.Text.Length <3 ) {

                MessageBox.Show("Número do código de segurança é de 5 digitos: Pode está entre 3 à 5 digitos !");
            
            }


            if (textDate.Text.Length < textcardDate) {

                MessageBox.Show("Número de Validade do Cartão de Credito são 4 Digitos (Mês/Ano:)");

            }

            else {

                validarCampo();
                MessageBox.Show("Transação realizada com Sucesso !!"+ "\nNúmero de seu cartão é: " +textCreditCard.Text);
                // It has calling the Last Digit of Credit Card method 
                ultimosdigitosCartao();
                tipodoCartao();
                stringRevers();

            }

            limparTela();

        }

        private void  stringRevers()
        {
            //It has doing number credit card reverse;
            string datarevers = textCvv.Text;

            
            string stringArray = datarevers;
            string reverse = string.Empty;
            for (int i = stringArray.Length - 1; i >= 0; i--)
            {
                reverse += stringArray[i];
            }
            MessageBox.Show("Número do Codigo CVV, reverso cartão: Primeira rotação é= " + reverse);
            

            
            //It has doing number credit card reverse:
            string datarevers2 = textCreditCard.Text;

            
            string stringArray2 = reverse;
            string reverse2 = string.Empty;

            for (int i = stringArray2.Length - 1; i >= 0; i--)
            {
                reverse2 += stringArray2[i];
            }
            MessageBox.Show("Número do Codigo CVV: Segunda rotação é= " + reverse2);
        }

        private void tipodoCartao() {
          //  It has taking element first of the string
            string first = textCreditCard.Text.Substring(0, 1);

            MessageBox.Show("Número de seu cartão é: " + first);
            /*
             * 3 – cartões de viagem / entretenimento ( American Express e Diners Club)

                4 – Visa

                5 – MasterCard

                6 – Discover Card
             */
            

            if (first == "3")
            {
                MessageBox.Show("Número de seu cartão de American Express ! " + "Primeiro digito: "+first);

            }

                
            if (first == "4") {
                MessageBox.Show("Número de seu cartão de Bandeira Visa ! "+ "Primeiro digito: "+first);


            }
            if (first == "5")
            {
                MessageBox.Show("Número de seu cartão de Bandeira MasterCard! " + "Primeiro digito: "+first);
            }
            if (first == "6")
            {
                MessageBox.Show("Número de seu cartão de Bandeira Discover Card !" + "Primeiro digito: " + first);
            }


        }

        private void limparTela() {
            textCreditCard.Text = string.Empty;
            textCvv.Text = string.Empty;
            textDate.Text = string.Empty;
        }
        private void ultimosdigitosCartao() {
            string lastDigit = textCreditCard.Text;
            //It has taking last digit credit card
            lastDigit.Substring(lastDigit.Length - 4);
            MessageBox.Show("Os últimos digitos de seu cartão são: " + lastDigit.Substring(lastDigit.Length - 4));

        }

        private void validarCampo() {

            if (String.IsNullOrEmpty(textCreditCard.Text))
            {
                MessageBox.Show("Faltou digitar: O número do cartão de credito");


            }

            if (String.IsNullOrEmpty(textCvv.Text))
            {
                MessageBox.Show("Faltou digitar: O número do código de segurança");
            }

            if (String.IsNullOrEmpty(textDate.Text))
            {
                MessageBox.Show("Faltou digitar: A validade do cartão");
            }

            else
            {
                exportandoExcel();
               

            }



        }
    

        private void exportandoExcel() {

            string first = textCreditCard.Text.Substring(0, 1);


            // It has taking fields of the credit card and it has saving in cvs file
            var dadosCartao = "Card Credit Number:" +
                textCreditCard.Text +
                "; Card Credit Date: " +
                textDate.Text + "; Code Card Credit:" + textCvv.Text +
                ";Last Digit Credit Card: " +
                textCreditCard.Text.Substring(textCreditCard.Text.Length - 4) + "; Tipo de Cartao: " + first +
                "; Bank Time Operation: " + DateTime.Now.ToString();//It has taking on time now


            //It has working: It has saving it cvs file
            using (StreamWriter file = new StreamWriter(@"C:\dadoscharp\dados.csv"))
            {
                string[] lines = { "New line 1", "New line 2" };
                file.WriteLine(dadosCartao, lines);

                string text = "First line" + Environment.NewLine;

               
            }
        }

        private void textCreditCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Just it has aceptting number
            if (!char.IsDigit(e.KeyChar))
            {
                //It has doing cancel the event
                e.Handled = true;
            }
        }

        private void textDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Just it has aceptting number
            if (!char.IsDigit(e.KeyChar))
            {
                //It has doing cancel the event
                e.Handled = true;
            }
        }

        private void textCvv_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Just it has aceptting number of the code credit cart
            if (!char.IsDigit(e.KeyChar))
            {
                //It has doing cancel the event of the code credit cart
                e.Handled = true;
            }
        }
        

    }

}
