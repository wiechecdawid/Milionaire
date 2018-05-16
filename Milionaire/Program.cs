using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Milionaire
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Test");
            //Quiz.GetTheAQuestions();
            //Console.ReadLine();

            //Quiz.LoadTextQuiz(Player.PassName());
            Quiz.LoadDbQuiz(Player.PassName());
        }
    }
}
