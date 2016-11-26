using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections;

namespace TBApiTest.Interaction
{
    public static class Helper
    {
        internal static void Serialize<T>(this T arg, string fileName)
        {
            string res = JsonConvert.SerializeObject(arg, Formatting.Indented);
            File.WriteAllText(fileName, res);
        }

        internal static T Deserialize<T>(string fileName)
        {
            string json = File.ReadAllText(fileName);
            T res = JsonConvert.DeserializeObject<T>(json);
            return res;
        }
    }
}
