namespace simplegossip{

    public class RoutingEvents{
        private ushort APIVersion = 1;
        private byte[] ourID;

        public RoutingEvents(byte[] ourID){
            if (ourID.Length != 32){
                throw new System.Exception("Invalid ID length");
            }
            this.ourID = ourID;
        }

        public ushort GetAPIVersion(){return APIVersion;}
        public byte[] getMyID(){return ourID;}

        public UploadReceiveResult UploadReceive(Peer fromPeer, byte[] checksumAndMessage){
            return UploadReceiveResult.Success;
        }

        //public byte[] listMessageChecksums(){return}

    }

}