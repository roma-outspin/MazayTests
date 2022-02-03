using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazayTests.Core.Model
{
    public class Answer
    {
        public List<string> TextAnswer { get; set; }
        public bool AnswerStrictlyWithImage { get; set; }
        public bool AnswerStrictlyWithSound { get; set; }
    }
}
