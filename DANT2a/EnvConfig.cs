using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a {
    class EnvConfig {
        private static readonly HeadsUp mainForm = (HeadsUp)Application.OpenForms[0];
        public enum LogOpts { Reminders, ReminderAck, Alarms, Timers, Misc };
        public enum EnvConfOpts { DefaultSoundBite, BeepEnabled };

        [Serializable]
        public partial class Env {
            private Boolean Reminders, ReminderAck, Alarms, Timers, Misc;
            private String DefaultSoundBite;
            private Boolean BeepEnabled;



        }

    }
}
