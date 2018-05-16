using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionaire
{
    public class Player
    {
        public string Name { get; }
        public bool FiftyCheck { get; private set; }
        public bool FriendCallCheck { get; private set; }
        public bool AudienceCheck { get; private set; }
        public int Won { get; private set; }
        public int Earned { get; private set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TotalTime { get; private set; }

        public Player(string name)
        {
            this.Name = name;
            this.FiftyCheck = true;
            this.FriendCallCheck = true;
            this.AudienceCheck = true;
            this.Won = Question.Rewards[0];
            this.Earned = 0;
        }

        public void GameLength()
        {
            this.TotalTime = this.EndTime - this.StartTime;
        }
        
        public char Answer()
        {
            char answer = Char.ToLower(Console.ReadKey().KeyChar);
            return answer;
        }

        public static string PassName()
        {
            Console.Write("Witaj w grze \"Milionerzy\"! Podaj imię, aby rozpocząć grę: ");
            return Console.ReadLine();
        }

        public void MoneyRain(int i)
        {
            this.Won = Question.Rewards[i + 1];
            if (i == 1 || i == 3 || i==5 || i==9)
            {
                this.Earned = this.Won;
            }
        }

        public void FiftyFifty(Question question)
        {
            if (FiftyCheck)
            {
                Random rand = new Random();
                //TODO: arr - it is argument, or shortcut for array
                //TODO: Please change the name of variable. The name of variable should tell what this variable do. For example: index - questionIdThatRemain
                int[] arr;
                int index = 0;
                //TODO: Dont repet yourself and please try refactor this code 
                if (question.Correct == 'a')
                {
                    arr = new int[] { 1, 2, 3 };
                    index = arr[rand.Next(0, arr.Length)];
                }
                if (question.Correct == 'b')
                {
                    arr = new int[] { 0, 2, 3 };
                    index = arr[rand.Next(0, arr.Length)];
                }
                if (question.Correct == 'c')
                {
                    arr = new int[] { 0, 1, 3 };
                    index = arr[rand.Next(0, arr.Length)];
                }
                if (question.Correct == 'd')
                {
                    arr = new int[] { 0, 1, 2 };
                    index = arr[rand.Next(0, arr.Length)];
                }

                Console.Clear();
                Console.WriteLine("Komputer wylosował dla Ciebie dwie możliwe odpowiedzi! Oto one: \n");
                Console.WriteLine($"{question.Number}. {question.Content}");
                if (question.Correct == 'a' || index == 0)
                    Console.WriteLine($"a) {question.AnswA}");
                else
                    Console.WriteLine($"a) ");
                if (question.Correct == 'b' || index == 1)
                    Console.WriteLine($"b) {question.AnswB}");
                else
                    Console.WriteLine($"b) ");
                if (question.Correct == 'c' || index == 2)
                    Console.WriteLine($"c) {question.AnswC}");
                else
                    Console.WriteLine($"c) ");
                if (question.Correct == 'd' || index == 3)
                    Console.WriteLine($"d) {question.AnswD}");
                else
                    Console.WriteLine($"d) ");
                //TODO: if you make a space, you will read better this code 
                if (this.FriendCallCheck)
                    Console.WriteLine("\nNaciśnij F, by zadzwonić do przyjaciela");

                if (this.AudienceCheck)
                    Console.WriteLine("\nNaciśnij Q, by skorzystać z pomocy publiczności");
                if (this.FiftyCheck)
                    Console.WriteLine("\nNaciśnij H, by skorzystać z \"pół na pół\"");
            }
            else
                Console.WriteLine("\nWykorzystałeś już pół na pół."); //TODO: if you make a space, you will read better this code 

            this.FiftyCheck = false;
        }

        public void FriendCall(Question question)
        {
            Console.WriteLine();
            if (this.FriendCallCheck)
            {
                char hint = Char.ToUpper(question.Correct);
                Console.WriteLine("\nWydaje mi się, że poprawna odpowiedź to {0}.", hint);
                Console.WriteLine("Ostatnie słowo wciąż należy do Ciebie! Którą odpowiedź wybierasz?");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Wykorzystałeś już telefon do przyjaciela.");
            }

            this.FriendCallCheck = false;
        }

        public void AskAudience(Question question)
        {
            if (this.AudienceCheck)
            {
                int percA = 0;
                int percB = 0;
                int percC = 0;
                int percD = 0;
                int overall = 100;
                Random rand = new Random();

                switch (question.Correct)
                {
                    case 'a':
                        //TODO: Don't repet yourself 
                        percA = rand.Next(30, 40);
                        percB = rand.Next(20, 28);
                        percC = rand.Next(20, 28);
                        percD = overall - (percA + percB + percC);
                        break;

                    case 'b':
                        //TODO: Don't repet yourself 
                        percB = rand.Next(30, 40);
                        percA = rand.Next(20, 28);
                        percC = rand.Next(20, 28);
                        percD = overall - (percA + percB + percC);
                        break;

                    case 'c':
                        percC = rand.Next(30, 40);
                        percB = rand.Next(20, 28);
                        percD = rand.Next(20, 28);
                        percA = overall - (percD + percB + percC);
                        break;

                    default:
                        percD = rand.Next(30, 40);
                        percB = rand.Next(20, 28);
                        percC = rand.Next(20, 28);
                        percA = overall - (percD + percB + percC);
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Oto wyniki sondy: ");
                Console.WriteLine($"A: {percA}% \nB: {percB}% \nC: {percC}% \nD: {percD}%");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Wykorzystałeś już pomoc publiczności.");
            }

            this.AudienceCheck = false;

        }
    }
}
