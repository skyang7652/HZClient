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
    public partial class FormBid : Form
    {
        public CircularProgress cpLoading;
        List<API.bid> bidList = null;
        bool inputIsLock = true;
        int index = 0;

        string bid_Id = null;
        string bidName = null;
        string bidAbbreviation = null;
        string bidMoney = null;
        string bidBond = null;
        string startDate = null;
        string endDate = null;
        string bidType = null;

        public FormBid()
        {
            InitializeComponent();
        }

        private void FormBid_Load(object sender, EventArgs e)
        {
            dataGridViewBid.Rows.Clear();
            dataGridViewBid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16);
            dataGridViewBid.DefaultCellStyle.Font = new Font("PMingLiU", 16);
            dataGridViewBid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
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

        private void inputLock(bool inputIsLock)
        {
            if (inputIsLock)
            {
                buttonEdit.Text = "修改";
                textBoxBidName.Enabled = false;
                textBoxBidNickName.Enabled = false;
                textBoxEndDate.Enabled = false;
                textBoxStartDate.Enabled = false;
                numBidMoney.Enabled = false;
                numBond.Enabled = false;
            }
            else
            {
                buttonEdit.Text = "更新";
                textBoxBidName.Enabled = true;
                textBoxBidNickName.Enabled = true;
                textBoxEndDate.Enabled = true;
                textBoxStartDate.Enabled = true;
                numBidMoney.Enabled = true;
                numBond.Enabled = true;

            }
        }

        private void bwLoading_Run(Object sender, DoWorkEventArgs e)
        {
            if (checkBoxNot.Checked == true)
            {
                bidList = API.getBidAll(0);
            }
            else
            {
                bidList = API.getBidAll(1);
            }

        }

        private void bwLoading_Completed(Object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridViewBid.Rows.Clear();

            bid_Id = bidList[0].bid_Id.ToString();

            textBoxBidName.Text = bidList[0].bidName;
            textBoxBidNickName.Text = bidList[0].bidAbbreviation;
            textBoxStartDate.Text = bidList[0].bidStartDate;
            textBoxEndDate.Text = bidList[0].bidEndDate;
            numBidMoney.Value = bidList[0].bidMoney;
            numBond.Value = bidList[0].bidBond;

            if (bidList[0].bidType == true)
            {
                buttonComplete.Text = "已結案";
                buttonComplete.Enabled = false;
            }

            foreach (API.bid item in bidList)
            {
                dataGridViewBid.Rows.Add(item.bidName);
            }
            if (cpLoading != null)
            {
                cpLoading.Stop();
                this.Controls.Remove(cpLoading);
                cpLoading = null;
            }
        }

        private void dataGridViewBid_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridViewBid_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridViewBid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= bidList.Count)
            {
                return;
            }
            index = e.RowIndex;

            if (bidList[index].bidType == true)
            {
                buttonComplete.Text = "已結案";
                buttonComplete.Enabled = false;

            }
            else
            {
                buttonComplete.Text = "結案";
                buttonComplete.Enabled = true;
            }
            inputIsLock = true;

            inputLock(inputIsLock);
            bid_Id = bidList[index].bid_Id.ToString();
            textBoxBidName.Text = bidList[index].bidName;
            textBoxBidNickName.Text = bidList[index].bidAbbreviation;
            textBoxStartDate.Text = bidList[index].bidStartDate;
            textBoxEndDate.Text = bidList[index].bidEndDate;
            numBidMoney.Value = bidList[index].bidMoney;
            numBond.Value = bidList[index].bidBond;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            bidName = textBoxBidName.Text;
            bidAbbreviation = textBoxBidNickName.Text;
            startDate = textBoxStartDate.Text;
            endDate = textBoxEndDate.Text;
            bidMoney = numBidMoney.Value.ToString();
            bidBond = numBond.Value.ToString();
            bidType = bidList[index].bidType.ToString();

            if (inputIsLock)
            {
                //目前鎖住按下去要解開
                inputIsLock = false;
                buttonEdit.Text = "更新";
                inputLock(inputIsLock);
            }
            else
            {
                //更新完恢復鎖住
                inputIsLock = true;
                buttonEdit.Text = "修改";
                inputLock(inputIsLock);
                string api = API.getApi((int)ENUM.API_t.API_BID_EDIT);

                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("bid_Id", bid_Id),
                    new KeyValuePair<string, string>("bidName", bidName),
                    new KeyValuePair<string, string>("bidAbbreviation", bidAbbreviation),
                    new KeyValuePair<string, string>("bidBond", bidBond),
                    new KeyValuePair<string, string>("bidMoney", bidMoney),
                    new KeyValuePair<string, string>("startDate", startDate),
                    new KeyValuePair<string, string>("endDate", endDate),
                    new KeyValuePair<string, string>("bidType", bidType),
                };


                Task<string> task = Task.Run(() => Func.PostRequest(api, queries));

                string content = task.Result;

                Func.result Ret = new Func.result();
                Ret = Func.getResult(content);
                if (Ret.type == "E000")
                {
                    MessageBox.Show("新增成功");
                    updateBid();
                }
                else
                {
                    MessageBox.Show("新增失敗 Message:" + Ret.message);

                }
            }

        }
        private void updateBid()
        {
            bidList.Clear();
            dataGridViewBid.Rows.Clear();
                        
            if (checkBoxNot.Checked == true)
            {
                bidList = API.getBidAll(0);
            }
            else
            {
                bidList = API.getBidAll(1);
            }
            foreach (API.bid item in bidList)
            {
                dataGridViewBid.Rows.Add(item.bidName);
            }

            inputIsLock = true;

            inputLock(inputIsLock);

            bid_Id = bidList[index].bid_Id.ToString();
            textBoxBidName.Text = bidList[index].bidName;
            textBoxBidNickName.Text = bidList[index].bidAbbreviation;
            textBoxStartDate.Text = bidList[index].bidStartDate;
            textBoxEndDate.Text = bidList[index].bidEndDate;
            numBidMoney.Value = bidList[index].bidMoney;
            numBond.Value = bidList[index].bidBond;
            bidType = bidList[index].bidType.ToString();
            if(bidList[index].bidType)
            {
                buttonComplete.Text = "已結案";
                buttonComplete.Enabled = false;
            }
            else
            {
                buttonComplete.Text = "結案";
                buttonComplete.Enabled = true;

            }
        }

        private void checkBoxNot_CheckedChanged(object sender, EventArgs e)
        {
            index = 0;
            updateBid();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否刪除?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                string api = API.getApi((int)ENUM.API_t.API_BID_DELETE);

                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("bid_Id", bid_Id),

                };


                Task<string> task = Task.Run(() => Func.PostRequest(api, queries));

                string content = task.Result;

                Func.result Ret = new Func.result();
                Ret = Func.getResult(content);
                if (Ret.type == "E000")
                {
                    index = 0;
                    MessageBox.Show("刪除成功");
                    updateBid();
                }
                else
                {
                    MessageBox.Show("新增失敗 Message:" + Ret.message);

                }
            }

        }

        private void buttonComplete_Click(object sender, EventArgs e)
        {

            bidName = textBoxBidName.Text;
            bidAbbreviation = textBoxBidNickName.Text;
            startDate = textBoxStartDate.Text;
            endDate = textBoxEndDate.Text;
            bidMoney = numBidMoney.Value.ToString();
            bidBond = numBond.Value.ToString();
            bidType = "1";

            string api = API.getApi((int)ENUM.API_t.API_BID_EDIT);

            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("bid_Id", bid_Id),
                    new KeyValuePair<string, string>("bidName", bidName),
                    new KeyValuePair<string, string>("bidAbbreviation", bidAbbreviation),
                    new KeyValuePair<string, string>("bidBond", bidBond),
                    new KeyValuePair<string, string>("bidMoney", bidMoney),
                    new KeyValuePair<string, string>("startDate", startDate),
                    new KeyValuePair<string, string>("endDate", endDate),
                    new KeyValuePair<string, string>("bidType", bidType),
                };


            Task<string> task = Task.Run(() => Func.PostRequest(api, queries));

            string content = task.Result;

            Func.result Ret = new Func.result();
            Ret = Func.getResult(content);
            if (Ret.type == "E000")
            {
                MessageBox.Show("結案成功");
                updateBid();
            }
            else
            {
                MessageBox.Show("結案失敗 Message:" + Ret.message);

            }
        }
    }
}
