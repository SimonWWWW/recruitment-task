using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TestsTemplate
    {
        private const string JsonFileName = "inputs.json";
        private static string JsonFilePath => Directory.EnumerateFiles(Environment.CurrentDirectory, JsonFileName).FirstOrDefault();
        
        string json = File.ReadAllText(JsonFilePath);
        public class JsonData
        {
            public string SauceDemoUrl { get; set; }

            public string CorrectUsername { get; set; }

            public string CorrectPassword { get; set; }

            public string IncorrectUsername { get; set; }

            public string IncorrectPassword { get; set; }
        }
    }
}
