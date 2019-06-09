
namespace Auden.Excercise.Common
{
    using NUnit.Framework;


    public class Assertions
    {

        /// <summary>
        /// Asserts the fail.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void AssertFail(string errorMessage)
        {
            Assert.Fail(errorMessage);
        }
    }
}
