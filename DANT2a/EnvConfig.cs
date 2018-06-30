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
            private Boolean reminders, reminderAck, alarms, timers, misc, beepEnabled; 
            private String defaultSoundBite;

            //let's see if things are working with the abbreviated style
            public Boolean Reminders {
                get; set;
            }

            public Boolean ReminderAck {
                get; set;
            }

            public Boolean Alarms {
                get; set;
            }

            public Boolean Timers {
                get; set;
            }

            public Boolean Misc {
                get; set;
            }

            public Boolean BeepEnabled {
                get; set;
            }

            public String DefaultSoundBite {
                get; set;
            }
            


        }

    }
}
