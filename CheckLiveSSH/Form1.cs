using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckLiveSSH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        DataTable table;
        public  DataTable Convert(string File, string TableName, string delimiter)
        {
            table = new DataTable();

            table.Columns.Add("ipaddress", typeof(string));
            table.Columns.Add("username", typeof(string));
            table.Columns.Add("password", typeof(string));
            table.Columns.Add("location", typeof(string));
            table.Columns.Add("pos", typeof(string));
            table.Columns.Add("city", typeof(string));
            table.Columns.Add("status", typeof(string));

            StreamReader s = new StreamReader(File);           
                 
            string AllData = s.ReadToEnd();
            string[] stringSeparators = new string[] { "\r\n" };
            string[] rows = AllData.Split(stringSeparators, StringSplitOptions.None);         
            foreach (string r in rows)
            {              
                string[] items = r.Split(delimiter.ToCharArray());
                table.Rows.Add(items);
            }    
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt) | *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string url = ofd.FileName;
                txt_url.Text = url;
                DataTable dt = Convert(url, "test", "|");
                gv_data.DataSource = dt;

            }
        }
        int somay = 0;
        private int _soMayChon;
        private int _mayChamXong;
        private int somayChamXong
        {
            set
            {
                lock (gv_data)
                {
                    _mayChamXong = value;
                    if (_mayChamXong >= _soMayChon)
                    {
                        
                        //progressBarControl1.BeginInvoke(new Action(() =>
                        //{
                        //    Double percent = 100;
                        //    progressBarControl1.EditValue = percent;
                        //}));
                    }
                    else
                    {
                        //progressBarControl1.BeginInvoke(new Action(() =>
                        //{
                        //    Double percent = Convert.ToDouble(_mayChamXong) / Convert.ToDouble(_soMayChon) * 100.0;
                        //    progressBarControl1.EditValue = percent;
                        //    Load_DuLieu();
                        //}));
                    }
                }
            }
            get
            {
                lock (gv_data)
                {
                    return _mayChamXong;
                }
            }
        }
        private void TinhTrangKetNoi(int rowHandle, string msg)
        {
            gv_data.BeginInvoke((Action)(() =>
            {
                gv_data[6, rowHandle].Value = msg;
            }));
        }
        private  void btn_start_Click(object sender, EventArgs e)
        {
            _soMayChon = table.Rows.Count;
            somayChamXong = 0;
            //int i = 0;

            var ipList = new List<KeyValuePair<int, string>>();

            for (var r = 0; r <= table.Rows.Count - 1; r++)
            {
                somay++;
                              
                ipList.Add(new KeyValuePair<int, string>(r, table.Rows[r]["ipaddress"].ToString()));
               
            }
            var smallIpLists = SplitList(ipList, 5); //chia list chính thành nhiều list co nhieu nhat 5 ip 
            // bạn debug mà xem list nó như thế nào nhé

            if (somay > 0)
            {
                foreach (var _listIp in smallIpLists) //chay thread cho moi list
                {
                    new Thread(() => {

                       foreach(var ipInfo in _listIp)
                        {
                           new Thread(async () =>
                            {
                                TinhTrangKetNoi(ipInfo.Key, "Đang kiểm tra...");
                                int r = ipInfo.Key;
                                string username = table.Rows[r]["username"].ToString();
                                string password = table.Rows[r]["password"].ToString();
                                string result = await new MySSH().checkSSH(ipInfo.Value, username, password, "google.com", 10);
                                TinhTrangKetNoi(ipInfo.Key, result);
                            }).Start();
                        };
                    }).Start();
                }
               
             
                    
                
            }
        }
        public static List<List<T>> SplitList<T>(IEnumerable<T> values, int groupSize, int? maxCount = null)
        {
            List<List<T>> result = new List<List<T>>();
            // Quick and special scenario
            if (values.Count() <= groupSize)
            {
                result.Add(values.ToList());
            }
            else
            {
                List<T> valueList = values.ToList();
                int startIndex = 0;
                int count = valueList.Count;
                int elementCount = 0;

                while (startIndex < count && (!maxCount.HasValue || (maxCount.HasValue && startIndex < maxCount)))
                {
                    elementCount = (startIndex + groupSize > count) ? count - startIndex : groupSize;
                    result.Add(valueList.GetRange(startIndex, elementCount));
                    startIndex += elementCount;
                }
            }


            return result;
        }
    }
}
