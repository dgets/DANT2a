using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a {
  public partial class EditEntry : Form {

    private HeadsUp mainForm =
          (HeadsUp)Application.OpenForms[0];

    public EditEntry() {
      InitializeComponent();

      mainForm.Enabled = false;
      dtpActiveAt.CustomFormat = "MMMM dd, yyyy '@' H:mm:ss";
    }

    private void EditEntry_Load(object sender, EventArgs e) {
      EntryType.Entries currentTypeEdited = new EntryType.Entries();

      if (mainForm.alarmCLB.SelectedIndex != -1) {
        currentTypeEdited = EntryType.Entries.Alarm;
      } else if (mainForm.reminderCLB.SelectedIndex != -1) {
        currentTypeEdited = EntryType.Entries.Reminder;
      } else {
        currentTypeEdited = EntryType.Entries.Timer;

        //lets change the controls accordingly
        //(no event handler to remove for the existing dtp
        this.Controls.Remove(dtpActiveAt);

        //change existing label
        lblRingAt.Text = "Duration:";

        //set up new control properties
        this.nudTmrHrs = new System.Windows.Forms.NumericUpDown();
        this.nudTmrHrs.Location = new System.Drawing.Point(92, 39);
        this.nudTmrHrs.Name = "nudTmrHrs";
        this.nudTmrHrs.Size = new System.Drawing.Size(40, 20);
        this.nudTmrHrs.TabIndex = 8;
        this.nudTmrHrs.Minimum = 0;
        this.nudTmrHrs.Maximum = 23;

        this.lblTmrHours = new System.Windows.Forms.Label();
        this.lblTmrHours.Location = new System.Drawing.Point(135, 44);
        this.lblTmrHours.Name = "lblTmrHours";
        this.lblTmrHours.Size = new System.Drawing.Size(23, 20);
        this.lblTmrHours.Text = "Hrs";

        this.nudTmrMin = new System.Windows.Forms.NumericUpDown();
        this.nudTmrMin.Location = new System.Drawing.Point(160, 39);
        this.nudTmrMin.Name = "nudTmrMin";
        this.nudTmrMin.Size = new System.Drawing.Size(40, 20);
        this.nudTmrMin.TabIndex = 9;
        this.nudTmrMin.Minimum = 0;
        this.nudTmrMin.Maximum = 59;

        this.lblTmrMinutes = new System.Windows.Forms.Label();
        this.lblTmrMinutes.Location = new System.Drawing.Point(203, 44);
        this.lblTmrMinutes.Name = "lblTmrMinutes";
        this.lblTmrMinutes.Size = new System.Drawing.Size(23, 20);
        this.lblTmrMinutes.Text = "Min";

        this.nudTmrSec = new System.Windows.Forms.NumericUpDown();
        this.nudTmrSec.Location = new System.Drawing.Point(228, 39);
        this.nudTmrSec.Name = "nudTmrSec";
        this.nudTmrSec.Size = new System.Drawing.Size(40, 20);
        this.nudTmrSec.Text = "Sec";
        this.nudTmrSec.TabIndex = 10;
        this.nudTmrSec.Minimum = 0;
        this.nudTmrSec.Maximum = 59;

        this.lblTmrSeconds = new System.Windows.Forms.Label();
        this.lblTmrSeconds.Location = new System.Drawing.Point(271, 44);
        this.lblTmrSeconds.Name = "lblTmrSeconds";
        this.lblTmrSeconds.Size = new System.Drawing.Size(23, 20);
        this.lblTmrSeconds.Text = "Sec";

        //and now we've got to add the new numeric selectors and labels
        //this.nudTmrHrs.Location = new System.Drawing.Point(92, 39);

        this.Controls.Add(nudTmrHrs);
        this.Controls.Add(lblTmrHours);
        this.Controls.Add(nudTmrMin);
        this.Controls.Add(lblTmrMinutes);
        this.Controls.Add(nudTmrSec);
        this.Controls.Add(lblTmrSeconds);
        
        /*this.nudTmrHrs.Show();
        this.lblTmrHours.Show();
        this.nudTmrMin.Show();*/
        //this.Refresh();
      }
      
      switch (currentTypeEdited) {
        case EntryType.Entries.Alarm:
          //edit our alarm entry heah
          tbxReminderText.Text = "unavailable";
          tbxReminderText.Enabled = false;
          tbxName.Text =
            HeadsUp.activeAlarms[mainForm.alarmCLB.SelectedIndex].Name;
          dtpActiveAt.Value =
            HeadsUp.activeAlarms[mainForm.alarmCLB.SelectedIndex].ActiveAt;

          break;
        case EntryType.Entries.Timer:
          //edit timer heah
          tbxReminderText.Text = "unavailable";
          tbxReminderText.Enabled = false;
          tbxName.Text =
            HeadsUp.activeTimers[mainForm.timerCLB.SelectedIndex].Name;
          //okay the following isn't a DTP, it's a 3 number field; we're
          //going to have to handle this one differently, hopefully not with
          //a completely different form
          /*dtpActiveAt.Value =
            HeadsUp.activeTimers[mainForm.timerCLB.SelectedIndex].remaining*/

          break;
        case EntryType.Entries.Reminder:
          //reminder tiem
          tbxReminderText.Text =
            HeadsUp.activeReminders[mainForm.reminderCLB.SelectedIndex].Msg;
          tbxName.Text =
            HeadsUp.activeReminders[mainForm.reminderCLB.SelectedIndex].Name;
          dtpActiveAt.Value =
            HeadsUp.activeReminders[
              mainForm.reminderCLB.SelectedIndex].ActiveAt;

          break;
      }
    }

    private void btnMakeChanges_Click(object sender, EventArgs e) {
      EntryType.Entries currentTypeEdited = EntryType.Entries.Alarm;

      switch (currentTypeEdited) {
        case (EntryType.Entries.Alarm):
          /* note that the following conditional will need to have soundbite
           * information checking, as well */
          if (tbxName.Text.Equals(
            HeadsUp.activeAlarms[mainForm.alarmCLB.SelectedIndex].Name) &&
              dtpActiveAt.Value.Equals(
            HeadsUp.activeAlarms[mainForm.alarmCLB.SelectedIndex].ActiveAt)) {

            //no changes made to settings
            if (MessageBox.Show("You haven't made any changes!",
              "Nothing changed", MessageBoxButtons.OKCancel,
              MessageBoxIcon.Warning) == DialogResult.Cancel) {
              mainForm.Enabled = true;
              this.Close();
            }
            break;
          }

          HeadsUp.activeAlarms[mainForm.alarmCLB.SelectedIndex].Name =
            tbxName.Text;
          HeadsUp.activeAlarms[mainForm.alarmCLB.SelectedIndex].ActiveAt =
            dtpActiveAt.Value;

          MessageBox.Show("Changes propagated (not yet saved!)",
            "Changes made", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
          this.Close();

          break;
        //timer & reminder need to follow here
      }
    }
  }
}
