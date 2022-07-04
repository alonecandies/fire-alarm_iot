//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;
//using System.Collections.Generic;

//namespace System.Mvc.Api
//{
//    //public class Response
//    //{
//    //    public int Code { get; set; }
//    //    public string Message { get; set; }
//    //    public object Value { get; set; }
//    //}

//    public class StateObject
//    {
//        // Client  socket.  
//        public Socket workSocket = null;
//        // Size of receive buffer.  
//        public const int BufferSize = 1024;
//        // Receive buffer.  
//        public byte[] buffer = new byte[BufferSize];

//        List<byte[]> _data = new List<byte[]>();

//        public const string EOF = "<EOF>";
//        public string GetMessage()
//        {
//            for (int i = 0; i < BufferSize; i++)
//            {
//                int j = 0;
//                for (int k = i; k < BufferSize && j < EOF.Length; k++)
//                {
//                    if (buffer[k] != EOF[j++]) { break; }
//                }

//                if (j >= EOF.Length)
//                {
//                    Join(i);
//                    return GetUTF8String();
//                }
//            }

//            Join(BufferSize);

//            return null;
//        }

//        public void Join(int bytes)
//        {
//            var v = new byte[bytes];
//            for (int i = 0; i < bytes; i++) { v[i] = buffer[i]; }

//            _data.Add(v);
//        }
//        public string GetUTF8String()
//        {
//            int n = 0;
//            foreach (var arr in _data) { n += arr.Length; }

//            var v = new byte[n];
//            int i = 0;
//            foreach (var arr in _data)
//            {
//                arr.CopyTo(v, i);
//                i += arr.Length;
//            }
//            return Encoding.UTF8.GetString(v);
//        }
//    }

//    public class ApiBase
//    {
//        public T Deserialize<T>(object value) where T: new()
//        {
//            var model = new T();
//            var src = (Newtonsoft.Json.Linq.JObject)value;

//            foreach (var p in typeof(T).GetProperties())
//            {
//                if (p.CanWrite)
//                {
//                    var token = src.SelectToken(p.Name);
//                    if (token != null)
//                    {
//                        p.SetValue(model, token.ToObject(p.PropertyType));
//                    }
//                }
//            }

//            return model;
//        }
//    }

//    public class Client : ApiBase
//    {
//        private static ManualResetEvent connectDone =
//            new ManualResetEvent(false);
//        private static ManualResetEvent sendDone =
//            new ManualResetEvent(false);
//        private static ManualResetEvent receiveDone =
//            new ManualResetEvent(false);

//        public string ServerIp { get; set; }
//        public int ServerPort { get; set; }

//        IPAddress _ipAddress;
//        IPEndPoint _remoteEP;

//        public Action<string> ResponseCallBack;

//        public Client(string ip, int port)
//        {
//            ServerIp = ip;
//            ServerPort = port;

//            IPHostEntry ipHostInfo = Dns.GetHostEntry(ip);
//            _ipAddress = ipHostInfo.AddressList[0];
//            _remoteEP = new IPEndPoint(_ipAddress, port);
//        }

//        private void StartClient(string mesage)
//        {
//            // Connect to a remote device.  
//            try
//            {
//                // Create a TCP/IP socket.  
//                Socket client = new Socket(_ipAddress.AddressFamily,
//                    SocketType.Stream, ProtocolType.Tcp);

//                // Connect to the remote endpoint.  
//                client.BeginConnect(_remoteEP,
//                    new AsyncCallback(ConnectCallback), client);
//                connectDone.WaitOne();

//                // Send test data to the remote device.  
//                Send(client, mesage + StateObject.EOF);
//                sendDone.WaitOne();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }
//        }

//        private void ConnectCallback(IAsyncResult ar)
//        {
//            try
//            {
//                // Retrieve the socket from the state object.  
//                Socket client = (Socket)ar.AsyncState;

//                // Complete the connection.  
//                client.EndConnect(ar);

//                Console.WriteLine("Socket connected to {0}",
//                    client.RemoteEndPoint.ToString());

//                // Signal that the connection has been made.  
//                connectDone.Set();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }
//        }

//        private void Receive(Socket client)
//        {
//            try
//            {
//                // Create the state object.  
//                StateObject state = new StateObject();
//                state.workSocket = client;

//                // Begin receiving the data from the remote device.  
//                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
//                    new AsyncCallback(ReceiveCallback), state);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }
//        }

//        private void ReceiveCallback(IAsyncResult ar)
//        {
//            try
//            {
//                // Retrieve the state object and the client socket
//                // from the asynchronous state object.  
//                StateObject state = (StateObject)ar.AsyncState;
//                Socket client = state.workSocket;

//                // Read data from the remote device.  
//                int bytesRead = client.EndReceive(ar);

//                if (bytesRead > 0)
//                {
//                    // There might be more data, so store the data received so far.  
//                    state.Join(bytesRead);

//                    // Get the rest of the data.  
//                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
//                        new AsyncCallback(ReceiveCallback), state);
//                }
//                else
//                {
//                    // All the data has arrived; put it in response.  
//                    var response = state.GetUTF8String();

//                    // Signal that all bytes have been received.  
//                    receiveDone.Set();

//                    ResponseCallBack?.Invoke(response);

//                    // Release the socket.  
//                    client.Shutdown(SocketShutdown.Both);
//                    client.Close();
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }
//        }

//        private void Send(Socket client, String data)
//        {
//            // Convert the string data to byte data using ASCII encoding.  
//            byte[] byteData = Encoding.ASCII.GetBytes(data);

//            // Begin sending the data to the remote device.  
//            client.BeginSend(byteData, 0, byteData.Length, 0,
//                new AsyncCallback(SendCallback), client);
//        }

