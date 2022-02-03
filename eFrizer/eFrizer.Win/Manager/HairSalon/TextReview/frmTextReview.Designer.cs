
namespace eFrizer.Win.Manager.HairSalon.TextReview
{
    partial class frmTextReview
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTextReview = new System.Windows.Forms.DataGridView();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HairSalon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Review = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTextReview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.dgvTextReview);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Reviews";
            // 
            // dgvTextReview
            // 
            this.dgvTextReview.AllowUserToAddRows = false;
            this.dgvTextReview.AllowUserToDeleteRows = false;
            this.dgvTextReview.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTextReview.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvTextReview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTextReview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User,
            this.HairSalon,
            this.Review});
            this.dgvTextReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTextReview.Location = new System.Drawing.Point(3, 19);
            this.dgvTextReview.Name = "dgvTextReview";
            this.dgvTextReview.ReadOnly = true;
            this.dgvTextReview.RowTemplate.Height = 25;
            this.dgvTextReview.Size = new System.Drawing.Size(683, 262);
            this.dgvTextReview.TabIndex = 0;
            // 
            // User
            // 
            this.User.DataPropertyName = "ClientUsername";
            this.User.HeaderText = "User";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            // 
            // HairSalon
            // 
            this.HairSalon.DataPropertyName = "HairSalonName";
            this.HairSalon.HeaderText = "HairSalon";
            this.HairSalon.Name = "HairSalon";
            this.HairSalon.ReadOnly = true;
            // 
            // Review
            // 
            this.Review.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Review.DataPropertyName = "Text";
            this.Review.HeaderText = "Review";
            this.Review.Name = "Review";
            this.Review.ReadOnly = true;
            // 
            // frmTextReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 297);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTextReview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTextReview";
            this.Load += new System.EventHandler(this.frmTextReview_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTextReview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTextReview;
        private System.Windows.Forms.DataGridViewTextBoxColumn HairSalon;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Review;
    }
}