using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace coffee
{
    public partial class addDrink : Form
    {
        public addDrink()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
                connect.Open();
                OleDbCommand command1 = new OleDbCommand("INSERT INTO Напитки (Название, Объем, Тип, Описание, Цена, Картинка) VALUES('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "','" + comboBox1.Items[comboBox1.SelectedIndex] + "','" + textBox4.Text + "','" + openFileDialog1.FileName + "'); ", connect);
                OleDbDataReader read = command1.ExecuteReader();
                connect.Close();
                this.Close();
            }
            catch (Exception Ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = new DialogResult();
                dr = openFileDialog1.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    panel1.BackgroundImageLayout = ImageLayout.Stretch;
                    panel1.BackgroundImage = System.Drawing.Bitmap.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception Ex) { }
        }
    }
}
