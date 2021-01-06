namespace simplegossip{

    public enum UploadReceiveResult : ushort{
        Success,
        InvalidChecksum,
        InvalidLength
    }

}