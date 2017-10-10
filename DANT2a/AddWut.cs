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
  public partial class AddWut : Form {

    public AddWut() {
      InitializeComponent();
    }

    private void btnGo_Click(object sender, EventArgs e) {
        //is this REALLY necessary? rbts normally come in groups...
        if (!rbtAlarm.Checked && !rbtTimer.Checked && !rbtReminder.Checked) {
          MessageBox.Show(Properties.Resources.SelectTypeToAdd);
          return;
        }

        if (rbtAlarm.Checked) {
          //addAlarm();
        } else if (rbtTimer.Checked) {
          //addTimer();
        } else {
          //addReminder();
        }
    }
  }
}
