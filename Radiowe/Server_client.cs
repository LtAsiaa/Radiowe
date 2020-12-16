using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

namespace Radiowe
{
    // webserver
    class SynchronousSocketListener 
    {
        // Incoming data from the client.  
        public static string data = null;
        public static WirelessNetwork network = new WirelessNetwork();

        public static void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            Random rng = new Random();

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    byte[] msg_ret;
                    string[] table = new string[7];
                    try
                    {
                        Console.WriteLine("my data: {0}", data);
                        data = data.Substring(0, data.Length - 5);
                        Console.WriteLine("my data: {0}", data);
                        table = SplitIncMSG(data);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    network.AddStationToSystem(new BaseStation(Int32.Parse(table[0]), Int32.Parse(table[1]), Double.Parse(table[2],System.Globalization.NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB")), Double.Parse(table[3], System.Globalization.NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB")), Int32.Parse(table[4]), Double.Parse(table[5], System.Globalization.NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB")), table[6]));
                    //if (rng.Next(0, 2) > 0)
                    //{
                        msg_ret = Encoding.ASCII.GetBytes("GOOD! <EOF>");
                    //}
                    //else
                    //{
                    //    msg_ret = Encoding.ASCII.GetBytes("BAD! <EOF>");
                    //}
                    // Show the data on the console.  
                    Console.WriteLine("Text received : {0}", data);

                    // Echo the data back to the client.  
                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static int Main(String[] args)
        {
            //string test = "10,15,3452.3,1,1,1,KeKko <EOF>";
            //test = test.Substring(0,test.Length - 5);
            //Console.WriteLine("test: {0}", test);
            //string[] table = SplitIncMSG(test);
            //Console.WriteLine("This is my string: {0}", test);
            
            //double test_double = Double.Parse(table[2],System.Globalization.NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"));
            //Console.WriteLine("echo: ", test_double);
            //Console.WriteLine("This is the result {0} {1} {2} {3} {4} {5} {6}", table[0], table[1], table[2], table[3], table[4], table[5], table[6]) ;

            StartListening();
            return 0;
        }

        //public bool AddBS(String[] args)
        //{
         //   return true;
        //}

        public static string[] SplitIncMSG(string inc)
        {
            string[] array = inc.Split(' ', ',');
            return array;
        } 
    }
    /*    class Server_client { 
     public static void Main()
     {
         string ip = "127.0.0.1";
         int port = 80;
         var server = new TcpListener(IPAddress.Parse(ip), port);

         server.Start();
         Console.WriteLine("Connected on {0}:{1}, waiting for connection...", ip, port);

         TcpClient client = server.AcceptTcpClient();
         Console.WriteLine("Client connected!");

         NetworkStream stream = client.GetStream();

         while (true)
         {
             while (!stream.DataAvailable);
             while (client.Available < 3);

             byte[] bytes = new byte[client.Available];
             stream.Read(bytes, 0, client.Available);
             string s = Encoding.UTF8.GetString(bytes);
             if (Regex.IsMatch(s, "^GET", RegexOptions.IgnoreCase))
             {
                 Console.WriteLine("===========HANDSHAKE from client =============\n{0}", s);
                 /*
                  * 1. Obtain the value of "Sec-WebSocet-Key" request header without any leading or trailing whitespace 
                  * 2. Concatenate it with "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
                  * 3. Compute SHA-1 and Base64 hash opf the new value
                  * 4. write the hash back as the value of "Sec-WebSocet-Accept" response header in an HTTP response

                 string swk = Regex.Match(s, "Sec-WebSocket-Key: (.*)").Groups[1].Value.Trim();
                 string swka = swk + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
                 byte[] swkaSha1 = System.Security.Cryptography.SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(swka));
                 string swkaSha1Base64 = Convert.ToBase64String(swkaSha1);

                 //HTTP/1.1 defines the sequence CR LF as the end-of-line marker
                 byte[] response = Encoding.UTF8.GetBytes(
                     "Http/1.1 101 Switching Protocols \r\n" +
                     "Connection: Upgrade\r\n" +
                     "Upgrade: websocket\r\n" +
                     "Sec-WebSocket-Accept: " + swkaSha1Base64 + "\r\n\r\n");

                 stream.Write(response, 0, response.Length);
             }
             else
             {
                 bool fin = (bytes[0] & 0b10000000) != 0;
                 bool mask = (bytes[1] & 0b10000000) != 0; // has to be always true

                 int opcode = bytes[0] & 0b00001111, // expecting 1 - text message
                     msglen = bytes[1] - 128, // & 0111 1111
                     offset = 2;

                 if (msglen == 126)
                 {
                     msglen = BitConverter.ToUInt16(new byte[] { bytes[3], bytes[2] }, 0);
                     offset = 4;
                 }

                 else if (msglen == 127)
                 {
                     //msglen = BitConverter.ToUInt64(new byte[] { bytes[5], bytes[4], bytes[3], bytes[2], bytes[9], bytes[8], bytes[7], bytes[6] }, 0);
                     //offset = 10;
                 }

                 if (msglen == 0)
                     Console.WriteLine("msglen == 0");
                 else if (mask)
                 {
                     byte[] decoded = new byte[msglen];
                     byte[] masks = new byte[4] { bytes[offset], bytes[offset + 1], bytes[offset + 2], bytes[offset + 3] };
                     offset += 4;

                     for (int i = 0; i < msglen; ++i)
                         decoded[i] = (byte)(bytes[offset + i] ^ masks[i % 4]);

                     string text = Encoding.UTF8.GetString(decoded);
                     //byte[] reply = Encoding.UTF8.GetBytes(text);

                     //stream.Write(reply,0,reply.Length);
                     Console.WriteLine("{0}", text);
                 }
                 else
                 {
                     Console.WriteLine("mask bit not set");
                 }
                 Console.WriteLine();
             }

         }
     }
    }
     */
 }
