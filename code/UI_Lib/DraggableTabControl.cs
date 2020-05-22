﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace UI_Lib
{
    public class DraggableTabControl : System.Windows.Forms.TabControl
    {
        //移用頁籤原始出處: https://www.codeproject.com/Articles/2445/Drag-and-Drop-Tab-Control
        //

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DraggableTabControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            AllowDrop = true;
            // TODO: Add any initialization after the InitForm call

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion

        protected override void OnDragOver(System.Windows.Forms.DragEventArgs e)//拖過
        {
            base.OnDragOver(e);

            Point pt = new Point(e.X, e.Y);//抓出目前座標
            //We need client coordinates.
            pt = PointToClient(pt);//將指定的螢幕點的位置計算為工作區座標 (Client Coordinate)。-public class Control內的成員函數

            //Get the tab we are hovering over.
            TabPage hover_tab = GetTabPageByTab(pt);//從工作區座標計算出被重疊的目的TabPage

            //Make sure we are on a tab.
            if (hover_tab != null)
            {
                //Make sure there is a TabPage being dragged.
                if (e.Data.GetDataPresent(typeof(TabPage)))
                {
                    e.Effect = DragDropEffects.Move;
                    TabPage drag_tab = (TabPage)e.Data.GetData(typeof(TabPage));

                    int item_drag_index = FindIndex(drag_tab);//找出目前TabPage所在位置
                    int drop_location_index = FindIndex(hover_tab);//找出目前被重疊TabPage所在位置

                    //Don't do anything if we are hovering over ourself.
                    if (item_drag_index != drop_location_index)//確定有移動
                    {
                        ArrayList pages = new ArrayList();

                        //Put all tab pages into an array.
                        for (int i = 0; i < TabPages.Count; i++)//把所有不是被拖拉的物件記錄下來
                        {
                            //Except the one we are dragging.
                            if (i != item_drag_index)
                                pages.Add(TabPages[i]);
                        }

                        //Now put the one we are dragging it at the proper location.
                        pages.Insert(drop_location_index, drag_tab);//把是被拖拉的物件指定到目的之位置

                        //Make them all go away for a nanosec.
                        TabPages.Clear();//清空所有內容

                        //Add them all back in.
                        TabPages.AddRange((TabPage[])pages.ToArray(typeof(TabPage)));//重新填入所有頁面

                        //Make sure the drag tab is selected.
                        SelectedTab = drag_tab;//指定目前顯示頁面
                    }
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Point pt = new Point(e.X, e.Y);
            TabPage tp = GetTabPageByTab(pt);//從工作區座標計算出被重疊的目的TabPage

            if (tp != null)
            {
                DoDragDrop(tp, DragDropEffects.All);
            }
        }

        /// <summary>
        /// Finds the TabPage whose tab is contains the given point.
        /// </summary>
        /// <param name="pt">The point (given in client coordinates) to look for a TabPage.</param>
        /// <returns>The TabPage whose tab is at the given point (null if there isn't one).</returns>
        private TabPage GetTabPageByTab(Point pt)
        {
            TabPage tp = null;

            for (int i = 0; i < TabPages.Count; i++)
            {
                if (GetTabRect(i).Contains(pt))
                {
                    tp = TabPages[i];
                    break;
                }
            }

            return tp;
        }

        /// <summary>
        /// Loops over all the TabPages to find the index of the given TabPage.
        /// </summary>
        /// <param name="page">The TabPage we want the index for.</param>
        /// <returns>The index of the given TabPage(-1 if it isn't found.)</returns>
        private int FindIndex(TabPage page)//找出目前TabPage所在位置
        {
            for (int i = 0; i < TabPages.Count; i++)
            {
                if (TabPages[i] == page)
                    return i;
            }

            return -1;
        }
    }
}
