using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DANT2a {
  public partial class AddTimer : Form {
    private HeadsUp mainForm =
      (HeadsUp)Application.OpenForms[0];

    //constructor
    public AddTimer() {
      InitializeComponent();

      tbxName.ForeColor = SystemColors.InactiveCaption;
      tbxName.Text = Properties.Resources.InactiveNameTbx;
    }

    private void btnAddTimer_Click(object sender, EventArgs e) {
      EntryType.Timer godOuah = new EntryType.Timer();

      if (tbxName.Text.Equals(Properties.Resources.InactiveNameTbx)) {
        MessageBox.Show("No user text!", "You must set a timer name!",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      godOuah.Name = tbxName.Text;
      godOuah.Duration = new TimeSpan((int) nudHrs.Value, (int) nudMin.Value,
        (int) nudSec.Value);
      //need to set soundbite after we get that set up on the form, too

      mainForm.addActiveTimer(godOuah);

      this.Close();
    }

    //usability methods
    private void tbxName_Enter(object sender, EventArgs e) {
      tbxName.ForeColor = SystemColors.WindowText;

      if ((tbxName.Text.Equals(Properties.Resources.InactiveNameTbx)) ||
          (tbxName.Text.Length < 3)) {
        tbxName.Text = "";
      }
    }

    private void tbxName_Click(object sender, EventArgs e) {
      tbxName.ForeColor = SystemColors.InactiveCaption;

      if (tbxName.Text.Equals(Properties.Resources.InactiveNameTbx)) {
        tbxName.Text = Properties.Resources.InactiveNameTbx;
      }
    }

    private void tbxName_Leave(object sender, EventArgs e) {
      tbxName.ForeColor = SystemColors.InactiveCaption;

      if (tbxName.Text.Equals("")) {
        tbxName.Text = Properties.Resources.InactiveNameTbx;
      }
    }
  }
}
