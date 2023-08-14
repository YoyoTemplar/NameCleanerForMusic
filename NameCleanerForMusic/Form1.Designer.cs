namespace NameCleanerForMusic
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
            this.components = new System.ComponentModel.Container();
            this.listBox_results = new System.Windows.Forms.ListBox();
            this.contextMenuStrip_listBox_results = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_ClearName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ClearSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.button_Go = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip_listBox_results.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_results
            // 
            this.listBox_results.ContextMenuStrip = this.contextMenuStrip_listBox_results;
            this.listBox_results.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox_results.FormattingEnabled = true;
            this.listBox_results.Location = new System.Drawing.Point(0, 100);
            this.listBox_results.Name = "listBox_results";
            this.listBox_results.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_results.Size = new System.Drawing.Size(940, 498);
            this.listBox_results.TabIndex = 0;
            this.listBox_results.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_results_MouseDoubleClick);
            this.listBox_results.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox_results_MouseUp);
            // 
            // contextMenuStrip_listBox_results
            // 
            this.contextMenuStrip_listBox_results.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ClearName,
            this.toolStripMenuItem_ClearSelected});
            this.contextMenuStrip_listBox_results.Name = "contextMenuStrip_listBox_results";
            this.contextMenuStrip_listBox_results.Size = new System.Drawing.Size(197, 70);
            // 
            // ToolStripMenuItem_ClearName
            // 
            this.ToolStripMenuItem_ClearName.Name = "ToolStripMenuItem_ClearName";
            this.ToolStripMenuItem_ClearName.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItem_ClearName.Text = "Очистить имя";
            this.ToolStripMenuItem_ClearName.Click += new System.EventHandler(this.ToolStripMenuItem_ClearName_Click);
            // 
            // toolStripMenuItem_ClearSelected
            // 
            this.toolStripMenuItem_ClearSelected.Name = "toolStripMenuItem_ClearSelected";
            this.toolStripMenuItem_ClearSelected.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_ClearSelected.Text = "Очистить выделенное";
            this.toolStripMenuItem_ClearSelected.Click += new System.EventHandler(this.toolStripMenuItem_ClearSelected_Click);
            // 
            // textBox_Path
            // 
            this.textBox_Path.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox_Path.Location = new System.Drawing.Point(12, 12);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(712, 20);
            this.textBox_Path.TabIndex = 1;
            this.textBox_Path.Text = "C:\\Users\\Александр\\Desktop\\Новая папка (5)";
            // 
            // button_Go
            // 
            this.button_Go.Location = new System.Drawing.Point(743, 9);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(75, 23);
            this.button_Go.TabIndex = 2;
            this.button_Go.Text = "Перейти";
            this.button_Go.UseVisualStyleBackColor = true;
            this.button_Go.Click += new System.EventHandler(this.button_Go_Click);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(835, 10);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 3;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(115, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Обзор";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Очистить";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 598);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_Go);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.listBox_results);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip_listBox_results.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox_results;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Button button_Go;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_listBox_results;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ClearName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ClearSelected;
    }
}

