using NUnit.Framework;
using System;
using simplegossip;
using System.Security.Cryptography;
using System.Collections.Generic;

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
            var nID = BitConverter.ToUInt32((byte[]) ourID, 0);

            for(int i = 0; i < 10; i++){
                var arr = new byte[32];
                RandomNumberGenerator.Fill(arr);
                epidemic.peerList.Add(new Peer(arr));
            }



            var nearest = epidemic.getXNearestPeers(3);

            var listCopy = new List<Peer>(epidemic.peerList.ToArray());

            listCopy.Sort((x, y) => Math.Abs(x.numericID - nID).CompareTo(Math.Abs(nID - y.numericID)));

            Assert.IsTrue(nearest.Length == 3);

            for (int i = 0; i < nearest.Length; i++){
                if (! listCopy[i].Equals(nearest[i])){
                    throw new Exception("Not nearest");
                }
            }

        }
    }
}