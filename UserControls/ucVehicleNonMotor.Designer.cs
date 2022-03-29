
namespace FaceRecognition.UserControls
{
    partial class ucVehicleNonMotor
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
            this.PicGlobal = new System.Windows.Forms.PictureBox();
            this.PicVehicle = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicGlobal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // PicGlobal
            // 
            this.PicGlobal.Location = new System.Drawing.Point(5, 50);
            this.PicGlobal.Name = "PicGlobal";
            this.PicGlobal.Size = new System.Drawing.Size(180, 150);
            this.PicGlobal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicGlobal.TabIndex = 0;
            this.PicGlobal.TabStop = false;
            // 
            // PicVehicle
            // 
            this.PicVehicle.Location = new System.Drawing.Point(191, 50);
            this.PicVehicle.Name = "PicVehicle";
            this.PicVehicle.Size = new System.Drawing.Size(180, 150);
            this.PicVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicVehicle.TabIndex = 0;
            this.PicVehicle.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(5, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 1);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vehicle Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Non Motor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vehicle Color";
            // 
            // txtColor
            // 
            this.txtColor.AutoSize = true;
            this.txtColor.Location = new System.Drawing.Point(87, 31);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(50, 15);
            this.txtColor.TabIndex = 5;
            this.txtColor.Text = "txtColor";
            // 
            // ucVehicleNonMotor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PicVehicle);
            this.Controls.Add(this.PicGlobal);
            this.Name = "ucVehicleNonMotor";
            this.Size = new System.Drawing.Size(374, 215);
            ((System.ComponentModel.ISupportInitialize)(this.PicGlobal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicVehicle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicGlobal;
        private System.Windows.Forms.PictureBox PicVehicle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtColor;
    }
}
