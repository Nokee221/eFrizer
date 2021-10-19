
namespace eFrizer.Win
{
    partial class frmHairDresserManager
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
            this.gbHDM = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.pbHairDresser = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbHDM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHairDresser)).BeginInit();
            this.SuspendLayout();
            // 
            // gbHDM
            // 
            this.gbHDM.Controls.Add(this.txtDescription);
            this.gbHDM.Controls.Add(this.cbStatus);
            this.gbHDM.Controls.Add(this.pbHairDresser);
            this.gbHDM.Controls.Add(this.label3);
            this.gbHDM.Controls.Add(this.label2);
            this.gbHDM.Controls.Add(this.txtSurname);
            this.gbHDM.Controls.Add(this.label1);
            this.gbHDM.Controls.Add(this.txtName);
            this.gbHDM.Location = new System.Drawing.Point(12, 12);
            this.gbHDM.Name = "gbHDM";
            this.gbHDM.Size = new System.Drawing.Size(485, 296);
            this.gbHDM.TabIndex = 0;
            this.gbHDM.TabStop = false;
            this.gbHDM.Text = "Basic information";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(28, 165);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(192, 63);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Text = "";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(28, 243);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(59, 19);
            this.cbStatus.TabIndex = 7;
            this.cbStatus.Text = "Active";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // pbHairDresser
            // 
            this.pbHairDresser.Location = new System.Drawing.Point(273, 30);
            this.pbHairDresser.Name = "pbHairDresser";
            this.pbHairDresser.Size = new System.Drawing.Size(183, 242);
            this.pbHairDresser.TabIndex = 6;
            this.pbHairDresser.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Surname";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(28, 104);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(192, 23);
            this.txtSurname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(28, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(192, 23);
            this.txtName.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(360, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmHairDresserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 353);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbHDM);
            this.Name = "frmHairDresserManager";
            this.Text = "Hair Dresser Manager";
            this.Load += new System.EventHandler(this.frmHairDresserManager_Load);
            this.gbHDM.ResumeLayout(false);
            this.gbHDM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHairDresser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHDM;
        private System.Windows.Forms.PictureBox pbHairDresser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Button btnSave;
    }
}