
namespace FaceRecognition.Forms
{
    partial class frmSelectDisplayMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectDisplayMode));
            this.panel1 = new System.Windows.Forms.Panel();
            this.boderVehicleMode = new System.Windows.Forms.Panel();
            this.picVehicleMode = new System.Windows.Forms.PictureBox();
            this.boderFaceMode = new System.Windows.Forms.Panel();
            this.picFaceMode = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.boderVehicleMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicleMode)).BeginInit();
            this.boderFaceMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFaceMode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.boderVehicleMode);
            this.panel1.Controls.Add(this.boderFaceMode);
            this.panel1.Location = new System.Drawing.Point(12, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 140);
            this.panel1.TabIndex = 0;
            // 
            // boderVehicleMode
            // 
            this.boderVehicleMode.Controls.Add(this.picVehicleMode);
            this.boderVehicleMode.Location = new System.Drawing.Point(136, 3);
            this.boderVehicleMode.Name = "boderVehicleMode";
            this.boderVehicleMode.Size = new System.Drawing.Size(127, 130);
            this.boderVehicleMode.TabIndex = 1;
            // 
            // picVehicleMode
            // 
            this.picVehicleMode.Image = ((System.Drawing.Image)(resources.GetObject("picVehicleMode.Image")));
            this.picVehicleMode.Location = new System.Drawing.Point(3, 3);
            this.picVehicleMode.Name = "picVehicleMode";
            this.picVehicleMode.Size = new System.Drawing.Size(120, 124);
            this.picVehicleMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVehicleMode.TabIndex = 0;
            this.picVehicleMode.TabStop = false;
            this.picVehicleMode.Click += new System.EventHandler(this.picVehicleMode_Click);
            // 
            // boderFaceMode
            // 
            this.boderFaceMode.Controls.Add(this.picFaceMode);
            this.boderFaceMode.Location = new System.Drawing.Point(3, 3);
            this.boderFaceMode.Name = "boderFaceMode";
            this.boderFaceMode.Size = new System.Drawing.Size(127, 130);
            this.boderFaceMode.TabIndex = 1;
            // 
            // picFaceMode
            // 
            this.picFaceMode.Image = ((System.Drawing.Image)(resources.GetObject("picFaceMode.Image")));
            this.picFaceMode.Location = new System.Drawing.Point(3, 3);
            this.picFaceMode.Name = "picFaceMode";
            this.picFaceMode.Size = new System.Drawing.Size(120, 124);
            this.picFaceMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFaceMode.TabIndex = 0;
            this.picFaceMode.TabStop = false;
            this.picFaceMode.Click += new System.EventHandler(this.picFaceMode_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::FaceRecognition.Properties.Resources.icons8_cancel_24;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(208, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::FaceRecognition.Properties.Resources.icons8_save_24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(140, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSelectDisplayMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 215);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectDisplayMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSelectDisplayMode";
            this.Load += new System.EventHandler(this.frmSelectDisplayMode_Load);
            this.panel1.ResumeLayout(false);
            this.boderVehicleMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVehicleMode)).EndInit();
            this.boderFaceMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFaceMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picFaceMode;
        private System.Windows.Forms.Panel boderVehicleMode;
        private System.Windows.Forms.PictureBox picVehicleMode;
        private System.Windows.Forms.Panel boderFaceMode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}