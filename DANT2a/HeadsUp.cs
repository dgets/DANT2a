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
  public interface IAddAlarm {
    //not an interface virgin anymore, yay
    TextBox nameTbx {
      get;
    }
  }

  public partial class HeadsUp : Form {

    //active lists - make private?
    public List<EntryType.Alarm> activeAlarms = new List<EntryType.Alarm>();
    private List<EntryType.Timer> activeTimers = new List<EntryType.Timer>();
    private List<EntryType.Reminder> activeReminders = 
      new List<EntryType.Reminder>();           

    //debugging flags
    public const Boolean generalDebugging = true;
    public const Boolean alarmDebugging = true;
    public const Boolean timerDebugging = true;
    public const Boolean tickDebugging = true;
    public const Boolean fileIODebugging = true;

    //classes

    //HeadsUp form constructor
    public HeadsUp() {
      InitializeComponent();
    }

    //List setters (add edit/delete) - should these just be a single generic
    //passed an EntryType?
    public void addActiveAlarm(EntryType.Alarm newAl) {
      activeAlarms.Add(newAl);

      //trigger display update
      updateDisplay(EntryType.Entries.Alarm);
    }

    public void addActiveTimer(EntryType.Timer newTm) {
      activeTimers.Add(newTm);

      //display update
      updateDisplay(EntryType.Entries.Timer);
    }

    public void addActiveReminder(EntryType.Reminder newRe) {
      activeReminders.Add(newRe);

      //display, etc
      updateDisplay(EntryType.Entries.Reminder);
    }

    //misc methods
    private void btnAddAny_Click(object sender, EventArgs e) {
      AddWut newOne = new AddWut();
      newOne.Show();
    }

    private void updateDisplay(EntryType.Entries eType) {
      switch (eType) {
        case EntryType.Entries.Alarm:
          clbAlarms.Items.Clear();

          foreach (EntryType.Alarm al in activeAlarms) {
            if (al.Running) {
              clbAlarms.Items.Add(al.ActiveAt + " - " + al.Name, true);
            } else {
              clbAlarms.Items.Add(al.ActiveAt + " - " + al.Name, false);
            }
          }
          break;
        
       case EntryType.Entries.Timer:
          clbTimers.Items.Clear();

          foreach (EntryType.Timer tm in activeTimers) {
            if (tm.Running) {
              clbTimers.Items.Add(tm.Remaining + " - " + tm.Name, true);
            } else {
              clbTimers.Items.Add(tm.Remaining + " - " + tm.Name, false);
            }
          }
          break;

       case EntryType.Entries.Reminder:
         clbReminders.Items.Clear();

         foreach (EntryType.Reminder rm in activeReminders) {
           if (rm.Running) {
             clbReminders.Items.Add(rm.ActiveAt + " - " + rm.Name, true);
           } else {
             clbReminders.Items.Add(rm.ActiveAt + " - " + rm.Name, false);
           }
         }
         break;

      }
    }

    private int getNumRunning() {
      int cntr = 0;

      foreach (EntryType.Alarm al in activeAlarms) {
        if (al.Running == true) {
          cntr++;
        }
      }

      return cntr;
    }

  }
}
