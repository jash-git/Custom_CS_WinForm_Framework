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
        static public Settings m_Settings;

        //---
        //讀取AssemblyInfo.cs內的版本資訊
        private static System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
        private static FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

        private static Assembly assem = Assembly.GetEntryAssembly();
        private static AssemblyName assemName = assem.GetName();
        private static Version ver = assemName.Version;

        private static string version = ver.ToString().Replace(".", "");//程式標題改成『Workstation [for SYDM]- V版號』 - private static string version = ver.ToString().Replace(".", "") + " [" + fvi.FileVersion + "]";
        private static string productVersion = "- V" + version;
        private static string title = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
        //---讀取AssemblyInfo.cs內的版本資訊
        public void setLanguage()
        {
            labmain001.Text = Language.m_Strlabmain001;
            tabPmain001.Text = Language.m_StrtabPmain001; //参数设定
            tabPmain002.Text = Language.m_StrtabPmain002; //设备操作
            bdgmain001.Text = Language.m_Strbdgmain001; //参数 读取/ 写入
            bdgmain002.Text = Language.m_Strbdgmain002; //手动参数修改
            labmain002.Text = Language.m_Strlabmain002; //通讯埠：
            labmain003.Text = Language.m_Strlabmain003; //设备清单：
            bttmain001.Text = Language.m_Strbttmain001; //读取参数
            bttmain002.Text = Language.m_Strbttmain002; //储存参数
        }
        public void Initcmbmain001()
        {
            //---
            //語系選項設定
            System.Object[] ItemLanguage = new System.Object[4];
            ItemLanguage[0] = "繁體中文";
            ItemLanguage[1] = "简体中文";
            ItemLanguage[2] = "English";
            ItemLanguage[3] = "Other";
            cmbmain001.Items.Clear();
            cmbmain001.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbmain001.Items.AddRange(ItemLanguage);
            cmbmain001.SelectedIndex = Int32.Parse(m_Settings.m_StrLanguage);
            //---語系選項設定
        }
        public void InitMainForm()
        {
            this.Text = title;
            m_Settings = new Settings();
            Language.initVar();
            Initcmbmain001();

            SQLite.initSQLiteDatabase();//建立SQLite的DB
        }
    }
}
