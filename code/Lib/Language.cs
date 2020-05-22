using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace SetCPUCardParameter
{
    public class Language
    {

        static public ArrayList ALStrName = new ArrayList();
        static public ArrayList ALStrValue = new ArrayList();

        static public String m_Strlabmain001;//語系設定
        static public String m_StrtabPmain001;//参数设定
        static public String m_StrtabPmain002;//设备操作
        static public String m_Strbdgmain001;// 参数 读取/写入
        static public String m_Strbdgmain002;// 手动参数修改
        static public String m_Strlabmain002;// 通讯埠：
        static public String m_Strlabmain003;// 设备清单：
        static public String m_Strbttmain001;// 读取参数
        static public String m_Strbttmain002;// 储存参数

        static public void initVar()
        {
            ReadLangSet(Int32.Parse(MainForm.m_Settings.m_StrLanguage));
            ALStr2Var();
        }
        static public void ReadLangSet(int index)
        {
            //ALStr.Clear();
            //int i = 0;
            ALStrName.Clear();
            ALStrValue.Clear();
            StreamReader sr = null;
            switch (index)
            {
                case 0:
                    sr = new StreamReader("language\\SetCPUCardParameter_tw.sycsv");//csv->sycsv//修改語系檔放在執行檔目錄下的language資料夾中 at 2017/04/06
                    break;
                case 1:
                    sr = new StreamReader("language\\SetCPUCardParameter_cn.sycsv");//csv->sycsv//修改語系檔放在執行檔目錄下的language資料夾中 at 2017/04/06
                    break;
                case 2:
                    sr = new StreamReader("language\\SetCPUCardParameter_en.sycsv");//csv->sycsv//修改語系檔放在執行檔目錄下的language資料夾中 at 2017/04/06
                    break;
                case 3:
                    sr = new StreamReader("language\\SetCPUCardParameter_other.sycsv");//csv->sycsv//修改語系檔放在執行檔目錄下的language資料夾中 at 2017/04/06
                    break;
            }
            while (!sr.EndOfStream)// 每次讀取一行，直到檔尾
            {
                string line = sr.ReadLine();// 讀取文字到 line 變數
                if (line.Length > 0 && line.IndexOf(',') > 0)
                {
                    //String StrBuf = line.Substring(line.IndexOf(',') + 1);
                    string[] strs = line.Split(',');
                    ALStrName.Add(strs[0]);
                    ALStrValue.Add(strs[1]);
                    //ALStr.Add(StrBuf);
                    //i++;
                }
            }
            sr.Close();// 關閉串流
        }
        static public void ALStr2Var()
        {
            m_Strlabmain001 = (String)ALStrValue[ALStrName.IndexOf("m_Strlabmain001")];//語系設定
            m_StrtabPmain001 = (String)ALStrValue[ALStrName.IndexOf("m_StrtabPmain001")];//参数设定
            m_StrtabPmain002 = (String)ALStrValue[ALStrName.IndexOf("m_StrtabPmain002")];//设备操作
            m_Strbdgmain001 = (String)ALStrValue[ALStrName.IndexOf("m_Strbdgmain001")];//参数 读取/ 写入
            m_Strbdgmain002 = (String)ALStrValue[ALStrName.IndexOf("m_Strbdgmain002")];//手动参数修改
            m_Strlabmain002 = (String)ALStrValue[ALStrName.IndexOf("m_Strlabmain002")];//通讯埠：
            m_Strlabmain003 = (String)ALStrValue[ALStrName.IndexOf("m_Strlabmain003")];//设备清单：
            m_Strbttmain001 = (String)ALStrValue[ALStrName.IndexOf("m_Strbttmain001")];//读取参数
            m_Strbttmain002 = (String)ALStrValue[ALStrName.IndexOf("m_Strbttmain002")];//储存参数
        }
    }//Language
}
