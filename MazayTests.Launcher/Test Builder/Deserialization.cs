using MazayTests.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test_Builder
{
    class Deserialization
    {
        public InteractiveTest Deserialize()
        {
            string str = File.ReadAllText(@"Tests\Tests1\Test1.json");
            var result = JsonSerializer.Deserialize<InteractiveTest>(str);
            return result;
        }
    }
}
