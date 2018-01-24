namespace DANT2a {
  partial class AddAlarm {
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
      this.tbxName = new System.Windows.Forms.TextBox();
      this.lblRingAt = new System.Windows.Forms.Label();
      this.dtpAlarmTarget = new System.Windows.Forms.DateTimePicker();
      this.lblAlarmSound = new System.Windows.Forms.Label();
      this.btnAddAlarm = new System.Windows.Forms.Button();
      this.ofdLocateSoundbite = new System.Windows.Forms.OpenFileDialog();
      this.SuspendLayout();
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(45, 14);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(38, 13);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Name:";
      // 
      // tbxName
      // 
      this.tbxName.Location = new System.Drawing.Point(89, 7);
      this.tbxName.MaxLength = 25;
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new System.Drawing.Size(100, 20);
      this.tbxName.TabIndex = 1;
      this.tbxName.Click += new System.EventHandler(this.tbxName_Click);
      this.tbxName.Enter += new System.EventHandler(this.tbxName_Enter);
      this.tbxName.Leave += new System.EventHandler(this.tbxName_Leave);
      // 
      // lblRingAt
      // 
      this.lblRingAt.AutoSize = true;
      this.lblRingAt.Location = new System.Drawing.Point(38, 39);
      this.lblRingAt.Name = "lblRingAt";
      this.lblRingAt.Size = new System.Drawing.Size(45, 13);
      this.lblRingAt.TabIndex = 2;
      this.lblRingAt.Text = "Ring At:";
      // 
      // dtpAlarmTarget
      // 
      this.dtpAlarmTarget.CustomFormat = "f";
      this.dtpAlarmTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpAlarmTarget.Location = new System.Drawing.Point(89, 39);
      this.dtpAlarmTarget.MaxDate = new System.DateTime(3000, 10, 11, 0, 0, 0, 0);
      this.dtpAlarmTarget.MinDate = new System.DateTime(2017, 10, 11, 0, 0, 0, 0);
      this.dtpAlarmTarget.Name = "dtpAlarmTarget";
      this.dtpAlarmTarget.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.dtpAlarmTarget.Size = new System.Drawing.Size(201, 20);
      this.dtpAlarmTarget.TabIndex = 3;
      this.dtpAlarmTarget.Value = new System.DateTime(2017, 11, 21, 0, 0, 0, 0);
      // 
      // lblAlarmSound
      // 
      this.lblAlarmSound.AutoSize = true;
      this.lblAlarmSound.Location = new System.Drawing.Point(13, 68);
      this.lblAlarmSound.Name = "lblAlarmSound";
      this.lblAlarmSound.Size = new System.Drawing.Size(70, 13);
      this.lblAlarmSound.TabIndex = 4;
      this.lblAlarmSound.Text = "Alarm Sound:";
      // 
      // btnAddAlarm
      // 
      this.btnAddAlarm.Location = new System.Drawing.Point(89, 106);
      this.btnAddAlarm.Name = "btnAddAlarm";
      this.btnAddAlarm.Size = new System.Drawing.Size(75, 23);
      this.btnAddAlarm.TabIndex = 5;
      this.btnAddAlarm.Text = "Add Alarm";
      this.btnAddAlarm.UseVisualStyleBackColor = true;
      this.btnAddAlarm.Click += new System.EventHandler(this.btnAddAlarm_Click);
      // 
      // ofdLocateSoundbite
      // 
      this.ofdLocateSoundbite.Title = "Locate Soundbite";
      // 
      // AddAlarm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(302, 199);
      this.Controls.Add(this.btnAddAlarm);
      this.Controls.Add(this.lblAlarmSound);
      this.Controls.Add(this.dtpAlarmTarget);
      this.Controls.Add(this.lblRingAt);
      this.Controls.Add(this.tbxName);
      this.Controls.Add(this.lblName);
      this.Name = "AddAlarm";
      this.Text = "Add Alarm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox tbxName;
    private System.Windows.Forms.Label lblRingAt;
    private System.Windows.Forms.DateTimePicker dtpAlarmTarget;
    private System.Windows.Forms.Label lblAlarmSound;
    private System.Windows.Forms.Button btnAddAlarm;
    private System.Windows.Forms.OpenFileDialog ofdLocateSoundbite;
  }
}