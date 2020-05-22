using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace UI_Lib
{
    public class JLNumEdit : Panel
    {
        public Button m_butUp;
        public Button m_butDown;
        public TextBox m_TxtValue;
		
		private bool m_blnLoopValue=false;
        [Browsable(true), Category("自訂屬性"), Description("數值循環設定")]
        /// <summary>
        /// 數值循環設定
        /// </summary>
        ///        
		public bool LoopValue
		{
            get { return m_blnLoopValue; }
            set { m_blnLoopValue = value; }
		}
        private int m_intValue;
        [Browsable(true), Category("自訂屬性"), Description("元件的目前值")]
        /// <summary>
        /// 元件的目前值
        /// </summary>
        /// 
        public int Value
        {
            get { return m_intValue; }
            set { m_intValue = value; m_TxtValue.Text = String.Format("{0:00}", m_intValue); }
        }
        private int m_intMaxValue=4;
        [Browsable(true), Category("自訂屬性"), Description("元件設定的最大值")]
        /// <summary>
        /// 元件設定的最大值
        /// </summary>
        public int MaxValue
        {
            get { return m_intMaxValue; }
            set { m_intMaxValue = value; }
        }

        private int m_intMinValue=1;
        [Browsable(true), Category("自訂屬性"), Description("元件設定的最小值")]
        /// <summary>
        /// 元件設定的最小值
        /// </summary>
        public int MinValue
        {
            get { return m_intMinValue; }
            set { m_intMinValue = value; }
        }

        public JLNumEdit(): base()
        {
            Size = new Size(37, 26);//設定元件大小 50,26
            //m_intValue = m_intMinValue;

            m_TxtValue = new TextBox();
            m_TxtValue.Size = new Size(25, 26);
            m_TxtValue.Multiline = true;
            m_TxtValue.Location = new Point(0, 0);
            //m_TxtValue.ReadOnly = true;
            m_TxtValue.BorderStyle = BorderStyle.FixedSingle;
            m_TxtValue.Text = String.Format("{0:00}", m_intValue); //"" + m_intValue;
            m_TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            m_TxtValue.TextChanged += new System.EventHandler(txt_TextChanged);
            m_TxtValue.KeyPress += new KeyPressEventHandler(txt_KeyPress);//允許修改而新增的事件 at 2017/07/27 21:54
            m_TxtValue.KeyUp += new KeyEventHandler(this.txt_KeyUp);//允許修改而新增的事件 at 2017/07/27 21:54
            m_TxtValue.Leave += new System.EventHandler(this.txt_Leave);//修改期間不用應補成兩位數 at 2017/10/17
            Controls.Add(m_TxtValue);

            m_butUp = new Button();
            m_butUp.Text = "▲";
            m_butUp.Font = new System.Drawing.Font("新細明體", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));//---->2017/01/25-從微軟正黑體改成新細明體，4->9
            m_butUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            m_butUp.Size = new Size(12, 13);
            m_butUp.Location = new Point(25, 0);
            m_butUp.Click += Up_Click;
            Controls.Add(m_butUp);

            m_butDown = new Button();
            m_butDown.Text = "▼";
            m_butDown.Font = new System.Drawing.Font("新細明體", 4, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));//---->2017/01/25-從微軟正黑體改成新細明體
            m_butDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            m_butDown.Size = new Size(12, 13);
            m_butDown.Location = new Point(25, 13);
            m_butDown.Click += Down_Click;
            Controls.Add(m_butDown);

        }

        private void txt_Leave(object sender, EventArgs e)
        {
            m_TxtValue.Text = String.Format("{0:00}", m_intValue);//修改期間不用應補成兩位數 at 2017/10/17
        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 8)//刪除鍵要直接允許
            {
                return;
            }
            int temp = 0;
            try
            {
                temp = Convert.ToInt32(m_TxtValue.Text);
            }
            catch
            {
                temp = m_intMinValue;
            }

            if (m_intMaxValue >= temp && m_intMinValue <= temp)
            {
                m_intValue = temp;
                //修改期間不用應補成兩位數，所以把該行停用，並將該行程式移置 txt_Leave 事件中 at 2017/10/17~ m_TxtValue.Text = String.Format("{0:00}", m_intValue);
            }
            else if (m_intMaxValue < temp)
            {
                m_TxtValue.Text = String.Format("{0:00}", m_intMaxValue); //"" + m_intMaxValue;
                m_intValue = m_intMaxValue;
            }
            else
            {
                m_TxtValue.Text = String.Format("{0:00}", m_intMinValue); //""" + m_intMinValue;
                m_intValue = m_intMinValue;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)//刪除鍵要直接允許
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9')//限制0~9和A~F
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        public event EventHandler Value_Changed;//20170209 將內部事件轉傳
        private void txt_TextChanged(object sender, EventArgs e)
        {
            //正規作法 把內部事件轉到表單事件 2017/01/13
            if (Value_Changed != null)
            {
                Value_Changed(m_TxtValue, e);
                return;
            }
        }

        public event EventHandler Button_Click;//20170720 new
        private void Up_Click(object sender, EventArgs e)
        {
            m_intValue++;
            if (m_intMaxValue >= m_intValue)
            {
                m_TxtValue.Text = String.Format("{0:00}", m_intValue); //"" + m_intValue;
            }
            else
            {
				if(m_blnLoopValue==false)
				{
                    m_TxtValue.Text = String.Format("{0:00}", m_intMaxValue); //"" + m_intMaxValue;
					m_intValue = m_intMaxValue;					
				}
				else
				{
                    m_TxtValue.Text = String.Format("{0:00}", m_intMinValue);//"" + m_intMinValue;//產生循環
					m_intValue = m_intMinValue;//產生循環					
				}
            }

            //--
            //20170720 new
            if (Button_Click != null)
            {
                Button_Click(m_TxtValue, e);
            }
            //--

        }

        private void Down_Click(object sender, EventArgs e)
        {
            m_intValue--;
            if (m_intMinValue <= m_intValue)
            {
                m_TxtValue.Text = String.Format("{0:00}", m_intValue); //"" + m_intValue;
            }
            else
            {
				if(m_blnLoopValue==false)
				{
                    m_TxtValue.Text = String.Format("{0:00}", m_intMinValue); //""" + m_intMinValue;
					m_intValue = m_intMinValue;				
				}
				else
				{
                    m_TxtValue.Text = String.Format("{0:00}", m_intMaxValue); //"" + m_intMaxValue;//產生循環
					m_intValue = m_intMaxValue;//產生循環					
				}				
            }

            //--
            //20170720 new
            if (Button_Click != null)
            {
                Button_Click(m_TxtValue, e);
            }
            //--

        }
    }
}
