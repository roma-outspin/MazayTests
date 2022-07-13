using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazayTests.Manager
{
    interface IRepository
    {
        string[] GetCollections();
        string[] GetTests(string currentCollection);
        string GetNameCollection(string currentCollection);
        string GetNameTest(string currentTest);
        void DeleteColection(string currentCollection);
        void DeleteTest(string currentTest);
        void CreateCollection(string path);
    }
}
