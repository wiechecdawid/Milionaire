using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using WMPLib;

namespace Milionaire
{
    public static class Quiz
    {
        
        public static void LetsPlay()
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer
            {   
                URL = @"Data\sounds\letsplay.mp3"
            };
            player.controls.play();
        }

        public static void Good()
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            
            player.URL = @"Data\sounds\correctanswer.mp3";
            player.controls.play();
        }
     
        public static void Bad()
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            
            player.URL = @"Data\sounds\wronganswer.mp3";
            player.controls.play();
        }



        public static void GameLogic(Player player, List<Question> questions)
        {
            Console.WriteLine($"Miło Cię poznać, {player.Name}! Grasz o milion złotych! Naciśnij ENTER, by rozpocząć!");
            Console.ReadLine();
            player.StartTime = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                LetsPlay();
                questions[i].DisplayQuestion(player);
                char ans = player.Answer();
                switch (ans)
                {
                    case 'a':
                        break;
                    case 'b':
                        break;
                    case 'c':
                        break;
                    case 'd':
                        break;

                    case 'h':
                        player.FiftyFifty(questions[i]);
                        ans = player.Answer();
                        if (ans == 'f')
                            player.FriendCall(questions[i]);
                        else if (ans == 'q')
                            player.AskAudience(questions[i]);
                        break;

                    case 'f':
                        player.FriendCall(questions[i]);
                        ans = player.Answer();
                        if (ans == 'h')
                            player.FiftyFifty(questions[i]);
                        else if (ans == 'q')
                            player.AskAudience(questions[i]);
                        break;

                    case 'q':
                        player.AskAudience(questions[i]);
                        ans = player.Answer();
                        if (ans == 'f')
                            player.FriendCall(questions[i]);
                        else if (ans == 'h')
                            player.FiftyFifty(questions[i]);
                        break;

                    case 'x':
                        questions[i].Resign(player);
                        break;


                    default:
                        Console.WriteLine("Nieobsługiwany przycisk. Spróbuj jeszcze raz: ");
                        ans = player.Answer();
                        break;
                }

                if (ans == 'x')
                    break;

                if (!questions[i].CheckPass(ans))
                {
                    player.EndTime = DateTime.Now;
                    player.GameLength();
                    SaveScore(player);
                    Bad();
                    questions[i].UrWrong(ans);
                    Console.WriteLine($"Wygrałeś {player.Earned}, Czas gry: {player.TotalTime}");
                    Console.ReadLine();
                    break;
                }

                Good();
                player.MoneyRain(i);
                questions[i].UrRight(player);

                if (i == 9)
                {
                    player.EndTime = DateTime.Now;
                    player.GameLength();
                    SaveScore(player);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Gratulacje, {player.Name}! Wygrałeś {player.Earned} złotych!!!");
                    Console.ReadLine();
                }

            }
        }

        public static void LoadDbQuiz(string nick)
        {
            Player player = new Player(nick);
            List<DAL.Entity.Question> tempQuest = new List<DAL.Entity.Question>();
            tempQuest = DAL.Repository.QuestionRepository.ListConvert();
            List<Question> quizQuestions = new List<Question>();

            foreach(DAL.Entity.Question temp in tempQuest)
            {
                quizQuestions.Add(new Question(temp.Id-1)
                {
                    Number = temp.Id,
                    Content = temp.QuestContent,
                    AnswA = temp.AnswerA,
                    AnswB = temp.AnswerB,
                    AnswC = temp.AnswerC,
                    AnswD = temp.AnswerD,
                    Correct = Convert.ToChar(temp.Correct)
                });
            }

            GameLogic(player, quizQuestions);
        }        
         
        public static void LoadTextQuiz(string nick)
        {
            Player player = new Player(nick);
            List<Question> quizQuestions = new List<Question>();
            for(int i =0; i<10; i++)
            {
                quizQuestions.Add(new Question(i));
            }
            
            string rFile = @"Data\quiz.txt";  

            Question.ReadQuestion(rFile, quizQuestions);

            GameLogic(player, quizQuestions);

        }

        public static void SaveScore(Player tempPlayer)
        {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = @"Server=DESKTOP-H7F2SB6;Database=Score;Integrated Security=True;";
            connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = String.Format($"INSERT INTO TheScore (Name, Reward) " +
                    $"VALUES ('{tempPlayer.Name}', '{tempPlayer.Earned}')");
                command.ExecuteNonQuery();
            connection.Close();
        }

        public static void GetTheAQuestions()
        {
            string cString = @"Server=DESKTOP-H7F2SB6;Database=Milions;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(cString);
            connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spGetTheAQuestions";
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                    while(reader.Read())
                    {
                        Console.WriteLine(string.Format("{0}. {1} \n a) {2} \n b) {3} \n c) {4} \n d) {5} \n",
                            reader["Id"],
                            reader["QuestContent"],
                            reader["AnswerA"],
                            reader["AnswerB"],
                            reader["AnswerC"],
                            reader["AnswerD"]));
                    }
                reader.Close();
            connection.Close();
        }
    }
}
