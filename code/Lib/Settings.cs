using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SetCPUCardParameter
{
    public class Settings
    {
        public String m_StrLanguage;
        public String m_StrRandomStart;
        public Settings()
        {
            Random R = new Random();
            m_StrLanguage = "1";
            m_StrRandomStart = ""+ R.Next(0, 65535);
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SYRIS-RD300-C1.xml"))
            {
                readSettingXML();
            }
            else
            {
                saveSettingXML();
            }
        }
        public void saveSettingXML()
        {
            XmlTextWriter XTW = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SetCPUCardParameter.xml", Encoding.UTF8);

            XTW.WriteStartDocument();

            XTW.WriteStartElement("Setting");

            XTW.WriteElementString("Language", m_StrLanguage);
            XTW.WriteElementString("RandomStart", m_StrRandomStart);
            XTW.Flush();
            XTW.Close();
        }
        public void readSettingXML()
        {
            try
            {
                XmlDocument xd = new XmlDocument();

                xd.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SetCPUCardParameter.xml");

                XmlNode root = xd.SelectSingleNode("//Setting");
                int i = 0;
                foreach (XmlElement elm in root.ChildNodes)
                {
                    switch (i)
                    {
                        case 0://Language
                            m_StrLanguage = elm.InnerText.Trim();
                            break;
                        case 1://RandomStart
                            m_StrRandomStart = elm.InnerText.Trim();
                            break;
                    }
                    i++;
                }
            }
            catch
            {
                Random R = new Random();
                m_StrLanguage = "1";
                m_StrRandomStart = "" + R.Next(0,65535);
            }
        }
    }
}
