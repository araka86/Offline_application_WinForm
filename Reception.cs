using CartrigeAltstar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class Reception : Form
    {
        ContexAltstarContext db;

        // Кількість рядків, які вже виведені:
        // 0 <= counter <= richTextBox1.Lines.Length
        int counter = 0; // наскрізний номер рядка в масиві рядків, що виводяться
        int curPage; // поточна сторінка

        // Початок друку
        private void printDocument1_BeginPrint(object sender,
        System.Drawing.Printing.PrintEventArgs e)
        {
            // Перед початком друку змінні-лічильники
            // встановити в початкові значення
            counter = 0;
            curPage = 1;
        }






        public Reception()
        {
            InitializeComponent();
            db = new ContexAltstarContext();
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reception_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("А ты смелый!!!");
            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {


            MessageBox.Show("Авторская программа специально созданна для ТОВ \"Альтстра\" ");
        }
    }
}
