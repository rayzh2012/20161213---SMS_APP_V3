using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System;
//using IExcelDataReader;
//using Excel2=Excel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Reflection;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using System.IO;

//calling the marshal fucntion
using System.Runtime.InteropServices;
using Excel2 = Microsoft.Office.Interop.Excel;

namespace Twilio_win_1108
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Label label1;
        public string message;
        //public string accountSid = "ACf04feadcc22ed31672371d7d4ca3eb29";
        //public string authToken = "9b1d78ea7051df858a9b15ec67f7269a";
        //public string Twilio_num = "+116475592196";
        //public string service_num = "(416)797-8295";
        public string accountSid;
        public string authToken;
        public string Twilio_num;
        public string service_num;
        public int id=0;
        public string phoneNumber;
        public string clientName;
        public string OrderNum;
        string preName = "[name]", preOrderNum = "[Order#]";
        string proName = "";
        string[] proMsg = new string[5];

        //for importing and exporting to Excel
        public int vertical = 0;
        public int horizontal = 0;
        //string FileName = @"D:\Excel For Hang\Daily_Data_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
        object misValue = System.Reflection.Missing.Value;
        Microsoft.Office.Interop.Excel.Application appExl;
        Microsoft.Office.Interop.Excel.Workbook workbook;
        Microsoft.Office.Interop.Excel.Worksheet NwSheet;
        Microsoft.Office.Interop.Excel.Range ShtRange;

        string[] MsgfromXML;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = true;
            configRead();
           // openFileDialog1.ShowDialog();
           // openFileDialog1_FileOk_1();
           // Import_Evt();
            phoneNumber = txtPhone.Text.ToString();
            clientName = txtName.Text.ToString();

            /*
             * check if files existed. If not, created a new Excel Archive file, else
             * import the file.
             */
            Boolean isFileExisted = chkFileExisted();
            if (!isFileExisted)
            {
                Create_Excel_Evt();
            }
            Import_Evt();

            /*
             * load the messages from the XML file and then import to the
             */
           MsgfromXML = loadMsgfromXML(this);   
          
            //assign button.tag to each button
            btnSubmit1.Tag = "1";
            btnSubmit2.Tag = "2";
            btnSubmit3.Tag = "3";
            btnSubmit4.Tag = "4";
            btnSubmit5.Tag = "5";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private Boolean chkFileExisted()
        {
            Boolean isFileExisted = false;

            var path = path_builder();
            string _path = new Uri(path).LocalPath;

            if (File.Exists(_path))
            {
                isFileExisted = true;

            }

            return isFileExisted;

        }

      
        private void btnSubmit1_Onclick(object sender, EventArgs e)
        {
                      
            var phoneNumber = txtPhone.Text.ToString();
            var clientName = txtName.Text.ToString();
            var Twilio_num = "+2898060265";
            var service_num = "(416)797-8295";
            Button btn = (Button)sender;
            
            //message = "Hi " + clientName + " ,Your order has some problem, please call " + service_num + " for more details.";
            //loadMsgfromXML(this);
            message = AssignMsgbaseedOnButton(sender);
            msgReadtoPreview(message);          
        }

        private void btnSubmit2_Onclick(object sender, EventArgs e)
        {
            //message = "Hi " + txtName.Text.ToString()+" ,Your order is ready, Please pick up your product  " ;
            //loadMsgfromXML(this);
            message = AssignMsgbaseedOnButton(sender);
            msgReadtoPreview(message);
        }
        private void btnSubmit3_OnClick(object sender, System.EventArgs e)
        {
            //message = "Hi " + txtName.Text.ToString() + " ,message 3 ";
            //loadMsgfromXML(this);
            message = AssignMsgbaseedOnButton(sender);
            msgReadtoPreview(message);
            //add_record_to_dataview(id, phoneNumber, clientName, message);
        }

        private void btnSubmit4_OnClick(object sender, System.EventArgs e)
        {
            //loadMsgfromXML(this);
            //message = "Hi " + txtName.Text.ToString() + " ,message 4 ";
            //Button button = (Button)sender;
            //string buttonId = button.Name;
            //MessageBox.Show(buttonId);
            //char buttonid1 = buttonId[9];
            //message = MsgfromXML[(int)buttonId[9]-49];
            message = AssignMsgbaseedOnButton(sender);
            msgReadtoPreview(message);
            //add_record_to_dataview(id, phoneNumber, clientName, message);
        }

        private void btnSubmit5_OnClick(object sender, System.EventArgs e)
        {
            //message = "Hi " + txtName.Text.ToString() + " ,message 5 ";           
            //loadMsgfromXML(this);
            message = AssignMsgbaseedOnButton(sender);
            msgReadtoPreview(message);
            //add_record_to_dataview(id, phoneNumber, clientName, message);
        }
        private void btnSend_OnClick(object sender, System.EventArgs e)
        {
            //send the messages after the preview action
            //MessageBox.Show(txtPreview.Text);
            MsgboxYesNo();
            //send_msg(txtPreview.Text);
            btnExport_Click(sender, e);
            //  export_evt(sender, e);
        }
        // DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);

        private string AssignMsgbaseedOnButton(object sender)
        {
            MsgfromXML = loadMsgfromXML(this); 
            Button button = (Button)sender;
            string buttonId = button.Name;
            //MessageBox.Show(buttonId);
            char buttonid1 = buttonId[9];
            //Replace all message with tags with the approariate number and name
            MsgfromXML = ReplaceTag(MsgfromXML);
            message = MsgfromXML[(int)buttonId[9] - 49];
           
            return message;
        }
        
        //read the configuration settings from the configuration XML
        private void configRead()
        {        
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("config.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/button");
            XmlDocument xmlDoc2 = new XmlDocument();
            xmlDoc2.Load("config.xml");
            XmlNodeList nodeList2 = xmlDoc2.DocumentElement.SelectNodes("/Table/Table_Admin");
       
            string proText = "", proName = "";

            foreach (XmlNode node in nodeList)
            {
                proName = node.SelectSingleNode("name").InnerText;
                proText = node.SelectSingleNode("text").InnerText;
               // MessageBox.Show(proName.ToString());
                
                //price = node.SelectSingleNode("").InnerText;
                //MessageBox.Show("The name is " + proName + " the text of the button " + proText);
                AddTextinButton(this,proName,proText);
            }

            ////read the msg from the XML config
            //string[] proMsg = new string[5];
            //int i = 0;
            foreach (XmlNode node in nodeList2)
            {
               //Load Twilio Account Variables from the XML configuration sheet
                accountSid = node.SelectSingleNode("accountID").InnerText;
                authToken = node.SelectSingleNode("authToken").InnerText;
                Twilio_num = node.SelectSingleNode("TwilioNumber").InnerText;
                service_num = node.SelectSingleNode("AgentNumber").InnerText;            
            }
        }
        
        private void AddTextinButton(Control parent, string proName, string proText){
            foreach (Control c in parent.Controls)
            {
                if(c.GetType() == typeof(Button))
                {
                   // MessageBox.Show(c.Text);
                    if (c.Name == proName)
                    {
                        c.Text = proText;
                    }
                }
                else
                {
                    AddTextinButton(c,proName,proText);
                }
            }
        }

        private string[] loadMsgfromXML(Control parent)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("config.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/button");
            //read the msg from the XML config
          
            int i = 0;
   
            foreach (XmlNode node in nodeList)
            {
                proName = node.SelectSingleNode("name").InnerText;
                proMsg[i] = node.SelectSingleNode("msg").InnerText;

                //MessageBox.Show(proTemplate.ToString());
                foreach (Control c in parent.Controls)
                {
                    if (c.GetType() == typeof(Button))
                    {
                        // MessageBox.Show(c.Text);
                        if (c.Name == proName)
                        {
                           // c.Text = proText;
                            //message = proMsg[i];
                            i=i+1;
                        }     
                    }
                    else
                    {
                        //loadMsgfromXML(c);
                    }
                }
               
            }
            return proMsg;
        }

        //private void chkBtnID(Control parent)
        //{
        //    //check the button ID against the button name once each button is clicked
        //     foreach (Control c in parent.Controls)
        //        {
        //            if (c.GetType() == typeof(Button))
        //            {                   
        //                var btnName = c.Name.ToString();
        //                var btnName2 = "btnSubmit" + i.ToString();
                     
        //                MessageBox.Show("control name = "+btnName+" ")
        //                if (c.Name == "btnSubmit" + i.ToString())
        //                {
        //                    //c.Text = proMsg[i];
        //                    message = proMsg;
        //                }
        //            }
        //            else
        //            {
                        
        //            }
         
        //}

        private void AddMsginDatagrid(Control parent,string msg)
        {
             
        }

        //Read the data from the Excel files using ExcelDataReader
        //https://github.com/ExcelDataReader/ExcelDataReader
    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }      
        private void MsgboxYesNo()
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to send this message?",
                      "Confirmation Popup", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes: send_msg(txtPreview.Text); break;
                case DialogResult.No: break;
            }
        }


        private void msgReadtoPreview(string message)
        {
            //preview the messages if it's not null or empty
            if (!string.IsNullOrEmpty(message))
            {
                txtPreview.Text = message;
                
            }
            //get the latest id of the record
            id = dataGridView1.Rows.Count;

        }
        private void add_record_to_dataview(int id, string phone,string name,string content)
        {
           // dataGridView1.Rows.Add("", phone, name, content, DateTime.Now);
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            DataRow drToAdd = dataTable.NewRow();
            id = id++;
            drToAdd["#"] = id.ToString();
            drToAdd["Phone"] = phone;
            drToAdd["Name"] = txtName.Text.ToString();
            drToAdd["Order Number"] = txtOrderNum.Text.ToString();
            drToAdd["Content"] = content;
            drToAdd["Send Datetime"] = DateTime.Now;
           // drToAdd["Name"] = "Value2";

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();

          //  dataGridView1.Rows.Add("", phone, name, content, DateTime.Now);
        }


       /* private void send_msg(string message)
        {
           
            var twilio = new Twilio.TwilioRestClient(accountSid, authToken);
            //msgReadtoPreview(message);
            //add the contact record into tthe datagridview
            add_record_to_dataview(id, phoneNumber, clientName, message);
            var sendmsg = twilio.SendMessage(
                "+12898060265", // From (Replace with your Twilio number)
                phoneNumber, // To (Replace with your phone number)
                message
                );
            //export to excel file
            export_evt();

        }*/
        private void send_msg(string message)
        {
            var phoneNumber = txtPhone.Text.ToString();
            TwilioClient.Init(accountSid, authToken);
            //msgReadtoPreview(message);
            //add the contact record into tthe datagridview
            add_record_to_dataview(id, phoneNumber, clientName, message);

            var sendmsg = MessageResource.Create(
                to: new PhoneNumber("+14166299386"),
                from: new PhoneNumber("+12898060265"),
                body: "Hello from C#");
            //export to excel file
            export_evt();
        }

        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

         private void btnImport_Click(object sender, EventArgs e)
        {
            Import_Evt();
        }

        private void openFileDialog1_FileOk_1()
        {
          //  string filePath = openFileDialog1.FileName;
            string filePath = "C:\\Users\\Hang.Wu\\Desktop\\Hang_IportExcel_n_displayongridview\\Hang_IportExcel_n_displayongridview\\Export_XL\\Daily_Data_2016_11_11.xlsx";
            string extension = Path.GetExtension(filePath);
            //string header = rbHeaderYes.Checked ? "YES" : "NO";
            string header = "YES";
            string conStr, sheetName;

            conStr = string.Empty;
            switch (extension)
            {

                //case ".xls": //Excel 97-03
                //    conStr = string.Format(Excel03ConString, filePath, header);
                //    break;

                case ".xlsx": //Excel 07
                    conStr = string.Format(Excel07ConString, filePath, header);
                    break;
            }

            //Get the name of the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    con.Close();
                }
            }

            //Read Data from the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandText = "SELECT * From [" + sheetName + "]";
                        cmd.Connection = con;
                        con.Open();
                        oda.SelectCommand = cmd;
                        oda.Fill(dt);
                        con.Close();

                        //Populate DataGridView.
                        dataGridView1.DataSource = dt;
                        
                    }
                }
            }
        }

        private void Import_Evt()
        {
            appExl = new Microsoft.Office.Interop.Excel.Application();

            var path = path_builder();
            string _path = new Uri(path).LocalPath;

            workbook = appExl.Workbooks.Open(_path, false, true, misValue, misValue, misValue, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, '\t', false, false, 0, false, true, 0);
            NwSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);

            ShtRange = NwSheet.UsedRange; //gives the used cells in sheet
            NwSheet = workbook.ActiveSheet;
            //int Cnum = 0;
            //int Rnum = 0;
            System.Data.DataTable dt = new System.Data.DataTable();

            Array myValues = (Array)ShtRange.Cells.Value2;
            if (myValues != null)
            {
                vertical = myValues.GetLength(0);
                horizontal = myValues.GetLength(1);
            }
            else
            {
                dt.Columns.AddRange(new DataColumn[20] {new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),new DataColumn("", typeof(DateTime)),
                    new DataColumn("", typeof(DateTime)),new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),
                    new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),
                    new DataColumn("", typeof(string)),new DataColumn("", typeof(string)),new DataColumn("", typeof(string)), new DataColumn("", typeof(string)), new DataColumn("",typeof(string)) });
                dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                //dt.Rows.Add();
                //dt.Rows.Add("", "", "", "");
                //dt.Rows.Add("", "", "", "");
                //this.dataGridView1.DataSource = dt;
            }

            // must start with index = 1
            // get header information
            for (int i = 1; i <= horizontal; i++)
            {
                dt.Columns.Add(new DataColumn(myValues.GetValue(1, i).ToString()));
            }

            // Get the row information
            for (int a = 2; a <= vertical; a++)
            {
                object[] poop = new object[horizontal];
                for (int b = 1; b <= horizontal; b++)
                {
                    poop[b - 1] = myValues.GetValue(a, b);
                }
                DataRow row = dt.NewRow();
                row.ItemArray = poop;
                dt.Rows.Add(row);
            }

            workbook.Close(true, misValue, misValue);
            appExl.Quit();
            releaseObject(NwSheet);
            releaseObject(workbook);
            releaseObject(appExl);

            dataGridView1.DataSource = dt;//DataSource to GrigView(Id:gvOne)
            //change type of the datagrid
            this.dataGridView1.Columns[5].ValueType = typeof(DateTime);

        }


        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

            //private void readExcel(){
        
            //}

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //read from excel
           // readExcel();
        }

        private string path_builder()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var path = Path.Combine(outPutDirectory, "Data\\Daily_Data_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
            
            return path;
        }

       

        //private void btnExport_Click(object sender, System.EventArgs e)
        //{
        //    if (dataGridView1.Rows.Count > 0)
        //    {
        //        try
        //        {
        //            // Bind Grid Data to Datatable
        //            DataTable dt = new DataTable();
        //            foreach (DataGridViewColumn col in dataGridView1.Columns)
        //            {
        //                dt.Columns.Add(col.HeaderText, col.ValueType);
        //            }
        //            int count = 0;
        //            foreach (DataGridViewRow row in dataGridView1.Rows)
        //            {
        //                if (count < dataGridView1.Rows.Count - 1)
        //                {
        //                    dt.Rows.Add();
        //                    foreach (DataGridViewCell cell in row.Cells)
        //                    {
        //                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
        //                    }
        //                }
        //                count++;
        //            }
        //            // Bind table data to Stream Writer to export data to respective folder
        //            //StreamWriter wr = new StreamWriter(@"C:\Users\Hang.Wu\Documents\Visual Studio 2012\Projects\20161124---Twilio_win_---excel_read_write\Twilio_win_1108\bin\Debug\Data\\Daily_Data_2016_11_11.xls");
        //           var path = path_builder();
        //           string _path = new Uri(path).LocalPath;
        //            StreamWriter wr = new StreamWriter(@_path);
        //            // Write Columns to excel file
        //            for (int i = 0; i < dt.Columns.Count; i++)
        //            {
        //                wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
        //            }
        //            wr.WriteLine();
        //            //write rows to excel file
        //            for (int i = 0; i < (dt.Rows.Count); i++)
        //            {
        //                for (int j = 0; j < dt.Columns.Count; j++)
        //                {
        //                    if (dt.Rows[i][j] != null)
        //                    {
        //                        wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
        //                    }
        //                    else
        //                    {
        //                        wr.Write("\t");
        //                    }
        //                }
        //                wr.WriteLine();
        //            }
        //            wr.Close();           
        //            lblSuccessMsg.Text = "Data Exported Successfully";
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Excel.Application Excel;
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    DataSet ds = new DataSet();
                    DataTable data = (DataTable)(dataGridView1.DataSource);
                    ds.Tables.Add(data);

                    ExportDataSetToExcel(ds);

                    label1.Text = "Data Exported Successfully";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void export_evt()
        {
            //Microsoft.Office.Interop.Excel.Application Excel;
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    DataSet ds = new DataSet();
                    DataTable data = (DataTable)(dataGridView1.DataSource);
             
                    ds.Tables.Add(data);
                    //remove automatically assigned Dataset properties, to avoid the 
                    //"DataTable already belongs to another DataSet" error

                    ds.Tables.Remove(data.TableName);

                    ExportDataSetToExcel(ds);

                    label1.Text = "Data Exported Successfully";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void ExportDataSetToExcel(DataSet ds)
        {
            appExl = new Microsoft.Office.Interop.Excel.Application();
            //workbook = appExl.Workbooks.Open(@"D:\Excel For Hang\data.xls");

            var path = path_builder();
            string _path = new Uri(path).LocalPath;
            //StreamWriter wr = new StreamWriter(@_path);

            workbook = appExl.Workbooks.Open(_path);
            NwSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);

            ShtRange = NwSheet.UsedRange; //gives the used cells in sheet
            NwSheet = workbook.ActiveSheet;
            foreach (DataTable table in ds.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                //Microsoft.Office.Interop.Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                //excelWorkSheet.Name = table.Tabledata;
                //ShtRange = NwSheet.UsedRange; //gives the used cells in sheet
                //NwSheet = workbook.ActiveSheet;
                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    NwSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        NwSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }

            workbook.Save();
            //(@"D:\Excel For Hang\data.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            workbook.Close();
            appExl.Quit();

            //remove datatables that associated with the dataset
            ds.Tables.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var path = path_builder();
            string _path = new Uri(path).LocalPath;


            Excel2.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            Excel2.Workbook xlWorkBook;
            Excel2.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel2.Worksheet)xlWorkBook.Worksheets.get_Item(1);
           
            //Define Column data
            xlWorkSheet.Cells[1, 1] = "#";
            xlWorkSheet.Cells[1, 2] = "Phone";
            xlWorkSheet.Cells[1, 3] = "Name";
            xlWorkSheet.Cells[1, 4] = "Order Number";   
            xlWorkSheet.Cells[1, 5] = "Content";
            xlWorkSheet.Cells[1, 6] = "Send Datetime";

            try
            {
                //excel save as
                // xlWorkBook.SaveAs("D:\\CSharp_Excel_Test\\Daily_Data_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.SaveAs(_path, Excel2.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel2.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                MessageBox.Show("Excel file created , you can find the file Daily_Data_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //import data
                Import_Evt();
            }
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            Import_Evt();
        }
      
        private void Create_Excel_Evt()
        {
            var path = path_builder();
            string _path = new Uri(path).LocalPath;


            Excel2.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Excel2.Workbook xlWorkBook;
            Excel2.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel2.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //Define Column data
            xlWorkSheet.Cells[1, 1] = "#";
            xlWorkSheet.Cells[1, 2] = "Phone";
            xlWorkSheet.Cells[1, 3] = "Name";
            xlWorkSheet.Cells[1, 4] = "Order Number";
            xlWorkSheet.Cells[1, 5] = "Content";
            xlWorkSheet.Cells[1, 6] = "Send Datetime";
            try
            {
                //excel save as
                // xlWorkBook.SaveAs("D:\\CSharp_Excel_Test\\Daily_Data_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.SaveAs(_path, Excel2.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel2.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                MessageBox.Show("Excel file created , you can find the file Daily_Data_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //import data
                Import_Evt();
            }
        }

        string[] Messages = new string[5];
        private string[] ReplaceTag(string[] MsgfromXML)
        {
            
            for (int i = 0; i < MsgfromXML.Count(); i++)
            {

                StringBuilder sb = new StringBuilder(MsgfromXML[i]);
                Messages[i] = MsgfromXML[i].Replace("[name]", txtName.Text.ToString()).Replace("[Name]", txtName.Text.ToString()).Replace("[Order#]",  txtOrderNum.Text.ToString()).Replace("[order#]", txtOrderNum.Text.ToString()).ToString();
               
                MsgfromXML[i] = MsgfromXML[i].Replace("name", txtName.Text.ToString());
                MsgfromXML[i] = MsgfromXML[i].Replace("[Name]", txtName.Text.ToString());
                MsgfromXML[i] = MsgfromXML[i].Replace("[Order#]", txtOrderNum.Text.ToString());
                MsgfromXML[i] = MsgfromXML[i].Replace("[order#]", txtOrderNum.Text.ToString());
                //MessageBox.Show(sb.ToString());
                //preName = txtName.Text.ToString();
                //preOrderNum = txtOrderNum.Text.ToString();
                //MessageBox.Show(preName + " " + preOrderNum);
            }
            return Messages;
        }


        }
        }
        



    

