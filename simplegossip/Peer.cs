using System.Collections.Generic;
using System;

namespace simplegossip{

    public class Peer{

        public byte[] peerID;

        public int numericID;

        public Peer(byte[] peerID){
            this.peerID = peerID;
            this.numericID = BitConverter.ToInt32((byte[]) peerID, 0);
        }

        public List<byte[]> knownStoredMessages;

    }

}