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
            Game aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            Random rand = new Random();

            do
            {
                var randomValue = rand.Next(5);

                aGame.roll(randomValue + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }
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
            
                aGame.add("Chet");
                aGame.add("Pat");
                aGame.add("Sue");
            
                do
                {
                    var randomValue = rand.Next(5);
                    aGame.roll(randomValue + 1);
            
                    randomValue = rand.Next(9);

                    if (randomValue == 7)
                    {
                        notAWinner = aGame.wrongAnswer();
                    }
                    else
                    {
                        notAWinner = aGame.wasCorrectlyAnswered();
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

