using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;  

namespace UI_Lib
{
    /*
     有自訂屬性的標準做法
    */
    /*http://www.magicsite.cn/blog/NET/csharp/csharp425672.html*/

    ///   
    /// LineX 画横线控件  
    ///
    public class LineX : System.Windows.Forms.UserControl
    {
        #region 属性定义
        private System.Drawing.Color lineColor;
        private int lineWidth;

        ///
        /// 线的颜色属性  
        ///   
        public System.Drawing.Color LineColor
        {
            set
            {
                this.lineColor = value;
                System.Windows.Forms.PaintEventArgs ep =
                new PaintEventArgs(this.CreateGraphics(),
                this.ClientRectangle);
                this.LineX_Paint(this, ep);
            }
            get { return this.lineColor; }
        }

        ///   
        /// 线的粗细  
        ///   
        public int LineWidth
        {
            set
            {
                this.lineWidth = value;
                System.Windows.Forms.PaintEventArgs ep =
                new PaintEventArgs(this.CreateGraphics(),
                this.ClientRectangle);
                this.LineX_Paint(this, ep);
            }
            get { return this.lineWidth; }
        }
        #endregion

        private System.ComponentModel.Container components = null;

        private bool m_blnDash;
        [Browsable(true), Category("自訂屬性"), Description("設定是否為虛線")]
        public bool blnDash
        {
            set { m_blnDash = value;}
            get { return m_blnDash; }
        }

        private bool m_blnArrow;
        [Browsable(true), Category("自訂屬性"), Description("設定是否有箭頭的線段")]
        public bool blnArrow
        {
            set { m_blnArrow = value; }
            get { return m_blnArrow; }
        }

        ///   
        /// 构造函数初始颜色和线粗细  
        ///   
        public LineX()
        {
            InitializeComponent();
            this.lineColor = this.ForeColor;
            this.lineWidth = 2;
            m_blnDash = false;
            m_blnArrow = false;
        }

        ///
        /// 清理所有正在使用的资源。  
        ///
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

        #region 组件设计器生成的代码
        ///   
        /// 设计器支持所需的方法 - 不要使用代码编辑器   
        /// 修改此方法的内容。  
        ///   
        private void InitializeComponent()
        {
            //   
            // LineX  
            //   
            this.Name = "LineX";
            this.Resize += new System.EventHandler(this.LineX_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LineX_Paint);
        }
        #endregion



        private void LineX_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            Pen myPen = new Pen(this.lineColor);

            myPen.Width = this.lineWidth/2;//為了雙箭頭修改-2017/02/03

            this.Height = this.LineWidth;

            if (m_blnDash == false)//http://www.developer.com/net/csharp/article.php/1436621
            {
                myPen.DashStyle = DashStyle.Solid;
            }
            else
            {
                myPen.DashStyle = DashStyle.Dot;//DashStyle.Dash;
            }

            if (m_blnArrow == false)//http://myericho.blogspot.tw/2014/05/c_2.html
            {
                myPen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
                myPen.EndCap = System.Drawing.Drawing2D.LineCap.Flat;
            }
            else
            {
                myPen.StartCap = LineCap.ArrowAnchor;
                myPen.EndCap = LineCap.ArrowAnchor;
            }

            g.DrawLine(myPen, 0, lineWidth / 2, e.ClipRectangle.Right, lineWidth / 2);//為了雙箭頭修改-2017/02/03

        }
        private void LineX_Resize(object sender, System.EventArgs e)
        {
            this.Height = this.lineWidth;
        }
    } 
 
///   
/// LineY 画竖线控件  
///   
    public class LineY : System.Windows.Forms.UserControl  
    {
	    #region 属性定义  
	    private System.Drawing.Color lineColor;  
	    private int lineWidth;  
	    ///   
	    /// 线的颜色属性  
	    ///
	    public System.Drawing.Color LineColor
	    {  
		    set
		    {  
			    this.lineColor=value;
			    System.Windows.Forms.PaintEventArgs ep = new PaintEventArgs(this.CreateGraphics(),  
			    this.ClientRectangle);  
			    this.LineY_Paint(this,ep);
		    }  
		    get{return this.lineColor;}  
	    }  

	    ///   
	    /// 线的粗细  
	    ///   
	    public int LineWidth  
	    {  
		    set
		    {  
			    this.lineWidth=value;  
			    System.Windows.Forms.PaintEventArgs ep= new PaintEventArgs(this.CreateGraphics(),  
			    this.ClientRectangle);  
			    this.LineY_Paint(this,ep);  
		    }  
		    get{return this.lineWidth;}  
	    }  
	    #endregion  

	    private System.ComponentModel.Container components = null;

        private bool m_blnDash;
        [Browsable(true), Category("自訂屬性"), Description("設定是否為虛線")]
        public bool blnDash
        {
            set { m_blnDash = value; }
            get { return m_blnDash; }
        }

        private bool m_blnArrow;
        [Browsable(true), Category("自訂屬性"), Description("設定是否有箭頭的線段")]
        public bool blnArrow
        {
            set { m_blnArrow = value; }
            get { return m_blnArrow; }
        }

	    ///   
        /// 构造函数初始颜色和线粗细  
        ///   
	    public LineY()  
	    {  
		    InitializeComponent();  
		    this.lineColor=this.ForeColor;  
		    this.lineWidth=2;
            m_blnDash=false;
            m_blnArrow = false;
	    }  

	    ///   
	    /// 清理所有正在使用的资源。  
	    ///   
	    protected override void Dispose( bool disposing )  
	    {  
		    if( disposing )  
		    {
			    if(components != null)  
			    {  
				    components.Dispose();  
			    }
		    }
		    base.Dispose( disposing );  
	    }  
 
	    #region 组件设计器生成的代码  
	    ///   
	    /// 设计器支持所需的方法 - 不要使用代码编辑器   
	    /// 修改此方法的内容。  
	    ///   
	    private void InitializeComponent()  
	    {  
	     //   
	     // LineY  
	     //   
	     this.Name = "LineY";  
	     this.Resize += new System.EventHandler(this.LineY_Resize);  
	     this.Paint += new System.Windows.Forms.PaintEventHandler(this.LineY_Paint);  
	    }  
	    #endregion  

	    private void LineY_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
	    {  
		    Graphics g=e.Graphics;  
		    Pen myPen = new Pen(this.lineColor);
            myPen.Width = this.lineWidth / 2;//為了雙箭頭修改-2017/02/03 
		    this.Width=this.LineWidth;

            if (m_blnDash == false)//http://www.developer.com/net/csharp/article.php/1436621
            {
                myPen.DashStyle = DashStyle.Solid;
            }
            else
            {
                myPen.DashStyle = DashStyle.Dot;//DashStyle.Dash;
            }

            if (m_blnArrow == false)//http://myericho.blogspot.tw/2014/05/c_2.html
            {
                myPen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
                myPen.EndCap = System.Drawing.Drawing2D.LineCap.Flat;
            }
            else
            {
                myPen.StartCap = LineCap.ArrowAnchor;
                myPen.EndCap = LineCap.ArrowAnchor;
            }

            g.DrawLine(myPen, lineWidth / 2, 0, lineWidth / 2, e.ClipRectangle.Bottom);//為了雙箭頭修改-2017/02/03 
	    }  
	    private void LineY_Resize(object sender, System.EventArgs e)  
	    {  
		    this.Width=lineWidth;
	    }  
    }
}
