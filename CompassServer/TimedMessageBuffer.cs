using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompassServer
{
    public class TimedMessageBuffer
    {
        public delegate void TimedBufferCallback(String message);
        public delegate void DebugPrintCallback(String message);
        public delegate String SerialReadCallback();

        public static TimedBufferCallback _writeToSerialPortCallback = null;
        public static DebugPrintCallback _debugPrintCallback = null;
        public static SerialReadCallback _serialReadCallback = null;

        private static Queue<String> _writeBuffer = new Queue<string>();
        private static Queue<String> _readBuffer = new Queue<string>();

        private static String _lastSentMessage = "n/a";

        public static void Run()
        {
            String nextMessage = "";

            while (true)
            {
                if (_readBuffer.Count > 0)
                {
                    nextMessage = _readBuffer.Dequeue();
                }
                else
                {
                    lock (_writeBuffer)
                    {
                        lock (_readBuffer)
                        {
                            _readBuffer = _writeBuffer;
                            _writeBuffer = new Queue<string>();
                        }
                    }
                }

                if (nextMessage.Length > 0
                    && _lastSentMessage != nextMessage)
                {
                    _debugPrintCallback.Invoke("message Buffer to Serial: " + nextMessage);

                    _writeToSerialPortCallback.Invoke(nextMessage);

                    _lastSentMessage = nextMessage;
                    nextMessage = "";
                }


                String message = "";
                String fragment = _serialReadCallback();

                while(fragment.Length > 0)
                {
                    message += fragment;
                    fragment = _serialReadCallback();
                }

                if(message.Length > 0)
                {
                    _debugPrintCallback.Invoke("Serial to message Buffer: " + message);
                }
            }
        }

        public static void SocketCallback(String message)
        {
            lock (_writeBuffer)
            {
                _writeBuffer.Enqueue(message);
            }
        }
    }
}
