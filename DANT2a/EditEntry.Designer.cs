namespace DANT2a
{
  partial class EditEntry
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
    private void InitializeComponent()
    {
      this.lblName = new System.Windows.Forms.Label();
      this.tbxName = new System.Windows.Forms.TextBox();
      this.lblRingAt = new System.Windows.Forms.Label();
      this.dtpActiveAt = new System.Windows.Forms.DateTimePicker();
      this.lblSoundBite = new System.Windows.Forms.Label();
      this.lblReminderText = new System.Windows.Forms.Label();
      this.tbxReminderText = new System.Windows.Forms.TextBox();
      this.btnMakeChanges = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(48, 13);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(38, 13);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Name:";
      // 
      // tbxName
      // 
      this.tbxName.Location = new System.Drawing.Point(92, 10);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new System.Drawing.Size(100, 20);
      this.tbxName.TabIndex = 1;
      this.tbxName.Text = "loading";
      // 
      // lblRingAt
      // 
      this.lblRingAt.AutoSize = true;
      this.lblRingAt.Location = new System.Drawing.Point(41, 45);
      this.lblRingAt.Name = "lblRingAt";
      this.lblRingAt.Size = new System.Drawing.Size(45, 13);
      this.lblRingAt.TabIndex = 2;
      this.lblRingAt.Text = "Ring At:";
      // 
      // dtpActiveAt
      // 
      this.dtpActiveAt.Location = new System.Drawing.Point(92, 39);
      this.dtpActiveAt.Name = "dtpActiveAt";
      this.dtpActiveAt.Size = new System.Drawing.Size(200, 20);
      this.dtpActiveAt.TabIndex = 3;
      // 
      // lblSoundBite
      // 
      this.lblSoundBite.AutoSize = true;
      this.lblSoundBite.Location = new System.Drawing.Point(24, 69);
      this.lblSoundBite.Name = "lblSoundBite";
      this.lblSoundBite.Size = new System.Drawing.Size(62, 13);
      this.lblSoundBite.TabIndex = 4;
      this.lblSoundBite.Text = "Sound Bite:";
      // 
      // lblReminderText
      // 
      this.lblReminderText.AutoSize = true;
      this.lblReminderText.Location = new System.Drawing.Point(7, 96);
      this.lblReminderText.Name = "lblReminderText";
      this.lblReminderText.Size = new System.Drawing.Size(79, 13);
      this.lblReminderText.TabIndex = 5;
      this.lblReminderText.Text = "Reminder Text:";
      // 
      // tbxReminderText
      // 
      this.tbxReminderText.Enabled = false;
      this.tbxReminderText.Location = new System.Drawing.Point(92, 96);
      this.tbxReminderText.Multiline = true;
      this.tbxReminderText.Name = "tbxReminderText";
      this.tbxReminderText.Size = new System.Drawing.Size(200, 154);
      this.tbxReminderText.TabIndex = 6;
      // 
      // btnMakeChanges
      // 
      this.btnMakeChanges.Location = new System.Drawing.Point(104, 262);
      this.btnMakeChanges.Name = "btnMakeChanges";
      this.btnMakeChanges.Size = new System.Drawing.Size(88, 23);
      this.btnMakeChanges.TabIndex = 7;
      this.btnMakeChanges.Text = "Make Changes";
      this.btnMakeChanges.UseVisualStyleBackColor = true;
      this.btnMakeChanges.Click += new System.EventHandler(this.btnMakeChanges_Click);
      // 
      // EditEntry
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(301, 297);
      this.Controls.Add(this.btnMakeChanges);
      this.Controls.Add(this.tbxReminderText);
      this.Controls.Add(this.lblReminderText);
      this.Controls.Add(this.lblSoundBite);
      this.Controls.Add(this.dtpActiveAt);
      this.Controls.Add(this.lblRingAt);
      this.Controls.Add(this.tbxName);
      this.Controls.Add(this.lblName);
      this.Name = "EditEntry";
      this.Text = "EditEntry";
      this.Load += new System.EventHandler(this.EditEntry_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox tbxName;
    private System.Windows.Forms.Label lblRingAt;
    private System.Windows.Forms.DateTimePicker dtpActiveAt;
    private System.Windows.Forms.Label lblSoundBite;
    private System.Windows.Forms.Label lblReminderText;
    private System.Windows.Forms.TextBox tbxReminderText;
    private System.Windows.Forms.Button btnMakeChanges;
  }
}