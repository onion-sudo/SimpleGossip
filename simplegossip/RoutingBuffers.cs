using System.Collections.Generic;

namespace simplegossip{

    public interface RecieveHandler{

        void handleRecieve(Epidemic epidemic, Peer peer, byte[] message);
        void handleSend(Epidemic epidemic, Peer peer, byte[] message);

    }

    public class RoutingBuffer{

        RecieveHandler handler;
        public RoutingBuffer(RecieveHandler handler){
            this.handler = handler;
        }

    }

}