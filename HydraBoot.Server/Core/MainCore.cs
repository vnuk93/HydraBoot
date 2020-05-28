using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HydraBoot.Server
{
    public class MainCore
    {
        public Core.Models.MBoot GetConfig(string configName)
        {
            HydraBoot.Server.Core.Models.MBoot _out;
            try { 
                _out = JsonConvert.DeserializeObject<HydraBoot.Server.Core.Models.MBoot>(File.ReadAllText("./config/" + configName + ".json"));
            }
            catch
            {
                return null;
            }
            return _out;  
        }
    }
}