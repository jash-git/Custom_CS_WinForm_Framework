using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UI_Lib
{
    /// <summary>
    /// Summary description for TreeViewMS.
    /// </summary>
    //https://www.codeproject.com/Articles/2756/C%ADTreeView%ADwith%ADmultiple%ADselection7/12
    class TreeViewMS : TriStateTreeView//讓TreeView支援多重選擇(利用 Shift/Ctrl 鍵來達成)
    {
        public ArrayList m_coll;//把TreeViewMS類別內的m_coll變數從protected->public protected ArrayList m_coll;
        protected TreeNode m_lastNode, m_firstNode;

        public TreeViewMS()
        {
            m_coll = new ArrayList();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }


        public ArrayList SelectedNodes
        {
            get
            {
                return m_coll;
            }
            set
            {
                removePaintFromNodes();
                m_coll.Clear();
                m_coll = value;
                paintSelectedNodes();
            }
        }



        // Triggers
        //
        // (overriden method, and base class called to ensure events are triggered)


        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            base.OnBeforeSelect(e);

            bool bControl = (ModifierKeys == Keys.Control);
            bool bShift = (ModifierKeys == Keys.Shift);

            // selecting twice the node while pressing CTRL ?
            if (bShift && m_coll.Contains(e.Node))
            {
                // unselect it (let framework know we don't want selection this time)
                e.Cancel = true;

                // update nodes
                removePaintFromNodes();
                m_coll.Remove(e.Node);
                paintSelectedNodes();
                return;
            }

            m_lastNode = e.Node;
            if (!bShift) m_firstNode = e.Node; // store begin of shift sequence
        }


        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);

            bool bControl = (ModifierKeys == Keys.Control);
            bool bShift = (ModifierKeys == Keys.Shift);

            if (bControl)
            {
                if (!m_coll.Contains(e.Node)) // new node ?
                {
                    m_coll.Add(e.Node);
                }
                else  // not new, remove it from the collection
                {
                    removePaintFromNodes();
                    m_coll.Remove(e.Node);
                }
                paintSelectedNodes();
            }
            else
            {
                // SHIFT is pressed
                if (bShift)
                {
                    Queue myQueue = new Queue();

                    TreeNode uppernode = m_firstNode;
                    TreeNode bottomnode = e.Node;
                    // case 1 : begin and end nodes are parent
                    bool bParent = isParent(m_firstNode, e.Node); // is m_firstNode parent (direct or not) of e.Node
                    if (!bParent)
                    {
                        bParent = isParent(bottomnode, uppernode);
                        if (bParent) // swap nodes
                        {
                            TreeNode t = uppernode;
                            uppernode = bottomnode;
                            bottomnode = t;
                        }
                    }
                    if (bParent)
                    {
                        TreeNode n = bottomnode;
                        try
                        {
                            while (n != uppernode.Parent)
                            {
                                if (!m_coll.Contains(n)) // new node ?
                                    myQueue.Enqueue(n);

                                n = n.Parent;
                            }
                        }
                        catch { }
                    }
                    // case 2 : nor the begin nor the end node are descendant one another
                    else
                    {
                        if ((uppernode.Parent == null && bottomnode.Parent == null) || (uppernode.Parent != null && uppernode.Parent.Nodes.Contains(bottomnode))) // are they siblings ?
                        {
                            int nIndexUpper = uppernode.Index;
                            int nIndexBottom = bottomnode.Index;
                            if (nIndexBottom < nIndexUpper) // reversed?
                            {
                                TreeNode t = uppernode;
                                uppernode = bottomnode;
                                bottomnode = t;
                                nIndexUpper = uppernode.Index;
                                nIndexBottom = bottomnode.Index;
                            }

                            TreeNode n = uppernode;
                            while (nIndexUpper <= nIndexBottom)
                            {
                                if (!m_coll.Contains(n)) // new node ?
                                    myQueue.Enqueue(n);

                                n = n.NextNode;

                                nIndexUpper++;
                            } // end while

                        }
                        else
                        {
                            if (!m_coll.Contains(uppernode)) myQueue.Enqueue(uppernode);
                            if (!m_coll.Contains(bottomnode)) myQueue.Enqueue(bottomnode);
                        }
                    }

                    m_coll.AddRange(myQueue);

                    paintSelectedNodes();
                    m_firstNode = e.Node; // let us chain several SHIFTs if we like it
                } // end if m_bShift
                else
                {
                    // in the case of a simple click, just add this item
                    if (m_coll != null && m_coll.Count > 0)
                    {
                        removePaintFromNodes();
                        m_coll.Clear();
                    }
                    else
                    {
                        m_coll = new ArrayList();//TreeViewMS的m_coll變數新增對應防呆
                    }

                    m_coll.Add(e.Node);

                    paintSelectedNodes();//修正TreeView元件支援shift全選後還要可以支援選擇三態
                }
            }
        }



        // Helpers
        //
        //


        protected bool isParent(TreeNode parentNode, TreeNode childNode)
        {
            if (parentNode == childNode)
                return true;

            TreeNode n = childNode;
            bool bFound = false;
            while (!bFound && n != null)
            {
                n = n.Parent;
                bFound = (n == parentNode);
            }
            return bFound;
        }

        protected void paintSelectedNodes()
        {
            if (m_coll != null)//在2018/09/17 VS2015更新過後編譯不過，因此增加的防呆
            {
                foreach (Tree_Node n in m_coll)
                {
                    n.BackColor = SystemColors.Highlight;
                    n.ForeColor = SystemColors.HighlightText;

                    //---
                    //修正TreeView元件支援shift全選後還要可以支援選擇三態
                    n.Checked = true;
                    KeybordTriState(n);
                    //---修正TreeView元件支援shift全選後還要可以支援選擇三態
                }
            }
        }

        protected void removePaintFromNodes()
        {
            if (m_coll.Count == 0) return;
            try
            {
                //---
                //修正TreeView元件shift全選取消Node元件的文字狀態會是異常狀態	
                /*
                Tree_Node n0 = (Tree_Node)m_coll[0];
                Color back = n0.BackColor;//抓到指定節點顏色後，為何在選取取消後無法恢復原設定值的BUG 2017/07/29 20:44~ Color back = n0.TreeView.BackColor;
                Color fore = n0.ForeColor;//抓到指定節點顏色後，為何在選取取消後無法恢復原設定值的BUG 2017/07/29 20:44~ Color fore = n0.TreeView.ForeColor;
                */
                //---修正TreeView元件shift全選取消Node元件的文字狀態會是異常狀態	

                foreach (Tree_Node n in m_coll)
                {
                    //---
                    //修正TreeView元件shift全選取消Node元件的文字狀態會是異常狀態
                    /*
                    n.BackColor = back;
                    n.ForeColor = fore; 
                    */
                    n.BackColor = Color.FromArgb(224, 224, 224);//單純調整『門區』變成美工建議的 ~ 調整三態TreeView元件沒選擇Node刷的背景色為灰色
                    n.ForeColor = n.m_ColorBackup;
                    //---修正TreeView元件shift全選取消Node元件的文字狀態會是異常狀態

                    //---
                    //修正TreeView元件支援shift全選後還要可以支援選擇三態
                    n.Checked = false;
                    KeybordTriState(n);
                    //---修正TreeView元件支援shift全選後還要可以支援選擇三態
                }
            }
            catch
            {

            }

        }

        //---
        //修正TreeView元件支援shift全選後還要可以支援選擇三態
        public void KeybordTriState(Tree_Node BufNode)
        {
            Stack<TreeNode> stNodes;
            TreeNode tnBuffer;
            bool bMixedState;
            int iIndex;

            tnBuffer = BufNode;												// re-buffer clicked node.

            stNodes = new Stack<TreeNode>(tnBuffer.Nodes.Count);			// create a new stack and
            stNodes.Push(tnBuffer);											// push buffered node first.
            do
            {																// let's pop node from stack,
                tnBuffer = stNodes.Pop();									// inherit buffered node's
                tnBuffer.Checked = BufNode.Checked;							// check state and push
                for (int i = 0; i < tnBuffer.Nodes.Count; i++)				// each child on the stack
                    stNodes.Push(tnBuffer.Nodes[i]);						// until there is no node
            } while (stNodes.Count > 0);									// left.

            bMixedState = false;
            tnBuffer = BufNode;
            while (tnBuffer.Parent != null)
            {																// while we get a parent we
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
        }
        //---修正TreeView元件支援shift全選後還要可以支援選擇三態
    }
}
