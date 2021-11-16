
namespace eFrizer.Win
{
    partial class frmLoyalty
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
            this.cbService = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLoyalty = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbExpiration = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveBonus = new System.Windows.Forms.Button();
            this.cbActivatesOn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoyalty)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbService
            // 
            this.cbService.FormattingEnabled = true;
            this.cbService.Location = new System.Drawing.Point(69, 32);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(121, 23);
            this.cbService.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Service:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLoyalty);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 302);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Defined loyalty bonuses";
            // 
            // dgvLoyalty
            // 
            this.dgvLoyalty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoyalty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoyalty.Location = new System.Drawing.Point(3, 19);
            this.dgvLoyalty.Name = "dgvLoyalty";
            this.dgvLoyalty.RowTemplate.Height = 25;
            this.dgvLoyalty.Size = new System.Drawing.Size(770, 280);
            this.dgvLoyalty.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbExpiration);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSaveBonus);
            this.groupBox2.Controls.Add(this.cbActivatesOn);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbService);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 118);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add new loyalty bonus";
            // 
            // cbExpiration
            // 
            this.cbExpiration.FormattingEnabled = true;
            this.cbExpiration.Location = new System.Drawing.Point(618, 32);
            this.cbExpiration.Name = "cbExpiration";
            this.cbExpiration.Size = new System.Drawing.Size(152, 23);
            this.cbExpiration.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(555, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Expires in";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(266, 33);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(59, 23);
            this.txtDiscount.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Discount(%)";
            // 
            // btnSaveBonus
            // 
            this.btnSaveBonus.Location = new System.Drawing.Point(618, 77);
            this.btnSaveBonus.Name = "btnSaveBonus";
            this.btnSaveBonus.Size = new System.Drawing.Size(155, 23);
            this.btnSaveBonus.TabIndex = 10;
            this.btnSaveBonus.Text = "Save bonus";
            this.btnSaveBonus.UseVisualStyleBackColor = true;
            // 
            // cbActivatesOn
            // 
            this.cbActivatesOn.FormattingEnabled = true;
            this.cbActivatesOn.Location = new System.Drawing.Point(412, 32);
            this.cbActivatesOn.Name = "cbActivatesOn";
            this.cbActivatesOn.Size = new System.Drawing.Size(137, 23);
            this.cbActivatesOn.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Activates on:";
            // 
            // frmLoyalty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLoyalty";
            this.Text = "Loyalty";
            this.Load += new System.EventHandler(this.Loyalty_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoyalty)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLoyalty;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveBonus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbExpiration;
        private System.Windows.Forms.ComboBox cbActivatesOn;
    }
}