//        private void SendCallback(IAsyncResult ar)
//        {
//            try
//            {
//                // Retrieve the socket from the state object.  
//                Socket client = (Socket)ar.AsyncState;

//                // Complete sending the data to the remote device.  
//                int bytesSent = client.EndSend(ar);
//                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

//                // Signal that all bytes have been sent.  
//                sendDone.Set();

//                // Receive the response from the remote device.  
//                Receive(client);
//                receiveDone.WaitOne();

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }
//        }

//        public void Post(string api, object param)
//        {
//            StartClient(new ApiRequest<object>(api, param).ToString());
//        }
//    }

//    public class ApiRequest<T>
//    {
//        public string Api { get; set; }
//        public T Param { get; set; }

//        public ApiRequest() { }
//        public ApiRequest(string api, T param)
//        {
//            Api = api;
//            Param = param;
//        }
//        //public ApiRequest(string api, object param)
//        //{
//        //    Api = api;
//        //    Param = param;
//        //    if (param != null)
//        //    {
//        //        Param = param as string;
//        //        if (Param == null)
//        //        {
//        //            Param = Newtonsoft.Json.JsonConvert.SerializeObject(param);
//        //        }
//        //    }
//        //}
//        public override string ToString()
//        {
//            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
//            //var msg = "{\"api\":\"" + Api + "\"";
//            //if (Param != null)
//            //{
//            //    msg += ",\"param\":\"" + Param + "\"";
//            //}
//            //return msg + '}';
//        }
//    }
//    public class ApiController : ApiBase
//    {
//        static ManualResetEvent allDone = new ManualResetEvent(false);

//        public static void StartListening(string ip, int port)
//        {
//            // Establish the local endpoint for the socket.  
//            // The DNS name of the computer  
//            // running the listener is "host.contoso.com".

//            if (ip == null) { ip = Dns.GetHostName(); }
//            IPHostEntry ipHostInfo = Dns.GetHostEntry(ip);
//            IPAddress ipAddress = ipHostInfo.AddressList[0];
//            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

//            Console.WriteLine("Start server at {0}:{1}", ipAddress.MapToIPv4(), port);

//            // Create a TCP/IP socket.  
//            Socket listener = new Socket(ipAddress.AddressFamily,
//                SocketType.Stream, ProtocolType.Tcp);

//            // Bind the socket to the local endpoint and listen for incoming connections.  
//            try
//            {
//                listener.Bind(localEndPoint);
//                listener.Listen(100);

//                var ts = new ThreadStart(() => {
//                    while (true)
//                    {
//                        // Set the event to nonsignaled state.  
//                        allDone.Reset();

//                        // Start an asynchronous socket to listen for connections.  
//                        Console.WriteLine("Waiting for a connection...");
//                        listener.BeginAccept(
//                            new AsyncCallback(AcceptCallback),
//                            listener);

//                        // Wait until a connection is made before continuing.  
//                        allDone.WaitOne();
//                    }
//                });
//                new Thread(ts).Start();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }
//        }

//        static void AcceptCallback(IAsyncResult ar)
//        {
//            // Signal the main thread to continue.  
//            allDone.Set();

//            // Get the socket that handles the client request.  
//            Socket listener = (Socket)ar.AsyncState;
//            Socket handler = listener.EndAccept(ar);

//            // Create the state object.  
//            StateObject state = new StateObject();
//            state.workSocket = handler;
//            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
//                new AsyncCallback(ReadCallback), state);
//        }

//        static void ReadCallback(IAsyncResult ar)
//        {
//            String content = String.Empty;

//            // Retrieve the state object and the handler socket  
//            // from the asynchronous state object.  
//            StateObject state = (StateObject)ar.AsyncState;
//            Socket handler = state.workSocket;

//            // Read data from the client socket.
//            int bytesRead = handler.EndReceive(ar);

//            if (bytesRead > 0)
//            {
//                string msg = state.GetMessage();
//                if (msg != null)
//                {
//                    // All the data has been read from the
//                    // client. Display it on the console.  

//                    Console.WriteLine(msg);

//                    object response;
//                    try
//                    {
//                        var request = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiRequest<object>>(msg);
//                        var context = new RequestContext(request.Api);

//                        var controller = Engine.CreateObject<ApiController>("Controllers.Api." + context.ControllerName + "Controller");
//                        var method = controller.GetType().GetMethod(context.ActionName);

//                        response = method.Invoke(controller, new object[] { request.Param });
//                    }
//                    catch (Exception e)
//                    {
//                        response = new { Code = -1, Message = e.Message };
//                    }

//                    // Echo the data back to the client.  
//                    Send(handler, Newtonsoft.Json.JsonConvert.SerializeObject(response));
//                }
//                else
//                {
//                    // Not all data received. Get more.  
//                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
//                    new AsyncCallback(ReadCallback), state);
//                }
//            }
//        }

//        static void Send(Socket handler, String data)
//        {
//            byte[] byteData = Encoding.UTF8.GetBytes(data);

//            // Begin sending the data to the remote device.  
//            handler.BeginSend(byteData, 0, byteData.Length, 0,
//                new AsyncCallback(SendCallback), handler);
//        }

//        static void SendCallback(IAsyncResult ar)
//        {
//            try
//            {
//                // Retrieve the socket from the state object.  
//                Socket handler = (Socket)ar.AsyncState;

//                // Complete sending the data to the remote device.  
//                int bytesSent = handler.EndSend(ar);
//                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

//                handler.Shutdown(SocketShutdown.Both);
//                handler.Close();

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }
//        }
//    }
//}
