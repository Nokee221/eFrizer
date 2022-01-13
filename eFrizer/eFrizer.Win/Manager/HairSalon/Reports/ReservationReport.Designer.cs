
namespace eFrizer.Win
{
    partial class ReservationReport
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
            this.btnReservation = new System.Windows.Forms.Button();
            this.dtpReservationFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpReservationTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnServiceReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpServiceFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpServiceTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFinancial = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFinancialFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFinancialTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReservation
            // 
            this.btnReservation.Location = new System.Drawing.Point(534, 41);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(218, 23);
            this.btnReservation.TabIndex = 0;
            this.btnReservation.Text = "Generate report";
            this.btnReservation.UseVisualStyleBackColor = true;
            this.btnReservation.Click += new System.EventHandler(this.btnReservation_Click);
            // 
            // dtpReservationFrom
            // 
            this.dtpReservationFrom.Location = new System.Drawing.Point(49, 41);
            this.dtpReservationFrom.Name = "dtpReservationFrom";
            this.dtpReservationFrom.Size = new System.Drawing.Size(200, 23);
            this.dtpReservationFrom.TabIndex = 1;
            // 
            // dtpReservationTo
            // 
            this.dtpReservationTo.Location = new System.Drawing.Point(299, 41);
            this.dtpReservationTo.Name = "dtpReservationTo";
            this.dtpReservationTo.Size = new System.Drawing.Size(200, 23);
            this.dtpReservationTo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "From:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReservation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpReservationFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpReservationTo);
            this.groupBox1.Location = new System.Drawing.Point(12, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservation report";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnServiceReport);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpServiceFrom);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpServiceTo);
            this.groupBox2.Location = new System.Drawing.Point(12, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service report";
            // 
            // btnServiceReport
            // 
            this.btnServiceReport.Location = new System.Drawing.Point(534, 41);
            this.btnServiceReport.Name = "btnServiceReport";
            this.btnServiceReport.Size = new System.Drawing.Size(218, 23);
            this.btnServiceReport.TabIndex = 0;
            this.btnServiceReport.Text = "Generate report";
            this.btnServiceReport.UseVisualStyleBackColor = true;
            this.btnServiceReport.Click += new System.EventHandler(this.btnServiceReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "From:";
            // 
            // dtpServiceFrom
            // 
            this.dtpServiceFrom.Location = new System.Drawing.Point(49, 41);
            this.dtpServiceFrom.Name = "dtpServiceFrom";
            this.dtpServiceFrom.Size = new System.Drawing.Size(200, 23);
            this.dtpServiceFrom.TabIndex = 1;
            this.dtpServiceFrom.ValueChanged += new System.EventHandler(this.dtpServiceFrom_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "To:";
            // 
            // dtpServiceTo
            // 
            this.dtpServiceTo.Location = new System.Drawing.Point(299, 41);
            this.dtpServiceTo.Name = "dtpServiceTo";
            this.dtpServiceTo.Size = new System.Drawing.Size(200, 23);
            this.dtpServiceTo.TabIndex = 2;
            this.dtpServiceTo.ValueChanged += new System.EventHandler(this.dtpServiceTo_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFinancial);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpFinancialFrom);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dtpFinancialTo);
            this.groupBox3.Location = new System.Drawing.Point(12, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 100);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Financial report";
            // 
            // btnFinancial
            // 
            this.btnFinancial.Location = new System.Drawing.Point(534, 41);
            this.btnFinancial.Name = "btnFinancial";
            this.btnFinancial.Size = new System.Drawing.Size(218, 23);
            this.btnFinancial.TabIndex = 0;
            this.btnFinancial.Text = "Generate report";
            this.btnFinancial.UseVisualStyleBackColor = true;
            this.btnFinancial.Click += new System.EventHandler(this.btnFinancial_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "From:";
            // 
            // dtpFinancialFrom
            // 
            this.dtpFinancialFrom.Location = new System.Drawing.Point(49, 41);
            this.dtpFinancialFrom.Name = "dtpFinancialFrom";
            this.dtpFinancialFrom.Size = new System.Drawing.Size(200, 23);
            this.dtpFinancialFrom.TabIndex = 1;
            this.dtpFinancialFrom.ValueChanged += new System.EventHandler(this.dtpFinancialFrom_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "To:";
            // 
            // dtpFinancialTo
            // 
            this.dtpFinancialTo.Location = new System.Drawing.Point(299, 41);
            this.dtpFinancialTo.Name = "dtpFinancialTo";
            this.dtpFinancialTo.Size = new System.Drawing.Size(200, 23);
            this.dtpFinancialTo.TabIndex = 2;
            this.dtpFinancialTo.ValueChanged += new System.EventHandler(this.dtpFinancialTo_ValueChanged);
            // 
            // ReservationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReservationReport";
            this.Text = "ReservationReport";
            this.Load += new System.EventHandler(this.ReservationReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.DateTimePicker dtpReservationFrom;
        private System.Windows.Forms.DateTimePicker dtpReservationTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnServiceReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpServiceFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpServiceTo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFinancial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFinancialFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFinancialTo;
    }
}