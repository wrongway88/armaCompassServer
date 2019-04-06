using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text;
using System.Threading;

namespace CompassServer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Compass compass = new Compass();

            SerialPortWrapper portWrapper = new SerialPortWrapper();
            portWrapper.Init();

            AsynchronousSocketListener._socketCallback += MessageBuffer.SocketCallback;
            MessageBuffer._writeToSerialPortCallback += portWrapper.WriteSerialPort;
            MessageBuffer._debugPrintCallback += compass.WriteDebugLine;
            MessageBuffer._serialReadCallback += portWrapper.ReadSerialPort;
            compass._writeToSerialPortCallback = portWrapper.WriteSerialPort;

            Thread socketThread = new System.Threading.Thread(new ThreadStart(AsynchronousSocketListener.StartListening));
            Thread bufferThread = new System.Threading.Thread(new ThreadStart(MessageBuffer.Run));

            socketThread.Start();
            bufferThread.Start();

            Application.Run(compass);
        }
    }

    
}
