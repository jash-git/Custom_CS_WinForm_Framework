using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
//using MySql.Data.MySqlClient;

namespace UI_Lib
{
    public class Tree_Node : TreeNode//UI元件擴展
    {
        public int m_id;
        public int m_unit;//相依(父親)
        public int m_tree_level;
        public String m_data;
        public Color m_ColorBackup;//修正TreeView元件shift全選取消Node元件的文字狀態會是異常狀態	

        public Tree_Node(int id, string name, int unit, int tree_level,String data="")
        {
            m_id = id;
            this.Text = name;
            m_unit = unit;
            m_tree_level = tree_level;
            m_data = data;
            m_ColorBackup = Color.Black;//修正TreeView元件shift全選取消Node元件的文字狀態會是異常狀態
        }
    }

    //public class SQLAPB_Door2Tree_Node
    //{
    //    /*
    //    //根,[門區]
    //    m_id            ->  id
    //    m_unit          ->  -1
    //    m_tree_level    ->  2
    //    */
    //    public ArrayList m_ALRoot = new ArrayList();//Controller
    //    public SQLAPB_Door2Tree_Node(int DB_id = -10)
    //    {
    //        String SQL = "";
    //        m_ALRoot.Clear();
    //        /*
    //        SQL = String.Format("SELECT a_d.door_id AS id,d.name AS name FROM apb_door AS a_d,door AS d WHERE a_d.door_id=d.id AND a_d.apb_group_id={0} ORDER BY a_d.door_id;", DB_id);
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = String.Format("SELECT a_d.door_id AS id,d.name AS name FROM apb_door AS a_d,door AS d WHERE (a_d.state=1 OR a_d.state=2) AND a_d.door_id=d.id AND a_d.apb_group_id={0} ORDER BY a_d.door_id;", DB_id);

    //        MySqlDataReader Reader_Root = MySQL.GetDataReader(SQL);
    //        while (Reader_Root.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Root["id"].ToString()), Reader_Root["name"].ToString(), -1, 2, "");//id,NAME,父親,階層,資料
    //            m_ALRoot.Add(tmp_Node);
    //        }
    //        Reader_Root.Close();
    //    }
    //}
    //public class SQLAPB_2Tree_Node//把APB區域的資料從DB讀入記憶體
    //{
    //    /*
    //    //根,[區域]
    //    m_id            ->  id
    //    m_unit          ->  -1
    //    m_tree_level    ->  0
    //    */
    //    /*
    //    //子(非根),[區域]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  1
    //    */
    //    /*
    //    //子(非根),[門]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  >2        
    //    */
    //    public ArrayList m_ALRoot = new ArrayList();//Controller
    //    public ArrayList m_ALChild = new ArrayList();//door
    //    public SQLAPB_2Tree_Node(int mode = 0,int DB_id=-1)
    //    {
    //        m_ALRoot.Clear();
    //        m_ALChild.Clear();
    //        String SQL = "";

    //        /*
    //        SQL = "SELECT id,name,unit FROM area WHERE unit=-1 ORDER BY id;";
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT id,name,unit FROM area WHERE unit=-1 AND (state=1 OR state=2) ORDER BY id;";

    //        MySqlDataReader Reader_Root = MySQL.GetDataReader(SQL);
    //        while (Reader_Root.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Root["id"].ToString()), Reader_Root["name"].ToString(), -1, 0, "");//id,NAME,父親,階層,資料
    //            m_ALRoot.Add(tmp_Node);
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Root.Close();

    //        /*
    //        SQL = "SELECT id,name,unit FROM area WHERE unit!=-1 ORDER BY id;";
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT id,name,unit FROM area WHERE unit!=-1 AND (state=1 OR state=2) ORDER BY id;";
    //        MySqlDataReader Reader_Child = MySQL.GetDataReader(SQL);
    //        while (Reader_Child.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Child["id"].ToString()), Reader_Child["name"].ToString(), Int32.Parse(Reader_Child["unit"].ToString()), 1, "");//id,NAME,父親,階層,資料
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child.Close();
            
    //        SQL = "";
    //        switch (mode)
    //        {
    //            case 0://新增~APB門區模式 
    //                //---
    //                //SYCG/SYDM模式下SYDM ID綁定程式
    //                //SQL = "SELECT d.name AS name,d_e.door_id AS id,a_d.area_id AS unit,c_e.apb_mode AS apb_mode FROM door AS d,door_extend AS d_e,controller_extend AS c_e,area_detail AS a_d WHERE d.id=d_e.door_id AND d.controller_id=c_e.controller_sn AND d.id=a_d.door_id AND c_e.apb_enable=1 AND d_e.apb_used=0 AND (d_e.apb_group_id=-1 OR d_e.apb_group_id=-10) AND c_e.apb_mode=1 ORDER BY d_e.door_id;";
    //                //-2018/12/24之前-SQL = "SELECT d.name AS name,d_e.door_id AS id,a_d.area_id AS unit,c_e.apb_mode AS apb_mode FROM door AS d,door_extend AS d_e,controller AS c,controller_extend AS c_e,area_detail AS a_d WHERE d.id=d_e.door_id AND d.controller_id=c_e.controller_sn AND d.id=a_d.door_id AND c_e.apb_enable=1 AND d_e.apb_used=0 AND (d_e.apb_group_id=-1 OR d_e.apb_group_id=-10) AND c_e.apb_mode=1 AND c_e.controller_sn=c.sn AND c.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY d_e.door_id;";
    //                SQL = "SELECT base.name AS name,base.door_id AS id,base.apb_mode AS apb_mode,a_d.area_id AS unit FROM (SELECT * FROM (SELECT d_e.door_id AS door_id,d.name AS name,d_e.apb_group_id AS apb_group_id,d_e.apb_used AS apb_used,d.controller_id AS sn FROM door AS d,door_extend AS d_e WHERE d.id=d_e.door_id) AS d_data,(SELECT c.sydm_id AS sydm_id,c_e.apb_enable AS apb_enable,c_e.apb_mode AS apb_mode,c.sn AS c_sn FROM controller AS c,controller_extend AS c_e WHERE c_e.controller_sn=c.sn) AS c_data WHERE d_data.sn=c_data.c_sn) AS base,area_detail AS a_d WHERE (base.door_id=a_d.door_id) AND base.apb_enable=1 AND base.apb_used=0 AND (base.apb_group_id=-1 OR base.apb_group_id=-10) AND base.apb_mode=1 AND base.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY base.door_id;";//修正調整SQL解決當DOOR數量過多導致APB編輯UI無法使用
    //                //---SYCG/SYDM模式下SYDM ID綁定程式

    //                //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //                SQL = "SELECT base.name AS name,base.door_id AS id,base.apb_mode AS apb_mode,a_d.area_id AS unit FROM (SELECT * FROM (SELECT d_e.door_id AS door_id,d.name AS name,d_e.apb_group_id AS apb_group_id,d_e.apb_used AS apb_used,d.controller_id AS sn FROM door AS d,door_extend AS d_e WHERE (d.state=1 OR d.state=2) AND d.id=d_e.door_id) AS d_data,(SELECT c.sydm_id AS sydm_id,c_e.apb_enable AS apb_enable,c_e.apb_mode AS apb_mode,c.sn AS c_sn FROM controller AS c,controller_extend AS c_e WHERE (c.state=1 OR c.state=2) AND c_e.controller_sn=c.sn) AS c_data WHERE d_data.sn=c_data.c_sn) AS base,area_detail AS a_d WHERE (base.door_id=a_d.door_id) AND base.apb_enable=1 AND base.apb_used=0 AND (base.apb_group_id=-1 OR base.apb_group_id=-10) AND base.apb_mode=1 AND base.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY base.door_id;";//修正調整SQL解決當DOOR數量過多導致APB編輯UI無法使用
    //                break;
    //            case 1://新增~APB次數模式
    //                //---
    //                //SYCG/SYDM模式下SYDM ID綁定程式
    //                //SQL = "SELECT d.name AS name,d_e.door_id AS id,a_d.area_id AS unit,c_e.apb_mode AS apb_mode FROM door AS d,door_extend AS d_e,controller_extend AS c_e,area_detail AS a_d WHERE d.id=d_e.door_id AND d.controller_id=c_e.controller_sn AND d.id=a_d.door_id AND c_e.apb_enable=1 AND d_e.apb_used=0 AND (d_e.apb_group_id=-1 OR d_e.apb_group_id=-10) AND c_e.apb_mode=2 ORDER BY d_e.door_id;";
    //                //-2018/12/24之前-SQL = "SELECT d.name AS name,d_e.door_id AS id,a_d.area_id AS unit,c_e.apb_mode AS apb_mode FROM door AS d,door_extend AS d_e,controller AS c,controller_extend AS c_e,area_detail AS a_d WHERE d.id=d_e.door_id AND d.controller_id=c_e.controller_sn AND d.id=a_d.door_id AND c_e.apb_enable=1 AND d_e.apb_used=0 AND (d_e.apb_group_id=-1 OR d_e.apb_group_id=-10) AND c_e.apb_mode=2 AND c_e.controller_sn=c.sn AND c.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY d_e.door_id;";
    //                SQL = "SELECT base.name AS name,base.door_id AS id,base.apb_mode AS apb_mode,a_d.area_id AS unit FROM (SELECT * FROM (SELECT d_e.door_id AS door_id,d.name AS name,d_e.apb_group_id AS apb_group_id,d_e.apb_used AS apb_used,d.controller_id AS sn FROM door AS d,door_extend AS d_e WHERE d.id=d_e.door_id) AS d_data,(SELECT c.sydm_id AS sydm_id,c_e.apb_enable AS apb_enable,c_e.apb_mode AS apb_mode,c.sn AS c_sn FROM controller AS c,controller_extend AS c_e WHERE c_e.controller_sn=c.sn) AS c_data WHERE d_data.sn=c_data.c_sn) AS base,area_detail AS a_d WHERE (base.door_id=a_d.door_id) AND base.apb_enable=1 AND base.apb_used=0 AND (base.apb_group_id=-1 OR base.apb_group_id=-10) AND base.apb_mode=2 AND base.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY base.door_id;";//修正調整SQL解決當DOOR數量過多導致APB編輯UI無法使用
    //                //---SYCG/SYDM模式下SYDM ID綁定程式

    //                //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //                SQL = "SELECT base.name AS name,base.door_id AS id,base.apb_mode AS apb_mode,a_d.area_id AS unit FROM (SELECT * FROM (SELECT d_e.door_id AS door_id,d.name AS name,d_e.apb_group_id AS apb_group_id,d_e.apb_used AS apb_used,d.controller_id AS sn FROM door AS d,door_extend AS d_e WHERE (d.state=1 OR d.state=2) AND d.id=d_e.door_id) AS d_data,(SELECT c.sydm_id AS sydm_id,c_e.apb_enable AS apb_enable,c_e.apb_mode AS apb_mode,c.sn AS c_sn FROM controller AS c,controller_extend AS c_e WHERE (c.state=1 OR c.state=2) AND c_e.controller_sn=c.sn) AS c_data WHERE d_data.sn=c_data.c_sn) AS base,area_detail AS a_d WHERE (base.door_id=a_d.door_id) AND base.apb_enable=1 AND base.apb_used=0 AND (base.apb_group_id=-1 OR base.apb_group_id=-10) AND base.apb_mode=2 AND base.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY base.door_id;";//修正調整SQL解決當DOOR數量過多導致APB編輯UI無法使用
    //                break;
    //            case 2://編修~APB門區模式 
    //                //---
    //                //SYCG/SYDM模式下SYDM ID綁定程式
    //                //SQL = "SELECT d.name AS name,d_e.door_id AS id,a_d.area_id AS unit,c_e.apb_mode AS apb_mode FROM door AS d,door_extend AS d_e,controller_extend AS c_e,area_detail AS a_d WHERE d.id=d_e.door_id AND d.controller_id=c_e.controller_sn AND d.id=a_d.door_id AND c_e.apb_enable=1 AND d_e.apb_used=0 AND (d_e.apb_group_id=-1 OR d_e.apb_group_id=-10 OR d_e.apb_group_id= " + DB_id + ") AND c_e.apb_mode=1 ORDER BY d_e.door_id;";
    //                //-2018/12/24之前-SQL = "SELECT d.name AS name,d_e.door_id AS id,a_d.area_id AS unit,c_e.apb_mode AS apb_mode FROM door AS d,door_extend AS d_e,controller AS c,controller_extend AS c_e,area_detail AS a_d WHERE d.id=d_e.door_id AND d.controller_id=c_e.controller_sn AND d.id=a_d.door_id AND c_e.apb_enable=1 AND d_e.apb_used=0 AND (d_e.apb_group_id=-1 OR d_e.apb_group_id=-10 OR d_e.apb_group_id= " + DB_id + ") AND c_e.apb_mode=1 AND c_e.controller_sn=c.sn AND c.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY d_e.door_id;";
    //                SQL = "SELECT base.name AS name,base.door_id AS id,base.apb_mode AS apb_mode,a_d.area_id AS unit FROM (SELECT * FROM (SELECT d_e.door_id AS door_id,d.name AS name,d_e.apb_group_id AS apb_group_id,d_e.apb_used AS apb_used,d.controller_id AS sn FROM door AS d,door_extend AS d_e WHERE d.id=d_e.door_id) AS d_data,(SELECT c.sydm_id AS sydm_id,c_e.apb_enable AS apb_enable,c_e.apb_mode AS apb_mode,c.sn AS c_sn FROM controller AS c,controller_extend AS c_e WHERE c_e.controller_sn=c.sn) AS c_data WHERE d_data.sn=c_data.c_sn) AS base,area_detail AS a_d WHERE (base.door_id=a_d.door_id) AND base.apb_enable=1 AND base.apb_used=0 AND (base.apb_group_id=-1 OR base.apb_group_id=-10 OR base.apb_group_id= " + DB_id + ") AND base.apb_mode=1 AND base.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY base.door_id;";//修正調整SQL解決當DOOR數量過多導致APB編輯UI無法使用
    //                //---SYCG/SYDM模式下SYDM ID綁定程式

