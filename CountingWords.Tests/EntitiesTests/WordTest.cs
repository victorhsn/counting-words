using CountingWords.Domain.Entities;
using NUnit.Framework;

namespace CountingWords.Tests.EntitiesTests
{
    [TestFixture(Author = "Victor Hugo")]
    public class WordTest
    {
        [Test(Author = "Victor Hugo")]
        public void Length_Can_Not_To_Be_Zero()
        {
            var word = new Word(10);
            Assert.Greater(word.Length, 0);
        }

        [Test(Author = "Victor Hugo")]
        public void Count_Can_Be_Zero()
        {
            var word = new Word(10);
            word.AddCount(0);

            Assert.LessOrEqual(0, word.Count);
        }

        [Test(Author = "Victor Hugo")]
        public void Words_Can_Be_Empty()
        {
            var word = new Word(2);
            Assert.IsNull(word.Words);
        }

        [Test(Author = "Victor Hugo")]
        public void Must_Add_A_Value_At_Count_Property()
        {
            var word = new Word(8);
            word.AddCount(1);

            Assert.IsNotNull(word.Count);
        }

        [Test]
        public void Must_Add_A_Value_At_Words_Property()
        {
            var word = new Word(3);
            word.UpdateWords("luxoft");

            Assert.IsNotNull(word.Words);
        }
    }
}
