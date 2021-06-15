using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace KeyMapper
{
    class MainClass
    {

        [DllImport("MouseMapperDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int setGlobalKeyboardHook();

        [DllImport("MouseMapperDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int removeGlobalKeyboardHook();

        static void Main(string[] args)
        {

            
            ServerSocket serverSocket = new ServerSocket(9000);
            
            int success = setGlobalKeyboardHook();
            
            StreamReader configFile = File.OpenText("./config.txt");
            List<Tuple<KeyGroup, KeyAction>> configuredKeyMappings = ConfigFileParser.ParseConfigFile(configFile);
            KeyMappings currentKeyMappings = new KeyMappings(configuredKeyMappings);

            KeyGroup currentlyPressedKeys = new KeyGroup();
            


            while (true)
            {

                ClientSocket client = new ClientSocket(serverSocket.AcceptClient());

                string clientMsg = client.GetMsg();
                Console.WriteLine("Message from client: " + clientMsg);

                KeyEvent keyEvent = KeyEvent.FromClientMessage(clientMsg);

                //By default, tell the hook to do nothing and allow the original key code to pass through
                string returnMessage = "Ok";

                if(keyEvent.GetKeyDirection() == KeyDirection.Up)
                {
                    currentlyPressedKeys.RemoveKey(keyEvent.GetKey());
                }
                else
                {
                    currentlyPressedKeys.AddKey(keyEvent.GetKey());
                    if (currentKeyMappings.Contains(currentlyPressedKeys))
                    {
                        KeyAction keyAction = currentKeyMappings.GetKeyAction(currentlyPressedKeys);
                        keyAction.Execute();
                        returnMessage = keyAction.GetReturnMessage();

                    }
                }

                
                client.SendMsg(returnMessage);
                client.Disconnect();
            }





        }



    }
}
