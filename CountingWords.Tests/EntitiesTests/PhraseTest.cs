using CountingWords.Domain.Entities;
using NUnit.Framework;

namespace CountingWords.Tests.EntitiesTests
{
    [TestFixture(Author = "Victor Hugo")]
    public class PhraseTest
    {

        [Test(Author = "Victor Hugo")]
        public void Sentence_And_Length_Must_Be_Informed()
        {
            var a = new Phrase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", new int[] { 9, 5, 10 });
            var b = new Phrase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", new int[] { 9, 5, 10 });

            Assert.AreEqual(a.Sentence, b.Sentence);
            Assert.AreEqual(a.Lengths, a.Lengths);
        }

        [Test(Author = "Victor Hugo")]
        public void Sentence_Must_Be_More_Than_Zero_Character()
        {
            var phrase = new Phrase("L", new int[] { 9, 5, 10 });
            Assert.AreEqual(1, phrase.Sentence.Length);
        }

        [Test(Author = "Victor Hugo")]
        public void Length_Must_Be_More_Than_Zero_Values()
        {
            var phrase = new Phrase("L", new int[] { 9, 5, 10 });
            Assert.AreEqual(3, phrase.Lengths.Length);
        }

        [Test(Author = "Victor Hugo")]
        public void Words_Must_have_At_Least_One_Value()
        {
            var word = new Word(10);

            var phrase = new Phrase("Lorem elit", new int[] { 1, 3, 6 });
            phrase.UpdateWords(word);

            Assert.AreEqual(1, phrase.Words.Count);
        }

        [Test(Author = "Victor Hugo")]
        public void ExistLengths_Must_Return_True()
        {
            var phrase = new Phrase("consectetur adipiscing elit", new int[] { 8, 7, 11 });
            var exists = phrase.ExistLengths(phrase.Lengths);

            Assert.IsTrue(exists);
        }

        [Test(Author = "Victor Hugo")]
        public void ExistLengths_Must_Return_False()
        {
            var phrase = new Phrase("Lorem ipsum dolor sit amet", new int[] { });

            Assert.IsFalse(phrase.ExistLengths(phrase.Lengths));
        }

        [Test(Author = "Victor Hugo")]
        public void VerifyLength_Must_Return_True()
        {
            var word = new Word(10);

            var phrase = new Phrase("Lorem ipsum", new int[] { 1, 3, 10, 6, 2, 6 });
            phrase.UpdateWords(word);

            Assert.IsTrue(phrase.VerifyLength(10));
        }

        [Test(Author = "Victor Hugo")]
        public void VerifyLength_Must_Return_False()
        {
            var word = new Word(5);

            var phrase = new Phrase("Lorem ipsum", new int[] { 3, 8 });
            phrase.UpdateWords(word);

            Assert.False(phrase.VerifyLength(10));
        }
    }
}
