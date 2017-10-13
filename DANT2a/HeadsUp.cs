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
    
    /*public void addActiveAlarm(EntryType.Alarm newAlarm) {
      activeAlarms.Add(newAlarm);
      
      //update display, whether or not running entries have triggered ticking

    }*/

    private void updateDisplay(EntryType.Entries eType) {
      //let's make this one a switch/case, so that it doesn't look so gross

      int cntr = 0;

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

      /* if (eType.Equals(EntryType.Entries.Alarm)) {
        //clear display (primarily in lieu of # of listed changing downwards
        clbAlarms.Items.Clear();

        //add entry's display text
        foreach (EntryType.Alarm al in activeAlarms) {
          clbAlarms.Items.Add(al.Name + " - " + al.ActiveAt);

          if (al.Running == true) {
            clbAlarms.Items.Add("Checked", true);
          } else {
            clbAlarms.Items.Add("Checked", false);
          }
        }

      } else if (eType.Equals(EntryType.Entries.Timer)) {
        //clear display
        clbTimers.Items.Clear();

        //add display text
        foreach (EntryType.Timer tm in activeTimers) {
          clbTimers.Items.Add(tm.Name + " - " + tm.Remaining);

          if (tm.Running == true) {
            clbTimers.Items.Add("Checked", true);
          } else {
            clbTimers.Items.Add("Checked", false);
          }
        }
      } else if (eType.Equals(EntryType.Entries.Reminder)) {
        //clear display
        clbReminders.Items.Clear();

        //add display text
        foreach (EntryType.Reminder rm in activeReminders) {
          clbReminders.Items.Add(rm.Name + " - " + rm.ActiveAt + " - " +
            rm.Msg);

          if (rm.Running == true) {
            clbReminders.Items.Add("Checked", true);
          } else {
            clbReminders.Items.Add("Checked", false);
          }
        }
      } else {
        //do 'em all
        //clear
        clbTimers.Items.Clear();
        clbTimers.Items.Clear();
        clbReminders.Items.Clear();

        //add display text (modularize above)

      } */
      
      //String displayText = null;
      //int nr = getNumRunning();
      //EntryType.Alarm curAlarm = null;

      /*for (int cntr = 0; cntr <= nr;) {
        if (activeAlarms[cntr].Running) {
          curAlarm = activeAlarms[cntr++];
          clbAlarms.Items.Add(curAlarm.Name + " - " + curAlarm.
      }*/

      /*foreach (EntryType.Alarm a in activeAlarms) {
        //displayText = a.Name + " - " + a.ActiveAt;
        clbAlarms. .Text = a.Name + " - " + a.ActiveAt;
      }*/
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
