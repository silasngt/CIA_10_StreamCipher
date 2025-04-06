using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIA_10_StreamCipher
{
    public partial class Form1: Form
    {
        // Khai báo các thành phần giao diện
        private ComboBox comboBoxAlgorithm;
        private TextBox textBoxKey;
        private TextBox textBoxPlaintext;
        private TextBox textBoxCiphertext;
        private TextBox textBoxDecrypted;
        private Button buttonEncrypt;
        private Button buttonDecrypt;
        private Button buttonGenerateKey; // Nút mới để tạo khóa
        private Label labelAlgorithm;
        private Label labelKey;
        private Label labelPlaintext;
        private Label labelCiphertext;
        private Label labelDecrypted;

        public Form1()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Thiết lập Form
            this.Text = "Stream Cipher Demo";
            this.Size = new System.Drawing.Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label Algorithm
            labelAlgorithm = new Label();
            labelAlgorithm.Text = "Chọn thuật toán:";
            labelAlgorithm.Location = new System.Drawing.Point(20, 20);
            labelAlgorithm.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelAlgorithm);

            // ComboBox Algorithm
            comboBoxAlgorithm = new ComboBox();
            comboBoxAlgorithm.Location = new System.Drawing.Point(130, 20);
            comboBoxAlgorithm.Size = new System.Drawing.Size(150, 20);
            comboBoxAlgorithm.Items.Add("RC4");
            comboBoxAlgorithm.Items.Add("ChaCha20 (Basic)");
            comboBoxAlgorithm.SelectedIndex = 0; // Mặc định chọn RC4
            this.Controls.Add(comboBoxAlgorithm);

            // Label Key
            labelKey = new Label();
            labelKey.Text = "Khóa:";
            labelKey.Location = new System.Drawing.Point(20, 60);
            labelKey.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelKey);

            // TextBox Key
            textBoxKey = new TextBox();
            textBoxKey.Location = new System.Drawing.Point(130, 60);
            textBoxKey.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(textBoxKey);

            // Button Generate Key
            buttonGenerateKey = new Button();
            buttonGenerateKey.Text = "Generate Key";
            buttonGenerateKey.Location = new System.Drawing.Point(440, 60);
            buttonGenerateKey.Size = new System.Drawing.Size(100, 20);
            buttonGenerateKey.Click += new EventHandler(buttonGenerateKey_Click);
            this.Controls.Add(buttonGenerateKey);

            // Label Plaintext
            labelPlaintext = new Label();
            labelPlaintext.Text = "Plaintext:";
            labelPlaintext.Location = new System.Drawing.Point(20, 100);
            labelPlaintext.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelPlaintext);

            // TextBox Plaintext
            textBoxPlaintext = new TextBox();
            textBoxPlaintext.Location = new System.Drawing.Point(130, 100);
            textBoxPlaintext.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(textBoxPlaintext);

            // Label Ciphertext
            labelCiphertext = new Label();
            labelCiphertext.Text = "Ciphertext:";
            labelCiphertext.Location = new System.Drawing.Point(20, 140);
            labelCiphertext.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelCiphertext);

            // TextBox Ciphertext
            textBoxCiphertext = new TextBox();
            textBoxCiphertext.Location = new System.Drawing.Point(130, 140);
            textBoxCiphertext.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(textBoxCiphertext);

            // Label Decrypted
            labelDecrypted = new Label();
            labelDecrypted.Text = "Decrypted:";
            labelDecrypted.Location = new System.Drawing.Point(20, 180);
            labelDecrypted.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelDecrypted);

            // TextBox Decrypted
            textBoxDecrypted = new TextBox();
            textBoxDecrypted.Location = new System.Drawing.Point(130, 180);
            textBoxDecrypted.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(textBoxDecrypted);

            // Button Encrypt
            buttonEncrypt = new Button();
            buttonEncrypt.Text = "Encrypt";
            buttonEncrypt.Location = new System.Drawing.Point(130, 220);
            buttonEncrypt.Size = new System.Drawing.Size(100, 30);
            buttonEncrypt.Click += new EventHandler(buttonEncrypt_Click);
            this.Controls.Add(buttonEncrypt);

            // Button Decrypt
            buttonDecrypt = new Button();
            buttonDecrypt.Text = "Decrypt";
            buttonDecrypt.Location = new System.Drawing.Point(250, 220);
            buttonDecrypt.Size = new System.Drawing.Size(100, 30);
            buttonDecrypt.Click += new EventHandler(buttonDecrypt_Click);
            this.Controls.Add(buttonDecrypt);
        }

        // Sự kiện nút Generate Key
        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            string generatedKey = GenerateRandomKey();
            textBoxKey.Text = generatedKey;
        }

        // Hàm tạo khóa ngẫu nhiên
        private string GenerateRandomKey()
        {
            byte[] keyBytes = new byte[16]; // Khóa 16 byte (128 bit)
            Random rnd = new Random();
            rnd.NextBytes(keyBytes); // Tạo mảng byte ngẫu nhiên
            return Convert.ToBase64String(keyBytes); // Chuyển thành chuỗi Base64
        }

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

            string ciphertext = "";
            if (selectedAlgorithm == "RC4")
            {
                ciphertext = RC4Encrypt(plaintext, key);
            }
            else if (selectedAlgorithm == "ChaCha20 (Basic)")
            {
                ciphertext = ChaCha20BasicEncrypt(plaintext, key);
            }

            textBoxCiphertext.Text = ciphertext;
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

            string decrypted = "";
            if (selectedAlgorithm == "RC4")
            {
                decrypted = RC4Decrypt(ciphertext, key);
            }
            else if (selectedAlgorithm == "ChaCha20 (Basic)")
            {
                decrypted = ChaCha20BasicDecrypt(ciphertext, key);
            }

            textBoxDecrypted.Text = decrypted;
        }

        // Thuật toán RC4
        private string RC4Encrypt(string plaintext, string key)
        {
            byte[] S = new byte[256];
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] ciphertextBytes = new byte[plaintextBytes.Length];

            for (int i = 0; i < 256; i++)
                S[i] = (byte)i;

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + keyBytes[i % keyBytes.Length]) % 256;
                byte temp = S[i];
                S[i] = S[j];
                S[j] = temp;
            }

            int x = 0, y = 0;
            for (int k = 0; k < plaintextBytes.Length; k++)
            {
                x = (x + 1) % 256;
                y = (y + S[x]) % 256;
                byte temp = S[x];
                S[x] = S[y];
                S[y] = temp;
                int t = (S[x] + S[y]) % 256;
                ciphertextBytes[k] = (byte)(plaintextBytes[k] ^ S[t]);
            }

            return Convert.ToBase64String(ciphertextBytes);
        }

        private string RC4Decrypt(string ciphertext, string key)
        {
            byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);
            byte[] decryptedBytes = new byte[ciphertextBytes.Length];
            byte[] S = new byte[256];
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            for (int i = 0; i < 256; i++)
                S[i] = (byte)i;

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + keyBytes[i % keyBytes.Length]) % 256;
                byte temp = S[i];
                S[i] = S[j];
                S[j] = temp;
            }

            int x = 0, y = 0;
            for (int k = 0; k < ciphertextBytes.Length; k++)
            {
                x = (x + 1) % 256;
                y = (y + S[x]) % 256;
                byte temp = S[x];
                S[x] = S[y];
                S[y] = temp;
                int t = (S[x] + S[y]) % 256;
                decryptedBytes[k] = (byte)(ciphertextBytes[k] ^ S[t]);
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        // Thuật toán ChaCha20 (Phiên bản đơn giản hóa)
        private string ChaCha20BasicEncrypt(string plaintext, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32, '\0'));
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] ciphertextBytes = new byte[plaintextBytes.Length];

            for (int i = 0; i < plaintextBytes.Length; i++)
            {
                ciphertextBytes[i] = (byte)(plaintextBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return Convert.ToBase64String(ciphertextBytes);
        }

        private string ChaCha20BasicDecrypt(string ciphertext, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32, '\0'));
            byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);
            byte[] decryptedBytes = new byte[ciphertextBytes.Length];

            for (int i = 0; i < ciphertextBytes.Length; i++)
            {
                decryptedBytes[i] = (byte)(ciphertextBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
