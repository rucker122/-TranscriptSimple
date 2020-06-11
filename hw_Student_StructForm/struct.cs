using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_Student_StructForm
{
    public struct Student
    {
        public string Name;
        public Subject[] subjects;
    }

    public class Subject
    {
        public string SubName { get; set; }
        public int Score { get; set; }
    }


    class Class1
    {
    }
}
