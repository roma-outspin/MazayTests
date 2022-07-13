using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazayTests.Manager;

namespace MazayTests.Manager
{
    class Repository : IRepository
    {
        public void CreateCollection(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void DeleteColection(string currentCollection)
        {
            Directory.Delete(currentCollection, true);
            MessageBox.Show($"Коллекция {GetNameCollection(currentCollection)} удалена");
        }

        public void DeleteTest(string currentTest)
        {
            File.Delete(currentTest);
            MessageBox.Show($"Тест {GetNameTest(currentTest)} удален");
        }

        public string[] GetCollections()
        {
           return Directory.GetDirectories("Tests");
        }

        public string GetNameCollection(string currentCollection)
        {
            return currentCollection.Substring(currentCollection.IndexOf('\\') + 1);
        }

        public string GetNameTest(string currentTest)
        {
            return currentTest.Substring(currentTest.LastIndexOf('\\') + 1);
        }

        public string[] GetTests(string currentCollection)
        {
            return Directory.GetFiles(currentCollection, "*.json");
        }
    }
}
