using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace HISPlus
{
    public partial class DefaultReportForm : Form
    {

        static string DoctorName;
        
        

        public DataRow SelectedRow
        {
            get
            {
                if (uiDefaltTextGrid.CurrentRow == null)
                    return null;
                return ((System.Data.DataRowView)(uiDefaltTextGrid.CurrentRow.DataBoundItem)).Row;
            }
        }

        public DefaultReportForm()
        {
            InitializeComponent();
            uiDeleteButton.Enabled = false;
            using (DBHelper dbhOproom = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                uiDoctorCmBox.DisplayMember = "Name";
                uiDoctorCmBox.ValueMember = "ID";
                uiDoctorCmBox.DataSource = dbhOproom.Select("Doctor");
            }

            FillGrid();

        }

        void FillGrid()
        {
            using (DBHelper dbhHIS = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                uiDefaltTextGrid.Refresh();
                string filters = null;
                if (uiDoctorCmBox.Text != null)
                {
                    filters = " DoctorName LIKE N'%" + uiDoctorCmBox.Text + "%'";
                    uiDefaltTextGrid.DataSource = dbhHIS.Select("OperationDefaultText", filters);
                }
                else
                    uiDefaltTextGrid.DataSource = null;
            }
        }
        private void DefaultReportForm_Load(object sender, EventArgs e)
        {
            
        }

        private void uiNewButton_Click(object sender, EventArgs e)
        {
            EditDefaultTextForm newDefaultText = new EditDefaultTextForm(null, DoctorName);
            newDefaultText.Show();
        }

        private void uiShowButton_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void uiDefaltTextGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void uiDoctorCmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
            DoctorName = uiDoctorCmBox.Text;
        }

        private void uiDeleteButton_Click(object sender, EventArgs e)
        {
            DBHelper dbhHIS = new DBHelper(ConnectionStrings.HisPlusDB);
            dbhHIS.Delete("OperationDefaultText", SelectedRow["ID"].ToString());
            FillGrid();
        }

        private void uiDefaltTextGrid_SelectionChanged(object sender, EventArgs e)
        {
            uiDeleteButton.Enabled = true;
        }

        private void uiEditButton_Click(object sender, EventArgs e)
        {
            EditDefaultTextForm newDefaultText = new EditDefaultTextForm(SelectedRow, DoctorName);
            newDefaultText.Show();
        }


    }
}
