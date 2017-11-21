using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DANT2a {
  public partial class AddReminder : Form, IAddForm {
    private HeadsUp mainForm =
      (HeadsUp)Application.OpenForms[0];

    public TextBox nameTbx {
      get { return this.tbxName; }
      set { this.tbxName = nameTbx; }
    }

    //constructor
    public AddReminder() {
      InitializeComponent();

      tbxName.ForeColor = SystemColors.InactiveCaption;
      tbxName.Text = Properties.Resources.InactiveNameTbx;
      dtpReminderTarget.CustomFormat = "MMMM.dd, yyyy '@' H:mm:ss";
      tbxReminder.ForeColor = SystemColors.InactiveCaption;
      tbxReminder.Text = Properties.Resources.InactiveReminderTbx;
    }

    private void btnAddReminder_Click(object sender, EventArgs e) {
      EntryType.Reminder godOuah = new EntryType.Reminder();

      //really weak form validation
      if (tbxName.Text.Equals(Properties.Resources.InactiveNameTbx)) {
        MessageBox.Show(Properties.Resources.NoNameSetError, 
          Properties.Resources.NoTextError,
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (tbxReminder.Text.Equals(Properties.Resources.InactiveReminderTbx)) {
        MessageBox.Show("You should use an alarm if you're not concerned " +
          "about having a reminder message!", Properties.Resources.NoTextError,
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      godOuah.Name = tbxName.Text;
      godOuah.ActiveAt = dtpReminderTarget.Value;
      godOuah.SoundBite = null;
      godOuah.Running = false;  //don't need this, but maybe we will l8r
      godOuah.Msg = tbxReminder.Text;

      mainForm.addActiveReminder(godOuah);

      this.Close();
    }

    //okay the following usability methods REALLY need to be modularized in an
    //external c# file; inclusion in 3 different forms is ridiculous
    private void tbxName_Enter(object sender, EventArgs e) {
      FriendlyForms.Usability.nameEnter(nameTbx);
    }

    private void tbxReminder_Enter(object sender, EventArgs e) {
      tbxReminder.ForeColor = SystemColors.WindowText;

      if (tbxReminder.Text.Equals(Properties.Resources.InactiveReminderTbx) ||
        (tbxReminder.Text.Length < 3)) {
        tbxReminder.Text = "";
      }
    }

    //not sure that this is really necessary any more
    private void tbxName_Click(object sender, EventArgs e) {
      FriendlyForms.Usability.nameEnter(nameTbx);
    }

    private void tbxName_Leave(object sender, EventArgs e) {
      FriendlyForms.Usability.nameWipe(nameTbx);
    }

    private void tbxReminder_Leave(object sender, EventArgs e) {
      tbxReminder.ForeColor = SystemColors.InactiveCaption;

      if (tbxReminder.Text.Length < 3) {
        tbxReminder.Text = Properties.Resources.InactiveReminderTbx;
      }
    }
  }
}
