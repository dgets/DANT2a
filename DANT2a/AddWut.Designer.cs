namespace DANT2a {
  partial class AddWut {
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
      this.rbtAlarm = new System.Windows.Forms.RadioButton();
      this.rbtTimer = new System.Windows.Forms.RadioButton();
      this.rbtReminder = new System.Windows.Forms.RadioButton();
      this.btnGo = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // rbtAlarm
      // 
      this.rbtAlarm.AutoSize = true;
      this.rbtAlarm.Location = new System.Drawing.Point(13, 12);
      this.rbtAlarm.Name = "rbtAlarm";
      this.rbtAlarm.Size = new System.Drawing.Size(51, 17);
      this.rbtAlarm.TabIndex = 0;
      this.rbtAlarm.TabStop = true;
      this.rbtAlarm.Text = "Alarm";
      this.rbtAlarm.UseVisualStyleBackColor = true;
      // 
      // rbtTimer
      // 
      this.rbtTimer.AutoSize = true;
      this.rbtTimer.Location = new System.Drawing.Point(13, 37);
      this.rbtTimer.Name = "rbtTimer";
      this.rbtTimer.Size = new System.Drawing.Size(51, 17);
      this.rbtTimer.TabIndex = 1;
      this.rbtTimer.TabStop = true;
      this.rbtTimer.Text = "Timer";
      this.rbtTimer.UseVisualStyleBackColor = true;
      // 
      // rbtReminder
      // 
      this.rbtReminder.AutoSize = true;
      this.rbtReminder.Location = new System.Drawing.Point(13, 61);
      this.rbtReminder.Name = "rbtReminder";
      this.rbtReminder.Size = new System.Drawing.Size(70, 17);
      this.rbtReminder.TabIndex = 2;
      this.rbtReminder.TabStop = true;
      this.rbtReminder.Text = "Reminder";
      this.rbtReminder.UseVisualStyleBackColor = true;
      // 
      // btnGo
      // 
      this.btnGo.Location = new System.Drawing.Point(13, 85);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new System.Drawing.Size(75, 23);
      this.btnGo.TabIndex = 3;
      this.btnGo.Text = "Go";
      this.btnGo.UseVisualStyleBackColor = true;
      this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
      // 
      // AddWut
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(204, 122);
      this.Controls.Add(this.btnGo);
      this.Controls.Add(this.rbtReminder);
      this.Controls.Add(this.rbtTimer);
      this.Controls.Add(this.rbtAlarm);
      this.MaximizeBox = false;
      this.Name = "AddWut";
      this.Text = "Adding What?";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton rbtAlarm;
    private System.Windows.Forms.RadioButton rbtTimer;
    private System.Windows.Forms.RadioButton rbtReminder;
    private System.Windows.Forms.Button btnGo;
  }
}