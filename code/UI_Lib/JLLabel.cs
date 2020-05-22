using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_Lib
{
    class JLLabel : Label
    {
        public int m_intIndex;
        public JLLabel() : base()
        {
            m_intIndex = 0;
        }
    }
}
