using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ControladorEncriptacion.Encrypt(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = ControladorEncriptacion.Decrypt(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {


            int asd =ControladorDigitosVerificadores.calcularDVH(textBox4.Text);

            textBox5.Text = asd.ToString();

        }
    }
}
