using System.Collections.Generic;

namespace CountingWords.Domain.Entities
{
    /// <summary>
    /// Class responsible to provide a structure for the Results 
    /// </summary>
    public sealed class Word
    {
        private readonly List<string> _words;

        #region Constructor
        /// <summary>
        /// The <see cref="Word"/> constructor needs receive one parameter with the Length of words when the object instance will be created.
        /// </summary>
        /// <param name="length"></param>
        public Word(int length)
        {
            _words = new List<string>();
            Length = length;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Length researching for the application from the <see cref="Phrase.Sentence"/>
        /// </summary>
        public int Length { get; private set; }
        /// <summary>
        /// The number of words that has in <see cref="Words"/>
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// List of words that were defined for <see cref="Phrase.Lengths"/> from <seealso cref="Phrase.Sentence"/>
        /// </summary>
        public IList<string> Words { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add the number of words there are with in <see cref="Words"/> at specific <seealso cref="Length"/>
        /// </summary>
        /// <param name="count"></param>
        public void AddCount(int count)
        {
            Count = count;
        }
        /// <summary>
        /// Add the word in <see cref="Words"/>
        /// </summary>
        /// <param name="word"></param>
        public void UpdateWords(string word)
        {
            _words.Add(word);
            Words = _words;
        }
        #endregion
    }
}
