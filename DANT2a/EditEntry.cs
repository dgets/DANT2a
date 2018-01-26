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
      EntryType.Entries currentTypeEdited = EntryType.Entries.Alarm;

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
      }
    }
  }
}
