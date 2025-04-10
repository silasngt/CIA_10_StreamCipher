using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIA_10_StreamCipher
{
    public partial class Form1: Form
    {
        // Khai báo thêm TextBox mới (Hiển thị bit cho phần Key và Giải mã)
        private TextBox textBoxKeyBits;
        private TextBox textBoxKeystreamBits;
        private Label labelKeyBits;
        private Label labelKeystreamBits;


        // Khai báo các thành phần giao diện
        private ComboBox comboBoxAlgorithm;
        private TextBox textBoxKey;
        private TextBox textBoxPlaintext;
        private TextBox textBoxPlaintextBits;
        private TextBox textBoxCiphertext;
        private TextBox textBoxCiphertextBits;
        private TextBox textBoxDecrypted;
        private TextBox textBoxDecryptedBits;
        private Button buttonEncrypt;
        private Button buttonDecrypt;
        private Button buttonGenerateKey; // Nút mới để tạo khóa
        private Label labelAlgorithm;
        private Label labelKey;
        private Label labelPlaintext;
        private Label labelCiphertext;
        private Label labelDecrypted;
        private Button buttonTeamInfo;
        private Button buttonHelp;
        private PictureBox pictureBoxHelp;
        private Button buttonReset;
        private Label labelPlaintextBits;
        private Label labelCiphertextBits;
        private Label labelDecryptedBits;



        public Form1()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
          
                // Thiết lập Form
                this.Text = "Stream Cipher - CI";
                this.Size = new System.Drawing.Size(720, 500);
                this.StartPosition = FormStartPosition.CenterScreen;

                // Tiêu đề
                Label labelTitle = new Label();
                labelTitle.Text = "Thuật toán mã hóa Stream Cipher";
                labelTitle.Font = new Font("Arial", 14, FontStyle.Bold);
                labelTitle.ForeColor = Color.Red;
                labelTitle.Location = new Point(180, 15);
                labelTitle.Size = new Size(350, 30);
                labelTitle.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(labelTitle);

            // Button Team Info & Help
            buttonTeamInfo = new Button();
            buttonTeamInfo.Text = "Nhóm thực hiện";
            buttonTeamInfo.Location = new System.Drawing.Point(430, 60);
            buttonTeamInfo.Size = new Size(120, 25);
            buttonTeamInfo.Click += new EventHandler(buttonTeamInfo_Click);
            this.Controls.Add(buttonTeamInfo);

            buttonHelp = new Button();
            buttonHelp.Text = "Trợ giúp";
            buttonHelp.Location = new Point(560, 60);
            buttonHelp.Size = new Size(120, 25);
            buttonHelp.Click += new EventHandler(btnHelp_Click);
            this.Controls.Add(buttonHelp);

            // Tạo GroupBox cho phần thuật toán và khóa
            GroupBox groupBoxAlgorithmKey = new GroupBox();
                groupBoxAlgorithmKey.Text = "Thuật toán và khóa";
                groupBoxAlgorithmKey.Location = new Point(20, 90);
                groupBoxAlgorithmKey.Size = new Size(320, 220);
                this.Controls.Add(groupBoxAlgorithmKey);

                // Label Algorithm
                labelAlgorithm = new Label();
                labelAlgorithm.Text = "Chọn thuật toán:";
                labelAlgorithm.Location = new System.Drawing.Point(20, 30);
                labelAlgorithm.Size = new System.Drawing.Size(100, 20);
                groupBoxAlgorithmKey.Controls.Add(labelAlgorithm);

                // ComboBox Algorithm
                comboBoxAlgorithm = new ComboBox();
                comboBoxAlgorithm.Location = new System.Drawing.Point(130, 30);
                comboBoxAlgorithm.Size = new System.Drawing.Size(150, 30);
                comboBoxAlgorithm.Items.Add("RC4");
                comboBoxAlgorithm.Items.Add("OTP");
                comboBoxAlgorithm.Items.Add("A5/1");
                comboBoxAlgorithm.SelectedIndex = 0; // Mặc định chọn RC4
                groupBoxAlgorithmKey.Controls.Add(comboBoxAlgorithm);

                // Label Key
                labelKey = new Label();
                labelKey.Text = "Key:";
                labelKey.Location = new System.Drawing.Point(20, 70);
                labelKey.Size = new System.Drawing.Size(100, 20);
                groupBoxAlgorithmKey.Controls.Add(labelKey);

                // TextBox Key
                textBoxKey = new TextBox();
                textBoxKey.Location = new System.Drawing.Point(130, 70);
                textBoxKey.Size = new System.Drawing.Size(170, 20);
                groupBoxAlgorithmKey.Controls.Add(textBoxKey);

                // Label Key Bits 
                labelKeyBits = new Label();
                labelKeyBits.Text = "Key Bits:";
                labelKeyBits.Location = new System.Drawing.Point(20, 100);
                labelKeyBits.Size = new System.Drawing.Size(100, 20);
                groupBoxAlgorithmKey.Controls.Add(labelKeyBits);

                // TextBox Key Bits 
                textBoxKeyBits = new TextBox();
                textBoxKeyBits.Location = new System.Drawing.Point(130, 100);
                textBoxKeyBits.Size = new System.Drawing.Size(170, 20);
                textBoxKeyBits.ReadOnly = true;
                groupBoxAlgorithmKey.Controls.Add(textBoxKeyBits);

                // Label Keystream Bits
                labelKeystreamBits = new Label();
                labelKeystreamBits.Text = "Keystream:";
                labelKeystreamBits.Location = new System.Drawing.Point(20, 130);
                labelKeystreamBits.Size = new System.Drawing.Size(100, 20);
                groupBoxAlgorithmKey.Controls.Add(labelKeystreamBits);

                // TextBox Keystream Bits 
                textBoxKeystreamBits = new TextBox();
                textBoxKeystreamBits.Location = new System.Drawing.Point(130, 130);
                textBoxKeystreamBits.Size = new System.Drawing.Size(170, 20);
                textBoxKeystreamBits.ReadOnly = true;
                groupBoxAlgorithmKey.Controls.Add(textBoxKeystreamBits);

                // Button Generate Key
                buttonGenerateKey = new Button();
                buttonGenerateKey.Text = "Tạo khóa";
                buttonGenerateKey.Location = new System.Drawing.Point(130, 170);
                buttonGenerateKey.Size = new System.Drawing.Size(80, 30);
                buttonGenerateKey.Click += new EventHandler(buttonGenerateKey_Click);
                groupBoxAlgorithmKey.Controls.Add(buttonGenerateKey);

                // Button Reset
                buttonReset = new Button();
                buttonReset.Text = "Reset";
                buttonReset.Location = new System.Drawing.Point(220, 170);
                buttonReset.Size = new System.Drawing.Size(80, 30);
                buttonReset.Click += new EventHandler(buttonReset_Click);
                groupBoxAlgorithmKey.Controls.Add(buttonReset);

                /*// Button Team Info & Help
                buttonTeamInfo = new Button();
                buttonTeamInfo.Text = "Nhóm thực hiện";
                buttonTeamInfo.Location = new System.Drawing.Point(130, 60);
                buttonTeamInfo.Size = new Size(80, 30);
                buttonTeamInfo.Click += new EventHandler(buttonTeamInfo_Click);
                groupBoxAlgorithmKey.Controls.Add(buttonTeamInfo);

            buttonHelp = new Button();
                buttonHelp.Text = "Trợ giúp";
                buttonHelp.Location = new Point(220, 60);
                buttonHelp.Size = new Size(80, 30);
                buttonHelp.Click += new EventHandler(btnHelp_Click);
            groupBoxAlgorithmKey.Controls.Add(buttonHelp);*/

            // Tạo GroupBox cho phần mã hóa/giải mã
            GroupBox groupBoxEncryptionDecryption = new GroupBox();
                groupBoxEncryptionDecryption.Text = "Mã hóa/Giải mã";
                groupBoxEncryptionDecryption.Location = new Point(360, 90);
                groupBoxEncryptionDecryption.Size = new Size(320, 330);
                this.Controls.Add(groupBoxEncryptionDecryption);

                // Label Plaintext
                labelPlaintext = new Label();
                labelPlaintext.Text = "Bản rõ:";
                labelPlaintext.Location = new System.Drawing.Point(20, 30);
                labelPlaintext.Size = new System.Drawing.Size(60, 20);
                groupBoxEncryptionDecryption.Controls.Add(labelPlaintext);

                // TextBox Plaintext
                textBoxPlaintext = new TextBox();
                textBoxPlaintext.Location = new System.Drawing.Point(80, 30);
                textBoxPlaintext.Size = new System.Drawing.Size(210, 20);
                groupBoxEncryptionDecryption.Controls.Add(textBoxPlaintext);

                // Label Plaintext Bits
                labelPlaintextBits = new Label();
                labelPlaintextBits.Text = "Bit bản rõ:";
                labelPlaintextBits.Location = new System.Drawing.Point(20, 60);
                labelPlaintextBits.Size = new System.Drawing.Size(60, 20);
                groupBoxEncryptionDecryption.Controls.Add(labelPlaintextBits);

                // TextBox Plaintext Bits
                textBoxPlaintextBits = new TextBox();
                textBoxPlaintextBits.Location = new System.Drawing.Point(80, 60);
                textBoxPlaintextBits.Size = new System.Drawing.Size(210, 20);
                textBoxPlaintextBits.ReadOnly = true;
                groupBoxEncryptionDecryption.Controls.Add(textBoxPlaintextBits);

                // Label Ciphertext
                labelCiphertext = new Label();
                labelCiphertext.Text = "Bản mã:";
                labelCiphertext.Location = new System.Drawing.Point(20, 120);
                labelCiphertext.Size = new System.Drawing.Size(60, 20);
                groupBoxEncryptionDecryption.Controls.Add(labelCiphertext);

                // TextBox Ciphertext
                textBoxCiphertext = new TextBox();
                textBoxCiphertext.Location = new System.Drawing.Point(80, 120);
                textBoxCiphertext.Size = new System.Drawing.Size(210, 20);
                groupBoxEncryptionDecryption.Controls.Add(textBoxCiphertext);

                // Label Ciphertext Bits
                labelCiphertextBits = new Label();
                labelCiphertextBits.Text = "Bit bản mã:";
                labelCiphertextBits.Location = new System.Drawing.Point(20, 150);
                labelCiphertextBits.Size = new System.Drawing.Size(60, 20);
                groupBoxEncryptionDecryption.Controls.Add(labelCiphertextBits);

                // TextBox Ciphertext Bits
                textBoxCiphertextBits = new TextBox();
                textBoxCiphertextBits.Location = new System.Drawing.Point(80, 150);
                textBoxCiphertextBits.Size = new System.Drawing.Size(210, 20);
                textBoxCiphertextBits.ReadOnly = true;
                groupBoxEncryptionDecryption.Controls.Add(textBoxCiphertextBits);

                // Label Decrypted
                labelDecrypted = new Label();
                labelDecrypted.Text = "Đã giải mã:";
                labelDecrypted.Location = new System.Drawing.Point(20, 210);
                labelDecrypted.Size = new System.Drawing.Size(60, 20);
                groupBoxEncryptionDecryption.Controls.Add(labelDecrypted);

                // TextBox Decrypted
                textBoxDecrypted = new TextBox();
                textBoxDecrypted.Location = new System.Drawing.Point(80, 210);
                textBoxDecrypted.Size = new System.Drawing.Size(210, 20);
                groupBoxEncryptionDecryption.Controls.Add(textBoxDecrypted);

                // Label Decrypted Bits
                labelDecryptedBits = new Label();
                labelDecryptedBits.Text = "Bit đã giải mã:";
                labelDecryptedBits.Location = new System.Drawing.Point(20, 240);
                labelDecryptedBits.Size = new System.Drawing.Size(60, 20);
                groupBoxEncryptionDecryption.Controls.Add(labelDecryptedBits);

                // TextBox Decrypted Bits
                textBoxDecryptedBits = new TextBox();
                textBoxDecryptedBits.Location = new System.Drawing.Point(80, 240);
                textBoxDecryptedBits.Size = new System.Drawing.Size(210, 20);
                textBoxDecryptedBits.ReadOnly = true;
                groupBoxEncryptionDecryption.Controls.Add(textBoxDecryptedBits);

                // Button Encrypt
                buttonEncrypt = new Button();
                buttonEncrypt.Text = "Mã hóa";
                buttonEncrypt.Location = new System.Drawing.Point(80, 280);
                buttonEncrypt.Size = new System.Drawing.Size(65, 30);
                buttonEncrypt.Click += new EventHandler(buttonEncrypt_Click);
                groupBoxEncryptionDecryption.Controls.Add(buttonEncrypt);

                // Button Decrypt
                buttonDecrypt = new Button();
                buttonDecrypt.Text = "Giải mã";
                buttonDecrypt.Location = new System.Drawing.Point(150, 280);
                buttonDecrypt.Size = new System.Drawing.Size(65, 30);
                buttonDecrypt.Click += new EventHandler(buttonDecrypt_Click);
                groupBoxEncryptionDecryption.Controls.Add(buttonDecrypt);

                // Button Thoát
                Button buttonExit = new Button();
                buttonExit.Text = "Thoát";
                buttonExit.Location = new System.Drawing.Point(220, 280);
                buttonExit.Size = new System.Drawing.Size(65, 30);
                buttonExit.Click += (s, e) => { this.Close(); };
                groupBoxEncryptionDecryption.Controls.Add(buttonExit);
            
        }
        #region "Sự kiện các nút cơ bản"
        // Nút Nhóm thực hiện
        private void buttonTeamInfo_Click(object sender, EventArgs e)
        {
            string message = "Nhóm 10:\n" +
                             "- 2251120049 - Nguyễn Giang Thành Tài\n" +
                             "- 2251120182-Nguyễn Ngọc Quận\n" +
                             "- 2251120098 -Trịnh Thị Nghĩa\n" +
                             "- 2251120165 - Nguyễn Khao";
            MessageBox.Show(message, "Thông tin nhóm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút Trợ giúp

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string imagePath = Path.Combine(Application.StartupPath, "SC.jpg");

            if (!File.Exists(imagePath))
            {
                MessageBox.Show("Không tìm thấy ảnh trợ giúp!");
                return;
            }

            Form popup = new Form();
            popup.Text = "Sơ đồ nguyên lý";
            popup.Size = new Size(500, 300);
            popup.StartPosition = FormStartPosition.CenterParent;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = Image.FromFile(imagePath); // Load từ file
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            popup.Controls.Add(pictureBox);
            popup.ShowDialog();
        }


        // Sự kiện nút Generate Key
        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            string generatedKey = GenerateRandomKey();
            textBoxKey.Text = generatedKey;
            textBoxKeyBits.Text = BytesToBitString(Encoding.UTF8.GetBytes(generatedKey));
        }
        #endregion


        #region "Hàm sinh khóa và keystream các thuật toán"

        #region "Sinh Key Ngẫu nhiên và Chuyển đổi sang Bit"
        private string GenerateRandomKey()
        {
            byte[] keyBytes = new byte[16];
            Random rnd = new Random();
            rnd.NextBytes(keyBytes);
            return Convert.ToBase64String(keyBytes);
        }

        private string BytesToBitString(byte[] bytes)
        {
            StringBuilder bitString = new StringBuilder();
            foreach (byte b in bytes)
            {
                bitString.Append(Convert.ToString(b, 2).PadLeft(8, '0') + " ");
            }
            return bitString.ToString().Trim();
        }
        #endregion

        // Hàm sinh keystream

        #region "Keystream RC4"
        private byte[] GenerateRC4Keystream(byte[] key, int length)
        {
            byte[] S = new byte[256];
            byte[] keystream = new byte[length];
            int keyLength = key.Length;

            // 1. Khởi tạo mảng S
            for (int i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
            }

            // 2. Hoán vị mảng S bằng khóa (Key-Scheduling Algorithm - KSA)
            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % keyLength]) %256;
                // Hoán vị S[i] và S[j]
                (S[j], S[i]) = (S[i], S[j]);
            }

            // 3. Sinh keystream (Pseudo-Random Generation Algorithm - PRGA)
            int iIndex = 0;
            j = 0;
            for (int n = 0; n < length; n++)
            {
                iIndex = (iIndex + 1) % 256;
                j = (j + S[iIndex]) % 256;

                // Hoán vị S[iIndex] và S[j]
                (S[j], S[iIndex]) = (S[iIndex], S[j]);

                // Sinh byte keystream
                int t = (S[iIndex] + S[j]) % 256;
                keystream[n] = S[t];
            }

            return keystream;
        }

        #endregion

        #region "Keystream A5/1"
        private byte[] GenerateA51Keystream(byte[] key, int length)
        {
            byte[] keystream = new byte[length];
            
            return keystream;
        }
        #endregion

        #region "Keystream OTP"
        private byte[] GenerateOTPKeystream(byte[] key, int length)
        {
            if (key.Length < length)
            {
                throw new ArgumentException("Khóa OTP phải dài ít nhất bằng plaintext!");
            }
            byte[] keystream = new byte[length];
            Array.Copy(key, keystream, length);
            return keystream;
        }

        #endregion

        #endregion


        #region "Hàm mã hóa và giải mã chung"

        #region "Mã hóa chung"
        // Hàm mã hóa 
        private string Encrypt(string plaintext, byte[] keystream)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            if (keystream.Length < plaintextBytes.Length)
            {
                throw new ArgumentException("Keystream phải dài ít nhất bằng plaintext!");
            }

            byte[] ciphertextBytes = new byte[plaintextBytes.Length];
            for (int i = 0; i < plaintextBytes.Length; i++)
            {
                ciphertextBytes[i] = (byte)(plaintextBytes[i] ^ keystream[i]);
            }

            // Trả về chuỗi Base64 thay vì byte thô để tránh lỗi encoding
            return Convert.ToBase64String(ciphertextBytes);
        }
        #endregion

        #region "Giải mã chung"
        // Hàm giải mã 
        private string Decrypt(string ciphertext, byte[] keystream)
        {
            byte[] ciphertextBytes = Convert.FromBase64String(ciphertext); // Ciphertext là Base64
            if (keystream.Length < ciphertextBytes.Length)
            {
                throw new ArgumentException("Keystream phải dài ít nhất bằng ciphertext!");
            }

            byte[] decryptedBytes = new byte[ciphertextBytes.Length];
            for (int i = 0; i < ciphertextBytes.Length; i++)
            {
                decryptedBytes[i] = (byte)(ciphertextBytes[i] ^ keystream[i]);
            }

            // Chuyển byte về chuỗi UTF-8 để hỗ trợ tiếng Việt
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        #endregion

        #endregion


        #region "Sự kiện các nút Mã hóa và Giải mã"
        // Sự kiện nút Encrypt 
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            string key = textBoxKey.Text;
            string plaintext = textBoxPlaintext.Text;
            string selectedAlgorithm = comboBoxAlgorithm.SelectedItem.ToString();

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(plaintext))
            {
                MessageBox.Show("Vui lòng nhập khóa và plaintext!");
                return;
            }

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            textBoxKeyBits.Text = BytesToBitString(keyBytes);
            textBoxPlaintextBits.Text = BytesToBitString(Encoding.UTF8.GetBytes(plaintext));

            byte[] keystream;
            string ciphertext = "";

            try
            {
                if (selectedAlgorithm == "RC4")
                {
                    keystream = GenerateRC4Keystream(keyBytes, Encoding.UTF8.GetBytes(plaintext).Length);
                    textBoxKeystreamBits.Text = BytesToBitString(keystream);
                    ciphertext = Encrypt(plaintext, keystream);
                }
                else if (selectedAlgorithm == "OTP")
                {
                    keystream = GenerateOTPKeystream(keyBytes, Encoding.UTF8.GetBytes(plaintext).Length);
                    textBoxKeystreamBits.Text = BytesToBitString(keystream);
                    ciphertext = Encrypt(plaintext, keystream);
                }
                else if (selectedAlgorithm == "A5/1")
                {
                    keystream = GenerateA51Keystream(keyBytes, Encoding.UTF8.GetBytes(plaintext).Length);
                    textBoxKeystreamBits.Text = BytesToBitString(keystream);
                    ciphertext = Encrypt(plaintext, keystream);
                }

                textBoxCiphertext.Text = ciphertext;
                textBoxCiphertextBits.Text = BytesToBitString(Convert.FromBase64String(ciphertext));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện nút Decrypt 
        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            string key = textBoxKey.Text;
            string ciphertext = textBoxCiphertext.Text;
            string selectedAlgorithm = comboBoxAlgorithm.SelectedItem.ToString();

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(ciphertext))
            {
                MessageBox.Show("Vui lòng nhập khóa và ciphertext!");
                return;
            }

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            textBoxKeyBits.Text = BytesToBitString(keyBytes);

            byte[] keystream;
            string decrypted = "";

            try
            {
                if (selectedAlgorithm == "RC4")
                {
                    keystream = GenerateRC4Keystream(keyBytes, Convert.FromBase64String(ciphertext).Length);
                    textBoxKeystreamBits.Text = BytesToBitString(keystream);
                    decrypted = Decrypt(ciphertext, keystream);
                }
                else if (selectedAlgorithm == "OTP")
                {
                    keystream = GenerateOTPKeystream(keyBytes, Convert.FromBase64String(ciphertext).Length);
                    textBoxKeystreamBits.Text = BytesToBitString(keystream);
                    decrypted = Decrypt(ciphertext, keystream);
                }
                else if (selectedAlgorithm == "A5/1")
                {
                    keystream = GenerateA51Keystream(keyBytes, Convert.FromBase64String(ciphertext).Length);
                    textBoxKeystreamBits.Text = BytesToBitString(keystream);
                    decrypted = Decrypt(ciphertext, keystream);
                }

                textBoxDecrypted.Text = decrypted;
                textBoxDecryptedBits.Text = BytesToBitString(Encoding.UTF8.GetBytes(decrypted));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        

        private void buttonReset_Click(object sender, EventArgs e)
        {
           
            if (textBoxKey != null) textBoxKey.Text = "";
            if (textBoxKeyBits != null) textBoxKeyBits.Text = "";
            if (textBoxPlaintext != null) textBoxPlaintext.Text = "";
            if (textBoxPlaintextBits != null) textBoxPlaintextBits.Text = "";
            if (textBoxKeystreamBits != null) textBoxKeystreamBits.Text = "";
            if (textBoxCiphertext != null) textBoxCiphertext.Text = "";
            if (textBoxCiphertextBits != null) textBoxCiphertextBits.Text = "";
            if (textBoxDecrypted != null) textBoxDecrypted.Text = "";
            if (textBoxDecryptedBits != null) textBoxDecryptedBits.Text = "";
            if (pictureBoxHelp != null) pictureBoxHelp.Visible = false;
            if (comboBoxAlgorithm != null) comboBoxAlgorithm.SelectedIndex = 0;
        }
    }
}
