
namespace eFrizer.Win.Review
{
    partial class frmReview
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
            this.dgvReview = new System.Windows.Forms.DataGridView();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HairSalon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StarRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvReview);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reviews";
            // 
            // dgvReview
            // 
            this.dgvReview.AllowUserToAddRows = false;
            this.dgvReview.AllowUserToDeleteRows = false;
            this.dgvReview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User,
            this.HairSalon,
            this.Text,
            this.StarRating,
            this.Action});
            this.dgvReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReview.Location = new System.Drawing.Point(3, 19);
            this.dgvReview.Name = "dgvReview";
            this.dgvReview.ReadOnly = true;
            this.dgvReview.RowTemplate.Height = 25;
            this.dgvReview.Size = new System.Drawing.Size(768, 207);
            this.dgvReview.TabIndex = 0;
            // 
            // User
            // 
            this.User.DataPropertyName = "ClientName";
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
            // Text
            // 
            this.Text.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Text.DataPropertyName = "Text";
            this.Text.HeaderText = "TextReview";
            this.Text.Name = "Text";
            this.Text.ReadOnly = true;
            // 
            // StarRating
            // 
            this.StarRating.DataPropertyName = "StarRating";
            this.StarRating.HeaderText = "StarRating";
            this.StarRating.Name = "StarRating";
            this.StarRating.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Text = "Delete";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // frmReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 243);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReview";
            this.Load += new System.EventHandler(this.frmReview_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvReview;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn HairSalon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
        private System.Windows.Forms.DataGridViewTextBoxColumn StarRating;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}