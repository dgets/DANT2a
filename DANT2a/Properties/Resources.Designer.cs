﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DANT2a.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DANT2a.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name Goes Here.
        /// </summary>
        internal static string InactiveNameTbx {
            get {
                return ResourceManager.GetString("InactiveNameTbx", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter your reminder message here.
        /// </summary>
        internal static string InactiveReminderTbx {
            get {
                return ResourceManager.GetString("InactiveReminderTbx", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must selected a name!.
        /// </summary>
        internal static string NoNameSetError {
            get {
                return ResourceManager.GetString("NoNameSetError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No user text entered!.
        /// </summary>
        internal static string NoTextError {
            get {
                return ResourceManager.GetString("NoTextError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No selected timers!.
        /// </summary>
        internal static string NoTimerSelectedError {
            get {
                return ResourceManager.GetString("NoTimerSelectedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must select\ntype to add!.
        /// </summary>
        internal static string SelectTypeToAdd {
            get {
                return ResourceManager.GetString("SelectTypeToAdd", resourceCulture);
            }
        }
    }
}
