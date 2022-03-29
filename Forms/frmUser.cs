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

namespace FaceRecognition.Forms
{
    public partial class frmUser : Form
    {
        public string _ID;
        public frmUser()
        {
            InitializeComponent();
        }
        public frmUser(string ID)
        {
            InitializeComponent();
            this._ID = ID;
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            List<string> AccessList = new List<string>();
            AccessList.Add(MultiLanguage.GetString("AccessAdmin", StaticPool.Language));
            AccessList.Add(MultiLanguage.GetString("AccessUser", StaticPool.Language));
            cbAccess.DataSource = AccessList;
            cbAccess.SelectedIndex = 0;
            if (this._ID != "")
            {
                User user = StaticPool.users.GetUserById(this._ID);
                txtID.Text = user.ID.ToString();
                txtUsercode.Text = user.Code;
                txtFullname.Text = user.Fullname;
                txtUsername.Text = user.Username;
                txtPassword.Text = user.Password;
                txtRetypePassword.Text = user.Password;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsercode.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("UsercodeEmpty", StaticPool.Language));
                return;
            }
            if (txtFullname.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("FullnameEmpty", StaticPool.Language));
                return;
            }
            if (txtUsername.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("UsernameEmpty", StaticPool.Language));
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("PasswordEmpty", StaticPool.Language));
                return;
            }
            if (!txtPassword.Text.Equals(txtRetypePassword.Text))
            {
                MessageBox.Show(MultiLanguage.GetString("RetypePasswordError", StaticPool.Language));
                return;
            }
            string userCode = txtUsercode.Text;
            string fullName = txtFullname.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int right = cbAccess.SelectedIndex;
            int isLockUser = 0;
            if (chbLock.Checked)
            {
                isLockUser = 1;
            }
            if (this._ID != "")
            {
                if (!StaticPool.mdb.ExecuteCommand($"update tblUser set Fullname ='{fullName}',Code='{userCode}',Username='{username}',Password='{password}',Right1={right},isLockUser={isLockUser} where ID = {this._ID}"))
                {
                    if (!StaticPool.mdb.ExecuteCommand($"update tblUser set Fullname ='{fullName}',Code='{userCode}',Username='{username}',Password='{password}',Right1={right},isLockUser={isLockUser} where ID = {this._ID}"))
                    {
                        MessageBox.Show(MultiLanguage.GetString("UserEditError", StaticPool.Language));
                    }
                }
                else
                {
                    User user = StaticPool.users.GetUserById(this._ID);
                    user.Username = username;
                    user.Code = userCode;
                    user.Password = password;
                    user.Fullname = fullName;
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                //Add
                if (!StaticPool.mdb.ExecuteCommand($"Insert into tblUser values('{fullName}','{userCode}','{username}','{password}',{right},{isLockUser})"))
                {
                    if (!StaticPool.mdb.ExecuteCommand($"Insert into tblUser values('{fullName}','{userCode}','{username}','{password}',{right},{isLockUser})"))
                    {
                        MessageBox.Show(MultiLanguage.GetString("UserAddError", StaticPool.Language));
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }

        }
    }
}
