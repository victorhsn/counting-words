using CountingWords.Domain.CommandResults;
using CountingWords.Domain.Commands;
using CountingWords.Domain.Entities;
using CountingWords.Log.Logging;
using CountingWords.Shared.Commands;
using CountingWords.Shared.FluentValidator;
using CountingWords.Shared.Util;
using System.Collections.Generic;

namespace CountingWords.Domain.CommandHandlers
{
    /// <summary>
    /// Class responsible to receive an object of type <see cref="PhraseCommand"/> from the client.
    /// </summary>
    public class PhraseCommandHandler : Notifiable, ICommandHandler<PhraseCommand>
    {
        private readonly IDictionary<string, int> _wordsAndLengths;

        public PhraseCommandHandler()
        {
            _wordsAndLengths = new Dictionary<string, int>();
        }

        /// <summary>
        /// Receive an object of type <see cref="PhraseCommand"/>
        /// </summary>
        /// <param name="command"></param>
        /// <returns>
        /// <see cref="PhraseCommandResult"/>
        /// </returns>
        public ICommandResult Handle(PhraseCommand command)
        {

            var phrase = new Phrase(command.Sentence, command.Lengths);

            AddNotifications(phrase.Notifications);

            if (!IsValid())
            {
                Logging.LogError(GetType(), phrase.Notifications);
                return null;
            }

            var words = phrase.Sentence.CompareStrings();
            var lengths = phrase.Lengths.DeleteDuplicateNumbers();

            foreach (var len in lengths)
            {
                foreach (var word in words)
                {
                    if (len == word.Length)
                        _wordsAndLengths.Add(word, len);
                }
            }

            foreach (var w in _wordsAndLengths)
            {
                var count = 0;

                if (phrase.VerifyLength(w.Value)) continue;

                Word word = new Word(w.Key.Length);

                foreach (var b in _wordsAndLengths)
                {
                    if (w.Key.Length == b.Key.Length)
                    {
                        count++;
                        word.UpdateWords(b.Key);
                    }
                }

                word.AddCount(count);
                phrase.UpdateWords(word);
            }

            return new PhraseCommandResult(phrase.Words);
        }
    }
}
