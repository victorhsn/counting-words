using CountingWords.Domain.CommandResults;
using CountingWords.Domain.Commands;
using CountingWords.Domain.Entities;
using CountingWords.Log.Logging;
using CountingWords.Shared.Commands;
using CountingWords.Shared.FluentValidator;
using CountingWords.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingWords.Domain.CommandHandlers
{
    /// <summary>
    /// Class responsible to receive an object of type <see cref="PhraseCommand"/> from the client.
    /// </summary>
    public class PhraseCommandHandler : Notifiable, ICommandHandler<PhraseCommand>
    {
        private readonly IDictionary<string, int> _wordsAndLengths;
        private readonly IList<int> _notHaveWords;

        public PhraseCommandHandler()
        {
            _wordsAndLengths = new Dictionary<string, int>();
            _notHaveWords = new List<int>();
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

            TakingWordsLengths(lengths, words);
            MountStructure(phrase);
            NotHaveWords(lengths, phrase);

            return new PhraseCommandResult(phrase.Words);
        }

        private void TakingWordsLengths(IEnumerable<int> lengths, IEnumerable<string> words)
        {
            foreach (var len in lengths)
            {
                foreach (var ws in words)
                {
                    if (len == ws.Length)
                        _wordsAndLengths.Add(ws, len);
                }
            }
        }

        private void MountStructure(Phrase phrase)
        {
            foreach (var w in _wordsAndLengths)
            {
                var count = 0;

                if (phrase.VerifyLength(w.Value)) continue;

                var word = new Word(w.Key.Length);

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
        }

        private void NotHaveWords(IEnumerable<int> lengths, Phrase phrase)
        {

            foreach (var item in lengths)
            {
                try
                {
                    if (!phrase.Words.Any(x => x.Length.Equals(item)))
                    {
                        var word = new Word(item);
                        word.AddCount(0);
                        word.UpdateWords(string.Empty);
                        phrase.UpdateWords(word);
                    }
                }
                catch (Exception)
                {

                    var word = new Word(item);
                    word.AddCount(0);
                    word.UpdateWords(string.Empty);
                    phrase.UpdateWords(word);
                }        
            }
        }
    }
}
