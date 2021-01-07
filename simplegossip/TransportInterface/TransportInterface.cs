namespace simplegossip{

    public interface TransportInterface{

        TransportInterfaceSendMessageResult transportSendMessage(Peer toPeer, byte[] message);
        ushort transportGetPeerAPIVersion(Peer peer);
        byte[] transportGetMessageList(Peer peer);

    }

}