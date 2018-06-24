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
          Environment.SpecialFolder.ApplicationData) + "\\DANT\\";
        public static String saveDataLoc = saveDir + saveFile;
        public static String saveLogLoc = saveDir + logFile;

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
            Debug.ShowDbgOut("Using " + saveDir + " for application data.");

            //handle the saveDir schitt
            if (!Directory.Exists(saveDir)) {
                if (Debug.fileIODebugging) {
                    Debug.ShowDbgOut(saveDir + " allegedly doesn't exist\n" +
                      "Attempting to create " + saveDir);
                }

                try {
                    Directory.CreateDirectory(saveDir);
                } catch (Exception ex) {
                    Debug.ShowDbgOut("Exception thrown trying to create " + saveDir +
                        "\nMessage: " + ex.Message);
                }
            } else if (Debug.fileIODebugging) {
                Debug.ShowDbgOut(saveDir + " has been found.");
            }

            /*if ((File.GetAttributes(saveDir) & FileAttributes.Directory) !=
                FileAttributes.Directory) {
                if (Debug.fileIODebugging) {
                    Debug.ShowDbgOut(
                        "FileAttributes.Directory test on 'saveDir' is false\n" +
                        "Throwing exception.");
                }

                throw new Exception(saveDir + " exists but is not a directory?!?");
            }

            //wipe the previous entry (maybe, or set behavior?), create new
            //with the permissions that we need
            try {
                Directory.CreateDirectory(saveDir); //don't forget try/catch
            } catch (Exception ex) {
                Debug.ShowDbgOut("Issue creating app's data directory!");
            }*/

            //handle the saveDataLoc schitt
            if (!File.Exists(saveDataLoc) || !File.Exists(saveLogLoc)) {
                if (Debug.fileIODebugging) {
                    Debug.ShowDbgOut(saveDataLoc + " or " + saveLogLoc + " cannot be " +
                        "located.\nAttempting to create. . .");
                }

                try {
                    File.CreateText(saveDataLoc);
                } catch (Exception ex) {
                    Debug.ShowDbgOut("Unable to create " + saveDataLoc + "\nMessage" +
                        ex.Message);
                }
            }

            if ((File.GetAttributes(saveDataLoc) & FileAttributes.Normal) != 
                FileAttributes.Normal) {
                //same schitt here
                if (Debug.fileIODebugging) {
                    Debug.ShowDbgOut(
                        "FileAttributes.Normal test on 'saveFile' is false.\n" +
                        "Attempting to archive & recreate.");
                }

                try {
                    if (File.Exists(saveDataLoc)) {
                        File.Move(saveDataLoc, saveDataLoc + ".bak");
                        if (Debug.fileIODebugging) {
                            Debug.ShowDbgOut("Archived old " + saveDataLoc);
                        }
                    }

                    File.CreateText(saveDataLoc);
                } catch (Exception ex) {
                    Debug.ShowDbgOut("Unable to create " + saveDataLoc + "\n" +
                        ex.Message);
                }
            }

            //handle the logLoc schitt
            if ((File.GetAttributes(saveLogLoc) & FileAttributes.Normal) !=
                FileAttributes.Normal) {
                    //2nd verse, same as the first
                    if (Debug.fileIODebugging) {
                        Debug.ShowDbgOut(
                            "FileAttributes.Normal test on 'logFile' is false.\n" +
                            "Attempting to archive & recreate.");
                    }
                }

                try {
                    File.Move(saveLogLoc, saveLogLoc + ".bak");
                    File.CreateText(saveLogLoc);    //try/catch, idiot (&)
                } catch (Exception ex) {
                    Debug.ShowDbgOut("Unable to create " + saveLogLoc + "\n" + 
                        ex.Message);
                }
            }
            
        }
    }
}
