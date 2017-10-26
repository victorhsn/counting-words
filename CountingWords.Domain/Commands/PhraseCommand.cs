using CountingWords.Shared.Commands;

namespace CountingWords.Domain.Commands
{
    /// <summary>
    /// Class responsible for define the strucure that came from client  (eg: JSON)
    /// </summary>
    public class PhraseCommand : ICommand
    {
        /// <summary>
        /// Property that came from client.
        /// </summary>
        public string Sentence { get; set; }
        /// <summary>
        /// Property that came from client
        /// </summary>
        public int[] Lengths { get; set; }
    }
}
