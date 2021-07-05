using System;
using System.Collections.Generic;
using System.Linq;

namespace csharpcore
{
    public class Game
    {
        public event Action<object> Publish;

        private Dictionary<int, QuestionCategory> categories = new Dictionary<int, QuestionCategory>
        {
            {0, QuestionCategory.Pop},
            {4, QuestionCategory.Pop},
            {8, QuestionCategory.Pop},
            {1, QuestionCategory.Science},
            {5, QuestionCategory.Science},
            {9, QuestionCategory.Science},
            {2, QuestionCategory.Sports},
            {6, QuestionCategory.Sports},
            {10, QuestionCategory.Sports},
        };

        private readonly Dictionary<QuestionCategory, LinkedList<string>> _questionDecks;
        private readonly List<Player> _players;

        int currentPlayer = 0;
        
        public Game(Dictionary<QuestionCategory, LinkedList<string>> questionDecks)
        {
            _questionDecks = questionDecks;
            _players = new List<Player>();
        }

        public void AddPlayer(string playerName)
        {
            _players.Add(new Player(playerName));

            Publish?.Invoke(new PlayerAdded(playerName, _players.Count));
        }

        private Player CurrentPlayer => _players[currentPlayer];

        public void Roll(int roll)
        {
            Publish?.Invoke(new PlayerTurn(CurrentPlayer.Name, roll));

            if (CurrentPlayer.IsInPenaltyBox && roll % 2 == 0)
            {
                Publish?.Invoke(new PlayerStayInPenaltyBox(CurrentPlayer.Name));
                return;
            }

            if (CurrentPlayer.IsInPenaltyBox && roll % 2 != 0)
                CurrentPlayer.ReleaseFromPenaltyBox();

            CurrentPlayer.Move(roll);
 
            var question = AskQuestion();

            Publish?.Invoke(new PlayerAction(CurrentPlayer.Name,  CurrentPlayer.Place, CurrentCategory(), question));
        }

        private string AskQuestion()
        {
            var currentQuestions = _questionDecks[CurrentCategory()];
            var currentQuestion = currentQuestions.First();

            currentQuestions.RemoveFirst();

            return currentQuestion;
        }
        
        public bool WasCorrectlyAnswered()
        {
            if (CurrentPlayer.IsInPenaltyBox)
                return true;

            Publish?.Invoke(new AnswerWasCorrect());

            CurrentPlayer.IncrementPurse();

            Publish?.Invoke(new PlayerStatus(CurrentPlayer.Name, CurrentPlayer.Purse));

            return DidPlayerWin();
        }
        
        public bool WrongAnswer()
        {
            Publish?.Invoke(new AnwserWasIncorrect(CurrentPlayer.Name));
            CurrentPlayer.SetInInPenaltyBox();
            return true;
        }

        public void NextPlayer()
        {
            currentPlayer++;
            if (currentPlayer == _players.Count) currentPlayer = 0;
        }
        
        private QuestionCategory CurrentCategory()
        {
            if (categories.ContainsKey(CurrentPlayer.Place))
                return categories[CurrentPlayer.Place];

            return QuestionCategory.Rock;
        }
        
        private bool DidPlayerWin()
        {
            return CurrentPlayer.Purse != 6;
        }
    }

}