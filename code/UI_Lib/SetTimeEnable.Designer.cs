namespace UI_Lib
{
    partial class SetTimeEnable
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
            this.label1 = new System.Windows.Forms.Label();
            this.ckb_enable = new System.Windows.Forms.CheckBox();
            this.txtMin = new JLNumEdit();
            this.txtHrs = new JLNumEdit();
            this.ckb_001 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = ":";
            // 
            // ckb_enable
            // 
            this.ckb_enable.AutoEllipsis = true;
            this.ckb_enable.Location = new System.Drawing.Point(10, 8);
            this.ckb_enable.Name = "ckb_enable";
            this.ckb_enable.Size = new System.Drawing.Size(151, 24);
            this.ckb_enable.TabIndex = 3;
            this.ckb_enable.Text = "checkBox1";
            this.ckb_enable.UseVisualStyleBackColor = true;
            this.ckb_enable.CheckedChanged += new System.EventHandler(this.ckb_enable_CheckedChanged);
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(64, 38);
            this.txtMin.LoopValue = true;
            this.txtMin.MaxValue = 59;
            this.txtMin.MinValue = 0;
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(37, 26);
            this.txtMin.TabIndex = 2;
            this.txtMin.Value = 0;
            // 
            // txtHrs
            // 
            this.txtHrs.Location = new System.Drawing.Point(10, 38);
            this.txtHrs.LoopValue = true;
            this.txtHrs.MaxValue = 23;
            this.txtHrs.MinValue = 0;
            this.txtHrs.Name = "txtHrs";
            this.txtHrs.Size = new System.Drawing.Size(37, 26);
            this.txtHrs.TabIndex = 1;
            this.txtHrs.Value = 0;
            // 
            // ckb_001
            // 
            this.ckb_001.AutoEllipsis = true;
            this.ckb_001.Location = new System.Drawing.Point(107, 40);
            this.ckb_001.Name = "ckb_001";
            this.ckb_001.Size = new System.Drawing.Size(18, 26);
            this.ckb_001.TabIndex = 4;
            this.ckb_001.Text = "reset mode";
            this.ckb_001.UseVisualStyleBackColor = true;
            // 
            // SetTimeEnable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckb_001);
            this.Controls.Add(this.ckb_enable);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtHrs);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SetTimeEnable";
            this.Size = new System.Drawing.Size(171, 72);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private JLNumEdit txtHrs;
        private JLNumEdit txtMin;
        private System.Windows.Forms.CheckBox ckb_enable;
        public System.Windows.Forms.CheckBox ckb_001;
    }
}
