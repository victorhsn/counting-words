using CountingWords.Shared.FluentValidator;
using System.Collections.Generic;

namespace CountingWords.Domain.Entities
{
    /// <summary>
    ///  This class contains properties about the sentence that came from client.
    /// </summary>
    public sealed class Phrase : Notifiable
    {
        private readonly IList<Word> _words;

        #region Constructor
        /// <summary>
        /// The <see cref="Phrase"/> constructor needs receive two parameters when the object instance will be created.
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="lengths"></param>
        public Phrase(string sentence, int[] lengths)
        {
            _words = new List<Word>();

            Sentence = sentence;
            Lengths = lengths;

            if (!ExistLengths(Lengths))
                AddNotification("Lengths", "The field lengths does not have any value");

            new ValidationContract<Phrase>(this)
                .IsRequired(x => x.Sentence, "You must fill the sentence")
                .HasMinLenght(x => x.Sentence, 1, "The sentence does not have character!");

        }
        #endregion

        #region Properties
        /// <summary>
        /// Property responsible to receive a sentence from client.
        /// </summary>
        /// 
        public string Sentence { get; private set; }
        /// <summary>
        /// Property responsible to receive the lengths from client. 
        /// </summary>
        public int[] Lengths { get; private set; }
        /// <summary>
        /// Property responsible to create a collection of objects as <seealso cref="Word"/>
        /// </summary>
        public IList<Word> Words { get; private set; }
        #endregion


        #region Methods
        /// <summary>
        /// Verify if the <see cref="Lengths"/> has values.
        /// </summary>
        /// <param name="lengths"></param>
        /// <returns></returns>
        public bool ExistLengths(int[] lengths)
        {
            if (lengths.Length > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Add an object of type <seealso cref="Word"/> in the <see cref="Words"/>
        /// </summary>
        /// <param name="word"></param>
        public void UpdateWords(Word word)
        {
            _words.Add(word);
            Words = _words;
        }
        /// <summary>
        ///  Verify the word exists on <see cref="Words"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// If the value exist, return true
        /// If the value does not exists, Return false
        /// </returns>
        public bool VerifyLength(int value)
        {
            var exist = false;

            for (int i = 0; i < _words.Count; i++)
            {
                if (_words[i].Length == value)
                    exist = true;
            }

            return exist;
        }
        #endregion
    }
}
