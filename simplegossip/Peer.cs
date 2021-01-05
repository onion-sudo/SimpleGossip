using System.Collections.Generic;
using System;

namespace simplegossip{

    public class Peer{

        public byte[] peerID;

        public uint numericID;

        public Peer(byte[] peerID){
            this.peerID = peerID;
            this.numericID = BitConverter.ToUInt32((byte[]) peerID, 0);
        }

        public List<byte[]> knownStoredMessages;

    }

}