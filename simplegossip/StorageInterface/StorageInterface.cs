namespace simplegossip{

    public interface StorageInterface{

        byte[] getMessageChecksums();
        // Checksum might not be what the application considers, so we need to mark it
        // because its how we get it later in getMessage
        DoStoreResult doStore(byte[] checksum);
        DoStorePeerResult doStorePeer(Peer peer);
        byte[] getMessage(byte[] checksum);
        
        

    }

}