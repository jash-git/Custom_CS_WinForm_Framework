using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace UI_Lib
{
    public class BorderGroupBox : GroupBox
    {
        //http://wahahastudynote.blogspot.tw/2013/05/c-groupbox.html
        private Color _BorderColor = Color.Black;
        [Description("設定或取得外框顏色")]

        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; this.Refresh(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {//http://www.programgo.com/article/344319851/;jsessionid=5D37A8C3634BCD42CB54BC67A6EEA810
            e.Graphics.DrawString(Text, Font, Brushes.Black, 10, 1);
            Pen Pen1 = new Pen(_BorderColor);
            Pen1.Width = 1.0F;
            e.Graphics.DrawLine(Pen1, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pen1, e.Graphics.MeasureString(Text, Font).Width + 8, 7, Width - 2, 7);
            e.Graphics.DrawLine(Pen1, 1, 7, 1, Height - 2);
            e.Graphics.DrawLine(Pen1, 1, Height - 2, Width - 2, Height - 2);
            e.Graphics.DrawLine(Pen1, Width - 2, 7, Width - 2, Height - 2);
           /*
            //原本內容-文字的部分也會畫線
            //取得text字型大小
            Size FontSize = TextRenderer.MeasureText(this.Text, 
                                                     this.Font);
            //畫框線
            Rectangle rec = new Rectangle(e.ClipRectangle.Y, 
                                          this.Font.Height / 2, 
                                          e.ClipRectangle.Width - 1, 
                                          e.ClipRectangle.Height - 1 - 
                                          this.Font.Height / 2);
             
            e.Graphics.DrawRectangle(new Pen(BorderColor), rec);
 
            //填滿text的背景
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 
                new Rectangle(6, 0, FontSize.Width, FontSize.Height));
 
            //text
            e.Graphics.DrawString(this.Text, this.Font, 
                new Pen(this.ForeColor).Brush, 6, 0);
           */
        }
    }
}
