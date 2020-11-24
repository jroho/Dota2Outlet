using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

namespace Dota2Outlet.App_Code
{
    public class SiteGlobal
    {

        #region "SiteGlobal - Data Members"

        protected static Configuration o_WebConfig;

        #endregion

        #region "SiteGlobal - Properties"

        private static string s_ConnectionString = String.Empty;
        public static string ConnectionString
        {
            get { return GetConnectionString(s_DBName); }
            set { s_ConnectionString = value; }
        }

        private static string s_DBName = String.Empty;
        public static string DBName
        {
            get { return s_DBName; }
            set { s_DBName = value; }
        }

        private static string s_CookieName = String.Empty;
        public static string CookieName
        {
            get { return s_CookieName; }
            set { s_CookieName = value; }
        }

        #endregion

        #region "SiteGlobal - Constructors"

        public SiteGlobal() 
        {
            o_WebConfig = WebConfigurationManager.OpenWebConfiguration(HttpRuntime.AppDomainAppVirtualPath);
            s_DBName = GetConfigSetting("DBName");
            s_CookieName =  GetConfigSetting("CookieName");
        }

        #endregion

        #region "SiteGlobal - Methods - Helpers"
        
        protected static string GetConfigSetting(string sKey)
        {
            return GetConfigSetting(sKey);
        }

        protected static string GetConnectionString(string sName)
        {
            string sRestult = String.Empty;

            if (o_WebConfig != null)
            {
                ConnectionStringSettings oConnString = o_WebConfig.ConnectionStrings.ConnectionStrings[s_DBName];
                if (oConnString != null)
                    s_ConnectionString = oConnString.ConnectionString;
            }

            return sRestult;
        }

        #endregion

    }
}