    //                //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //                SQL = "SELECT base.name AS name,base.door_id AS id,base.apb_mode AS apb_mode,a_d.area_id AS unit FROM (SELECT * FROM (SELECT d_e.door_id AS door_id,d.name AS name,d_e.apb_group_id AS apb_group_id,d_e.apb_used AS apb_used,d.controller_id AS sn FROM door AS d,door_extend AS d_e WHERE (d.state=1 OR d.state=2) AND d.id=d_e.door_id) AS d_data,(SELECT c.sydm_id AS sydm_id,c_e.apb_enable AS apb_enable,c_e.apb_mode AS apb_mode,c.sn AS c_sn FROM controller AS c,controller_extend AS c_e WHERE (c.state=1 OR c.state=2) AND c_e.controller_sn=c.sn) AS c_data WHERE d_data.sn=c_data.c_sn) AS base,area_detail AS a_d WHERE (base.door_id=a_d.door_id) AND base.apb_enable=1 AND base.apb_used=0 AND (base.apb_group_id=-1 OR base.apb_group_id=-10 OR base.apb_group_id= " + DB_id + ") AND base.apb_mode=1 AND base.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY base.door_id;";//修正調整SQL解決當DOOR數量過多導致APB編輯UI無法使用
    //                break;
    //            case 3://編修~APB次數模式
    //                //---
    //                //SYCG/SYDM模式下SYDM ID綁定程式
    //                //SQL = "SELECT d.name AS name,d_e.door_id AS id,a_d.area_id AS unit,c_e.apb_mode AS apb_mode FROM door AS d,door_extend AS d_e,controller_extend AS c_e,area_detail AS a_d WHERE d.id=d_e.door_id AND d.controller_id=c_e.controller_sn AND d.id=a_d.door_id AND c_e.apb_enable=1 AND d_e.apb_used=0 AND (d_e.apb_group_id=-1 OR d_e.apb_group_id=-10 OR d_e.apb_group_id= " + DB_id + ") AND c_e.apb_mode=2 ORDER BY d_e.door_id;";
    //                //-2018/12/24之前-SQL = "SELECT d.name AS name,d_e.door_id AS id,a_d.area_id AS unit,c_e.apb_mode AS apb_mode FROM door AS d,door_extend AS d_e,controller AS c,controller_extend AS c_e,area_detail AS a_d WHERE d.id=d_e.door_id AND d.controller_id=c_e.controller_sn AND d.id=a_d.door_id AND c_e.apb_enable=1 AND d_e.apb_used=0 AND (d_e.apb_group_id=-1 OR d_e.apb_group_id=-10 OR d_e.apb_group_id= " + DB_id + ") AND c_e.apb_mode=2 AND c_e.controller_sn=c.sn AND c.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY d_e.door_id;";
    //                SQL = "SELECT base.name AS name,base.door_id AS id,base.apb_mode AS apb_mode,a_d.area_id AS unit FROM (SELECT * FROM (SELECT d_e.door_id AS door_id,d.name AS name,d_e.apb_group_id AS apb_group_id,d_e.apb_used AS apb_used,d.controller_id AS sn FROM door AS d,door_extend AS d_e WHERE d.id=d_e.door_id) AS d_data,(SELECT c.sydm_id AS sydm_id,c_e.apb_enable AS apb_enable,c_e.apb_mode AS apb_mode,c.sn AS c_sn FROM controller AS c,controller_extend AS c_e WHERE c_e.controller_sn=c.sn) AS c_data WHERE d_data.sn=c_data.c_sn) AS base,area_detail AS a_d WHERE (base.door_id=a_d.door_id) AND base.apb_enable=1 AND base.apb_used=0 AND (base.apb_group_id=-1 OR base.apb_group_id=-10 OR base.apb_group_id= " + DB_id + ") AND base.apb_mode=2 AND base.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY base.door_id;";//修正調整SQL解決當DOOR數量過多導致APB編輯UI無法使用
    //                //---SYCG/SYDM模式下SYDM ID綁定程式

    //                //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //                SQL = "SELECT base.name AS name,base.door_id AS id,base.apb_mode AS apb_mode,a_d.area_id AS unit FROM (SELECT * FROM (SELECT d_e.door_id AS door_id,d.name AS name,d_e.apb_group_id AS apb_group_id,d_e.apb_used AS apb_used,d.controller_id AS sn FROM door AS d,door_extend AS d_e WHERE (d.state=1 OR d.state=2) AND d.id=d_e.door_id) AS d_data,(SELECT c.sydm_id AS sydm_id,c_e.apb_enable AS apb_enable,c_e.apb_mode AS apb_mode,c.sn AS c_sn FROM controller AS c,controller_extend AS c_e WHERE (c.state=1 OR c.state=2) AND c_e.controller_sn=c.sn) AS c_data WHERE d_data.sn=c_data.c_sn) AS base,area_detail AS a_d WHERE (base.door_id=a_d.door_id) AND base.apb_enable=1 AND base.apb_used=0 AND (base.apb_group_id=-1 OR base.apb_group_id=-10 OR base.apb_group_id= " + DB_id + ") AND base.apb_mode=2 AND base.sydm_id=" + Main_Frm.pForm1.m_StrAPBSydmid + " ORDER BY base.door_id;";//修正調整SQL解決當DOOR數量過多導致APB編輯UI無法使用
    //                break;
    //        }//-1表示沒用過；-10表示當下動作，還未正式存檔；其他表示上一次已儲存結果
    //        if (SQL != "")
    //        {
    //            if (GetWebManage.p_manage_unlimited == "x")//所有UI增加部門和門區的可是範圍限制功能
    //            {//GetWebManage.p_manage_authorized_doors.m_Strdata
    //                String StrBuf = " AND ( base.door_id IN (" + GetWebManage.p_manage_authorized_doors.m_Strdata + ") )  ORDER BY base.door_id;";
    //                SQL = SQL.Replace(" ORDER BY base.door_id;", StrBuf);
    //            }

    //            MySqlDataReader Reader_mode = MySQL.GetDataReader(SQL);
    //            while (Reader_mode.Read())
    //            {
    //                Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_mode["id"].ToString()), Reader_mode["name"].ToString(), Int32.Parse(Reader_mode["unit"].ToString()), (Int32.Parse(Reader_mode["apb_mode"].ToString())+1), "");//id,NAME,父親,階層,資料
    //                m_ALChild.Add(tmp_Node);
    //            }
    //            Reader_mode.Close();
    //        }
    //    }
    //}

    //public class SQLArea_2Tree_Node////把區域的資料從DB讀入記憶體
    //{
    //    /*
    //    //根,[區域群組]
    //    m_id            ->  id
    //    m_unit          ->  -1
    //    m_tree_level    ->  -1        
    //    */
    //    /*
    //    //根,[區域]
    //    m_id            ->  id
    //    m_unit          ->  -1
    //    m_tree_level    ->  0
    //    */
    //    /*
    //    //子(非根),[區域]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  1
    //    */
    //    /*
    //    //子(非根),[門]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  2        
    //    */
    //    public ArrayList m_ALRoot = new ArrayList();//area_group+area
    //    public ArrayList m_ALChild = new ArrayList();//area+door
    //    public SQLArea_2Tree_Node(int extend= 0)
    //    {
    //        m_ALRoot.Clear();
    //        m_ALChild.Clear();
    //        String SQL = "";

    //        if (extend == 2)
    //        {
    //            /*
    //            SQL = "SELECT id,name FROM door_group ORDER BY id;";
    //            */
    //            //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //            SQL = "SELECT id,name FROM door_group WHERE (state=1 OR state=2) ORDER BY id;";

    //            MySqlDataReader Reader_Extend00 = MySQL.GetDataReader(SQL);
    //            while (Reader_Extend00.Read())
    //            {
    //                Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Extend00["id"].ToString()), Reader_Extend00["name"].ToString(), -1, -1, "");//id,NAME,父親,階層,資料
    //                m_ALRoot.Add(tmp_Node);
    //            }
    //            Reader_Extend00.Close();
    //        }

    //        /*
    //        SQL = "SELECT id,name,unit FROM area WHERE unit=-1 ORDER BY id;";
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT id,name,unit FROM area WHERE unit=-1 AND (state=1 OR state=2) ORDER BY id;";

    //        MySqlDataReader Reader_Root = MySQL.GetDataReader(SQL);
    //        while (Reader_Root.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Root["id"].ToString()), Reader_Root["name"].ToString(), -1, 0, "");//id,NAME,父親,階層,資料
    //            m_ALRoot.Add(tmp_Node);
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Root.Close();

    //        /*
    //        SQL = "SELECT id,name,unit FROM area WHERE unit!=-1 ORDER BY id;";
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT id,name,unit FROM area WHERE unit!=-1 AND (state=1 OR state=2) ORDER BY id;";

    //        MySqlDataReader Reader_Child = MySQL.GetDataReader(SQL);
    //        while (Reader_Child.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Child["id"].ToString()), Reader_Child["name"].ToString(), Int32.Parse(Reader_Child["unit"].ToString()), 1, "");//id,NAME,父親,階層,資料
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child.Close();

    //        if (extend != 0)
    //        {
    //            SQL = "";
    //            if (extend >= 1)//單純顯示 區域+門區
    //            {
    //                /*
    //                SQL = "SELECT d.id AS id, d.name AS name,ad.area_id AS unit FROM area_detail AS ad,door AS d WHERE ad.door_id=d.id ORDER BY d.id;";
    //                */
    //                //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //                SQL = "SELECT d.id AS id, d.name AS name,ad.area_id AS unit FROM area_detail AS ad,door AS d WHERE (d.state=1 OR d.state=2) AND ad.door_id=d.id AND (ad.state=1 OR ad.state=2) ORDER BY d.id;";

    //                if (GetWebManage.p_manage_unlimited == "x")//所有UI增加部門和門區的可是範圍限制功能
    //                {//GetWebManage.p_manage_authorized_doors.m_Strdata
    //                    SQL = "SELECT d.id AS id, d.name AS name,ad.area_id AS unit FROM area_detail AS ad,door AS d WHERE (d.state=1 OR d.state=2) AND ad.door_id=d.id AND (ad.state=1 OR ad.state=2) AND ( d.id IN (" + GetWebManage.p_manage_authorized_doors.m_Strdata + ")) ORDER BY d.id;";
    //                }

    //                MySqlDataReader Reader_Extend = MySQL.GetDataReader(SQL);
    //                while (Reader_Extend.Read())
    //                {
    //                    Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Extend["id"].ToString()), Reader_Extend["name"].ToString(), Int32.Parse(Reader_Extend["unit"].ToString()), 2, "");//id,NAME,父親,階層,資料
                        
    //                    //--
    //                    //modified 2017/10/25
    //                    //m_ALChild.Add(tmp_Node);
    //                    if (tmp_Node.Text != "ElevatorGroups-null")
    //                    {
    //                        m_ALChild.Add(tmp_Node);
    //                    }
    //                    //--
    //                }
    //                Reader_Extend.Close();
    //            }
    //        }

