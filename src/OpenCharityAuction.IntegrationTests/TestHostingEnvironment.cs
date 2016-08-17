using System;
using System.IO;
using System.Runtime.Versioning;
using Microsoft.Extensions.PlatformAbstractions;

namespace Website.Tests
{
    public class TestApplicationEnvironment : ApplicationEnvironment
    {
        public TestApplicationEnvironment()
        {
            string shopPath =
                Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\Website"));
        }

        public object GetData(string name)
        {
            throw new NotImplementedException();
        }

        public void SetData(string name, object value)
        {
            throw new NotImplementedException();
        }

        public string Configuration => "Debug";
        
    }
}