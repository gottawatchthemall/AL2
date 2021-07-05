namespace csharpcore
{
    public record PlayerStayInPenaltyBox(string Player);

    public record AnswerWasCorrect();

    public record PlayerStatus(string Player, int Purse);

    public record AnwserWasIncorrect(string Player);

    public record PlayerAdded(string Player, int TotalNumberOfPlayers);

    public record PlayerTurn(string Player, int Roll);

    public record PlayerAction(string Player, int Location, QuestionCategory QuestionCategory, string Question);
}