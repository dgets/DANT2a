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

    public TextBox nameTbx {
      get { return this.tbxName; }
      set { this.tbxName = nameTbx; }
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
      FriendlyForms.Usability.nameEnter(nameTbx);
    }

    private void tbxName_Click(object sender, EventArgs e) {
      FriendlyForms.Usability.nameEnter(nameTbx); 
    }

    private void tbxName_Leave(object sender, EventArgs e) {
      FriendlyForms.Usability.nameWipe(nameTbx);
    }
  }
}
