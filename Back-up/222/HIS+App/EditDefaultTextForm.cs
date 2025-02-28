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
using System.Data.SqlClient;
using System.Data;

namespace HISPlus
{
    public partial class EditDefaultTextForm : Form
    {

        DataRow SelectedRow = null;
        string DoctorName;

        public EditDefaultTextForm(DataRow selectedRow,string doctorName)
        {
            InitializeComponent();
            DoctorName = doctorName;
            SelectedRow = selectedRow;

            if (SelectedRow != null)
            {
                uiDefaultText.Text = SelectedRow["DefaultText"].ToString();
                uiDoctorNameTxt.Text = SelectedRow["DoctorName"].ToString();
                uiKindOfOperationCmb.Text = SelectedRow["OperationName"].ToString();
                uiKindOfOperationCmb.Enabled = false;
            }
            else
            {
                AdjustKindOfOperationCmb();
                uiDoctorNameTxt.Text = DoctorName;
                uiDefaultText.Text = null;
            }
            uiDoctorNameTxt.Text = DoctorName;

            using (DBHelper dbhOproom = new DBHelper(ConnectionStrings.OpRoomDB))
            {
               
            }
        }



        private void EditDefaultTextForm_Load(object sender, EventArgs e)
        {

        }

        private void uiKindOfOperationCmb_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void uiKindOfOperationCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedRow = SearechSingleRow();
            if (SelectedRow == null)
                return;
        }

        DataRow SearechSingleRow()
        {
            DBHelper dbhHIS = new DBHelper(ConnectionStrings.HisPlusDB);
            List<string> filters = new List<string>();

            filters.Add(" DoctorName LIKE N'%" + uiDoctorNameTxt.Text + "%' ");
            filters.Add(string.Format(" OperationName LIKE N'%{0}%' ", uiKindOfOperationCmb.Text));
            return
                dbhHIS.SelectSingle("OperationDefaultText", string.Join((" and "), filters.ToArray()));
        }

        void SetSelectedRow()
        {
            SelectedRow["DoctorName"] = uiDoctorNameTxt.Text;
            SelectedRow["OperationName"] = uiKindOfOperationCmb.Text;
            SelectedRow["DefaultText"] = uiDefaultText.Text;
        }

        private void uiSaveButton_Click(object sender, EventArgs e)
        {
            DBHelper dbhHIS = new DBHelper(ConnectionStrings.HisPlusDB);
            SqlDataAdapter da= new SqlDataAdapter();
            
            if (SearechSingleRow() == null)
            {
                SelectedRow = dbhHIS.GetNewRow("OperationDefaultText", out da);
                SetSelectedRow();
                dbhHIS.Insert(SelectedRow, da);
            }
            else
            {
                SetSelectedRow();
                dbhHIS.Update(SelectedRow, da, "OperationDefaultText");
            }
            this.Close();
        }


        void AdjustKindOfOperationCmb()
        {
            using (DBHelper dbhHIS = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                uiKindOfOperationCmb.DataSource = dbhHIS.ExecuteQuery("exec SP_Doctor_Operation @DoctorName = '" + uiDoctorNameTxt.Text + "'");
                uiKindOfOperationCmb.DisplayMember = "Name";
                uiKindOfOperationCmb.ValueMember = "ID";
            }
           
        }

    }
}
