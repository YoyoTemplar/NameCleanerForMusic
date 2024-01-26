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
            this.button_back = new System.Windows.Forms.Button();
            this.comboBox_Path = new System.Windows.Forms.ComboBox();
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
            this.contextMenuStrip_listBox_results.Size = new System.Drawing.Size(197, 48);
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
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(754, 29);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 3;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // comboBox_Path
            // 
            this.comboBox_Path.FormattingEnabled = true;
            this.comboBox_Path.Location = new System.Drawing.Point(22, 29);
            this.comboBox_Path.Name = "comboBox_Path";
            this.comboBox_Path.Size = new System.Drawing.Size(711, 21);
            this.comboBox_Path.TabIndex = 4;
            this.comboBox_Path.Text = "C:\\Users\\Александр\\Desktop";
            this.comboBox_Path.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox_Path_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 598);
            this.Controls.Add(this.comboBox_Path);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.listBox_results);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip_listBox_results.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox_results;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_listBox_results;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ClearName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ClearSelected;
        private System.Windows.Forms.ComboBox comboBox_Path;
    }
}

