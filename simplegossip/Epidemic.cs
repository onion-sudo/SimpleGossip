using System;
using System.Collections.Generic;

namespace simplegossip{

    public class Epidemic{

        private float percentSpread;
        private byte[] personalID;

        private static float spreadToNearestPercent = 0.1f;

        public List<Peer> peerList;

        public Epidemic(byte[] ourID){
            personalID = ourID;
            peerList = new List<Peer>();
        }
        public Epidemic(byte[] ourID, Peer[] peerArray){
            personalID = ourID;
            peerList = new List<Peer>(peerArray);
        }

        public void sortPeerListInPlace(){
            peerList.Sort((x, y) => y.numericID.CompareTo(x.numericID));
        }

        public Peer[] getXNearestPeers(int x, bool acceptLess=true){
            var closest = new Peer[x];
            if (! acceptLess && peerList.Count < x){
                throw new IndexOutOfRangeException("Not enough peers to satisfy request");
            }
            if (peerList.Count == 0){
                throw new IndexOutOfRangeException("Not enough peers to satisfy request");
            }

            // Return X peers "nearest" to personalID, by peer.personalID
            var peerListCopy = new List<Peer>(peerList.ToArray());
            var usAsPeer = new Peer(personalID);
            peerListCopy.Add(usAsPeer);
            peerListCopy.Sort((x, y) => y.numericID.CompareTo(x.numericID));

            var half = (peerListCopy.Count - 1) / 2;
            var ourPos = peerListCopy.IndexOf(usAsPeer);
            var startPos = ourPos - half;
            while (startPos < 0){
                startPos += 1;
            }
            int counter = 0;
            while(closest[x - 1] is null){
                closest[counter] = peerListCopy[startPos + counter];
                counter += 1;
            }
            return closest;

        }

        }

    }