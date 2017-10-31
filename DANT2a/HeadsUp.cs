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
  public interface IAddForm {
    //not an interface virgin anymore, yay
    TextBox nameTbx {
      get;
    }
  }

  public interface IHeadsUp {
    CheckedListBox alarmCLB {
      get;
    }

    CheckedListBox timerCLB {
      get;
    }

    CheckedListBox reminderCLB {
      get;
    }
  }

  public partial class HeadsUp : Form, IHeadsUp {
    //interface schiesse
    public CheckedListBox alarmCLB {
      get { return this.clbAlarms; }
      set { this.clbAlarms = alarmCLB;  }
    }

    public CheckedListBox timerCLB {
      get { return this.clbTimers; }
      set { this.clbTimers = timerCLB; }
    }

    public CheckedListBox reminderCLB {
      get { return this.clbReminders; }
      set { this.clbReminders = reminderCLB; }
    }

    //active lists - should these be private w/getters & setters?
    public static List<EntryType.Alarm> activeAlarms =
      new List<EntryType.Alarm>();
    public List<EntryType.Timer> activeTimers = new List<EntryType.Timer>();
    public List<EntryType.Reminder> activeReminders = 
      new List<EntryType.Reminder>();           

    //debugging flags
    public const Boolean generalDebugging = true;
    public const Boolean alarmDebugging = true;
    public const Boolean timerDebugging = true;
    public const Boolean tickDebugging = true;
    public const Boolean fileIODebugging = true;

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

    private void btnDbgSave_Click(object sender, EventArgs e) {
        try {
            FileIO.WriteActivesBinary<List<EntryType.Timer>>("", activeTimers);
        } catch (Exception ex) {
                MessageBox.Show("Exception: " + ex.Message);
        }
    }

    private void updateDisplay(EntryType.Entries eType) {
      //this method needs to be updated to take advantage of updateEntry()
      //properly
      int cntr = 0;

      switch (eType) {
        case EntryType.Entries.Alarm:
          clbAlarms.Items.Clear();

          foreach (EntryType.Alarm al in activeAlarms) {
            if (al.Running && !al.isPast()) {
              updateEntry(EntryType.Entries.Alarm, cntr);
            } else {
              if (al.Running) {
                //executed if the alarm is in the past but for some
                //reason still flagged as running
                al.toggleRunning();
              }
              clbAlarms.Items.Add(al.ActiveAt + " - " + al.Name, false);
            }

            cntr++;
          }
          cntr = 0;
          break;
        
        case EntryType.Entries.Timer:
          cntr = 0;

          clbTimers.Items.Clear();

          foreach (EntryType.Timer tm in activeTimers) {
            if (tm.Running) {
              //clbTimers.Items.Add(tm.Remaining + " - " + tm.Name, true);
              updateEntry(EntryType.Entries.Timer, cntr);
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

    //display update methods - this (and the related ToString() methods,
    //are going to almost certainly be replacing the above update*() method
    //at least where it contains the switch/case logic
    public void updateEntry(EntryType.Entries whichType, int curr) {
      switch (whichType) {
        case EntryType.Entries.Alarm:
          alarmCLB.Items.Add(activeAlarms[curr].ToString());
          break;
        case EntryType.Entries.Timer:
          timerCLB.Items.Add(activeTimers[curr].ToString());
          break;
        case EntryType.Entries.Reminder:
          reminderCLB.Items.Add(activeReminders[curr].ToString());
          break;
        default:
          //ouah
          break;
      }
    }

    //is this really the best place for this?
    private void btnResetTimer_Click(object sender, EventArgs e) {
      if (clbTimers.SelectedIndices.Count == 0) {
        MessageBox.Show("You must first select timer(s) to reset!", 
          Properties.Resources.NoTimerSelectedError, MessageBoxButtons.OK,
          MessageBoxIcon.Error);
      } else {
        foreach (int idx in clbTimers.SelectedIndices) {
          activeTimers[idx].Remaining = activeTimers[idx].Duration;
        }
      }

      updateDisplay(EntryType.Entries.Timer);
    }

    //alright, let's get down to the meat of things here.  or the tofu,
    //at least
    private void tmrGreenwichAtomic_Tick(object sender, EventArgs e) {
      //int cntr = 0;
      //we'll start by updating the displays

      //alarms
      foreach (EntryType.Alarm current in activeAlarms) {
        if (current.Running) {
          updateDisplay(EntryType.Entries.Alarm);
        }
      }

      foreach (EntryType.Timer current in activeTimers) {
        if (current.Running) {
          updateDisplay(EntryType.Entries.Timer);
        }
      }
    }

    private void alarmCLB_ItemCheck(Object sender, ItemCheckEventArgs e) {
      activeAlarms.ElementAt(e.Index).Running = true;
      //MessageBox.Show(e.Index.ToString());
      tmrGreenwichAtomic.Start();
    }
  }
}
