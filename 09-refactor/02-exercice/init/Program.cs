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
    }    
}

