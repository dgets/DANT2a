using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANT2a{
    class FileIO {
        //set up a standard (per-user) location to store the active lists
        public static void WriteActivesBinary<EntryType>(string path,
            EntryType wutOne) {
            using (Stream stream = File.Open(path, FileMode.Create)) {
                var binFmttr = 
                    new System.Runtime.Serialization.Formatters.Binary.
                        BinaryFormatter();
                binFmttr.Serialize(stream, wutOne);
            }
        }

        public static EntryType ReadActivesBinary<EntryType>(string path) {
            using (Stream stream = File.Open(path, FileMode.Open)) {
                var binFmttr =
                    new System.Runtime.Serialization.Formatters.Binary.
                        BinaryFormatter();
                return (EntryType)binFmttr.Deserialize(stream);
            }
        }
    }
}
