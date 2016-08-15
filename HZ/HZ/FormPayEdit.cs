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
    public partial class FormPayEdit : Form
    {
        public FormPayEdit()
        {
            InitializeComponent();
        }

        public int isApply = 0;
        public int employee_Id = 0;
        public string name = null;
        public int pay_Id = 0;
        //public string employee_Id = null;
        public string date = null;
        public string allMoney = null;
    
        public string amTime = null;
        public string amLocation_Id = null;
        public string amMoney = null;
        public string am_Id = null;

        public string pmTime = null;
        public string pmLocation_Id = null;
        public string pmMoney = null;
        public string pm_Id = null;

        public string otTime = null;
        public string otLocation_Id = null;
        public string otMoney = null;
        public string ot_Id = null;

        public CircularProgress cpLoading;
        List<API.bid> bid = null;
        API.pay pay = null;
        API.employee employee = null;
        List<API.detailPay> detailPay = null;
        private void FormPayEdit_Load(object sender, EventArgs e)
        {
            hidenUpDown();
            labelName.Text = name;
            textBoxDate.Enabled = false;
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

            bid = API.getBidAll(0);
            pay = API.getPayData(pay_Id);
            detailPay = API.getDetailPay(pay_Id);
            employee = API.getEmployee(employee_Id);
        }

        private void bwLoading_Completed(Object sender, RunWorkerCompletedEventArgs e)
        {
          

            textBoxDate.Text = pay.date;
            numAllPay.Value = pay.money;
            numAmPay.Value = detailPay[0].money;
            numAmSegement.Value = detailPay[0].time;
            numPmPay.Value = detailPay[1].money;
            numPmSegement.Value = detailPay[1].time;
            numOTPay.Value = detailPay[2].money;
            numOTSegement.Value = detailPay[2].time;


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
            ComboBoxItem item = null;

            // combox am
            if(detailPay[0].bid_Id == 0)
            {
                comboBoxAmLocation.SelectedIndex = 0;
            }
            else
            {
                for (int i = 1; i < comboBoxAmLocation.Items.Count; i++)
                {
                    item = comboBoxAmLocation.Items[i] as ComboBoxItem;

                    if (Convert.ToInt32(item.Value) == detailPay[0].bid_Id)
                    {
                        comboBoxAmLocation.SelectedIndex = i;
                    }

                }
            }


            //combox pm
            if (detailPay[1].bid_Id == 0)
            {
                comboBoxPmLocation.SelectedIndex = 0;
            }
            else
            {
                for (int i = 1; i < comboBoxPmLocation.Items.Count; i++)
                {
                    item = comboBoxPmLocation.Items[i] as ComboBoxItem;

                    if (Convert.ToInt32(item.Value) == detailPay[1].bid_Id)
                    {
                        comboBoxPmLocation.SelectedIndex = i;
                    }

                }
            }


            //combox ot
            if (detailPay[2].bid_Id == 0)
            {
                comboBoxOTLocation.SelectedIndex = 0;
            }
            else
            {
                for (int i = 1; i < comboBoxOTLocation.Items.Count; i++)
                {
                    item = comboBoxAmLocation.Items[i] as ComboBoxItem;

                    if (Convert.ToInt32(item.Value) == detailPay[2].bid_Id)
                    {
                        comboBoxOTLocation.SelectedIndex = i;
                    }

                }
            }


            //int index = comboBoxAmLocation.Items.IndexOf(amItem);
            textBoxDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (cpLoading != null)
            {
                cpLoading.Stop();
                this.Controls.Remove(cpLoading);
                cpLoading = null;
            }

        }

        private void numAmSegement_ValueChanged(object sender, EventArgs e)
        {
            numAmPay.Value = (Convert.ToInt32(employee.pay) / 2) * numAmSegement.Value / 4;
            numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
        }

        private void numPmSegement_ValueChanged(object sender, EventArgs e)
        {
            numPmPay.Value = (Convert.ToInt32(employee.pay) / 2) * numPmSegement.Value / 4;
            numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
        }

        private void numOTSegement_ValueChanged(object sender, EventArgs e)
        {
            if (numOTSegement.Value > 2)
            {
                numOTPay.Value = (employee.pay) / 2; //超過2小時算半天薪水
            }
            else
            {
                numOTPay.Value = (Convert.ToInt32(employee.overtimePay)) * numOTSegement.Value;
            }

            numAllPay.Value = numAmPay.Value + numPmPay.Value + numOTPay.Value;
        }

        private void hidenUpDown()
        {
            Func.HideUpDown(numAllPay);
            Func.HideUpDown(numAmPay);
            Func.HideUpDown(numPmPay);
            Func.HideUpDown(numOTPay);
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

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否更新", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                updatePay();
            }
        }


        private void updatePay()
        {
            if (comboBoxAmLocation.SelectedIndex < 0)
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
            
            employee_Id = employee.employee_Id;
            date = textBoxDate.Text;
            allMoney = numAllPay.Value.ToString();

            amTime = numAmSegement.Value.ToString();
            item = comboBoxAmLocation.Items[comboBoxAmLocation.SelectedIndex] as ComboBoxItem;
            amLocation_Id = item.Value;
            amMoney = numAmPay.Value.ToString();
            am_Id = detailPay[0].detailPay_Id.ToString();

            pmTime = numAmSegement.Value.ToString();
            item = comboBoxPmLocation.Items[comboBoxPmLocation.SelectedIndex] as ComboBoxItem;
            pmLocation_Id = item.Value;
            pmMoney = numPmPay.Value.ToString();
            pm_Id = detailPay[1].detailPay_Id.ToString();

            otTime = numOTSegement.Value.ToString();
            item = comboBoxOTLocation.Items[comboBoxOTLocation.SelectedIndex] as ComboBoxItem;
            otLocation_Id = item.Value;
            otMoney = numOTPay.Value.ToString();
            ot_Id = detailPay[2].detailPay_Id.ToString();

            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("pay_Id", pay_Id.ToString()),
                    new KeyValuePair<string, string>("allMoney", allMoney),


                    new KeyValuePair<string, string>("am_Id", am_Id),
                    new KeyValuePair<string, string>("amTime", amTime),
                    new KeyValuePair<string, string>("amLocation_Id", amLocation_Id),
                    new KeyValuePair<string, string>("amMoney", amMoney),

                    new KeyValuePair<string, string>("pm_Id", pm_Id),
                    new KeyValuePair<string, string>("pmTime", pmTime),
                    new KeyValuePair<string, string>("pmLocation_Id", pmLocation_Id),
                    new KeyValuePair<string, string>("pmMoney", pmMoney),

                    new KeyValuePair<string, string>("ot_Id",ot_Id),
                    new KeyValuePair<string, string>("otTime", otTime),
                    new KeyValuePair<string, string>("otLocation_Id", otLocation_Id),
                    new KeyValuePair<string, string>("otMoney", otMoney),
                };
            string api = API.getApi((int)ENUM.API_t.API_PAY_UPDATE);
            Task<string> task = Task.Run(() => Func.PostRequest(api, queries));

            string content = task.Result;

            Func.result Ret = new Func.result();
            Ret = Func.getResult(content);
            if (Ret.type == "E000")
            {
                MessageBox.Show("新增成功");
                isApply = 1;
                this.Close();
            }
            else
            {
                MessageBox.Show(Ret.message);
                isApply = 0;
                this.Close();
            }


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            isApply = 0;
            this.Close();
        }
    }
}
