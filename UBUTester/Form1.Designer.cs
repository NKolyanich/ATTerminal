namespace UBUTester
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxSendString = new System.Windows.Forms.TextBox();
            this.checkBoxLoop = new System.Windows.Forms.CheckBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.maskedTextBoxLoopDelay = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_crlf = new System.Windows.Forms.CheckBox();
            this.checkBox_esc = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(15, 17);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(54, 21);
            this.comboBoxPort.TabIndex = 0;
            this.comboBoxPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxPort_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(16, 41);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(53, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(320, 15);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(69, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // listViewLog
            // 
            this.listViewLog.BackColor = System.Drawing.SystemColors.Window;
            this.listViewLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.GridLines = true;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewLog.Location = new System.Drawing.Point(0, 113);
            this.listViewLog.MultiSelect = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.ShowGroups = false;
            this.listViewLog.Size = new System.Drawing.Size(510, 321);
            this.listViewLog.TabIndex = 4;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 38;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Время";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Данные";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 303;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "направ.";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 67;
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(16, 84);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(77, 23);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxSendString
            // 
            this.textBoxSendString.Location = new System.Drawing.Point(11, 17);
            this.textBoxSendString.MaxLength = 50;
            this.textBoxSendString.Name = "textBoxSendString";
            this.textBoxSendString.Size = new System.Drawing.Size(303, 20);
            this.textBoxSendString.TabIndex = 6;
            this.textBoxSendString.Text = "ATI";
            // 
            // checkBoxLoop
            // 
            this.checkBoxLoop.AutoSize = true;
            this.checkBoxLoop.Location = new System.Drawing.Point(11, 16);
            this.checkBoxLoop.Name = "checkBoxLoop";
            this.checkBoxLoop.Size = new System.Drawing.Size(75, 17);
            this.checkBoxLoop.TabIndex = 9;
            this.checkBoxLoop.Text = "Включить";
            this.checkBoxLoop.UseVisualStyleBackColor = true;
            this.checkBoxLoop.CheckedChanged += new System.EventHandler(this.checkBoxLoop_CheckedChanged);
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(83, 17);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(71, 13);
            this.labelDelay.TabIndex = 11;
            this.labelDelay.Text = "Период (мс):";
            // 
            // maskedTextBoxLoopDelay
            // 
            this.maskedTextBoxLoopDelay.Location = new System.Drawing.Point(155, 14);
            this.maskedTextBoxLoopDelay.Mask = "000000";
            this.maskedTextBoxLoopDelay.Name = "maskedTextBoxLoopDelay";
            this.maskedTextBoxLoopDelay.PromptChar = ' ';
            this.maskedTextBoxLoopDelay.Size = new System.Drawing.Size(59, 20);
            this.maskedTextBoxLoopDelay.TabIndex = 12;
            this.maskedTextBoxLoopDelay.Text = "500";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxPort);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(85, 71);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Порт";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maskedTextBoxLoopDelay);
            this.groupBox2.Controls.Add(this.checkBoxLoop);
            this.groupBox2.Controls.Add(this.labelDelay);
            this.groupBox2.Location = new System.Drawing.Point(103, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 42);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Цикл";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxSendString);
            this.groupBox3.Controls.Add(this.buttonSend);
            this.groupBox3.Location = new System.Drawing.Point(103, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 47);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Данные";
            // 
            // checkBox_crlf
            // 
            this.checkBox_crlf.AutoSize = true;
            this.checkBox_crlf.Location = new System.Drawing.Point(337, 23);
            this.checkBox_crlf.Name = "checkBox_crlf";
            this.checkBox_crlf.Size = new System.Drawing.Size(59, 17);
            this.checkBox_crlf.TabIndex = 16;
            this.checkBox_crlf.Text = "CR+LF";
            this.checkBox_crlf.UseVisualStyleBackColor = true;
            // 
            // checkBox_esc
            // 
            this.checkBox_esc.AutoSize = true;
            this.checkBox_esc.Location = new System.Drawing.Point(402, 23);
            this.checkBox_esc.Name = "checkBox_esc";
            this.checkBox_esc.Size = new System.Drawing.Size(47, 17);
            this.checkBox_esc.TabIndex = 17;
            this.checkBox_esc.Text = "ESC";
            this.checkBox_esc.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 434);
            this.Controls.Add(this.checkBox_esc);
            this.Controls.Add(this.checkBox_crlf);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.listViewLog);
            this.Name = "Form1";
            this.Text = "ATTerminal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxSendString;
        private System.Windows.Forms.CheckBox checkBoxLoop;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxLoopDelay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkBox_crlf;
        private System.Windows.Forms.CheckBox checkBox_esc;
    }
}

