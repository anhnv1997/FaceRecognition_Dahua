
namespace FaceRecognition
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.ucUser1 = new FaceRecognition.UserControls.ucUser();
            this.tabCamera = new System.Windows.Forms.TabPage();
            this.ucCamera1 = new FaceRecognition.UserControls.ucCamera();
            this.tabGroupFace = new System.Windows.Forms.TabPage();
            this.ucGroupFace1 = new FaceRecognition.UserControls.ucGroupFace();
            this.tabPersonFace = new System.Windows.Forms.TabPage();
            this.ucFacePerson2 = new FaceRecognition.UserControls.ucFacePerson();
            this.tabFaceRecognize = new System.Windows.Forms.TabPage();
            this.ucFaceRecognize1 = new FaceRecognition.UserControls.ucFaceRecognize();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabCamera.SuspendLayout();
            this.tabGroupFace.SuspendLayout();
            this.tabPersonFace.SuspendLayout();
            this.tabFaceRecognize.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabOption);
            this.tabControl1.Controls.Add(this.tabUser);
            this.tabControl1.Controls.Add(this.tabCamera);
            this.tabControl1.Controls.Add(this.tabGroupFace);
            this.tabControl1.Controls.Add(this.tabPersonFace);
            this.tabControl1.Controls.Add(this.tabFaceRecognize);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabOption
            // 
            resources.ApplyResources(this.tabOption, "tabOption");
            this.tabOption.Controls.Add(this.txtServerName);
            this.tabOption.Controls.Add(this.label1);
            this.tabOption.Name = "tabOption";
            this.tabOption.UseVisualStyleBackColor = true;
            // 
            // txtServerName
            // 
            resources.ApplyResources(this.txtServerName, "txtServerName");
            this.txtServerName.Name = "txtServerName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabUser
            // 
            resources.ApplyResources(this.tabUser, "tabUser");
            this.tabUser.Controls.Add(this.ucUser1);
            this.tabUser.Name = "tabUser";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // ucUser1
            // 
            resources.ApplyResources(this.ucUser1, "ucUser1");
            this.ucUser1.Name = "ucUser1";
            // 
            // tabCamera
            // 
            resources.ApplyResources(this.tabCamera, "tabCamera");
            this.tabCamera.Controls.Add(this.ucCamera1);
            this.tabCamera.Name = "tabCamera";
            this.tabCamera.UseVisualStyleBackColor = true;
            // 
            // ucCamera1
            // 
            resources.ApplyResources(this.ucCamera1, "ucCamera1");
            this.ucCamera1.Name = "ucCamera1";
            // 
            // tabGroupFace
            // 
            resources.ApplyResources(this.tabGroupFace, "tabGroupFace");
            this.tabGroupFace.Controls.Add(this.ucGroupFace1);
            this.tabGroupFace.Name = "tabGroupFace";
            this.tabGroupFace.UseVisualStyleBackColor = true;
            // 
            // ucGroupFace1
            // 
            resources.ApplyResources(this.ucGroupFace1, "ucGroupFace1");
            this.ucGroupFace1.Name = "ucGroupFace1";
            // 
            // tabPersonFace
            // 
            resources.ApplyResources(this.tabPersonFace, "tabPersonFace");
            this.tabPersonFace.Controls.Add(this.ucFacePerson2);
            this.tabPersonFace.Name = "tabPersonFace";
            this.tabPersonFace.UseVisualStyleBackColor = true;
            // 
            // ucFacePerson2
            // 
            resources.ApplyResources(this.ucFacePerson2, "ucFacePerson2");
            this.ucFacePerson2.Name = "ucFacePerson2";
            // 
            // tabFaceRecognize
            // 
            resources.ApplyResources(this.tabFaceRecognize, "tabFaceRecognize");
            this.tabFaceRecognize.Controls.Add(this.ucFaceRecognize1);
            this.tabFaceRecognize.Name = "tabFaceRecognize";
            this.tabFaceRecognize.UseVisualStyleBackColor = true;
            // 
            // ucFaceRecognize1
            // 
            resources.ApplyResources(this.ucFaceRecognize1, "ucFaceRecognize1");
            this.ucFaceRecognize1.Name = "ucFaceRecognize1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Image = global::FaceRecognition.Properties.Resources.icons8_save_24;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = global::FaceRecognition.Properties.Resources.icons8_cancel_24;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmSetting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSetting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabOption.ResumeLayout(false);
            this.tabOption.PerformLayout();
            this.tabUser.ResumeLayout(false);
            this.tabCamera.ResumeLayout(false);
            this.tabGroupFace.ResumeLayout(false);
            this.tabPersonFace.ResumeLayout(false);
            this.tabFaceRecognize.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOption;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage tabCamera;
        private System.Windows.Forms.TabPage tabGroupFace;
        private System.Windows.Forms.TabPage tabPersonFace;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label1;
        private UserControls.ucUser ucUser1;
        private UserControls.ucCamera ucCamera1;
        private UserControls.ucGroupFace ucGroupFace1;
        private UserControls.ucFacePerson ucFacePerson1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private UserControls.ucFacePerson ucFacePerson2;
        private System.Windows.Forms.TabPage tabFaceRecognize;
        private UserControls.ucFaceRecognize ucFaceRecognize1;
    }
}