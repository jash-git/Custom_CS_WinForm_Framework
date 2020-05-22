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
    public partial class SetTimeEnable : UserControl
    {
        private String m_StrValue;
        [Browsable(true), Category("自訂屬性"), Description("元件設定的時間值")]
        /// <summary>
        /// 元件設定的最大值
        /// </summary>
        public String StrValue
        {
            get { return (m_StrValue = String.Format("{0:00}:{1:00}", Convert.ToInt16(txtHrs.m_TxtValue.Text), Convert.ToInt16(txtMin.m_TxtValue.Text))); }
            set { 
                    m_StrValue = value;
                    string[] strs = m_StrValue.Split(':');
                    txtHrs.Value=Convert.ToInt32(strs[0], 10);
                    txtMin.Value = Convert.ToInt32(strs[1], 10);
                }
        }
        private bool m_blnEnable = false;
        public bool blnEnable
        {
            get { return m_blnEnable; }
            set { 
                    m_blnEnable = value;
                    ckb_enable.Checked = m_blnEnable;
                }
        }
        public void SetTxt(String StrTxt)
        {
            ckb_enable.Text = StrTxt;
        }
        public SetTimeEnable()
        {
            InitializeComponent();
            ckb_enable.Checked = false;
            txtHrs.Enabled = false;
            txtMin.Enabled = false;
            ckb_001.Enabled = false;
            ckb_001.Checked = false;
            m_StrValue = "00:00";
            m_blnEnable = false;
        }

        private void ckb_enable_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_enable.Checked == true)
            {
                txtHrs.Enabled = true;
                txtMin.Enabled = true;
                ckb_001.Enabled = true;
                m_blnEnable = true;
            }
            else
            {
                txtHrs.Enabled = false;
                txtMin.Enabled = false;
                ckb_001.Enabled = false;
                ckb_001.Checked = false;
                StrValue = "00:00";//時間元件未啟動一律作清空處理
                m_blnEnable = false;
            }
        }
    }
}
