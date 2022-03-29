
namespace FaceRecognition.UserControls
{
    partial class ucEventWithCandidate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEventWithCandidate));
            this.picFaceImage = new System.Windows.Forms.PictureBox();
            this.picCandidateImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBeard = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMask = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFaceImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCandidateImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picFaceImage
            // 
            resources.ApplyResources(this.picFaceImage, "picFaceImage");
            this.picFaceImage.Name = "picFaceImage";
            this.picFaceImage.TabStop = false;
            // 
            // picCandidateImage
            // 
            resources.ApplyResources(this.picCandidateImage, "picCandidateImage");
            this.picCandidateImage.Name = "picCandidateImage";
            this.picCandidateImage.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtGroupName
            // 
            resources.ApplyResources(this.txtGroupName, "txtGroupName");
            this.txtGroupName.Name = "txtGroupName";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtSex
            // 
            resources.ApplyResources(this.txtSex, "txtSex");
            this.txtSex.Name = "txtSex";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // txtPosition
            // 
            resources.ApplyResources(this.txtPosition, "txtPosition");
            this.txtPosition.Name = "txtPosition";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtBeard
            // 
            resources.ApplyResources(this.txtBeard, "txtBeard");
            this.txtBeard.Name = "txtBeard";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtMask
            // 
            resources.ApplyResources(this.txtMask, "txtMask");
            this.txtMask.Name = "txtMask";
            // 
            // ucEventWithCandidate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBeard);
            this.Controls.Add(this.txtMask);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCandidateImage);
            this.Controls.Add(this.picFaceImage);
            this.PersonName = "ucEventWithCandidate";
            this.Load += new System.EventHandler(this.ucEventWithCandidate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFaceImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCandidateImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFaceImage;
        private System.Windows.Forms.PictureBox picCandidateImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtGroupName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtSex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtBirthday;
        private System.Windows.Forms.Label txtCardType;
        private System.Windows.Forms.Label txtCardID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtPosition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtBeard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtMask;
    }
}
