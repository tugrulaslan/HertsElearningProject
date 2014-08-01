using HertsElearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace HertsElearningProject.Service
{
    public class VisitorStatsService
    {
        public void collectVisitorData(String browserName, String ipAddr, String userAgent, bool isMobileDev, bool isLocalCon, String sessionID)
        {
            HertsOnlineEntities db = new HertsOnlineEntities();
            VisitorStatistics visitorStatisticsModel = new VisitorStatistics();
            String visitStamp = DateTime.Now.ToString("dd/MM/yyyy H:mm");
            visitorStatisticsModel.UserSession = sessionID;

            if (isLocalCon)
            {
                //local connection
                visitorStatisticsModel.IPAddress = ipAddr;
                visitorStatisticsModel.Country = "localhost";
            }
            else
            {
                //external connection
                visitorStatisticsModel.IPAddress = ipAddr;
                visitorStatisticsModel.Country = getVisitorCountry(ipAddr);
            }
            if (isMobileDev)
            {
                //Mobile device
                visitorStatisticsModel.OperatingSystem = getMobileOS(userAgent);
                visitorStatisticsModel.Device = getMobileDevice(userAgent);
            }
            else
            {
                //Desktop Device
                visitorStatisticsModel.OperatingSystem = getDesktopOS(userAgent);
                visitorStatisticsModel.Device = "Desktop";
            }
            visitorStatisticsModel.VisitTimeStamp = visitStamp;

            visitorStatisticsModel.BrowserName = browserName;

            db.VisitorStatisticsEntity.Add(visitorStatisticsModel);
            db.SaveChanges();
        }

        public String getVisitorCountry(String ipAddress)
        {
            string APIKey = "159421dcb8169d1ef02eb745b3a9ba62c769430f2bfa47d4dbdc94ed86ff5e52";
            string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, ipAddress);
            List<Location> locations = new List<Location>();
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                Location locationModel = new JavaScriptSerializer().Deserialize<Location>(json);

                return locationModel.CountryName;

            }
        }

        public String getMobileDevice(String userAgent)
        {
            List<String> device = new List<string>();

            device.Add("iPad");
            device.Add("IPAD");
            device.Add("iPhone");
            device.Add("IPHONE");
            device.Add("GT-N7000");
            device.Add("GT-N7100");
            device.Add("GT-N7200");

            for (int i = 0; i < device.Count; i++)
            {
                if (userAgent.Contains(device.ElementAt(i)))
                {
                    //return device.ElementAt(i);
                    return "Mobile";
                }
            }
            return "Unknown";

        }

        public String getMobileOS(String userAgent)
        {
            List<String> operatingSystems = new List<string>();

            operatingSystems.Add("Mac");
            operatingSystems.Add("mac");
            operatingSystems.Add("Linux");
            operatingSystems.Add("linux");
            operatingSystems.Add("Android");
            operatingSystems.Add("android");
            operatingSystems.Add("Windows");
            operatingSystems.Add("windows");
            operatingSystems.Add("Win");
            operatingSystems.Add("win");
            operatingSystems.Add("Unix");
            operatingSystems.Add("unix");
            operatingSystems.Add("Symbian");
            operatingSystems.Add("SymbianOS");
            operatingSystems.Add("SymbianOs");

            for (int i = 0; i < operatingSystems.Count; i++)
            {
                if (userAgent.Contains(operatingSystems.ElementAt(i)))
                {
                    return operatingSystems.ElementAt(i);
                }
            }
            return "Unknown";

        }

        public String getDesktopOS(String userAgent)
        {
            List<String> operatingSystems = new List<string>();

            operatingSystems.Add("Mac");
            operatingSystems.Add("mac");
            operatingSystems.Add("Linux");
            operatingSystems.Add("linux");
            operatingSystems.Add("Android");
            operatingSystems.Add("android");
            operatingSystems.Add("Windows");
            operatingSystems.Add("windows");
            operatingSystems.Add("WinNT");
            operatingSystems.Add("Win");
            operatingSystems.Add("win");
            operatingSystems.Add("Unix");
            operatingSystems.Add("unix");

            for (int i = 0; i < operatingSystems.Count; i++)
            {
                if (userAgent.Contains(operatingSystems.ElementAt(i)))
                {
                    return operatingSystems.ElementAt(i);
                }
            }
            return "Unknown";
        }
    }
}