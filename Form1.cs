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
            this.Size = new System.Drawing.Size(720, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label Algorithm
            labelAlgorithm = new Label();
            labelAlgorithm.Text = "Chọn thuật toán:";
            labelAlgorithm.Location = new System.Drawing.Point(20, 40);
            labelAlgorithm.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelAlgorithm);

            // ComboBox Algorithm
            comboBoxAlgorithm = new ComboBox();
            comboBoxAlgorithm.Location = new System.Drawing.Point(130, 40);
            comboBoxAlgorithm.Size = new System.Drawing.Size(150, 30);
            comboBoxAlgorithm.Items.Add("RC4");
            comboBoxAlgorithm.Items.Add("OTP");
            comboBoxAlgorithm.Items.Add("A5/1");
            comboBoxAlgorithm.SelectedIndex = 0; // Mặc định chọn RC4
            this.Controls.Add(comboBoxAlgorithm);

            //Label Key
            labelKey = new Label();
            labelKey.Text = "Key:";
            labelKey.Location = new System.Drawing.Point(20, 90);
            labelKey.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelKey);

            // TextBox Key
            textBoxKey = new TextBox();
            textBoxKey.Location = new System.Drawing.Point(130, 90);
            textBoxKey.Size = new System.Drawing.Size(430, 20);
            this.Controls.Add(textBoxKey);

            // Button Generate Key
            buttonGenerateKey = new Button();
            buttonGenerateKey.Text = "Tạo khóa";
            buttonGenerateKey.Location = new System.Drawing.Point(570, 90);
            buttonGenerateKey.Size = new System.Drawing.Size(100, 20);
            buttonGenerateKey.Click += new EventHandler(buttonGenerateKey_Click);
            this.Controls.Add(buttonGenerateKey);

            // Label Key Bits 
            labelKeyBits = new Label();
            labelKeyBits.Text = "Key Bits:";
            labelKeyBits.Location = new System.Drawing.Point(20, 120);
            labelKeyBits.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelKeyBits);

            // TextBox Key Bits 
            textBoxKeyBits = new TextBox();
            textBoxKeyBits.Location = new System.Drawing.Point(130, 120);
            textBoxKeyBits.Size = new System.Drawing.Size(540, 20);
            textBoxKeyBits.ReadOnly = true;
            this.Controls.Add(textBoxKeyBits);

            // Label Plaintext
            labelPlaintext = new Label();
            labelPlaintext.Text = "Bản rõ:";
            labelPlaintext.Location = new System.Drawing.Point(20, 150);
            labelPlaintext.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelPlaintext);

            // TextBox Plaintext
            textBoxPlaintext = new TextBox();
            textBoxPlaintext.Location = new System.Drawing.Point(130, 150);
            textBoxPlaintext.Size = new System.Drawing.Size(540, 20);
            this.Controls.Add(textBoxPlaintext);

            // Label Plaintext Bits
            labelPlaintextBits = new Label();
            labelPlaintextBits.Text = "Bit bản rõ:";
            labelPlaintextBits.Location = new System.Drawing.Point(20, 180);
            labelPlaintextBits.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelPlaintextBits);

            textBoxPlaintextBits = new TextBox();
            textBoxPlaintextBits.Location = new System.Drawing.Point(130, 180);
            textBoxPlaintextBits.Size = new System.Drawing.Size(540, 20);
            textBoxPlaintextBits.ReadOnly = true;
            this.Controls.Add(textBoxPlaintextBits);

            // Label Keystream Bits
            labelKeystreamBits = new Label();
            labelKeystreamBits.Text = "Keystream Bits:";
            labelKeystreamBits.Location = new System.Drawing.Point(20, 210);
            labelKeystreamBits.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelKeystreamBits);

            // TextBox Keystream Bits 
            textBoxKeystreamBits = new TextBox();
            textBoxKeystreamBits.Location = new System.Drawing.Point(130, 210);
            textBoxKeystreamBits.Size = new System.Drawing.Size(540, 20);
            textBoxKeystreamBits.ReadOnly = true;
            this.Controls.Add(textBoxKeystreamBits);

            // Label Ciphertext
            labelCiphertext = new Label();
            labelCiphertext.Text = "Bản mã:";
            labelCiphertext.Location = new System.Drawing.Point(20, 240);
            labelCiphertext.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelCiphertext);

            // TextBox Ciphertext
            textBoxCiphertext = new TextBox();
            textBoxCiphertext.Location = new System.Drawing.Point(130, 240);
            textBoxCiphertext.Size = new System.Drawing.Size(540, 20);
            this.Controls.Add(textBoxCiphertext);

            // Label Ciphertext Bits
            labelCiphertextBits = new Label();
            labelCiphertextBits.Text = "Bit bản mã:";
            labelCiphertextBits.Location = new System.Drawing.Point(20, 270);
            labelCiphertextBits.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelCiphertextBits);

            // TextBox Ciphertext Bits
            textBoxCiphertextBits = new TextBox();
            textBoxCiphertextBits.Location = new System.Drawing.Point(130, 270);
            textBoxCiphertextBits.Size = new System.Drawing.Size(540, 20);
            textBoxCiphertextBits.ReadOnly = true;
            this.Controls.Add(textBoxCiphertextBits);

            // Label Decrypted
            labelDecrypted = new Label();
            labelDecrypted.Text = "Đã giải mã:";
            labelDecrypted.Location = new System.Drawing.Point(20, 300);
            labelDecrypted.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelDecrypted);

            // TextBox Decrypted
            textBoxDecrypted = new TextBox();
            textBoxDecrypted.Location = new System.Drawing.Point(130, 300);
            textBoxDecrypted.Size = new System.Drawing.Size(540, 20);
            this.Controls.Add(textBoxDecrypted);

            // Label Decrypted Bits
            labelDecryptedBits = new Label();
            labelDecryptedBits.Text = "Bit đã giải mã:";
            labelDecryptedBits.Location = new System.Drawing.Point(20, 330);
            labelDecryptedBits.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelDecryptedBits);

            // TextBox Decrypted Bits
            textBoxDecryptedBits = new TextBox();
            textBoxDecryptedBits.Location = new System.Drawing.Point(130, 330);
            textBoxDecryptedBits.Size = new System.Drawing.Size(540, 20);
            textBoxDecryptedBits.ReadOnly = true;
            this.Controls.Add(textBoxDecryptedBits);


            // Button Encrypt
            buttonEncrypt = new Button();
            buttonEncrypt.Text = "Mã hóa";
            buttonEncrypt.Location = new System.Drawing.Point(130, 370);
            buttonEncrypt.Size = new System.Drawing.Size(100, 30);
            buttonEncrypt.Click += new EventHandler(buttonEncrypt_Click);
            this.Controls.Add(buttonEncrypt);

            // Button Decrypt
            buttonDecrypt = new Button();
            buttonDecrypt.Text = "Giải mã";
            buttonDecrypt.Location = new System.Drawing.Point(250, 370);
            buttonDecrypt.Size = new System.Drawing.Size(100, 30);
            buttonDecrypt.Click += new EventHandler(buttonDecrypt_Click);
            this.Controls.Add(buttonDecrypt);
          

            // Tiêu đề
            Label labelTitle = new Label();
            labelTitle.Text = "StreamCipher - CIA - 10";
            labelTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            labelTitle.Location = new Point(180, 0);
            labelTitle.Size = new Size(300, 30);
            this.Controls.Add(labelTitle);

            // Nút nhóm thực hiện
            buttonTeamInfo = new Button();
            buttonTeamInfo.Text = "Nhóm thực hiện";
            buttonTeamInfo.Location = new System.Drawing.Point(330, 40);
            buttonTeamInfo.Size = new Size(100, 25);
            buttonTeamInfo.Click += new EventHandler(buttonTeamInfo_Click);
            this.Controls.Add(buttonTeamInfo);

            // Nút trợ giúp
            buttonHelp = new Button();
            buttonHelp.Text = "Trợ giúp";
            buttonHelp.Location = new Point(440, 40);
            buttonHelp.Size = new Size(100, 25);
            buttonHelp.Click += new EventHandler(btnHelp_Click);
            this.Controls.Add(buttonHelp);

            // PictureBox để hiển thị sơ đồ trợ giúp
            pictureBoxHelp = new PictureBox();
            pictureBoxHelp.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxHelp.Location = new Point(20, 310);
            pictureBoxHelp.Size = new Size(520, 200); // Tuỳ chỉnh kích thước nếu muốn
            pictureBoxHelp.Visible = false;
            this.Controls.Add(pictureBoxHelp);

            // Nút Reset
            buttonReset = new Button();
            buttonReset.Text = "Reset";
            buttonReset.Location = new Point(370, 370);
            buttonReset.Size = new Size(100, 30);
            buttonReset.Click += new EventHandler(buttonReset_Click);
            this.Controls.Add(buttonReset);


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

        #region "Keystream RC"
        private byte[] GenerateRC4Keystream(byte[] key, int length)
        {
            byte[] S = new byte[256];
            byte[] keystream = new byte[length];
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
            textBoxKey.Text = "";
            textBoxKeyBits.Text = "";
            textBoxPlaintext.Text = "";
            textBoxPlaintextBits.Text = "";
            textBoxKeystreamBits.Text = "";
            textBoxCiphertext.Text = "";
            textBoxCiphertextBits.Text = "";
            textBoxDecrypted.Text = "";
            textBoxDecryptedBits.Text = "";
            pictureBoxHelp.Visible = false;
            comboBoxAlgorithm.SelectedIndex = 0;
        }
    }
}
