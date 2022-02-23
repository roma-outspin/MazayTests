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
    class Serialization
    {
        public void Serialize(InteractiveTest Test)
        {
            string str = JsonSerializer.Serialize<InteractiveTest>(Test);
            File.WriteAllText(@"Tests\Tests1\Test1.json", str); 
        }
    }
}
