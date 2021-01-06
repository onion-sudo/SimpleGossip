using System.Collections.Generic;
using System;

namespace simplegossip{

    public class Peer{

        public byte[] peerID;

        public uint numericID;

        public string transportAddress; // For convinence and laziness, simplegossip does not care about it

        public Peer(byte[] peerID, string hostnameOrIP){
            this.peerID = peerID;
            this.numericID = BitConverter.ToUInt32((byte[]) peerID, 0);
            this.transportAddress = hostnameOrIP;
        }

        // List of checksums
        public List<byte[]> knownStoredMessages;

    }

}