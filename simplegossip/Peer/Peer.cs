using System.Collections.Generic;
using System.Security.Cryptography;

using System;

namespace simplegossip{

    public class Peer{

        public byte[] peerID;

        public uint numericID;

        public Peer(byte[] peerID){
            this.peerID = peerID;
            this.numericID = BitConverter.ToUInt32((byte[]) peerID, 0);
        }

        public void addMessage(byte[] data){
            byte[] hash;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                hash = mySHA256.ComputeHash(data);
            }
            if (knownStoredMessages.Contains(hash)){
                throw new DuplicateMessageError();
            }
            knownStoredMessages.Add(hash);
        }

        public void TryAddMessage(byte[] data){
            try{
                addMessage(data);
            }
            catch(DuplicateMessageError){
                return;
            }
        }

        // List of checksums
        public List<byte[]> knownStoredMessages;

    }

}