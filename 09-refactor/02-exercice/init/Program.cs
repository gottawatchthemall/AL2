using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace csharpcore
{
    public class Program
    {
        private static bool notAWinner;

        public static void Run(string[] args)
        {
            var questionDecks = new Dictionary<QuestionCategory, LinkedList<string>>
            {
                {QuestionCategory.Pop, QuestionDeckFactory.Create(QuestionCategory.Pop)},
                {QuestionCategory.Rock, QuestionDeckFactory.Create(QuestionCategory.Rock)},
                {QuestionCategory.Science, QuestionDeckFactory.Create(QuestionCategory.Science)},
                {QuestionCategory.Sports, QuestionDeckFactory.Create(QuestionCategory.Sports)},
            };
            
            var aGame = new Game(questionDecks);
            
            aGame.Publish += new GameListener().Handle;

            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");

            Random rand = new Random();

            do
            {
                var randomValue = rand.Next(5);

                aGame.Roll(randomValue + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = aGame.WrongAnswer();
                }
                else
                {
                    notAWinner = aGame.WasCorrectlyAnswered();
                }
                
                aGame.NextPlayer();

            } while (notAWinner);
        }

        [Fact]
        public void CheckNoRegression()
        {
            var randomValues = File.ReadLines("./randomAL2.txt").Select(int.Parse).ToList();
            var expectedOutput = File.ReadLines("./outputAL2.txt").ToList();
            
            //Random rand = new Random(); Utiliser randomValues a la place
            
            for (int cpt = 0; cpt < 10; cpt++)
            {
                Game aGame = new Game();
            
                aGame.AddPlayer("Chet");
                aGame.AddPlayer("Pat");
                aGame.AddPlayer("Sue");
            
                do
                {
                    var randomValue = rand.Next(5);
                    aGame.Roll(randomValue + 1);
            
                    randomValue = rand.Next(9);

                    if (randomValue == 7)
                    {
                        notAWinner = aGame.WrongAnswer();
                    }
                    else
                    {
                        notAWinner = aGame.WasCorrectlyAnswered();
                    }
                } while (notAWinner);
            }
            
            //Asserter que Game.output est toujours egal a expectedOutput
        }
        
        // [Fact]        
        // public void GenerateGoldenMaster()
        // {           
        //     Random rand = new Random();
        //
        //     for (int cpt = 0; cpt < 10; cpt++)
        //     {
        //         Game aGame = new Game();
        //
        //         aGame.add("Chet");
        //         aGame.add("Pat");
        //         aGame.add("Sue");
        //
        //         do
        //         {
        //             var randomValue = rand.Next(5);
        //             File.AppendAllLines("/tmp/randomAL2.txt", new []{ randomValue.ToString() });
        //             
        //             aGame.roll(randomValue + 1);
        //
        //             randomValue = rand.Next(9);
        //             File.AppendAllLines("/tmp/randomAL2.txt", new []{ randomValue.ToString() });
        //
        //             if (randomValue == 7)
        //             {
        //                 notAWinner = aGame.wrongAnswer();
        //             }
        //             else
        //             {
        //                 notAWinner = aGame.wasCorrectlyAnswered();
        //             }
        //         } while (notAWinner);
        //     }
        //
        //     File.AppendAllLines("/tmp/outputAL2.txt", Game.output);
        // }
    }    
}

