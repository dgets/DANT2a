using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a {
  class Debug {
    //not so sure that I'm going to need these like I thought
    public enum DebugModes {
      General, Alarm, Timer, Reminder, Tick, FileIO
    };

    //debugging flags
    public const Boolean generalDebugging = true;
    public const Boolean alarmDebugging = true;
    public const Boolean timerDebugging = true;
    public const Boolean reminderDebugging = true;
    public const Boolean tickDebugging = true;
    public const Boolean fileIODebugging = true;
    public const Boolean consoleDebugging = true;
    public const Boolean mBoxDebugging = false;
    
    //methods
    public static void ShowException(String eMsg) {
      if (consoleDebugging) {
        Console.WriteLine("Excp: " + eMsg);
      }

      if (mBoxDebugging) {
        MessageBox.Show(eMsg, "Exception", MessageBoxButtons.OK,
        MessageBoxIcon.Error);
      }
    }

    public static void ShowDbgOut(/*DebugModes mode,*/ String dMsg) {
      if (consoleDebugging) {
        Console.WriteLine("Dbg: " + dMsg);
      }

      if (mBoxDebugging) {
        MessageBox.Show(dMsg, "Debugging Out", MessageBoxButtons.OK,
          MessageBoxIcon.Information);
      }
    }
  }
}
