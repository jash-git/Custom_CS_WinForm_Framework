using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UI_Lib
{
    public partial class Grp_ckbtext : UserControl
    {
        public ArrayList m_ALckvtext = new ArrayList();//存放所有子ckbtext元件

        //--
        //add 2017/10/19
        public void ClearUI()
        {
            blnChildsEnabled = false;
            for (int i = 0; i < m_ALckvtext.Count; i++)
            {
                ((ckbtext)m_ALckvtext[i]).StrText = "";
                ((ckbtext)m_ALckvtext[i]).blnUsed = false;
            }
        }

        private int m_intGroupNum;
        [Browsable(true), Category("自訂屬性"), Description("設定是第幾組電梯群組")]
        public int IntGroupNum
        {
            get
            {
                return m_intGroupNum;
            }
            set
            {
                m_intGroupNum = value;
            }
        }
        //--
        
        private String m_StrText;
        [Browsable(true), Category("自訂屬性"), Description("編號區間顯示文字")]
        public String StrText
        {
            get {
                    m_StrText = checkBox1.Text;
                    return m_StrText;
                }
            set {
                    m_StrText = value;
                    checkBox1.Text = m_StrText;
                }
        }
        private bool m_blnChildsEnabled;
        [Browsable(true), Category("自訂屬性"), Description("判斷子元件是否啟用")]
        public bool blnChildsEnabled
        {
            get
            {
                m_blnChildsEnabled = checkBox1.Checked;
                return m_blnChildsEnabled;
            }
            set
            {
                m_blnChildsEnabled = value;
                checkBox1.Checked = m_blnChildsEnabled;
            }
        }
        public Grp_ckbtext()
        {
            InitializeComponent();

            m_ALckvtext.Clear();
            m_ALckvtext.Add(ckbtext1);//存放所有子ckbtext元件
            m_ALckvtext.Add(ckbtext2);//存放所有子ckbtext元件
            m_ALckvtext.Add(ckbtext3);//存放所有子ckbtext元件
            m_ALckvtext.Add(ckbtext4);//存放所有子ckbtext元件
            m_ALckvtext.Add(ckbtext5);//存放所有子ckbtext元件
            m_ALckvtext.Add(ckbtext6);//存放所有子ckbtext元件
            m_ALckvtext.Add(ckbtext7);//存放所有子ckbtext元件
            m_ALckvtext.Add(ckbtext8);//存放所有子ckbtext元件

            for (int i = 0; i < m_ALckvtext.Count; i++)
            {
                ((ckbtext)m_ALckvtext[i]).Enabled = checkBox1.Checked;//((ckbtext)m_ALckvtext[i]).blnUsed = ((CheckBox)sender).Checked;
            }

            //--
            //add 2017/10/19
            ClearUI();
            m_intGroupNum = 0;
            //--
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < m_ALckvtext.Count; i++)
            {
                ((ckbtext)m_ALckvtext[i]).Enabled = ((CheckBox)sender).Checked;//((ckbtext)m_ALckvtext[i]).blnUsed = ((CheckBox)sender).Checked;
                
                //--
                //add 2017/10/19
                if (m_intGroupNum > 0)
                {
                    ((ckbtext)m_ALckvtext[i]).m_FloorNum = (8*m_intGroupNum) + 1 + i;
                }
                else
                {
                    ((ckbtext)m_ALckvtext[i]).m_FloorNum = (int)Math.Pow(8, m_intGroupNum) + i;
                }
                //--


                //--
                //add 2017/10/20
                if (((CheckBox)sender).Checked)
                {
                    ((ckbtext)m_ALckvtext[i]).blnUsed = true;
                }
                //--

            }
        }

        private void ckbtexts_ck_Changed(object sender, EventArgs e)
        {
            /*
            int int_sum=0;
            for (int i = 0; i < m_ALckvtext.Count; i++)
            {
                if (((ckbtext)m_ALckvtext[i]).blnUsed)
                {
                    int_sum++;
                }
            }
            if (int_sum == 8)
            {
                checkBox1.Checked=true;
            }
            if(int_sum ==0)
            {
                checkBox1.Checked = false;
            }
            */ 
        }
    }
}
