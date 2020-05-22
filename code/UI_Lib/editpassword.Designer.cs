namespace UI_Lib
{
    partial class editpassword
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editpassword));
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.viewpassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewpassword)).BeginInit();
            this.SuspendLayout();
            // 
            // txtpassword
            // 
            this.txtpassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpassword.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtpassword.Location = new System.Drawing.Point(5, 5);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(225, 29);
            this.txtpassword.TabIndex = 0;
            this.txtpassword.TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // viewpassword
            // 
            this.viewpassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewpassword.Image = ((System.Drawing.Image)(resources.GetObject("viewpassword.Image")));
            this.viewpassword.Location = new System.Drawing.Point(240, 7);
            this.viewpassword.Margin = new System.Windows.Forms.Padding(5);
            this.viewpassword.Name = "viewpassword";
            this.viewpassword.Size = new System.Drawing.Size(42, 24);
            this.viewpassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.viewpassword.TabIndex = 1;
            this.viewpassword.TabStop = false;
            this.viewpassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewpassword_MouseDown);
            this.viewpassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.viewpassword_MouseUp);
            // 
            // editpassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewpassword);
            this.Controls.Add(this.txtpassword);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "editpassword";
            this.Size = new System.Drawing.Size(293, 41);
            ((System.ComponentModel.ISupportInitialize)(this.viewpassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.PictureBox viewpassword;
    }
}
