using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace VCCRfid2
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort = new SerialPort();
        private readonly byte[] _readCommand = new byte[] { 0xAA, 0x01, 0xBB };
        private HashSet<string> _uniqueEPCs = new HashSet<string>();
        private List<byte> _receiveBuffer = new List<byte>();

        private const int EPC_LENGTH_BYTES = 12;

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cmbPorts.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                cmbPorts.SelectedIndex = 0;
            }

            if (cmbBaudRate.Items.Count > 0)
            {
                int defaultBaudRateIndex = cmbBaudRate.Items.IndexOf("115200");
                cmbBaudRate.SelectedIndex = (defaultBaudRateIndex >= 0) ? defaultBaudRateIndex : 0;
            }

            UpdateStatusLabels("Not Connected", "Not Set");
            btnScan.Enabled = false;
            btnStop.Enabled = false;
            btnDisconnect.Enabled = false;

            tmrScan.Interval = 200;
            tmrScan.Tick += tmrScan_Tick;
        }

        private void InitializeDataGridView()
        {
            dgvTags.Rows.Clear();
        }

        private void btnConnect_Click(object? sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                UpdatePromptMessage("Already connected.", true);
                return;
            }

            string? selectedPort = cmbPorts.SelectedItem?.ToString();
            string? selectedBaudRate = cmbBaudRate.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedPort) || string.IsNullOrEmpty(selectedBaudRate))
            {
                UpdatePromptMessage("Please select Port and Baud Rate.", true);
                return;
            }

            try
            {
                _serialPort.PortName = selectedPort;
                _serialPort.BaudRate = int.Parse(selectedBaudRate);
                _serialPort.DataBits = 8;
                _serialPort.Parity = Parity.None;
                _serialPort.StopBits = StopBits.One;
                _serialPort.Handshake = Handshake.None;
                _serialPort.ReadTimeout = 1000;
                _serialPort.WriteTimeout = 1000;

                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

                _serialPort.Open();

                UpdateStatusLabels(_serialPort.PortName, _serialPort.BaudRate.ToString());
                UpdatePromptMessage($"Connected to {_serialPort.PortName} at {_serialPort.BaudRate} baud.");
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnScan.Enabled = true;
                btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                UpdateStatusLabels("Error", "Error");
                UpdatePromptMessage($"Connection Error: {ex.Message}", true);
                _serialPort.DataReceived -= _serialPort_DataReceived;
            }
        }

        private void btnDisconnect_Click(object? sender, EventArgs e)
        {
            DisconnectSerialPort();
        }

        private void btnScan_Click(object? sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                tmrScan.Start();
                UpdatePromptMessage("Scanning started.");
                btnScan.Enabled = false;
                btnStop.Enabled = true;
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = false;
            }
            else
            {
                UpdatePromptMessage("Not connected. Please connect first.", true);
            }
        }

        private void btnStop_Click(object? sender, EventArgs e)
        {
            tmrScan.Stop();
            UpdatePromptMessage("Scanning stopped.");
            btnScan.Enabled = true;
            btnStop.Enabled = false;
            btnDisconnect.Enabled = true;
            btnConnect.Enabled = false;
        }

        private void btnClearData_Click(object? sender, EventArgs e)
        {
            ClearTagData();
            UpdatePromptMessage("Tag data cleared.");
        }

        private void tmrScan_Tick(object? sender, EventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Write(_readCommand, 0, _readCommand.Length);
                }
                else
                {
                    tmrScan.Stop();
                    UpdatePromptMessage("Port disconnected. Stopping scan.", true);
                    SetControlStates(false);
                }
            }
            catch (Exception ex)
            {
                tmrScan.Stop();
                UpdatePromptMessage($"Scan write error: {ex.Message}", true);
                SetControlStates(false);
            }
        }

        private void _serialPort_DataReceived(object? sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort? sp = sender as SerialPort;
                if (sp == null) return;

                int bytesToRead = sp.BytesToRead;
                byte[] data = new byte[bytesToRead];
                sp.Read(data, 0, bytesToRead);

                lock (_receiveBuffer)
                {
                    _receiveBuffer.AddRange(data);
                }

                ProcessReceivedData();
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => UpdatePromptMessage($"Data Receive Error: {ex.Message}", true)));
                }
                else
                {
                    UpdatePromptMessage($"Data Receive Error: {ex.Message}", true);
                }
            }
        }

        private void ProcessReceivedData()
        {
            lock (_receiveBuffer)
            {
                while (_receiveBuffer.Count >= EPC_LENGTH_BYTES)
                {
                    byte[] epcBytes = _receiveBuffer.Take(EPC_LENGTH_BYTES).ToArray();
                    string epc = BitConverter.ToString(epcBytes).Replace("-", "");

                    _receiveBuffer.RemoveRange(0, EPC_LENGTH_BYTES);

                    AddOrUpdateTag(epc);
                }
            }
        }

        private void AddOrUpdateTag(string epc)
        {
            if (dgvTags.InvokeRequired)
            {
                dgvTags.Invoke(new Action(() => AddOrUpdateTag(epc)));
                return;
            }

            if (_uniqueEPCs.Add(epc))
            {
                dgvTags.Rows.Add("Reader1", epc, "", "", "1", "N/A", DateTime.Now.ToString("HH:mm:ss"), "");
            }
            else
            {
                foreach (DataGridViewRow row in dgvTags.Rows)
                {
                    if (row.Cells["ColumnEPC"].Value?.ToString() == epc)
                    {
                        row.Cells["ColumnReadTime"].Value = DateTime.Now.ToString("HH:mm:ss");
                        break;
                    }
                }
            }

            UpdateTotalTags(_uniqueEPCs.Count);
        }

        private void ClearTagData()
        {
            dgvTags.Rows.Clear();
            _uniqueEPCs.Clear();
            UpdateTotalTags(0);
        }

        private void DisconnectSerialPort()
        {
            if (_serialPort.IsOpen)
            {
                tmrScan.Stop();
                try
                {
                    _serialPort.DataReceived -= _serialPort_DataReceived;
                    _serialPort.Close();
                    UpdatePromptMessage($"Disconnected from {_serialPort.PortName}.");
                }
                catch (Exception ex)
                {
                    UpdatePromptMessage($"Disconnection Error: {ex.Message}", true);
                }
            }

            SetControlStates(true);
            UpdateStatusLabels("Not Connected", "Not Set");
        }

        private void SetControlStates(bool isDisconnected)
        {
            btnConnect.Enabled = isDisconnected;
            btnDisconnect.Enabled = !isDisconnected;
            btnScan.Enabled = !isDisconnected && !tmrScan.Enabled;
            btnStop.Enabled = !isDisconnected && tmrScan.Enabled;
        }


        private void UpdateTotalTags(int count)
        {
            if (lblTotalTags.InvokeRequired)
            {
                lblTotalTags.Invoke(new Action(() => lblTotalTags.Text = $"Total Number: {count}"));
            }
            else
            {
                lblTotalTags.Text = $"Total Number: {count}";
            }
        }

        private void UpdatePromptMessage(string message, bool isError = false)
        {
            if (txtPromptMessage.InvokeRequired)
            {
                txtPromptMessage.Invoke(new Action(() => UpdatePromptMessage(message, isError)));
            }
            else
            {
                if (isError)
                {
                    txtPromptMessage.SelectionColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtPromptMessage.SelectionColor = System.Drawing.Color.Black;
                }

                txtPromptMessage.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} - {message}{Environment.NewLine}");
                txtPromptMessage.SelectionStart = txtPromptMessage.TextLength;
                txtPromptMessage.ScrollToCaret();
                txtPromptMessage.SelectionColor = System.Drawing.Color.Black;
            }
        }

        private void UpdateStatusLabels(string? portStatus, string? baudStatus)
        {
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke(new Action(() => UpdateStatusLabels(portStatus ?? "N/A", baudStatus ?? "N/A")));
            }
            else
            {
                toolStripStatusLabelPort.Text = $"Port: {portStatus ?? "Not Set"}";
                toolStripStatusLabelBaud.Text = $"Baud: {baudStatus ?? "Not Set"}";
            }
        }
    }
}