using FaceRecognition.Forms;
using FaceRecognition.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition.UserControls
{
    public partial class ucUser : UserControl
    {
        public ucUser()
        {
            InitializeComponent();
            dgvUser.ToggleDoubleBuffered(true);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser("");
            frm.Text = MultiLanguage.GetString("frmUserAdd", StaticPool.Language);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                GetUser();
                LoadDataGridView();
            }

        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.Id() != "")
            {
                frmUser frm = new frmUser(this.Id());
                frm.Text = MultiLanguage.GetString("frmUserEdit", StaticPool.Language);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    LoadDataGridView();
                }
            }
            else
            {
                MessageBox.Show(MultiLanguage.GetString("RecordSelectRequest", StaticPool.Language));
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.Id() == "")
            {
                MessageBox.Show(MultiLanguage.GetString("RecordSelectRequest", StaticPool.Language));
                return;
            }

            if (MessageBox.Show("deleteconfirm", "deletetitle", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //Xoa tren database
                if (!StaticPool.mdb.ExecuteCommand($"Delete tblUser Where ID = {this.Id()}"))
                {
                    if (!StaticPool.mdb.ExecuteCommand($"Delete tblUser Where ID = {this.Id()}"))
                    {
                        MessageBox.Show(MultiLanguage.GetString("UserDeleteError", StaticPool.Language));
                        return;
                    }
                }
                //Update hien thi sau xoa
                User user = StaticPool.users.GetUserById(this.Id());
                StaticPool.users.Remove(user);
                LoadDataGridView();
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            GetUser();
            LoadDataGridView();
        }
        public void GetUser()
        {
            dgvUser.Rows.Clear();
            StaticPool.users.Clear();
            DataTable dtUser = StaticPool.mdb.FillData("Select * from tblUser order by ID");
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    User user = new User();
                    user.ID = row["ID"].ToString();
                    user.Fullname = row["Fullname"].ToString();
                    user.Code = row["Code"].ToString();
                    user.Username = row["Username"].ToString();
                    user.Password = row["Password"].ToString();
                    switch (row["Right1"].ToString())
                    {
                        case "1":
                            user.Right = true;
                            break;
                        case "0":
                            user.Right = false;
                            break;
                    }
                    StaticPool.users.Add(user);
                }
                dtUser.Dispose();
            }

        }
        public void LoadDataGridView()
        {
            dgvUser.Rows.Clear();
            foreach (User user in StaticPool.users)
            {
                dgvUser.Rows.Add(user.ID, user.Fullname, user.Username, user.Password);
            }
        }
        public string Id()
        {
            string _lcma = "";
            DataGridViewRow _drv = dgvUser.CurrentRow;
            try
            {
                _lcma = _drv.Cells[0].Value.ToString();
            }
            catch
            {
                _lcma = "";
            }
            return _lcma;
        }
    }
}
