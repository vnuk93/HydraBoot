// = Model version 1.0 =
using System;
using System.Collections.Generic;
using System.Text;

namespace HydraBoot.Server.Core.Models
{
    public class MBoot
    {
        public string modelVersion { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string packages { get; set; }
        public string version { get; set; }
        public int port { get; set; }
        public string relativePath { get; set; }
        public string group { get; set; }
    }
}
