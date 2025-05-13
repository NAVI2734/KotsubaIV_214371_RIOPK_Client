using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Учёт_населения
{
    public partial class Статистика : Form
    {
        public Статистика()
        {
            InitializeComponent();
        }

        private void Статистика_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "населениеDataSet.Общие_сведения". При необходимости она может быть перемещена или удалена.
            this.общие_сведенияTableAdapter.Fill(this.населениеDataSet.Общие_сведения);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "населениеDataSet.Социальное_положение". При необходимости она может быть перемещена или удалена.
            this.социальное_положениеTableAdapter.Fill(this.населениеDataSet.Социальное_положение);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "населениеDataSet.Услуги". При необходимости она может быть перемещена или удалена.
            this.услугиTableAdapter.Fill(this.населениеDataSet.Услуги);
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    общие_сведенияDataGridView.Visible = true;
                    break;
                case 1:
                    общие_сведенияDataGridView.Visible = false;
                    услугиDataGridView.Visible = false;
                    социальное_положениеDataGridView.Visible = true;
                    break;
                case 2:
                    общие_сведенияDataGridView.Visible = false;
                    услугиDataGridView.Visible = false;
                    социальное_положениеDataGridView.Visible = true;
                    break;

                case 3:
                    общие_сведенияDataGridView.Visible = false;
                    услугиDataGridView.Visible = false;
                    социальное_положениеDataGridView.Visible = true;
                    break;
                case 4:
                    общие_сведенияDataGridView.Visible = false;
                    услугиDataGridView.Visible = false;
                    социальное_положениеDataGridView.Visible = true;
                    break;
                case 5:
                    общие_сведенияDataGridView.Visible = false;
                    социальное_положениеDataGridView.Visible = false;
                    услугиDataGridView.Visible = true;
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    int a = 0, b = 0;
                    for (int i = 0; i < общие_сведенияDataGridView.RowCount - 1; i++)
                    {
                        if (общие_сведенияDataGridView.Rows[i].Cells[3].Value.ToString().Trim() == "Мужской") a++;
                        if (общие_сведенияDataGridView.Rows[i].Cells[3].Value.ToString().Trim() == "Женский") b++;

                    }

                    chart1.Series.Clear();
                    Series s = chart1.Series.Add("Pie");
                    s.ChartType = SeriesChartType.Pie;
                    s.IsValueShownAsLabel = true;
                    s.Points.AddXY(0, a);
                    s.Points.AddXY(1, b);
                    s.Points[0].LegendText = "Мужской";
                    s.Points[1].LegendText = "Женский";
                    break;
                case 1:
                    int c = 0, d = 0, f = 0, g = 0, h = 0, j = 0;
                    for (int i = 0; i < социальное_положениеDataGridView.RowCount - 1; i++)
                    {
                        if (социальное_положениеDataGridView.Rows[i].Cells[2].Value.ToString().Trim() == "Ветераны ВОВ") c++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[2].Value.ToString().Trim() == "Ветераны труда") d++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[2].Value.ToString().Trim() == "Инвалиды детства") f++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[2].Value.ToString().Trim() == "Нетрудоспособные") g++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[2].Value.ToString().Trim() == "Почётные доноры") h++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[2].Value.ToString().Trim() == "Пострадавшие от катастрофы на ЧАЭС") j++;

                    }

                    chart1.Series.Clear();
                    Series s1 = chart1.Series.Add("Pie");
                    s1.ChartType = SeriesChartType.Pie;
                    s1.IsValueShownAsLabel = true;
                    s1.Points.AddXY(0, c);
                    s1.Points.AddXY(1, d);
                    s1.Points.AddXY(2, f);
                    s1.Points.AddXY(3, g);
                    s1.Points.AddXY(4, h);
                    s1.Points.AddXY(5, j);
                    s1.Points[0].LegendText = "Ветераны ВОВ";
                    s1.Points[1].LegendText = "Ветераны труда";
                    s1.Points[2].LegendText = "Инвалиды детства";
                    s1.Points[3].LegendText = "Нетрудоспособные";
                    s1.Points[4].LegendText = "Почётные доноры";
                    s1.Points[5].LegendText = "Пострадавшие от катастрофы на ЧАЭС";
                    break;

                case 2:
                    int k = 0, l = 0;
                    for (int i = 0; i < социальное_положениеDataGridView.RowCount - 1; i++)
                    {
                        if (социальное_положениеDataGridView.Rows[i].Cells[3].Value.ToString().Trim() == "да") k++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[3].Value.ToString().Trim() == "нет") l++;

                    }
                    chart1.Series.Clear();
                    Series s2 = chart1.Series.Add("Pie");
                    s2.ChartType = SeriesChartType.Pie;
                    s2.IsValueShownAsLabel = true;
                    s2.Points.AddXY(0, k);
                    s2.Points.AddXY(1, l);
                    s2.Points[0].LegendText = "Да";
                    s2.Points[1].LegendText = "Нет";
                    break;
                case 3:
                    int m = 0, n = 0, o = 0;
                    for (int i = 0; i < социальное_положениеDataGridView.RowCount - 1; i++)
                    {
                        if (социальное_положениеDataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "1 группа") m++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "2 группа") n++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "3 группа") o++;
                    }

                    chart1.Series.Clear();
                    Series s3 = chart1.Series.Add("Pie");
                    s3.ChartType = SeriesChartType.Pie;
                    s3.IsValueShownAsLabel = true;
                    s3.Points.AddXY(0, m);
                    s3.Points.AddXY(1, n);
                    s3.Points.AddXY(2, o);
                    s3.Points[0].LegendText = "1 группа";
                    s3.Points[1].LegendText = "2 группа";
                    s3.Points[2].LegendText = "3 группа";
                    break;
                case 4:
                    int p = 0, q = 0, r = 0, t = 0;
                    for (int i = 0; i < социальное_положениеDataGridView.RowCount - 1; i++)
                    {
                        if (социальное_положениеDataGridView.Rows[i].Cells[5].Value.ToString().Trim() == "Женат") p++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[5].Value.ToString().Trim() == "Не женат") q++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[5].Value.ToString().Trim() == "Замужем") r++;
                        if (социальное_положениеDataGridView.Rows[i].Cells[5].Value.ToString().Trim() == "Не замужем") t++;
                    }

                    chart1.Series.Clear();
                    Series s4 = chart1.Series.Add("Pie");
                    s4.ChartType = SeriesChartType.Pie;
                    s4.IsValueShownAsLabel = true;
                    s4.Points.AddXY(0, p);
                    s4.Points.AddXY(1, q);
                    s4.Points.AddXY(2, r);
                    s4.Points.AddXY(3, t);
                    s4.Points[0].LegendText = "Женат";
                    s4.Points[1].LegendText = "Не женат";
                    s4.Points[2].LegendText = "Замужем";
                    s4.Points[3].LegendText = "Не замужем";
                    break;
                case 5:
                    int u = 0, v = 0, w = 0, x = 0, y = 0;
                    for (int i = 0; i < услугиDataGridView.RowCount - 1; i++)
                    {
                        if (услугиDataGridView.Rows[i].Cells[3].Value.ToString().Trim() == "Социальное такси") u++;
                        if (услугиDataGridView.Rows[i].Cells[3].Value.ToString().Trim() == "Доставка продуктов") v++;
                        if (услугиDataGridView.Rows[i].Cells[3].Value.ToString().Trim() == "Стрижка") w++;
                        if (услугиDataGridView.Rows[i].Cells[3].Value.ToString().Trim() == "Уборка жилого поммещения") x++;
                        if (услугиDataGridView.Rows[i].Cells[3].Value.ToString().Trim() == "Выгул домашних животных") y++;
                        
                    }

                    chart1.Series.Clear();
                    Series s5 = chart1.Series.Add("Pie");
                    s5.ChartType = SeriesChartType.Pie;
                    s5.IsValueShownAsLabel = true;
                    s5.Points.AddXY(0, u);
                    s5.Points.AddXY(1, v);
                    s5.Points.AddXY(2, w);
                    s5.Points.AddXY(3, x);
                    s5.Points.AddXY(4, y);
                    s5.Points[0].LegendText = "Социальное такси";
                    s5.Points[1].LegendText = "Доставка продуктов";
                    s5.Points[2].LegendText = "Стрижка";
                    s5.Points[3].LegendText = "Уборка жилого поммещения";
                    s5.Points[4].LegendText = "Выгул домашних животных";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Close();
            frm.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = "Справка.chm";
                SysInfo.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?",
                                             "Выход из программы",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            { Application.Exit(); }
            else
            { return; }
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?",
                                             "Выход из программы",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            { Application.Exit(); }
            else
            { return; }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?",
                                             "Выход из программы",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            { Application.Exit(); }
            else
            { return; }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            О_программе frm = new О_программе();
            frm.Show();
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Статистика_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Статистика_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            try
            {
                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = "Справка.chm";
                SysInfo.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}




        

