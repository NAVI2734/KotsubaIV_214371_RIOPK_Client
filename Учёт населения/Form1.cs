using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel1 = Microsoft.Office.Interop.Excel;
using Application = System.Windows.Forms.Application;
using System.Diagnostics;
using Point = System.Drawing.Point;
using System.Security.Cryptography;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections;
using Server.Models.DTO;


namespace Учёт_населения
{
    public partial class Form1 : Form
    {
        string path = Application.StartupPath + @"\Население.mdf";
        string myConnectionString;
        public Form1()
        { InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // todo: данная строка кода позволяет загрузить данные в таблицу "населениеdataset.услуги". при необходимости она может быть перемещена или удалена.
            this.услугиTableAdapter.Fill(this.населениеDataSet.Услуги);
            // todo: данная строка кода позволяет загрузить данные в таблицу "населениеdataset.документ_удостоверяющий_личность". при необходимости она может быть перемещена или удалена.
            this.документ_удостоверяющий_личностьTableAdapter.Fill(this.населениеDataSet.Документ_удостоверяющий_личность);
            // todo: данная строка кода позволяет загрузить данные в таблицу "населениеdataset.документ_предоставляющий_льготу". при необходимости она может быть перемещена или удалена.
            this.документ_предоставляющий_льготуTableAdapter.Fill(this.населениеDataSet.Документ_предоставляющий_льготу);
            // todo: данная строка кода позволяет загрузить данные в таблицу "населениеdataset.социальное_положение". при необходимости она может быть перемещена или удалена.
            this.социальное_положениеTableAdapter.Fill(this.населениеDataSet.Социальное_положение);
            // todo: данная строка кода позволяет загрузить данные в таблицу "населениеdataset.общие_сведения". при необходимости она может быть перемещена или удалена.
            this.общие_сведенияTableAdapter.Fill(this.населениеDataSet.Общие_сведения);

            myConnectionString = @"data source = (LocalDB)\MSSQLLocalDB; attachdbfilename = '" + path + "'; integrated security = true";

            kod1();
            kod2();
            kod3();
            kod4();
            kod5();
            код_общих_сведенийTextBox2.Enabled = false;

        }

