namespace DANT2a {
  partial class HeadsUp {
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
      this.components = new System.ComponentModel.Container();
      this.grpAlarms = new System.Windows.Forms.GroupBox();
      this.btnDeleteAlarm = new System.Windows.Forms.Button();
      this.btnEditAlarm = new System.Windows.Forms.Button();
      this.clbAlarms = new System.Windows.Forms.CheckedListBox();
      this.grpTimers = new System.Windows.Forms.GroupBox();
      this.btnResetTimer = new System.Windows.Forms.Button();
      this.btnDeleteTimer = new System.Windows.Forms.Button();
      this.btnEditTimer = new System.Windows.Forms.Button();
      this.clbTimers = new System.Windows.Forms.CheckedListBox();
      this.grpReminders = new System.Windows.Forms.GroupBox();
      this.btnDeleteReminder = new System.Windows.Forms.Button();
      this.btnEditReminder = new System.Windows.Forms.Button();
      this.clbReminders = new System.Windows.Forms.CheckedListBox();
      this.btnAddAny = new System.Windows.Forms.Button();
      this.tmrGreenwichAtomic = new System.Windows.Forms.Timer(this.components);
      this.btnDbgSave = new System.Windows.Forms.Button();
      this.btnDbgLoad = new System.Windows.Forms.Button();
      this.btnDbgWipe = new System.Windows.Forms.Button();
      this.grpDebug = new System.Windows.Forms.GroupBox();
      this.grpAlarms.SuspendLayout();
      this.grpTimers.SuspendLayout();
      this.grpReminders.SuspendLayout();
      this.grpDebug.SuspendLayout();
      this.SuspendLayout();
      // 
      // grpAlarms
      // 
      this.grpAlarms.Controls.Add(this.btnDeleteAlarm);
      this.grpAlarms.Controls.Add(this.btnEditAlarm);
      this.grpAlarms.Controls.Add(this.clbAlarms);
      this.grpAlarms.Location = new System.Drawing.Point(13, 13);
      this.grpAlarms.Name = "grpAlarms";
      this.grpAlarms.Size = new System.Drawing.Size(250, 251);
      this.grpAlarms.TabIndex = 0;
      this.grpAlarms.TabStop = false;
      this.grpAlarms.Text = "Alarms";
      // 
      // btnDeleteAlarm
      // 
      this.btnDeleteAlarm.Location = new System.Drawing.Point(7, 211);
      this.btnDeleteAlarm.Name = "btnDeleteAlarm";
      this.btnDeleteAlarm.Size = new System.Drawing.Size(75, 23);
      this.btnDeleteAlarm.TabIndex = 2;
      this.btnDeleteAlarm.Text = "Delete";
      this.btnDeleteAlarm.UseVisualStyleBackColor = true;
      // 
      // btnEditAlarm
      // 
      this.btnEditAlarm.Location = new System.Drawing.Point(7, 181);
      this.btnEditAlarm.Name = "btnEditAlarm";
      this.btnEditAlarm.Size = new System.Drawing.Size(75, 23);
      this.btnEditAlarm.TabIndex = 1;
      this.btnEditAlarm.Text = "Edit";
      this.btnEditAlarm.UseVisualStyleBackColor = true;
      this.btnEditAlarm.Click += new System.EventHandler(this.BtnEditAlarm_Click);
      // 
      // clbAlarms
      // 
      this.clbAlarms.FormattingEnabled = true;
      this.clbAlarms.Location = new System.Drawing.Point(7, 20);
      this.clbAlarms.Name = "clbAlarms";
      this.clbAlarms.Size = new System.Drawing.Size(237, 154);
      this.clbAlarms.TabIndex = 0;
      this.clbAlarms.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.AlarmCLB_ItemCheck);
      this.clbAlarms.SelectedIndexChanged += new System.EventHandler(this.AlarmSelectedChange);
      // 
      // grpTimers
      // 
      this.grpTimers.Controls.Add(this.btnResetTimer);
      this.grpTimers.Controls.Add(this.btnDeleteTimer);
      this.grpTimers.Controls.Add(this.btnEditTimer);
      this.grpTimers.Controls.Add(this.clbTimers);
      this.grpTimers.Location = new System.Drawing.Point(269, 13);
      this.grpTimers.Name = "grpTimers";
      this.grpTimers.Size = new System.Drawing.Size(267, 251);
      this.grpTimers.TabIndex = 1;
      this.grpTimers.TabStop = false;
      this.grpTimers.Text = "Timers";
      // 
      // btnResetTimer
      // 
      this.btnResetTimer.Location = new System.Drawing.Point(186, 181);
      this.btnResetTimer.Name = "btnResetTimer";
      this.btnResetTimer.Size = new System.Drawing.Size(75, 23);
      this.btnResetTimer.TabIndex = 3;
      this.btnResetTimer.Text = "Reset Timer";
      this.btnResetTimer.UseVisualStyleBackColor = true;
      this.btnResetTimer.Click += new System.EventHandler(this.BtnResetTimer_Click);
      // 
      // btnDeleteTimer
      // 
      this.btnDeleteTimer.Location = new System.Drawing.Point(7, 211);
      this.btnDeleteTimer.Name = "btnDeleteTimer";
      this.btnDeleteTimer.Size = new System.Drawing.Size(75, 23);
      this.btnDeleteTimer.TabIndex = 2;
      this.btnDeleteTimer.Text = "Delete";
      this.btnDeleteTimer.UseVisualStyleBackColor = true;
      // 
      // btnEditTimer
      // 
      this.btnEditTimer.Location = new System.Drawing.Point(7, 181);
      this.btnEditTimer.Name = "btnEditTimer";
      this.btnEditTimer.Size = new System.Drawing.Size(75, 23);
      this.btnEditTimer.TabIndex = 1;
      this.btnEditTimer.Text = "Edit";
      this.btnEditTimer.UseVisualStyleBackColor = true;
      this.btnEditTimer.Click += new System.EventHandler(this.BtnEditTimer_Click);
      // 
      // clbTimers
      // 
      this.clbTimers.FormattingEnabled = true;
      this.clbTimers.Location = new System.Drawing.Point(7, 20);
      this.clbTimers.Name = "clbTimers";
      this.clbTimers.Size = new System.Drawing.Size(254, 154);
      this.clbTimers.TabIndex = 0;
      this.clbTimers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.timerCLB_ItemCheck);
      this.clbTimers.SelectedIndexChanged += new System.EventHandler(this.TimerSelectedChange);
      // 
      // grpReminders
      // 
      this.grpReminders.Controls.Add(this.btnDeleteReminder);
      this.grpReminders.Controls.Add(this.btnEditReminder);
      this.grpReminders.Controls.Add(this.clbReminders);
      this.grpReminders.Location = new System.Drawing.Point(542, 12);
      this.grpReminders.Name = "grpReminders";
      this.grpReminders.Size = new System.Drawing.Size(279, 251);
      this.grpReminders.TabIndex = 2;
      this.grpReminders.TabStop = false;
      this.grpReminders.Text = "Reminders";
      // 
      // btnDeleteReminder
      // 
      this.btnDeleteReminder.Location = new System.Drawing.Point(7, 211);
      this.btnDeleteReminder.Name = "btnDeleteReminder";
      this.btnDeleteReminder.Size = new System.Drawing.Size(75, 23);
      this.btnDeleteReminder.TabIndex = 2;
      this.btnDeleteReminder.Text = "Delete";
      this.btnDeleteReminder.UseVisualStyleBackColor = true;
      // 
      // btnEditReminder
      // 
      this.btnEditReminder.Location = new System.Drawing.Point(7, 181);
      this.btnEditReminder.Name = "btnEditReminder";
      this.btnEditReminder.Size = new System.Drawing.Size(75, 23);
      this.btnEditReminder.TabIndex = 1;
      this.btnEditReminder.Text = "Edit";
      this.btnEditReminder.UseVisualStyleBackColor = true;
      this.btnEditReminder.Click += new System.EventHandler(this.BtnEditReminder_Click);
      // 
      // clbReminders
      // 
      this.clbReminders.FormattingEnabled = true;
      this.clbReminders.Location = new System.Drawing.Point(7, 20);
      this.clbReminders.Name = "clbReminders";
      this.clbReminders.Size = new System.Drawing.Size(266, 154);
      this.clbReminders.TabIndex = 0;
      this.clbReminders.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ReminderCLB_ItemCheck);
      this.clbReminders.SelectedIndexChanged += new System.EventHandler(this.ReminderSelectedChange);
      // 
      // btnAddAny
      // 
      this.btnAddAny.Location = new System.Drawing.Point(269, 270);
      this.btnAddAny.Name = "btnAddAny";
      this.btnAddAny.Size = new System.Drawing.Size(75, 23);
      this.btnAddAny.TabIndex = 3;
      this.btnAddAny.Text = "Add Entry";
      this.btnAddAny.UseVisualStyleBackColor = true;
      this.btnAddAny.Click += new System.EventHandler(this.BtnAddAny_Click);
      // 
      // tmrGreenwichAtomic
      // 
      this.tmrGreenwichAtomic.Interval = 1000;
      this.tmrGreenwichAtomic.Tick += new System.EventHandler(this.TmrGreenwichAtomic_Tick);
      // 
      // btnDbgSave
      // 
      this.btnDbgSave.Location = new System.Drawing.Point(6, 48);
      this.btnDbgSave.Name = "btnDbgSave";
      this.btnDbgSave.Size = new System.Drawing.Size(75, 23);
      this.btnDbgSave.TabIndex = 4;
      this.btnDbgSave.Text = "Debug Save";
      this.btnDbgSave.UseVisualStyleBackColor = true;
      this.btnDbgSave.Click += new System.EventHandler(this.BtnDbgSave_Click);
      // 
      // btnDbgLoad
      // 
      this.btnDbgLoad.Location = new System.Drawing.Point(6, 19);
      this.btnDbgLoad.Name = "btnDbgLoad";
      this.btnDbgLoad.Size = new System.Drawing.Size(75, 23);
      this.btnDbgLoad.TabIndex = 5;
      this.btnDbgLoad.Text = "Debug Load";
      this.btnDbgLoad.UseVisualStyleBackColor = true;
      this.btnDbgLoad.Click += new System.EventHandler(this.BtnDbgLoad_Click);
      // 
      // btnDbgWipe
      // 
      this.btnDbgWipe.Location = new System.Drawing.Point(93, 19);
      this.btnDbgWipe.Name = "btnDbgWipe";
      this.btnDbgWipe.Size = new System.Drawing.Size(75, 23);
      this.btnDbgWipe.TabIndex = 6;
      this.btnDbgWipe.Text = "Debug Wipe";
      this.btnDbgWipe.UseVisualStyleBackColor = true;
      this.btnDbgWipe.Click += new System.EventHandler(this.BtnDbgWipe_Click);
      // 
      // grpDebug
      // 
      this.grpDebug.Controls.Add(this.btnDbgLoad);
      this.grpDebug.Controls.Add(this.btnDbgWipe);
      this.grpDebug.Controls.Add(this.btnDbgSave);
      this.grpDebug.Location = new System.Drawing.Point(362, 270);
      this.grpDebug.Name = "grpDebug";
      this.grpDebug.Size = new System.Drawing.Size(174, 81);
      this.grpDebug.TabIndex = 7;
      this.grpDebug.TabStop = false;
      this.grpDebug.Text = "Debugging";
      // 
      // HeadsUp
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(833, 363);
      this.Controls.Add(this.grpDebug);
      this.Controls.Add(this.btnAddAny);
      this.Controls.Add(this.grpReminders);
      this.Controls.Add(this.grpTimers);
      this.Controls.Add(this.grpAlarms);
      this.Name = "HeadsUp";
      this.Text = "DANT";
      this.grpAlarms.ResumeLayout(false);
      this.grpTimers.ResumeLayout(false);
      this.grpReminders.ResumeLayout(false);
      this.grpDebug.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox grpAlarms;
    private System.Windows.Forms.Button btnDeleteAlarm;
    private System.Windows.Forms.Button btnEditAlarm;
    private System.Windows.Forms.CheckedListBox clbAlarms;
    private System.Windows.Forms.GroupBox grpTimers;
    private System.Windows.Forms.Button btnDeleteTimer;
    private System.Windows.Forms.Button btnEditTimer;
    private System.Windows.Forms.CheckedListBox clbTimers;
    private System.Windows.Forms.GroupBox grpReminders;
    private System.Windows.Forms.Button btnDeleteReminder;
    private System.Windows.Forms.Button btnEditReminder;
    private System.Windows.Forms.CheckedListBox clbReminders;
    private System.Windows.Forms.Button btnAddAny;
    private System.Windows.Forms.Button btnResetTimer;
    private System.Windows.Forms.Timer tmrGreenwichAtomic;
        private System.Windows.Forms.Button btnDbgSave;
        private System.Windows.Forms.Button btnDbgLoad;
    private System.Windows.Forms.Button btnDbgWipe;
    private System.Windows.Forms.GroupBox grpDebug;
  }
}

