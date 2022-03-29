using FaceRecognition.Databases;
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
    public partial class ucCamera : UserControl
    {
        public ucCamera()
        {
            InitializeComponent();
            dgvCamera.ToggleDoubleBuffered(true);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            frmCamera frm = new frmCamera("");
            frm.Text = MultiLanguage.GetString("frmCameraAdd", StaticPool.Language);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {                
                LoadDataGridView();
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.Id() != "")
            {
                frmCamera frm = new frmCamera(this.Id());
                frm.Text = MultiLanguage.GetString("frmCameraEdit", StaticPool.Language);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    LoadDataGridView();
                }
            }
            else
            {
                MessageBox.Show(MultiLanguage.GetString("RecordSelectRequest",StaticPool.Language));
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.Id() == "")
            {
                MessageBox.Show(MultiLanguage.GetString("RecordSelectRequest", StaticPool.Language));
                return;
            }

            if (MessageBox.Show(MultiLanguage.GetString("DeleteConfirm",StaticPool.Language), MultiLanguage.GetString("DeleteTittleCamera", StaticPool.Language), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //Xoa tren database
                if (!tblCamera.Delete(this.Id()))
                {
                    MessageBox.Show(MultiLanguage.GetString("CameraDeleteError", StaticPool.Language));
                    return;
                }
                //Update hien thi sau xoa
                Camera cam = StaticPool.cams.GetCameraById(this.Id());
                StaticPool.cams.Remove(cam);
                LoadDataGridView();
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            GetCamera();
            LoadDataGridView();
        }
        public void GetCamera()
        {
            tblCamera.LoadDataCamera(StaticPool.cams);

        }
        public void LoadDataGridView()
        {
            dgvCamera.Rows.Clear();
            foreach (Camera camera in StaticPool.cams)
            {
                dgvCamera.Rows.Add(camera.Id, camera.Name, camera.Type, camera.Com, camera.IP, camera.Port, camera.Username, camera.Password, camera.Channel);
            }
        }
        public string Id()
        {
            string _lcma = "";
            DataGridViewRow _drv = dgvCamera.CurrentRow;
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