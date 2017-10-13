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
  public partial class AddAlarm : Form
  {
    private HeadsUp mainForm = 
      (HeadsUp) Application.OpenForms[0];

    //constructor(s)
    public AddAlarm() {
      InitializeComponent();
      
      tbxName.ForeColor = SystemColors.InactiveCaption;
      tbxName.Text = Properties.Resources.InactiveNameTbx;
      dtpAlarmTarget.CustomFormat = "MMMM.dd, yyyy '@' H:mm:ss";
    }

    private void btnAddAlarm_Click(object sender, EventArgs e)
    {
      EntryType.Alarm godOuah = new EntryType.Alarm();

      //problems?
      //need to implement better validation
      if (tbxName.Text.Equals(Properties.Resources.InactiveNameTbx)) {
        MessageBox.Show("No user text!", "You must set an alarm name!",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      //this is done in the wrong place, isn't it?
      godOuah.Name = tbxName.Text;
      godOuah.ActiveAt = dtpAlarmTarget.Value.Date;
      godOuah.Running = false;
      godOuah.SoundBite = null; //this'll just mean a console beep
      //godOuah.SoundBite = ofdLocateSoundbite.FileName.

      mainForm.addActiveAlarm(godOuah);

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

    private void tbxName_Leave(object sender, EventArgs e)
    {
      tbxName.ForeColor = SystemColors.InactiveCaption;

      if (tbxName.Text.Equals("")) {
        tbxName.Text = Properties.Resources.InactiveNameTbx;
      }
    }
    
  }
}
