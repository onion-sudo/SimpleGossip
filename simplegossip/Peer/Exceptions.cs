using System;

namespace simplegossip{

[Serializable]
public class DuplicateMessageError : Exception
{
    public DuplicateMessageError() : base() { }
    public DuplicateMessageError(string message) : base(message) { }
    public DuplicateMessageError(string message, Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an
    // exception propagates from a remoting server to the client.
    protected DuplicateMessageError(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

}
