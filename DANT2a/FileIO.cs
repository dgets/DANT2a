using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANT2a{
    class FileIO {
        public static void WriteActivesBinary<List>(string path,
          EntryType.AllEntries glob) {

            try {
                using (Stream stream = File.Open(path, FileMode.Create)) {
                    var binFmttr =
                        new System.Runtime.Serialization.Formatters.Binary.
                            BinaryFormatter();
                    //don't forget to try/catch wrap .Serialize(), too
                    try {
                        binFmttr.Serialize(stream, glob);
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

        public static EntryType.AllEntries ReadActivesBinary<List>(string path) {
            //ffs add the try/catch code
            using (Stream stream = File.Open(path, FileMode.Open)) {
                var binFmttr =
                    new System.Runtime.Serialization.Formatters.Binary.
                        BinaryFormatter();
                return (EntryType.AllEntries)binFmttr.Deserialize(stream);
            }
        }
    }
}
