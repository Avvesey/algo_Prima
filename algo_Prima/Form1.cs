using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algo_Prima
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\r\n";
            foreach (Edge elements in Data.output)
            {
                textBox1.Text += elements.ToString() + "\r\n";
            }
            textBox1.Text += ("\r\n" + "Время выполнения: " + (Program.sw.ElapsedMilliseconds).ToString() + "ms");
        }

        
     internal static void Runing()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());

           
        }
    }
}
