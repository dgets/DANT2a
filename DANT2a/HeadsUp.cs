using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DANT2a {
  public interface IAddForm {
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
    public List<EntryType.Alarm> activeAlarms =
      new List<EntryType.Alarm>();
    public List<EntryType.Timer> activeTimers = 
      new List<EntryType.Timer>();
    public List<EntryType.Reminder> activeReminders = 
      new List<EntryType.Reminder>();           

    //HeadsUp form constructor
    public HeadsUp() {
      InitializeComponent();
    }

    public void addActiveAlarm(EntryType.Alarm newAl) {
      activeAlarms.Add(newAl);

      //trigger display update
      Display.updateDisplay(EntryType.Entries.Alarm);
    }

    public void addActiveTimer(EntryType.Timer newTm) {
      activeTimers.Add(newTm);

      //display update
      Display.updateDisplay(EntryType.Entries.Timer);
    }

    public void addActiveReminder(EntryType.Reminder newRe) {
      activeReminders.Add(newRe);

      //display, etc
      Display.updateDisplay(EntryType.Entries.Reminder);
    }

    //misc methods
    private void btnAddAny_Click(object sender, EventArgs e) {
      AddWut newOne = new AddWut();
      newOne.Show();
    }

    private void btnDbgSave_Click(object sender, EventArgs e) {
      //construct & deconstructGlob() need to be moved to EntryType
      EntryType.AllEntries theGlob = EntryType.constructGlob(activeAlarms, 
        activeTimers, activeReminders);

        try {
          FileIO.WriteActivesXML<EntryType.AllEntries>(FileIO.saveDataLoc, 
            theGlob);
        } catch (Exception ex) {
          Debug.showException("Save: " + ex.Message);
        }

        MessageBox.Show("Alarms/Timers/Reminders Saved", "Save Successful", 
          MessageBoxButtons.OK);
    }

    private void btnDbgLoad_Click(object sender, EventArgs e) {
      try {
        EntryType.deconstructGlob(FileIO.ReadActivesXML<EntryType.AllEntries>(
          FileIO.saveDataLoc));
      } catch (Exception ex) {
        Debug.showException("Load: " + ex.Message);
      }

      Display.updateDisplay(EntryType.Entries.Alarm);
      Display.updateDisplay(EntryType.Entries.Timer);
      Display.updateDisplay(EntryType.Entries.Reminder);
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

      Display.updateDisplay(EntryType.Entries.Timer);
    }

    //not sure at this point if it would be useful to have an option to 
    //select just one type; we'll keep it generic for now
    private Boolean anythingRunning() {
      foreach (EntryType.Alarm al in activeAlarms) {
        if (al.Running) {
          return true;
        }
      }
      foreach (EntryType.Timer tm in activeTimers) {
        if (tm.Running) {
          return true;
        }
      }
      foreach (EntryType.Reminder rm in activeReminders) {
        if (rm.Running) {
          return true;
        }
      }

      return false;
    }

    //alright, let's get down to the meat of things here.  or the tofu,
    //at least
    private void tmrGreenwichAtomic_Tick(object sender, EventArgs e) {
      if (!anythingRunning()) {
        if (Debug.tickDebugging) {
          Debug.showDbgOut("anythingRunning() sez false; disabling tmr");
        }

        tmrGreenwichAtomic.Enabled = false;
        return;
      }

      //alarms
      foreach (EntryType.Alarm current in activeAlarms) {
        if (current.Running) {
          if (current.isPast()) {
            alarmCLB.SetItemCheckState(activeAlarms.IndexOf(current),
              CheckState.Unchecked);
            current.ringRingNeo();
          }
          
          Display.updateDisplay(EntryType.Entries.Alarm);
        }
      }

      //timers
      foreach (EntryType.Timer current in activeTimers) {
        if (current.Running) {
          if (current.countDown()) {
            timerCLB.SetItemCheckState(activeTimers.IndexOf(current),
              CheckState.Unchecked);
            current.ringRingNeo();
          }/* else {
            current.countDown();
          }*/

          Display.updateDisplay(EntryType.Entries.Timer);
        }
      }

      //reminders
      foreach (EntryType.Reminder current in activeReminders) {
        if (current.Running) {
          if (Debug.tickDebugging) {
            Debug.showDbgOut(" - found running reminder");
          }
          if (current.checkInterval()) {
            reminderCLB.SetItemCheckState(activeReminders.IndexOf(current),
              CheckState.Unchecked);
            current.ringRingNeo();
            //maybe add some text formatting for aesthetics here, if user
            //has long text with no '\n's
            MessageBox.Show(current.Msg, "Don't Forget!", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
          }

          Display.updateDisplay(EntryType.Entries.Reminder);
        }
      }
    }

    //put this in a more logical location, verify that other methods are
    //grouped reasonably, as well
    private void alarmCLB_ItemCheck(Object sender, ItemCheckEventArgs e) {
      Boolean ouah = false;

      activeAlarms.ElementAt(e.Index).Running = true;
      if (activeAlarms.ElementAt(e.Index).Running) { 
        if (!tmrGreenwichAtomic.Enabled) {
          if (Debug.tickDebugging) {
            Debug.showDbgOut("Starting Greenwich Atomic");
          }

          tmrGreenwichAtomic.Enabled = true;
          tmrGreenwichAtomic.Start();
        }
      } else {
        foreach (EntryType.Alarm al in activeAlarms) {
          if (al.Running) {
            ouah = true;
            break;
          }
        }

        if (!ouah) {
          tmrGreenwichAtomic.Enabled = false;
        }
      }
    }

    private void reminderCLB_ItemCheck(Object sender, ItemCheckEventArgs e) {
      Boolean ouah = false;

      activeReminders.ElementAt(e.Index).Running = true;
      if (activeReminders.ElementAt(e.Index).Running) {
        if (!tmrGreenwichAtomic.Enabled) {
          if (Debug.tickDebugging) {
            Debug.showDbgOut("Starting Greenwich Atomic");
          }
        }

        tmrGreenwichAtomic.Enabled = true;
        tmrGreenwichAtomic.Start();
      } else {
        foreach (EntryType.Reminder rm in activeReminders) {
          if (rm.Running) {
            ouah = true;
            break;
          }
        }

        if (!ouah) {
          tmrGreenwichAtomic.Enabled = false;
        }
      }
    }

    private void timerCLB_ItemCheck(Object sender, ItemCheckEventArgs e) {
      activeTimers.ElementAt(e.Index).Running = true;
      //if (activeTimers.ElementAt(e.Index).Running) {
        if (!tmrGreenwichAtomic.Enabled) {
          tmrGreenwichAtomic.Enabled = true;
          tmrGreenwichAtomic.Start();
        }
      /*} else {
        foreach (EntryType.Timer tm in activeTimers) {
          if (tm.Running) {
            ouah = true;
            break;
          }
        }

        if (!ouah) {
          tmrGreenwichAtomic.Enabled = false;
        }
      }*/
    }

    private void btnDbgWipe_Click(object sender, EventArgs e) {
      //confirm wiping the old one, first
      if (File.Exists(FileIO.saveDataLoc)) {
        if (MessageBox.Show("Do you want to delete the save file?", 
              "Confirm savefile deletion!", MessageBoxButtons.YesNo) ==
              DialogResult.Yes) {
          //hose it
          try {
            File.Delete(FileIO.saveDataLoc);
          } catch (Exception) {
            MessageBox.Show("Exception trying to delete!", "Can't delete!",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

          activeAlarms.Clear(); activeTimers.Clear(); activeReminders.Clear();
          alarmCLB.Items.Clear(); timerCLB.Items.Clear();
          reminderCLB.Items.Clear();
        } else {
          MessageBox.Show("Letting savefile live.  Maybe it was never there" +
            " to begin with...  Do you think that's air you're breathing?",
            "Not killing existing savefile", MessageBoxButtons.OK, 
            MessageBoxIcon.Information);
        }

        MessageBox.Show("Alarms/Timers/Reminders Wiped", "Wipe Successful", 
          MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void btnEditAlarm_Click(object sender, EventArgs e) {
      if (alarmCLB.SelectedIndex != -1) {
        EditEntry editEntry = new EditEntry();
        editEntry.Show();
      } else {
        //nothing selected, error between floor & keyboard
        MessageBox.Show("You must select an entry to edit!", "Select Entry",
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void btnEditReminder_Click(object sender, EventArgs e) {
      if (reminderCLB.SelectedIndex != -1) {
        EditEntry editEntry = new EditEntry();
        editEntry.Show();
      } else {
        MessageBox.Show("You must select an entry to edit!", "Select Entry",
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void btnEditTimer_Click(object sender, EventArgs e) {
      if (timerCLB.SelectedIndex != -1) {
        EditEntry editEntry = new EditEntry();
        editEntry.Show();
      } else {
        MessageBox.Show("You must select an entry to edit!", "Select Entry",
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    //there's a better way to handle the *SelectedChange() methods here;
    //one method should be able to handle everything based
    private void alarmSelectedChange(object sender, EventArgs e) {
      if ((timerCLB.SelectedIndex != -1) || 
          (reminderCLB.SelectedIndex != -1)) {
        timerCLB.ClearSelected(); reminderCLB.ClearSelected();
      }
    }

    private void reminderSelectedChange(object sender, EventArgs e) {
      if ((alarmCLB.SelectedIndex != -1) ||
          (timerCLB.SelectedIndex != -1)) {
        alarmCLB.ClearSelected(); timerCLB.ClearSelected();
      }
    }

    private void timerSelectedChange(object sender, EventArgs e) {
      if ((alarmCLB.SelectedIndex != -1) ||
          (reminderCLB.SelectedIndex != -1)) {
        alarmCLB.ClearSelected(); reminderCLB.ClearSelected();
      }
    }
  }
}
