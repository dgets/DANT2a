namespace DANT2a {
  partial class AddTimer {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.lblName = new System.Windows.Forms.Label();
      this.lblDuration = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.tbxName = new System.Windows.Forms.TextBox();
      this.nudHrs = new System.Windows.Forms.NumericUpDown();
      this.nudMin = new System.Windows.Forms.NumericUpDown();
      this.nudSec = new System.Windows.Forms.NumericUpDown();
      this.lblHrs = new System.Windows.Forms.Label();
      this.lblMin = new System.Windows.Forms.Label();
      this.lblSec = new System.Windows.Forms.Label();
      this.btnAddTimer = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.nudHrs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSec)).BeginInit();
      this.SuspendLayout();
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(44, 13);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(38, 13);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Name:";
      // 
      // lblDuration
      // 
      this.lblDuration.AutoSize = true;
      this.lblDuration.Location = new System.Drawing.Point(32, 45);
      this.lblDuration.Name = "lblDuration";
      this.lblDuration.Size = new System.Drawing.Size(50, 13);
      this.lblDuration.TabIndex = 1;
      this.lblDuration.Text = "Duration:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 77);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(70, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Timer Sound:";
      // 
      // tbxName
      // 
      this.tbxName.Location = new System.Drawing.Point(88, 6);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new System.Drawing.Size(100, 20);
      this.tbxName.TabIndex = 3;
      this.tbxName.Click += new System.EventHandler(this.tbxName_Enter);
      this.tbxName.Enter += new System.EventHandler(this.tbxName_Enter);
      this.tbxName.Leave += new System.EventHandler(this.tbxName_Leave);
      // 
      // nudHrs
      // 
      this.nudHrs.Location = new System.Drawing.Point(88, 38);
      this.nudHrs.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
      this.nudHrs.Name = "nudHrs";
      this.nudHrs.Size = new System.Drawing.Size(40, 20);
      this.nudHrs.TabIndex = 4;
      // 
      // nudMin
      // 
      this.nudMin.Location = new System.Drawing.Point(173, 38);
      this.nudMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
      this.nudMin.Name = "nudMin";
      this.nudMin.Size = new System.Drawing.Size(44, 20);
      this.nudMin.TabIndex = 5;
      // 
      // nudSec
      // 
      this.nudSec.Location = new System.Drawing.Point(266, 38);
      this.nudSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
      this.nudSec.Name = "nudSec";
      this.nudSec.Size = new System.Drawing.Size(40, 20);
      this.nudSec.TabIndex = 6;
      // 
      // lblHrs
      // 
      this.lblHrs.AutoSize = true;
      this.lblHrs.Location = new System.Drawing.Point(134, 45);
      this.lblHrs.Name = "lblHrs";
      this.lblHrs.Size = new System.Drawing.Size(23, 13);
      this.lblHrs.TabIndex = 7;
      this.lblHrs.Text = "Hrs";
      // 
      // lblMin
      // 
      this.lblMin.AutoSize = true;
      this.lblMin.Location = new System.Drawing.Point(223, 45);
      this.lblMin.Name = "lblMin";
      this.lblMin.Size = new System.Drawing.Size(24, 13);
      this.lblMin.TabIndex = 8;
      this.lblMin.Text = "Min";
      // 
      // lblSec
      // 
      this.lblSec.AutoSize = true;
      this.lblSec.Location = new System.Drawing.Point(312, 45);
      this.lblSec.Name = "lblSec";
      this.lblSec.Size = new System.Drawing.Size(26, 13);
      this.lblSec.TabIndex = 9;
      this.lblSec.Text = "Sec";
      // 
      // btnAddTimer
      // 
      this.btnAddTimer.Location = new System.Drawing.Point(88, 126);
      this.btnAddTimer.Name = "btnAddTimer";
      this.btnAddTimer.Size = new System.Drawing.Size(75, 23);
      this.btnAddTimer.TabIndex = 10;
      this.btnAddTimer.Text = "Add Timer";
      this.btnAddTimer.UseVisualStyleBackColor = true;
      this.btnAddTimer.Click += new System.EventHandler(this.btnAddTimer_Click);
      // 
      // AddTimer
      // 
      this.ClientSize = new System.Drawing.Size(362, 161);
      this.Controls.Add(this.btnAddTimer);
      this.Controls.Add(this.lblSec);
      this.Controls.Add(this.lblMin);
      this.Controls.Add(this.lblHrs);
      this.Controls.Add(this.nudSec);
      this.Controls.Add(this.nudMin);
      this.Controls.Add(this.nudHrs);
      this.Controls.Add(this.tbxName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.lblDuration);
      this.Controls.Add(this.lblName);
      this.Name = "AddTimer";
      this.Text = "Add Timer";
      ((System.ComponentModel.ISupportInitialize)(this.nudHrs)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSec)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Label lblDuration;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbxName;
    private System.Windows.Forms.NumericUpDown nudHrs;
    private System.Windows.Forms.NumericUpDown nudMin;
    private System.Windows.Forms.NumericUpDown nudSec;
    private System.Windows.Forms.Label lblHrs;
    private System.Windows.Forms.Label lblMin;
    private System.Windows.Forms.Label lblSec;
    private System.Windows.Forms.Button btnAddTimer;
  }
}
