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
        private Button buttonTeamInfo;
        private Button buttonHelp;
        private PictureBox pictureBoxHelp;
        private Button buttonReset;
        


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
            labelAlgorithm.Location = new System.Drawing.Point(20, 40);
            labelAlgorithm.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelAlgorithm);

            // ComboBox Algorithm
            comboBoxAlgorithm = new ComboBox();
            comboBoxAlgorithm.Location = new System.Drawing.Point(130, 40);
            comboBoxAlgorithm.Size = new System.Drawing.Size(150, 30);
            comboBoxAlgorithm.Items.Add("RC4");
            comboBoxAlgorithm.Items.Add("ChaCha20 (Basic)");
            comboBoxAlgorithm.Items.Add("A5/1");
            comboBoxAlgorithm.SelectedIndex = 0; // Mặc định chọn RC4
            this.Controls.Add(comboBoxAlgorithm);

            // Label Key
            labelKey = new Label();
            labelKey.Text = "Khóa:";
            labelKey.Location = new System.Drawing.Point(20, 80);
            labelKey.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelKey);

            // TextBox Key
            textBoxKey = new TextBox();
            textBoxKey.Location = new System.Drawing.Point(130, 80);
            textBoxKey.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(textBoxKey);

            // Button Generate Key
            buttonGenerateKey = new Button();
            buttonGenerateKey.Text = "Generate Key";
            buttonGenerateKey.Location = new System.Drawing.Point(440, 80);
            buttonGenerateKey.Size = new System.Drawing.Size(100, 20);
            buttonGenerateKey.Click += new EventHandler(buttonGenerateKey_Click);
            this.Controls.Add(buttonGenerateKey);

            // Label Plaintext
            labelPlaintext = new Label();
            labelPlaintext.Text = "Plaintext:";
            labelPlaintext.Location = new System.Drawing.Point(20, 120);
            labelPlaintext.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelPlaintext);

            // TextBox Plaintext
            textBoxPlaintext = new TextBox();
            textBoxPlaintext.Location = new System.Drawing.Point(130, 120);
            textBoxPlaintext.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(textBoxPlaintext);

            // Label Ciphertext
            labelCiphertext = new Label();
            labelCiphertext.Text = "Ciphertext:";
            labelCiphertext.Location = new System.Drawing.Point(20, 160);
            labelCiphertext.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelCiphertext);

            // TextBox Ciphertext
            textBoxCiphertext = new TextBox();
            textBoxCiphertext.Location = new System.Drawing.Point(130, 160);
            textBoxCiphertext.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(textBoxCiphertext);

            // Label Decrypted
            labelDecrypted = new Label();
            labelDecrypted.Text = "Decrypted:";
            labelDecrypted.Location = new System.Drawing.Point(20, 200);
            labelDecrypted.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(labelDecrypted);

            // TextBox Decrypted
            textBoxDecrypted = new TextBox();
            textBoxDecrypted.Location = new System.Drawing.Point(130, 200);
            textBoxDecrypted.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(textBoxDecrypted);

            // Button Encrypt
            buttonEncrypt = new Button();
            buttonEncrypt.Text = "Encrypt";
            buttonEncrypt.Location = new System.Drawing.Point(130, 240);
            buttonEncrypt.Size = new System.Drawing.Size(80, 30);
            buttonEncrypt.Click += new EventHandler(buttonEncrypt_Click);
            this.Controls.Add(buttonEncrypt);

            // Button Decrypt
            buttonDecrypt = new Button();
            buttonDecrypt.Text = "Decrypt";
            buttonDecrypt.Location = new System.Drawing.Point(240, 240);
            buttonDecrypt.Size = new System.Drawing.Size(80, 30);
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
            buttonReset.Location = new Point(350, 240);
            buttonReset.Size = new Size(80, 30);
            buttonReset.Click += new EventHandler(buttonReset_Click);
            this.Controls.Add(buttonReset);


        }

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
            else if (selectedAlgorithm == "A5/1")
            {
                ciphertext = A51Encrypt(plaintext, key);
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
            else if (selectedAlgorithm == "A5/1")
            {
                decrypted = A51Decrypt(ciphertext, key);
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


        // Thuật toán A5/1
        private string A51Encrypt(string plaintext, string key)
        {
            // Chuyển đổi dữ liệu đầu vào
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] keyBytes = ConvertKeyToBytes(key);
            byte[] ciphertextBytes = new byte[plaintextBytes.Length];

            // Khởi tạo thanh ghi dịch với phản hồi tuyến tính (LFSR)
            bool[] R1 = new bool[19]; // 19-bit register
            bool[] R2 = new bool[22]; // 22-bit register
            bool[] R3 = new bool[23]; // 23-bit register

            // Khởi tạo các thanh ghi từ khóa
            InitializeRegisters(R1, R2, R3, keyBytes);

            // Thuật toán A5/1 cơ bản
            for (int i = 0; i < plaintextBytes.Length; i++)
            {
                byte keystreamByte = 0;

                // Tạo 8 bit keystream cho mỗi byte
                for (int j = 0; j < 8; j++)
                {
                    // Quyết định thanh ghi nào được cập nhật (theo cơ chế đa số)
                    bool majorityBit = Majority(R1[8], R2[10], R3[10]);

                    // Cập nhật các thanh ghi theo bit đa số
                    if (R1[8] == majorityBit)
                        ShiftRegister(R1, 13, 16, 17, 18);

                    if (R2[10] == majorityBit)
                        ShiftRegister(R2, 20, 21);

                    if (R3[10] == majorityBit)
                        ShiftRegister(R3, 7, 20, 21, 22);

                    // Lấy bit keystream từ bit đầu ra của mỗi thanh ghi
                    bool keystreamBit = R1[18] ^ R2[21] ^ R3[22];

                    // Thêm bit vào byte keystream
                    keystreamByte = (byte)((keystreamByte << 1) | (keystreamBit ? 1 : 0));
                }

                // XOR với byte plaintext để có byte ciphertext
                ciphertextBytes[i] = (byte)(plaintextBytes[i] ^ keystreamByte);
            }

            return Convert.ToBase64String(ciphertextBytes);
        }

        private string A51Decrypt(string ciphertext, string key)
        {
            // Giải mã thực tế giống với mã hóa trong mã dòng (XOR lại với cùng một dòng khóa)
            byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);
            byte[] keyBytes = ConvertKeyToBytes(key);
            byte[] decryptedBytes = new byte[ciphertextBytes.Length];

            // Khởi tạo thanh ghi dịch
            bool[] R1 = new bool[19];
            bool[] R2 = new bool[22];
            bool[] R3 = new bool[23];

            // Khởi tạo các thanh ghi từ khóa
            InitializeRegisters(R1, R2, R3, keyBytes);

            // Thuật toán A5/1 cơ bản (giống với mã hóa)
            for (int i = 0; i < ciphertextBytes.Length; i++)
            {
                byte keystreamByte = 0;

                for (int j = 0; j < 8; j++)
                {
                    bool majorityBit = Majority(R1[8], R2[10], R3[10]);

                    if (R1[8] == majorityBit)
                        ShiftRegister(R1, 13, 16, 17, 18);

                    if (R2[10] == majorityBit)
                        ShiftRegister(R2, 20, 21);

                    if (R3[10] == majorityBit)
                        ShiftRegister(R3, 7, 20, 21, 22);

                    bool keystreamBit = R1[18] ^ R2[21] ^ R3[22];
                    keystreamByte = (byte)((keystreamByte << 1) | (keystreamBit ? 1 : 0));
                }

                decryptedBytes[i] = (byte)(ciphertextBytes[i] ^ keystreamByte);
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        // Chuyển đổi khóa từ chuỗi sang mảng byte 8 byte (64 bit)
        private byte[] ConvertKeyToBytes(string key)
        {
            // Lấy 8 byte đầu tiên từ khóa (hoặc padding nếu khóa ngắn hơn)
            byte[] keyData = Encoding.UTF8.GetBytes(key);
            byte[] result = new byte[8]; // A5/1 sử dụng khóa 64-bit

            for (int i = 0; i < 8; i++)
            {
                result[i] = (i < keyData.Length) ? keyData[i] : (byte)0;
            }

            return result;
        }

        // Khởi tạo các thanh ghi từ khóa
        private void InitializeRegisters(bool[] R1, bool[] R2, bool[] R3, byte[] key)
        {
            // Đặt tất cả các bit thành 0
            Array.Clear(R1, 0, R1.Length);
            Array.Clear(R2, 0, R2.Length);
            Array.Clear(R3, 0, R3.Length);

            // Đưa 64 bit của khóa vào các thanh ghi
            for (int i = 0; i < 64; i++)
            {
                // Lấy bit thứ i từ khóa
                bool keyBit = ((key[i / 8] >> (7 - (i % 8))) & 1) == 1;

                // XOR bit khóa với bit phản hồi của mỗi thanh ghi và shift
                ShiftWithKeyBit(R1, keyBit, 13, 16, 17, 18);
                ShiftWithKeyBit(R2, keyBit, 20, 21);
                ShiftWithKeyBit(R3, keyBit, 7, 20, 21, 22);
            }

            // Thêm 22 chu kỳ đồng bộ hóa khung
            for (int i = 0; i < 22; i++)
            {
                // Trong giai đoạn này, chúng ta cũng sử dụng cơ chế đa số
                bool majorityBit = Majority(R1[8], R2[10], R3[10]);

                if (R1[8] == majorityBit)
                    ShiftRegister(R1, 13, 16, 17, 18);

                if (R2[10] == majorityBit)
                    ShiftRegister(R2, 20, 21);

                if (R3[10] == majorityBit)
                    ShiftRegister(R3, 7, 20, 21, 22);
            }
        }

        // Tính toán bit đa số từ 3 bit
        private bool Majority(bool a, bool b, bool c)
        {
            return (a && b) || (a && c) || (b && c);
        }

        // Dịch thanh ghi với XOR các bit phản hồi
        private void ShiftRegister(bool[] register, params int[] taps)
        {
            // Tính toán bit phản hồi từ các vị trí tap
            bool feedback = false;
            foreach (int tap in taps)
            {
                feedback ^= register[tap];
            }

            // Dịch phải toàn bộ thanh ghi
            for (int i = register.Length - 1; i > 0; i--)
            {
                register[i] = register[i - 1];
            }

            // Đặt bit phản hồi vào vị trí đầu tiên
            register[0] = feedback;
        }

        // Dịch thanh ghi với bit khóa thêm vào phản hồi
        private void ShiftWithKeyBit(bool[] register, bool keyBit, params int[] taps)
        {
            // Tính toán bit phản hồi từ các vị trí tap
            bool feedback = false;
            foreach (int tap in taps)
            {
                feedback ^= register[tap];
            }

            // XOR bit phản hồi với bit khóa
            feedback ^= keyBit;

            // Dịch phải toàn bộ thanh ghi
            for (int i = register.Length - 1; i > 0; i--)
            {
                register[i] = register[i - 1];
            }

            // Đặt bit phản hồi vào vị trí đầu tiên
            register[0] = feedback;
        }

        // Sự kiện nút Reset
        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxKey.Text = "";
            textBoxPlaintext.Text = "";
            textBoxCiphertext.Text = "";
            textBoxDecrypted.Text = "";

            // Ẩn sơ đồ trợ giúp nếu đang hiển thị
            pictureBoxHelp.Visible = false;

            // Đặt lại lựa chọn thuật toán (nếu muốn)
            comboBoxAlgorithm.SelectedIndex = 0;
        }

    }
}
