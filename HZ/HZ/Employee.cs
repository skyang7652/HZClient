using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZ
{
    public partial class FormEmployee : Form
    {
        public CircularProgress cpLoading;

        public FormPayEdit formPayEdit = null;
        List<API.employee> employee = null;
        List<API.pay> payList = null;
        List<API.detailPay> detailPayList = null;
        List<API.bid> bidList = null;
        int payIndex = 0;
        public List<payData> payDataList = new List<payData>();

        public class payData
        {
            public string date;
            public string amNickName;
            public int amMoney;
            public string pmNickName;
            public int pmMoney;
            public string otNickName;
            public int otMoney;
            public int allMoney;
        }
        bool inputIsLock = true;

        int isLoaded = 0;

        int employeeSelect = 0;
        int employeeIndex = 0;
        public static string emplpoyee_Id = null;
        public static string firstName = null;
        public static string lastName = null;
        public static string pay = null;
        public static string overtimePay = null;
        public static string phone = null;
        public static string address = null;




        public FormEmployee()
        {
            InitializeComponent();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            dataGridViewName.Rows.Clear();
            dataGridViewName.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16);
            dataGridViewName.DefaultCellStyle.Font = new Font("PMingLiU", 16);
            dataGridViewName.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewPay.Rows.Clear();
            dataGridViewPay.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
            dataGridViewPay.DefaultCellStyle.Font = new Font("PMingLiU", 14);
            for (int i = 0; i < dataGridViewPay.Columns.Count; i++)
            {
                dataGridViewPay.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //鎖住輸入
            inputLock(inputIsLock);

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
            payList = API.getPay(employee[0].employee_Id);
            bidList = API.getBidAll(0);

            getPayDataList();


            if (employee.Count >= 0)
            {
                isLoaded = 1;
            }
            else
            {
                isLoaded = 0;
            }
        }

        private void getPayDataList()
        {
            API.bid bidTemp;

            payDataList.Clear();
            foreach (API.pay i in payList)
            {
                detailPayList = API.getDetailPay(i.pay_Id);

                payData temp = new payData();
                temp.date = i.date;
                if (detailPayList[0].bid_Id == 0)
                {
                    temp.amNickName = "無";
                    temp.amMoney = detailPayList[0].money;
                }
                else
                {
                    bidTemp = null;
                    bidTemp = bidList.Find(
                        delegate (API.bid bid)
                        {
                            //return user.UserID == 0;  

                            return bid.bid_Id == detailPayList[0].bid_Id;
                        });
                    if (bidTemp == null)
                    {
                        bidTemp = API.getBid(detailPayList[0].bid_Id);
                    }
                    temp.amNickName = bidTemp.bidAbbreviation;
                    temp.amMoney = detailPayList[0].money;
                }

                if (detailPayList[1].bid_Id == 0)
                {
                    temp.pmNickName = "無";
                    temp.pmMoney = detailPayList[1].money;
                }
                else
                {
                    bidTemp = bidList.Find(
                   delegate (API.bid bid)
                   {
                       return bid.bid_Id == detailPayList[1].bid_Id;
                   });
                    if (bidTemp == null)
                    {
                        bidTemp = API.getBid(detailPayList[1].bid_Id);
                    }
                    temp.pmNickName = bidTemp.bidAbbreviation;
                    temp.pmMoney = detailPayList[1].money;
                }

                if (detailPayList[2].bid_Id == 0)
                {
                    temp.otNickName = "無";
                    temp.otMoney = detailPayList[2].money;
                }
                else
                {
                    bidTemp = bidList.Find(
                   delegate (API.bid bid)
                   {
                       //return user.UserID == 0;  

                       return bid.bid_Id == detailPayList[2].bid_Id;
                   });
                    if (bidTemp == null)
                    {
                        bidTemp = API.getBid(detailPayList[2].bid_Id);
                    }
                    temp.otNickName = bidTemp.bidAbbreviation;
                    temp.otMoney = detailPayList[2].money;
                }



                temp.allMoney = i.money;

                payDataList.Add(temp);
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
            dataGridViewName.Rows.Clear();
            dataGridViewPay.Rows.Clear();
            textBoxFirstName.Text = employee[0].firstName;
            textBoxLastName.Text = employee[0].lastName;
            textBoxPhone.Text = employee[0].phone;
            textBoxAddress.Text = employee[0].address;
            numPay.Value = Convert.ToInt32(employee[0].pay);
            numOvertimePay.Value = Convert.ToInt32(employee[0].overtimePay);

            employeeSelect = employee[0].employee_Id;

            foreach (API.employee i in employee)
            {
                string name = i.lastName + i.firstName;
                dataGridViewName.Rows.Add(name);
            }


            foreach (payData data in payDataList)
            {

                dataGridViewPay.Rows.Add(data.date, data.amNickName, data.amMoney, data.pmNickName, data.pmMoney, data.otNickName, data.otMoney, data.allMoney);
            }

            if (cpLoading != null)
            {
                cpLoading.Stop();
                this.Controls.Remove(cpLoading);
                cpLoading = null;
            }

        }


        private void inputLock(bool type)
        {
            if (type)
            {
                textBoxFirstName.Enabled = false;
                textBoxLastName.Enabled = false;
                textBoxAddress.Enabled = false;
                textBoxPhone.Enabled = false;
                numOvertimePay.Enabled = false;
                numPay.Enabled = false;
            }
            else
            {
                textBoxFirstName.Enabled = true;
                textBoxLastName.Enabled = true;
                textBoxAddress.Enabled = true;
                textBoxPhone.Enabled = true;
                numOvertimePay.Enabled = true;
                numPay.Enabled = true;


            }
        }

        private void dataGridViewName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            employeeIndex = e.RowIndex;
            if (employee.Count == 0)
            {
                return;
            }
            if (employeeIndex < 0 || employeeIndex >= employee.Count)
            {
                return;
            }

            employeeSelect = employee[employeeIndex].employee_Id;

            inputIsLock = true;
            buttonEdit.Text = "修改";
            inputLock(inputIsLock);

            textBoxFirstName.Text = employee[employeeIndex].firstName;
            textBoxLastName.Text = employee[employeeIndex].lastName;
            textBoxAddress.Text = employee[employeeIndex].address;
            textBoxPhone.Text = employee[employeeIndex].phone;
            numPay.Value = Convert.ToInt32(employee[employeeIndex].pay);
            numOvertimePay.Value = Convert.ToInt32(employee[employeeIndex].overtimePay);


            cpLoading = new CircularProgress();
            cpLoading.Dock = DockStyle.Fill;
            this.Controls.Add(cpLoading);
            cpLoading.BringToFront();
            cpLoading.Start();


            BackgroundWorker bwLoading = new BackgroundWorker();
            bwLoading.WorkerSupportsCancellation = true;
            bwLoading.DoWork += new DoWorkEventHandler(selectLoading_Run);
            bwLoading.RunWorkerCompleted += new RunWorkerCompletedEventHandler(selectLoading_Completed);
            bwLoading.RunWorkerAsync();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (inputIsLock)
            {
                //目前鎖住按下去要解開
                inputIsLock = false;
                buttonEdit.Text = "更新";
                inputLock(inputIsLock);
            }
            else
            {   //更新完恢復鎖住
                inputIsLock = true;
                buttonEdit.Text = "修改";
                inputLock(inputIsLock);

                emplpoyee_Id = employeeSelect.ToString();
                firstName = textBoxFirstName.Text;
                lastName = textBoxLastName.Text;
                pay = numPay.Value.ToString();
                overtimePay = numOvertimePay.Value.ToString();
                phone = textBoxPhone.Text;
                address = textBoxAddress.Text;
                string api = API.getApi((int)ENUM.API_t.API_UPDATE_EMPLOYEE);

                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("employee_Id", emplpoyee_Id),
                    new KeyValuePair<string, string>("firstName", firstName),
                    new KeyValuePair<string, string>("lastName", lastName),
                    new KeyValuePair<string, string>("pay", pay),
                    new KeyValuePair<string, string>("overtimePay", overtimePay),
                    new KeyValuePair<string, string>("phone", phone),
                    new KeyValuePair<string, string>("address", address),
                };


                Task<string> task = Task.Run(() => Func.PostRequest(api, queries));

                string content = task.Result;

                Func.result Ret = new Func.result();
                Ret = Func.getResult(content);
                if (Ret.type == "E000")
                {
                    MessageBox.Show("新增成功");
                    employeeUpdate();
                }
                else
                {
                    MessageBox.Show("新增失敗 Message:" + Ret.message);

                }

            }
        }

        public void employeeUpdate()
        {
            employee = API.getEmployee();
            string name = employee[employeeIndex].lastName + employee[employeeIndex].firstName;
            dataGridViewName.Rows[employeeIndex].Cells[0].Value = name;
        }

        public void emplpoyeeReload()
        {
            employee = API.getEmployee();



            dataGridViewName.Rows.Clear();

            textBoxFirstName.Text = employee[0].firstName;
            textBoxLastName.Text = employee[0].lastName;
            textBoxPhone.Text = employee[0].phone;
            textBoxAddress.Text = employee[0].address;
            numPay.Value = Convert.ToInt32(employee[0].pay);
            numOvertimePay.Value = Convert.ToInt32(employee[0].overtimePay);

            employeeSelect = employee[0].employee_Id;

            foreach (API.employee i in employee)
            {
                string name = i.lastName + i.firstName;
                dataGridViewName.Rows.Add(name);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否刪除", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                emplpoyee_Id = employeeSelect.ToString();
                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("employee_Id", emplpoyee_Id),

                };

                string api = API.getApi((int)ENUM.API_t.API_DElETE_EMPLOYEE);

                Task<string> task = Task.Run(() => Func.PostRequest(api, queries));

                string content = task.Result;

                Func.result Ret = new Func.result();
                Ret = Func.getResult(content);
                if (Ret.type == "E000")
                {
                    MessageBox.Show("刪除成功");
                    emplpoyeeReload();
                }
                else
                {
                    MessageBox.Show("刪除失敗 Message:" + Ret.message);

                }
            }

        }

        private void selectLoading_Run(Object sender, DoWorkEventArgs e)
        {
            payList = API.getPay(employee[employeeIndex].employee_Id);
            getPayDataList();
        }
        private void selectLoading_Completed(Object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridViewPay.Rows.Clear();
            foreach (payData data in payDataList)
            {

                dataGridViewPay.Rows.Add(data.date, data.amNickName, data.amMoney, data.pmNickName, data.pmMoney, data.otNickName, data.otMoney, data.allMoney);
            }

            if (cpLoading != null)
            {
                cpLoading.Stop();
                this.Controls.Remove(cpLoading);
                cpLoading = null;
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (payDataList.Count == 0)
            {
                MessageBox.Show("無薪水資料");
                return;
            }

            FormBilling formBilling = new FormBilling();
            formBilling.MdiParent = this.MdiParent;
            formBilling.payDataList = payDataList;
            formBilling.employee_Id = employeeSelect;
            formBilling.employeeName = textBoxLastName.Text + textBoxFirstName.Text;
            formBilling.FormClosed += new FormClosedEventHandler(formBilling_FormClosed);
            formBilling.Show();
        }
        private void formBilling_FormClosed(object sender, FormClosedEventArgs e)
        {
            //鎖住輸入
            inputLock(inputIsLock);

            cpLoading = new CircularProgress();
            cpLoading.Dock = DockStyle.Fill;
            this.Controls.Add(cpLoading);
            cpLoading.BringToFront();
            cpLoading.Start();


            BackgroundWorker bwLoading = new BackgroundWorker();
            bwLoading.WorkerSupportsCancellation = true;
            bwLoading.DoWork += new DoWorkEventHandler(selectLoading_Run);
            bwLoading.RunWorkerCompleted += new RunWorkerCompletedEventHandler(selectLoading_Completed);
            bwLoading.RunWorkerAsync();
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if(payIndex >= dataGridViewPay.Rows.Count - 1 || payIndex < 0)
            {
                return;
            }
            //this.IsMdiContainer = true;
            formPayEdit = new FormPayEdit();
            formPayEdit.pay_Id = payList[payIndex].pay_Id;
            formPayEdit.name = textBoxLastName.Text + textBoxFirstName.Text;
            formPayEdit.employee_Id = employee[employeeIndex].employee_Id;
            formPayEdit.MdiParent = this.MdiParent;
            formPayEdit.FormClosed += new FormClosedEventHandler(formPayEdit_Closed);
            formPayEdit.Show();
        }

        private void formPayEdit_Closed(object sender, FormClosedEventArgs e)
        {
            if(formPayEdit.isApply == 1)
            {
                //鎖住輸入
                inputLock(inputIsLock);

                cpLoading = new CircularProgress();
                cpLoading.Dock = DockStyle.Fill;
                this.Controls.Add(cpLoading);
                cpLoading.BringToFront();
                cpLoading.Start();


                BackgroundWorker bwLoading = new BackgroundWorker();
                bwLoading.WorkerSupportsCancellation = true;
                bwLoading.DoWork += new DoWorkEventHandler(selectLoading_Run);
                bwLoading.RunWorkerCompleted += new RunWorkerCompletedEventHandler(selectLoading_Completed);
                bwLoading.RunWorkerAsync();
            }
        }



        private void dataGridViewPay_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            payIndex = e.RowIndex;
            if(payIndex == dataGridViewPay.Rows.Count - 1)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < dataGridViewPay.Rows.Count - 1 ; i++)
                {
                    if (i == payIndex)
                    {
                        dataGridViewPay.Rows[i].Selected = true;
                    }
                    else
                    {
                        dataGridViewPay.Rows[i].Selected = false;
                    }
                }
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            string api = API.getApi((int)ENUM.API_t.API_PAY_DELETE);

            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("pay_Id", payList[payIndex].pay_Id.ToString()),
                 
                };


            Task<string> task = Task.Run(() => Func.PostRequest(api, queries));

            string content = task.Result;

            Func.result Ret = new Func.result();
            Ret = Func.getResult(content);
            if (Ret.type == "E000")
            {
                MessageBox.Show("刪除成功");


                cpLoading = new CircularProgress();
                cpLoading.Dock = DockStyle.Fill;
                this.Controls.Add(cpLoading);
                cpLoading.BringToFront();
                cpLoading.Start();


                BackgroundWorker bwLoading = new BackgroundWorker();
                bwLoading.WorkerSupportsCancellation = true;
                bwLoading.DoWork += new DoWorkEventHandler(selectLoading_Run);
                bwLoading.RunWorkerCompleted += new RunWorkerCompletedEventHandler(selectLoading_Completed);
                bwLoading.RunWorkerAsync();

            }
            else
            {
                MessageBox.Show("刪除失敗 Message:" + Ret.message);

            }
        }
    }
}
