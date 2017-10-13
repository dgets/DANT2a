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

    }
  }
}
