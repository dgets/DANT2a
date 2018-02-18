using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DANT2a {
  public partial class AddTimer : Form, IAddForm {
    private HeadsUp mainForm =
      (HeadsUp)Application.OpenForms[0];

    public TextBox NameTbx {
      get { return this.tbxName; }
      set { this.tbxName = NameTbx; }
    }

    //constructor
    public AddTimer() {
      InitializeComponent();

      tbxName.ForeColor = SystemColors.InactiveCaption;
      tbxName.Text = Properties.Resources.InactiveNameTbx;
    }

    private void btnAddTimer_Click(object sender, EventArgs e) {
      EntryType.Timer godOuah = new EntryType.Timer();

      if (tbxName.Text.Equals(Properties.Resources.InactiveNameTbx)) {
        MessageBox.Show(Properties.Resources.NoNameSetError, 
          Properties.Resources.NoTextError,
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if ((nudHrs.Value == 0) && (nudMin.Value == 0) && (nudSec.Value ==0)) {
        MessageBox.Show("Timer cannot be for null countdown!",
          "Timer Set for Zero", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      godOuah.Name = tbxName.Text;
      godOuah.Duration = new TimeSpan((int) nudHrs.Value, (int) nudMin.Value,
        (int) nudSec.Value);
      godOuah.Remaining = godOuah.Duration;
      //need to set soundbite after we get that set up on the form, too

      mainForm.AddActiveTimer(godOuah);

      this.Close();
    }

    //usability methods
    private void tbxName_Enter(object sender, EventArgs e) {
      FriendlyForms.Usability.NameEnter(NameTbx);
    }

    private void tbxName_Click(object sender, EventArgs e) {
      FriendlyForms.Usability.NameEnter(NameTbx); 
    }

    private void tbxName_Leave(object sender, EventArgs e) {
      FriendlyForms.Usability.NameWipe(NameTbx);
    }
  }
}
