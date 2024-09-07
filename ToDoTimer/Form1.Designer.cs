namespace ToDoTimer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBoxToDo = new TextBox();
            btnRegister = new Button();
            btnInit = new Button();
            dataGridViewTimer = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            maskedTextTime = new MaskedTextBox();
            btnDelete = new Button();
            toDo = new DataGridViewTextBoxColumn();
            startDate = new DataGridViewTextBoxColumn();
            TargetDate = new DataGridViewTextBoxColumn();
            TargetTime = new DataGridViewTextBoxColumn();
            timeElapsed = new DataGridViewTextBoxColumn();
            timerStart = new DataGridViewButtonColumn();
            timerStop = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTimer).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 8);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "할 일";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(599, 8);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "목표 시간";
            // 
            // textBoxToDo
            // 
            textBoxToDo.Location = new Point(20, 27);
            textBoxToDo.Name = "textBoxToDo";
            textBoxToDo.Size = new Size(100, 23);
            textBoxToDo.TabIndex = 2;
            textBoxToDo.KeyDown += textBoxToDo_KeyDown;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(754, 27);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "등록";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnInit
            // 
            btnInit.Location = new Point(842, 27);
            btnInit.Name = "btnInit";
            btnInit.Size = new Size(75, 23);
            btnInit.TabIndex = 5;
            btnInit.Text = "초기화";
            btnInit.UseVisualStyleBackColor = true;
            btnInit.Click += btnInit_Click;
            // 
            // dataGridViewTimer
            // 
            dataGridViewTimer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTimer.Columns.AddRange(new DataGridViewColumn[] { toDo, startDate, TargetDate, TargetTime, timeElapsed, timerStart, timerStop });
            dataGridViewTimer.Location = new Point(20, 70);
            dataGridViewTimer.Name = "dataGridViewTimer";
            dataGridViewTimer.Size = new Size(948, 343);
            dataGridViewTimer.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(142, 9);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 7;
            label3.Text = "시작 날짜";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(373, 8);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 8;
            label4.Text = "목표 날짜";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(143, 27);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 11;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(373, 28);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 12;
            // 
            // maskedTextTime
            // 
            maskedTextTime.Location = new Point(599, 27);
            maskedTextTime.Name = "maskedTextTime";
            maskedTextTime.Size = new Size(100, 23);
            maskedTextTime.TabIndex = 13;
            maskedTextTime.TextChanged += maskedTextTime_TextChanged;
            maskedTextTime.KeyPress += textBoxTime_KeyPress;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(893, 431);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "삭제";
            btnDelete.UseCompatibleTextRendering = true;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // toDo
            // 
            toDo.HeaderText = "할 일";
            toDo.Name = "toDo";
            // 
            // startDate
            // 
            startDate.HeaderText = "시작 날짜";
            startDate.Name = "startDate";
            startDate.Width = 200;
            // 
            // TargetDate
            // 
            TargetDate.HeaderText = "목표 날짜";
            TargetDate.Name = "TargetDate";
            TargetDate.Width = 200;
            // 
            // TargetTime
            // 
            TargetTime.HeaderText = "목표 시간";
            TargetTime.Name = "TargetTime";
            // 
            // timeElapsed
            // 
            timeElapsed.HeaderText = "달성한 시간";
            timeElapsed.Name = "timeElapsed";
            // 
            // timerStart
            // 
            timerStart.HeaderText = "타이머 시작";
            timerStart.Name = "timerStart";
            timerStart.Resizable = DataGridViewTriState.True;
            timerStart.SortMode = DataGridViewColumnSortMode.Automatic;
            timerStart.Text = "시작";
            timerStart.UseColumnTextForButtonValue = true;
            // 
            // timerStop
            // 
            timerStop.HeaderText = "타이머 정지";
            timerStop.Name = "timerStop";
            timerStop.Resizable = DataGridViewTriState.True;
            timerStop.SortMode = DataGridViewColumnSortMode.Automatic;
            timerStop.Text = "정지";
            timerStop.UseColumnTextForButtonValue = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 593);
            Controls.Add(btnDelete);
            Controls.Add(maskedTextTime);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dataGridViewTimer);
            Controls.Add(btnInit);
            Controls.Add(btnRegister);
            Controls.Add(textBoxToDo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTimer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxToDo;
        private TextBox textBoxTime;
        private Button btnRegister;
        private Button btnInit;
        private DataGridView dataGridViewTimer;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private MaskedTextBox maskedTextTime;
        private Button btnDelete;
        private DataGridViewTextBoxColumn toDo;
        private DataGridViewTextBoxColumn startDate;
        private DataGridViewTextBoxColumn TargetDate;
        private DataGridViewTextBoxColumn TargetTime;
        private DataGridViewTextBoxColumn timeElapsed;
        private DataGridViewButtonColumn timerStart;
        private DataGridViewButtonColumn timerStop;
    }
}
