using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace HZ
{   
    public partial class Main : Form
    {

       public FormEmployeeNew formEmployeeNew = null;
       public FormEmployee formEmployee = null;
       public FormBidNew formBidNew = null;
       public FormSalary formSalary = null;
       public FormBid formBid = null;
       public FormBidPhoto formBidPhoto = null;
        public Main()
        {
            InitializeComponent();
        }

        
       
        private void Main_Load(object sender, EventArgs e)
        {
            int ret = API.checkLink();

            if(ret > 0)
            {
                MessageBox.Show("連線成功....");
            }
            else
            {
                MessageBox.Show("連線失敗....");
                
            }

        
        }

        private void ToolStripMenuItemEmployeeNew_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            formEmployeeNew = new FormEmployeeNew();
            formEmployeeNew.MdiParent = this;
            formEmployeeNew.Show();
        }

        private void ToolStripMenuItemEmployeeData_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            formEmployee = new FormEmployee();
            formEmployee.MdiParent = this;
            formEmployee.Show();
        }

        private void ToolStripMenuItemBidNew_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            formBidNew = new FormBidNew();
            formBidNew.MdiParent = this;
            formBidNew.Show();
        }

        private void ToolStripMenuItemSalary_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            formSalary = new FormSalary();
            formSalary.MdiParent = this;
            formSalary.Show();
        }

        private void ToolStripMenuItemBidData_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            formBid = new FormBid();
            formBid.MdiParent = this;
            formBid.Show();
        }

        private void ToolStripMenuItemBidPhoto_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            formBidPhoto = new FormBidPhoto();
            formBidPhoto.MdiParent = this;
            formBidPhoto.Show();
        }


    }
}
