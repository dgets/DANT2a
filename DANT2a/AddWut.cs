﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a {
  public partial class AddWut : Form {

    private HeadsUp mainForm =
      (HeadsUp) Application.OpenForms[0];

    public AddWut() {
      InitializeComponent();

      mainForm.Enabled = false;
    }

    private void BtnGo_Click(object sender, EventArgs e) {
        //is this REALLY necessary? rbts normally come in groups...
        if (!rbtAlarm.Checked && !rbtTimer.Checked && !rbtReminder.Checked) {
          MessageBox.Show(Properties.Resources.SelectTypeToAdd);
          return;
        }

        if (rbtAlarm.Checked) {
          AddAlarm ouah = new AddAlarm();
          ouah.Show();
        } else if (rbtTimer.Checked) {
          AddTimer ouah = new AddTimer();
          ouah.Show();
        } else {
          AddReminder ouah = new AddReminder();
          ouah.Show();
        }

        mainForm.Enabled = true;
        this.Close();
    }
  }
}
