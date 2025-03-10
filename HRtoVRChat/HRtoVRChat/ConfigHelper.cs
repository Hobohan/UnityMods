﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace HRtoVRChat
{
    public static class ConfigHelper
    {
        public static Config LoadedConfig;
        private static string myCategory = "HRtoVRChat";

        public static bool DoesCategoryExist(string category) => MelonPreferences.GetCategory(category) != null;

        private static void CreateConfig()
        {
            MelonPreferences.CreateCategory(myCategory);
            try { MelonPreferences.CreateEntry(myCategory, "hrtype", "unknown", "hrtype", "Displays the HRType to use; see documentation."); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "fitbiturl", String.Empty, "fitbiturl", "Websocket URL to Connect to for FitbitHRtoWS."); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "hyperatesessionid", String.Empty, "hyperatesessionid", "SessionId for HypeRate."); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "pulsoidkey", String.Empty, "pulsoidkey", "WebSocket Key for Pulsoid WebSocket feed."); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "pulsoidwidget", String.Empty, "pulsoidwidget", "Widget Id for Pulsoid."); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "textfilelocation", String.Empty, "textfilelocation", "Location of the text file that contains HR data. (may only contain ints only!)"); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "ShowDebug", false, "ShowDebug", "Show additional Debug Information"); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "UIXSupport", true, "UIXSupport", "Add support for the UIExpansionKit mod"); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "AMAPISupport", true, "AMAPISupport", "Add support for the ActionMenuApi mod"); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "MaxHR", 150, "MaxHR", "Sets the maximum HR value for the HRPercent parameter (1)"); } catch (Exception) { }
            try { MelonPreferences.CreateEntry(myCategory, "MinHR", 0, "MinHR", "Sets the minimum HR value for the HRPercent parameter (0)"); } catch (Exception) { }
            LogHelper.Log("ConfigHelper", "Created Config!");
        }

        public static Config LoadConfig()
        {
            CreateConfig();
            Config newConfig = new Config();

            foreach (MelonPreferences_Entry mpe in MelonPreferences.GetCategory(myCategory).Entries)
            {
                switch (mpe.DisplayName.ToLower())
                {
                    case "hrtype":
                        newConfig.hrType = mpe.GetValueAsString();
                        break;
                    case "fitbiturl":
                        newConfig.fitbitURL = mpe.GetValueAsString();
                        break;
                    case "hyperatesessionid":
                        newConfig.hyperateSessionId = mpe.GetValueAsString();
                        break;
                    case "pulsoidfeed":
                        newConfig.pulsoidfeed = mpe.GetValueAsString();
                        LogHelper.Warn("ConfigHelper", "pulsoidfeed Value is deprecated!");
                        break;
                    case "pulsoidkey":
                        newConfig.pulsoidkey = mpe.GetValueAsString();
                        break;
                    case "pulsoidwidget":
                        newConfig.pulsoidwidget = mpe.GetValueAsString();
                        break;
                    case "textfilelocation":
                        newConfig.textfilelocation = mpe.GetValueAsString();
                        break;
                    case "showdebug":
                        newConfig.ShowDebug = Convert.ToBoolean(mpe.GetValueAsString());
                        break;
                    case "uixsupport":
                        newConfig.UIXSupport = Convert.ToBoolean(mpe.GetValueAsString());
                        break;
                    case "amapisupport":
                        newConfig.AMAPISupport = Convert.ToBoolean(mpe.GetValueAsString());
                        break;
                    case "maxhr":
                        newConfig.MaxHR = Convert.ToDouble(mpe.GetValueAsString());
                        break;
                    case "minhr":
                        newConfig.MinHR = Convert.ToDouble(mpe.GetValueAsString());
                        break;
                }
            }

            LoadedConfig = newConfig;
            LogHelper.Log("ConfigHelper", "Loaded Config!");
            return newConfig;
        }

        public class Config
        {
            public string hrType = "unknown";
            public string fitbitURL = "ws://localhost:8080/";
            public string hyperateSessionId = String.Empty;
            public string pulsoidfeed = String.Empty;
            public string pulsoidkey = String.Empty;
            public string pulsoidwidget = String.Empty;
            public string textfilelocation = String.Empty;
            public bool ShowDebug = false;
            public bool AMAPISupport = true;
            public bool UIXSupport = true;
            public double MaxHR = 150;
            public double MinHR = 0;
        }
    }
}
