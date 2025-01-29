namespace Sample_4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_RunningProcesses = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_AvailableBuilds = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_CloseWindow = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_RunApp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_AvialableApps = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_NameApp = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox_RunningApp = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_Log = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_SelectedButton = new System.Windows.Forms.ToolStripLabel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1041, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_RunningProcesses);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 411);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Запущенные процессы";
            // 
            // textBox_RunningProcesses
            // 
            this.textBox_RunningProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RunningProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_RunningProcesses.Location = new System.Drawing.Point(3, 16);
            this.textBox_RunningProcesses.Multiline = true;
            this.textBox_RunningProcesses.Name = "textBox_RunningProcesses";
            this.textBox_RunningProcesses.ReadOnly = true;
            this.textBox_RunningProcesses.Size = new System.Drawing.Size(278, 392);
            this.textBox_RunningProcesses.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_AvailableBuilds);
            this.groupBox2.Location = new System.Drawing.Point(745, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 411);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Доступные сборки";
            // 
            // textBox_AvailableBuilds
            // 
            this.textBox_AvailableBuilds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_AvailableBuilds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_AvailableBuilds.Location = new System.Drawing.Point(3, 16);
            this.textBox_AvailableBuilds.Multiline = true;
            this.textBox_AvailableBuilds.Name = "textBox_AvailableBuilds";
            this.textBox_AvailableBuilds.ReadOnly = true;
            this.textBox_AvailableBuilds.Size = new System.Drawing.Size(278, 392);
            this.textBox_AvailableBuilds.TabIndex = 0;
            // 
            // button_Start
            // 
            this.button_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Start.Location = new System.Drawing.Point(340, 197);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(182, 46);
            this.button_Start.TabIndex = 3;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Stop.Location = new System.Drawing.Point(340, 250);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(182, 46);
            this.button_Stop.TabIndex = 4;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_CloseWindow
            // 
            this.button_CloseWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CloseWindow.Location = new System.Drawing.Point(528, 197);
            this.button_CloseWindow.Name = "button_CloseWindow";
            this.button_CloseWindow.Size = new System.Drawing.Size(182, 46);
            this.button_CloseWindow.TabIndex = 5;
            this.button_CloseWindow.Text = "CloseWindow";
            this.button_CloseWindow.UseVisualStyleBackColor = true;
            this.button_CloseWindow.Click += new System.EventHandler(this.button_CloseWindow_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Refresh.Location = new System.Drawing.Point(528, 250);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(182, 46);
            this.button_Refresh.TabIndex = 6;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // button_RunApp
            // 
            this.button_RunApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_RunApp.Location = new System.Drawing.Point(436, 308);
            this.button_RunApp.Name = "button_RunApp";
            this.button_RunApp.Size = new System.Drawing.Size(182, 46);
            this.button_RunApp.TabIndex = 7;
            this.button_RunApp.Text = "RunApp";
            this.button_RunApp.UseVisualStyleBackColor = true;
            this.button_RunApp.Click += new System.EventHandler(this.button_RunApp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_AvialableApps);
            this.groupBox3.Location = new System.Drawing.Point(302, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 76);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Доступные приложения";
            // 
            // comboBox_AvialableApps
            // 
            this.comboBox_AvialableApps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_AvialableApps.FormattingEnabled = true;
            this.comboBox_AvialableApps.Location = new System.Drawing.Point(6, 31);
            this.comboBox_AvialableApps.Name = "comboBox_AvialableApps";
            this.comboBox_AvialableApps.Size = new System.Drawing.Size(425, 32);
            this.comboBox_AvialableApps.TabIndex = 0;
            this.comboBox_AvialableApps.SelectedIndexChanged += new System.EventHandler(this.comboBox_AvialableApps_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_NameApp);
            this.groupBox4.Location = new System.Drawing.Point(302, 360);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(437, 75);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Название приложения для запуска";
            // 
            // textBox_NameApp
            // 
            this.textBox_NameApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_NameApp.Location = new System.Drawing.Point(6, 33);
            this.textBox_NameApp.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_NameApp.Name = "textBox_NameApp";
            this.textBox_NameApp.Size = new System.Drawing.Size(425, 28);
            this.textBox_NameApp.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox_RunningApp);
            this.groupBox5.Location = new System.Drawing.Point(302, 110);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(437, 76);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Запущенные приложения (PID: Name)";
            // 
            // comboBox_RunningApp
            // 
            this.comboBox_RunningApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_RunningApp.FormattingEnabled = true;
            this.comboBox_RunningApp.Location = new System.Drawing.Point(6, 31);
            this.comboBox_RunningApp.Name = "comboBox_RunningApp";
            this.comboBox_RunningApp.Size = new System.Drawing.Size(425, 32);
            this.comboBox_RunningApp.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_Log,
            this.toolStripLabel_SelectedButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 441);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1041, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel_Log
            // 
            this.toolStripLabel_Log.Name = "toolStripLabel_Log";
            this.toolStripLabel_Log.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripLabel_SelectedButton
            // 
            this.toolStripLabel_SelectedButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_SelectedButton.Name = "toolStripLabel_SelectedButton";
            this.toolStripLabel_SelectedButton.Size = new System.Drawing.Size(0, 22);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 466);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_RunApp);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.button_CloseWindow);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Управление дочерними процессами";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_RunningProcesses;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_AvailableBuilds;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_CloseWindow;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_RunApp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_AvialableApps;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_NameApp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBox_RunningApp;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Log;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SelectedButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

