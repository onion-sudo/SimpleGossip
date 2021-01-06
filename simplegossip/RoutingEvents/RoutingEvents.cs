namespace simplegossip{

    public class RoutingEvents{
        private ushort APIVersion = 0;
        private byte[] ourID;

        StorageInterface storage;

        public RoutingEvents(byte[] ourID, StorageInterface storage){
            this.storage = storage;
        }

        public ushort GetAPIVersion(){return APIVersion;}
        public byte[] getMyID(){return ourID;}

        public UploadReceiveResult UploadReceive(Peer fromPeer, byte[] checksumAndMessage){
            return UploadReceiveResult.Success;
        }

        public byte[] listMessageChecksums(){return storage.getMessageChecksums();}

    }

}