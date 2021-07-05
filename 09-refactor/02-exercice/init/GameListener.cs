using System;

namespace csharpcore
{
    public class GameListener
    {
        public void Handle(object evt)
        {
            switch (evt)
            {
                case AnswerWasCorrect awc:
                    Console.WriteLine("Answer was correct!!!!");
                    break;
                case PlayerStatus ps:
                    Console.WriteLine($"{ps.Player} now has {ps.Purse} Gold Coins.");
                    break;
                case AnwserWasIncorrect awi:
                    Console.WriteLine("Question was incorrectly answered");
                    Console.WriteLine(awi.Player + " was sent to the penalty box");
                    break;
                case PlayerAdded pa:
                    Console.WriteLine(pa.Player + " was added");
                    Console.WriteLine("They are player number " + pa.TotalNumberOfPlayers);
                    break;
                case PlayerTurn pt:
                    Console.WriteLine(pt.Player + " is the current player");
                    Console.WriteLine("They have rolled a " + pt.Roll);
                    break;
                case PlayerAction pa:
                    Console.WriteLine(pa.Player
                                      + "'s new location is "
                                      + pa.Location);
                    Console.WriteLine("The category is " + pa.QuestionCategory);
                    Console.WriteLine(pa.Question);
                    break;
                case PlayerStayInPenaltyBox psi:
                    Console.WriteLine(psi.Player + " is not getting out of the penalty box");
                    break;
                default: break;
            }
        }
    }
}