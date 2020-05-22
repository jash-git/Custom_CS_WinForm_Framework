namespace UI_Lib
{
    partial class SetTimeEnable3
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ckb_enable = new System.Windows.Forms.CheckBox();
            this.txtMin2 = new JLNumEdit();
            this.txtHrs2 = new JLNumEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMin1 = new JLNumEdit();
            this.txtHrs1 = new JLNumEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ckb_enable
            // 
            this.ckb_enable.AutoEllipsis = true;
            this.ckb_enable.Location = new System.Drawing.Point(3, 3);
            this.ckb_enable.Name = "ckb_enable";
            this.ckb_enable.Size = new System.Drawing.Size(107, 24);
            this.ckb_enable.TabIndex = 8;
            this.ckb_enable.Text = "時段 X：";
            this.ckb_enable.UseVisualStyleBackColor = true;
            this.ckb_enable.CheckedChanged += new System.EventHandler(this.ckb_enable_CheckedChanged);
            // 
            // txtMin2
            // 
            this.txtMin2.Location = new System.Drawing.Point(264, 3);
            this.txtMin2.LoopValue = true;
            this.txtMin2.MaxValue = 59;
            this.txtMin2.MinValue = 0;
            this.txtMin2.Name = "txtMin2";
            this.txtMin2.Size = new System.Drawing.Size(40, 26);
            this.txtMin2.TabIndex = 18;
            this.txtMin2.Value = 0;
            // 
            // txtHrs2
            // 
            this.txtHrs2.Location = new System.Drawing.Point(211, 3);
            this.txtHrs2.LoopValue = true;
            this.txtHrs2.MaxValue = 23;
            this.txtHrs2.MinValue = 0;
            this.txtHrs2.Name = "txtHrs2";
            this.txtHrs2.Size = new System.Drawing.Size(40, 26);
            this.txtHrs2.TabIndex = 17;
            this.txtHrs2.Value = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(192, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "~";
            // 
            // txtMin1
            // 
            this.txtMin1.Location = new System.Drawing.Point(155, 3);
            this.txtMin1.LoopValue = true;
            this.txtMin1.MaxValue = 59;
            this.txtMin1.MinValue = 0;
            this.txtMin1.Name = "txtMin1";
            this.txtMin1.Size = new System.Drawing.Size(50, 26);
            this.txtMin1.TabIndex = 14;
            this.txtMin1.Value = 0;
            // 
            // txtHrs1
            // 
            this.txtHrs1.Location = new System.Drawing.Point(100, 3);
            this.txtHrs1.LoopValue = true;
            this.txtHrs1.MaxValue = 23;
            this.txtHrs1.MinValue = 0;
            this.txtHrs1.Name = "txtHrs1";
            this.txtHrs1.Size = new System.Drawing.Size(42, 26);
            this.txtHrs1.TabIndex = 13;
            this.txtHrs1.Value = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(139, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = ":";
            // 
            // SetTimeEnable3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMin2);
            this.Controls.Add(this.txtHrs2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMin1);
            this.Controls.Add(this.txtHrs1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckb_enable);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SetTimeEnable3";
            this.Size = new System.Drawing.Size(309, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckb_enable;
        private JLNumEdit txtMin2;
        private JLNumEdit txtHrs2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private JLNumEdit txtMin1;
        private JLNumEdit txtHrs1;
        private System.Windows.Forms.Label label1;

    }
}
