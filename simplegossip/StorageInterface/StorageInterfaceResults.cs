namespace simplegossip{

    public enum DoStoreResult : ushort{
        Success,
        FormatError,
        Failure
    }
    public enum DoStorePeerResult : ushort{

        Success,
        LogicRejected,
        Failure

    }

}