    //    }
    //}    
    //public class AreaTree_NodeFun
    //{
    //    public int m_intSelect;
    //    public ArrayList m_ALget = new ArrayList();
    //    public ArrayList m_ALposition = new ArrayList();
    //    public AreaTree_NodeFun()
    //    {
    //        m_intSelect = 0;
    //    }
    //    public void TreeView_Add_RootNode(TreeView treeview, Tree_Node tmp)//增加根節點函數
    //    {
    //        treeview.Nodes.Add(tmp);
    //    }
    //    public void Recursive_Add(Tree_Node n, Tree_Node F, Tree_Node tmp)//遞迴增加子節點函數
    //    {
    //        if (n == F)
    //        {
    //            n.Nodes.Add(tmp);
    //        }
    //        else
    //        {
    //            foreach (Tree_Node tn in n.Nodes)
    //            {
    //                Recursive_Add(tn, F, tmp);
    //            }
    //        }
    //    }
    //    public void TreeView_Add_Node(TreeView treeview, Tree_Node F, Tree_Node tmp)//增加子節點函數
    //    {
    //        TreeNodeCollection nodes = treeview.Nodes;
    //        foreach (Tree_Node n in nodes)
    //        {
    //            Recursive_Add(n, F, tmp);
    //        }
    //    }
    //    static public void SetChildNodeCheckedState(Tree_Node currNode, bool isCheckedOrNot)//設置子節點狀態
    //    {
    //        //http://www.cnblogs.com/luxiaoxun/p/3288003.html
    //        if (currNode.Nodes.Count == 0)//沒有子節點返回
    //        {
    //            /*
    //            if (isCheckedOrNot)
    //            {
    //                currNode.BackColor = Color.Yellow;
    //            }
    //            else
    //            {
    //                currNode.BackColor = Color.White;
    //            }
    //            */
    //            return;
    //        }
    //        foreach (Tree_Node tmpNode in currNode.Nodes)
    //        {
    //            /*
    //            if (isCheckedOrNot)
    //            {
    //                currNode.BackColor = Color.Red;
    //            }
    //            else
    //            {
    //                currNode.BackColor = Color.White;
    //            }
    //            */
    //            tmpNode.Checked = isCheckedOrNot;
    //            SetChildNodeCheckedState(tmpNode, isCheckedOrNot);
    //        }
    //    }
    //    static public void SetParentNodeCheckedState(Tree_Node currNode, bool isCheckedOrNot)//設置父節點狀態
    //    {
    //        //http://www.cnblogs.com/luxiaoxun/p/3288003.html
    //        if (currNode.Parent == null)//沒有父節點返回
    //            return;
    //        if (isCheckedOrNot) //如果當前節點被選中，則設置所有父節點都被選中
    //        {
    //            //--
    //            bool checkedFlag = true;
    //            foreach (Tree_Node tmpNode in currNode.Parent.Nodes)//當前節點的所有同層節點
    //            {
    //                if (tmpNode.Checked == false)
    //                {
    //                    checkedFlag = false;
    //                    break;
    //                }
    //            }
    //            /*
    //            if (checkedFlag)
    //            {
    //                currNode.Parent.BackColor = Color.Red;
    //            }
    //            else
    //            {
    //                currNode.Parent.BackColor = Color.Yellow;
    //            }
    //            */
    //            //--
    //            currNode.Parent.Checked = isCheckedOrNot;
    //            SetParentNodeCheckedState((Tree_Node)(currNode.Parent), isCheckedOrNot);
    //        }
    //        else //如果當前節點沒有被選中，則當其父節點的子節點有一個被選中時，父節點被選中，否則父節點不被選中
    //        {
    //            bool checkedFlag = false;
    //            foreach (Tree_Node tmpNode in currNode.Parent.Nodes)
    //            {
    //                if (tmpNode.Checked)
    //                {
    //                    checkedFlag = true;
    //                    break;
    //                }
    //            }
    //            //--
    //            /*
    //            if (checkedFlag)
    //            {
    //                currNode.Parent.BackColor = Color.Yellow;
    //            }
    //            else
    //            {
    //                currNode.Parent.BackColor = Color.White;
    //            }
    //            */
    //            //--
    //            currNode.Parent.Checked = checkedFlag;
    //            SetParentNodeCheckedState((Tree_Node)(currNode.Parent), checkedFlag);
    //        }
    //    }
        
    //    //--
    //    //2017/09/28
    //    public ArrayList m_ALarea_door_group_detailed = new ArrayList();
    //    public bool[] m_blnchexkNode = null;//修正授權編輯UI中TreeView選單重複選取的BUG
    //    public void setTreeView(Tree_Node Root, int extend = 0)//設定Node被選擇
    //    {
    //        if (Root.Nodes.Count == 0)
    //        {
    //            Tree_Node Node = Root;
    //            String NodeData = "";
    //            if ((Node.m_tree_level == 2) || (Node.m_tree_level == -1))
    //            {
    //                if (extend > 0)
    //                {
    //                    NodeData = Node.m_id + "," + Node.m_tree_level;
    //                }
    //                else
    //                {
    //                    NodeData = Node.m_id + "";//door
    //                }

    //                for (int i = 0; i < m_ALarea_door_group_detailed.Count; i++)
    //                {
    //                    String Data = m_ALarea_door_group_detailed[i].ToString();
    //                    if ((NodeData == Data) && (!m_blnchexkNode[i]))//修正授權編輯UI中TreeView選單重複選取的BUG if (NodeData == Data)
    //                    {
    //                        m_blnchexkNode[i] = true;//修正授權編輯UI中TreeView選單重複選取的BUG 
    //                        Node.Checked = true;
    //                        break;
    //                    }
    //                }
    //            }
    //        }

    //        foreach (Tree_Node Node in Root.Nodes)
    //        {
    //            if (Node.Nodes.Count == 0)//樹的最後節點
    //            {
    //                String NodeData = "";
    //                if ((Node.m_tree_level == 2) || (Node.m_tree_level == -1))
    //                {
    //                    if (extend > 0)
    //                    {
    //                        NodeData = Node.m_id + "," + Node.m_tree_level;
    //                    }
    //                    else
    //                    {
    //                        NodeData = Node.m_id + "";//door
    //                    }

    //                    for (int i = 0; i < m_ALarea_door_group_detailed.Count; i++)
    //                    {
    //                        String Data = m_ALarea_door_group_detailed[i].ToString();
    //                        if ((NodeData == Data) && (!m_blnchexkNode[i]))//修正授權編輯UI中TreeView選單重複選取的BUG if (NodeData == Data)
    //                        {
    //                            m_blnchexkNode[i] = true;//修正授權編輯UI中TreeView選單重複選取的BUG 
    //                            Node.Checked = true;
    //                            break;
    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                setTreeView(Node, extend);
    //            }
    //        }
    //        return;
    //    }
    //    public void setTreeView(TreeView TV, int extend = 0)//設定Node被選擇，必須從ROOT開始搜尋，所以要傳遞TreeView
    //    {
    //        //---
    //        //修正授權編輯UI中TreeView選單重複選取的BUG
    //        m_blnchexkNode = new bool[m_ALarea_door_group_detailed.Count];
    //        for(int i=0;i<m_blnchexkNode.Length;i++)
    //        {
    //            m_blnchexkNode[i] = false;
    //        }
    //        //---修正授權編輯UI中TreeView選單重複選取的BUG
    //        foreach (Tree_Node Node in TV.Nodes)
    //        {
    //            setTreeView(Node, extend);
    //        }
    //    }
    //    public void getTreeView(Tree_Node Root, int extend = 0)//取得被選擇的Node
    //    {
    //        if (Root.Nodes.Count == 0)
    //        {
    //            String NodeData = "";
    //            Tree_Node Node = Root;
    //            if ((Node.m_tree_level == 2) || (Node.m_tree_level == -1))
    //            {
    //                if (extend > 0)
    //                {
    //                    NodeData = Node.m_id + "," + Node.m_tree_level;
    //                }
    //                else
    //                {
    //                    NodeData = Node.m_id + "";//door
    //                }

    //                if (NodeData != "")
    //                {
    //                    m_ALarea_door_group_detailed.Add(NodeData);
    //                }
    //            }
    //        }

    //        foreach (Tree_Node Node in Root.Nodes)
    //        {
    //            if (Node.Checked == true)
    //            {
    //                if (Node.Nodes.Count == 0)//樹的最後節點
    //                {
    //                    String NodeData = "";
    //                    if ((Node.m_tree_level == 2) || (Node.m_tree_level == -1))
    //                    {
    //                        if (extend > 0)
    //                        {
    //                            NodeData = Node.m_id + "," + Node.m_tree_level;
    //                        }
    //                        else
    //                        {
    //                            NodeData = Node.m_id + "";//door
    //                        }

    //                        if (NodeData != "")
    //                        {
    //                            m_ALarea_door_group_detailed.Add(NodeData);
    //                        }
    //                    }
    //                }//if (Node.Nodes.Count == 0)
    //                else
    //                {
    //                    if (Node.Checked == true)
    //                    {
    //                        getTreeView(Node, extend);
    //                    }
    //                }
    //            }//if (Node.Checked == true)
    //        }
    //        return;
    //    }
    //    public void getTreeView(TreeView TV, int extend = 0)//取得被選擇的Node，必須從ROOT開始搜尋，所以要傳遞TreeView
    //    {
    //        m_ALarea_door_group_detailed.Clear();
    //        foreach (Tree_Node Node in TV.Nodes)
    //        {
    //            if (Node.Checked == true)
    //            {
    //                getTreeView(Node, extend);
    //            }
    //        }
    //    }
    //    //--
    //}

    //public class SQL_Controller2Tree_Node//把控制器+門區的資料從DB讀入記憶體
    //{
    //    /*
    //    //控制器
    //    m_id            ->  sn
    //    m_unit          ->  -1
    //    m_tree_level    ->  0
    //    m_data          ->  model 
    //    */

    //    /*
    //    //門區
    //    m_id            ->  id
    //    m_unit          ->  controller_id
    //    m_tree_level    ->  1
    //    */
    //    public ArrayList m_ALRoot = new ArrayList();//Controller
    //    public ArrayList m_ALChild = new ArrayList();//door
    //    public SQL_Controller2Tree_Node()
    //    {
    //        m_ALRoot.Clear();
    //        m_ALChild.Clear();

    //        String SQL = "";
            
    //        //---
    //        //門區的控制器列表不用列unknown部分
    //        //SQL = "SELECT c.sn AS sn,c.name AS name,m.door_number AS door_number FROM controller AS c,models AS m WHERE c.model=m.model ORDER BY id;";//modified at 2017/10/25~ SQL = "SELECT sn,name,model FROM controller ORDER BY id;";
    //        /*
    //        SQL = "SELECT c.sn AS sn,c.name AS name,m.door_number AS door_number FROM controller AS c,models AS m WHERE (c.model=m.model) AND (c.state>-1) ORDER BY id;";
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT c.sn AS sn,c.name AS name,m.door_number AS door_number FROM controller AS c,models AS m WHERE (c.model=m.model) AND (c.state=1 OR c.state=2) ORDER BY id;";
            
    //        //---門區的控制器列表不用列unknown部分

    //        MySqlDataReader Reader_Root = MySQL.GetDataReader(SQL);
    //        while (Reader_Root.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Root["sn"].ToString()), Reader_Root["name"].ToString(), -1, 0, Reader_Root["door_number"].ToString());//id,NAME,父親,階層
    //            m_ALRoot.Add(tmp_Node);
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Root.Close();

    //        /*
    //        SQL = "SELECT d.id AS id,d.name AS name,d.controller_id AS controller_id,m.door_number AS door_number FROM door AS d,controller AS c,models AS m WHERE (d.name!='') AND (d.controller_id=c.sn) AND (c.model=m.model) ORDER BY id ASC;";//modified at 2017/10/25~ //SQL = "SELECT id,name,controller_id FROM door WHERE name!='' ORDER BY id ASC;";
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT d.id AS id,d.name AS name,d.controller_id AS controller_id,m.door_number AS door_number FROM door AS d,controller AS c,models AS m WHERE (d.identifier!='') AND (d.state=1 OR d.state=2) AND (d.name!='') AND (d.controller_id=c.sn) AND (c.model=m.model) ORDER BY id ASC;"; //door 沒有Res_id 一律不顯示~ SQL = "SELECT d.id AS id,d.name AS name,d.controller_id AS controller_id,m.door_number AS door_number FROM door AS d,controller AS c,models AS m WHERE (d.state=1 OR d.state=2) AND (d.name!='') AND (d.controller_id=c.sn) AND (c.model=m.model) ORDER BY id ASC;";//modified at 2017/10/25~ //SQL = "SELECT id,name,controller_id FROM door WHERE name!='' ORDER BY id ASC;";

    //        if (GetWebManage.p_manage_unlimited == "x")//所有UI增加部門和門區的可是範圍限制功能
    //        {//GetWebManage.p_manage_authorized_doors.m_Strdata
    //            SQL = "SELECT d.id AS id,d.name AS name,d.controller_id AS controller_id,m.door_number AS door_number FROM door AS d,controller AS c,models AS m WHERE (d.identifier!='') AND (d.state=1 OR d.state=2) AND (d.name!='') AND (d.controller_id=c.sn) AND (c.model=m.model) AND (d.id IN (" + GetWebManage.p_manage_authorized_doors.m_Strdata + ") ) ORDER BY id ASC;";//door 沒有Res_id 一律不顯示~ SQL = "SELECT d.id AS id,d.name AS name,d.controller_id AS controller_id,m.door_number AS door_number FROM door AS d,controller AS c,models AS m WHERE (d.state=1 OR d.state=2) AND (d.name!='') AND (d.controller_id=c.sn) AND (c.model=m.model) AND (d.id IN (" + GetWebManage.p_manage_authorized_doors.m_Strdata + ") ) ORDER BY id ASC;";
    //        }

