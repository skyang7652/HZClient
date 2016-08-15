using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;
namespace HZ
{
    public partial class FormBilling : Form
    {
        public FormBilling()
        {
            InitializeComponent();
        }
        public string employeeName = null;
        float tableWidth = 453.4f;
        List<bill> billList = new List<bill>();
        List<bill> bonusList = new List<bill>();
        public List<HZ.FormEmployee.payData> payDataList { get; set; }
        private CircularProgress cpSave;
        public int employee_Id = 0;
        int payMoney = 0;
        int allowanceMoney = 0;
        int bonusMoney = 0;
        int subsidyIndex = 0;
        int saveSuccess = 0;
        public double pixelToMm = 0.353;
        private object fileName;
        public class bill
        {
            public int money;
            public string remark;
        }
        private void dataGridViewSubsidy_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                subsidyIndex = e.RowIndex;
                for (int i = 0; i < dataGridViewSubsidy.RowCount; i++)
                {
                    if (i == subsidyIndex)
                    {
                        dataGridViewSubsidy.Rows[i].Selected = true;
                    }
                    else
                    {
                        dataGridViewSubsidy.Rows[i].Selected = false;
                    }

                }
            }
        }

        private void ToolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            dataGridViewSubsidy.Rows.RemoveAt(subsidyIndex);
            int temp = 0;
            for (int i = 0; i < dataGridViewSubsidy.Rows.Count - 1; i++)
            {
                temp = temp + Convert.ToInt32(dataGridViewSubsidy.Rows[i].Cells[0].Value);
            }
            allowanceMoney = temp;
            int tempAll = payMoney + allowanceMoney + bonusMoney;
            labelAllPay.Text = tempAll.ToString();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {

            if (payDataList.Count == 0)
            {
                MessageBox.Show("無資料儲存");
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Doc|*.doc";
            dlg.Title = "Save an Image File";
            dlg.FileName = DateTime.Now.ToString("yyyy-MM-dd") + "-" + employeeName;
            // If the file name is not an empty string open it for saving.
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK && dlg.FileName != "")
            {
                fileName = dlg.FileName;
                cpSave = new CircularProgress();
                cpSave.Dock = DockStyle.Fill;
                this.Controls.Add(cpSave);
                cpSave.BringToFront();
                cpSave.Start();

                BackgroundWorker bwLoading = new BackgroundWorker();
                bwLoading.WorkerSupportsCancellation = true;
                bwLoading.DoWork += new DoWorkEventHandler(bwLoading_Run);
                bwLoading.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwLoading_Completed);
                bwLoading.RunWorkerAsync();

            }

            return;
            if (MessageBox.Show("是否提交?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                int aRow = dataGridViewSubsidy.Rows.Count - 1;
                int bRow = dataGridViewBonus.Rows.Count - 1;
                List<KeyValuePair<string, string>> item = new List<KeyValuePair<string, string>>();

                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> count = new KeyValuePair<string, string>("aCount", aRow.ToString());
                KeyValuePair<string, string> Id = new KeyValuePair<string, string>("employee_Id", employee_Id.ToString());
                item.Add(count);
                item.Add(Id);
                KeyValuePair<string, string> kTemp = new KeyValuePair<string, string>();
                for (int i = 0; i < aRow; i++)
                {
                    bill temp = new bill();
                    temp.money = Convert.ToInt32(dataGridViewSubsidy.Rows[i].Cells[0].Value);
                    temp.remark = Convert.ToString(dataGridViewSubsidy.Rows[i].Cells[1].Value);
                    billList.Add(temp);
                    kTemp = new KeyValuePair<string, string>("aTxt" + i, temp.remark);
                    item.Add(kTemp);
                    kTemp = new KeyValuePair<string, string>("aMoney" + i, temp.money.ToString());
                    item.Add(kTemp);

                }
                count = new KeyValuePair<string, string>("bCount", bRow.ToString());
                item.Add(count);
                for (int i = 0; i < bRow; i++)
                {
                    bill temp = new bill();
                    temp.money = Convert.ToInt32(dataGridViewBonus.Rows[i].Cells[0].Value);
                    temp.remark = Convert.ToString(dataGridViewBonus.Rows[i].Cells[1].Value);
                    bonusList.Add(temp);
                    kTemp = new KeyValuePair<string, string>("bTxt" + i, temp.remark);
                    item.Add(kTemp);
                    kTemp = new KeyValuePair<string, string>("bMoney" + i, temp.money.ToString());
                    item.Add(kTemp);
                }

                queries = item;
                string api = API.getApi((int)ENUM.API_t.API_POST_BILLING);
                Task<string> task = Task.Run(() => Func.PostRequest(api, queries));

                string content = task.Result;

                Func.result Ret = new Func.result();
                Ret = Func.getResult(content);
                if (Ret.type == "E000")
                {
                    MessageBox.Show("新增成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("新增失敗 Message:" + Ret.message);
                    this.Close();
                }
            }
        }

        private void FormBilling_Load(object sender, EventArgs e)
        {
            dataGridViewPay.Rows.Clear();
            dataGridViewPay.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16);
            dataGridViewPay.DefaultCellStyle.Font = new Font("PMingLiU", 16);
            for(int i = 0; i < dataGridViewPay.Columns.Count; i++)
            {
                dataGridViewPay.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridViewSubsidy.Rows.Clear();
            dataGridViewSubsidy.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
            dataGridViewSubsidy.DefaultCellStyle.Font = new Font("PMingLiU", 14);
            for (int i = 0; i < dataGridViewSubsidy.Columns.Count; i++)
            {
                dataGridViewSubsidy.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridViewBonus.Rows.Clear();
            dataGridViewBonus.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
            dataGridViewBonus.DefaultCellStyle.Font = new Font("PMingLiU", 14);
            for (int i = 0; i < dataGridViewBonus.Columns.Count; i++)
            {
                dataGridViewBonus.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (FormEmployee.payData data in payDataList)
            {
                dataGridViewPay.Rows.Add(data.date, data.amNickName, data.pmNickName, data.otNickName, data.allMoney);
                payMoney += data.allMoney;
            }

            int tempAll = payMoney + allowanceMoney + bonusMoney;
            labelAllPay.Text = tempAll.ToString();
        }

        private void dataGridViewSubsidy_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var editedCell = this.dataGridViewSubsidy.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var newValue = editedCell.Value;

            if (e.ColumnIndex == 0)
            {
                System.Text.RegularExpressions.Regex regul = new System.Text.RegularExpressions.Regex(@"^[1-9][0-9]*[\\.]?[0-9]*$");  //驗證的規則是直接copy您的規則 
                if (!regul.IsMatch(newValue.ToString()))
                {
                    MessageBox.Show("只允許填入數字！");
                    return;
                }
                int temp = 0;
                for (int i = 0; i < dataGridViewSubsidy.Rows.Count - 1; i++)
                {
                    temp = temp + Convert.ToInt32(dataGridViewSubsidy.Rows[i].Cells[0].Value);
                }
                allowanceMoney = temp;
                int tempAll = payMoney + allowanceMoney + bonusMoney;
                labelAllPay.Text = tempAll.ToString();
            }

        }

        private void dataGridViewBonus_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var editedCell = this.dataGridViewBonus.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var newValue = editedCell.Value;

            if (e.ColumnIndex == 0)
            {
                System.Text.RegularExpressions.Regex regul = new System.Text.RegularExpressions.Regex(@"^[1-9][0-9]*[\\.]?[0-9]*$");  //驗證的規則是直接copy您的規則 
                if (!regul.IsMatch(newValue.ToString()))
                {
                    MessageBox.Show("只允許填入數字！");
                    return;
                }
                int temp = 0;
                for (int i = 0; i < dataGridViewBonus.Rows.Count - 1; i++)
                {
                    temp = temp + Convert.ToInt32(dataGridViewBonus.Rows[i].Cells[0].Value);
                }
                bonusMoney = temp;
                int tempAll = payMoney + allowanceMoney + bonusMoney;

                labelAllPay.Text = tempAll.ToString();
            }
        }

        private void bwLoading_Run(Object sender, DoWorkEventArgs e)
        {
            int ret = 0;
            saveSuccess = 0;
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    setLsit();
                    ret = saveDocx(fileName);
                    saveSuccess = 1;
                }
                catch
                {
                    MessageBox.Show("儲存失敗");
                }

            });
        }
        private void bwLoading_Completed(Object sender, RunWorkerCompletedEventArgs e)
        {
            if (saveSuccess == 1)
            {
                MessageBox.Show("儲存完成");
            }


            if (cpSave != null)
            {
                cpSave.Stop();
                this.Controls.Remove(cpSave);
                cpSave = null;
            }
        }
        private void setLsit()
        {
            int aRow = dataGridViewSubsidy.Rows.Count - 1;
            int bRow = dataGridViewBonus.Rows.Count - 1;
            billList.Clear();
            bonusList.Clear();

            for (int i = 0; i < aRow; i++)
            {
                bill temp = new bill();
                temp.money = Convert.ToInt32(dataGridViewSubsidy.Rows[i].Cells[0].Value);
                temp.remark = Convert.ToString(dataGridViewSubsidy.Rows[i].Cells[1].Value);
                billList.Add(temp);
            }


            for (int i = 0; i < bRow; i++)
            {
                bill temp = new bill();
                temp.money = Convert.ToInt32(dataGridViewBonus.Rows[i].Cells[0].Value);
                temp.remark = Convert.ToString(dataGridViewBonus.Rows[i].Cells[1].Value);
                bonusList.Add(temp);
               
            }



        }
        private int saveDocx(object fileName)
        {

            int rowCounts = payDataList.Count + 3;
            if (billList.Count > 0)
            {
                rowCounts = rowCounts + billList.Count + 2;
            }
            if (bonusList.Count > 0)
            {

                rowCounts = rowCounts + bonusList.Count + 2;
            }
            Microsoft.Office.Interop.Word.Application wrdApp;
            Object oMissing = System.Reflection.Missing.Value;
            Object oEndOfDoc = "\\endofdoc";

            wrdApp = new Microsoft.Office.Interop.Word.Application();
            wrdApp.Visible = false;    //執行過程不在畫面上開啟 Word            
            Microsoft.Office.Interop.Word._Document myDoc;
            myDoc = wrdApp.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            myDoc.PageSetup.TopMargin = wrdApp.CentimetersToPoints(float.Parse("1.5"));
            myDoc.PageSetup.BottomMargin = wrdApp.CentimetersToPoints(float.Parse("1.5"));
            myDoc.PageSetup.LeftMargin = wrdApp.CentimetersToPoints(float.Parse("2.5"));
            myDoc.PageSetup.RightMargin = wrdApp.CentimetersToPoints(float.Parse("2.5"));
            myDoc.Paragraphs.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter; // 置中

            wrdApp.Selection.Font.Bold = 700;
            wrdApp.Selection.Font.Size = 16;
            wrdApp.Selection.Paragraphs.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
            wrdApp.Selection.Text = "禾展營造有限公司出工薪資";


            object WdLine = word.WdUnits.wdLine;//換一行;
            wrdApp.Selection.MoveDown(ref WdLine, ref oMissing, ref oMissing);//移動焦點
            wrdApp.Selection.TypeParagraph();//插入段落
            word.Range range = wrdApp.Selection.Range;
            Microsoft.Office.Interop.Word.Table myTable;

            Microsoft.Office.Interop.Word.Range wrdRng = myDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

            wrdApp.Selection.Font.Bold = 700;
            wrdApp.Selection.Font.Size = 14;
            wrdApp.Selection.Paragraphs.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
            wrdApp.Selection.Text = "員工姓名：" + employeeName + "                      表單日期：" + DateTime.Now.ToString("yyy年MM月dd日");

            WdLine = word.WdUnits.wdLine;
            wrdApp.Selection.MoveDown(ref WdLine, ref oMissing, ref oMissing);//移動焦點
            wrdApp.Selection.TypeParagraph();//換行

            range = wrdApp.Selection.Range;


            myTable = myDoc.Tables.Add(range, rowCounts , 5, ref oMissing, ref oMissing);
            myTable.Range.Font.Size = 12;
            myTable.Range.Font.Bold = 0;
            myTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            myTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;


            int rowIndex = 1;
            myTable.Cell(rowIndex, 1).Merge(myTable.Cell(rowIndex, 5));
            myTable.Cell(rowIndex, 1).Range.Text = "每日薪資";
            myTable.Cell(rowIndex, 1).Range.Font.Bold = 700;
            rowIndex++;

            myTable.Cell(rowIndex, 1).Range.Text = "日期";
            myTable.Cell(rowIndex, 2).Range.Text = "上午";
            myTable.Cell(rowIndex, 3).Range.Text = "下午";
            myTable.Cell(rowIndex, 4).Range.Text = "加班";
            myTable.Cell(rowIndex, 5).Range.Text = "日薪";

            rowIndex++;

            for (int i = 0; i < payDataList.Count; i++)
            {
                myTable.Cell(i + rowIndex, 1).Range.Text = payDataList[i].date;
                myTable.Cell(i + rowIndex, 2).Range.Text = payDataList[i].amMoney.ToString();
                myTable.Cell(i + rowIndex, 3).Range.Text = payDataList[i].pmMoney.ToString();
                myTable.Cell(i + rowIndex, 4).Range.Text = payDataList[i].otMoney.ToString();
                myTable.Cell(i + rowIndex, 5).Range.Text = payDataList[i].allMoney.ToString();
            }
            rowIndex = rowIndex + payDataList.Count;

            if (billList.Count > 0)
            {

                myTable.Cell(rowIndex, 1).Merge(myTable.Cell(rowIndex, 5));
                myTable.Cell(rowIndex, 1).Range.Text = "津貼";
                myTable.Cell(rowIndex, 1).Range.Font.Bold = 700;
                rowIndex++;
                myTable.Cell(rowIndex, 2).Merge(myTable.Cell(rowIndex, 5));
                myTable.Rows[rowIndex].Cells[1].Width = (float)(tableWidth / 2);
                myTable.Rows[rowIndex].Cells[2].Width = (float)(tableWidth / 2);
                myTable.Cell(rowIndex, 1).Range.Text = "金額";
                myTable.Cell(rowIndex, 2).Range.Text = "備註";

                rowIndex++;
                for (int i = 0; i < billList.Count; i++)
                {
                    myTable.Cell(i + rowIndex, 2).Merge(myTable.Cell(i + rowIndex, 5));
                    myTable.Rows[i + rowIndex].Cells[1].Width = (float)(tableWidth / 2);
                    myTable.Rows[i + rowIndex].Cells[2].Width = (float)(tableWidth / 2);
                    myTable.Cell(i + rowIndex, 1).Range.Text = billList[i].money.ToString();
                    myTable.Cell(i + rowIndex, 2).Range.Text = billList[i].remark;
                }
                rowIndex = rowIndex + billList.Count;
            }
           

            if (bonusList.Count > 0)
            {
                myTable.Cell(rowIndex, 1).Merge(myTable.Cell(rowIndex, 5));
                myTable.Cell(rowIndex, 1).Range.Text = "獎金";
                myTable.Cell(rowIndex, 1).Range.Font.Bold = 700;
                rowIndex++;
                myTable.Cell(rowIndex, 2).Merge(myTable.Cell(rowIndex, 5));
                myTable.Rows[rowIndex].Cells[1].Width = (float)(tableWidth / 2);
                myTable.Rows[rowIndex].Cells[2].Width = (float)(tableWidth / 2);
                myTable.Cell(rowIndex, 1).Range.Text = "金額";
                myTable.Cell(rowIndex, 2).Range.Text = "備註";
                rowIndex++;

                for (int i = 0; i < bonusList.Count; i++)
                {
                    myTable.Cell(i + rowIndex, 2).Merge(myTable.Cell(i + rowIndex, 5));
                    myTable.Rows[i + rowIndex].Cells[1].Width = (float)(tableWidth / 2);
                    myTable.Rows[i + rowIndex].Cells[2].Width = (float)(tableWidth / 2);
                    myTable.Cell(i + rowIndex, 1).Range.Text = bonusList[i].money.ToString();
                    myTable.Cell(i + rowIndex, 2).Range.Text = bonusList[i].remark;
                }
                rowIndex = rowIndex + bonusList.Count;
            }

            myTable.Cell(rowIndex, 2).Merge(myTable.Cell(rowIndex, 5));
            myTable.Rows[rowIndex].Cells[1].Width = (float)(100);
            myTable.Rows[rowIndex].Cells[2].Width = (float)(tableWidth -100);
            myTable.Cell(rowIndex, 1).Range.Text = "總薪資";
         
            myTable.Cell(rowIndex, 1).Range.Font.Bold = 700;
            myTable.Cell(rowIndex, 2).Range.Font.Bold = 700;
            myTable.Cell(rowIndex, 2).Range.Text = labelAllPay.Text;

            myTable.Cell(rowIndex, 2).Range.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphLeft;


            Object oFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;    //格式
            myDoc.SaveAs(ref fileName, ref oFormat,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);  

            Object oFalse = false;
            myDoc.Close(ref oFalse, ref oMissing, ref oMissing);
            return  1;
        }
    }
}
