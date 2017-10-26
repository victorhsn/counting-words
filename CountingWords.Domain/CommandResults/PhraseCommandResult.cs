using CountingWords.Domain.Entities;
using CountingWords.Shared.Commands;
using System.Collections.Generic;

namespace CountingWords.Domain.CommandResults
{
    /// <summary>
    /// Class responsible for create an structure to return as result
    /// </summary>
    public class PhraseCommandResult : ICommandResult
    {
        /// <summary>
        /// The constructor needs receive a list of <see cref="Word"/>
        /// </summary>
        /// <param name="words"></param>
        public PhraseCommandResult(IList<Word> words)
        {
            Results = words;
        }

        /// <summary>
        /// List of <see cref="Word"/>
        /// </summary>
        public IList<Word> Results { get; private set; }
    }
}
