using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//https://www.codeproject.com/Articles/5967/ComboBoxTree

namespace UI_Lib
{
    public delegate void NodeSelectEventHandler();
    /// <summary>
    /// ComboBoxTree control is a treeview that drops down much like a combobox
    /// </summary>
    class ComboBoxTreeView : UserControl
	{
        #region Private Fields
        public bool m_blnSowToggleTreeView;//jash add
        private Panel pnlBack;
		private Panel pnlTree;
		private TextBox tbSelectedValue;
		private ButtonEx btnSelect;
        public TreeView tvTreeView;//2018/08/02 自己破壞他原本結構因為這樣比較好寫 private TreeView tvTreeView;
		private LabelEx lblSizingGrip;
		private Form frmTreeView;

		private string _branchSeparator;
		private bool _absoluteChildrenSelectableOnly;
		private System.Drawing.Point DragOffset;
		#endregion
		#region Public Properties
		[Browsable(true), Description("Gets the TreeView Nodes collection"), Category("TreeView"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor(typeof(TreeNodeCollection), typeof(TreeNodeCollection))]
		public TreeNodeCollection Nodes 
		{
			get {return this.tvTreeView.Nodes;}
		}

		[Browsable(true), Description("Gets or sets the TreeView's Selected Node"), Category("TreeView")]
		public TreeNode SelectedNode 
		{
			set {
                this.tvTreeView.SelectedNode = value;
                if (this.tvTreeView.SelectedNode != null)
                {
                    this.tbSelectedValue.Text = this.tvTreeView.SelectedNode.Text;//jash add
                }
            }
            get { return this.tvTreeView.SelectedNode;}//jash add
		}	
		
		[Browsable(true), Description("Gets or sets the TreeView's Selected Node"), Category("TreeView")]
		public ImageList Imagelist 
		{
			get {return this.tvTreeView.ImageList;}
			set{this.tvTreeView.ImageList = value;}
		}

        //---
        //jash add 指定Image
        [Browsable(true), Description("Gets or sets the TreeView's ImageIndex"), Category("TreeView")]
        public int ImageIndex
        {
            get { return this.tvTreeView.ImageIndex; }
            set { this.tvTreeView.ImageIndex = value; }
        }

        [Browsable(true), Description("Gets or sets the TreeView's Selected ImageIndex"), Category("TreeView")]
        public int SelectedImageIndex
        {
            get { return this.tvTreeView.SelectedImageIndex; }
            set { this.tvTreeView.SelectedImageIndex = value; }
        }
        //---jash add 指定Image

		[Browsable(true), Description("The text in the ComboBoxTree control"), Category("Appearance")]
		public override string Text
		{
			get {return this.tbSelectedValue.Text;}
			set {this.tbSelectedValue.Text = value;}
		}
		[Browsable(true), Description("Gets or sets the separator for the selected node's value"), Category("Appearance")]
		public string BranchSeparator
		{
			get {return this._branchSeparator;}
			set
			{
				if(value.Length > 0)
					this._branchSeparator = value.Substring(0,1);
			}
		}
		[Browsable(true), Description("Gets or sets the separator for the selected node's value"), Category("Behavior")]
		public bool AbsoluteChildrenSelectableOnly
		{
			get {return this._absoluteChildrenSelectableOnly;}
			set {this._absoluteChildrenSelectableOnly = value;}
		}
		#endregion

        public ComboBoxTreeView() 
		{
			this.InitializeComponent();

            //---
            //jash add Object init
            this.AbsoluteChildrenSelectableOnly = true;
            this.BranchSeparator = ".";
            //---jash add Object init

            // Initializing Controls
            this.m_blnSowToggleTreeView = false;//jash add
            this.pnlBack = new Panel();
			this.pnlBack.BorderStyle = BorderStyle.Fixed3D;
			this.pnlBack.BackColor = Color.White;
			this.pnlBack.AutoScroll = false;
			
			this.tbSelectedValue = new TextBox();
            this.tbSelectedValue.ReadOnly = true;//jash add
            this.tbSelectedValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSelectedValue.TextChanged += new System.EventHandler(this.Data_Changed);//jash add

            this.btnSelect = new ButtonEx();
			this.btnSelect.Click += new EventHandler(ToggleTreeView);
			this.btnSelect.FlatStyle = FlatStyle.Flat;

			this.lblSizingGrip = new LabelEx();
			this.lblSizingGrip.Size = new Size(9,9);
			this.lblSizingGrip.BackColor = Color.Transparent;
			this.lblSizingGrip.Cursor = Cursors.SizeNWSE;
			this.lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
			this.lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

			this.tvTreeView = new TreeView();
			this.tvTreeView.BorderStyle = BorderStyle.None;
            this.tvTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(TreeViewNodeSelect);//jash modified this.tvTreeView.DoubleClick += new EventHandler(TreeViewNodeSelect); //jash modified this.tvTreeView.Click += new EventHandler(TreeViewNodeSelect); //jash modified 
            this.tvTreeView.Location = new Point(0,0);
			this.tvTreeView.LostFocus += new EventHandler(TreeViewLostFocus);
			//this.tvTreeView.Scrollable = false;

			this.frmTreeView = new Form();
			this.frmTreeView.FormBorderStyle = FormBorderStyle.None;
			this.frmTreeView.StartPosition = FormStartPosition.Manual;
			this.frmTreeView.ShowInTaskbar = false;
			this.frmTreeView.BackColor = System.Drawing.SystemColors.Control;

			this.pnlTree = new Panel();
			this.pnlTree.BorderStyle = BorderStyle.FixedSingle;
			this.pnlTree.BackColor = Color.White;
						
			SetStyle(ControlStyles.DoubleBuffer,true);
			SetStyle(ControlStyles.ResizeRedraw,true);

			// Adding Controls to UserControl
			this.pnlTree.Controls.Add(this.lblSizingGrip);
			this.pnlTree.Controls.Add(this.tvTreeView);
			this.frmTreeView.Controls.Add(this.pnlTree);
			this.pnlBack.Controls.AddRange(new Control[]{btnSelect, tbSelectedValue});
			this.Controls.Add(this.pnlBack);
		}

        //---
        //jash 清除所有節點資料
        public void ClearAllNodes()
        {
            this.tvTreeView.Nodes.Clear();
        }
        //---jash 清除所有節點資料

        //---
        //jash 清除預設選擇
        public void ClearSelectNode()
        {
            this.tvTreeView.SelectedNode = null;
        }
        //---jash 清除預設選擇

        //---
        //透過Tree_Node id指定被選擇的TreeNode
        private bool m_blnfind_setNode;
        private void find_setNode(int id, Tree_Node bufNode)
        {
            if (m_blnfind_setNode == false)
            {
                foreach (TreeNode tn_buf in bufNode.Nodes)
                {
                    if (m_blnfind_setNode == false)
                    {
                        Tree_Node tn = (Tree_Node)tn_buf;
                        if(tn.m_id==id)
                        {
                            SelectedNode = tn_buf;
                            m_blnfind_setNode = true;
                            break;
                        }
                        else
                        {
                            if((tn_buf.Nodes.Count > 0))
                            {
                                find_setNode(id, tn);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public void find_setNode(int id)
        {
            m_blnfind_setNode = false;//每次呼叫重新搜尋
            foreach (TreeNode tn_buf in tvTreeView.Nodes)
            {
                Tree_Node tn = (Tree_Node)tn_buf;
                if (m_blnfind_setNode == false)
                {
                    if (tn.m_id == id)
                    {
                        SelectedNode = tn_buf;
                        m_blnfind_setNode = true;
                        break;
                    }
                    else
                    {
                        if (tn.Nodes.Count > 0)
                        {
                            find_setNode(id, tn);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
        //---透過Tree_Node id指定被選擇的TreeNode

        //C#元件事件轉發 jash add
        public event EventHandler Value_Changed;
        private void Data_Changed(object sender, EventArgs e)
        {
            if ((tbSelectedValue.Text.Trim()).Length > 0)
            {
                if (Value_Changed != null)
                {
                    Value_Changed(this, e);
                    return;
                    /*
                    //表單對應程式碼
                    private void comboBoxTree1_Value_Changed(object sender, EventArgs e)
                    {
                        textBox1.Text = comboBoxTree1.Text;
                    } 
                    */
                }
            }
        }
        //---C#元件事件轉發 jash add

        private void RelocateGrip() 
		{
            this.tvTreeView.Height = 200;//jash add 調整預設下拉式選單大小
            this.lblSizingGrip.Top = this.frmTreeView.Height - lblSizingGrip.Height - 1;
			this.lblSizingGrip.Left = this.frmTreeView.Width - lblSizingGrip.Width - 1;
		}

		private void ToggleTreeView(object sender, EventArgs e) 
		{
            if (!m_blnSowToggleTreeView)//jash modified if(!this.frmTreeView.Visible) 
			{
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
				this.frmTreeView.Location = new System.Drawing.Point(CBRect.X, CBRect.Y + this.pnlBack.Height);
                this.tvTreeView.Font = this.tbSelectedValue.Font;//jash add
                this.frmTreeView.Show();
                this.frmTreeView.BringToFront();
			
				this.RelocateGrip();
                //this.tbSelectedValue.Text = "";
                m_blnSowToggleTreeView = true;//jash add
            } 
			else 
			{
				this.frmTreeView.Hide();
                m_blnSowToggleTreeView = false;
            }

            

        }

		public bool ValidateText()
		{
			string ValidatorText = this.Text;
			TreeNodeCollection TNC = this.tvTreeView.Nodes;

			for(int i = 0; i < ValidatorText.Split(this._branchSeparator.ToCharArray()[0]).Length; i++)
			{
				bool NodeFound = false;
				string NodeToFind = ValidatorText.Split(this._branchSeparator.ToCharArray()[0])[i];
				for(int j = 0; j < TNC.Count; j++)
				{
					if(TNC[j].Text == NodeToFind)
					{
						NodeFound = true;
						TNC = TNC[j].Nodes;
						break;
					}
				}

				if(!NodeFound)
					return false;
			}

			return true;
		}

		#region Events
		private void SizingGripMouseMove(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				int TvWidth, TvHeight;
				TvWidth = Cursor.Position.X - this.frmTreeView.Location.X;
				TvWidth = TvWidth + this.DragOffset.X;
				TvHeight = Cursor.Position.Y - this.frmTreeView.Location.Y;
				TvHeight = TvHeight + this.DragOffset.Y;
				
				if(TvWidth < 50)
					TvWidth = 50;
				if(TvHeight < 200)//jash modified 拖拉時預設改變的顯示高度 if(TvHeight < 50)
                    TvHeight = 200;//jash modified 拖拉時預設改變的顯示高度 TvHeight = 50;

                this.frmTreeView.Size = new System.Drawing.Size(TvWidth, TvHeight);
				this.pnlTree.Size = this.frmTreeView.Size;
				this.tvTreeView.Size = new System.Drawing.Size(this.frmTreeView.Size.Width - this.lblSizingGrip.Width, this.frmTreeView.Size.Height - this.lblSizingGrip.Width);;
				RelocateGrip();
			}
		}

		private void SizingGripMouseDown(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				int OffsetX = System.Math.Abs(Cursor.Position.X - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Right);
				int OffsetY = System.Math.Abs(Cursor.Position.Y - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Bottom);

				this.DragOffset = new Point(OffsetX, OffsetY);
			}
		}


		private void TreeViewLostFocus(object sender, EventArgs e)
		{
            if (!this.btnSelect.RectangleToScreen(this.btnSelect.ClientRectangle).Contains(Cursor.Position))
            {
                this.frmTreeView.Hide();
                m_blnSowToggleTreeView = false;
            }
		}

		private void TreeViewNodeSelect(object sender, EventArgs e) 
		{
            //---
            //按照『V8 功能選單』一個一個改-部門 ~ 修正ComboBoxTreeView元件未分類目錄顏色會因為選擇過而錯亂的BUG
            for (int i = 0; i < tvTreeView.Nodes.Count; i++)
            {
                Tree_Node tmp = (Tree_Node)tvTreeView.Nodes[i];
                if ((tmp.Text != this.tvTreeView.SelectedNode.Text))
                {
                    tmp.ForeColor = tmp.m_ColorBackup;
                }
            }
            //---按照『V8 功能選單』一個一個改-部門 ~ 修正ComboBoxTreeView元件未分類目錄顏色會因為選擇過而錯亂的BUG

			if(this._absoluteChildrenSelectableOnly)
			{
                //---
                //jash modified
                /*
				if(this.tvTreeView.SelectedNode.Nodes.Count == 0) 
				{
					tbSelectedValue.Text = this.tvTreeView.SelectedNode.FullPath.Replace(@"\", this._branchSeparator);
					this.ToggleTreeView(sender,null);
				}
                */
                tbSelectedValue.Text = this.tvTreeView.SelectedNode.Text;
                this.ToggleTreeView(sender, null);
                //---jash modified
            }
            else
			{
				tbSelectedValue.Text = this.tvTreeView.SelectedNode.FullPath.Replace(@"\", this._branchSeparator);
				this.ToggleTreeView(sender,null);
			}
		}

		private void InitializeComponent()
		{
			// 
			// ComboBoxTree
			// 
			this.Name = "ComboBoxTree";
			this._absoluteChildrenSelectableOnly = true;
			this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ComboBoxTree_Layout);

		}

		private void ComboBoxTree_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
		{
			this.Height = this.tbSelectedValue.Height + 8;
			this.pnlBack.Size = new Size(this.Width, this.Height - 2);

			this.btnSelect.Size = new Size(16, this.Height - 6);
			this.btnSelect.Location = new Point(this.Width - this.btnSelect.Width - 4, 0);

			this.tbSelectedValue.Location = new Point(2, 2);
			this.tbSelectedValue.Width = this.Width - this.btnSelect.Width - 4;
		
			this.frmTreeView.Size = new Size(this.Width, this.tvTreeView.Height);
			this.pnlTree.Size = this.frmTreeView.Size;
			this.tvTreeView.Width = this.frmTreeView.Width - this.lblSizingGrip.Width;
			this.tvTreeView.Height = this.frmTreeView.Height - this.lblSizingGrip.Width;
			this.RelocateGrip();
		}

		#endregion

		#region LabelEx
		private class LabelEx : Label 
		{
			/// <summary>
			/// 
			/// </summary>
			public LabelEx() 
			{
				this.SetStyle(ControlStyles.UserPaint,true);
				this.SetStyle(ControlStyles.DoubleBuffer,true);
				this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="e"></param>
			protected override void OnPaint(PaintEventArgs e) 
			{
				base.OnPaint(e);
				System.Windows.Forms.ControlPaint.DrawSizeGrip(e.Graphics,System.Drawing.Color.Black, 1, 0, this.Size.Width, this.Size.Height);
			}
		}
		#endregion
		#region ButtonEx
		private class ButtonEx : Button 
		{
			ButtonState state;

			/// <summary>
			/// 
			/// </summary>
			public ButtonEx() 
			{
				this.SetStyle(ControlStyles.UserPaint,true);
				this.SetStyle(ControlStyles.DoubleBuffer,true);
				this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);

			}
			/// <summary>
			/// 
			/// </summary>
			/// <param name="e"></param>
			protected override void OnMouseDown(MouseEventArgs e) 
			{
				state = ButtonState.Pushed;
				base.OnMouseDown(e);
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="e"></param>
			protected override void OnMouseUp(MouseEventArgs e) 
			{
				state = ButtonState.Normal;
				base.OnMouseUp(e);
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="e"></param>
			protected override void OnPaint(PaintEventArgs e) 
			{
				base.OnPaint(e);
				System.Windows.Forms.ControlPaint.DrawComboButton(e.Graphics, 0, 0, this.Width, this.Height, state);
			}
		}
		#endregion
	}
}
