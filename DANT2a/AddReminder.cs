using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DANT2a {
  public partial class AddReminder : Form {
    private HeadsUp mainForm =
      (HeadsUp)Application.OpenForms[0];

    //constructor
    public AddReminder() {
      InitializeComponent();


    }
  }
}
