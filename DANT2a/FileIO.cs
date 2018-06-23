using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANT2a {
    class FileIO {
        private static String saveFile = "DANTentries.cfg";
        private static String logFile = "DANT.log";
        private static String saveDir = Environment.GetFolderPath(
          Environment.SpecialFolder.ApplicationData);
        public static String saveDataLoc = saveDir + "\\" + saveFile;
        public static String saveLogLoc = saveDir + "\\" + logFile;

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

        public static void DoLocInit() {
            //we will definitely be needing to add some exception testing
            //handle the saveDir schitt
            if (File.GetAttributes(saveDir) != FileAttributes.Directory) {
                if (Debug.fileIODebugging) {
                    Debug.ShowDbgOut(
                        "FileAttributes.Directory test on 'saveDir' is false");
                }

                //wipe the previous entry (maybe, or set behavior?), create new
                //with the permissions that we need
                Directory.CreateDirectory(saveDir); //don't forget try/catch
            }

            //handle the saveDataLoc schitt
            if (File.GetAttributes(/*saveDir + saveFile*/ saveDataLoc) 
                != FileAttributes.Normal) {
                //same schitt here
                if (Debug.fileIODebugging) {
                    Debug.ShowDbgOut(
                        "FileAttributes.Normal test on 'saveFile' is false");
                }

                File.CreateText(saveDataLoc);    //try/catch, etc etc
            }

            //handle the logLoc schitt
            if (File.GetAttributes(saveLogLoc) != FileAttributes.Normal) {
                //2nd verse, same as the first
                if (Debug.fileIODebugging) {
                    Debug.ShowDbgOut(
                        "FileAttributes.Normal test on 'logFile' is false");
                }

                File.CreateText(saveLogLoc);    //try/catch, idiot (&)
            }


        }
    }
}
