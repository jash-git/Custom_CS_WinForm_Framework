using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace UI_Lib
{
    /*
    public class JLButton
    {
        static public Color oldColor;
        static public void Object_MouseHover(RoundPanel rp, PictureBox pb, Label la, Label lb)
        {
            Graphics g = Graphics.FromHwnd(rp.Handle);
            Rectangle r = new Rectangle();
            r.Width = rp.Width;
            r.Height = rp.Height;
            Draw(r, g, 35, false, System.Drawing.SystemColors.ActiveCaption, System.Drawing.SystemColors.ActiveCaption);//35要配合元件的角度做修改

            oldColor = pb.BackColor;
            pb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            la.BackColor = System.Drawing.SystemColors.ActiveCaption;
            lb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            Cursor.Current = Cursors.Hand;//變換滑鼠
        }
        static public void Object_MouseLeave(RoundPanel rp, PictureBox pb, Label la, Label lb)
        {
            rp.BorderColor = Color.Black;
            Graphics g = Graphics.FromHwnd(rp.Handle);
            Rectangle r = new Rectangle();
            r.Width = rp.Width;
            r.Height = rp.Height;
            Draw(r, g, 35, false, System.Drawing.SystemColors.ButtonFace, System.Drawing.SystemColors.ButtonFace);//35要配合元件的角度做修改

            pb.BackColor = oldColor;
            la.BackColor = oldColor;
            lb.BackColor = oldColor;
            Cursor.Current = Cursors.Default;//換回滑鼠游標
        }
        static public void Draw(Rectangle rectangle, Graphics g, int _radius, bool cusp, Color begin_color, Color end_color)
        {
            int span = 2;
            //抗锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //渐变填充
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush(rectangle, begin_color, end_color, LinearGradientMode.Vertical);
            //画尖角
            if (cusp)
            {
                span = 10;
                PointF p1 = new PointF(rectangle.Width - 12, rectangle.Y + 10);
                PointF p2 = new PointF(rectangle.Width - 12, rectangle.Y + 30);
                PointF p3 = new PointF(rectangle.Width, rectangle.Y + 20);
                PointF[] ptsArray = { p1, p2, p3 };
                g.FillPolygon(myLinearGradientBrush, ptsArray);
            }
            //填充
            g.FillPath(myLinearGradientBrush, DrawRoundRect(rectangle.X, rectangle.Y, rectangle.Width - span, rectangle.Height - 1, _radius));
        }
        static public GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            //四边圆角
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }
    }
    */ 
}
