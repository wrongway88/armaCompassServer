using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace CompassServer
{
    public partial class Compass : Form
    {
        public delegate void WriteToSerialPortCallback(String message);

        public WriteToSerialPortCallback _writeToSerialPortCallback = null;

        private String _prevDebugInput = "";
        private Mutex _serialPortMutex = new Mutex();
        private int _targetDir;

        private long _lastSerialWrite = 0;

        public Compass()
        {
            InitializeComponent();

            _lastSerialWrite = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public void SetDebugText(String text)
        {
            if(textBox_debugOutput.InvokeRequired)
            {
                Invoke(new Action<string>(SetDebugText), new object[] { text });
                return;
            }

            textBox_debugOutput.Text = text;
        }

        public void WriteDebugLine(String text)
        {
            long nowMilli = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            if (textBox_debugOutput.InvokeRequired)
            {
                Invoke(new Action<string>(WriteDebugLine), new object[] { text });
                return;
            }

            textBox_debugOutput.AppendText(Environment.NewLine);
            textBox_debugOutput.AppendText((nowMilli - _lastSerialWrite).ToString() + ": " + text);
            _lastSerialWrite = nowMilli;
        }

        private void button_debugApply_Click(object sender, EventArgs e)
        {
            String text = textBox_debugRotation.Text;
            int number = 0;
            // if(int.TryParse(text, out number))
            {
                WriteDebugLine("Debug to serial: " + text);

                _writeToSerialPortCallback.Invoke(text);
            }
        }

        private void textBox_debugRotation_TextChanged(object sender, EventArgs e)
        {
            return;

            String text = textBox_debugRotation.Text;

            int number = 0;

            if(text != ""
                && text != "-"
                && int.TryParse(text, out number) == false)
            {
                textBox_debugRotation.Text = _prevDebugInput;
            }
            else
            {
                _prevDebugInput = text;
            }
        }

        private void button_clearDebugOutput_MouseClick(object sender, MouseEventArgs e)
        {
            SetDebugText("");
        }
    }
}
