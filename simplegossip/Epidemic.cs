using System;
using System.Collections.Generic;

namespace simplegossip{

    public class Epidemic{

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
            var usAsPeer = new Peer(personalID);
            if (! acceptLess && peerList.Count < x){
                throw new IndexOutOfRangeException("Not enough peers to satisfy request");
            }
            if (peerList.Count == 0){
                throw new IndexOutOfRangeException("Not enough peers to satisfy request");
            }


            // Return X peers "nearest" to personalID, by peer.personalID
            var peerListCopy = new List<Peer>(peerList.ToArray());

            peerListCopy.Sort((x, y) => Math.Abs(x.numericID - usAsPeer.numericID).CompareTo(Math.Abs(usAsPeer.numericID - y.numericID)));

            return peerListCopy.GetRange(0, x).ToArray();


        }

        }

    }