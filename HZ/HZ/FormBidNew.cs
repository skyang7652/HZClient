using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace HZ
{
    public partial class FormBidNew : Form
    {

        public static string bidName = null;
        public static string bidAbbreviation = null;
        public static string bidMoney = null;
        public static string bidBond = null;
        public static string bidStartDate = null;
        public static string bidEndDate = null;
        public static string bidType = null;

        public FormBidNew()
        {
            InitializeComponent();
        }

        private void buttonNewBid_Click(object sender, EventArgs e)
        {
            bidName = textBoxBidName.Text;
            bidAbbreviation = textBoxBidAbbreviation.Text;
            bidMoney = Convert.ToString(numBIdMoney.Value);
            bidBond = Convert.ToString(numBidBond.Value);
            bidStartDate = Convert.ToString(textBoxStartDate);
            bidEndDate = Convert.ToString(textBoxEndDate);
            bidType = "false";
            string api = API.getApi((int)ENUM.API_t.API_NEW_BID);

            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("bidName", bidName),
                    new KeyValuePair<string, string>("bidAbbreviation", bidAbbreviation),
                    new KeyValuePair<string, string>("bidMoney", bidMoney),
                    new KeyValuePair<string, string>("bidBond", bidBond),
                    new KeyValuePair<string, string>("bidStartDate", bidStartDate),
                    new KeyValuePair<string, string>("bidEndDate", bidEndDate),
                    new KeyValuePair<string, string>("bidType", bidType),
                };


            Task<string> task = System.Threading.Tasks.Task.Run(() => Func.PostRequest(api, queries));

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

        private void FormBidNew_Load(object sender, EventArgs e)
        {

        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Title = "Open Image File";
            opd.Filter = "Doc|*.doc";

            if (opd.ShowDialog() == System.Windows.Forms.DialogResult.OK && opd.FileName != null)
            {
                string fileName = opd.FileName;
                openWord(fileName);
            }
        }

        private void openWord(string fileName)
        {
            try
            {
                object oMissing = System.Reflection.Missing.Value;
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = false;
                object Name = fileName;
                oDoc = oWord.Documents.Open(ref Name,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                int tableCount = oDoc.Tables.Count;   //文檔中表格的個數

                string temp = oDoc.Paragraphs[3].Range.Text.Trim();
                string test = temp.Remove(0, 6);
                textBoxBidName.Text = test;
            }
            catch
            {

            }
        }

        private void buttonDateStart_Click(object sender, EventArgs e)
        {
         
            monthCalendarDate.Visible = true;
            monthCalendarDate.BringToFront();
            monthCalendarDate.Location = numBIdMoney.Location;
            monthCalendarDate.DateSelected += new DateRangeEventHandler(monthCalendar_DateSelected_Start);
        }
        private void monthCalendar_DateSelected_Start(object sender, DateRangeEventArgs e)
        {
            monthCalendarDate.DateSelected -= new DateRangeEventHandler(monthCalendar_DateSelected_Start);
            textBoxStartDate.Text = e.Start.ToShortDateString();
            monthCalendarDate.Visible = false;
        }

        private void buttonDateEnd_Click(object sender, EventArgs e)
        {
            
            monthCalendarDate.Visible = true;
            monthCalendarDate.BringToFront();
            monthCalendarDate.Location = numBIdMoney.Location;
            monthCalendarDate.DateSelected += new DateRangeEventHandler(monthCalendar_DateSelected_End);
        }
        private void monthCalendar_DateSelected_End(object sender, DateRangeEventArgs e)
        {
            monthCalendarDate.DateSelected -= new DateRangeEventHandler(monthCalendar_DateSelected_End);
            textBoxEndDate.Text = e.Start.ToShortDateString();
            monthCalendarDate.Visible = false;
        }
    }
}
