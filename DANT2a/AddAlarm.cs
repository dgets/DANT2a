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
  public partial class AddAlarm : Form, IAddForm {
    private HeadsUp mainForm = 
      (HeadsUp) Application.OpenForms[0];

    public TextBox nameTbx {
      get { return this.tbxName; }
      set { this.tbxName = nameTbx; }
    }

    //constructor(s)
    public AddAlarm() {
      InitializeComponent();
      
      tbxName.ForeColor = SystemColors.InactiveCaption;
      tbxName.Text = Properties.Resources.InactiveNameTbx;
      dtpAlarmTarget.CustomFormat = "MMMM.dd, yyyy '@' H:mm:ss";
      dtpAlarmTarget.Value = DateTime.Now;
    }

    private void btnAddAlarm_Click(object sender, EventArgs e) {
      EntryType.Alarm godOuah = new EntryType.Alarm();
      
      //problems?
      //need to implement better validation
      if ((tbxName.Text.Equals(Properties.Resources.InactiveNameTbx)) ||
          (tbxName.Text.Length < 3)) { 
        MessageBox.Show(Properties.Resources.NoNameSetError,
          Properties.Resources.NoTextError,
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //this is done in the wrong place, isn't it?
      godOuah.Name = tbxName.Text;
      godOuah.ActiveAt = dtpAlarmTarget.Value;
      godOuah.Running = false;
      godOuah.SoundBite = null; //this'll just mean a console beep
      //godOuah.SoundBite = ofdLocateSoundbite.FileName.

      mainForm.addActiveAlarm(godOuah);

      this.Close();
    }

    //usability methods - trying to modularize
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
