using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace CompassServer
{
    class SerialPortWrapper
    {
        static private SerialPort _serialPort = null;

        public void Init()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";
            _serialPort.BaudRate = 9600;
            TryOpenPort();
        }

        public void WriteSerialPort(String message)
        {
            lock (_serialPort)
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Write(message + ";");
                }
                else
                {
                    TryOpenPort();
                }
            }
        }

        public String ReadSerialPort()
        {
            String result = "";

            if(_serialPort.IsOpen)
            {
                result = _serialPort.ReadExisting();
            }
            else
            {
                TryOpenPort();
            }

            return result;
        }

        private void TryOpenPort()
        {
            try
            {
                _serialPort.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
