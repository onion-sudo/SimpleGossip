using System.Collections.Generic;

namespace simplegossip{

    public interface RecieveHandler{
        void handleRecieve(byte[] message);
        void handleSend(byte[] message);

    }

    public class RoutingBuffer{



    }

}