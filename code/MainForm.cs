using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using System.Diagnostics;
using System;

namespace SetCPUCardParameter
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();       
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitMainForm();           
        }

        private void cmbmain001_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Settings.m_StrLanguage = "" + cmbmain001.SelectedIndex;
            Language.ReadLangSet(cmbmain001.SelectedIndex);
            Language.ALStr2Var();
            setLanguage();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_Settings.saveSettingXML();
        }
    }
}
