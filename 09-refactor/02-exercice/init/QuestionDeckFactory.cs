using System.Collections.Generic;
using System.Linq;

namespace csharpcore
{
    public static class QuestionDeckFactory
    {
        public static LinkedList<string> Create(QuestionCategory category)
        {
            var question = category switch
            {
                QuestionCategory.Pop => "Pop",
                QuestionCategory.Rock => "Rock",
                QuestionCategory.Science => "Science",
                QuestionCategory.Sports => "Sport",
            };

            return new LinkedList<string>(Enumerable.Range(0, 50).Select(x => $"{question} question {x}"));
        }
    }
}