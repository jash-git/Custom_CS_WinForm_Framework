using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System;

namespace UI_Lib
{
    public class ColorCheckBox : CheckBox
    {
        public String m_StrText;
        public ColorCheckBox()
        {
            m_StrText = "";
            base.AutoEllipsis = true;
            base.AutoSize = false;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            //https://www.experts-exchange.com/questions/23074917/C-disable-a-windows-form-button-while-keeping-the-color-of-the-text.html
            
            base.AutoEllipsis = true;
            base.AutoSize = false;

            if (base.Text!="")
            {
                m_StrText = base.Text;
            }

            if (base.Enabled)
            {
                if (base.Text == "")
                {
                    base.Text = m_StrText;
                }
                base.OnPaint(pe);
            }
            else
            {
                // Calling the base class OnPaint
                base.Text = "";
                base.OnPaint(pe);

                    // Drawing the button yoursel. The background is gray
                //--pe.Graphics.FillRectangle(new SolidBrush(Color.LightGray), pe.ClipRectangle);

                    // Draw the line around the button
                //--pe.Graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, base.Width - 1, base.Height - 1);
                
                    // Draw the text in the button in red
                if (base.Checked)//因為無法連打勾的地方都變顏色所以把停用時的狀態分成兩類
                {
                    pe.Graphics.DrawString(m_StrText, base.Font,
                        new SolidBrush(Color.Blue), (base.Width - pe.Graphics.MeasureString(m_StrText, base.Font).Width) / 2 + 8, (base.Height / 2) -
                        (pe.Graphics.MeasureString(m_StrText, base.Font).Height / 2));//+8 是實驗後的數值 at 2017/04/06
                }
                else
                {
                    pe.Graphics.DrawString(m_StrText, base.Font,
                        new SolidBrush(Color.Gray), (base.Width - pe.Graphics.MeasureString(m_StrText, base.Font).Width) / 2 + 8, (base.Height / 2) -
                        (pe.Graphics.MeasureString(m_StrText, base.Font).Height / 2));//+8 是實驗後的數值 at 2017/04/06
                }
            }
        }
    }
}