    //        MySqlDataReader Reader_Child = MySQL.GetDataReader(SQL);
    //        while (Reader_Child.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Child["id"].ToString()), Reader_Child["name"].ToString(), Int32.Parse(Reader_Child["controller_id"].ToString()), 1, Reader_Child["door_number"].ToString());//id,NAME,父親,階層
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child.Close();
    //    }
    //}
    //public class ControllerTree_NodeFun
    //{
    //    public int m_intSelect;
    //    public ArrayList m_ALget = new ArrayList();//取出節點要存放到DB的資訊[ 目前因為DB尚未決定所以資料室亂放的 at 2016/09/19 by jash ]
    //    public ArrayList m_ALposition = new ArrayList();//暫存檔案用
    //    public ControllerTree_NodeFun()
    //    {
    //        m_intSelect = 0;
    //    }
    //    public void TreeView_Add_RootNode(TreeView treeview, Tree_Node tmp)//增加根節點函數
    //    {
    //        treeview.Nodes.Add(tmp);
    //    }
    //    public void Recursive_Add(Tree_Node n, Tree_Node F, Tree_Node tmp)//遞迴增加子節點函數
    //    {
    //        if (n == F)
    //        {
    //            n.Nodes.Add(tmp);
    //        }
    //        else
    //        {
    //            foreach (Tree_Node tn in n.Nodes)
    //            {
    //                Recursive_Add(tn, F, tmp);
    //            }
    //        }
    //    }
    //    public void TreeView_Add_Node(TreeView treeview, Tree_Node F, Tree_Node tmp)//增加子節點函數
    //    {
    //        TreeNodeCollection nodes = treeview.Nodes;
    //        foreach (Tree_Node n in nodes)
    //        {
    //            Recursive_Add(n, F, tmp);
    //        }
    //    }
    //    static public void SetChildNodeCheckedState(Tree_Node currNode, bool isCheckedOrNot)//設置子節點狀態
    //    {
    //        //http://www.cnblogs.com/luxiaoxun/p/3288003.html
    //        if (currNode.Nodes.Count == 0)//沒有子節點返回
    //        {
    //            /*
    //            if (isCheckedOrNot)
    //            {
    //                currNode.BackColor = Color.Yellow;
    //            }
    //            else
    //            {
    //                currNode.BackColor = Color.White;
    //            }
    //            */ 
    //            return;
    //        }
    //        foreach (Tree_Node tmpNode in currNode.Nodes)
    //        {
    //            /*
    //            if (isCheckedOrNot)
    //            {
    //                currNode.BackColor = Color.Red;
    //            }
    //            else
    //            {
    //                currNode.BackColor = Color.White;
    //            }
    //            */ 
    //            tmpNode.Checked = isCheckedOrNot;
    //            SetChildNodeCheckedState(tmpNode, isCheckedOrNot);
    //        }
    //    }
    //    static public void SetParentNodeCheckedState(Tree_Node currNode, bool isCheckedOrNot)//設置父節點狀態
    //    {
    //        //http://www.cnblogs.com/luxiaoxun/p/3288003.html
    //        if (currNode.Parent == null)//沒有父節點返回
    //            return;
    //        if (isCheckedOrNot) //如果當前節點被選中，則設置所有父節點都被選中
    //        {
    //            //--
    //            bool checkedFlag = true;
    //            foreach (Tree_Node tmpNode in currNode.Parent.Nodes)//當前節點的所有同層節點
    //            {
    //                if (tmpNode.Checked == false)
    //                {
    //                    checkedFlag = false;
    //                    break;
    //                }
    //            }
    //            /*
    //            if (checkedFlag)
    //            {
    //                currNode.Parent.BackColor = Color.Red;
    //            }
    //            else
    //            {
    //                currNode.Parent.BackColor = Color.Yellow;
    //            }
    //            */ 
    //            //--
    //            currNode.Parent.Checked = isCheckedOrNot;
    //            SetParentNodeCheckedState((Tree_Node)(currNode.Parent), isCheckedOrNot);
    //        }
    //        else //如果當前節點沒有被選中，則當其父節點的子節點有一個被選中時，父節點被選中，否則父節點不被選中
    //        {
    //            bool checkedFlag = false;
    //            foreach (Tree_Node tmpNode in currNode.Parent.Nodes)
    //            {
    //                if (tmpNode.Checked)
    //                {
    //                    checkedFlag = true;
    //                    break;
    //                }
    //            }
    //            //--
    //            /*
    //            if (checkedFlag)
    //            {
    //                currNode.Parent.BackColor = Color.Yellow;
    //            }
    //            else
    //            {
    //                currNode.Parent.BackColor = Color.White;
    //            }
    //            */ 
    //            //--
    //            currNode.Parent.Checked = checkedFlag;
    //            SetParentNodeCheckedState((Tree_Node)(currNode.Parent), checkedFlag);
    //        }
    //    }
    //    public void getData(TreeView TV)//必須從ROOT開始搜尋，所以要傳遞TreeView
    //    {
    //        m_ALget.Clear();
    //        m_ALposition.Clear();
    //        int j = 0;
    //        foreach (Tree_Node Node in TV.Nodes)
    //        {
    //            if (Node.Checked == true)
    //            {
    //                String StrPosition = "" + j;
    //                getData(Node, StrPosition);
    //            }
    //            j++;
    //        }
    //        m_ALget = GetDistinctAarray(m_ALget);
    //        m_ALposition = GetDistinctAarray(m_ALposition);
    //        /*
    //        richTextBox1.Text = "";
    //        for (int i = 0; i < m_ALget.Count; i++)
    //        {
    //            richTextBox1.Text += m_ALget[i] + ", ";
    //        }
    //        */
    //    }
    //    public void Clear_AL()
    //    {
    //        m_ALget.Clear();
    //        m_ALposition.Clear();
    //    }
    //    public ArrayList GetDistinctAarray(ArrayList arr)//ArrayList 重複資料刪除
    //    {
    //        ArrayList lst = new ArrayList();
    //        for (int i = 0; i < arr.Count; i++)
    //        {
    //            if (lst.Contains(arr[i]))
    //            {
    //                continue;
    //            }
    //            lst.Add(arr[i]);
    //        }
    //        return lst;
    //    }
    //    /*
    //    public void getData_0(Tree_Node currNode, String StrPosition)//人
    //    {
    //        String SQL = String.Format("SELECT People_List.uid AS ID, People_List.C_name AS Name FROM People_List WHERE People_List.uid={0};", currNode.m_id);//確定所選項目是人非目錄
    //        bool blncheck = false;
    //        String StrName, StrID;
    //        StrName = "";
    //        StrID = "";
    //        MySqlDataReader Reader_user = MySQL.GetDataReader(SQL);
    //        while (Reader_user.Read())//有找到值就代表是人 非部門
    //        {
    //            blncheck = true;
    //            StrName = Reader_user["Name"].ToString();//取出姓名
    //            StrID = Reader_user["ID"].ToString();//取出編號
    //            break;
    //        }
    //        Reader_user.Close();

    //        if (blncheck)
    //        {
    //            if (StrName == currNode.Text)
    //            {
    //                blncheck = true;
    //            }
    //            else
    //            {
    //                blncheck = false;
    //            }
    //        }
    //        if ((currNode.Checked == true) && blncheck)//該選項有被選取 且 是人
    //        {
    //            String Buf = StrPosition;
    //            m_ALposition.Add(Buf);
    //            String Buf1 = currNode.Text + "(" + Buf + "~" + StrID + ")";
    //            m_ALget.Add(StrID);//m_ALget.Add(Buf1);
    //        }
    //    }
    //    public void getData_1(Tree_Node currNode, String StrPosition)//門
    //    {
    //        String SQL = String.Format("SELECT FDevice_List.uid AS ID, FDevice_List.C_name AS Name FROM FDevice_List WHERE FDevice_List.uid={0};", currNode.m_id);//確定所選項目是人非目錄
    //        bool blncheck = false;
    //        String StrName, StrID;
    //        StrName = "";
    //        StrID = "";
    //        MySqlDataReader Reader_user = MySQL.GetDataReader(SQL);
    //        while (Reader_user.Read())//有找到值就代表是人 非部門
    //        {
    //            blncheck = true;
    //            StrName = Reader_user["Name"].ToString();//取出姓名
    //            StrID = Reader_user["ID"].ToString();//取出編號
    //            break;
    //        }
    //        Reader_user.Close();

    //        if (blncheck)
    //        {
    //            if (StrName == currNode.Text)
    //            {
    //                blncheck = true;
    //            }
    //            else
    //            {
    //                blncheck = false;
    //            }
    //        }
    //        if ((currNode.Checked == true) && blncheck)//該選項有被選取 且 是人
    //        {
    //            String Buf = StrPosition;
    //            m_ALposition.Add(Buf);
    //            String Buf1 = currNode.Text + "(" + Buf + "~" + StrID + ")";
    //            m_ALget.Add(StrID);//m_ALget.Add(Buf1);
    //        }
    //    }
    //    */ 
    //    public void getData(Tree_Node currNode, String StrPosition)//搜尋最後節點的遞迴函數
    //    {
    //        if (currNode.Checked == true)
    //        {
    //            if (currNode.Nodes.Count == 0)//沒有子節點返回
    //            {
    //                switch (m_intSelect)
    //                {
    //                    case 0:
    //                        if ( (currNode.m_tree_level == 1) && (currNode.m_unit != -1) )
    //                        {
    //                            m_ALget.Add("" + currNode.m_id);//最後節點只要(currNode.m_tree_level == 1) && (currNode.m_unit != -1)就一定不是目錄-2017/05/25 //getData_0(currNode, StrPosition);//人(每的節點都查一次SQL)
    //                            m_ALposition.Add(currNode.Text);//用來儲存顯示被選項目的中文名稱 2017/05/26
    //                        }
    //                        break;
    //                    case 1:
    //                        if ((currNode.m_tree_level == 1) && (currNode.m_unit != -1))
    //                        {
    //                            m_ALget.Add("" + currNode.m_id);//最後節點只要(currNode.m_tree_level == 1) && (currNode.m_unit != -1)就一定不是目錄-2017/05/25 //getData_1(currNode, StrPosition);//門(每的節點都查一次SQL)
    //                            m_ALposition.Add(currNode.Text);//用來儲存顯示被選項目的中文名稱 2017/05/26
    //                        }
    //                        break;
    //                }
    //                return;
    //            }
    //            else
    //            {
    //                foreach (Tree_Node Node in currNode.Nodes)
    //                {
    //                    String Buf = StrPosition + "," + Node.Index;
    //                    getData(Node, Buf);
    //                }
    //            }
    //        }
    //    }
    //}

    //public class SQLDepartment2Tree_Node//把部門的資料從DB讀入記憶體
    //{
    //    /*
    //    //根,[部門]
    //    m_id            ->  id
    //    m_unit          ->  unit=0
    //    m_tree_level    ->  0
    //    */
    //    /*
    //    //子(非根),[部門]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  1
    //    */
    //    public ArrayList m_ALRoot = new ArrayList();//
    //    public ArrayList m_ALChild = new ArrayList();//
    //    public SQLDepartment2Tree_Node()
    //    {
    //        m_ALRoot.Clear();
    //        m_ALChild.Clear();
    //        String SQL = "";

    //        /*
    //        SQL = "SELECT id, name, unit FROM department WHERE unit=0 ORDER BY id;";
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit=0 ORDER BY id;";

    //        if (GetWebManage.p_manage_unlimited == "x")//所有UI增加部門和門區的可是範圍限制功能	
    //        {//GetWebManage.p_manage_authorized_department.m_Strdata
    //            SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit=0 AND ( id IN (" + GetWebManage.p_manage_authorized_department.m_Strdata + ") ) ORDER BY id;";
    //        }

    //        MySqlDataReader Reader_Root = MySQL.GetDataReader(SQL);
    //        Tree_Node Last_Node = null;//修正部們根節點排列順序的算法，確保未分類一定在部門列表的最後一個
    //        while (Reader_Root.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Root["id"].ToString()), Reader_Root["name"].ToString(), 0, 0, "");//id,NAME,父親,階層,資料
    //            //---
    //            //按照『V8 功能選單』一個一個改-部門 ~ 『未分類』擺至最下方，並以不同顏色區隔
    //            /*
    //            m_ALRoot.Add(tmp_Node);
    //            m_ALChild.Add(tmp_Node); 
    //            */
    //            if (tmp_Node.m_id < 0)
    //            {
    //                Last_Node = new Tree_Node(Int32.Parse(Reader_Root["id"].ToString()), Reader_Root["name"].ToString(), 0, 0, "");//id,NAME,父親,階層,資料
    //                Last_Node.ForeColor = Color.Blue;
    //                Last_Node.m_ColorBackup = Color.Blue;//按照『V8 功能選單』一個一個改-部門 ~ 修正ComboBoxTreeView元件未分類目錄顏色會因為選擇過而錯亂的BUG
    //            }
    //            else
    //            {
    //                m_ALRoot.Add(tmp_Node);
    //                m_ALChild.Add(tmp_Node);
    //            }
    //            //---按照『V8 功能選單』一個一個改-部門 ~ 『未分類』擺至最下方，並以不同顏色區隔
    //        }
    //        //---
    //        //修正部們根節點排列順序的算法，確保未分類一定在部門列表的最後一個
    //        if (Last_Node != null)
    //        {
    //            m_ALRoot.Add(Last_Node);
    //            m_ALChild.Add(Last_Node);
    //        }
    //        //---修正部們根節點排列順序的算法，確保未分類一定在部門列表的最後一個
    //        Reader_Root.Close();

