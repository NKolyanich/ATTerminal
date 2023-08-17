using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ATTerminal
{
    public enum Command
    {
        COMMAND_
    };

    public enum ANSWER_CODE
    {
        OK = 0x00,
        CONNECT,
        RING,
        NO_CARRIER,
        ERROR,
        NO_DIALTONE,
        BUSY,
        NO_ANSWER,
        NOT_SUPPORT,
        INVALID_COMMAND_LINE
    };

    public struct MSGRead
    {

        public string AnswerCommand;
        public int AnswerCode;
        public int SizeData;
        public byte[] Data;
    };

    public partial class MainForm : Form
    {
        Timer loop;
        int AnswerFlag = 0; // 0 - ожидаем ответной команды. 1 - ожидаем кода ответа. 2 - ожидаем параметров ответа
        const int BUF_LEIGHT = 255;
        byte[] readBuf = new byte[BUF_LEIGHT];
        MSGRead[] mgread = new MSGRead[10];
        public MainForm()
        {
            InitializeComponent();

            comboBoxPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            serialPort.BaudRate = 115200;
            checkBoxLoop.Checked = false;
            labelDelay.Enabled = false;
            maskedTextBoxLoopDelay.Enabled = false;
            OnReceive += new MethodReceive(SerialPort_OnReceive);
            loop = new Timer();
            loop.Tick += new EventHandler(loop_Tick);
            DateTime dt = DateTime.Now;
            WriteStringInLog("\r\n//------ "+dt.ToLongDateString()+" "+dt.ToLongTimeString()+"---------------- //");

            toolTip.SetToolTip(comboBoxPort, "Выбор COM-порта.");
            toolTip.SetToolTip(buttonStart, "Запуск/Останов выбранного COM-порта.");
            toolTip.SetToolTip(checkBoxLoop, "Включение/выключение цикличной посылки сообщения.");
            toolTip.SetToolTip(maskedTextBoxLoopDelay, "Период посылки сообщения, в миллисекундах.");
            toolTip.SetToolTip(buttonClear, "Очистка списка. Лог НЕ стирается.");
            toolTip.SetToolTip(textBoxSendString, "Сообщение в hex.\nС пробелами или без.\nМаксимум 50 символов. \nРасчёт CRC - автоматически, для Modbus-RTU");
            toolTip.SetToolTip(buttonSend, "1)Отправка сообщения\n2)Запуск/останов цикла посылки сообщения.");
        }

        void loop_Tick(object sender, EventArgs e)
        {
            SendHexString(textBoxSendString.Text);
        }

        public delegate void MethodReceive(byte[] str);
        public event MethodReceive OnReceive;


        void SerialPort_OnReceive(byte[] data)
        {
            SetReceiveTerminalTextChange(data);
        }

        delegate void SetReceiveTextCallback(byte[] data);
        void SetReceiveTerminalTextChange(byte[] data)
        {
            if (this.listViewLog.InvokeRequired)
            {
                SetReceiveTextCallback dt = new SetReceiveTextCallback(SetReceiveTerminalTextChange);
                this.Invoke(dt, new object[] { data });
            }
            else
            {
                string[] str = new string[listViewLog.Columns.Count];
                DateTime dt = DateTime.Now;
                string strdata = "";
                for (int i = 0; i < data.Length; i++)
                {
                    if (Convert.ToChar(data[i]) == 0x0d)
                    {
                        if ( AnswerFlag == 0 )
                        {// если только получили ответ

                        }
                        //strdata += Convert.ToString(data[i],);
                        strdata += Convert.ToChar(data[i]).ToString();
                    }
                    else
                    {
                        strdata += Convert.ToChar(data[i]).ToString();
                        continue;
                    }
                }
                str[0] = (listViewLog.Items.Count + 1).ToString();
                str[1] = dt.ToLongTimeString() + "." + dt.Millisecond.ToString();
                str[2] = strdata;
                str[3] = " <<-- ";
                listViewLog.Items.Add(new ListViewItem(str));
                DownScroll();
                WriteStringInLog(String.Join("    ", str));

                listViewLog.Items[listViewLog.Items.Count - 1].BackColor = Color.Salmon;
            }
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort.PortName = (string)comboBoxPort.SelectedItem;
        }



        int _stepIndex = 0;
        bool _startRead = false;
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        { //принимаем пакет
            try
            { 
                //  узнаем сколько байт пришло
                int buferSize = serialPort.BytesToRead;
                for (int i = 0; i < buferSize; ++i)
                {
                    //  читаем по одному байту
                    byte bt = (byte)serialPort.ReadByte();
                    //  если встретили начало кадра (0xFF) - начинаем запись в _bufer
                    if (0x0A == bt)
                    {
                        bt = (byte)serialPort.ReadByte();
                        if ( 0x0D == bt )
                        {
                            if (_startRead)
                            {
                                //  когда буфер наполнлся данными
                                _startRead = false;
                                byte[] bu = new byte[_stepIndex];
                                for (int y = 0; y < _stepIndex; y++)
                                {
                                    bu[y] = readBuf[y];
                                }
                                //- разбираем что приняли----------------
                                OnReceive(bu);
                            }
                            else
                            {
                                _stepIndex = 0;
                                _startRead = true;
                                //goto exit;
                            }
                        }
                    }
                    //  дописываем в буфер все остальное
                    if (_startRead)
                    {
                        readBuf[_stepIndex] = bt;
                        ++_stepIndex;
                    }
                    //exit: ;
                }
            }
            catch { }

            //////////////
            //serialPort.Read(readBuf, 0, BUF_LEIGHT);
            //OnReceive(readBuf);
        }

        #region Button Start
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
                buttonStart.Text = "Стоп";
                comboBoxPort.Enabled = false;
            }
            else
            {
                serialPort.Close();
                buttonStart.Text = "Старт";
                comboBoxPort.Enabled = true;
            }
        }
        #endregion

        #region Button Send
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                if (!checkBoxLoop.Checked)
                {
                    SendHexString(textBoxSendString.Text);
                }
                else
                {
                    if (loop.Enabled)
                    {
                        buttonSend.Text = "Запуск";
                        loop.Stop();
                    }
                    else
                    {
                        buttonSend.Text = "Стоп";
                        loop.Interval = Convert.ToInt32(maskedTextBoxLoopDelay.Text);
                        loop.Start();
                    }
                }     
            }
            else
            {
                MessageBox.Show("Порт: \"" + serialPort.PortName + "\" НЕ открыт!");
            }
        }

        private void SendHexString(string Data)
        {
            try
            {
                if (checkBox_crlf.Checked == true)
                {
                    Data = Data + "\r\n";
                }
                if (checkBox_esc.Checked)
                {
                    Data = Data + Convert.ToString(0x1B);
                }
                serialPort.Write(Data);

                string[] str = new string[listViewLog.Columns.Count];
                DateTime dt = DateTime.Now;
                str[0] = (listViewLog.Items.Count + 1).ToString();
                str[1] = dt.ToLongTimeString() + "." + dt.Millisecond.ToString();
                str[2] = Data;
                str[3] = " -->> ";

                listViewLog.Items.Add(new ListViewItem(str));
                DownScroll();
                listViewLog.Items[listViewLog.Items.Count - 1].BackColor = Color.LightBlue;

                WriteStringInLog(String.Join("    ", str));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region Button Clear
        private void buttonClear_Click(object sender, EventArgs e)
        {
            listViewLog.Items.Clear();
        }
        #endregion

        private void DownScroll()
        {
            listViewLog.EnsureVisible(listViewLog.Items.Count - 1);
        }

        #region //ModRTU_CRC
        byte[] ModRTU_CRC(byte[] buf, int len)
        {
            UInt16 crc = 0xFFFF;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (UInt16)buf[pos];

                for (int i = 8; i != 0; i--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                        crc >>= 1;
                }
            }
            //  младший и старший байты поменяны местами
            byte[] crc16 = new byte[2];
            crc16[1] = (byte)((crc/256) & 0x00ff);	 //  Hi byte
            crc16[0] = (byte)(crc & 0x00ff); 		 //  Lo byte
            return crc16;
        }
        #endregion

        private void WriteStringInLog(string data)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + @"\log.log", true))
            {
                file.WriteLine(data);
            }
        }

        private void checkBoxLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoop.Checked)
            {
                labelDelay.Enabled = true;
                maskedTextBoxLoopDelay.Enabled = true;
                buttonSend.Text = "Запуск";
            }
            else
            {
                labelDelay.Enabled = false;
                maskedTextBoxLoopDelay.Enabled = false;
                buttonSend.Text = "Отправить";
            }
        }

    }
}
