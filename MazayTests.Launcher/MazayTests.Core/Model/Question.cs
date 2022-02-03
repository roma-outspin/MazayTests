using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazayTests.Core.Model
{
    public class Question
    {
        public int GuidQuestion { get; set; }
        public string TextQuestion { get; set; }
        public List<string> TextAnswer { get; set; }
        public List<string> ImagesForAnswer { get; set; }
        public List<string> SoundForAnswer { get; set; }
        public List<string> RightAnswer { get; set; }
    }
}