    //        /*
    //        SQL = "SELECT id, name, unit FROM department WHERE unit>0 ORDER BY id;";
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit>0 ORDER BY id;";

    //        if (GetWebManage.p_manage_unlimited == "x")//所有UI增加部門和門區的可是範圍限制功能	
    //        {//GetWebManage.p_manage_authorized_department.m_Strdata
    //            SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit>0 AND ( id IN (" + GetWebManage.p_manage_authorized_department.m_Strdata + ") ) ORDER BY id;";
    //        }

    //        MySqlDataReader Reader_Child = MySQL.GetDataReader(SQL);
    //        while (Reader_Child.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Child["id"].ToString()), Reader_Child["name"].ToString(), Int32.Parse(Reader_Child["unit"].ToString()), 1, "");//id,NAME,父親,階層,資料
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child.Close();
    //    }
    //}
    //public class DepartmentTree_NodeFun
    //{
    //    public int m_intSelect;
    //    public ArrayList m_ALget = new ArrayList();//取出節點要存放到DB的資訊[ 目前因為DB尚未決定所以資料室亂放的 at 2016/09/19 by jash ]
    //    public ArrayList m_ALposition = new ArrayList();//暫存檔案用

    //    public DepartmentTree_NodeFun()
    //    {
    //        m_intSelect = 0;
    //    }
    //    public void TreeView_Add_RootNode(TreeView treeview, Tree_Node tmp)//增加根節點函數
    //    {
    //        treeview.Nodes.Add(tmp);
    //    }
    //    public void Recursive_Add(Tree_Node n, Tree_Node F, Tree_Node tmp)//遞迴增加子節點函數
    //    {
    //        if (n == F)
    //        {
    //            n.Nodes.Add(tmp);
    //        }
    //        else
    //        {
    //            foreach (Tree_Node tn in n.Nodes)
    //            {
    //                Recursive_Add(tn, F, tmp);
    //            }
    //        }
    //    }
    //    public void TreeView_Add_Node(TreeView treeview, Tree_Node F, Tree_Node tmp)//增加子節點函數
    //    {
    //        TreeNodeCollection nodes = treeview.Nodes;
    //        foreach (Tree_Node n in nodes)
    //        {
    //            Recursive_Add(n, F, tmp);
    //        }
    //    }

    //}

    //public class SQL_DeptCard2Tree_Node
    //{
    //    /*
    //    //根,[人員車輛群組]
    //    m_id            ->  id
    //    m_unit          ->  0
    //    m_tree_level    ->  -1        
    //    */
    //    /*
    //    //根,[部門]
    //    m_id            ->  id
    //    m_unit          ->  0
    //    m_tree_level    ->  0
    //    */
    //    /*
    //    //子(非根),[部門]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  1
    //    */
    //    /*
    //    //子(非根),[人的卡]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  2
    //    */
    //    /*
    //    //子(非根),[車的卡]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  3
    //    */

    //    //---
    //    //啟用授權複製作業~部門人員卡片列表支援搜尋
    //    public String m_StrCondition01;
    //    public String m_StrCondition02;
    //    //---啟用授權複製作業~部門人員卡片列表支援搜尋

    //    public ArrayList m_ALRoot = new ArrayList();//人員車輛群組+部門
    //    public ArrayList m_ALChild = new ArrayList();//部門+人卡+車卡
    //    public SQL_DeptCard2Tree_Node(int extend = 0, String StrCondition01 = "", String StrCondition02 = "")
    //    {
    //        String SQL = "";
    //        m_ALRoot.Clear();
    //        m_ALChild.Clear();

    //        //---
    //        //啟用授權複製作業~部門人員卡片列表支援搜尋
    //        m_StrCondition01 = StrCondition01;
    //        m_StrCondition02 = StrCondition02;
    //        //---啟用授權複製作業~部門人員卡片列表支援搜尋

    //        if (extend != 0)
    //        {
    //            /*
    //            SQL = "SELECT id,name FROM user_car_group ORDER BY id;";//人員車輛部門群組
    //            */
    //            //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //            SQL = "SELECT id,name FROM user_car_group WHERE (state=1 OR state=2) ORDER BY id;";//人員車輛部門群組

    //            MySqlDataReader Reader_Extend = MySQL.GetDataReader(SQL);
    //            while (Reader_Extend.Read())
    //            {
    //                Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Extend["id"].ToString()), Reader_Extend["name"].ToString(), 0, -1, "");//id,NAME,父親,階層,資料
    //                m_ALRoot.Add(tmp_Node);
    //            }
    //            Reader_Extend.Close();
    //        }

    //        /*
    //        SQL = "SELECT id, name, unit FROM department WHERE unit=0 ORDER BY id;";//查根部門
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit=0 ORDER BY id;";//查根部門

    //        if (GetWebManage.p_manage_unlimited == "x")//所有UI增加部門和門區的可是範圍限制功能	
    //        {//GetWebManage.p_manage_authorized_department.m_Strdata
    //            SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit=0 AND ( id IN (" + GetWebManage.p_manage_authorized_department.m_Strdata + ") ) ORDER BY id;";//查根部門
    //        }

    //        MySqlDataReader Reader_Root = MySQL.GetDataReader(SQL);
    //        while (Reader_Root.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Root["id"].ToString()), Reader_Root["name"].ToString(), 0, 0, "");//id,NAME,父親,階層,資料
    //            m_ALRoot.Add(tmp_Node);
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Root.Close();

    //        /*
    //        SQL = "SELECT id, name, unit FROM department WHERE unit>0 ORDER BY id;";//查子部門
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit>0 ORDER BY id;";//查子部門

    //        if (GetWebManage.p_manage_unlimited == "x")//所有UI增加部門和門區的可是範圍限制功能	
    //        {//GetWebManage.p_manage_authorized_department.m_Strdata
    //            SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit>0 AND (id IN (" + GetWebManage.p_manage_authorized_department.m_Strdata + ") ) ORDER BY id;";//查子部門
    //        }

    //        MySqlDataReader Reader_Child00 = MySQL.GetDataReader(SQL);
    //        while (Reader_Child00.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Child00["id"].ToString()), Reader_Child00["name"].ToString(), Int32.Parse(Reader_Child00["unit"].ToString()), 1, "");//id,NAME,父親,階層,資料
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child00.Close();

    //        //SQL = "SELECT cfuc.card_id AS id,u.name AS name01,d_d.dep_id AS unit,card.display AS name02,card.card_code AS name03 FROM user AS u,department_detail AS d_d,card_for_user_car AS cfuc LEFT JOIN card ON cfuc.card_id = card.id WHERE (cfuc.car_id IS NULL) AND (cfuc.user_id=u.id) AND (d_d.car_id IS NULL) AND (d_d.user_id=u.id);";
    //        /*
    //        SQL = String.Format("SELECT cfuc.card_id AS id,u.name AS name01,d_d.dep_id AS unit,card.display AS name02,card.card_code AS name03 FROM user AS u,department_detail AS d_d,card_for_user_car AS cfuc LEFT JOIN card ON cfuc.card_id = card.id WHERE (cfuc.car_id IS NULL) AND (cfuc.user_id=u.id) AND (d_d.car_id IS NULL) AND (d_d.user_id=u.id){0};", m_StrCondition01);//啟用授權複製作業~部門人員卡片列表支援搜尋
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = String.Format("SELECT cfuc.card_id AS id,u.name AS name01,d_d.dep_id AS unit,card.display AS name02,card.card_code AS name03 FROM user AS u,department_detail AS d_d,card_for_user_car AS cfuc LEFT JOIN card ON cfuc.card_id = card.id WHERE (u.state=1 OR u.state=2 ) AND (cfuc.car_id IS NULL) AND (cfuc.user_id=u.id) AND (d_d.car_id IS NULL) AND (d_d.user_id=u.id){0};", m_StrCondition01);//啟用授權複製作業~部門人員卡片列表支援搜尋

