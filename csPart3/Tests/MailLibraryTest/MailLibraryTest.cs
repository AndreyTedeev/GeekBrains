using MailLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace MailLibraryTest
{
    [TestClass]
    public class MailLibraryTest
    {

        private string INPUT_STRING;

        [TestInitialize]
        public void Init() {
#if DEBUG
            Debug.WriteLine("Init");
#endif
            INPUT_STRING = "Test Input";
        }

        [TestCleanup]
        public void CleanUp() 
        {
#if DEBUG
            Debug.WriteLine("Clenup");
#endif
        }

        [TestMethod]
        public void CryptoTest()
        {
#if DEBUG
            Debug.WriteLine("CryptoTest");
#endif
            Assert.AreEqual(
                INPUT_STRING, 
                Crypto.Decode( Crypto.Encode(INPUT_STRING) ),
                "Crypto is failed.");
            StringAssert.Equals(
                INPUT_STRING,
                Crypto.Decode(Crypto.Encode(INPUT_STRING)));
        }
    }
}
