namespace Учёт_населения
{
    partial class Статистика
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Статистика));
            this.населениеDataSet = new Учёт_населения.НаселениеDataSet();
            this.общие_сведенияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.общие_сведенияTableAdapter = new Учёт_населения.НаселениеDataSetTableAdapters.Общие_сведенияTableAdapter();
            this.tableAdapterManager = new Учёт_населения.НаселениеDataSetTableAdapters.TableAdapterManager();
            this.социальное_положениеTableAdapter = new Учёт_населения.НаселениеDataSetTableAdapters.Социальное_положениеTableAdapter();
            this.услугиTableAdapter = new Учёт_населения.НаселениеDataSetTableAdapters.УслугиTableAdapter();
            this.социальное_положениеBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.услугиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.общие_сведенияDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.социальное_положениеDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.услугиDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label26 = new System.Windows.Forms.Label();
            this.button39 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.населениеDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.общие_сведенияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.социальное_положениеBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.услугиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.общие_сведенияDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.социальное_положениеDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.услугиDataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // населениеDataSet
            // 
            this.населениеDataSet.DataSetName = "НаселениеDataSet";
            this.населениеDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // общие_сведенияBindingSource
            // 
            this.общие_сведенияBindingSource.DataMember = "Общие сведения";
            this.общие_сведенияBindingSource.DataSource = this.населениеDataSet;
            // 
            // общие_сведенияTableAdapter
            // 
            this.общие_сведенияTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Учёт_населения.НаселениеDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.Документ_предоставляющий_льготуTableAdapter = null;
            this.tableAdapterManager.Документ_удостоверяющий_личностьTableAdapter = null;
            this.tableAdapterManager.Общие_сведенияTableAdapter = this.общие_сведенияTableAdapter;
            this.tableAdapterManager.Социальное_положениеTableAdapter = this.социальное_положениеTableAdapter;
            this.tableAdapterManager.УслугиTableAdapter = this.услугиTableAdapter;
            // 
            // социальное_положениеTableAdapter
            // 
            this.социальное_положениеTableAdapter.ClearBeforeFill = true;
            // 
            // услугиTableAdapter
            // 
            this.услугиTableAdapter.ClearBeforeFill = true;
            // 
            // социальное_положениеBindingSource
            // 
            this.социальное_положениеBindingSource.DataMember = "Социальное положение";
            this.социальное_положениеBindingSource.DataSource = this.населениеDataSet;
            // 
            // услугиBindingSource
            // 
            this.услугиBindingSource.DataMember = "Услуги";
            this.услугиBindingSource.DataSource = this.населениеDataSet;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Azure;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(87, 473);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1110, 415);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // общие_сведенияDataGridView
            // 
            this.общие_сведенияDataGridView.AllowUserToAddRows = false;
            this.общие_сведенияDataGridView.AllowUserToDeleteRows = false;
            this.общие_сведенияDataGridView.AllowUserToResizeColumns = false;
            this.общие_сведенияDataGridView.AllowUserToResizeRows = false;
            this.общие_сведенияDataGridView.AutoGenerateColumns = false;
            this.общие_сведенияDataGridView.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.общие_сведенияDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.общие_сведенияDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.общие_сведенияDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.общие_сведенияDataGridView.DataSource = this.общие_сведенияBindingSource;
            this.общие_сведенияDataGridView.Location = new System.Drawing.Point(119, 117);
            this.общие_сведенияDataGridView.Name = "общие_сведенияDataGridView";
            this.общие_сведенияDataGridView.ReadOnly = true;
            this.общие_сведенияDataGridView.RowHeadersVisible = false;
            this.общие_сведенияDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.общие_сведенияDataGridView.Size = new System.Drawing.Size(1044, 350);
            this.общие_сведенияDataGridView.TabIndex = 5;
            this.общие_сведенияDataGridView.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Код общих сведений";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код общих сведений";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ФИО";
            this.dataGridViewTextBoxColumn2.HeaderText = "ФИО";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Дата рождения";
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата рождения";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Пол";
            this.dataGridViewTextBoxColumn4.HeaderText = "Пол";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Адрес регистрации";
            this.dataGridViewTextBoxColumn5.HeaderText = "Адрес регистрации";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 250;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Адрес проживания";
            this.dataGridViewTextBoxColumn6.HeaderText = "Адрес проживания";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 250;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Телефон";
            this.dataGridViewTextBoxColumn7.HeaderText = "Телефон";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 110;
            // 
            // социальное_положениеDataGridView
            // 
            this.социальное_положениеDataGridView.AllowUserToAddRows = false;
            this.социальное_положениеDataGridView.AllowUserToDeleteRows = false;
            this.социальное_положениеDataGridView.AllowUserToResizeColumns = false;
            this.социальное_положениеDataGridView.AllowUserToResizeRows = false;
            this.социальное_положениеDataGridView.AutoGenerateColumns = false;
            this.социальное_положениеDataGridView.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.социальное_положениеDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.социальное_положениеDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.социальное_положениеDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            this.социальное_положениеDataGridView.DataSource = this.социальное_положениеBindingSource;
            this.социальное_положениеDataGridView.Location = new System.Drawing.Point(119, 117);
            this.социальное_положениеDataGridView.Name = "социальное_положениеDataGridView";
            this.социальное_положениеDataGridView.ReadOnly = true;
            this.социальное_положениеDataGridView.RowHeadersVisible = false;
            this.социальное_положениеDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.социальное_положениеDataGridView.Size = new System.Drawing.Size(1044, 350);
            this.социальное_положениеDataGridView.TabIndex = 5;
            this.социальное_положениеDataGridView.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Код социального положения";
            this.dataGridViewTextBoxColumn8.HeaderText = "Код социального положения";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ФИО";
            this.dataGridViewTextBoxColumn9.HeaderText = "ФИО";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 200;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Социальная категория";
            this.dataGridViewTextBoxColumn10.HeaderText = "Социальная категория";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 270;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Инвалидность";
            this.dataGridViewTextBoxColumn11.HeaderText = "Инвалидность";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Группа инвалидности";
            this.dataGridViewTextBoxColumn12.HeaderText = "Группа инвалидности";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 185;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Семейное положение";
            this.dataGridViewTextBoxColumn13.HeaderText = "Семейное положение";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 185;
            // 
            // услугиDataGridView
            // 
            this.услугиDataGridView.AllowUserToAddRows = false;
            this.услугиDataGridView.AllowUserToDeleteRows = false;
            this.услугиDataGridView.AllowUserToResizeColumns = false;
            this.услугиDataGridView.AllowUserToResizeRows = false;
            this.услугиDataGridView.AutoGenerateColumns = false;
            this.услугиDataGridView.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.услугиDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.услугиDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.услугиDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18});
            this.услугиDataGridView.DataSource = this.услугиBindingSource;
            this.услугиDataGridView.Location = new System.Drawing.Point(119, 117);
            this.услугиDataGridView.Name = "услугиDataGridView";
            this.услугиDataGridView.ReadOnly = true;
            this.услугиDataGridView.RowHeadersVisible = false;
            this.услугиDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.услугиDataGridView.Size = new System.Drawing.Size(1044, 350);
            this.услугиDataGridView.TabIndex = 5;
            this.услугиDataGridView.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Код услуги";
            this.dataGridViewTextBoxColumn14.HeaderText = "Код услуги";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Код общих сведений";
            this.dataGridViewTextBoxColumn15.HeaderText = "Код общих сведений";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "ФИО";
            this.dataGridViewTextBoxColumn16.HeaderText = "ФИО";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 300;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Наименование услуги";
            this.dataGridViewTextBoxColumn17.HeaderText = "Наименование услуги";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 340;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Дата оказания услуги";
            this.dataGridViewTextBoxColumn18.HeaderText = "Дата оказания услуги";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 200;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Пол",
            "Социальная категория",
            "Инвалидность",
            "Группа инваоидности",
            "Семейное положение",
            "Услуги"});
            this.comboBox1.Location = new System.Drawing.Point(119, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(1044, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(268, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(366, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Сформировать статистику";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(640, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(364, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "Закрыть статистику";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 27);
            this.menuStrip1.TabIndex = 54;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.менюToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.BackColor = System.Drawing.Color.PaleTurquoise;
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.BackColor = System.Drawing.Color.PaleTurquoise;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.BackColor = System.Drawing.Color.PaleTurquoise;
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.выйтиToolStripMenuItem.Text = "Выход";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label26.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(558, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(149, 23);
            this.label26.TabIndex = 110;
            this.label26.Text = "Учёт населения";
            this.label26.DoubleClick += new System.EventHandler(this.label26_Click);
            // 
            // button39
            // 
            this.button39.BackColor = System.Drawing.Color.LightBlue;
            this.button39.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button39.Image = global::Учёт_населения.Properties.Resources.Свернуть_2;
            this.button39.Location = new System.Drawing.Point(1209, 2);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(33, 21);
            this.button39.TabIndex = 112;
            this.button39.UseVisualStyleBackColor = false;
            this.button39.Click += new System.EventHandler(this.button39_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button13.Image = global::Учёт_населения.Properties.Resources.Выйти_1;
            this.button13.Location = new System.Drawing.Point(1248, 2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(33, 21);
            this.button13.TabIndex = 111;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // Статистика
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1284, 900);
            this.Controls.Add(this.button39);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.общие_сведенияDataGridView);
            this.Controls.Add(this.услугиDataGridView);
            this.Controls.Add(this.социальное_положениеDataGridView);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Статистика";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика";
            this.Load += new System.EventHandler(this.Статистика_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Статистика_HelpRequested);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Статистика_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.населениеDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.общие_сведенияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.социальное_положениеBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.услугиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.общие_сведенияDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.социальное_положениеDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.услугиDataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private НаселениеDataSet населениеDataSet;
        private System.Windows.Forms.BindingSource общие_сведенияBindingSource;
        private НаселениеDataSetTableAdapters.Общие_сведенияTableAdapter общие_сведенияTableAdapter;
        private НаселениеDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private НаселениеDataSetTableAdapters.Социальное_положениеTableAdapter социальное_положениеTableAdapter;
        private System.Windows.Forms.BindingSource социальное_положениеBindingSource;
        private НаселениеDataSetTableAdapters.УслугиTableAdapter услугиTableAdapter;
        private System.Windows.Forms.BindingSource услугиBindingSource;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView общие_сведенияDataGridView;
        private System.Windows.Forms.DataGridView социальное_положениеDataGridView;
        private System.Windows.Forms.DataGridView услугиDataGridView;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button13;
    }
}