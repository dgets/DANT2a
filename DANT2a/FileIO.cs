using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANT2a {
    class FileIO {
        private static String saveFile = "DANTentries.cfg";
        private static String saveDir = Environment.GetFolderPath(
          Environment.SpecialFolder.ApplicationData);
        public static String saveDataLoc = saveDir + "\\" + saveFile;

        public static void WriteActivesXML<List>(string path,
          EntryType.AllEntries glob) {

            try {
                using (Stream stream = File.Open(path, FileMode.Create)) {
                    var xmlFmttr = new System.Xml.Serialization.XmlSerializer(
                      typeof(EntryType.AllEntries));
                    
                    //don't forget to try/catch wrap .Serialize(), too
                    try {
                      //binFmttr.Serialize(stream, glob);
                      xmlFmttr.Serialize(stream, glob);
                    } catch (Exception e) {
                        //bubble any Binary/XMLFormatter.Serialize() issues up
                        throw e;
                    }
                }
            } catch (Exception e) {
                //this one will handle any stream opening & issues from
                //above
                throw e;    //whatever bubbles bubbles up
            }
        }

        public static EntryType.AllEntries ReadActivesXML<List>(string path) {
            //ffs add the try/catch code
            using (Stream stream = File.Open(path, FileMode.Open)) {
              var xmlFmttr = new System.Xml.Serialization.XmlSerializer(
                typeof(EntryType.AllEntries));

              return (EntryType.AllEntries)xmlFmttr.Deserialize(stream);
            }
        }
    }
}
