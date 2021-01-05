using NUnit.Framework;
using System.Collections.Generic;
using simplegossip;
using System.Security.Cryptography;

namespace tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNormalEven()
        {
            var ourID = new byte[32];
            RandomNumberGenerator.Fill(ourID);
            Epidemic epidemic = new Epidemic(ourID);

            for(int i = 0; i < 100; i++){
                var arr = new byte[32];
                RandomNumberGenerator.Fill(arr);
                epidemic.peerList.Add(new Peer(arr));
            }


            epidemic.getXNearestPeers(3);
        }
    }
}