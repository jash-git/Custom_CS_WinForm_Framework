using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_Lib
{
    
    public partial class ckbtext : UserControl
    {
        public int m_FloorNum;//add 2017/10/19

        private String m_StrText;
        [Browsable(true), Category("自訂屬性"), Description("元件內容值")]
        public String StrText
        {
            get {
                    m_StrText = textBox1.Text;
                    return m_StrText;
                }
            set {
                    m_StrText = value;
                    textBox1.Text = m_StrText;
                }
        }

        private bool m_blnUsed;
        [Browsable(true), Category("自訂屬性"), Description("元件啟用判斷")]
        public bool blnUsed
        {
            get {
                    m_blnUsed = checkBox1.Checked;
                    return m_blnUsed;
                }
            set { 
                    m_blnUsed = value;
                    checkBox1.Checked = m_blnUsed;
                }
        }

        public ckbtext()
        {
            InitializeComponent();
            textBox1.Enabled = checkBox1.Checked;
            m_blnUsed = checkBox1.Checked;
            m_FloorNum = 0;//add 2017/10/19
        }

        public event EventHandler ck_Changed;//20170209 將內部事件轉傳
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //--
            //add 2017/10/19
            if (((CheckBox)sender).Checked)
            {
                if (textBox1.Text == "")
                {
                    textBox1.Text = String.Format("{0:000}F", m_FloorNum);
                }
            }
            else
            {
                textBox1.Text = "";
            }
            //--

            textBox1.Enabled = ((CheckBox)sender).Checked;

            //正規作法 把內部事件轉到表單事件 2017/01/13
            if (ck_Changed != null)
            {
                ck_Changed(checkBox1, e);
                return;
            }
        }

        public event EventHandler Value_Changed;//20170209 將內部事件轉傳
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //正規作法 把內部事件轉到表單事件 2017/01/13
            if (Value_Changed != null)
            {
                Value_Changed(textBox1, e);
                return;
            }
        }
    }
}
