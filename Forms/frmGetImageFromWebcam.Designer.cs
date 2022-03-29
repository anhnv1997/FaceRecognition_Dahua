
namespace FaceRecognition.Forms
{
    partial class frmGetImageFromWebcam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetImageFromWebcam));
            this.WebcamLiveview = new System.Windows.Forms.PictureBox();
            this.WebcamPic = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTakePicture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WebcamLiveview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebcamPic)).BeginInit();
            this.SuspendLayout();
            // 
            // WebcamLiveview
            // 
            resources.ApplyResources(this.WebcamLiveview, "WebcamLiveview");
            this.WebcamLiveview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.WebcamLiveview.Name = "WebcamLiveview";
            this.WebcamLiveview.TabStop = false;
            // 
            // WebcamPic
            // 
            resources.ApplyResources(this.WebcamPic, "WebcamPic");
            this.WebcamPic.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.WebcamPic.Name = "WebcamPic";
            this.WebcamPic.TabStop = false;
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
            this.btnCancel.Image = global::FaceRecognition.Properties.Resources.icons8_cancel_24;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnTakePicture
            // 
            resources.ApplyResources(this.btnTakePicture, "btnTakePicture");
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.UseVisualStyleBackColor = true;
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // frmGetImageFromWebcam
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTakePicture);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.WebcamPic);
            this.Controls.Add(this.WebcamLiveview);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetImageFromWebcam";
            this.Load += new System.EventHandler(this.frmGetImageFromWebcam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WebcamLiveview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebcamPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox WebcamLiveview;
        private System.Windows.Forms.PictureBox WebcamPic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTakePicture;
    }
}