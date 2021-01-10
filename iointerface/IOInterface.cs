using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

using simplegossip;


namespace iointerface
{

    public enum Commands : byte{

        GetVersion,
        UploadReceive

    }

    class Program
    {
        public static byte[] Base64Decode(string base64EncodedData) {
            return System.Convert.FromBase64String(base64EncodedData);
        }

        static void Main(string[] args)
        {
            byte[] ourID = Base64Decode(args[0]);
            RoutingEvents routingEvents = new RoutingEvents(ourID);

            TcpListener server=null;
            UInt32 maxMessageSize = 10 * 1000 * 100;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13010;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[maxMessageSize];
                String data = null;

                // Enter the listening loop.
                while(true)
                {
                    Console.WriteLine("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while((i = stream.Read(bytes, 0, bytes.Length))!=0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                        byte[] peerID = msg[..32];
                        Commands cmd = (Commands)msg[33];
                        byte[] msgContent = msg[34..];

                        switch(cmd){
                            case Commands.GetVersion:
                                msg = System.Text.Encoding.ASCII.GetBytes(routingEvents.GetAPIVersion().ToString());
                            break;
                            case Commands.UploadReceive:
                                Peer                                
                            break;
                        }

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}
