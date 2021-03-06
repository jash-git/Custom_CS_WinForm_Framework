﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace UI_Lib
{
    class PromptTextBox : TextBox
    {
        //資料來源:https://dotblogs.com.tw/sam319/2010/01/19/13106
        private string _tipText = string.Empty; //提示訊息
        public string TipText
        {
            get { return _tipText; }
            set { _tipText = value; Invalidate(); }
        }

        private Color _tipColor = SystemColors.Highlight; //訊息顏色
        public Color TipColor
        {
            get { return _tipColor; }
            set { _tipColor = value; Invalidate(); }
        }

        private Font _tipFont = DefaultFont; //訊息字型
        public Font TipFont
        {
            get { return _tipFont; }
            set { _tipFont = value; Invalidate(); }
        }

        const int WM_PAINT = 0xF; //繪製的訊息

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT && !string.IsNullOrEmpty(_tipText) && Text.Length == 0 && Enabled && !ReadOnly && !Focused) //判斷TextBox的狀態決定要不要顯示提示訊息
            {
                TextFormatFlags formatFlags = TextFormatFlags.Default; //使用原始設定的對齊方式來顯示提示訊息

                switch (TextAlign)
                {
                    case HorizontalAlignment.Center:
                        formatFlags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Left:
                        formatFlags = TextFormatFlags.Left;
                        break;
                    case HorizontalAlignment.Right:
                        formatFlags = TextFormatFlags.Right;
                        break;
                }

                TextRenderer.DrawText(Graphics.FromHwnd(Handle), _tipText, _tipFont, ClientRectangle, _tipColor, BackColor, formatFlags); //畫出提示訊息
            }
        }
    }
}
