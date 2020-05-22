namespace SetCPUCardParameter
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmbmain001 = new System.Windows.Forms.ComboBox();
            this.labmain001 = new System.Windows.Forms.Label();
            this.tabCmain001 = new System.Windows.Forms.TabControl();
            this.tabPmain001 = new System.Windows.Forms.TabPage();
            this.tabPmain002 = new System.Windows.Forms.TabPage();
            this.bdgmain002 = new UI_Lib.BorderGroupBox();
            this.bdgmain001 = new UI_Lib.BorderGroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labmain002 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.labmain003 = new System.Windows.Forms.Label();
            this.bttmain001 = new System.Windows.Forms.Button();
            this.bttmain002 = new System.Windows.Forms.Button();
            this.tabCmain001.SuspendLayout();
            this.tabPmain001.SuspendLayout();
            this.bdgmain001.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbmain001
            // 
            this.cmbmain001.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmain001.FormattingEnabled = true;
            this.cmbmain001.Location = new System.Drawing.Point(1717, 5);
            this.cmbmain001.Name = "cmbmain001";
            this.cmbmain001.Size = new System.Drawing.Size(175, 28);
            this.cmbmain001.TabIndex = 8;
            this.cmbmain001.SelectedIndexChanged += new System.EventHandler(this.cmbmain001_SelectedIndexChanged);
            // 
            // labmain001
            // 
            this.labmain001.AutoSize = true;
            this.labmain001.Location = new System.Drawing.Point(1591, 9);
            this.labmain001.Name = "labmain001";
            this.labmain001.Size = new System.Drawing.Size(88, 20);
            this.labmain001.TabIndex = 7;
            this.labmain001.Text = "COM Port:";
            // 
            // tabCmain001
            // 
            this.tabCmain001.Controls.Add(this.tabPmain001);
            this.tabCmain001.Controls.Add(this.tabPmain002);
            this.tabCmain001.Location = new System.Drawing.Point(12, 39);
            this.tabCmain001.Name = "tabCmain001";
            this.tabCmain001.SelectedIndex = 0;
            this.tabCmain001.Size = new System.Drawing.Size(1880, 961);
            this.tabCmain001.TabIndex = 9;
            // 
            // tabPmain001
            // 
            this.tabPmain001.Controls.Add(this.bdgmain002);
            this.tabPmain001.Controls.Add(this.bdgmain001);
            this.tabPmain001.Location = new System.Drawing.Point(4, 29);
            this.tabPmain001.Name = "tabPmain001";
            this.tabPmain001.Padding = new System.Windows.Forms.Padding(3);
            this.tabPmain001.Size = new System.Drawing.Size(1872, 928);
            this.tabPmain001.TabIndex = 0;
            this.tabPmain001.Text = "tabPage1";
            this.tabPmain001.UseVisualStyleBackColor = true;
            // 
            // tabPmain002
            // 
            this.tabPmain002.Location = new System.Drawing.Point(4, 29);
            this.tabPmain002.Name = "tabPmain002";
            this.tabPmain002.Padding = new System.Windows.Forms.Padding(3);
            this.tabPmain002.Size = new System.Drawing.Size(1872, 928);
            this.tabPmain002.TabIndex = 1;
            this.tabPmain002.Text = "tabPage2";
            this.tabPmain002.UseVisualStyleBackColor = true;
            // 
            // bdgmain002
            // 
            this.bdgmain002.BorderColor = System.Drawing.Color.Black;
            this.bdgmain002.Location = new System.Drawing.Point(6, 157);
            this.bdgmain002.Name = "bdgmain002";
            this.bdgmain002.Size = new System.Drawing.Size(1860, 327);
            this.bdgmain002.TabIndex = 1;
            this.bdgmain002.TabStop = false;
            this.bdgmain002.Text = "手動設定參數";
            // 
            // bdgmain001
            // 
            this.bdgmain001.BorderColor = System.Drawing.Color.Black;
            this.bdgmain001.Controls.Add(this.bttmain002);
            this.bdgmain001.Controls.Add(this.bttmain001);
            this.bdgmain001.Controls.Add(this.comboBox2);
            this.bdgmain001.Controls.Add(this.labmain003);
            this.bdgmain001.Controls.Add(this.comboBox1);
            this.bdgmain001.Controls.Add(this.labmain002);
            this.bdgmain001.Location = new System.Drawing.Point(6, 6);
            this.bdgmain001.Name = "bdgmain001";
            this.bdgmain001.Size = new System.Drawing.Size(1860, 145);
            this.bdgmain001.TabIndex = 0;
            this.bdgmain001.TabStop = false;
            this.bdgmain001.Text = "參數 讀取/寫入";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 28);
            this.comboBox1.TabIndex = 10;
            // 
            // labmain002
            // 
            this.labmain002.AutoSize = true;
            this.labmain002.Location = new System.Drawing.Point(6, 45);
            this.labmain002.Name = "labmain002";
            this.labmain002.Size = new System.Drawing.Size(88, 20);
            this.labmain002.TabIndex = 9;
            this.labmain002.Text = "COM Port:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(478, 41);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(175, 28);
            this.comboBox2.TabIndex = 12;
            // 
            // labmain003
            // 
            this.labmain003.AutoSize = true;
            this.labmain003.Location = new System.Drawing.Point(352, 45);
            this.labmain003.Name = "labmain003";
            this.labmain003.Size = new System.Drawing.Size(88, 20);
            this.labmain003.TabIndex = 11;
            this.labmain003.Text = "COM Port:";
            // 
            // bttmain001
            // 
            this.bttmain001.Location = new System.Drawing.Point(10, 100);
            this.bttmain001.Name = "bttmain001";
            this.bttmain001.Size = new System.Drawing.Size(141, 31);
            this.bttmain001.TabIndex = 13;
            this.bttmain001.Text = "button1";
            this.bttmain001.UseVisualStyleBackColor = true;
            // 
            // bttmain002
            // 
            this.bttmain002.Location = new System.Drawing.Point(192, 100);
            this.bttmain002.Name = "bttmain002";
            this.bttmain002.Size = new System.Drawing.Size(141, 31);
            this.bttmain002.TabIndex = 14;
            this.bttmain002.Text = "button2";
            this.bttmain002.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1012);
            this.Controls.Add(this.tabCmain001);
            this.Controls.Add(this.cmbmain001);
            this.Controls.Add(this.labmain001);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabCmain001.ResumeLayout(false);
            this.tabPmain001.ResumeLayout(false);
            this.bdgmain001.ResumeLayout(false);
            this.bdgmain001.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbmain001;
        private System.Windows.Forms.Label labmain001;
        private System.Windows.Forms.TabControl tabCmain001;
        private System.Windows.Forms.TabPage tabPmain001;
        private System.Windows.Forms.TabPage tabPmain002;
        private UI_Lib.BorderGroupBox bdgmain001;
        private UI_Lib.BorderGroupBox bdgmain002;
        private System.Windows.Forms.Button bttmain002;
        private System.Windows.Forms.Button bttmain001;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label labmain003;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labmain002;
    }
}

