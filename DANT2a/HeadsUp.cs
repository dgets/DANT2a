﻿using System;
using System.IO;
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
    public static List<EntryType.Timer> activeTimers = 
      new List<EntryType.Timer>();
    public static List<EntryType.Reminder> activeReminders = 
      new List<EntryType.Reminder>();           

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
      /*const String saveFile = "DANTentries.cfg";
      String saveDir = Environment.GetFolderPath(
        Environment.SpecialFolder.ApplicationData);*/

    //construct & deconstructGlob() need to be moved to EntryType
    EntryType.AllEntries theGlob = constructGlob();

      try {
        FileIO.WriteActivesBinary<EntryType.AllEntries>(FileIO.saveDataLoc, 
          theGlob);
      } catch (Exception ex) {
        Debug.showException("Save: " + ex.Message);
        //MessageBox.Show("Exception saving: " + ex.Message);
      }

      MessageBox.Show("Alarms/Timers/Reminders Saved", "Save Successful", 
        MessageBoxButtons.OK);
    }

    private void btnDbgLoad_Click(object sender, EventArgs e) {
      try {
        deconstructGlob(FileIO.ReadActivesBinary<EntryType.AllEntries>(
          FileIO.saveDataLoc));
      } catch (Exception ex) {
        Debug.showException("Load: " + ex.Message);
        //MessageBox.Show("Exception loading: " + ex.Message);
      }

      updateDisplay(EntryType.Entries.Alarm);
      updateDisplay(EntryType.Entries.Timer);
      updateDisplay(EntryType.Entries.Reminder);
    }

    private void updateDisplay(EntryType.Entries eType) {
      int cntr;   //wut?

      switch (eType) {
        //implement EntryType.Entries.All, ffs
        /*case EntryType.Entries.All:
          clbAlarms.Items.Clear(); clbTimers.Items.Clear();
          clbReminders.Items.Clear();

          break;*/

        case EntryType.Entries.Alarm:
          clbAlarms.Items.Clear();

          for (int cntr2 = 0; cntr2 < activeAlarms.Count; cntr2++) {
            //switch the above to a 'for' loop & remove cntr++ below
            EntryType.Alarm al = activeAlarms[cntr2];

            if (al.Running) {
              if (!al.isPast()) {
                updateEntry(EntryType.Entries.Alarm, cntr2);

                /*if (Debug.tickDebugging && Debug.alarmDebugging) {
                  Debug.showDbgOut("Entered updateEntry(alarm)");
                }*/
              } else {
                if (Debug.tickDebugging && Debug.alarmDebugging) {
                  Debug.showDbgOut("Toggling alarm #" + cntr2.ToString());
                }

                al.toggleRunning();
              }
            } else {
              clbAlarms.Items.Add(al.ActiveAt + " - " + al.Name, false);

              //if this is needed later on, uncomment and change 
              //Debug.alarmDebugging when necessary after that point
              /*if (Debug.tickDebugging && Debug.alarmDebugging) {
                Debug.showDbgOut("Alarm #" + cntr2.ToString() + 
                  " not running");
              }*/
            }
          }
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
      /*if (tickDebugging) {
        MessageBox.Show("In updateEntry()", "Tick Debugging");
      }*/
      
      switch (whichType) {
        case EntryType.Entries.Alarm:
          alarmCLB.Items.Add(activeAlarms[curr].ToString(), true);
          alarmCLB.Show();
          break;
        case EntryType.Entries.Timer:
          timerCLB.Items.Add(activeTimers[curr].ToString(), true);
          timerCLB.Show();
          break;
        case EntryType.Entries.Reminder:
          reminderCLB.Items.Add(activeReminders[curr].ToString(), true);
          reminderCLB.Show();
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
          //MessageBox.Show("anythingRunning() sez false");
          Debug.showDbgOut("anythingRunning() sez false; disabling tmr");
        }

        tmrGreenwichAtomic.Enabled = false;
        return;
      }

      //alarms
      foreach (EntryType.Alarm current in activeAlarms) {
        if (current.Running) {
          if (current.isPast()) {
            Boolean ouah;

            current.ringRingNeo();
            /* all of this should be handled in ringRingNeo() nao
            ouah = current.toggleRunning();

            if (Debug.tickDebugging) {
              //MessageBox.Show(current.Name + " toggle");
              Debug.showDbgOut(current.Name + " isPast() sez true");
            }

            MessageBox.Show(current.Name + " isPast(); ouah = "
              + ouah.ToString());*/
          } else {
            updateDisplay(EntryType.Entries.Alarm);
          }
        }
      }

      //timers
      /*foreach (EntryType.Timer current in activeTimers) {
        if (current.Running) {
          updateDisplay(EntryType.Entries.Timer);
        }
      }*/
    }

    private EntryType.AllEntries constructGlob() {
      EntryType.AllEntries newGlob = new EntryType.AllEntries();

      newGlob.Als = activeAlarms; newGlob.Tms = activeTimers;
      newGlob.Rms = activeReminders;

      return newGlob;
    }

    private void deconstructGlob(EntryType.AllEntries readGlob) {
      activeAlarms = readGlob.Als; activeTimers = readGlob.Tms;
      activeReminders = readGlob.Rms;
    }

    //put this in a more logical location, verify that other methods are
    //grouped reasonably, as well
    private void alarmCLB_ItemCheck(Object sender, ItemCheckEventArgs e) {
      Boolean ouah = false;

      activeAlarms.ElementAt(e.Index).Running = true;
      //if (activeAlarms.ElementAt(e.Index).toggleRunning()) {
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

    private void btnDbgWipe_Click(object sender, EventArgs e) {
      //confirm wiping the old one, first
      if (File.Exists(FileIO.saveDataLoc)) {
        if (MessageBox.Show("Do you want to delete the save file?", 
              "Confirm savefile deletion!", MessageBoxButtons.YesNo) ==
              DialogResult.Yes) {
          //hose it
          try {
            File.Delete(FileIO.saveDataLoc);
          } catch (Exception ex) {
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
