#region Copyright ?2010 ViCon GmbH / Sebastian Grote. All Rights Reserved.
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace UI_Lib
{
    /// <summary>
    /// Provides a tree view(提供樹形視圖)
    /// control supporting
    /// tri-state checkboxes.(三態復選框)
    /// </summary>
    //https://www.codeproject.com/Articles/59514/Simple-Tri-State-TreeView
    public class TriStateTreeView : TreeView//把內建 Checkbox 變成三態
    {

        // ~~~ fields(member) ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public ImageList _ilStateImages;//狀態圖
        public bool _bUseTriState;//紀錄是否使用三種狀態模式
        public bool _bCheckBoxesVisible;//紀錄是否顯示復選框
        public bool _bPreventCheckEvent;//紀錄是否要記錄上層選擇事件

        // ~~~ constructor(建構子) ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Creates a new instance
        /// of this control.
        /// </summary>
        public TriStateTreeView()
            : base()
        {
            CheckBoxState cbsState;//建立常數陣列
            Graphics gfxCheckBox;//建立顯示圖片元件
            Bitmap bmpCheckBox;//建立繪圖空間

            _ilStateImages = new ImageList();//建立圖片儲存List實體						// first we create our state image
            cbsState = CheckBoxState.UncheckedNormal;//將預設狀態設定成未選取			// list and pre-init check state.

            for (int i = 0; i <= 2; i++)
            {												// let's iterate each tri-state
                bmpCheckBox = new Bitmap(16, 16);//建立繪圖空間實體						// creating a new checkbox bitmap
                gfxCheckBox = Graphics.FromImage(bmpCheckBox);//抓取繪圖空間指標		// and getting graphics object from
                switch (i)
                {															// it...
                    case 0: cbsState = CheckBoxState.UncheckedNormal; break;
                    case 1: cbsState = CheckBoxState.CheckedNormal; break;
                    case 2: cbsState = CheckBoxState.MixedNormal; break;
                }
                CheckBoxRenderer.DrawCheckBox(gfxCheckBox, new Point(2, 2), cbsState);	// 把對應的圖填到繪圖空間中...rendering the checkbox and...
                gfxCheckBox.Save();//把圖片儲存起來
                _ilStateImages.Images.Add(bmpCheckBox);//將圖片存到儲存List實體中     	// ...adding to sate image list.

                _bUseTriState = true;//設定啟用三態功能
            }
        }

        // ~~~ properties(屬性 成員) ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Gets or sets to display
        /// checkboxes in the tree
        /// view.
        /// </summary>
        [Category("Appearance")]
        [Description("Sets tree view to display checkboxes or not.")]
        [DefaultValue(false)]
        public new bool CheckBoxes//紀錄目前選取狀態，CheckBoxes=屬性 成員名稱
        {
            get { return _bCheckBoxesVisible; }
            set
            {
                _bCheckBoxesVisible = value;//實體變數
                base.CheckBoxes = _bCheckBoxesVisible;
                this.StateImageList = _bCheckBoxesVisible ? _ilStateImages : null;//指定三態圖示
            }
        }

        [Browsable(false)]
        public new ImageList StateImageList
        {
            get { return base.StateImageList; }
            set { base.StateImageList = value; }
        }

        /// <summary>
        /// Gets or sets to support
        /// tri-state in the checkboxes
        /// or not.
        /// </summary>
        [Category("Appearance")]
        [Description("Sets tree view to use tri-state checkboxes or not.")]
        [DefaultValue(true)]
        public bool CheckBoxesTriState//三態啟用與否屬性
        {
            get { return _bUseTriState; }
            set { _bUseTriState = value; }
        }

        // ~~~ functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /*
        C++
        Override(覆蓋)：是指派生類函數覆蓋基類函數，特徵是：
        （1）不同的範圍（分別位於派生類與基類）；
        （2）函數名字相同；
        （3）參數相同；
        （4）基類函數必須有virtual 關鍵字。
        ps.當子物件強制轉換成父類型時，會呼叫子類別功能，因為已經被覆蓋
        */
        /// <summary>
        /// Refreshes this
        /// control.
        /// </summary>
        public override void Refresh()//刷新
        {
            Stack<TreeNode> stNodes;
            TreeNode tnStacked;

            base.Refresh();//呼叫父類別的成員做完原本該做的

            if (!CheckBoxes)												//如果沒有啟用複選框，就不用繼續執行// nothing to do here if
                return;														// checkboxes are hidden.

            base.CheckBoxes = false;										// hide normal checkboxes...

            stNodes = new Stack<TreeNode>(this.Nodes.Count);				// create a new stack and
            foreach (TreeNode tnCurrent in this.Nodes)						// push each root node.
                stNodes.Push(tnCurrent);

            while (stNodes.Count > 0)
            {										                        // let's pop node from stack,
                tnStacked = stNodes.Pop();									// set correct state image
                if (tnStacked.StateImageIndex == -1)						// index if not already done
                    tnStacked.StateImageIndex = tnStacked.Checked ? 1 : 0;	// and push each child to stack
                for (int i = 0; i < tnStacked.Nodes.Count; i++)				// too until there are no
                    stNodes.Push(tnStacked.Nodes[i]);						// nodes left on stack.
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)//在顯示時
        {
            base.OnLayout(levent);

            Refresh();
        }

        protected override void OnAfterExpand(TreeViewEventArgs e)//展開
        {
            base.OnAfterExpand(e);

            foreach (TreeNode tnCurrent in e.Node.Nodes)					// set tree state image
                if (tnCurrent.StateImageIndex == -1)						// to each child node...
                    tnCurrent.StateImageIndex = tnCurrent.Checked ? 1 : 0;   
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)//選取事件
        {
            base.OnAfterCheck(e);
            
            if (_bPreventCheckEvent)
                return;
            
            OnNodeMouseClick(new TreeNodeMouseClickEventArgs(e.Node, MouseButtons.None, 0, 0, 0));
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            Stack<TreeNode> stNodes;
            TreeNode tnBuffer;
            bool bMixedState;
            int iSpacing;
            int iIndex;

            base.OnNodeMouseClick(e);

            _bPreventCheckEvent = true;

            iSpacing = ImageList == null ? 0 : 18;							// if user clicked area
            if ((e.X > e.Node.Bounds.Left - iSpacing ||						// *not* used by the state
                 e.X < e.Node.Bounds.Left - (iSpacing + 16)) &&				// image we can leave here.
                 e.Button != MouseButtons.None)
            { return; }

            tnBuffer = e.Node;												// buffer clicked node and
            if (e.Button == MouseButtons.Left)								// flip its check state.
                tnBuffer.Checked = !tnBuffer.Checked;

            tnBuffer.StateImageIndex = tnBuffer.Checked ?					// set state image index
                                        1 : tnBuffer.StateImageIndex;		// correctly.

            OnAfterCheck(new TreeViewEventArgs(tnBuffer, TreeViewAction.ByMouse));

            stNodes = new Stack<TreeNode>(tnBuffer.Nodes.Count);			// create a new stack and
            stNodes.Push(tnBuffer);											// push buffered node first.
            do
            {															// let's pop node from stack,
                tnBuffer = stNodes.Pop();									// inherit buffered node's
                tnBuffer.Checked = e.Node.Checked;							// check state and push
                for (int i = 0; i < tnBuffer.Nodes.Count; i++)				// each child on the stack
                    stNodes.Push(tnBuffer.Nodes[i]);						// until there is no node
            } while (stNodes.Count > 0);									// left.

            bMixedState = false;
            tnBuffer = e.Node;												// re-buffer clicked node.
            while (tnBuffer.Parent != null)
            {								// while we get a parent we
                foreach (TreeNode tnChild in tnBuffer.Parent.Nodes)			// determine mixed check states
                    bMixedState |= (tnChild.Checked != tnBuffer.Checked |	// and convert current check
                                    tnChild.StateImageIndex == 2);			// state to state image index.
                iIndex = (int)Convert.ToUInt32(tnBuffer.Checked);			// set parent's check state and
                tnBuffer.Parent.Checked = bMixedState || (iIndex > 0);		// state image in dependency
                if (bMixedState)											// of mixed state.
                    tnBuffer.Parent.StateImageIndex = CheckBoxesTriState ? 2 : 1;
                else
                    tnBuffer.Parent.StateImageIndex = iIndex;
                tnBuffer = tnBuffer.Parent;									// finally buffer parent and
            }																// loop here.

            _bPreventCheckEvent = false;
        }
    }

}
