using log4net;
using log4net.Config;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Web.Script.Serialization;

using WebSocket4Net;
namespace AdminServerObject
{
    public class AdminServer
    {
        bool firstConnect = true;
        private List<string> ipAddressList = null;
        private AutoResetEvent _messageReceivedEvent = new AutoResetEvent(false);
        private Exception websocketException;
        private JavaScriptSerializer jss;
        private MessageCoder messageCoder;
        private ServerResponse serverResponse;
        private WebSocket _websocket = null;
        private SortedDictionary<string, FtpServerInfo> ftpServerList = null;
        private string errorMessage = "";
        public string lastServerId = "";
        private static readonly ILog logger = LogManager.GetLogger(typeof(AdminServer));

        public int portNo;
        public string serverName { get; set; }
        public AdminServer()
        {
            jss = new JavaScriptSerializer();
            messageCoder = new MessageCoder();
            string log4netConfigFilePath = AppDomain.CurrentDomain.BaseDirectory + "log4net.config";
            XmlConfigurator.Configure(new FileInfo(log4netConfigFilePath));
        }
        public ServerResponse addFtpServer(FtpServerInfo ftpServerInfo)
        {
            errorMessage = "";
            Request request = new Request();
            ServerResponse response = null;
            request.action = "AddFtpServer";
            List<string> bindingAddresses = new List<string>();
            foreach (string address in ftpServerInfo.bindingAddresses)
            {
                bindingAddresses.Add(address);
            }
            ftpServerInfo.bindingAddresses = bindingAddresses;
            request.ObjectMap["ftpServerInfo"] = ftpServerInfo;
            _websocket.Send(messageCoder.aesEncode(jss.Serialize(request)));
            _messageReceivedEvent.WaitOne();
            if (String.IsNullOrEmpty(errorMessage))
            {
                response = jss.Deserialize<ServerResponse>(jss.Serialize(serverResponse));
                if (response.responseCode == 0)
                {
                    ftpServerInfo.serverId = (string)response.returnObjects["ftpServerId"];
                    ftpServerList.Add(ftpServerInfo.serverId, ftpServerInfo);
                    lastServerId = ftpServerInfo.serverId;
                }
            }
            else
            {
                disConnect();
                websocketException = new Exception("An exception occurs when adding a FTP Server.");
                throw websocketException;
            }
            return response;
        }
        public bool connect(string hostName, int portNo)
        {
            bool result = false;
            this.portNo = portNo;
            this.serverName = hostName;
            string URL = "ws://" + hostName + ":" + portNo + "/websocket";
            firstConnect = true;
            errorMessage = "";
            _websocket = new WebSocket(URL);
            _websocket.Opened += new EventHandler(websocket_Opened);
            _websocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(websocket_Error);
            _websocket.Closed += new EventHandler(websocket_Closed);
            _websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
            _websocket.Open();

            _messageReceivedEvent.WaitOne();

            if (String.IsNullOrEmpty(errorMessage))
                result = true;
            else
            {
                result = false;
            }
            return result;
        }
        public ServerResponse deleteFtpServer(string serverId)
        {
            errorMessage = "";
            Request request = new Request();
            ServerResponse response = null;
            request.action = "DelFTPServer";
            request.ObjectMap["ftpServerId"] = serverId;
            _websocket.Send(messageCoder.aesEncode(jss.Serialize(request)));
            _messageReceivedEvent.WaitOne();
            if (String.IsNullOrEmpty(errorMessage))
            {
                response = jss.Deserialize<ServerResponse>(jss.Serialize(serverResponse));
                if (response.responseCode == 0)
                {
                    ftpServerList.Remove(serverId);
                }
            }
            else
            {
                disConnect();
                websocketException = new Exception("An exception occurs when deleting ftp server instance.");
                throw websocketException;
            }
            return response;
        }
        public void disConnect()
        {
            if (_websocket.State == WebSocketState.Open)
                _websocket.Close();
        }
        public FtpServerInfo getFTPServerInfo(string serverId)
        {
            FtpServerInfo result = null;
            if (ftpServerList != null)
            {
                result = ftpServerList[serverId];
            }
            return result;
        }
        public SortedDictionary<string, FtpServerInfo> getFTPServerList()
        {
            return this.ftpServerList;
        }
        public List<string> getIPAddressList()
        {
            return this.ipAddressList;
        }
        public bool login(string userName, string password)
        {
            bool result = true;
            Login login = new Login();
            login.password = password;
            login.userName = userName;
            errorMessage = "";
            _websocket.Send(messageCoder.aesEncode(jss.Serialize(login)));
            _messageReceivedEvent.WaitOne();
            if (String.IsNullOrEmpty(errorMessage))
            {
                if (serverResponse.responseCode == 0)
                {
                    logger.Info("Login to admin. server successfully.");
                    this.ftpServerList = jss.Deserialize<SortedDictionary<string, FtpServerInfo>>(jss.Serialize(serverResponse.returnObjects["ftpServerList"]));
                    this.ipAddressList = jss.Deserialize<List<string>>(jss.Serialize(serverResponse.returnObjects["ipAddressList"]));
                    result = true;
                }
                else
                {
                    result = false;
                    disConnect();
                    logger.Debug("Login to admin. server failure.");
                }
            }
            else
            {
                result = false;
                disConnect();
                websocketException = new Exception("An exception occurs when login to admin. server.");
                throw websocketException;
            }
            return result;
        }
        public ServerResponse saveFtpServerNetworkProperties(FtpServerInfo ftpServerInfo)
        {
            errorMessage = "";
            Request request = new Request();
            ServerResponse response = null;
            request.action = "SaveFTPServerNetworkProperties";
            List<string> bindingAddresses = new List<string>();
            foreach (string address in ftpServerInfo.bindingAddresses)
            {
                bindingAddresses.Add(address);
            }
            ftpServerInfo.bindingAddresses = bindingAddresses;
            request.ObjectMap["ftpServerInfo"] = ftpServerInfo;
            _websocket.Send(messageCoder.aesEncode(jss.Serialize(request)));
            _messageReceivedEvent.WaitOne();
            if (String.IsNullOrEmpty(errorMessage))
            {
                response = jss.Deserialize<ServerResponse>(jss.Serialize(serverResponse));
                if (response.responseCode == 0)
                {
                    ftpServerList.Remove(ftpServerInfo.serverId);
                    ftpServerList.Add(ftpServerInfo.serverId, ftpServerInfo);
                    lastServerId = ftpServerInfo.serverId;
                }
            }
            else
            {
                disConnect();
                websocketException = new Exception("An exception occurs when adding a FTP Server.");
                throw websocketException;
            }
            return response;
        }
        private void sendRSAKey()
        {
            logger.Debug("Send RSA Key");
            _websocket.Send(messageCoder.getRSAPublicKey());
        }
        private void websocket_Closed(object sender, EventArgs e)
        {
            errorMessage = e.ToString();
            logger.Debug("Websocket Connection is closed:" + errorMessage);
            _messageReceivedEvent.Set();
        }
        private void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            errorMessage = e.Exception.Message;
            logger.Debug("Websocket Error:" + errorMessage);
            _messageReceivedEvent.Set();
        }
        private void websocket_Opened(object sender, EventArgs e)
        {
            logger.Debug("Connection opened");
            sendRSAKey();
        }
        private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            logger.Debug("Raw Server response:" + e.Message);
            string decodedMessage = "";
            if (firstConnect)
            {
                decodedMessage = messageCoder.decodeRSAMessage(e.Message);
                dynamic AESObject = jss.Deserialize<dynamic>(decodedMessage);
                messageCoder.initAESCodec(AESObject["messageKey"], AESObject["ivText"]);
                firstConnect = false;
            }
            else
            {
                decodedMessage = messageCoder.aesDecode(e.Message);
                serverResponse = jss.Deserialize<ServerResponse>(decodedMessage);
            }
            logger.Debug("Decoded server response:" + decodedMessage);
            _messageReceivedEvent.Set();
        }
    }
}
