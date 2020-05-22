using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace UI_Lib
{
    /// <summary>
    /// 基于.NET 2.0的Tooltip工具类
    /// </summary>
    /*
    //http://www.jb51.net/article/53324.htm
    private void button1_Click(object sender, EventArgs e)
    {
      button1.ShowTooltip(toolTip, "button1_Click");
    }
    private void listBox1_Click(object sender, EventArgs e)
    {
      listBox1.ShowTooltip(toolTip, "listBox1_Click", 500);
    } 
    */
    public static class TooltipToolV2
    {
        public static bool blnRun = false;//顯示控制器狀態燈號說明Tip
        /// <summary>
        /// 为控件提供Tooltip
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="tip">ToolTip</param>
        /// <param name="message">提示消息</param>
        public static void ShowTooltip(this Control control, ToolTip tip, string message)
        {
            Point _mousePoint = Control.MousePosition;
            int _x = control.PointToClient(_mousePoint).X;
            int _y = control.PointToClient(_mousePoint).Y;
            tip.Show(message, control, _x, _y);
            tip.Active = true;
        }
        /// <summary>
        /// 为控件提供Tooltip
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="tip">ToolTip</param>
        /// <param name="message">提示消息</param>
        /// <param name="durationTime">保持提示的持续时间</param>
        public static void ShowTooltip(this Control control, ToolTip tip, string message, int durationTime)
        {
            Point _mousePoint = Control.MousePosition;
            int _x = control.PointToClient(_mousePoint).X;
            int _y = control.PointToClient(_mousePoint).Y;
            tip.Show(message, control, _x, _y, durationTime);
            tip.Active = true;
        }
        /// <summary>
        /// 为控件提供Tooltip
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="tip">ToolTip</param>
        /// <param name="message">提示消息</param>
        /// <param name="xoffset">水平偏移量</param>
        /// <param name="yoffset">垂直偏移量</param>
        public static void ShowTooltip(this Control control, ToolTip tip, string message, int xoffset, int yoffset)
        {
            Point _mousePoint = Control.MousePosition;
            int _x = control.PointToClient(_mousePoint).X;
            int _y = control.PointToClient(_mousePoint).Y;
            tip.Show(message, control, _x + xoffset, _y + yoffset);
            tip.Active = true;
            blnRun = true;//顯示控制器狀態燈號說明Tip
        }
        /// <summary>
        /// 为控件提供Tooltip
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="tip">ToolTip</param>
        /// <param name="message">提示消息</param>
        /// <param name="xoffset">水平偏移量</param>
        /// <param name="yoffset">垂直偏移量</param>
        /// <param name="durationTime">保持提示的持续时间</param>
        public static void ShowTooltip(this Control control, ToolTip tip, string message, int xoffset, int yoffset, int durationTime)
        {
            Point _mousePoint = Control.MousePosition;
            int _x = control.PointToClient(_mousePoint).X;
            int _y = control.PointToClient(_mousePoint).Y;
            tip.Show(message, control, _x + xoffset, _y + yoffset, durationTime);
            tip.Active = true;
        }
    }
}
