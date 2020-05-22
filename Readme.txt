C#建立表單新專案基本框架範例[Custom_CS_WinForm_Framework]
步驟:
	00.修改.NET版本為4.6.1
	01.設定程式ICON
	02.使用IDE在方案下建立新專案
	03.修改預設表單的名稱從Form1 -> MainForm
	04.修改表單標題，使標題和版號連動
		InitMainForm()
	05.調整畫面大小
	06.新增資料庫模組~ SQLite
		因為引用X32的DLL，所以要調整專案編譯模式[專案屬性(滑鼠右鍵開啟)->建置頁籤 下 平台目標 選擇 x86]
	07.新增AES加解密模組
	08.XML設定檔
	09.語系模組
	10.載入現有UI元件函示庫
	11.製作安裝檔
code
	SetCPUCardParameter專案
	
installation
	WINRAR的自解壓檔
other
	存放『C#使用Sqlite.dll問題』教學