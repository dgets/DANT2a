using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANT2a{
    class FileIO {
        private static string debugPath = 
            "C:\\Users\\lobotomy\\Desktop\\ouah.sav";
        //for now we're going to use a static hardcoded pathway for debugging;
        //later on we'll do the following:
        //set up a standard (per-user) location to store the active lists
        public static void WriteActivesBinary<EntryType>(string path,
            EntryType wutOne) {
            path = debugPath;
            
            try {
                using (Stream stream = File.Open(path, FileMode.Create)) {
                    var binFmttr =
                        new System.Runtime.Serialization.Formatters.Binary.
                            BinaryFormatter();
                    //don't forget to try/catch wrap .Serialize(), too
                    try {
                        binFmttr.Serialize(stream, wutOne);
                    } catch (Exception e) {
                        //bubble any BinaryFormatter.Serialize() issues up
                        throw e;
                    }
                }
            } catch (Exception e) {
                //this one will handle any stream opening & issues from
                //above
                throw e;    //whatever bubbles bubbles up
            }
        }

        public static EntryType ReadActivesBinary<EntryType>(string path) {
            path = debugPath;   //just for debugging

            using (Stream stream = File.Open(path, FileMode.Open)) {
                var binFmttr =
                    new System.Runtime.Serialization.Formatters.Binary.
                        BinaryFormatter();
                return (EntryType)binFmttr.Deserialize(stream);
            }
        }
    }
}
