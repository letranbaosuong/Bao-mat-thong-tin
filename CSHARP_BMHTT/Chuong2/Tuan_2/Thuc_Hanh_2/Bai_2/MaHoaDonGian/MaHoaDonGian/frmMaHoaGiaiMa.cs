using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaHoaDonGian
{
    public partial class frmMaHoaGiaiMa : Form
    {
        public delegate void ProgressInitHandler(object sender, ProgressInitArgs e);
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);
        public static event ProgressEventHandler IncrementProgress;
        public static event ProgressInitHandler InitProgress;

        private MaHoa cryptographer = null;
        private int elapsed = 0;
        private bool IsFile = false;
        private bool IsEncryption = false;
        private DateTime start;
        private DateTime end;
        private TimeSpan result;
        private TimerCallback timerDelegate;
        private AutoResetEvent autoEvent;
        private System.Threading.Timer timer1;
        private BackgroundWorker wkr;
        public frmMaHoaGiaiMa()
        {
            InitializeComponent();
        }
        public void DisableButtons()
        {
            CheckForIllegalCrossThreadCalls = false;
            btnFileDecrypt.Enabled = false;
            btnFileEncrypt.Enabled = false;
            btnFileSelect.Enabled = false;
            btnTextDecrypt.Enabled = false;
            btnTextEncrypt.Enabled = false;
        }
        public void EnableButtons()
        {
            btnFileDecrypt.Enabled = true;
            btnFileEncrypt.Enabled = true;
            btnFileSelect.Enabled = true;
            btnTextDecrypt.Enabled = true;
            btnTextEncrypt.Enabled = true;
        }
        private void StartProcess()
        {
            if (rbContinuous.Checked)
            {
                timer1 = new System.Threading.Timer(timerDelegate, autoEvent, 0, 1000);
                wkr.RunWorkerAsync();
            }
            else if (rbResult.Checked)
            {
                DisableButtons();
                start = DateTime.Now;
                this.StartSelectedProcess();
                end = DateTime.Now;
                result = end - start;
                lblProgress.Text = "Elapsed Time : " + result.ToString();
            if (IsFile == true)
                {
                    // MessageBox.Show(lblEncryptedFilename.Text + " File Encryption/Decryption is complete.");
                    MessageBox.Show(txtAlteredFile.Text, "File Encryption/Decryption is complete.");
                }
                EnableButtons();
            }
        }
        private void StartSelectedProcess()
        {
            elapsed = 0;
            ClearProgressBar();
            if (IsEncryption) // Mã hóa
            {
                if (IsFile) // Mã hóa tập tin
                {
                    cryptographer = new MaHoa(rbDES.Checked ? CacGiaiThuat.DES_File :
                    CacGiaiThuat.AES_File, IncrementProgress, InitProgress);
                    cryptographer.EncryptionStart(txtFile.Text.Replace("\\", "\\\\"),
                    txtAlteredFile.Text.Replace("\\", "\\\\"), txtKey_File.Text.ToUpper());
                }
                else
                { // Mã hóa văn bản
                    txtEncrypted.Clear();
                    cryptographer = new MaHoa(rbDES.Checked ? CacGiaiThuat.DES : CacGiaiThuat.AES,
                    IncrementProgress, InitProgress);
                    txtEncrypted.Text = cryptographer.EncryptionStart(txtPlainText.Text, txtKey.Text.ToUpper(),
                    false);
                }
            }
            else
            { // Giải mã
                if (IsFile)
                { // Giải mã tập tin
                    cryptographer = new MaHoa(rbDES.Checked ? CacGiaiThuat.DES_File :
                    CacGiaiThuat.AES_File, IncrementProgress, InitProgress);
                    cryptographer.DecryptionStart(txtFile.Text.Replace("\\", "\\\\"),
                    txtAlteredFile.Text.Replace("\\", "\\\\"), txtKey_File.Text.ToUpper());
                }
                else
                { // Giải mã văn bản
                    txtEncrypted.Clear();
                    cryptographer = new MaHoa(rbDES.Checked ? CacGiaiThuat.DES : CacGiaiThuat.AES,
                    IncrementProgress, InitProgress);
                    txtEncrypted.Text = GiaiThuat.AES.BaseTransform.FromBinaryToText(
                    cryptographer.DecryptionStart(txtPlainText.Text, txtKey.Text.ToUpper(), true));
                }
            }
        }
        private bool FileCheck()
        {
            if (txtFile.Text == "")
            {
                MessageBox.Show("Please select a file for encryption/decryption");
                return false;
            }
            return true;
        }
        private bool KeyCheck(string key)
        {
            if (rbDES.Checked)
            {
                if (key.Length == 16)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("The key must be 16-HexDecimal Length for DES algorithm");
                    return false;
                }
            }
            else
            {
                if (key.Length == 32)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("The key must be 32-HexDecimal Length for AES algorithm");
                    return false;
                }
            }
        }
        private void ClearProgressBar()
        {
            prbProgress.Value = 0;
        }
        private bool IsHexaDecimal(char value)
        {
            if ((('0' <= value) && (value <= '9')) ||
                    (('A' <= value) && (value <= 'F')) ||
                    (('a' <= value) && (value <= 'f')) ||
                    (8 == (int)value))
            {
                return true;
            }
            return false;
        }
        private void increase(object sender, ProgressEventArgs e)
        {
            prbProgress.Increment(e.Increment);
        }
        private void Initialize(object sender, ProgressInitArgs e)
        {
            prbProgress.Maximum = e.Maximum;
        }
        private void wkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Dispose();
            if (IsFile)
            {
                // MessageBox.Show(lblEncryptedFilename.Text + " File Encryption/Decryption is complete.");
                MessageBox.Show(txtAlteredFile.Text, "File Encryption/Decryption is complete.");
            }
            EnableButtons();
        }
        private void wkr_DoWork(object sender, DoWorkEventArgs e)
        {
            DisableButtons();
            this.StartSelectedProcess();
        }

        private void btnFileEncrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(txtKey_File.Text) || !FileCheck())
            {
                return;
            }
            IsFile = true;
            IsEncryption = true;
            StartProcess();
        }

        private void btnFileDescrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(txtKey_File.Text) || !FileCheck())
            {
                return;
            }
            IsFile = true;
            IsEncryption = false;
            StartProcess();
        }

        private void btnTextEncrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(txtKey.Text))
            {
                return;
            }
            IsFile = false;
            IsEncryption = true;
            StartProcess();
        }

        private void btnTextDecrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(txtKey.Text))
            {
                return;
            }
            IsFile = false;
            IsEncryption = false;
            StartProcess();
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            txtFile.Clear();
            txtAlteredFile.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
                txtAlteredFile.Text = openFileDialog1.FileName.Replace(".", "_2.");
            }
        }

        private void frmMaHoaGiaiMa_Load(object sender, EventArgs e)
        {
            StartUp startup = new StartUp();
            startup.ShowDialog();
            // Initialize progressbar
            prbProgress.Maximum = 100;
            prbProgress.Step = 1;
            InitProgress += new ProgressInitHandler(Initialize);
            IncrementProgress += new ProgressEventHandler(increase);
            // Initialize timer
            timerDelegate = new TimerCallback(this.Timer1_Tick);
            autoEvent = new AutoResetEvent(false);
            // Initialize BackgroundWorker for ecryption and decryption process
            wkr = new BackgroundWorker();
            wkr.DoWork += new DoWorkEventHandler(wkr_DoWork);
            wkr.RunWorkerCompleted += new
            RunWorkerCompletedEventHandler(wkr_RunWorkerCompleted);
        }

        private void rbDES_CheckedChanged(object sender, EventArgs e)
        {
            txtKey_File.MaxLength = 16;
            txtKey.MaxLength = 16;
        }

        private void rbAES_CheckedChanged(object sender, EventArgs e)
        {
            txtKey_File.MaxLength = 32;
            txtKey.MaxLength = 32;
        }

        private void txtKey_File_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsHexaDecimal(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = false;

            if (rbDES.Checked)
            {
                txtKey_File.MaxLength = 16;
                txtKey.MaxLength = 16;
            }
            else if (rbAES.Checked)
            {
                txtKey_File.MaxLength = 32;
                txtKey.MaxLength = 32;
            }
        }

        private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsHexaDecimal(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = false;

            if (rbDES.Checked)
            {
                txtKey_File.MaxLength = 16;
                txtKey.MaxLength = 16;
            }
            else if (rbAES.Checked)
            {
                txtKey_File.MaxLength = 32;
                txtKey.MaxLength = 32;
            }
        }
        public void Timer1_Tick(object stateInfo)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                elapsed++;
                lblProgress.Text = "Elapsed Time : " + elapsed.ToString() + " sec.";
            }));
        }
    }
}
