
namespace eFrizer.Win.Service
{
    partial class frmService
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
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServiceId = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtView = new System.Windows.Forms.Button();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvServices
            // 
            this.dgvServices.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Time,
            this.Price,
            this.Description});
            this.dgvServices.Location = new System.Drawing.Point(13, 54);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.RowTemplate.Height = 25;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.Size = new System.Drawing.Size(457, 256);
            this.dgvServices.TabIndex = 0;
            this.dgvServices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServices_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtServiceId);
            this.groupBox1.Controls.Add(this.btnSaveChanges);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 338);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtTime.Location = new System.Drawing.Point(55, 129);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(71, 23);
            this.txtTime.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(7, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Time:";
            // 
            // txtServiceId
            // 
            this.txtServiceId.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtServiceId.Location = new System.Drawing.Point(441, 272);
            this.txtServiceId.Name = "txtServiceId";
            this.txtServiceId.ReadOnly = true;
            this.txtServiceId.Size = new System.Drawing.Size(10, 23);
            this.txtServiceId.TabIndex = 8;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveChanges.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSaveChanges.Location = new System.Drawing.Point(319, 301);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(132, 30);
            this.btnSaveChanges.TabIndex = 7;
            this.btnSaveChanges.Text = "Save changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCreate.Location = new System.Drawing.Point(7, 301);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(112, 31);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtDesc.Location = new System.Drawing.Point(7, 199);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(433, 96);
            this.txtDesc.TabIndex = 5;
            this.txtDesc.Text = "";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrice.Location = new System.Drawing.Point(55, 83);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(109, 23);
            this.txtPrice.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtName.Location = new System.Drawing.Point(55, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 23);
            this.txtName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(7, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(7, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Name: ";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSearch.Location = new System.Drawing.Point(68, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // txtView
            // 
            this.txtView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtView.ForeColor = System.Drawing.SystemColors.Control;
            this.txtView.Location = new System.Drawing.Point(335, 21);
            this.txtView.Name = "txtView";
            this.txtView.Size = new System.Drawing.Size(135, 27);
            this.txtView.TabIndex = 4;
            this.txtView.Text = "Search";
            this.txtView.UseVisualStyleBackColor = false;
            this.txtView.Click += new System.EventHandler(this.txtView_Click);
            // 
            // Name
            // 
            this.Name.DataPropertyName = "ServiceName";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // Time
            // 
            this.Time.DataPropertyName = "TimeMin";
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 666);
            this.Controls.Add(this.txtView);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvServices);
            this.Name = "frmService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmService";
            this.Load += new System.EventHandler(this.frmService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSaveC;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.TextBox txtServiceId;
        private System.Windows.Forms.Button txtView;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}