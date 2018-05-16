using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Milionaire
{
    public class Question 
    {
        public int Number=1;
        public string Content;
        public string AnswA;
        public string AnswB;
        public string AnswC;
        public string AnswD;
        public char Correct;
        public string answRead;
        public static int[] Rewards = new int[] { 0, 1000, 2000, 5000, 10000, 40000, 75000, 125000, 250000, 500000, 1000000 };
        
        public bool CheckPass(char answer)
        {
            if (answer == Correct) return true;
            return false;
        }

        public Question(int num)
        {
            this.Number = num + 1;
        }

        public Question(string content, string answA, string answB, string answC, string answD, char correct)
        {
            this.Content = content;
            this.AnswA = answA;
            this.AnswB = answB;
            this.AnswC = answC;
            this.AnswD = answD;
            this.Correct = correct;
        }

        public Question (int number, string content, string answA, string answB, string answC, string answD, char correct)
        {
            this.Number = number;
            this.Content = content;
            this.AnswA = answA;
            this.AnswB = answB;
            this.AnswC = answC;
            this.AnswD = answD;
            this.Correct = correct;
        }

        public static void ReadQuestion(string file, List<Question> tempQuest)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string wholeTxt = sr.ReadToEnd();
                string[] questPart = wholeTxt.Split(';');
                for (int i = 0; i < 10; i++)
                {
                    int index = i * 6;
                    try
                    {
                        tempQuest[i].Content = questPart[index];
                        tempQuest[i].AnswA = questPart[index + 1];
                        tempQuest[i].AnswB = questPart[index + 2];
                        tempQuest[i].AnswC = questPart[index + 3];
                        tempQuest[i].AnswD = questPart[index + 4];
                        tempQuest[i].Correct = Convert.ToChar(questPart[index + 5]);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine($"Wystąpił błąd. Nr kolejki: {i}, Indeks: {index}");
                    }

                }
            }
        }

        public void GreenAnswer(string answer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{this.Correct}) {answer}");
            Console.ResetColor();
        }

        public void DisplayQuestion(Player player)
        {
            Console.Clear();
            Console.WriteLine($"{this.Number}. {this.Content}");
            Console.WriteLine($"a) {this.AnswA}");
            Console.WriteLine($"b) {this.AnswB}");
            Console.WriteLine($"c) {this.AnswC}");
            Console.WriteLine($"d) {this.AnswD}");
            
            if (player.FriendCallCheck)
                Console.WriteLine("\nNaciśnij F, by zadzwonić do przyjaciela");

            if (player.AudienceCheck)
                Console.WriteLine("\nNaciśnij Q, by skorzystać z pomocy publiczności");

            if (player.FiftyCheck)
                Console.WriteLine("\nNaciśnij H, by skorzystać z \"pół na pół\"");

            Console.WriteLine("\nNaciśnij X, by zakończyć grę i zabrać swoje pieniądze.");
        }

        public void UrRight(Player p)
        {
            Console.Clear();

            Console.WriteLine($"{this.Number}. {this.Content}");

            if (this.Correct == 'a')
                this.GreenAnswer(AnswA);
            else
                Console.WriteLine($"a) {this.AnswA}");

            if (this.Correct == 'b')
                this.GreenAnswer(AnswB);
            else
                Console.WriteLine($"b) {this.AnswB}");

            if (this.Correct == 'c')
                this.GreenAnswer(AnswC);
            else
                Console.WriteLine($"c) {this.AnswC}");

            if (this.Correct == 'd')
                this.GreenAnswer(AnswD);
            else
                Console.WriteLine($"d) {this.AnswD}");


            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine($"\nGratulacje! To poprawna odpowiedź! \nZdobyłeś {p.Won}zł. Gwarantowane: {p.Earned}zł. (Naciśnij ENTER, by przejść dalej)");
            Console.ResetColor();
            Console.ReadLine();
        }

        public void UrWrong(char ans)
        {
            Console.Clear();

            Console.WriteLine($"{this.Number}. {this.Content}");

            if (this.Correct == 'a')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (ans == 'a')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine($"a) {this.AnswA}");
            Console.ResetColor();

            if (this.Correct == 'b')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (ans == 'b')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine($"b) {this.AnswB}");
            Console.ResetColor();

            if (this.Correct == 'c')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (ans == 'c')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine($"c) {this.AnswC}");
            Console.ResetColor();

            if (this.Correct == 'd')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (ans == 'd')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"d) {this.AnswD}");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPrzykro mi, to nie jest właściwa odpowiedź! Przegrywasz. (Naciśnij ENTER, aby zakończyć)");
            Console.ResetColor();
            Console.ReadLine();
        }

        public void Resign(Player p)
        {
            Console.Clear();

            Console.WriteLine($"{this.Number}. {this.Content}");

            if (this.Correct == 'a')
                this.GreenAnswer(AnswA);

            if (this.Correct == 'b')
                this.GreenAnswer(AnswB);

            if (this.Correct == 'c')
                this.GreenAnswer(AnswC);

            if (this.Correct == 'd')
                this.GreenAnswer(AnswD);

            Console.WriteLine($"\nKoniec gry! \nTwoja wygrana to {p.Won}zł. Gratulacje! (Naciśnij ENTER, by przejść dalej)");
            
            Console.ReadLine();
        }
    }
}
