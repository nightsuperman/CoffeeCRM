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
    public partial class Form1 : Form
    {
        public DataTable datatable;
        public Form1()
        {



            InitializeComponent();
            try
            {
                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
                connect.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Пица;", connect);
                OleDbDataReader read = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                int lineHeight = 0;
                int lineWidth = 0;
                Panel panel;
                int counter_i = 0;
                int counter_j = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    panel = new Panel();
                    panel.Width = 200;
                    panel.Height = 335;
                    panel.BackColor = Color.SlateGray;
                    panel.ForeColor = Color.Red;
                    if (counter_i * panel.Width > tabControl1.Width - 100)
                    {
                        counter_i = 0;
                        counter_j++;
                        lineWidth = 0;
                        lineHeight = counter_j * (panel.Height + 20);


                    }
                    lineWidth = counter_i * (panel.Width + 10);
                    panel.Location = new Point(lineWidth, lineHeight);
                    counter_i++;



                    Image image = Image.FromFile(dt.Rows[i][5].ToString());

                    PictureBox pictureBox1 = new PictureBox();
                    pictureBox1.Image = image;
                    pictureBox1.Width = 190;
                    pictureBox1.Height = 190;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Location = new Point(5, 5);

                    Label name = new Label();
                    name.Text = dt.Rows[i][1].ToString();
                    name.ForeColor = Color.Black;
                    name.Font = new Font(FontFamily.GenericSansSerif, 12);
                    name.Location = new Point(0, 200);
                    name.AutoSize = true;

                    Label weight = new Label();
                    weight.Text = dt.Rows[i][2].ToString();
                    weight.ForeColor = Color.Black;
                    weight.Font = new Font(FontFamily.GenericSansSerif, 12);
                    weight.Location = new Point(0, 220);

                    TextBox description = new TextBox();
                    description.Text = dt.Rows[i][3].ToString();
                    description.ReadOnly = true;
                    description.Enabled = false;
                    description.Location = new Point(5, 245);
                    description.Multiline = true;
                    description.Width = 190;
                    description.Height = 50;

                    Label price = new Label();
                    price.Text = "Цена: " + dt.Rows[i][4].ToString();
                    price.ForeColor = Color.Black;
                    price.Font = new Font(FontFamily.GenericSansSerif, 12);
                    price.Location = new Point(0, 300);

                    Button chart = new Button();
                    chart.Text = "В корзину";
                    chart.Width = 70;
                    chart.Height = 30;

                    chart.FlatStyle = FlatStyle.Flat;
                    chart.BackColor = Color.Gray;
                    chart.ForeColor = Color.Black;
                    chart.Location = new Point(120, 300);
                    chart.Tag = i;
                    chart.Click += new System.EventHandler(this.chart_Click);

                    panel.Controls.Add(pictureBox1);
                    panel.Controls.Add(name);
                    panel.Controls.Add(weight);
                    panel.Controls.Add(description);
                    panel.Controls.Add(price);
                    panel.Controls.Add(chart);
                    tabPage1.Controls.Add(panel);
                }


                command = new OleDbCommand("SELECT * FROM Напитки;", connect);
                read = command.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(read);
                lineHeight = 0;
                lineWidth = 0;
                Panel panel2;
                counter_i = 0;
                counter_j = 0;
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    panel2 = new Panel();
                    panel2.Width = 200;
                    panel2.Height = 335;
                    panel2.BackColor = Color.SlateGray;
                    panel2.ForeColor = Color.Red;
                    if (counter_i * panel2.Width > tabControl1.Width - 100)
                    {
                        counter_i = 0;
                        counter_j++;
                        lineWidth = 0;
                        lineHeight = counter_j * (panel2.Height + 20);


                    }
                    lineWidth = counter_i * (panel2.Width + 10);
                    panel2.Location = new Point(lineWidth, lineHeight);
                    counter_i++;



                    Image image = Image.FromFile(dt2.Rows[i][6].ToString());

                    PictureBox pictureBox1 = new PictureBox();
                    pictureBox1.Image = image;
                    pictureBox1.Width = 190;
                    pictureBox1.Height = 190;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Location = new Point(5, 5);

                    Label name = new Label();
                    name.Text = dt2.Rows[i][1].ToString();
                    name.ForeColor = Color.Black;
                    name.Font = new Font(FontFamily.GenericSansSerif, 12);
                    name.Location = new Point(0, 200);
                    name.AutoSize = true;

                    Label vol = new Label();
                    vol.Text = dt2.Rows[i][2].ToString();
                    vol.ForeColor = Color.Black;
                    vol.Font = new Font(FontFamily.GenericSansSerif, 12);
                    vol.Location = new Point(0, 220);

                    TextBox description = new TextBox();
                    description.Text = dt2.Rows[i][4].ToString();
                    description.ReadOnly = true;
                    description.Enabled = false;
                    description.Location = new Point(5, 245);
                    description.Multiline = true;
                    description.Width = 190;
                    description.Height = 50;

                    Label price = new Label();
                    price.Text = "Цена: " + dt2.Rows[i][5].ToString();
                    price.ForeColor = Color.Black;
                    price.Font = new Font(FontFamily.GenericSansSerif, 12);
                    price.Location = new Point(0, 300);

                    Button chart = new Button();
                    chart.Text = "В корзину";
                    chart.Width = 70;
                    chart.Height = 30;

                    chart.FlatStyle = FlatStyle.Flat;
                    chart.BackColor = Color.Gray;
                    chart.ForeColor = Color.Black;
                    chart.Location = new Point(120, 300);
                    chart.Tag = i;
                    chart.Click += new System.EventHandler(this.chart_Click2);

                    panel2.Controls.Add(pictureBox1);
                    panel2.Controls.Add(name);
                    panel2.Controls.Add(vol);
                    panel2.Controls.Add(description);
                    panel2.Controls.Add(price);
                    panel2.Controls.Add(chart);
                    tabPage2.Controls.Add(panel2);
                }



                command = new OleDbCommand("SELECT * FROM Другие;", connect);
                read = command.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(read);
                lineHeight = 0;
                lineWidth = 0;
                Panel panel3;
                counter_i = 0;
                counter_j = 0;
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    panel3 = new Panel();
                    panel3.Width = 200;
                    panel3.Height = 335;
                    panel3.BackColor = Color.SlateGray;
                    panel3.ForeColor = Color.Red;
                    if (counter_i * panel3.Width > tabControl1.Width - 100)
                    {
                        counter_i = 0;
                        counter_j++;
                        lineWidth = 0;
                        lineHeight = counter_j * (panel3.Height + 20);


                    }
                    lineWidth = counter_i * (panel3.Width + 10);
                    panel3.Location = new Point(lineWidth, lineHeight);
                    counter_i++;



                    Image image = Image.FromFile(dt3.Rows[i][6].ToString());

                    PictureBox pictureBox1 = new PictureBox();
                    pictureBox1.Image = image;
                    pictureBox1.Width = 190;
                    pictureBox1.Height = 190;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Location = new Point(5, 5);

                    Label name = new Label();
                    name.Text = dt3.Rows[i][1].ToString();
                    name.ForeColor = Color.Black;
                    name.Font = new Font(FontFamily.GenericSansSerif, 12);
                    name.Location = new Point(0, 200);
                    name.AutoSize = true;

                    Label vol = new Label();
                    vol.Text = dt3.Rows[i][4].ToString();
                    vol.ForeColor = Color.Black;
                    vol.Font = new Font(FontFamily.GenericSansSerif, 12);
                    vol.Location = new Point(0, 220);

                    TextBox description = new TextBox();
                    description.Text = dt3.Rows[i][3].ToString();
                    description.ReadOnly = true;
                    description.Enabled = false;
                    description.Location = new Point(5, 245);
                    description.Multiline = true;
                    description.Width = 190;
                    description.Height = 50;

                    Label price = new Label();
                    price.Text = "Цена: " + dt3.Rows[i][5].ToString();
                    price.ForeColor = Color.Black;
                    price.Font = new Font(FontFamily.GenericSansSerif, 12);
                    price.Location = new Point(0, 300);

                    Button chart = new Button();
                    chart.Text = "В корзину";
                    chart.Width = 70;
                    chart.Height = 30;

                    chart.FlatStyle = FlatStyle.Flat;
                    chart.BackColor = Color.Gray;
                    chart.ForeColor = Color.Black;
                    chart.Location = new Point(120, 300);
                    chart.Tag = i;
                    chart.Click += new System.EventHandler(this.chart_Click3);

                    panel3.Controls.Add(pictureBox1);
                    panel3.Controls.Add(name);
                    panel3.Controls.Add(vol);
                    panel3.Controls.Add(description);
                    panel3.Controls.Add(price);
                    panel3.Controls.Add(chart);
                    tabPage3.Controls.Add(panel3);
                }



                command = new OleDbCommand("SELECT * FROM Корзина", connect);
                read = command.ExecuteReader();
                DataTable chart_table = new DataTable();
                chart_table.Load(read);
                dataGridView1.DataSource = chart_table;



                // Загрузка таблицы во вкладку редактирование

                OleDbCommand command1 = new OleDbCommand("SELECT * FROM Пица", connect);
                OleDbDataReader read1 = command1.ExecuteReader();
                datatable = new DataTable();
                datatable.TableName = "Пица";
                datatable.Load(read1);
                dataGridView2.DataSource = datatable;
                connect.Close();
            }
            catch (Exception Ex) {
                MessageBox.Show(Ex.ToString());
            }
        }
        void chart_Click(Object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
            connect.Open();

            OleDbCommand command1 = new OleDbCommand("SELECT * FROM Пица;", connect);
            OleDbDataReader read = command1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);

            OleDbCommand command2 = new OleDbCommand("SELECT * FROM Корзина;", connect);
            OleDbDataReader read2 = command2.ExecuteReader();
            DataTable chart = new DataTable();
            chart.Load(read2);

            bool add = true;
            for (int i = 0; i < chart.Rows.Count; i++)
            {
                add = true;
                if (chart.Rows[i][1].ToString() == dt.Rows[Convert.ToInt32(((Control)sender).Tag)][1].ToString())
                {
                    command1 = new OleDbCommand("UPDATE Корзина SET Количество = " + (Convert.ToInt32(chart.Rows[i][3]) + 1) + ", Цена = " + (Convert.ToInt32(dt.Rows[Convert.ToInt32(((Control)sender).Tag)][4]) + Convert.ToInt32(chart.Rows[i][2])) + " WHERE Продукт = '" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][1] + "';", connect);
                    command1.ExecuteNonQuery();
                    add = false;
                    break;
                }

            }
            if (add == true)
            {
                command1 = new OleDbCommand("INSERT INTO Корзина (Продукт, Цена, Количество, [Цена за единицу]) VALUES('" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][1].ToString() + "', '" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][4].ToString() + "', '" + 1 + "', '" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][4].ToString() + "'); ", connect);
                command1.ExecuteNonQuery();
            }

            connect.Close();
            

        }

        void chart_Click2(Object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
            connect.Open();

            OleDbCommand command1 = new OleDbCommand("SELECT * FROM Напитки;", connect);
            OleDbDataReader read = command1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);

            OleDbCommand command2 = new OleDbCommand("SELECT * FROM Корзина;", connect);
            OleDbDataReader read2 = command2.ExecuteReader();
            DataTable chart = new DataTable();
            chart.Load(read2);

            bool add = true;
            for (int i = 0; i < chart.Rows.Count; i++)
            {
                add = true;
                if (chart.Rows[i][1].ToString() == dt.Rows[Convert.ToInt32(((Control)sender).Tag)][1].ToString())
                {
                    command1 = new OleDbCommand("UPDATE Корзина SET Количество = " + (Convert.ToInt32(chart.Rows[i][3]) + 1) + ", Цена = " + (Convert.ToInt32(dt.Rows[Convert.ToInt32(((Control)sender).Tag)][5]) + Convert.ToInt32(chart.Rows[i][2])) + " WHERE Продукт = '" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][1] + "';", connect);
                    command1.ExecuteNonQuery();
                    add = false;
                    break;
                }
            }
            if (add == true)
            {
                command1 = new OleDbCommand("INSERT INTO Корзина (Продукт, Цена, Количество, [Цена за единицу]) VALUES('" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][1].ToString() + "', '" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][5].ToString() + "', '" + 1 + "', '"+ dt.Rows[Convert.ToInt32(((Control)sender).Tag)][5].ToString() + "'); ", connect);
                command1.ExecuteNonQuery();
            }
            connect.Close();
        }
        void chart_Click3(Object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
            connect.Open();

            OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Другие];", connect);
            OleDbDataReader read = command1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);

            OleDbCommand command2 = new OleDbCommand("SELECT * FROM Корзина;", connect);
            OleDbDataReader read2 = command2.ExecuteReader();
            DataTable chart = new DataTable();
            chart.Load(read2);

            bool add = true;
            for (int i = 0; i < chart.Rows.Count; i++)
            {
                add = true;
                if (chart.Rows[i][1].ToString() == dt.Rows[Convert.ToInt32(((Control)sender).Tag)][1].ToString())
                {
                    command1 = new OleDbCommand("UPDATE Корзина SET Количество = " + (Convert.ToInt32(chart.Rows[i][3]) + 1) + ", Цена = " + (Convert.ToInt32(dt.Rows[Convert.ToInt32(((Control)sender).Tag)][5]) + Convert.ToInt32(chart.Rows[i][2])) + " WHERE Продукт = '" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][1] + "';", connect);
                    command1.ExecuteNonQuery();
                    add = false;
                    break;
                }
            }
            if (add == true)
            {
                command1 = new OleDbCommand("INSERT INTO Корзина (Продукт, Цена, Количество, [Цена за единицу]) VALUES('" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][1].ToString() + "', '" + dt.Rows[Convert.ToInt32(((Control)sender).Tag)][5].ToString() + "', '" + 1 + "', '"+ dt.Rows[Convert.ToInt32(((Control)sender).Tag)][5].ToString() + "'); ", connect);
                command1.ExecuteNonQuery();
            }
            connect.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
            connect.Open();
            if (tabControl1.SelectedIndex == 0)
            {
                tabPage1.Controls.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Пица WHERE Название LIKE '%" + textBox1.Text + "%';", connect);
                OleDbDataReader read = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                int lineHeight = 0;
                int lineWidth = 0;
                Panel panel;
                int counter_i = 0;
                int counter_j = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    panel = new Panel();
                    panel.Width = 200;
                    panel.Height = 350;
                    panel.BackColor = Color.SlateGray;
                    panel.ForeColor = Color.Red;
                    if (counter_i * panel.Width > tabControl1.Width - 100)
                    {
                        counter_i = 0;
                        counter_j++;
                        lineWidth = 0;
                        lineHeight = counter_j * (panel.Height + 20);


                    }
                    lineWidth = counter_i * (panel.Width + 10);
                    panel.Location = new Point(lineWidth, lineHeight);
                    counter_i++;



                    Image image = Image.FromFile(dt.Rows[i][5].ToString());

                    PictureBox pictureBox1 = new PictureBox();
                    pictureBox1.Image = image;
                    pictureBox1.Width = 190;
                    pictureBox1.Height = 190;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Location = new Point(5, 5);

                    Label name = new Label();
                    name.Text = dt.Rows[i][1].ToString();
                    name.ForeColor = Color.Black;
                    name.Font = new Font(FontFamily.GenericSansSerif, 12);
                    name.Location = new Point(0, 200);
                    name.AutoSize = true;

                    Label weight = new Label();
                    weight.Text = dt.Rows[i][2].ToString();
                    weight.ForeColor = Color.Black;
                    weight.Font = new Font(FontFamily.GenericSansSerif, 12);
                    weight.Location = new Point(0, 220);

                    TextBox description = new TextBox();
                    description.Text = dt.Rows[i][3].ToString();
                    description.ReadOnly = true;
                    description.Enabled = false;
                    description.Location = new Point(5, 245);
                    description.Multiline = true;
                    description.Width = 190;
                    description.Height = 50;

                    Label price = new Label();
                    price.Text = "Цена: " + dt.Rows[i][4].ToString();
                    price.ForeColor = Color.Black;
                    price.Font = new Font(FontFamily.GenericSansSerif, 12);
                    price.Location = new Point(0, 300);

                    Button chart = new Button();
                    chart.Text = "В корзину";
                    chart.Width = 70;
                    chart.Height = 30;

                    chart.FlatStyle = FlatStyle.Flat;
                    chart.BackColor = Color.Green;
                    chart.ForeColor = Color.Black;
                    chart.Location = new Point(120, 300);
                    chart.Tag = i;
                    chart.Click += new System.EventHandler(this.chart_Click);

                    panel.Controls.Add(pictureBox1);
                    panel.Controls.Add(name);
                    panel.Controls.Add(weight);
                    panel.Controls.Add(description);
                    panel.Controls.Add(price);
                    panel.Controls.Add(chart);
                    tabPage1.Controls.Add(panel);
                }
                connect.Close();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                tabPage2.Controls.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Напитки WHERE Название LIKE '%" + textBox1.Text + "%';", connect);
                OleDbDataReader read = command.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(read);
                int lineHeight = 0;
                int lineWidth = 0;
                Panel panel2;
                int counter_i = 0;
                int counter_j = 0;
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    panel2 = new Panel();
                    panel2.Width = 200;
                    panel2.Height = 350;
                    panel2.BackColor = Color.SlateGray;
                    panel2.ForeColor = Color.Red;
                    if (counter_i * panel2.Width > tabControl1.Width - 100)
                    {
                        counter_i = 0;
                        counter_j++;
                        lineWidth = 0;
                        lineHeight = counter_j * (panel2.Height + 20);


                    }
                    lineWidth = counter_i * (panel2.Width + 10);
                    panel2.Location = new Point(lineWidth, lineHeight);
                    counter_i++;



                    Image image = Image.FromFile(dt2.Rows[i][6].ToString());

                    PictureBox pictureBox1 = new PictureBox();
                    pictureBox1.Image = image;
                    pictureBox1.Width = 190;
                    pictureBox1.Height = 190;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Location = new Point(5, 5);

                    Label name = new Label();
                    name.Text = dt2.Rows[i][1].ToString();
                    name.ForeColor = Color.Black;
                    name.Font = new Font(FontFamily.GenericSansSerif, 12);
                    name.Location = new Point(0, 200);
                    name.AutoSize = true;

                    Label vol = new Label();
                    vol.Text = dt2.Rows[i][2].ToString();
                    vol.ForeColor = Color.Black;
                    vol.Font = new Font(FontFamily.GenericSansSerif, 12);
                    vol.Location = new Point(0, 220);

                    TextBox description = new TextBox();
                    description.Text = dt2.Rows[i][4].ToString();
                    description.ReadOnly = true;
                    description.Enabled = false;
                    description.Location = new Point(5, 245);
                    description.Multiline = true;
                    description.Width = 190;
                    description.Height = 50;

                    Label price = new Label();
                    price.Text = "Цена: " + dt2.Rows[i][5].ToString();
                    price.ForeColor = Color.Black;
                    price.Font = new Font(FontFamily.GenericSansSerif, 12);
                    price.Location = new Point(0, 300);

                    Button chart = new Button();
                    chart.Text = "В корзину";
                    chart.Width = 70;
                    chart.Height = 30;

                    chart.FlatStyle = FlatStyle.Flat;
                    chart.BackColor = Color.Green;
                    chart.ForeColor = Color.Black;
                    chart.Location = new Point(120, 300);
                    chart.Tag = i;
                    chart.Click += new System.EventHandler(this.chart_Click2);

                    panel2.Controls.Add(pictureBox1);
                    panel2.Controls.Add(name);
                    panel2.Controls.Add(vol);
                    panel2.Controls.Add(description);
                    panel2.Controls.Add(price);
                    panel2.Controls.Add(chart);
                    tabPage2.Controls.Add(panel2);
                }
            }
            if (tabControl1.SelectedIndex == 2)
            {
                tabPage3.Controls.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Другие] WHERE Название LIKE '%" + textBox1.Text + "%';", connect);
                OleDbDataReader read = command.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(read);
                int lineHeight = 0;
                int lineWidth = 0;
                Panel panel3;
                int counter_i = 0;
                int counter_j = 0;
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    panel3 = new Panel();
                    panel3.Width = 200;
                    panel3.Height = 350;
                    panel3.BackColor = Color.SlateGray;
                    panel3.ForeColor = Color.Red;
                    if (counter_i * panel3.Width > tabControl1.Width - 100)
                    {
                        counter_i = 0;
                        counter_j++;
                        lineWidth = 0;
                        lineHeight = counter_j * (panel3.Height + 20);


                    }
                    lineWidth = counter_i * (panel3.Width + 10);
                    panel3.Location = new Point(lineWidth, lineHeight);
                    counter_i++;



                    Image image = Image.FromFile(dt3.Rows[i][6].ToString());

                    PictureBox pictureBox1 = new PictureBox();
                    pictureBox1.Image = image;
                    pictureBox1.Width = 190;
                    pictureBox1.Height = 190;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Location = new Point(5, 5);

                    Label name = new Label();
                    name.Text = dt3.Rows[i][1].ToString();
                    name.ForeColor = Color.Black;
                    name.Font = new Font(FontFamily.GenericSansSerif, 12);
                    name.Location = new Point(0, 200);
                    name.AutoSize = true;

                    Label type = new Label();
                    type.Text = dt3.Rows[i][2].ToString();
                    type.ForeColor = Color.Black;
                    type.Font = new Font(FontFamily.GenericSansSerif, 12);
                    type.Location = new Point(0, 220);

                    TextBox description = new TextBox();
                    description.Text = dt3.Rows[i][4].ToString();
                    description.ReadOnly = true;
                    description.Enabled = false;
                    description.Location = new Point(5, 245);
                    description.Multiline = true;
                    description.Width = 190;
                    description.Height = 50;

                    Label price = new Label();
                    price.Text = "Цена: " + dt3.Rows[i][5].ToString();
                    price.ForeColor = Color.Black;
                    price.Font = new Font(FontFamily.GenericSansSerif, 12);
                    price.Location = new Point(0, 300);

                    Button chart = new Button();
                    chart.Text = "В корзину";
                    chart.Width = 70;
                    chart.Height = 30;

                    chart.FlatStyle = FlatStyle.Flat;
                    chart.BackColor = Color.Green;
                    chart.ForeColor = Color.Black;
                    chart.Location = new Point(120, 300);
                    chart.Tag = i;
                    chart.Click += new System.EventHandler(this.chart_Click3);

                    panel3.Controls.Add(pictureBox1);
                    panel3.Controls.Add(name);
                    panel3.Controls.Add(type);
                    panel3.Controls.Add(description);
                    panel3.Controls.Add(price);
                    panel3.Controls.Add(chart);
                    tabPage3.Controls.Add(panel3);
                }
            }
            connect.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                addPizza ap = new addPizza();
                ap.ShowDialog();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                addDrink ad = new addDrink();
                ad.ShowDialog();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                addOther aO = new addOther();
                aO.ShowDialog();
            }
            refresh();
        }

        public static int summary = 0;

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int indexRow = dataGridView1.CurrentRow.Index;
                int price = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                int fullPrice = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
                int count = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                object key = dataGridView1.CurrentRow.Cells[0].Value;



                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
                connect.Open();
                OleDbCommand command;

                OleDbCommand command2 = new OleDbCommand("SELECT * FROM Корзина", connect);
                OleDbDataReader read = command2.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                dataGridView1.DataSource = dt;


                summary = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    summary += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                }
                label1.Text = "К оплате: " + summary;


                if (count > 1)
                {
                    
                    command = new OleDbCommand("UPDATE Корзина SET Количество = " + (count - 1) + " WHERE Код = " + key + ";", connect);
                    command.ExecuteNonQuery();

                    command = new OleDbCommand("UPDATE Корзина SET Цена = " + (fullPrice - price) + " WHERE Код = " + key + ";", connect);
                    command.ExecuteNonQuery();

                    summary -= price;

                }
                else
                {
                    command = new OleDbCommand("DELETE FROM Корзина WHERE Код = " + key + ";", connect);
                    command.ExecuteNonQuery();
                    
                }

                command2 = new OleDbCommand("SELECT * FROM Корзина", connect);
                read = command2.ExecuteReader();
                dt = new DataTable();
                dt.Load(read);
                dataGridView1.DataSource = dt;
                summary = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    summary += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                }
                label1.Text = "К оплате: " + summary;


                dataGridView1.CurrentCell = dataGridView1.Rows[indexRow].Cells[0];
                connect.Close();
            }
            catch (Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
            connect.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Корзина", connect);
            OleDbDataReader read = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            dataGridView1.DataSource = dt;
            summary = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                summary += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            label1.Text = "К оплате: " + summary;
            connect.Close();
        }
        private void refresh() {
            tabPage1.Controls.Clear();
            tabPage2.Controls.Clear();
            tabPage3.Controls.Clear();

            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
            connect.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Пица;", connect);
            OleDbDataReader read = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            int lineHeight = 0;
            int lineWidth = 0;
            Panel panel;
            int counter_i = 0;
            int counter_j = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                panel = new Panel();
                panel.Width = 200;
                panel.Height = 350;
                panel.BackColor = Color.SlateGray;
                panel.ForeColor = Color.Red;
                if (counter_i * panel.Width > tabControl1.Width - 100)
                {
                    counter_i = 0;
                    counter_j++;
                    lineWidth = 0;
                    lineHeight = counter_j * (panel.Height + 20);


                }
                lineWidth = counter_i * (panel.Width + 10);
                panel.Location = new Point(lineWidth, lineHeight);
                counter_i++;



                Image image = Image.FromFile(dt.Rows[i][5].ToString());

                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Image = image;
                pictureBox1.Width = 190;
                pictureBox1.Height = 190;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Location = new Point(5, 5);

                Label name = new Label();
                name.Text = dt.Rows[i][1].ToString();
                name.ForeColor = Color.Black;
                name.Font = new Font(FontFamily.GenericSansSerif, 12);
                name.Location = new Point(0, 200);
                name.AutoSize = true;

                Label weight = new Label();
                weight.Text = dt.Rows[i][2].ToString();
                weight.ForeColor = Color.Black;
                weight.Font = new Font(FontFamily.GenericSansSerif, 12);
                weight.Location = new Point(0, 220);

                TextBox description = new TextBox();
                description.Text = dt.Rows[i][3].ToString();
                description.ReadOnly = true;
                description.Enabled = false;
                description.Location = new Point(5, 245);
                description.Multiline = true;
                description.Width = 190;
                description.Height = 50;

                Label price = new Label();
                price.Text = "Цена: " + dt.Rows[i][4].ToString();
                price.ForeColor = Color.Black;
                price.Font = new Font(FontFamily.GenericSansSerif, 12);
                price.Location = new Point(0, 300);

                Button chart = new Button();
                chart.Text = "В корзину";
                chart.Width = 70;
                chart.Height = 30;

                chart.FlatStyle = FlatStyle.Flat;
                chart.BackColor = Color.Green;
                chart.ForeColor = Color.Black;
                chart.Location = new Point(120, 300);
                chart.Tag = i;
                chart.Click += new System.EventHandler(this.chart_Click);

                panel.Controls.Add(pictureBox1);
                panel.Controls.Add(name);
                panel.Controls.Add(weight);
                panel.Controls.Add(description);
                panel.Controls.Add(price);
                panel.Controls.Add(chart);
                tabPage1.Controls.Add(panel);
            }


            command = new OleDbCommand("SELECT * FROM Напитки;", connect);
            read = command.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(read);
            lineHeight = 0;
            lineWidth = 0;
            Panel panel2;
            counter_i = 0;
            counter_j = 0;
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                panel2 = new Panel();
                panel2.Width = 200;
                panel2.Height = 350;
                panel2.BackColor = Color.SlateGray;
                panel2.ForeColor = Color.Red;
                if (counter_i * panel2.Width > tabControl1.Width - 100)
                {
                    counter_i = 0;
                    counter_j++;
                    lineWidth = 0;
                    lineHeight = counter_j * (panel2.Height + 20);


                }
                lineWidth = counter_i * (panel2.Width + 10);
                panel2.Location = new Point(lineWidth, lineHeight);
                counter_i++;



                Image image = Image.FromFile(dt2.Rows[i][6].ToString());

                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Image = image;
                pictureBox1.Width = 190;
                pictureBox1.Height = 190;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Location = new Point(5, 5);

                Label name = new Label();
                name.Text = dt2.Rows[i][1].ToString();
                name.ForeColor = Color.Black;
                name.Font = new Font(FontFamily.GenericSansSerif, 12);
                name.Location = new Point(0, 200);
                name.AutoSize = true;

                Label vol = new Label();
                vol.Text = dt2.Rows[i][2].ToString();
                vol.ForeColor = Color.Black;
                vol.Font = new Font(FontFamily.GenericSansSerif, 12);
                vol.Location = new Point(0, 220);

                TextBox description = new TextBox();
                description.Text = dt2.Rows[i][4].ToString();
                description.ReadOnly = true;
                description.Enabled = false;
                description.Location = new Point(5, 245);
                description.Multiline = true;
                description.Width = 190;
                description.Height = 50;

                Label price = new Label();
                price.Text = "Цена: " + dt2.Rows[i][5].ToString();
                price.ForeColor = Color.Black;
                price.Font = new Font(FontFamily.GenericSansSerif, 12);
                price.Location = new Point(0, 300);

                Button chart = new Button();
                chart.Text = "В корзину";
                chart.Width = 70;
                chart.Height = 30;

                chart.FlatStyle = FlatStyle.Flat;
                chart.BackColor = Color.Green;
                chart.ForeColor = Color.Black;
                chart.Location = new Point(120, 300);
                chart.Tag = i;
                chart.Click += new System.EventHandler(this.chart_Click2);

                panel2.Controls.Add(pictureBox1);
                panel2.Controls.Add(name);
                panel2.Controls.Add(vol);
                panel2.Controls.Add(description);
                panel2.Controls.Add(price);
                panel2.Controls.Add(chart);
                tabPage2.Controls.Add(panel2);
            }



            command = new OleDbCommand("SELECT * FROM [Другие];", connect);
            read = command.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(read);
            lineHeight = 0;
            lineWidth = 0;
            Panel panel3;
            counter_i = 0;
            counter_j = 0;
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                panel3 = new Panel();
                panel3.Width = 200;
                panel3.Height = 350;
                panel3.BackColor = Color.SlateGray;
                panel3.ForeColor = Color.Red;
                if (counter_i * panel3.Width > tabControl1.Width - 100)
                {
                    counter_i = 0;
                    counter_j++;
                    lineWidth = 0;
                    lineHeight = counter_j * (panel3.Height + 20);


                }
                lineWidth = counter_i * (panel3.Width + 10);
                panel3.Location = new Point(lineWidth, lineHeight);
                counter_i++;



                Image image = Image.FromFile(dt3.Rows[i][6].ToString());

                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Image = image;
                pictureBox1.Width = 190;
                pictureBox1.Height = 190;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Location = new Point(5, 5);

                Label name = new Label();
                name.Text = dt3.Rows[i][1].ToString();
                name.ForeColor = Color.Black;
                name.Font = new Font(FontFamily.GenericSansSerif, 12);
                name.Location = new Point(0, 200);
                name.AutoSize = true;

                Label type = new Label();
                type.Text = dt3.Rows[i][2].ToString();
                type.ForeColor = Color.Black;
                type.Font = new Font(FontFamily.GenericSansSerif, 12);
                type.Location = new Point(0, 220);

                TextBox description = new TextBox();
                description.Text = dt3.Rows[i][4].ToString();
                description.ReadOnly = true;
                description.Enabled = false;
                description.Location = new Point(5, 245);
                description.Multiline = true;
                description.Width = 190;
                description.Height = 50;

                Label price = new Label();
                price.Text = "Цена: " + dt3.Rows[i][5].ToString();
                price.ForeColor = Color.Black;
                price.Font = new Font(FontFamily.GenericSansSerif, 12);
                price.Location = new Point(0, 300);

                Button chart = new Button();
                chart.Text = "В корзину";
                chart.Width = 70;
                chart.Height = 30;

                chart.FlatStyle = FlatStyle.Flat;
                chart.BackColor = Color.Green;
                chart.ForeColor = Color.Black;
                chart.Location = new Point(120, 300);
                chart.Tag = i;
                chart.Click += new System.EventHandler(this.chart_Click3);

                panel3.Controls.Add(pictureBox1);
                panel3.Controls.Add(name);
                panel3.Controls.Add(type);
                panel3.Controls.Add(description);
                panel3.Controls.Add(price);
                panel3.Controls.Add(chart);
                tabPage3.Controls.Add(panel3);
            }



            command = new OleDbCommand("SELECT * FROM Корзина", connect);
            read = command.ExecuteReader();
            DataTable chart_table = new DataTable();
            chart_table.Load(read);
            dataGridView1.DataSource = chart_table;
            connect.Close();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            refresh();
        }

        OleDbDataAdapter oledbAdapter;
        OleDbCommandBuilder oledbCmdBuilder;
        DataSet ds = new DataSet();
        DataSet changes;



        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            ds.Tables.Clear();
            datatable.TableName = "Пица";
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
            connect.Open();

            oledbAdapter = new OleDbDataAdapter("SELECT * FROM Пица", connect);
            oledbAdapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            
            connect.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            ds.Tables.Clear();
            datatable.TableName = "Напитки";
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
            connect.Open();

            oledbAdapter = new OleDbDataAdapter("SELECT * FROM Напитки", connect);
            oledbAdapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            connect.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            ds.Tables.Clear();
            datatable.TableName = "Другие";
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
            connect.Open();

            oledbAdapter = new OleDbDataAdapter("SELECT * FROM [Другие]", connect);
            oledbAdapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            connect.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
          //  try
           // {
                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database1.mdb");
                connect.Open();
                OleDbCommand delete = new OleDbCommand("DELETE FROM [" + datatable.TableName + "] WHERE Код = " + dataGridView2.CurrentRow.Cells[0].Value + ";", connect);
                delete.ExecuteNonQuery();
               
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                
                
                OleDbCommand command = new OleDbCommand("SELECT * FROM [" + datatable.TableName + "];", connect);
                OleDbDataReader read = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                dataGridView2.DataSource = dt;
                connect.Close();
                refresh();
           // }
           // catch (Exception ex) {
           // }
        }

        private void button14_Click(object sender, EventArgs e)
        {
          //  try
            //{
                oledbCmdBuilder = new OleDbCommandBuilder(oledbAdapter);
                changes = ds.GetChanges();
                if (changes != null)
                {
                    oledbAdapter.Update(ds.Tables[0]);
                }
                ds.AcceptChanges();
                refresh();
                MessageBox.Show("Изменение сохранены!!!");
           // }
           // catch (Exception ex) {
            //    MessageBox.Show(ex.ToString());
           // }
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
