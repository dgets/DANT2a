namespace DANT2a {
  partial class AddReminder {
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
      this.lblDateTime = new System.Windows.Forms.Label();
      this.lblSoundBite = new System.Windows.Forms.Label();
      this.lblReminder = new System.Windows.Forms.Label();
      this.tbxName = new System.Windows.Forms.TextBox();
      this.dtpTarget = new System.Windows.Forms.DateTimePicker();
      this.tbxReminder = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(45, 20);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(38, 13);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Name:";
      // 
      // lblDateTime
      // 
      this.lblDateTime.AutoSize = true;
      this.lblDateTime.Location = new System.Drawing.Point(42, 50);
      this.lblDateTime.Name = "lblDateTime";
      this.lblDateTime.Size = new System.Drawing.Size(41, 13);
      this.lblDateTime.TabIndex = 1;
      this.lblDateTime.Text = "Target:";
      // 
      // lblSoundBite
      // 
      this.lblSoundBite.AutoSize = true;
      this.lblSoundBite.Location = new System.Drawing.Point(13, 77);
      this.lblSoundBite.Name = "lblSoundBite";
      this.lblSoundBite.Size = new System.Drawing.Size(70, 13);
      this.lblSoundBite.TabIndex = 2;
      this.lblSoundBite.Text = "Alarm Sound:";
      // 
      // lblReminder
      // 
      this.lblReminder.AutoSize = true;
      this.lblReminder.Location = new System.Drawing.Point(28, 107);
      this.lblReminder.Name = "lblReminder";
      this.lblReminder.Size = new System.Drawing.Size(55, 13);
      this.lblReminder.TabIndex = 3;
      this.lblReminder.Text = "Reminder:";
      // 
      // tbxName
      // 
      this.tbxName.Location = new System.Drawing.Point(99, 13);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new System.Drawing.Size(100, 20);
      this.tbxName.TabIndex = 4;
      // 
      // dtpTarget
      // 
      this.dtpTarget.Location = new System.Drawing.Point(99, 44);
      this.dtpTarget.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
      this.dtpTarget.MinDate = new System.DateTime(2017, 10, 13, 0, 0, 0, 0);
      this.dtpTarget.Name = "dtpTarget";
      this.dtpTarget.Size = new System.Drawing.Size(272, 20);
      this.dtpTarget.TabIndex = 5;
      // 
      // tbxReminder
      // 
      this.tbxReminder.AcceptsReturn = true;
      this.tbxReminder.Location = new System.Drawing.Point(99, 104);
      this.tbxReminder.Multiline = true;
      this.tbxReminder.Name = "tbxReminder";
      this.tbxReminder.Size = new System.Drawing.Size(272, 157);
      this.tbxReminder.TabIndex = 6;
      // 
      // AddReminder
      // 
      this.ClientSize = new System.Drawing.Size(383, 273);
      this.Controls.Add(this.tbxReminder);
      this.Controls.Add(this.dtpTarget);
      this.Controls.Add(this.tbxName);
      this.Controls.Add(this.lblReminder);
      this.Controls.Add(this.lblSoundBite);
      this.Controls.Add(this.lblDateTime);
      this.Controls.Add(this.lblName);
      this.Name = "AddReminder";
      this.Text = "Add Reminder";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Label lblDateTime;
    private System.Windows.Forms.Label lblSoundBite;
    private System.Windows.Forms.Label lblReminder;
    private System.Windows.Forms.TextBox tbxName;
    private System.Windows.Forms.DateTimePicker dtpTarget;
    private System.Windows.Forms.TextBox tbxReminder;
  }
}
