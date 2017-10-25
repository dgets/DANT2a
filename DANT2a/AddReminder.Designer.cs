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
      this.dtpReminderTarget = new System.Windows.Forms.DateTimePicker();
      this.tbxReminder = new System.Windows.Forms.TextBox();
      this.btnAddReminder = new System.Windows.Forms.Button();
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
      this.tbxName.Click += new System.EventHandler(this.tbxName_Enter);
      this.tbxName.Enter += new System.EventHandler(this.tbxName_Enter);
      this.tbxName.Leave += new System.EventHandler(this.tbxName_Leave);
      // 
      // dtpReminderTarget
      // 
      this.dtpReminderTarget.Location = new System.Drawing.Point(99, 44);
      this.dtpReminderTarget.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
      this.dtpReminderTarget.MinDate = new System.DateTime(2017, 10, 13, 0, 0, 0, 0);
      this.dtpReminderTarget.Name = "dtpReminderTarget";
      this.dtpReminderTarget.Size = new System.Drawing.Size(272, 20);
      this.dtpReminderTarget.TabIndex = 5;
      // 
      // tbxReminder
      // 
      this.tbxReminder.AcceptsReturn = true;
      this.tbxReminder.Location = new System.Drawing.Point(99, 104);
      this.tbxReminder.Multiline = true;
      this.tbxReminder.Name = "tbxReminder";
      this.tbxReminder.Size = new System.Drawing.Size(272, 157);
      this.tbxReminder.TabIndex = 6;
      this.tbxReminder.Click += new System.EventHandler(this.tbxReminder_Enter);
      this.tbxReminder.Enter += new System.EventHandler(this.tbxReminder_Enter);
      this.tbxReminder.Leave += new System.EventHandler(this.tbxReminder_Leave);
      // 
      // btnAddReminder
      // 
      this.btnAddReminder.Location = new System.Drawing.Point(141, 267);
      this.btnAddReminder.Name = "btnAddReminder";
      this.btnAddReminder.Size = new System.Drawing.Size(102, 23);
      this.btnAddReminder.TabIndex = 7;
      this.btnAddReminder.Text = "Add Reminder";
      this.btnAddReminder.UseVisualStyleBackColor = true;
      this.btnAddReminder.Click += new System.EventHandler(this.btnAddReminder_Click);
      // 
      // AddReminder
      // 
      this.ClientSize = new System.Drawing.Size(383, 297);
      this.Controls.Add(this.btnAddReminder);
      this.Controls.Add(this.tbxReminder);
      this.Controls.Add(this.dtpReminderTarget);
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
    private System.Windows.Forms.DateTimePicker dtpReminderTarget;
    private System.Windows.Forms.TextBox tbxReminder;
    private System.Windows.Forms.Button btnAddReminder;
  }
}