    //        MySqlDataReader Reader_Child01 = MySQL.GetDataReader(SQL);
    //        while (Reader_Child01.Read())
    //        {
    //            String name = Reader_Child01["name01"].ToString() + "~" + Reader_Child01["name02"].ToString() + "(" + Reader_Child01["name03"].ToString() + ")";
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Child01["id"].ToString()), name, Int32.Parse(Reader_Child01["unit"].ToString()), 2, "");//id,NAME,父親,階層,資料
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child01.Close();

    //        //SQL = "SELECT cfuc.card_id AS id,c.licence AS name00,c.name AS name01,d_d.dep_id AS unit,card.display AS name02,card.card_code AS name03 FROM car AS c,department_detail AS d_d,card_for_user_car AS cfuc LEFT JOIN card ON cfuc.card_id = card.id WHERE (c.id=d_d.car_id) AND (cfuc.car_id=c.id);";
    //        /*
    //        SQL = String.Format("SELECT cfuc.card_id AS id,c.licence AS name00,c.name AS name01,d_d.dep_id AS unit,card.display AS name02,card.card_code AS name03 FROM car AS c,department_detail AS d_d,card_for_user_car AS cfuc LEFT JOIN card ON cfuc.card_id = card.id WHERE (c.id=d_d.car_id) AND (cfuc.car_id=c.id){0};", m_StrCondition02);//啟用授權複製作業~部門人員卡片列表支援搜尋
    //        */
    //        //修正Thread_WebAPIUploadDB不具備刪除遠端DB資料的補救程序-所有列表UI都要加上(state=1||state=2)的過濾
    //        SQL = String.Format("SELECT cfuc.card_id AS id,c.licence AS name00,c.name AS name01,d_d.dep_id AS unit,card.display AS name02,card.card_code AS name03 FROM car AS c,department_detail AS d_d,card_for_user_car AS cfuc LEFT JOIN card ON cfuc.card_id = card.id WHERE (c.state=1 OR c.state=2) AND (c.id=d_d.car_id) AND (cfuc.car_id=c.id){0};", m_StrCondition02);//啟用授權複製作業~部門人員卡片列表支援搜尋

    //        MySqlDataReader Reader_Child02 = MySQL.GetDataReader(SQL);
    //        while (Reader_Child02.Read())
    //        {
    //            String name = Reader_Child02["name01"].ToString() + "[" + Reader_Child02["name00"].ToString() + "]~"+Reader_Child02["name02"].ToString()+"(" + Reader_Child02["name03"].ToString() + ")";
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Child02["id"].ToString()), name, Int32.Parse(Reader_Child02["unit"].ToString()), 3, "");//id,NAME,父親,階層,資料
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child02.Close();
    //    }
    //}
    //public class DeptCardTree_NodeFun
    //{
    //    public int m_intSelect;
    //    public ArrayList m_ALget = new ArrayList();
    //    public ArrayList m_ALposition = new ArrayList();
    //    public DeptCardTree_NodeFun()
    //    {
    //        m_intSelect = 0;
    //    }
    //    public void TreeView_Add_RootNode(TreeView treeview, Tree_Node tmp)//增加根節點函數
    //    {
    //        treeview.Nodes.Add(tmp);
    //    }
    //    public void Recursive_Add(Tree_Node n, Tree_Node F, Tree_Node tmp)//遞迴增加子節點函數
    //    {
    //        if (n == F)
    //        {
    //            n.Nodes.Add(tmp);
    //        }
    //        else
    //        {
    //            foreach (Tree_Node tn in n.Nodes)
    //            {
    //                Recursive_Add(tn, F, tmp);
    //            }
    //        }
    //    }
    //    public void TreeView_Add_Node(TreeView treeview, Tree_Node F, Tree_Node tmp)//增加子節點函數
    //    {
    //        TreeNodeCollection nodes = treeview.Nodes;
    //        foreach (Tree_Node n in nodes)
    //        {
    //            Recursive_Add(n, F, tmp);
    //        }
    //    }
    //    static public void SetChildNodeCheckedState(Tree_Node currNode, bool isCheckedOrNot)//設置子節點狀態
    //    {
    //        //http://www.cnblogs.com/luxiaoxun/p/3288003.html
    //        if (currNode.Nodes.Count == 0)//沒有子節點返回
    //        {
    //            /*
    //            if (isCheckedOrNot)
    //            {
    //                currNode.BackColor = Color.Yellow;
    //            }
    //            else
    //            {
    //                currNode.BackColor = Color.White;
    //            }
    //            */
    //            return;
    //        }
    //        foreach (Tree_Node tmpNode in currNode.Nodes)
    //        {
    //            /*
    //            if (isCheckedOrNot)
    //            {
    //                currNode.BackColor = Color.Red;
    //            }
    //            else
    //            {
    //                currNode.BackColor = Color.White;
    //            }
    //            */
    //            tmpNode.Checked = isCheckedOrNot;
    //            SetChildNodeCheckedState(tmpNode, isCheckedOrNot);
    //        }
    //    }
    //    static public void SetParentNodeCheckedState(Tree_Node currNode, bool isCheckedOrNot)//設置父節點狀態
    //    {
    //        //http://www.cnblogs.com/luxiaoxun/p/3288003.html
    //        if (currNode.Parent == null)//沒有父節點返回
    //            return;
    //        if (isCheckedOrNot) //如果當前節點被選中，則設置所有父節點都被選中
    //        {
    //            //--
    //            bool checkedFlag = true;
    //            foreach (Tree_Node tmpNode in currNode.Parent.Nodes)//當前節點的所有同層節點
    //            {
    //                if (tmpNode.Checked == false)
    //                {
    //                    checkedFlag = false;
    //                    break;
    //                }
    //            }
    //            /*
    //            if (checkedFlag)
    //            {
    //                currNode.Parent.BackColor = Color.Red;
    //            }
    //            else
    //            {
    //                currNode.Parent.BackColor = Color.Yellow;
    //            }
    //            */
    //            //--
    //            currNode.Parent.Checked = isCheckedOrNot;
    //            SetParentNodeCheckedState((Tree_Node)(currNode.Parent), isCheckedOrNot);
    //        }
    //        else //如果當前節點沒有被選中，則當其父節點的子節點有一個被選中時，父節點被選中，否則父節點不被選中
    //        {
    //            bool checkedFlag = false;
    //            foreach (Tree_Node tmpNode in currNode.Parent.Nodes)
    //            {
    //                if (tmpNode.Checked)
    //                {
    //                    checkedFlag = true;
    //                    break;
    //                }
    //            }
    //            //--
    //            /*
    //            if (checkedFlag)
    //            {
    //                currNode.Parent.BackColor = Color.Yellow;
    //            }
    //            else
    //            {
    //                currNode.Parent.BackColor = Color.White;
    //            }
    //            */
    //            //--
    //            currNode.Parent.Checked = checkedFlag;
    //            SetParentNodeCheckedState((Tree_Node)(currNode.Parent), checkedFlag);
    //        }
    //    }

    //    public ArrayList m_ALuser_car_group_detailed = new ArrayList();
    //    public bool[] m_blnchexkNode = null;//修正授權編輯UI中TreeView選單重複選取的BUG
    //    public void setTreeView(Tree_Node Root, int extend = 0)//設定Node被選擇
    //    {
    //        if (Root.Nodes.Count == 0)
    //        {
    //            String NodeData = "";
    //            Tree_Node Node = Root;
    //            if ((Node.m_tree_level >= 2) || (Node.m_tree_level == -1))
    //            {
    //                if (extend > 0)
    //                {
    //                    NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                }
    //                else
    //                {
    //                    NodeData = Node.m_id + "";//卡
    //                }

    //                for (int i = 0; i < m_ALuser_car_group_detailed.Count; i++)
    //                {
    //                    String Data = m_ALuser_car_group_detailed[i].ToString();
    //                    if ((NodeData == Data) && (!m_blnchexkNode[i]))//修正授權編輯UI中TreeView選單重複選取的BUG if (NodeData == Data)
    //                    {
    //                        m_blnchexkNode[i] = true;//修正授權編輯UI中TreeView選單重複選取的BUG 
    //                        Node.Checked = true;
    //                        break;
    //                    }
    //                }
    //            }
    //        }

    //        foreach (Tree_Node Node in Root.Nodes)
    //        {
    //            if (Node.Nodes.Count == 0)//樹的最後節點
    //            {
    //                String NodeData = "";
    //                if ((Node.m_tree_level >= 2) || (Node.m_tree_level == -1))//2017/09/28 if (Node.m_tree_level >= 2)//>=2 才是 人的卡 或 車的卡 
    //                {
    //                    /*
    //                    if (Node.m_tree_level == 2)//人的卡
    //                    {
    //                        NodeData = Node.m_unit + "," + Node.m_id + "," + 2;
    //                    }
    //                    else//車的卡
    //                    {
    //                        NodeData = Node.m_unit + "," + Node.m_id + "," + 3;
    //                    }
    //                    */
    //                    if (extend > 0)
    //                    {
    //                        NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                    }
    //                    else
    //                    {
    //                        NodeData = Node.m_id + "";//卡
    //                    }

    //                    for (int i = 0; i < m_ALuser_car_group_detailed.Count; i++)
    //                    {
    //                        String Data = m_ALuser_car_group_detailed[i].ToString();
    //                        if ((NodeData == Data) && (!m_blnchexkNode[i]))//修正授權編輯UI中TreeView選單重複選取的BUG if (NodeData == Data)
    //                        {
    //                            m_blnchexkNode[i] = true;//修正授權編輯UI中TreeView選單重複選取的BUG
    //                            Node.Checked = true;
    //                            break;
    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                setTreeView(Node, extend);
    //            }
    //        }
    //        return;
    //    }
    //    public void setTreeView(TreeView TV, int extend = 0)//設定Node被選擇，必須從ROOT開始搜尋，所以要傳遞TreeView
    //    {
    //        //---
    //        //修正授權編輯UI中TreeView選單重複選取的BUG
    //        m_blnchexkNode = new bool[m_ALuser_car_group_detailed.Count];
    //        for (int i = 0; i < m_blnchexkNode.Length; i++)
    //        {
    //            m_blnchexkNode[i] = false;
    //        }
    //        //---修正授權編輯UI中TreeView選單重複選取的BUG

    //        foreach (Tree_Node Node in TV.Nodes)
    //        {
    //            setTreeView(Node, extend);
    //        }
    //    }
    //    public void getTreeView(Tree_Node Root, int extend = 0)//取得被選擇的Node
    //    {
    //        if (Root.Nodes.Count==0)
    //        {
    //            String NodeData = "";
    //            Tree_Node Node = Root;
    //            if ((Node.m_tree_level >= 2) || (Node.m_tree_level == -1))
    //            {
    //                if (extend > 0)
    //                {
    //                    NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                }
    //                else
    //                {
    //                    NodeData = Node.m_id + "";//卡
    //                }

    //                if (NodeData != "")
    //                {
    //                    m_ALuser_car_group_detailed.Add(NodeData);
    //                }
    //            }
    //        }

    //        foreach (Tree_Node Node in Root.Nodes)
    //        {
    //            if (Node.Checked == true)
    //            {
    //                if (Node.Nodes.Count == 0)//樹的最後節點
    //                {
    //                    String NodeData = "";
    //                    if ((Node.m_tree_level >= 2) || (Node.m_tree_level == -1))//2017/09/28 if (Node.m_tree_level >= 2)//>=2 才是 人的卡 或 車的卡 
    //                    {
    //                        /*
    //                        if (Node.m_tree_level == 2)//人的卡
    //                        {
    //                            NodeData = Node.m_unit + "," + Node.m_id;
    //                        }
    //                        else//車的卡
    //                        {
    //                            NodeData = Node.m_unit + "," + Node.m_id;
    //                        }
    //                        */
    //                        if (extend > 0)
    //                        {
    //                            NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                        }
    //                        else
    //                        {
    //                            NodeData = Node.m_id + "";//卡
    //                        }

    //                        if (NodeData != "")
    //                        {
    //                            m_ALuser_car_group_detailed.Add(NodeData);
    //                        }
    //                    }
    //                }//if (Node.Nodes.Count == 0)
    //                else
    //                {
    //                    if (Node.Checked == true)
    //                    {
    //                        getTreeView(Node, extend);
    //                    }
    //                }
    //            }//if (Node.Checked == true)
    //        }
    //        return;
    //    }
    //    public void getTreeView(TreeView TV, int extend = 0)//取得被選擇的Node，必須從ROOT開始搜尋，所以要傳遞TreeView
    //    {
    //        m_ALuser_car_group_detailed.Clear();
    //        foreach (Tree_Node Node in TV.Nodes)
    //        {
    //            if (Node.Checked == true)
    //            {
    //                getTreeView(Node, extend);
    //            }
    //        }
    //    }
    //}

    //public class SQL_V09Device2Tree_Node
    //{

    //    /*
    //    //根,[控制器]
    //    m_id            ->  id
    //    m_unit          ->  unit=0
    //    m_tree_level    ->  1
    //    */
    //    /*
    //    //子(非根),[門、模組]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  2 or 3
    //    */

    //    /*
    //    未知設備定義
    //        控制器->(沒有門) amount = 0
    //        門區-> (下面沒有模組) SELECT id, alias, is_connected,(SELECT COUNT(*) FROM device WHERE uid = d.id) AS module_count FROM device AS d WHERE type = 2
    //    */

    //    public ArrayList m_ALRoot = new ArrayList();//控制器
    //    public ArrayList m_ALChild = new ArrayList();//控制器+門區+模組
    //    public SQL_V09Device2Tree_Node(String StrFilter="")//建構子
    //    {
    //        m_ALRoot.Clear();
    //        m_ALChild.Clear();

    //        String SQL = "";

    //        //---
    //        //找出所有控制器資料
    //        SQL = "SELECT alias,id,ip,port,serial_number,amount,model_code,is_connected,resource_id,encryption_key_switch_level FROM device WHERE uid = 0;";
    //        MySqlDataReader Reader_Root = MySQL.GetDataReader(SQL);
    //        while (Reader_Root.Read())
    //        {
    //            Tree_Node tmp_Node = null;
    //            String StrName = "";
    //            String StrAmount=Reader_Root["amount"].ToString();
    //            int intencryption_key_switch_level= Int32.Parse(Reader_Root["encryption_key_switch_level"].ToString());
    //            if (StrAmount.Length==0)
    //            {
    //                StrAmount = "0";
    //            }
    //            if (Int32.Parse(StrAmount) >0)
    //            {
    //                String StrModel = "";
    //                for (int i=0;i< HW_Net_API.m_ALDM_ID.Count;i++)
    //                {
    //                    if (HW_Net_API.m_ALDM_ID[i].ToString() == Reader_Root["model_code"].ToString())
    //                    {
    //                        StrModel = HW_Net_API.m_ALDM_Name[i].ToString();
    //                        break;
    //                    }
    //                }

    //                //---
    //                //設備列表新增encryption_key_switch_level資訊
    //                if (intencryption_key_switch_level==0)
    //                {
    //                    StrName = String.Format("{0}({1}_{2})", Reader_Root["alias"].ToString(), StrModel, String.Format("{0:X}", Int64.Parse(Reader_Root["serial_number"].ToString())));
    //                }
    //                else
    //                {
    //                    StrName = String.Format("{0}({1}_{2})    [Security L{3}]", Reader_Root["alias"].ToString(), StrModel, String.Format("{0:X}", Int64.Parse(Reader_Root["serial_number"].ToString())), intencryption_key_switch_level);
    //                }
    //                //---設備列表新增encryption_key_switch_level資訊

    //                tmp_Node = new Tree_Node(Int32.Parse(Reader_Root["id"].ToString()), StrName, 0, 1, Reader_Root["resource_id"].ToString());
    //                if(Int32.Parse(Reader_Root["is_connected"].ToString())>0)
    //                {
    //                    tmp_Node.ForeColor = Color.Blue;
    //                    tmp_Node.m_ColorBackup = Color.Blue;
    //                }
    //                else
    //                {
    //                    tmp_Node.ForeColor = Color.Red;
    //                    tmp_Node.m_ColorBackup = Color.Red;
    //                }
    //            }
    //            else
    //            {
    //                StrName = String.Format("{0}({1}:{2})", Reader_Root["alias"].ToString(), Reader_Root["ip"].ToString(), Reader_Root["port"].ToString());
    //                tmp_Node = new Tree_Node(Int32.Parse(Reader_Root["id"].ToString()), StrName, 0, 1, "unknow");
    //            }

    //            m_ALRoot.Add(tmp_Node);
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Root.Close();
    //        //---找出所有控制器資料

    //        //---
    //        //找出所有門區
    //        ArrayList ALMuid = new ArrayList();
    //        String StrMuid = "";
    //        ALMuid.Clear();
    //        //---
    //        //實作如果沒有指紋模組不顯示上層門區資訊
    //        if (StrFilter == "")
    //        {
    //            SQL = "SELECT uid FROM device WHERE type=3 GROUP BY uid;";
    //        }
    //        else
    //        {
    //            SQL = String.Format("SELECT B.uid AS uid,F.model AS model FROM (SELECT uid,model_code FROM device AS d WHERE type=3 ORDER BY alias) AS B INNER JOIN (SELECT model FROM fd_models WHERE type IN ({0})) AS F ON (B.model_code=F.model);", StrFilter);//修改SQL_V09Device2Tree_Node類別支援只單純顯示指紋模組
    //        }
    //        //---實作如果沒有指紋模組不顯示上層門區資訊
    //        MySqlDataReader Reader_Child01 = MySQL.GetDataReader(SQL);
    //        while (Reader_Child01.Read())
    //        {
    //            //---
    //            //實作如果沒有指紋模組不顯示上層門區資訊
    //            if (StrMuid.Length==0)
    //            {
    //                StrMuid = Reader_Child01[0].ToString();
    //            }
    //            else
    //            {
    //                StrMuid += "," + Reader_Child01[0].ToString();
    //            }
    //            //---實作如果沒有指紋模組不顯示上層門區資訊
    //            ALMuid.Add(Reader_Child01[0].ToString());
    //        }
    //        Reader_Child01.Close();

    //        //---
    //        //實作如果沒有指紋模組不顯示上層門區資訊
    //        if (StrFilter == "")
    //        {
    //            SQL = "SELECT alias,id,ip,port,serial_number,amount,model_code,is_connected,uid,type FROM device AS d WHERE type=2 ORDER BY alias;";
    //        }
    //        else
    //        {
    //            if(StrMuid.Length==0)
    //            {
    //                StrMuid = "-1";
    //            }
    //            //---
    //            //指紋傳送UI門區列表顯示門區名稱和區域一致
    //            //SQL = String.Format("SELECT alias,id,ip,port,serial_number,amount,model_code,is_connected,uid,type FROM device AS d WHERE type=2 AND id IN ({0}) ORDER BY alias;", StrMuid);
    //            SQL = String.Format("SELECT d.name AS alias, b.id AS id, b.ip AS ip, b.port AS port, b.serial_number AS serial_number, b.amount AS amount, b.model_code AS model_code, b.is_connected AS is_connected, b.uid AS uid, b.type AS type FROM (SELECT alias, id, ip, port, serial_number, amount, model_code, is_connected, uid, type, resource_id FROM device WHERE type = 2 AND id IN({0}) ORDER BY alias) AS b INNER JOIN (SELECT identifier, name FROM door) AS d ON d.identifier = b.resource_id;", StrMuid);
    //            //---指紋傳送UI門區列表顯示門區名稱和區域一致
    //        }
    //        //---實作如果沒有指紋模組不顯示上層門區資訊
    //        MySqlDataReader Reader_Child02 = MySQL.GetDataReader(SQL);
    //        while (Reader_Child02.Read())
    //        {
    //            Tree_Node tmp_Node = null;
    //            String StrName = Reader_Child02["alias"].ToString();
    //            tmp_Node = new Tree_Node(Int32.Parse(Reader_Child02["id"].ToString()), StrName, Int32.Parse(Reader_Child02["uid"].ToString()), Int32.Parse(Reader_Child02["type"].ToString()), "");
    //            if (Int32.Parse(Reader_Child02["is_connected"].ToString()) > 0)
    //            {
    //                tmp_Node.ForeColor = Color.Blue;
    //                tmp_Node.m_ColorBackup = Color.Blue;
    //                tmp_Node.m_data = "";
    //            }
    //            else
    //            {
    //                tmp_Node.ForeColor = Color.Black;
    //                tmp_Node.m_ColorBackup = Color.Black;
    //                tmp_Node.m_data = "unknow";
    //            }
    //            for (int i = 0; i < ALMuid.Count; i++)
    //            {
    //                if ((ALMuid[i].ToString() == Reader_Child02["id"].ToString()) && Int32.Parse(Reader_Child02["is_connected"].ToString()) ==0 )
    //                {
    //                    tmp_Node.ForeColor = Color.Red;
    //                    tmp_Node.m_ColorBackup = Color.Red;
    //                    tmp_Node.m_data = "";
    //                    break;
    //                }
    //            }
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child02.Close();
    //        //---找出所有門區

    //        //---
    //        //找出所有模組
    //        //---
    //        //實作如果沒有指紋模組不顯示上層門區資訊
    //        if (StrFilter=="")
    //        {
    //            SQL = "SELECT alias,id,ip,port,serial_number,amount,model_code,is_connected,uid,type FROM device AS d WHERE type=3 ORDER BY alias;";
    //        }
    //        else
    //        {
    //            SQL = String.Format("SELECT B.alias AS alias,B.id AS id,B.ip AS ip,B.port AS port,B.serial_number AS serial_number,B.amount AS amount,B.model_code AS model_code,B.is_connected AS is_connected,B.uid AS uid,B.type AS type,F.model_name AS model_name FROM (SELECT alias,id,ip,port,serial_number,amount,model_code,is_connected,uid,type FROM device AS d WHERE type=3 ORDER BY alias) AS B INNER JOIN (SELECT model_name,model FROM fd_models WHERE type IN ({0})) AS F ON (B.model_code=F.model);", StrFilter);//修改SQL_V09Device2Tree_Node類別支援只單純顯示指紋模組
    //        }
    //        //---實作如果沒有指紋模組不顯示上層門區資訊          
    //        MySqlDataReader Reader_Child03 = MySQL.GetDataReader(SQL);
    //        while (Reader_Child03.Read())
    //        {
    //            Tree_Node tmp_Node = null;
    //            String StrModel = "";
    //            for (int i = 0; i < HW_Net_API.m_ALDM_ID.Count; i++)
    //            {
    //                if (HW_Net_API.m_ALDM_ID[i].ToString() == Reader_Child03["model_code"].ToString())
    //                {
    //                    StrModel = HW_Net_API.m_ALDM_Name[i].ToString();
    //                    break;
    //                }
    //            }
    //            String StrName = String.Format("{0}({1}_{2})", Reader_Child03["alias"].ToString(), StrModel, String.Format("{0:X}", Int64.Parse(Reader_Child03["serial_number"].ToString())));
    //            tmp_Node = new Tree_Node(Int32.Parse(Reader_Child03["id"].ToString()), StrName, Int32.Parse(Reader_Child03["uid"].ToString()), Int32.Parse(Reader_Child03["type"].ToString()), "");

    //            if (Int32.Parse(Reader_Child03["is_connected"].ToString()) > 0)
    //            {
    //                tmp_Node.ForeColor = Color.Blue;
    //                tmp_Node.m_ColorBackup = Color.Blue;
    //                tmp_Node.m_data = "";
    //            }
    //            else
    //            {
    //                tmp_Node.ForeColor = Color.Red;
    //                tmp_Node.m_ColorBackup = Color.Red;
    //                tmp_Node.m_data = "";
    //            }
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child03.Close();
    //        //---找出所有模組

    //    }
    //}
    //public class V09DeviceTree_NodeFun
    //{
    //    public int m_intSelect;
    //    public ArrayList m_ALget = new ArrayList();//取出節點要存放到DB的資訊[ 目前因為DB尚未決定所以資料室亂放的 at 2016/09/19 by jash ]
    //    public ArrayList m_ALposition = new ArrayList();//暫存檔案用

    //    public V09DeviceTree_NodeFun()
    //    {
    //        m_intSelect = 0;
    //    }
    //    public void TreeView_Add_RootNode(TreeView treeview, Tree_Node tmp)//增加根節點函數
    //    {
    //        treeview.Nodes.Add(tmp);
    //    }
    //    public void Recursive_Add(Tree_Node n, Tree_Node F, Tree_Node tmp)//遞迴增加子節點函數
    //    {
    //        if (n == F)
    //        {
    //            n.Nodes.Add(tmp);
    //        }
    //        else
    //        {
    //            foreach (Tree_Node tn in n.Nodes)
    //            {
    //                Recursive_Add(tn, F, tmp);
    //            }
    //        }
    //    }
    //    public void TreeView_Add_Node(TreeView treeview, Tree_Node F, Tree_Node tmp)//增加子節點函數
    //    {
    //        TreeNodeCollection nodes = treeview.Nodes;
    //        foreach (Tree_Node n in nodes)
    //        {
    //            Recursive_Add(n, F, tmp);
    //        }
    //    }

    //    public ArrayList m_ALmodel_detailed = new ArrayList();
    //    public ArrayList m_ALmodel_detailed_MT = new ArrayList();//傳送指紋要針對控制器，分別開不同獨立子程序動作的資料變數
    //    public bool[] m_blnchexkNode = null;//修正授權編輯UI中TreeView選單重複選取的BUG
    //    //---
    //    //統計要傳送模組數量和相對應的id值
    //    public void getTreeView(Tree_Node Root, int extend = 0)//取得被選擇的Node
    //    {
    //        if (Root.Nodes.Count == 0)
    //        {
    //            String NodeData = "";
    //            String NodeData_MT = "";
    //            Tree_Node Node = Root;

    //            if ((Node.m_tree_level >= 3) || (Node.m_tree_level == -1))
    //            {
    //                if (extend > 0)
    //                {
    //                    NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                }
    //                else
    //                {
    //                    NodeData = Node.m_id + "";//模組
    //                    NodeData_MT = Node.m_id + "," + Node.m_data;//模組+控制器Res_id
    //                }

    //                if (NodeData != "")
    //                {
    //                    m_ALmodel_detailed.Add(NodeData);
    //                    m_ALmodel_detailed_MT.Add(NodeData_MT);
    //                }
    //            }
    //        }

    //        foreach (Tree_Node Node in Root.Nodes)
    //        {
    //            if (Node.Checked == true)
    //            {
    //                if (Node.Nodes.Count == 0)//樹的最後節點
    //                {
    //                    String NodeData = "";
    //                    String NodeData_MT = "";
    //                    if ((Node.m_tree_level >= 3) || (Node.m_tree_level == -1))//2017/09/28 if (Node.m_tree_level >= 2)//>=2 才是 人的卡 或 車的卡 
    //                    {
    //                        if (extend > 0)
    //                        {
    //                            NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                        }
    //                        else
    //                        {
    //                            NodeData = Node.m_id + "";//模組
    //                            NodeData_MT = Node.m_id + "," + Node.m_data;//模組+控制器Res_id
    //                        }

    //                        if (NodeData != "")
    //                        {
    //                            m_ALmodel_detailed.Add(NodeData);
    //                            m_ALmodel_detailed_MT.Add(NodeData_MT);
    //                        }
    //                    }
    //                }//if (Node.Nodes.Count == 0)
    //                else
    //                {
    //                    if (Node.Checked == true)
    //                    {
    //                        getTreeView(Node, extend);
    //                    }
    //                }
    //            }//if (Node.Checked == true)
    //        }
    //        return;
    //    }
    //    public void getTreeView(TreeView TV, int extend = 0)//取得被選擇的Node，必須從ROOT開始搜尋，所以要傳遞TreeView
    //    {
    //        m_ALmodel_detailed.Clear();
    //        m_ALmodel_detailed_MT.Clear();
    //        foreach (Tree_Node Node in TV.Nodes)
    //        {
    //            if (Node.Checked == true)
    //            {
    //                getTreeView(Node, extend);
    //            }
    //        }
    //    }
    //    //---統計要傳送模組數量和相對應的id值
    //}

    ////---
    ////實作指紋傳送UI ~ 建立指紋用機種過濾SQL Class
    //public class SQL_DeptFingerprint2Tree_Node
    //{
    //    /*
    //    //根,[部門]
    //    m_id            ->  id
    //    m_unit          ->  0
    //    m_tree_level    ->  0
    //    */
    //    /*
    //    //子(非根),[部門]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  1
    //    */
    //    /*
    //    //子(非根),[人的指紋]
    //    m_id            ->  id
    //    m_unit          ->  unit
    //    m_tree_level    ->  2
    //    */
    //    public ArrayList m_ALRoot = new ArrayList();//部門
    //    public ArrayList m_ALChild = new ArrayList();//部門+人的指紋
    //    public SQL_DeptFingerprint2Tree_Node(String StrFilter= "1,2")
    //    {
    //        String SQL = "";
    //        SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit=0 ORDER BY id;";//查根部門
    //        if (GetWebManage.p_manage_unlimited == "x")//所有UI增加部門和門區的可是範圍限制功能	
    //        {//GetWebManage.p_manage_authorized_department.m_Strdata
    //            SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit=0 AND ( id IN (" + GetWebManage.p_manage_authorized_department.m_Strdata + ") ) ORDER BY id;";//查根部門
    //        }
    //        MySqlDataReader Reader_Root = MySQL.GetDataReader(SQL);
    //        while (Reader_Root.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Root["id"].ToString()), Reader_Root["name"].ToString(), 0, 0, "");//id,NAME,父親,階層,資料
    //            m_ALRoot.Add(tmp_Node);
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Root.Close();

    //        SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit>0 ORDER BY id;";//查子部門
    //        if (GetWebManage.p_manage_unlimited == "x")//所有UI增加部門和門區的可是範圍限制功能	
    //        {//GetWebManage.p_manage_authorized_department.m_Strdata
    //            SQL = "SELECT id, name, unit FROM department WHERE (state=1 OR state=2) AND unit>0 AND (id IN (" + GetWebManage.p_manage_authorized_department.m_Strdata + ") ) ORDER BY id;";//查子部門
    //        }
    //        MySqlDataReader Reader_Child00 = MySQL.GetDataReader(SQL);
    //        while (Reader_Child00.Read())
    //        {
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Child00["id"].ToString()), Reader_Child00["name"].ToString(), Int32.Parse(Reader_Child00["unit"].ToString()), 1, "");//id,NAME,父親,階層,資料
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child00.Close();

    //        SQL = String.Format("SELECT FBase01.id AS id, Base01.name AS uname, Base01.unit AS unit, Base01.card_code AS card_code,FBase01.name AS fname, FBase01.type AS dtype FROM (SELECT * FROM ( SELECT cfuc.card_id AS id,u.name AS name,d_d.dep_id AS unit,card.card_code AS card_code FROM user AS u,department_detail AS d_d,card_for_user_car AS cfuc LEFT JOIN card ON cfuc.card_id = card.id WHERE (u.state=1 OR u.state=2 ) AND (cfuc.car_id IS NULL) AND (cfuc.user_id=u.id) AND (d_d.car_id IS NULL) AND (d_d.user_id=u.id) ) AS Base) AS Base01,(SELECT * FROM ( SELECT fp.uid AS id,fp.CL_uid AS c_id,fpt.Name AS name,fdt.name AS type FROM fingerprint_list AS fp,fingerprint_type AS fpt,fd_type AS fdt WHERE (fp.state=2) AND ( (fpt.uid=(fp.FT_uid%10)) OR ((fp.Ft_uid-(10*(fp.fd_type-1)))=fpt.uid) ) AND (fp.fd_type=fdt.id) AND (fp.fd_type IN ({0}))) AS FBase) AS FBase01 WHERE (Base01.id=FBase01.c_id);", StrFilter);//1,2; 1 ; 2 //修正指紋傳送列表查詢SQL
    //        /*
    //        SELECT * FROM ( SELECT cfuc.card_id AS id,u.name AS name,d_d.dep_id AS unit,card.card_code AS card_code FROM user AS u,department_detail AS d_d,card_for_user_car AS cfuc LEFT JOIN card ON cfuc.card_id = card.id WHERE (u.state=1 OR u.state=2 ) AND (cfuc.car_id IS NULL) AND (cfuc.user_id=u.id) AND (d_d.car_id IS NULL) AND (d_d.user_id=u.id) ) AS Base;
    //        SELECT * FROM ( SELECT fp.uid AS id,fp.CL_uid AS c_id,fpt.Name AS name,fdt.name AS type FROM fingerprint_list AS fp,fingerprint_type AS fpt,fd_type AS fdt WHERE (fpt.uid=(fp.FT_uid%10)) AND (fp.fd_type=fdt.id) AND (fp.fd_type={0})) AS FBase
    //        */
    //        MySqlDataReader Reader_Child01 = MySQL.GetDataReader(SQL);
    //        while (Reader_Child01.Read())
    //        {
    //            String name = Reader_Child01["uname"].ToString() + "~" + Reader_Child01["card_code"].ToString() + "(" + Reader_Child01["fname"].ToString() + ") "+ Reader_Child01["dtype"].ToString();
    //            Tree_Node tmp_Node = new Tree_Node(Int32.Parse(Reader_Child01["id"].ToString()), name, Int32.Parse(Reader_Child01["unit"].ToString()), 2, "");//id,NAME,父親,階層,資料
    //            m_ALChild.Add(tmp_Node);
    //        }
    //        Reader_Child01.Close();
    //    }
    //}
    //public class DeptFingerprintTree_NodeFun
    //{
    //    public int m_intSelect;
    //    public ArrayList m_ALget = new ArrayList();
    //    public ArrayList m_ALposition = new ArrayList();
    //    public DeptFingerprintTree_NodeFun()
    //    {
    //        m_intSelect = 0;
    //    }
    //    public void TreeView_Add_RootNode(TreeView treeview, Tree_Node tmp)//增加根節點函數
    //    {
    //        treeview.Nodes.Add(tmp);
    //    }
    //    public void Recursive_Add(Tree_Node n, Tree_Node F, Tree_Node tmp)//遞迴增加子節點函數
    //    {
    //        if (n == F)
    //        {
    //            n.Nodes.Add(tmp);
    //        }
    //        else
    //        {
    //            foreach (Tree_Node tn in n.Nodes)
    //            {
    //                Recursive_Add(tn, F, tmp);
    //            }
    //        }
    //    }
    //    public void TreeView_Add_Node(TreeView treeview, Tree_Node F, Tree_Node tmp)//增加子節點函數
    //    {
    //        TreeNodeCollection nodes = treeview.Nodes;
    //        foreach (Tree_Node n in nodes)
    //        {
    //            Recursive_Add(n, F, tmp);
    //        }
    //    }
    //    static public void SetChildNodeCheckedState(Tree_Node currNode, bool isCheckedOrNot)//設置子節點狀態
    //    {
    //        //http://www.cnblogs.com/luxiaoxun/p/3288003.html
    //        if (currNode.Nodes.Count == 0)//沒有子節點返回
    //        {
    //            /*
    //            if (isCheckedOrNot)
    //            {
    //                currNode.BackColor = Color.Yellow;
    //            }
    //            else
    //            {
    //                currNode.BackColor = Color.White;
    //            }
    //            */
    //            return;
    //        }
    //        foreach (Tree_Node tmpNode in currNode.Nodes)
    //        {
    //            /*
    //            if (isCheckedOrNot)
    //            {
    //                currNode.BackColor = Color.Red;
    //            }
    //            else
    //            {
    //                currNode.BackColor = Color.White;
    //            }
    //            */
    //            tmpNode.Checked = isCheckedOrNot;
    //            SetChildNodeCheckedState(tmpNode, isCheckedOrNot);
    //        }
    //    }
    //    static public void SetParentNodeCheckedState(Tree_Node currNode, bool isCheckedOrNot)//設置父節點狀態
    //    {
    //        //http://www.cnblogs.com/luxiaoxun/p/3288003.html
    //        if (currNode.Parent == null)//沒有父節點返回
    //            return;
    //        if (isCheckedOrNot) //如果當前節點被選中，則設置所有父節點都被選中
    //        {
    //            //--
    //            bool checkedFlag = true;
    //            foreach (Tree_Node tmpNode in currNode.Parent.Nodes)//當前節點的所有同層節點
    //            {
    //                if (tmpNode.Checked == false)
    //                {
    //                    checkedFlag = false;
    //                    break;
    //                }
    //            }
    //            /*
    //            if (checkedFlag)
    //            {
    //                currNode.Parent.BackColor = Color.Red;
    //            }
    //            else
    //            {
    //                currNode.Parent.BackColor = Color.Yellow;
    //            }
    //            */
    //            //--
    //            currNode.Parent.Checked = isCheckedOrNot;
    //            SetParentNodeCheckedState((Tree_Node)(currNode.Parent), isCheckedOrNot);
    //        }
    //        else //如果當前節點沒有被選中，則當其父節點的子節點有一個被選中時，父節點被選中，否則父節點不被選中
    //        {
    //            bool checkedFlag = false;
    //            foreach (Tree_Node tmpNode in currNode.Parent.Nodes)
    //            {
    //                if (tmpNode.Checked)
    //                {
    //                    checkedFlag = true;
    //                    break;
    //                }
    //            }
    //            //--
    //            /*
    //            if (checkedFlag)
    //            {
    //                currNode.Parent.BackColor = Color.Yellow;
    //            }
    //            else
    //            {
    //                currNode.Parent.BackColor = Color.White;
    //            }
    //            */
    //            //--
    //            currNode.Parent.Checked = checkedFlag;
    //            SetParentNodeCheckedState((Tree_Node)(currNode.Parent), checkedFlag);
    //        }
    //    }

    //    public ArrayList m_ALuser_car_group_detailed = new ArrayList();
    //    public bool[] m_blnchexkNode = null;//修正授權編輯UI中TreeView選單重複選取的BUG
    //    public void setTreeView(Tree_Node Root, int extend = 0)//設定Node被選擇
    //    {
    //        if (Root.Nodes.Count == 0)
    //        {
    //            String NodeData = "";
    //            Tree_Node Node = Root;
    //            if ((Node.m_tree_level >= 2) || (Node.m_tree_level == -1))
    //            {
    //                if (extend > 0)
    //                {
    //                    NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                }
    //                else
    //                {
    //                    NodeData = Node.m_id + "";//卡
    //                }

    //                for (int i = 0; i < m_ALuser_car_group_detailed.Count; i++)
    //                {
    //                    String Data = m_ALuser_car_group_detailed[i].ToString();
    //                    if ((NodeData == Data) && (!m_blnchexkNode[i]))//修正授權編輯UI中TreeView選單重複選取的BUG if (NodeData == Data)
    //                    {
    //                        m_blnchexkNode[i] = true;//修正授權編輯UI中TreeView選單重複選取的BUG 
    //                        Node.Checked = true;
    //                        break;
    //                    }
    //                }
    //            }
    //        }

    //        foreach (Tree_Node Node in Root.Nodes)
    //        {
    //            if (Node.Nodes.Count == 0)//樹的最後節點
    //            {
    //                String NodeData = "";
    //                if ((Node.m_tree_level >= 2) || (Node.m_tree_level == -1))//2017/09/28 if (Node.m_tree_level >= 2)//>=2 才是 人的卡 或 車的卡 
    //                {
    //                    /*
    //                    if (Node.m_tree_level == 2)//人的卡
    //                    {
    //                        NodeData = Node.m_unit + "," + Node.m_id + "," + 2;
    //                    }
    //                    else//車的卡
    //                    {
    //                        NodeData = Node.m_unit + "," + Node.m_id + "," + 3;
    //                    }
    //                    */
    //                    if (extend > 0)
    //                    {
    //                        NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                    }
    //                    else
    //                    {
    //                        NodeData = Node.m_id + "";//卡
    //                    }

    //                    for (int i = 0; i < m_ALuser_car_group_detailed.Count; i++)
    //                    {
    //                        String Data = m_ALuser_car_group_detailed[i].ToString();
    //                        if ((NodeData == Data) && (!m_blnchexkNode[i]))//修正授權編輯UI中TreeView選單重複選取的BUG if (NodeData == Data)
    //                        {
    //                            m_blnchexkNode[i] = true;//修正授權編輯UI中TreeView選單重複選取的BUG
    //                            Node.Checked = true;
    //                            break;
    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                setTreeView(Node, extend);
    //            }
    //        }
    //        return;
    //    }
    //    public void setTreeView(TreeView TV, int extend = 0)//設定Node被選擇，必須從ROOT開始搜尋，所以要傳遞TreeView
    //    {
    //        //---
    //        //修正授權編輯UI中TreeView選單重複選取的BUG
    //        m_blnchexkNode = new bool[m_ALuser_car_group_detailed.Count];
    //        for (int i = 0; i < m_blnchexkNode.Length; i++)
    //        {
    //            m_blnchexkNode[i] = false;
    //        }
    //        //---修正授權編輯UI中TreeView選單重複選取的BUG

    //        foreach (Tree_Node Node in TV.Nodes)
    //        {
    //            setTreeView(Node, extend);
    //        }
    //    }
    //    public void getTreeView(Tree_Node Root, int extend = 0)//取得被選擇的Node
    //    {
    //        if (Root.Nodes.Count == 0)
    //        {
    //            String NodeData = "";
    //            Tree_Node Node = Root;
    //            if ((Node.m_tree_level >= 2) || (Node.m_tree_level == -1))
    //            {
    //                if (extend > 0)
    //                {
    //                    NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                }
    //                else
    //                {
    //                    NodeData = Node.m_id + "";//卡
    //                }

    //                if (NodeData != "")
    //                {
    //                    m_ALuser_car_group_detailed.Add(NodeData);
    //                }
    //            }
    //        }

    //        foreach (Tree_Node Node in Root.Nodes)
    //        {
    //            if (Node.Checked == true)
    //            {
    //                if (Node.Nodes.Count == 0)//樹的最後節點
    //                {
    //                    String NodeData = "";
    //                    if ((Node.m_tree_level >= 2) || (Node.m_tree_level == -1))//2017/09/28 if (Node.m_tree_level >= 2)//>=2 才是 人的卡 或 車的卡 
    //                    {
    //                        /*
    //                        if (Node.m_tree_level == 2)//人的卡
    //                        {
    //                            NodeData = Node.m_unit + "," + Node.m_id;
    //                        }
    //                        else//車的卡
    //                        {
    //                            NodeData = Node.m_unit + "," + Node.m_id;
    //                        }
    //                        */
    //                        if (extend > 0)
    //                        {
    //                            NodeData = Node.m_id + "," + Node.m_tree_level;//2017/09/28
    //                        }
    //                        else
    //                        {
    //                            NodeData = Node.m_id + "";//卡
    //                        }

    //                        if (NodeData != "")
    //                        {
    //                            m_ALuser_car_group_detailed.Add(NodeData);
    //                        }
    //                    }
    //                }//if (Node.Nodes.Count == 0)
    //                else
    //                {
    //                    if (Node.Checked == true)
    //                    {
    //                        getTreeView(Node, extend);
    //                    }
    //                }
    //            }//if (Node.Checked == true)
    //        }
    //        return;
    //    }
    //    public void getTreeView(TreeView TV, int extend = 0)//取得被選擇的Node，必須從ROOT開始搜尋，所以要傳遞TreeView
    //    {
    //        m_ALuser_car_group_detailed.Clear();
    //        foreach (Tree_Node Node in TV.Nodes)
    //        {
    //            if (Node.Checked == true)
    //            {
    //                getTreeView(Node, extend);
    //            }
    //        }
    //    }
    //}
    ////---實作指紋傳送UI ~ 建立指紋用機種過濾SQL Class

}
