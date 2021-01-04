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

        public Peer[] getXNearestPeers(int x){
            ulong counter = 0;
            foreach(Peer peer in peerList){
                
            }
        }

        }

    }

}