        int kod2kod, kod3kod, kod4kod;
        private void kod2()
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            string query = "DECLARE @number INT, @rez INT; SET @number = 1; set @rez=1; WHILE @number < 2147483647 BEGIN SET @number = @number + 1 IF @number  in (select [Код документа предоставляющего льготу] from [Документ предоставляющий льготу]) set @number=@number; else BEGIN set @rez=@number; break;END; END; select @rez;";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                kod2kod = Convert.ToInt32(reader[0]);

            }
            reader.Close();
            myConnection.Close();
        }
        private void kod3()
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            string query = "DECLARE @number INT, @rez INT; SET @number = 1; set @rez=1; WHILE @number < 2147483647 BEGIN SET @number = @number + 1 IF @number  in (select [Код документа удостоверяющего личность] from [Документ удостоверяющий личность]) set @number=@number; else BEGIN set @rez=@number; break;END; END; select @rez;";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                kod3kod = Convert.ToInt32(reader[0]);

            }
            reader.Close();
            myConnection.Close();
        }

        private void kod4()
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            string query = "DECLARE @number INT, @rez INT; SET @number = 1; set @rez=1; WHILE @number < 2147483647 BEGIN SET @number = @number + 1 IF @number  in (select [Код социального положения] from [Социальное положение]) set @number=@number; else BEGIN set @rez=@number; break;END; END; select @rez;";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                kod4kod = Convert.ToInt32(reader[0]);

            }
            reader.Close();
            myConnection.Close();
        }
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {

            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;
                object oMissing = Missing.Value;
                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Times New Roman";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //table style 
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;



                //save the file

                oDoc.SaveAs(filename, ref oMissing, ref oMissing, ref oMissing,
    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
    ref oMissing, ref oMissing);

                //NASSIM LOUCHANI
            }
        }

        bool insertZP, updateZP;

        int kod1kod;
        private void kod1()
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            string query = "DECLARE @number INT, @rez INT; SET @number = 1; set @rez=1; WHILE @number < 2147483647 BEGIN SET @number = @number + 1 IF @number  in (select [Код общих сведений] from [Общие сведения]) set @number=@number; else BEGIN set @rez=@number; break;END; END; select @rez;";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                kod1kod = Convert.ToInt32(reader[0]);

            }
            reader.Close();
            myConnection.Close();
        }
        private void Insert_button_Click(object sender, EventArgs e)
        {
            if ((insertZP != true) && (updateZP != true))
            {
                общие_сведенияBindingSource.AddNew();
                kod1();
                insertZP = true;
                updateZP = false;
                код_общих_сведенийTextBox.ReadOnly = false;
                код_общих_сведенийTextBox.Text = kod1kod.ToString();
                код_общих_сведенийTextBox.ReadOnly = true;

                документ_предоставляющий_льготуBindingSource.AddNew();
                kod2();
                insertZP = true;
                updateZP = false;
                код_документа_предоставляющего_льготуTextBox.ReadOnly = false;
                код_документа_предоставляющего_льготуTextBox.Text = kod2kod.ToString();
                код_документа_предоставляющего_льготуTextBox.ReadOnly = true;

                документ_удостоверяющий_личностьBindingSource.AddNew();
                kod3();
                insertZP = true;
                updateZP = false;
                код_документа_удостоверяющего_личностьTextBox.ReadOnly = false;
                код_документа_удостоверяющего_личностьTextBox.Text = kod3kod.ToString();
                код_документа_удостоверяющего_личностьTextBox.ReadOnly = true;


                социальное_положениеBindingSource.AddNew();
                kod4();
                insertZP = true;
                updateZP = false;
                код_социального_положенияTextBox.ReadOnly = false;
                код_социального_положенияTextBox.Text = kod4kod.ToString();
                код_социального_положенияTextBox.ReadOnly = true;

                tabControl1.Visible = false;
                panel1.Visible = true;

            }
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            if ((insertZP))
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "INSERT INTO [Общие сведения]  ([код общих сведений], ФИО, [Дата рождения], Пол, [Адрес регистрации], [Адрес проживания], Телефон) VALUES (@код_общих_сведений, @ФИО, @Дата_рождения, @Пол, @Адрес_регистрации, @Адрес_проживания, @Телефон);";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@код_общих_сведений", код_общих_сведенийTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox3.Text);
                cmd_SQL.Parameters.AddWithValue("@Дата_рождения", дата_рожденияDateTimePicker.Value);
                cmd_SQL.Parameters.AddWithValue("@Пол", полComboBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Адрес_регистрации", адрес_регистрацииTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Адрес_проживания", адрес_проживанияTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Телефон", телефонTextBox.Text);

                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка! Данные с общими сведениями не добавлены введите данные корректно! ");
                }
                finally
                {
                    connect.Close();
                    this.общие_сведенияTableAdapter.Fill(this.населениеDataSet.Общие_сведения);
                }
            }


            if ((insertZP))
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "INSERT INTO [Документ предоставляющий льготу]  ([Код документа предоставляющего льготу], ФИО, [Тип документа], Серия, Номер, [Дата выдачи]) VALUES (@Код_документа_предоставляющего_льготу, @ФИО, @Тип_документа, @Серия, @Номер, @Дата_выдачи);";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@Код_документа_предоставляющего_льготу", код_документа_предоставляющего_льготуTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox3.Text);
                cmd_SQL.Parameters.AddWithValue("@Тип_документа", тип_документаComboBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Серия", серияTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Номер", номерTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Дата_выдачи", дата_выдачиDateTimePicker.Value);


                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка! Данные о документе предоставляющем льготу не добавлены введите данные корректно! ");
                }
                finally
                {
                    connect.Close();
                    this.документ_предоставляющий_льготуTableAdapter.Fill(this.населениеDataSet.Документ_предоставляющий_льготу);
                }
            }

            if ((insertZP))
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "INSERT INTO [Документ удостоверяющий личность]  ([код документа удостоверяющего личность], ФИО, [Тип документа], Серия, Номер, [Дата выдачи], [Дата окончания срока действия], [Кем выдан]) VALUES (@код_документа_удостоверяющего_личность, @ФИО, @Тип_документа, @Серия, @Номер, @Дата_выдачи, @Дата_окончания_срока_действия, @Кем_выдан);";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@код_документа_удостоверяющего_личность", код_документа_удостоверяющего_личностьTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox3.Text);
                cmd_SQL.Parameters.AddWithValue("@Тип_документа", тип_документаComboBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Серия", серияTextBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Номер", номерTextBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Дата_выдачи", дата_выдачиDateTimePicker1.Value);
                cmd_SQL.Parameters.AddWithValue("@Дата_окончания_срока_действия", дата_окончания_срока_действияDateTimePicker1.Value);
                cmd_SQL.Parameters.AddWithValue("@Кем_выдан", кем_выданComboBox.Text);
                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка! Данные о документе удостоверяющем личность не добавлены введите данные корректно! ");
                }
                finally
                {
                    connect.Close();
                    this.документ_удостоверяющий_личностьTableAdapter.Fill(this.населениеDataSet.Документ_удостоверяющий_личность);
                }
            }


            if ((insertZP))
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "INSERT INTO [Социальное положение]  ([код социального положения], ФИО, [Социальная категория], Инвалидность, [Группа инвалидности], [Семейное положение]) VALUES (@код_социальнго_положения, @ФИО, @Социальная_категория, @Инвалидность, @Группа_инвалидности, @Семейное_положение);";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@код_социальнго_положения", код_социального_положенияTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox3.Text);
                cmd_SQL.Parameters.AddWithValue("@Социальная_категория", социальная_категорияComboBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Инвалидность", инвалидностьComboBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Группа_инвалидности", группа_инвалидностиComboBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Семейное_положение", семейное_положениеComboBox.Text);
                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка! Данные о социальном положении не добавлены введите данные корректно! ");
                }
                finally
                {
                    connect.Close();
                    this.социальное_положениеTableAdapter.Fill(this.населениеDataSet.Социальное_положение);
                }
            }


            insertZP = false;
            updateZP = false;
            код_общих_сведенийTextBox.ReadOnly = false;
            код_документа_предоставляющего_льготуTextBox.ReadOnly = false;
            код_документа_удостоверяющего_личностьTextBox.ReadOnly = false;
            код_социального_положенияTextBox.ReadOnly = false;
            panel1.Visible = false;
            tabControl1.Visible = true;


        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите удалить запись?",
                                             "Удаление записи",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if ((insertZP != true) && (updateZP != true))
                {
                    SqlConnection connect = new SqlConnection(myConnectionString);
                    string sql = "exec del " + общие_сведенияDataGridView.Rows[общие_сведенияDataGridView.CurrentRow.Index].Cells[0].Value.ToString() + ";";
                    SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                    try
                    {
                        connect.Open();
                        int n = cmd_SQL.ExecuteNonQuery();
                        MessageBox.Show("Запись успешно Удалена!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка! с данными общими сведениями связаны документы, услуги и социальное положение, сначала нужно удалить связанные записи!");


                    }
                    finally
                    {
                        connect.Close();
                    }
                    общие_сведенияTableAdapter.Update(населениеDataSet.Общие_сведения);
                    this.общие_сведенияTableAdapter.Fill(this.населениеDataSet.Общие_сведения);

                    социальное_положениеTableAdapter.Update(населениеDataSet.Социальное_положение);
                    this.социальное_положениеTableAdapter.Fill(this.населениеDataSet.Социальное_положение);

                    документ_предоставляющий_льготуTableAdapter.Update(населениеDataSet.Документ_предоставляющий_льготу);
                    this.документ_предоставляющий_льготуTableAdapter.Fill(this.населениеDataSet.Документ_предоставляющий_льготу);

                    документ_удостоверяющий_личностьTableAdapter.Update(населениеDataSet.Документ_удостоверяющий_личность);
                    this.документ_удостоверяющий_личностьTableAdapter.Fill(this.населениеDataSet.Документ_удостоверяющий_личность);

                    услугиTableAdapter.Update(населениеDataSet.Услуги);
                    this.услугиTableAdapter.Fill(this.населениеDataSet.Услуги);
                }
            }
            else
            { return; }


        }



        private void Update_button_Click(object sender, EventArgs e)
        {

            if ((insertZP != true) && (updateZP != true))
            {
                updateZP = true;
                insertZP = false;
                код_общих_сведенийTextBox2.ReadOnly = true;
                groupBox5.Visible = true;
                tabControl1.Visible = false;

            }
        }

        private void Canel_button_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            tabControl1.Visible = true;
            if (insertZP == true)
            {
                документ_предоставляющий_льготуBindingSource.RemoveAt(документ_предоставляющий_льготуDataGridView.RowCount - 2);
                this.документ_предоставляющий_льготуTableAdapter.Fill(this.населениеDataSet.Документ_предоставляющий_льготу);

                документ_удостоверяющий_личностьBindingSource.RemoveAt(документ_удостоверяющий_личностьDataGridView.RowCount - 2);
                this.документ_удостоверяющий_личностьTableAdapter.Fill(this.населениеDataSet.Документ_удостоверяющий_личность);

                общие_сведенияBindingSource.RemoveAt(общие_сведенияDataGridView.RowCount - 2);
                this.общие_сведенияTableAdapter.Fill(this.населениеDataSet.Общие_сведения);

                социальное_положениеBindingSource.RemoveAt(социальное_положениеDataGridView.RowCount - 2);
                this.социальное_положениеTableAdapter.Fill(this.населениеDataSet.Социальное_положение);

            }
            insertZP = false;
            updateZP = false;
        }


        int kod5kod;
        private void kod5()
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            string query = "DECLARE @number1 INT, @rez1 INT; SET @number1 = 1; set @rez1=1; WHILE @number1 < 2147483647 BEGIN SET @number1 = @number1 + 1 IF @number1  in (select [Код услуги] from [Услуги]) set @number1=@number1; else BEGIN set @rez1=@number1; break;END; END; select @rez1;";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                kod5kod = Convert.ToInt32(reader[0]);

            }
            reader.Close();
            myConnection.Close();
        }






        private void Update_button1_Click(object sender, EventArgs e)
        {
            if ((insertZP != true) && (updateZP != true))
            {
                updateZP = true;
                insertZP = false;
                код_услугиTextBox.ReadOnly = true;
                tabControl1.Visible = false;
                groupBox4.Visible = true;
            }
        }

        private void Save_button1_Click(object sender, EventArgs e)
        {
            if ((insertZP))
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "INSERT INTO [Услуги]  ([Код услуги], [Код общих сведений], [Наименование услуги], [ФИО], [Дата оказания услуги]) VALUES (@Код_услуги, @Код_общих_сведений, @Наименование_услуги, @ФИО, @Дата_оказания_услуги);";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@Код_услуги", код_услугиTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Код_общих_сведений", код_общих_сведенийTextBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Наименование_услуги", наименование_услугиComboBox.Text);
                cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox7.Text);
                cmd_SQL.Parameters.AddWithValue("@Дата_оказания_услуги", дата_оказания_услугиDateTimePicker.Value);
                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();

                    MessageBox.Show("Запись успешно добавлена!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка! Запись не добавлена введите данные корректно! ");
                }
                finally
                {
                    connect.Close();
                    this.услугиTableAdapter.Fill(this.населениеDataSet.Услуги);
                }
            }
            else if (updateZP)
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "Update  [Услуги] set [Код общих сведений]=@Код_общих_сведений, [Наименование услуги]=@Наименование_услуги,  ФИО=@ФИО,  [Дата оказания услуги]=@Дата_оказания_услуги where [Код услуги] = @Код_услуги;";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@Код_услуги", код_услугиTextBox.Text);
                cmd_SQL.Parameters.AddWithValue("@Код_общих_сведений", код_общих_сведенийTextBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Наименование_услуги", наименование_услугиComboBox.Text);
                cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox7.Text);
                cmd_SQL.Parameters.AddWithValue("@Дата_оказания_услуги", дата_оказания_услугиDateTimePicker.Value);
                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно изменена!");
                    this.услугиTableAdapter.Fill(this.населениеDataSet.Услуги);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка! Запись не изменена введите данные корректно!");
                    if (insertZP == true)
                    {
                        услугиBindingSource.RemoveAt(услугиDataGridView.RowCount - 2);
                        this.услугиTableAdapter.Fill(this.населениеDataSet.Услуги);
                    }
                    groupBox4.Visible = false;
                    insertZP = false;
                    updateZP = false;
                }
                finally
                {
                    connect.Close();
                    this.услугиTableAdapter.Fill(this.населениеDataSet.Услуги);
                }
            }
            insertZP = false;
            updateZP = false;
            groupBox4.Visible = false;
            tabControl1.Visible = true;
            код_услугиTextBox.ReadOnly = false;
        }

        private void Canel_button1_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            tabControl1.Visible = true;
            if (insertZP == true)
            {
                услугиBindingSource.RemoveAt(услугиDataGridView.RowCount - 2);
                this.услугиTableAdapter.Fill(this.населениеDataSet.Услуги);
            }
            insertZP = false;
            updateZP = false;
        }


        private void Word_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "document.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(общие_сведенияDataGridView, sfd.FileName);
            }
        }


        private void Excel_button_Click(object sender, EventArgs e)
        {
            if (общие_сведенияDataGridView.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < общие_сведенияDataGridView.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = общие_сведенияDataGridView.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < общие_сведенияDataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < общие_сведенияDataGridView.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = общие_сведенияDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;

            }
        }




        private void Search_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Search_comboBox.SelectedIndex)
            {
                case 0:
                    znachosv = 2;

                    break;
                case 1:
                    znachosv = 3;

                    break;
                case 2:
                    znachosv = 4;

                    break;
                case 3:
                    znachosv = 5;

                    break;
                case 4:
                    znachosv = 6;

                    break;
                case 5:
                    znachosv = 7;

                    break;

            }
        }

        int znachosv = 0;
        int znachdpl = 0;
        int znachdul = 0;
        int znachspl = 0;
        int znachusl = 0;



        private void SearchOsv(int znachosv)
        {
            for (int i = 0; i < общие_сведенияDataGridView.RowCount; i++)

            {

                общие_сведенияDataGridView.Rows[i].Selected = false;

                int j = znachosv - 1;

                if (общие_сведенияDataGridView.Rows[i].Cells[j].Value != null)

                    if (общие_сведенияDataGridView.Rows[i].Cells[j].Value.ToString().Contains(Search_textBox.Text))

                    {

                        общие_сведенияDataGridView.Rows[i].Selected = true;

                        if (Search_textBox.Text == "") общие_сведенияDataGridView.ClearSelection();

                    }

            }
        }

        private void SearchDpl(int znachdpl)
        {
            for (int i = 0; i < документ_предоставляющий_льготуDataGridView.RowCount; i++)

            {

                документ_предоставляющий_льготуDataGridView.Rows[i].Selected = false;

                int j = znachdpl - 1;

                if (документ_предоставляющий_льготуDataGridView.Rows[i].Cells[j].Value != null)

                    if (документ_предоставляющий_льготуDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))

                    {

                        документ_предоставляющий_льготуDataGridView.Rows[i].Selected = true;

                        if (textBox1.Text == "") документ_предоставляющий_льготуDataGridView.ClearSelection();

                    }

            }
        }

        private void SearchDul(int znachdul)
        {
            for (int i = 0; i < документ_удостоверяющий_личностьDataGridView.RowCount; i++)

            {

                документ_удостоверяющий_личностьDataGridView.Rows[i].Selected = false;

                int j = znachdul - 1;

                if (документ_удостоверяющий_личностьDataGridView.Rows[i].Cells[j].Value != null)

                    if (документ_удостоверяющий_личностьDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox2.Text))

                    {

                        документ_удостоверяющий_личностьDataGridView.Rows[i].Selected = true;

                        if (textBox2.Text == "") документ_удостоверяющий_личностьDataGridView.ClearSelection();

                    }

            }
        }

        private void SearchSpl(int znachspl)
        {
            for (int i = 0; i < социальное_положениеDataGridView.RowCount; i++)

            {

                социальное_положениеDataGridView.Rows[i].Selected = false;

                int j = znachspl - 1;

                if (социальное_положениеDataGridView.Rows[i].Cells[j].Value != null)

                    if (социальное_положениеDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox3.Text))

                    {

                        социальное_положениеDataGridView.Rows[i].Selected = true;

                        if (textBox3.Text == "") социальное_положениеDataGridView.ClearSelection();

                    }

            }
        }

        private void SearchUsl(int znachusl)
        {
            for (int i = 0; i < услугиDataGridView.RowCount; i++)

            {

                услугиDataGridView.Rows[i].Selected = false;

                int j = znachusl - 1;

                if (услугиDataGridView.Rows[i].Cells[j].Value != null)

                    if (услугиDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))

                    {

                        услугиDataGridView.Rows[i].Selected = true;

                        if (textBox4.Text == "") услугиDataGridView.ClearSelection();

                    }

            }
        }

        private void Word_button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "document.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (услугиDataGridView.Visible == true)
                {
                    Export_Data_To_Word(услугиDataGridView, sfd.FileName);
                }
            }
        }

        private void Word_button2_Click(object sender, EventArgs e)
        {
            if (услугиDataGridView.Visible == true)
            {
                if (услугиDataGridView.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < услугиDataGridView.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = услугиDataGridView.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < услугиDataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < услугиDataGridView.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = услугиDataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                }
            }
        }

        private void Insert_Uslugi_button_Click(object sender, EventArgs e)
        {
            if ((insertZP != true) && (updateZP != true))
            {
                услугиBindingSource.AddNew();
                kod5();
                insertZP = true;
                updateZP = false;
                tabControl1.Visible = false;
                groupBox4.Visible = true;
                код_общих_сведенийTextBox1.Text = код_общих_сведенийTextBox2.Text;
                фИОTextBox7.Text = фИОTextBox.Text;
                код_услугиTextBox.ReadOnly = false;
                код_услугиTextBox.Text = kod5kod.ToString();
                код_услугиTextBox.ReadOnly = true;
            }
        }

        private void общие_сведенияDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in услугиDataGridView.Rows)
                if (row.Cells[1].Value.ToString() == код_общих_сведенийTextBox2.Text)
                {
                    row.Selected = true;
                }

            foreach (DataGridViewRow row1 in услугиDataGridView.Rows)
                if (row1.Cells[2].Value.ToString() == фИОTextBox.Text)
                {
                    row1.Selected = true;
                }
        }


        private void comboBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    znachdpl = 2;

                    break;
                case 1:
                    znachdpl = 3;

                    break;
                case 2:
                    znachdpl = 4;

                    break;
                case 3:
                    znachdpl = 5;

                    break;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    znachdul = 2;

                    break;
                case 1:
                    znachdul = 3;

                    break;
                case 2:
                    znachdul = 4;

                    break;
                case 3:
                    znachdul = 5;

                    break;
                case 4:
                    znachdul = 6;

                    break;
                case 5:
                    znachdul = 7;

                    break;
                case 6:
                    znachdul = 8;

                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox4.SelectedIndex)
            {
                case 0:
                    znachspl = 2;

                    break;
                case 1:
                    znachspl = 3;

                    break;
                case 2:
                    znachspl = 4;

                    break;
                case 3:
                    znachspl = 5;

                    break;
                case 4:
                    znachspl = 6;

                    break;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0:
                    znachusl = 3;

                    break;
                case 1:
                    znachusl = 4;

                    break;
                case 2:
                    znachusl = 5;

                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "document.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(социальное_положениеDataGridView, sfd.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "document.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(документ_предоставляющий_льготуDataGridView, sfd.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "document.docx";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(документ_удостоверяющий_личностьDataGridView, sfd.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (социальное_положениеDataGridView.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < социальное_положениеDataGridView.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = социальное_положениеDataGridView.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < социальное_положениеDataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < социальное_положениеDataGridView.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = социальное_положениеDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (документ_предоставляющий_льготуDataGridView.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < документ_предоставляющий_льготуDataGridView.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = документ_предоставляющий_льготуDataGridView.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < документ_предоставляющий_льготуDataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < документ_предоставляющий_льготуDataGridView.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = документ_предоставляющий_льготуDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (документ_удостоверяющий_личностьDataGridView.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < документ_удостоверяющий_личностьDataGridView.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = документ_удостоверяющий_личностьDataGridView.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < документ_удостоверяющий_личностьDataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < документ_удостоверяющий_личностьDataGridView.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = документ_удостоверяющий_личностьDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;

            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            List<string> filterParts = new List<string>();
            if (comboBox6.Text != "")
                filterParts.Add("[Социальная категория] like '*" + comboBox6.Text + "*'");
            if (comboBox7.Text != "")
                filterParts.Add("Инвалидность like '*" + comboBox7.Text + "*'");
            if (comboBox8.Text != "")
                filterParts.Add("[Группа инвалидности] like '*" + comboBox8.Text + "*'");
            if (textBox6.Text != "")
                filterParts.Add("ФИО like '*" + textBox6.Text + "*'");
            if (comboBox10.Text != "")
                filterParts.Add("[Семейное положение] like '*" + comboBox10.Text + "*'");
            string filter1 = string.Join(" AND ", filterParts);
            социальное_положениеBindingSource.Filter = filter1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            List<string> filterParts = new List<string>();
            if (comboBox11.Text != "")
                filterParts.Add("[Тип документа] like '*" + comboBox11.Text + "*'");
            if (textBox7.Text != "")
                filterParts.Add("Серия like '*" + textBox7.Text + "*'");
            if (textBox11.Text != "")
                filterParts.Add("Номер like '*" + textBox11.Text + "*'");
            if (textBox15.Text != "")
                filterParts.Add("ФИО like '*" + textBox15.Text + "*'");
            string filter2 = string.Join(" AND ", filterParts);
            документ_предоставляющий_льготуBindingSource.Filter = filter2;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<string> filterParts = new List<string>();
            if (comboBox14.Text != "")
                filterParts.Add("[Тип документа] like '*" + comboBox14.Text + "*'");
            if (textBox13.Text != "")
                filterParts.Add("Серия like '*" + textBox13.Text + "*'");
            if (textBox12.Text != "")
                filterParts.Add("Номер like '*" + textBox12.Text + "*'");
            if (textBox16.Text != "")
                filterParts.Add("ФИО like '*" + textBox16.Text + "*'");
            if (comboBox13.Text != "")
                filterParts.Add("[Кем выдан] like '*" + comboBox13.Text + "*'");
            string filter3 = string.Join(" AND ", filterParts);
            документ_удостоверяющий_личностьBindingSource.Filter = filter3;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            List<string> filterParts = new List<string>();
            if (textBox14.Text != "")
                filterParts.Add("ФИО like '*" + textBox14.Text + "*'");
            if (comboBox15.Text != "")
                filterParts.Add("[Наименование услуги] like '*" + comboBox15.Text + "*'");
            string filter4 = string.Join(" AND ", filterParts);
            услугиBindingSource.Filter = filter4;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            List<string> filterParts = new List<string>();
            if (textBox5.Text != "")
                filterParts.Add("ФИО like '*" + textBox5.Text + "*'");
            if (comboBox1.Text != "")
                filterParts.Add("Пол like '*" + comboBox1.Text + "*'");
            if (textBox8.Text != "")
                filterParts.Add("[Адрес регистрации] like '*" + textBox8.Text + "*'");
            if (textBox9.Text != "")
                filterParts.Add("[Адрес проживания] like '*" + textBox9.Text + "*'");
            if (textBox10.Text != "")
                filterParts.Add("Телефон like '*" + textBox10.Text + "*'");
            string filter = string.Join(" AND ", filterParts);
            общие_сведенияBindingSource.Filter = filter;
        }



        private void button7_Click(object sender, EventArgs e)
        {
            if ((insertZP != true) && (updateZP != true))
            {
                updateZP = true;
                insertZP = false;
                код_социального_положенияTextBox1.ReadOnly = true;
                groupBox3.Visible = true;
                tabControl1.Visible = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if ((insertZP != true) && (updateZP != true))
            {
                updateZP = true;
                insertZP = false;
                код_документа_предоставляющего_льготуTextBox1.ReadOnly = true;
                groupBox1.Visible = true;
                tabControl1.Visible = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if ((insertZP != true) && (updateZP != true))
            {
                updateZP = true;
                insertZP = false;
                код_документа_удостоверяющего_личностьTextBox1.ReadOnly = true;
                groupBox2.Visible = true;
                tabControl1.Visible = false;
                Canel_button.Visible = true;
                Save_button.Visible = true;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (updateZP)
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "Update  [Документ предоставляющий льготу] set ФИО = @ФИО, [Тип документа] = @Тип_документа, Серия = @Серия, Номер = @Номер, [Дата выдачи] = @Дата_выдачи where [Код документа предоставляющего льготу] = @Код_документа_предоставляющего_льготу;";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@Код_документа_предоставляющего_льготу", код_документа_предоставляющего_льготуTextBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox6.Text);
                cmd_SQL.Parameters.AddWithValue("@Тип_документа", тип_документаComboBox2.Text);
                cmd_SQL.Parameters.AddWithValue("@Серия", серияTextBox2.Text);
                cmd_SQL.Parameters.AddWithValue("@Номер", номерTextBox2.Text);
                cmd_SQL.Parameters.AddWithValue("@Дата_выдачи", дата_выдачиDateTimePicker2.Value);

                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно изменена!");
                    this.документ_предоставляющий_льготуTableAdapter.Fill(this.населениеDataSet.Документ_предоставляющий_льготу);
                }
                catch (SqlException ex)
                {

                    if (insertZP == true)
                    {
                        документ_предоставляющий_льготуBindingSource.RemoveAt(документ_предоставляющий_льготуDataGridView.RowCount - 2);
                        this.документ_предоставляющий_льготуTableAdapter.Fill(this.населениеDataSet.Документ_предоставляющий_льготу);
                    }
                    insertZP = false;
                    updateZP = false;
                }
                finally
                {
                    connect.Close();
                    this.документ_предоставляющий_льготуTableAdapter.Fill(this.населениеDataSet.Документ_предоставляющий_льготу);
                }
            }

            insertZP = false;
            updateZP = false;
            код_документа_предоставляющего_льготуTextBox.ReadOnly = false;
            groupBox1.Visible = false;
            tabControl1.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            tabControl1.Visible = true;
            if (insertZP == true)
            {
                документ_предоставляющий_льготуBindingSource.RemoveAt(документ_предоставляющий_льготуDataGridView.RowCount - 2);
                this.документ_предоставляющий_льготуTableAdapter.Fill(this.населениеDataSet.Документ_предоставляющий_льготу);
            }
            insertZP = false;
            updateZP = false;
        }

        /// <summary>
        /// КНОПКА ОБНОВЛЕНИЯ Документ удостоверяющий личность
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button21_Click(object sender, EventArgs e)
        {
            var document = new DokumentDto
            {
                КодДокументаУдостоверяющегоЛичность = int.Parse(код_документа_удостоверяющего_личностьTextBox1.Text),
                Фио = фИОTextBox8.Text,
                ТипДокумента = тип_документаComboBox3.Text,
                Серия = серияTextBox3.Text,
                Номер = номерTextBox3.Text,
                ДатаВыдачи = дата_выдачиDateTimePicker3.Value,
                ДатаОкончанияСрокаДействия = дата_окончания_срока_действияDateTimePicker3.Value,
                КемВыдан = кем_выданComboBox1.Text
            };

            using (HttpClient client = new HttpClient())
            {

                // Сериализация в JSON
                var json = JsonConvert.SerializeObject(document);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                // Отправка POST-запроса
                HttpResponseMessage response = await client.PostAsync("https://localhost:7144/api/Documents/saveDokumentUdostoveraushiyLichnost", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Запись успешно изменена!");

                    insertZP = false;
                    updateZP = false;
                    код_документа_удостоверяющего_личностьTextBox.ReadOnly = false;
                    groupBox2.Visible = false;
                    tabControl1.Visible = true;
                }

                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Ошибка: {error}");
                }
            }
            //if (updateZP)
            //{
            //    SqlConnection connect = new SqlConnection(myConnectionString);
            //    string sql = "Update  [Документ удостоверяющий личность] set ФИО = @ФИО, [Тип документа] = @Тип_документа, Серия = @Серия, Номер = @Номер, [Дата выдачи] = @Дата_выдачи, [Дата окончания срока действия] = @Дата_окончания_срока_действия, [Кем выдан] = @Кем_выдан  where [код документа удостоверяющего личность] = @код_документа_удостоверяющего_личность;";
            //    SqlCommand cmd_SQL = new SqlCommand(sql, connect);
            //    cmd_SQL.Parameters.AddWithValue("@код_документа_удостоверяющего_личность", код_документа_удостоверяющего_личностьTextBox1.Text);
            //    cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox8.Text);
            //    cmd_SQL.Parameters.AddWithValue("@Тип_документа", тип_документаComboBox3.Text);
            //    cmd_SQL.Parameters.AddWithValue("@Серия", серияTextBox3.Text);
            //    cmd_SQL.Parameters.AddWithValue("@Номер", номерTextBox3.Text);
            //    cmd_SQL.Parameters.AddWithValue("@Дата_выдачи", дата_выдачиDateTimePicker3.Value);
            //    cmd_SQL.Parameters.AddWithValue("@Дата_окончания_срока_действия", дата_окончания_срока_действияDateTimePicker3.Value);
            //    cmd_SQL.Parameters.AddWithValue("@Кем_выдан", кем_выданComboBox1.Text);
            //    try
            //    {
            //        connect.Open();
            //        int n = cmd_SQL.ExecuteNonQuery();
            //        MessageBox.Show("Запись успешно изменена!");
            //        this.документ_удостоверяющий_личностьTableAdapter.Fill(this.населениеDataSet.Документ_удостоверяющий_личность);
            //    }
            //    catch (SqlException ex)
            //    {

            //        if (insertZP == true)
            //        {
            //            документ_удостоверяющий_личностьBindingSource.RemoveAt(документ_удостоверяющий_личностьDataGridView.RowCount - 2);
            //            this.документ_удостоверяющий_личностьTableAdapter.Fill(this.населениеDataSet.Документ_удостоверяющий_личность);
            //        }
            //        insertZP = false;
            //        updateZP = false;
            //    }
            //    finally
            //    {
            //        connect.Close();
            //        this.документ_удостоверяющий_личностьTableAdapter.Fill(this.населениеDataSet.Документ_удостоверяющий_личность);
            //    }
            //}

            //insertZP = false;
            //updateZP = false;
            //код_документа_удостоверяющего_личностьTextBox.ReadOnly = false;
            //groupBox2.Visible = false;
            //tabControl1.Visible = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            tabControl1.Visible = true;
            if (insertZP == true)
            {
                документ_удостоверяющий_личностьBindingSource.RemoveAt(документ_удостоверяющий_личностьDataGridView.RowCount - 2);
                this.документ_удостоверяющий_личностьTableAdapter.Fill(this.населениеDataSet.Документ_удостоверяющий_личность);
            }
            insertZP = false;
            updateZP = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (updateZP)
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "Update  [Общие сведения] set ФИО = @ФИО, [Дата рождения] = @Дата_рождения, Пол = @Пол, [Адрес регистрации] = @Адрес_регистрации, [Адрес проживания] = @Адрес_проживания, Телефон = @Телефон  where [код общих сведений] = @код_общих_сведений;";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@код_общих_сведений", код_общих_сведенийTextBox3.Text);
                cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox9.Text);
                cmd_SQL.Parameters.AddWithValue("@Дата_рождения", дата_рожденияDateTimePicker1.Value);
                cmd_SQL.Parameters.AddWithValue("@Пол", полComboBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Адрес_регистрации", адрес_регистрацииTextBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Адрес_проживания", адрес_проживанияTextBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Телефон", телефонTextBox1.Text);
                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно изменена!");
                    this.общие_сведенияTableAdapter.Fill(this.населениеDataSet.Общие_сведения);
                }
                catch (SqlException ex)
                {

                    if (insertZP == true)
                    {
                        общие_сведенияBindingSource.RemoveAt(общие_сведенияDataGridView.RowCount - 2);
                        this.общие_сведенияTableAdapter.Fill(this.населениеDataSet.Общие_сведения);
                    }
                    insertZP = false;
                    updateZP = false;
                }
                finally
                {
                    connect.Close();
                    this.общие_сведенияTableAdapter.Fill(this.населениеDataSet.Общие_сведения);
                }
            }

            insertZP = false;
            updateZP = false;
            код_общих_сведенийTextBox.ReadOnly = false;
            groupBox5.Visible = false;
            tabControl1.Visible = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            tabControl1.Visible = true;
            if (insertZP == true)
            {
                общие_сведенияBindingSource.RemoveAt(общие_сведенияDataGridView.RowCount - 2);
                this.общие_сведенияTableAdapter.Fill(this.населениеDataSet.Общие_сведения);
            }
            insertZP = false;
            updateZP = false;
        }


        private void документ_предоставляющий_льготуBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.документ_предоставляющий_льготуBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.населениеDataSet);

        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";

            List<string> filterParts = new List<string>();
            if (textBox5.Text != "")
                filterParts.Add("ФИО like '*" + textBox5.Text + "*'");
            if (comboBox1.Text != "")
                filterParts.Add("Пол like '*" + comboBox1.Text + "*'");
            if (textBox8.Text != "")
                filterParts.Add("[Адрес регистрации] like '*" + textBox8.Text + "*'");
            if (textBox9.Text != "")
                filterParts.Add("[Адрес проживания] like '*" + textBox9.Text + "*'");
            if (textBox10.Text != "")
                filterParts.Add("Телефон like '*" + textBox10.Text + "*'");
            string filter = string.Join(" AND ", filterParts);
            общие_сведенияBindingSource.Filter = filter;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox10.Text = "";
            textBox6.Text = "";
            List<string> filterParts = new List<string>();
            if (comboBox6.Text != "")
                filterParts.Add("[Социальная категория] like '*" + comboBox6.Text + "*'");
            if (comboBox7.Text != "")
                filterParts.Add("Инвалидность like '*" + comboBox7.Text + "*'");
            if (comboBox8.Text != "")
                filterParts.Add("[Группа инвалидности] like '*" + comboBox8.Text + "*'");
            if (textBox6.Text != "")
                filterParts.Add("ФИО like '*" + textBox6.Text + "*'");
            if (comboBox10.Text != "")
                filterParts.Add("[Семейное положение] like '*" + comboBox10.Text + "*'");
            string filter1 = string.Join(" AND ", filterParts);
            социальное_положениеBindingSource.Filter = filter1;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            comboBox11.Text = "";
            textBox11.Text = "";
            textBox15.Text = "";
            List<string> filterParts = new List<string>();
            if (comboBox11.Text != "")
                filterParts.Add("[Тип документа] like '*" + comboBox11.Text + "*'");
            if (textBox7.Text != "")
                filterParts.Add("Серия like '*" + textBox7.Text + "*'");
            if (textBox11.Text != "")
                filterParts.Add("Номер like '*" + textBox11.Text + "*'");
            if (textBox15.Text != "")
                filterParts.Add("ФИО like '*" + textBox15.Text + "*'");
            string filter2 = string.Join(" AND ", filterParts);
            документ_предоставляющий_льготуBindingSource.Filter = filter2;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox13.Text = "";
            comboBox13.Text = "";
            comboBox14.Text = "";
            textBox12.Text = "";
            textBox16.Text = "";
            List<string> filterParts = new List<string>();
            if (comboBox14.Text != "")
                filterParts.Add("[Тип документа] like '*" + comboBox14.Text + "*'");
            if (textBox13.Text != "")
                filterParts.Add("Серия like '*" + textBox13.Text + "*'");
            if (textBox12.Text != "")
                filterParts.Add("Номер like '*" + textBox12.Text + "*'");
            if (textBox16.Text != "")
                filterParts.Add("ФИО like '*" + textBox16.Text + "*'");
            if (comboBox13.Text != "")
                filterParts.Add("[Кем выдан] like '*" + comboBox13.Text + "*'");
            string filter3 = string.Join(" AND ", filterParts);
            документ_удостоверяющий_личностьBindingSource.Filter = filter3;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            comboBox15.Text = "";
            List<string> filterParts = new List<string>();
            if (textBox14.Text != "")
                filterParts.Add("ФИО like '*" + textBox14.Text + "*'");
            if (comboBox15.Text != "")
                filterParts.Add("[Наименование услуги] like '*" + comboBox15.Text + "*'");
            string filter4 = string.Join(" AND ", filterParts);
            услугиBindingSource.Filter = filter4;
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



        private void button15_Click(object sender, EventArgs e)
        {
            if ((znachdul == 0) && (textBox2.Text != ""))
            {
                for (int i = 0; i < документ_удостоверяющий_личностьDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < документ_удостоверяющий_личностьDataGridView.ColumnCount; j++)

                        if (документ_удостоверяющий_личностьDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox2.Text))

                        {

                            документ_удостоверяющий_личностьDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (textBox2.Text != "") SearchDul(znachdul);
            else if (textBox2.Text == "") документ_удостоверяющий_личностьDataGridView.ClearSelection();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            if ((znachdul == 0) && (textBox2.Text != ""))
            {
                for (int i = 0; i < документ_удостоверяющий_личностьDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < документ_удостоверяющий_личностьDataGridView.ColumnCount; j++)

                        if (документ_удостоверяющий_личностьDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox2.Text))

                        {

                            документ_удостоверяющий_личностьDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (textBox2.Text != "") SearchDul(znachdul);
            else if (textBox2.Text == "") документ_удостоверяющий_личностьDataGridView.ClearSelection();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox10.Visible = true;
            }
            else
            {
                groupBox10.Visible = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                groupBox11.Visible = true;
            }
            else
            {
                groupBox11.Visible = false;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if ((znachosv == 0) && (Search_textBox.Text != ""))
            {
                for (int i = 0; i < общие_сведенияDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < общие_сведенияDataGridView.ColumnCount; j++)

                        if (общие_сведенияDataGridView.Rows[i].Cells[j].Value.ToString().Contains(Search_textBox.Text))

                        {

                            общие_сведенияDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (Search_textBox.Text != "") SearchOsv(znachosv);
            else if (Search_textBox.Text == "") общие_сведенияDataGridView.ClearSelection();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Search_textBox.Text = "";
            if ((znachosv == 0) && (Search_textBox.Text != ""))
            {
                for (int i = 0; i < общие_сведенияDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < общие_сведенияDataGridView.ColumnCount; j++)

                        if (общие_сведенияDataGridView.Rows[i].Cells[j].Value.ToString().Contains(Search_textBox.Text))

                        {

                            общие_сведенияDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (Search_textBox.Text != "") SearchOsv(znachosv);
            else if (Search_textBox.Text == "") общие_сведенияDataGridView.ClearSelection();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                groupBox12.Visible = true;
            }
            else
            {
                groupBox12.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                groupBox13.Visible = true;
            }
            else
            {
                groupBox13.Visible = false;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if ((znachspl == 0) && (textBox3.Text != ""))
            {
                for (int i = 0; i < социальное_положениеDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < социальное_положениеDataGridView.ColumnCount; j++)

                        if (социальное_положениеDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox3.Text))

                        {

                            социальное_положениеDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (textBox3.Text != "") SearchSpl(znachspl);
            else if (textBox3.Text == "") социальное_положениеDataGridView.ClearSelection();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            if ((znachspl == 0) && (textBox3.Text != ""))
            {
                for (int i = 0; i < социальное_положениеDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < социальное_положениеDataGridView.ColumnCount; j++)

                        if (социальное_положениеDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox3.Text))

                        {

                            социальное_положениеDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (textBox3.Text != "") SearchSpl(znachspl);
            else if (textBox3.Text == "") социальное_положениеDataGridView.ClearSelection();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if ((znachdpl == 0) && (textBox1.Text != ""))
            {
                for (int i = 0; i < документ_предоставляющий_льготуDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < документ_предоставляющий_льготуDataGridView.ColumnCount; j++)

                        if (документ_предоставляющий_льготуDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))

                        {

                            документ_предоставляющий_льготуDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (textBox1.Text != "") SearchDpl(znachdpl);
            else if (textBox1.Text == "") документ_предоставляющий_льготуDataGridView.ClearSelection();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if ((znachdpl == 0) && (textBox1.Text != ""))
            {
                for (int i = 0; i < документ_предоставляющий_льготуDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < документ_предоставляющий_льготуDataGridView.ColumnCount; j++)

                        if (документ_предоставляющий_льготуDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))

                        {

                            документ_предоставляющий_льготуDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (textBox1.Text != "") SearchDpl(znachdpl);
            else if (textBox1.Text == "") документ_предоставляющий_льготуDataGridView.ClearSelection();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                groupBox14.Visible = true;
            }
            else
            {
                groupBox14.Visible = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                groupBox15.Visible = true;
            }
            else
            {
                groupBox15.Visible = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                groupBox16.Visible = true;
            }
            else
            {
                groupBox16.Visible = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                groupBox17.Visible = true;
            }
            else
            {
                groupBox17.Visible = false;
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if ((znachusl == 0) && (textBox4.Text != ""))
            {
                for (int i = 0; i < услугиDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < услугиDataGridView.ColumnCount; j++)

                        if (услугиDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))

                        {

                            услугиDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (textBox4.Text != "") SearchUsl(znachusl);
            else if (textBox4.Text == "") услугиDataGridView.ClearSelection();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            if ((znachusl == 0) && (textBox4.Text != ""))
            {
                for (int i = 0; i < услугиDataGridView.RowCount; i++)

                {
                    for (int j = 0; j < услугиDataGridView.ColumnCount; j++)

                        if (услугиDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))

                        {

                            услугиDataGridView.Rows[i].Selected = true;


                        }

                }
            }
            else if (textBox4.Text != "") SearchUsl(znachusl);
            else if (textBox4.Text == "") услугиDataGridView.ClearSelection();

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                groupBox18.Visible = true;
            }
            else
            {
                groupBox18.Visible = false;
            }
        }



        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                groupBox19.Visible = true;
            }
            else
            {
                groupBox19.Visible = false;
            }
        }

        private void инвалидностьComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (инвалидностьComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    группа_инвалидностиComboBox.Text = "Нет";

                    break;
            }
        }

        private void инвалидностьComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (инвалидностьComboBox1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    группа_инвалидностиComboBox1.Text = "Нет";

                    break;
            }
        }







        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Статистика frm = new Статистика();
            this.Hide();
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }




        private void label26_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            О_программе frm = new О_программе();
            frm.Show();
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

        private void button39_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if ((insertZP != true) && (updateZP != true))
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "Delete from [Услуги] where [Код услуги] = @Код_услуги;";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@Код_услуги", услугиDataGridView.Rows[услугиDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно Удалена!");
                }
                finally
                {
                    connect.Close();
                }

                this.услугиTableAdapter.Fill(this.населениеDataSet.Услуги);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        

        private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
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

        private async void button41_Click(object sender, EventArgs e)
        {
            //using (var client = new HttpClient())
            //{
            //    var json = JsonConvert.SerializeObject("");
            //    var content = new StringContent(json, Encoding.UTF8, "application/json");

            //    var response = await client.GetAsync("https://localhost:7144/WeatherForecast/GetA?B=5");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var responseData = JsonConvert.DeserializeObject<IEnumerable<DocumentPredostavlaushiyLgotu>>(await response.Content.ReadAsStringAsync());
            //        var firstresponseData = responseData.FirstOrDefault();
            //        документ_предоставляющий_льготуDataGridView.DataSource = responseData;

            //    }
            //}
        }
      

        private void button25_Click(object sender, EventArgs e)
        {
            if (updateZP)
            {
                SqlConnection connect = new SqlConnection(myConnectionString);
                string sql = "Update  [Социальное положение] set ФИО = @ФИО, [Социальная категория] = @Социальная_категория,  [Инвалидность] = @Инвалидность, [Группа инвалидности] = @Группа_инвалидности, [Семейное положение] = @Семейное_положение where [код социального положения] = @код_социальнго_положения;";
                SqlCommand cmd_SQL = new SqlCommand(sql, connect);
                cmd_SQL.Parameters.AddWithValue("@код_социальнго_положения", код_социального_положенияTextBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@ФИО", фИОTextBox5.Text);
                cmd_SQL.Parameters.AddWithValue("@Социальная_категория", социальная_категорияComboBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Инвалидность", инвалидностьComboBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Группа_инвалидности", группа_инвалидностиComboBox1.Text);
                cmd_SQL.Parameters.AddWithValue("@Семейное_положение", семейное_положениеComboBox1.Text);
                try
                {
                    connect.Open();
                    int n = cmd_SQL.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно изменена!");
                    this.социальное_положениеTableAdapter.Fill(this.населениеDataSet.Социальное_положение);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка! Запись не изменена введите данные корректно!");
                    if (insertZP == true)
                    {
                        социальное_положениеBindingSource.RemoveAt(социальное_положениеDataGridView.RowCount - 2);
                        this.социальное_положениеTableAdapter.Fill(this.населениеDataSet.Социальное_положение);
                    }
                    insertZP = false;
                    updateZP = false;
                }
                finally
                {
                    connect.Close();
                    this.социальное_положениеTableAdapter.Fill(this.населениеDataSet.Социальное_положение);
                }
            }

            insertZP = false;
            updateZP = false;
            код_социального_положенияTextBox1.ReadOnly = false;
            groupBox3.Visible = false;
            tabControl1.Visible = true;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            tabControl1.Visible = true;
            if (insertZP == true)
            {
                социальное_положениеBindingSource.RemoveAt(социальное_положениеDataGridView.RowCount - 2);
                this.социальное_положениеTableAdapter.Fill(this.населениеDataSet.Социальное_положение);
            }
            insertZP = false;
            updateZP = false;
        }

                     

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        

        
    }
}
