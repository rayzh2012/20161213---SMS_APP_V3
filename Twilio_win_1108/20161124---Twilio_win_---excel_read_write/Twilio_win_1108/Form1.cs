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
using Excel;

using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Reflection;
using ClosedXML.Excel;

using System.IO;


namespace Twilio_win_1108
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Label label1;
        public string message;
        public string accountSid = "ACf04feadcc22ed31672371d7d4ca3eb29";
        public string authToken = "9b1d78ea7051df858a9b15ec67f7269a";
        public string Twilio_num = "+116475592196";
        public string service_num = "(416)797-8295";
        public int id=0;
        public string phoneNumber;
        public string clientName;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = true;
            configRead();
           // openFileDialog1.ShowDialog();
            openFileDialog1_FileOk_1();
            phoneNumber = txtPhone.Text.ToString();
            clientName = txtName.Text.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void btnSubmit1_Onclick(object sender, EventArgs e)
        {
          
            var phoneNumber = txtPhone.Text.ToString();
            var clientName = txtName.Text.ToString();
           // var Twilio_num = "+16475592196";
            var service_num = "(416)797-8295";
            message = "Hi " + clientName + " ,Your order has some problem, please call " + service_num + " for more details.";
            
            msgReadtoPreview(message);          
            //add the contact record into tthe datagridview
            add_record_to_dataview(id, phoneNumber, clientName,message);
        }

        private void btnSubmit2_Onclick(object sender, EventArgs e)
        {
            message = "Hi " + txtName.Text.ToString()+" ,Your order is ready, Please pick up your product  " ;
            msgReadtoPreview(message);

            //add the contact record into tthe datagridview
            add_record_to_dataview(id, phoneNumber, clientName, message);
        }

        //read the configuration settings in the configuration XML
        private void configRead()
        {
            

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("config.xml");

            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/button");

            string proText = "", proName = "", price = "";

            foreach (XmlNode node in nodeList)
            {

                proName = node.SelectSingleNode("name").InnerText;

                proText = node.SelectSingleNode("text").InnerText;

                //price = node.SelectSingleNode("").InnerText;
                //MessageBox.Show("The name is " + proName + " the text of the button " + proText);
                AddTextinButton(this,proName,proText);

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

        //Read the data from the Excel files using ExcelDataReader
        //https://github.com/ExcelDataReader/ExcelDataReader
    


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void btnSubmit3_OnClick(object sender, System.EventArgs e)
        {
            message = "Hi " + txtName.Text.ToString() + " ,message 3 ";
            msgReadtoPreview(message);
            add_record_to_dataview(id, phoneNumber, clientName, message);
        }

        private void btnSubmit4_OnClick(object sender, System.EventArgs e)
        {
            message = "Hi " + txtName.Text.ToString() + " ,message 4 ";
            msgReadtoPreview(message);
            add_record_to_dataview(id, phoneNumber, clientName, message);
        }

        private void btnSubmit5_OnClick(object sender, System.EventArgs e)
        {
            message = "Hi " + txtName.Text.ToString() + " ,message 5 ";
            msgReadtoPreview(message);
            add_record_to_dataview(id, phoneNumber, clientName, message);

        }
        private void btnSend_OnClick(object sender, System.EventArgs e)
        {
            //send the messages after the preview action
            MessageBox.Show(txtPreview.Text);
            MsgboxYesNo();
            //send_msg(txtPreview.Text);
        }
       // DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);

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
            drToAdd["Name"] = name;
            drToAdd["Content"] = content;
            drToAdd["Send Datetime"] = DateTime.Now;
           // drToAdd["Name"] = "Value2";

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();

          //  dataGridView1.Rows.Add("", phone, name, content, DateTime.Now);
        }


        private void send_msg(string message)
        {
            var phoneNumber = txtPhone.Text.ToString();
            var twilio = new Twilio.TwilioRestClient(accountSid, authToken);
            var sendmsg = twilio.SendMessage(
                "+16475592196", // From (Replace with your Twilio number)
                phoneNumber, // To (Replace with your phone number)
                message
                );

        }
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

         private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
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

        private void readExcel(){
        
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //read from excel
           // readExcel();
        }

        private string path_builder()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var path = Path.Combine(outPutDirectory, "Data\\Daily_Data_2016_11_11.xls");
            return path;
        }

       

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    // Bind Grid Data to Datatable
                    DataTable dt = new DataTable();
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        dt.Columns.Add(col.HeaderText, col.ValueType);
                    }
                    int count = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (count < dataGridView1.Rows.Count - 1)
                        {
                            dt.Rows.Add();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                            }
                        }
                        count++;
                    }
                    // Bind table data to Stream Writer to export data to respective folder
                    //StreamWriter wr = new StreamWriter(@"C:\Users\Hang.Wu\Documents\Visual Studio 2012\Projects\20161124---Twilio_win_---excel_read_write\Twilio_win_1108\bin\Debug\Data\\Daily_Data_2016_11_11.xls");
                   var path = path_builder();
                   string _path = new Uri(path).LocalPath;
                    StreamWriter wr = new StreamWriter(@_path);
                    // Write Columns to excel file
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                    }
                    wr.WriteLine();
                    //write rows to excel file
                    for (int i = 0; i < (dt.Rows.Count); i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dt.Rows[i][j] != null)
                            {
                                wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                            }
                            else
                            {
                                wr.Write("\t");
                            }
                        }
                        wr.WriteLine();
                    }
                    wr.Close();           
                    lblSuccessMsg.Text = "Data Exported Successfully";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}
