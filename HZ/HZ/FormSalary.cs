using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZ
{
    public partial class FormSalary : Form
    {
        List<API.employee> employee = null;
        List<API.bid>bid = null;
        int isLoaded = 0;
        int employeeSelect = 0;
        public CircularProgress cpLoading;
        int index = 0;

        string employee_Id = null;
        string date = null;
        string allMoney = null;

        string amTime = null;
        string amLocation_Id = null;
        string amMoney = null;

        string pmTime = null;
        string pmLocation_Id = null;
        string pmMoney = null;

        string otTime = null;
        string otLocation_Id = null;
        string otMoney = null;


        public FormSalary()
        {
            InitializeComponent();
        }

        private void FormSalary_Load(object sender, EventArgs e)
        {
            dataGridViewName.Rows.Clear();
            dataGridViewName.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16);
            dataGridViewName.DefaultCellStyle.Font = new Font("PMingLiU", 16);

            hideNumUpDown();

            cpLoading = new CircularProgress();
            cpLoading.Dock = DockStyle.Fill;
            this.Controls.Add(cpLoading);
            cpLoading.BringToFront();
            cpLoading.Start();

            BackgroundWorker bwLoading = new BackgroundWorker();
            bwLoading.WorkerSupportsCancellation = true;
            bwLoading.DoWork += new DoWorkEventHandler(bwLoading_Run);
            bwLoading.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwLoading_Completed);
            bwLoading.RunWorkerAsync();
        }

        private void bwLoading_Run(Object sender, DoWorkEventArgs e)
        {

            employee = API.getEmployee();
            bid = API.getBidAll(0);

            if (employee.Count > 0)
            {
                isLoaded = 1;
            }
            else
            {
                isLoaded = 0;
            }
        }

        private void bwLoading_Completed(Object sender, RunWorkerCompletedEventArgs e)
        {


            if (isLoaded == 0)
            {
                MessageBox.Show("讀取失敗");
                this.Close();
                return;
            }

            foreach (API.employee i in employee)
            {
                string name = i.lastName + i.firstName;
                dataGridViewName.Rows.Add(name);
            }

            comboBoxAmLocation.Items.Clear();
            comboBoxPmLocation.Items.Clear();
            comboBoxOTLocation.Items.Clear();

            comboBoxAmLocation.Items.Add(new ComboBoxItem("0", "無"));
            comboBoxPmLocation.Items.Add(new ComboBoxItem("0", "無"));
            comboBoxOTLocation.Items.Add(new ComboBoxItem("0", "無"));

            foreach (API.bid i in bid)
            {
                comboBoxAmLocation.Items.Add(new ComboBoxItem(i.bid_Id.ToString(), i.bidName));
                comboBoxPmLocation.Items.Add(new ComboBoxItem(i.bid_Id.ToString(), i.bidName));
                comboBoxOTLocation.Items.Add(new ComboBoxItem(i.bid_Id.ToString(), i.bidName));
            }


            textBoxDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (cpLoading != null)
            {
                cpLoading.Stop();
                this.Controls.Remove(cpLoading);
                cpLoading = null;
            }

        }


        public class ComboBoxItem
        {
            public string Value;
            public string Text;

            public ComboBoxItem(string val, string text)
            {
                Value = val;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }


        private void hideNumUpDown()
        {
            Func.HideUpDown(numAllPay);
            Func.HideUpDown(numAmPay);
            Func.HideUpDown(numPmPay);
            Func.HideUpDown(numOTPay);
        }
        private void dataGridViewName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (employee.Count == 0)
            {
                return;
            }
            if (index < 0 || index >= employee.Count)
            {
                return;
            }
            employeeSelect = employee[index].employee_Id;

            numAmPay.Value = 4;
            numPmPay.Value = 4;
            numOTPay.Value = 0;

            labelName.Text = employee[index].lastName + employee[index].firstName;
            numAmPay.Value = (Convert.ToInt32(employee[index].pay) / 2) * numAmSegement.Value / 4;
            numPmPay.Value = (Convert.ToInt32(employee[index].pay) / 2) * numPmSegement.Value / 4;
            numOTPay.Value = (Convert.ToInt32(employee[index].overtimePay)) * numOTSegement.Value ;
            numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
        }

        private void comboBoxAmLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x= comboBoxAmLocation.SelectedIndex;
            if (x == 0)
            {
                numAmSegement.Value = 0;
                numAmPay.Value = 0;
                numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
                numAmSegement.Enabled = false;
            }
            else
            {
                if(numAmSegement.Value == 0)
                {
                    numAmSegement.Value = 4;
                    numAmSegement.Enabled = true;
                    numAmPay.Value = (Convert.ToInt32(employee[index].pay) / 2) * numAmSegement.Value / 4;
                    numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
                }
               
            }

        }

        private void comboBoxPmLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = comboBoxPmLocation.SelectedIndex;
            if (x == 0)
            {
                numPmSegement.Value = 0;
                numPmPay.Value = 0;
                numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
                numPmSegement.Enabled = false;
            }
            else
            {
                if (numPmSegement.Value == 0)
                {
                    numPmSegement.Value = 4;
                    numPmSegement.Enabled = true;
                    numPmPay.Value = (Convert.ToInt32(employee[index].pay) / 2) * numPmSegement.Value / 4;
                    numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
                }
              
            }
        }

        private void numAmSegement_ValueChanged(object sender, EventArgs e)
        {
            numAmPay.Value = (Convert.ToInt32(employee[index].pay) / 2) * numAmSegement.Value / 4;
            numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
        }

        private void numPmSegement_ValueChanged(object sender, EventArgs e)
        {
            numPmPay.Value = (Convert.ToInt32(employee[index].pay) / 2) * numPmSegement.Value / 4;
            numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
        }

        private void numOTSegement_ValueChanged(object sender, EventArgs e)
        {
            if(numOTSegement.Value > 2)
            {
                numOTPay.Value = (employee[index].pay) / 2; //超過2小時算半天薪水
            }
            else
            {
                numOTPay.Value = (Convert.ToInt32(employee[index].overtimePay)) * numOTSegement.Value;
            }
          
            numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否新增","",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                newPay();
            }
        }

        private void newPay()
        {
            if(comboBoxAmLocation.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇上午地點!!");
                return;
            }
            if (comboBoxPmLocation.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇中午地點!!");
                return;
            }
            if (comboBoxOTLocation.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇加班地點!!");
                return;
            }
            ComboBoxItem item = null;
            employee_Id = employee[index].employee_Id.ToString();
            date = textBoxDate.Text;
            allMoney = numAllPay.Value.ToString();

            amTime = numAmSegement.Value.ToString();
            item = comboBoxAmLocation.Items[comboBoxAmLocation.SelectedIndex] as ComboBoxItem;
            amLocation_Id = item.Value;
            amMoney = numAmPay.Value.ToString();


            pmTime = numAmSegement.Value.ToString();
            item = comboBoxPmLocation.Items[comboBoxPmLocation.SelectedIndex] as ComboBoxItem;
            pmLocation_Id = item.Value;
            pmMoney = numPmPay.Value.ToString();

            otTime = numOTSegement.Value.ToString();
            item = comboBoxOTLocation.Items[comboBoxOTLocation.SelectedIndex] as ComboBoxItem;
            otLocation_Id = item.Value;
            otMoney = numOTPay.Value.ToString();


            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("employee_Id", employee_Id),
                    new KeyValuePair<string, string>("date", date),
                    new KeyValuePair<string, string>("allMoney", allMoney),

                    new KeyValuePair<string, string>("amTime", amTime),
                    new KeyValuePair<string, string>("amLocation_Id", amLocation_Id),
                    new KeyValuePair<string, string>("amMoney", amMoney),

                    new KeyValuePair<string, string>("pmTime", pmTime),
                    new KeyValuePair<string, string>("pmLocation_Id", pmLocation_Id),
                    new KeyValuePair<string, string>("pmMoney", pmMoney),

                    new KeyValuePair<string, string>("otTime", otTime),
                    new KeyValuePair<string, string>("otLocation_Id", otLocation_Id),
                    new KeyValuePair<string, string>("otMoney", otMoney),              
                };
            string api = API.getApi((int)ENUM.API_t.API_NEW_PAY);
            Task<string> task = Task.Run(() => Func.PostRequest(api, queries));

            string content = task.Result;

            Func.result Ret = new Func.result();
            Ret = Func.getResult(content);
            if (Ret.type == "E000")
            {
                MessageBox.Show("新增成功");               
            }
            else
            {
                MessageBox.Show(Ret.message);                
            }


        }

        private void comboBoxOTLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = comboBoxOTLocation.SelectedIndex;
            if (x == 0)
            {
                numOTSegement.Value = 0;
                numOTPay.Value = 0;
                numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
                numOTSegement.Enabled = false;
            }
            else
            {
                if (numOTSegement.Value == 0)
                {
                    numOTSegement.Value = 0;
                    numOTSegement.Enabled = true;
                    numOTPay.Value = Convert.ToInt32(employee[index].overtimePay) * numOTSegement.Value;
                    numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
                }
            }
        }

        private void buttonDate_Click(object sender, EventArgs e)
        {
            monthCalendarDate.Visible = true;
            monthCalendarDate.BringToFront();
            monthCalendarDate.Location = buttonDate.Location;
            monthCalendarDate.DateSelected += new DateRangeEventHandler(monthCalendar_DateSelected);
           
        }
        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBoxDate.Text = e.Start.ToShortDateString();
            monthCalendarDate.Visible = false;
           

        }

        private void FormSalary_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendarDate.Visible = false;
        }
    }
}
