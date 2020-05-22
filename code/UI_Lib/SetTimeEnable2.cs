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
    public partial class SetTimeEnable2 : UserControl
    {
        private String m_StrValue1;
        [Browsable(true), Category("自訂屬性"), Description("元件設定的時間值1")]
        /// <summary>
        /// 元件設定的最大值
        /// </summary>
        public String StrValue1
        {
            get { return (m_StrValue1 = String.Format("{0:00}:{1:00}", Convert.ToInt16(txtHrs1.m_TxtValue.Text), Convert.ToInt16(txtMin1.m_TxtValue.Text))); }
            set
            {
                string[] values = value.Split(':');
                txtHrs1.Value = Convert.ToInt32(values[0]);
                txtMin1.Value = Convert.ToInt32(values[1]);
                m_StrValue1 = String.Format("{0:00}:{1:00}", Convert.ToInt16(txtHrs1.m_TxtValue.Text), Convert.ToInt16(txtMin1.m_TxtValue.Text));
                //---
                //修正『設置卡片，取消勾選時段 2 及時段3，儲存後再進入該張卡片。時段 2 及時段3 還是會勾選』BUG
                if ((StrValue2 == StrValue1) && (StrValue1 == "00:00"))
                {
                    m_blnEnable = false;
                    ckb_enable.Checked = m_blnEnable;
                }
                else
                {
                    m_blnEnable = true;
                    ckb_enable.Checked = m_blnEnable;
                }
                //---修正『設置卡片，取消勾選時段 2 及時段3，儲存後再進入該張卡片。時段 2 及時段3 還是會勾選』BUG
            }
        }
        private String m_StrValue2;
        [Browsable(true), Category("自訂屬性"), Description("元件設定的時間值1")]
        /// <summary>
        /// 元件設定的最大值
        /// </summary>
        public String StrValue2
        {
            get { return (m_StrValue2 = String.Format("{0:00}:{1:00}", Convert.ToInt16(txtHrs2.m_TxtValue.Text), Convert.ToInt16(txtMin2.m_TxtValue.Text))); }
            set
            {
                string[] values = value.Split(':');
                txtHrs2.Value = Convert.ToInt32(values[0]);
                txtMin2.Value = Convert.ToInt32(values[1]);
                m_StrValue2 = String.Format("{0:00}:{1:00}", Convert.ToInt16(txtHrs2.m_TxtValue.Text), Convert.ToInt16(txtMin2.m_TxtValue.Text));
                //---
                //修正『設置卡片，取消勾選時段 2 及時段3，儲存後再進入該張卡片。時段 2 及時段3 還是會勾選』BUG
                if ((StrValue2 == StrValue1) && (StrValue1 == "00:00"))
                {
                    m_blnEnable = false;
                    ckb_enable.Checked = m_blnEnable;
                }
                else
                {
                    m_blnEnable = true;
                    ckb_enable.Checked = m_blnEnable;
                }
                //---修正『設置卡片，取消勾選時段 2 及時段3，儲存後再進入該張卡片。時段 2 及時段3 還是會勾選』BUG
            }
        }

        private bool m_blnEnable = false;
        public bool blnEnable
        {
            get { return m_blnEnable; }
            set
            {
                m_blnEnable = value;
                ckb_enable.Checked = m_blnEnable;
            }
        }
        public void SetTxt(String StrTxt)
        {
            ckb_enable.Text = StrTxt;
        }
        public SetTimeEnable2()
        {
            InitializeComponent();
            ckb_enable.Checked = false;
            txtHrs1.Enabled = false;
            txtMin1.Enabled = false;
            m_StrValue1 = "00:00";
            txtHrs2.Enabled = false;
            txtMin2.Enabled = false;
            m_StrValue2 = "00:00";
            m_blnEnable = false;
        }

        private void ckb_enable_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_enable.Checked == true)
            {
                txtHrs1.Enabled = true;
                txtMin1.Enabled = true;
                txtHrs2.Enabled = true;
                txtMin2.Enabled = true;
                m_blnEnable = true;
            }
            else
            {
                txtHrs1.Enabled = false;
                txtMin1.Enabled = false;
                txtHrs2.Enabled = false;
                txtMin2.Enabled = false;
                StrValue2 = StrValue1 = "00:00";//時間元件未啟動一律作清空處理
                m_blnEnable = false;
            }
        }
    }
}
