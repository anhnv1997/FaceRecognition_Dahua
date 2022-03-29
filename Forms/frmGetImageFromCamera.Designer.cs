
namespace FaceRecognition.Forms
{
    partial class frmGetImageFromCamera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetImageFromCamera));
            this.CamTreeview = new System.Windows.Forms.TreeView();
            this.CamLiveview = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.CamPicture = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnTakePicture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CamLiveview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // CamTreeview
            // 
            resources.ApplyResources(this.CamTreeview, "CamTreeview");
            this.CamTreeview.Name = "CamTreeview";
            this.CamTreeview.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.CamTreeview_NodeMouseDoubleClick);
            // 
            // CamLiveview
            // 
            resources.ApplyResources(this.CamLiveview, "CamLiveview");
            this.CamLiveview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CamLiveview.Name = "CamLiveview";
            this.CamLiveview.TabStop = false;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = global::FaceRecognition.Properties.Resources.icons8_save_24;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::FaceRecognition.Properties.Resources.icons8_cancel_24;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CamPicture
            // 
            resources.ApplyResources(this.CamPicture, "CamPicture");
            this.CamPicture.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CamPicture.Name = "CamPicture";
            this.CamPicture.TabStop = false;
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Image = global::FaceRecognition.Properties.Resources.icons8_cancel_24;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnTakePicture
            // 
            resources.ApplyResources(this.btnTakePicture, "btnTakePicture");
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.UseVisualStyleBackColor = true;
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // frmGetImageFromCamera
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTakePicture);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.CamPicture);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.CamLiveview);
            this.Controls.Add(this.CamTreeview);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetImageFromCamera";
            this.Load += new System.EventHandler(this.frmGetImageFromCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CamLiveview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView CamTreeview;
        private System.Windows.Forms.PictureBox CamLiveview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox CamPicture;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnTakePicture;
    }
}