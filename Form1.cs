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
            // Tạo container chính cho layout
            TableLayoutPanel containerPanel = new TableLayoutPanel();
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.RowCount = 2;
            containerPanel.ColumnCount = 1;
            containerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // Header height
            containerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Main panel gets remaining space
            this.Controls.Add(containerPanel);

            // Thiết lập Form - làm to hơn để hiển thị đầy đủ nội dung
            this.Text = "Stream Cipher - Mã hóa dòng";
            this.Size = new System.Drawing.Size(900, 650);  // Tăng kích thước form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Panel chứa tiêu đề
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Fill;
            headerPanel.BackColor = Color.FromArgb(45, 66, 99);
            containerPanel.Controls.Add(headerPanel, 0, 0);

            // Tiêu đề
            Label labelTitle = new Label();
            labelTitle.Text = "THUẬT TOÁN MÃ HÓA STREAM CIPHER";
            labelTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.AutoSize = false;
            labelTitle.Size = new Size(500, 40);
            labelTitle.Location = new Point(20, 10);
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            headerPanel.Controls.Add(labelTitle);

            // Nút thông tin nhóm
            buttonTeamInfo = new Button();
            buttonTeamInfo.Text = "Nhóm thực hiện";
            buttonTeamInfo.Location = new System.Drawing.Point(620, 15);
            buttonTeamInfo.Size = new Size(120, 30);
            buttonTeamInfo.FlatStyle = FlatStyle.Flat;
            buttonTeamInfo.FlatAppearance.BorderSize = 0;
            buttonTeamInfo.BackColor = Color.FromArgb(70, 96, 135);
            buttonTeamInfo.ForeColor = Color.White;
            buttonTeamInfo.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            buttonTeamInfo.Click += new EventHandler(buttonTeamInfo_Click);
            headerPanel.Controls.Add(buttonTeamInfo);

            // Nút trợ giúp
            buttonHelp = new Button();
            buttonHelp.Text = "Trợ giúp";
            buttonHelp.Location = new Point(750, 15);
            buttonHelp.Size = new Size(120, 30);
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.BackColor = Color.FromArgb(70, 96, 135);
            buttonHelp.ForeColor = Color.White;
            buttonHelp.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            buttonHelp.Click += new EventHandler(btnHelp_Click);
            headerPanel.Controls.Add(buttonHelp);

            // Panel chính chứa các điều khiển
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20, 20, 20, 20);
            containerPanel.Controls.Add(mainPanel, 0, 1);

            // Tạo GroupBox cho phần thuật toán và khóa
            GroupBox groupBoxAlgorithmKey = new GroupBox();
            groupBoxAlgorithmKey.Text = "Thuật toán và khóa";
            groupBoxAlgorithmKey.Location = new Point(20, 20);
            groupBoxAlgorithmKey.Size = new Size(400, 280);
            groupBoxAlgorithmKey.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            groupBoxAlgorithmKey.ForeColor = Color.FromArgb(45, 66, 99);
            mainPanel.Controls.Add(groupBoxAlgorithmKey);

            // Label Algorithm
            labelAlgorithm = new Label();
            labelAlgorithm.Text = "Chọn thuật toán:";
            labelAlgorithm.Location = new System.Drawing.Point(20, 30);
            labelAlgorithm.Size = new System.Drawing.Size(120, 25);
            labelAlgorithm.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxAlgorithmKey.Controls.Add(labelAlgorithm);

            // ComboBox Algorithm
            comboBoxAlgorithm = new ComboBox();
            comboBoxAlgorithm.Location = new System.Drawing.Point(150, 30);
            comboBoxAlgorithm.Size = new System.Drawing.Size(230, 30);
            comboBoxAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAlgorithm.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            comboBoxAlgorithm.Items.Add("RC4");
            comboBoxAlgorithm.Items.Add("OTP");
            comboBoxAlgorithm.Items.Add("A5/1");
            comboBoxAlgorithm.SelectedIndex = 0; // Mặc định chọn RC4
            groupBoxAlgorithmKey.Controls.Add(comboBoxAlgorithm);

            // Label Key
            labelKey = new Label();
            labelKey.Text = "Key:";
            labelKey.Location = new System.Drawing.Point(20, 70);
            labelKey.Size = new System.Drawing.Size(120, 25);
            labelKey.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxAlgorithmKey.Controls.Add(labelKey);

            // TextBox Key
            textBoxKey = new TextBox();
            textBoxKey.Location = new System.Drawing.Point(150, 70);
            textBoxKey.Size = new System.Drawing.Size(230, 25);
            textBoxKey.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxAlgorithmKey.Controls.Add(textBoxKey);

            // Label Key Bits 
            labelKeyBits = new Label();
            labelKeyBits.Text = "Key Bits:";
            labelKeyBits.Location = new System.Drawing.Point(20, 110);
            labelKeyBits.Size = new System.Drawing.Size(120, 25);
            labelKeyBits.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxAlgorithmKey.Controls.Add(labelKeyBits);

            // TextBox Key Bits 
            textBoxKeyBits = new TextBox();
            textBoxKeyBits.Location = new System.Drawing.Point(150, 110);
            textBoxKeyBits.Size = new System.Drawing.Size(230, 25);
            textBoxKeyBits.ReadOnly = true;
            textBoxKeyBits.Font = new Font("Consolas", 9, FontStyle.Regular);
            textBoxKeyBits.BackColor = Color.FromArgb(240, 240, 240);
            groupBoxAlgorithmKey.Controls.Add(textBoxKeyBits);

            // Label Keystream Bits
            labelKeystreamBits = new Label();
            labelKeystreamBits.Text = "Keystream:";
            labelKeystreamBits.Location = new System.Drawing.Point(20, 150);
            labelKeystreamBits.Size = new System.Drawing.Size(120, 25);
            labelKeystreamBits.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxAlgorithmKey.Controls.Add(labelKeystreamBits);

            // TextBox Keystream Bits - Sử dụng TextBox đa dòng (Multiline) để hiển thị đầy đủ
            textBoxKeystreamBits = new TextBox();
            textBoxKeystreamBits.Location = new System.Drawing.Point(150, 150);
            textBoxKeystreamBits.Size = new System.Drawing.Size(230, 60);
            textBoxKeystreamBits.ReadOnly = true;
            textBoxKeystreamBits.Font = new Font("Consolas", 9, FontStyle.Regular);
            textBoxKeystreamBits.BackColor = Color.FromArgb(240, 240, 240);
            textBoxKeystreamBits.Multiline = true;
            textBoxKeystreamBits.ScrollBars = ScrollBars.Vertical;
            groupBoxAlgorithmKey.Controls.Add(textBoxKeystreamBits);

            // Button Generate Key
            buttonGenerateKey = new Button();
            buttonGenerateKey.Text = "Tạo khóa";
            buttonGenerateKey.Location = new System.Drawing.Point(150, 230);
            buttonGenerateKey.Size = new System.Drawing.Size(110, 35);
            buttonGenerateKey.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            buttonGenerateKey.FlatStyle = FlatStyle.Flat;
            buttonGenerateKey.BackColor = Color.FromArgb(70, 96, 135);
            buttonGenerateKey.ForeColor = Color.White;
            buttonGenerateKey.Click += new EventHandler(buttonGenerateKey_Click);
            groupBoxAlgorithmKey.Controls.Add(buttonGenerateKey);

            // Button Reset
            buttonReset = new Button();
            buttonReset.Text = "Reset";
            buttonReset.Location = new System.Drawing.Point(270, 230);
            buttonReset.Size = new System.Drawing.Size(110, 35);
            buttonReset.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            buttonReset.FlatStyle = FlatStyle.Flat;
            buttonReset.BackColor = Color.FromArgb(180, 180, 180);
            buttonReset.ForeColor = Color.Black;
            buttonReset.Click += new EventHandler(buttonReset_Click);
            groupBoxAlgorithmKey.Controls.Add(buttonReset);

            // Tạo GroupBox cho phần mã hóa/giải mã
            GroupBox groupBoxEncryptionDecryption = new GroupBox();
            groupBoxEncryptionDecryption.Text = "Mã hóa/Giải mã";
            groupBoxEncryptionDecryption.Location = new Point(440, 20);
            groupBoxEncryptionDecryption.Size = new Size(420, 480);
            groupBoxEncryptionDecryption.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            groupBoxEncryptionDecryption.ForeColor = Color.FromArgb(45, 66, 99);
            mainPanel.Controls.Add(groupBoxEncryptionDecryption);

            // Label Plaintext
            labelPlaintext = new Label();
            labelPlaintext.Text = "Bản rõ:";
            labelPlaintext.Location = new System.Drawing.Point(20, 30);
            labelPlaintext.Size = new System.Drawing.Size(100, 25);
            labelPlaintext.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxEncryptionDecryption.Controls.Add(labelPlaintext);

            // TextBox Plaintext - Sử dụng TextBox đa dòng
            textBoxPlaintext = new TextBox();
            textBoxPlaintext.Location = new System.Drawing.Point(130, 30);
            textBoxPlaintext.Size = new System.Drawing.Size(270, 50);
            textBoxPlaintext.Multiline = true;
            textBoxPlaintext.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxEncryptionDecryption.Controls.Add(textBoxPlaintext);

            // Label Plaintext Bits
            labelPlaintextBits = new Label();
            labelPlaintextBits.Text = "Bit bản rõ:";
            labelPlaintextBits.Location = new System.Drawing.Point(20, 90);
            labelPlaintextBits.Size = new System.Drawing.Size(100, 25);
            labelPlaintextBits.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxEncryptionDecryption.Controls.Add(labelPlaintextBits);

            // TextBox Plaintext Bits - Sử dụng TextBox đa dòng và có thanh cuộn
            textBoxPlaintextBits = new TextBox();
            textBoxPlaintextBits.Location = new System.Drawing.Point(130, 90);
            textBoxPlaintextBits.Size = new System.Drawing.Size(270, 50);
            textBoxPlaintextBits.ReadOnly = true;
            textBoxPlaintextBits.Multiline = true;
            textBoxPlaintextBits.ScrollBars = ScrollBars.Vertical;
            textBoxPlaintextBits.Font = new Font("Consolas", 9, FontStyle.Regular);
            textBoxPlaintextBits.BackColor = Color.FromArgb(240, 240, 240);
            groupBoxEncryptionDecryption.Controls.Add(textBoxPlaintextBits);

            // Label Ciphertext
            labelCiphertext = new Label();
            labelCiphertext.Text = "Mã Morse:";
            labelCiphertext.Location = new System.Drawing.Point(20, 160);
            labelCiphertext.Size = new System.Drawing.Size(100, 25);
            labelCiphertext.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxEncryptionDecryption.Controls.Add(labelCiphertext);

            // TextBox Ciphertext - Sử dụng TextBox đa dòng
            textBoxCiphertext = new TextBox();
            textBoxCiphertext.Location = new System.Drawing.Point(130, 160);
            textBoxCiphertext.Size = new System.Drawing.Size(270, 70);
            textBoxCiphertext.Multiline = true;
            textBoxCiphertext.ScrollBars = ScrollBars.Vertical;
            textBoxCiphertext.Font = new Font("Consolas", 9, FontStyle.Regular);
            groupBoxEncryptionDecryption.Controls.Add(textBoxCiphertext);

            // Label Ciphertext Bits
            labelCiphertextBits = new Label();
            labelCiphertextBits.Text = "Bit mã hóa:";
            labelCiphertextBits.Location = new System.Drawing.Point(20, 240);
            labelCiphertextBits.Size = new System.Drawing.Size(100, 25);
            labelCiphertextBits.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxEncryptionDecryption.Controls.Add(labelCiphertextBits);

            // TextBox Ciphertext Bits - Sử dụng TextBox đa dòng và có thanh cuộn
            textBoxCiphertextBits = new TextBox();
            textBoxCiphertextBits.Location = new System.Drawing.Point(130, 240);
            textBoxCiphertextBits.Size = new System.Drawing.Size(270, 50);
            textBoxCiphertextBits.ReadOnly = true;
            textBoxCiphertextBits.Multiline = true;
            textBoxCiphertextBits.ScrollBars = ScrollBars.Vertical;
            textBoxCiphertextBits.Font = new Font("Consolas", 9, FontStyle.Regular);
            textBoxCiphertextBits.BackColor = Color.FromArgb(240, 240, 240);
            groupBoxEncryptionDecryption.Controls.Add(textBoxCiphertextBits);

            // Label Decrypted
            labelDecrypted = new Label();
            labelDecrypted.Text = "Bản giải mã:";
            labelDecrypted.Location = new System.Drawing.Point(20, 310);
            labelDecrypted.Size = new System.Drawing.Size(100, 25);
            labelDecrypted.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxEncryptionDecryption.Controls.Add(labelDecrypted);

            // TextBox Decrypted - Sử dụng TextBox đa dòng
            textBoxDecrypted = new TextBox();
            textBoxDecrypted.Location = new System.Drawing.Point(130, 310);
            textBoxDecrypted.Size = new System.Drawing.Size(270, 50);
            textBoxDecrypted.Multiline = true;
            textBoxDecrypted.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxEncryptionDecryption.Controls.Add(textBoxDecrypted);

            // Label Decrypted Bits
            labelDecryptedBits = new Label();
            labelDecryptedBits.Text = "Bit giải mã:";
            labelDecryptedBits.Location = new System.Drawing.Point(20, 370);
            labelDecryptedBits.Size = new System.Drawing.Size(100, 25);
            labelDecryptedBits.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            groupBoxEncryptionDecryption.Controls.Add(labelDecryptedBits);

            // TextBox Decrypted Bits - Sử dụng TextBox đa dòng và có thanh cuộn
            textBoxDecryptedBits = new TextBox();
            textBoxDecryptedBits.Location = new System.Drawing.Point(130, 370);
            textBoxDecryptedBits.Size = new System.Drawing.Size(270, 50);
            textBoxDecryptedBits.ReadOnly = true;
            textBoxDecryptedBits.Multiline = true;
            textBoxDecryptedBits.ScrollBars = ScrollBars.Vertical;
            textBoxDecryptedBits.Font = new Font("Consolas", 9, FontStyle.Regular);
            textBoxDecryptedBits.BackColor = Color.FromArgb(240, 240, 240);
            groupBoxEncryptionDecryption.Controls.Add(textBoxDecryptedBits);

            // Panel chứa các nút điều khiển
            Panel buttonPanel = new Panel();
            buttonPanel.Location = new Point(130, 430);
            buttonPanel.Size = new Size(270, 40);
            groupBoxEncryptionDecryption.Controls.Add(buttonPanel);

            // Button Encrypt
            buttonEncrypt = new Button();
            buttonEncrypt.Text = "Mã hóa";
            buttonEncrypt.Location = new System.Drawing.Point(0, 0);
            buttonEncrypt.Size = new System.Drawing.Size(85, 35);
            buttonEncrypt.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            buttonEncrypt.FlatStyle = FlatStyle.Flat;
            buttonEncrypt.BackColor = Color.FromArgb(70, 130, 180);
            buttonEncrypt.ForeColor = Color.White;
            buttonEncrypt.Click += new EventHandler(buttonEncrypt_Click);
            buttonPanel.Controls.Add(buttonEncrypt);

            // Button Decrypt
            buttonDecrypt = new Button();
            buttonDecrypt.Text = "Giải mã";
            buttonDecrypt.Location = new System.Drawing.Point(92, 0);
            buttonDecrypt.Size = new System.Drawing.Size(85, 35);
            buttonDecrypt.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            buttonDecrypt.FlatStyle = FlatStyle.Flat;
            buttonDecrypt.BackColor = Color.FromArgb(60, 179, 113);
            buttonDecrypt.ForeColor = Color.White;
            buttonDecrypt.Click += new EventHandler(buttonDecrypt_Click);
            buttonPanel.Controls.Add(buttonDecrypt);

            // Button Thoát
            Button buttonExit = new Button();
            buttonExit.Text = "Thoát";
            buttonExit.Location = new System.Drawing.Point(185, 0);
            buttonExit.Size = new System.Drawing.Size(85, 35);
            buttonExit.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.BackColor = Color.FromArgb(220, 53, 69);
            buttonExit.ForeColor = Color.White;
            buttonExit.Click += (s, e) => { this.Close(); };
            buttonPanel.Controls.Add(buttonExit);

            // GroupBox thông tin mã Morse (Thêm phần mới để giải thích)
            GroupBox groupBoxMorseInfo = new GroupBox();
            groupBoxMorseInfo.Text = "Thông tin mã Morse";
            groupBoxMorseInfo.Location = new Point(20, 320);
            groupBoxMorseInfo.Size = new Size(400, 180);
            groupBoxMorseInfo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            groupBoxMorseInfo.ForeColor = Color.FromArgb(45, 66, 99);
            mainPanel.Controls.Add(groupBoxMorseInfo);

            // TextBox thông tin mã Morse
            TextBox textBoxMorseInfo = new TextBox();
            textBoxMorseInfo.Location = new Point(20, 30);
            textBoxMorseInfo.Size = new Size(360, 130);
            textBoxMorseInfo.Multiline = true;
            textBoxMorseInfo.ReadOnly = true;
            textBoxMorseInfo.ScrollBars = ScrollBars.Vertical;
            textBoxMorseInfo.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            textBoxMorseInfo.BackColor = Color.FromArgb(245, 245, 245);
            textBoxMorseInfo.Text = "Mã Morse là một phương thức mã hóa văn bản bằng cách biểu diễn các ký tự dưới dạng các chuỗi dấu chấm và gạch ngang (. và -).\r\n\r\nQuy trình mã hóa đầy đủ:\r\n1. Plaintext -> Base64\r\n2. Base64 -> Mã Morse\r\n3. Mã Morse -> Base64 (khi giải mã)\r\n4. Base64 -> Plaintext";
            groupBoxMorseInfo.Controls.Add(textBoxMorseInfo);
        }
        #region "Sự kiện các nút cơ bản"
        // Nút Nhóm thực hiện

        private void buttonTeamInfo_Click(object sender, EventArgs e)
        {
            // Tạo một form tùy chỉnh thay vì sử dụng MessageBox
            Form teamInfoForm = new Form
            {
                Text = "Thông tin nhóm",
                Size = new Size(450, 360),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            // Panel tiêu đề
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(45, 66, 99)
            };
            teamInfoForm.Controls.Add(headerPanel);

            // Tiêu đề
            Label titleLabel = new Label
            {
                Text = "THÔNG TIN NHÓM THỰC HIỆN",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = false
            };
            headerPanel.Controls.Add(titleLabel);

            // Panel chính
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };
            teamInfoForm.Controls.Add(mainPanel);

            // Label nhóm
            Label groupLabel = new Label
            {
                Text = "Nhóm 10",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 66, 99),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            mainPanel.Controls.Add(groupLabel);

            // PictureBox logo trường (thay thế bằng logo thật nếu có)
            PictureBox logoPictureBox = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(mainPanel.Width - 110, 10),
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Có thể thêm logo từ tài nguyên hoặc tệp
            // logoPictureBox.Image = Properties.Resources.SchoolLogo;
            // Hoặc nếu không có logo, có thể vẽ một hình đơn giản
            Bitmap logoBitmap = new Bitmap(80, 80);
            using (Graphics g = Graphics.FromImage(logoBitmap))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillEllipse(new SolidBrush(Color.FromArgb(45, 66, 99)), 10, 10, 60, 60);
                g.DrawString("UIT", new Font("Arial", 20, FontStyle.Bold), Brushes.White, 20, 25);
            }
            logoPictureBox.Image = logoBitmap;

            mainPanel.Controls.Add(logoPictureBox);

            // TableLayoutPanel chứa thông tin thành viên
            TableLayoutPanel membersTable = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 4,
                Location = new Point(20, 60),
                Size = new Size(380, 160),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                BackColor = Color.White
            };

            membersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            membersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            for (int i = 0; i < 4; i++)
            {
                membersTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            }

            // Thêm thông tin thành viên với format đẹp mắt
            AddMemberInfo(membersTable, 0, "2251120049", "Nguyễn Giang Thành Tài");
            AddMemberInfo(membersTable, 1, "2251120182", "Nguyễn Ngọc Quận");
            AddMemberInfo(membersTable, 2, "2251120098", "Trịnh Thị Nghĩa");
            AddMemberInfo(membersTable, 3, "2251120165", "Nguyễn Khao");

            mainPanel.Controls.Add(membersTable);

            // Label môn học
            Label subjectLabel = new Label
            {
                Text = "Môn học: An toàn thông tin",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                AutoSize = true,
                Location = new Point(20, 230)
            };
            mainPanel.Controls.Add(subjectLabel);

            // Button đóng
            Button closeButton = new Button
            {
                Text = "Đóng",
                Size = new Size(100, 35),
                Location = new Point(mainPanel.Width - 120, mainPanel.Height - 60),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(70, 96, 135),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            closeButton.Click += (s, args) => teamInfoForm.Close();
            mainPanel.Controls.Add(closeButton);

            teamInfoForm.ShowDialog();
        }

        // Phương thức hỗ trợ để thêm thông tin thành viên vào bảng
        private void AddMemberInfo(TableLayoutPanel table, int row, string studentId, string name)
        {
            // Panel chứa MSSV với màu nền
            Panel idPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(1),
                BackColor = Color.FromArgb(240, 240, 240)
            };

            Label idLabel = new Label
            {
                Text = studentId,
                Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 66, 99),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = false
            };

            idPanel.Controls.Add(idLabel);
            table.Controls.Add(idPanel, 0, row);

            // Panel chứa tên với màu nền
            Panel namePanel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(1),
                BackColor = Color.FromArgb(250, 250, 250)
            };

            Label nameLabel = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 0, 0, 0),
                AutoSize = false
            };

            namePanel.Controls.Add(nameLabel);
            table.Controls.Add(namePanel, 1, row);
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
            // Định nghĩa các thanh ghi LFSR và kích thước của chúng
            int[] LFSR1 = new int[19];
            int[] LFSR2 = new int[22];
            int[] LFSR3 = new int[23];

            // Các bit phản hồi (feedback taps)
            int[] taps1 = { 13, 16, 17, 18 }; // Cho LFSR1
            int[] taps2 = { 20, 21 };         // Cho LFSR2
            int[] taps3 = { 7, 20, 21, 22 };  // Cho LFSR3

            // Chuyển key thành chuỗi bit nối liên tiếp (MSB to LSB)
            int[] keyBits = new int[key.Length * 8];
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    keyBits[i * 8 + j] = (key[i] >> (7 - j)) & 1; // MSB to LSB
                }
            }

            // Nạp vào các thanh ghi
            for (int i = 0; i < LFSR1.Length; i++) LFSR1[i] = keyBits[i % keyBits.Length];
            for (int i = 0; i < LFSR2.Length; i++) LFSR2[i] = keyBits[(i + LFSR1.Length) % keyBits.Length];
            for (int i = 0; i < LFSR3.Length; i++) LFSR3[i] = keyBits[(i + LFSR1.Length + LFSR2.Length) % keyBits.Length];

            byte[] keystream = new byte[length];

            for (int i = 0; i < length * 8; i++) // Sinh số lượng bit = chiều dài keystream * 8
            {
                // Lấy bit majority từ 3 bit điều khiển (bit 8, 10, 10 tương ứng)
                int majority = (LFSR1[8] & LFSR2[10]) | (LFSR1[8] & LFSR3[10]) | (LFSR2[10] & LFSR3[10]);

                // Dịch các thanh ghi chỉ nếu bit điều khiển của chúng bằng majority
                if (LFSR1[8] == majority) ShiftRegister(LFSR1, taps1);
                if (LFSR2[10] == majority) ShiftRegister(LFSR2, taps2);
                if (LFSR3[10] == majority) ShiftRegister(LFSR3, taps3);

                // XOR các đầu ra để tạo bit keystream
                int keystreamBit = LFSR1[LFSR1.Length - 1] ^ LFSR2[LFSR2.Length - 1] ^ LFSR3[LFSR3.Length - 1];

                // Ghi bit keystream vào mảng
                int byteIndex = i / 8;
                int bitIndex = i % 8;
                keystream[byteIndex] |= (byte)(keystreamBit << (7 - bitIndex));
            }

            return keystream;
        }

        // Hàm hỗ trợ để dịch thanh ghi
        private void ShiftRegister(int[] register, int[] taps)
        {
            // XOR các bit phản hồi để tạo bit mới
            int feedback = 0;
            foreach (int tap in taps)
            {
                feedback ^= register[tap];
            }

            // Dịch các bit sang phải và thêm feedback vào đầu
            for (int i = register.Length - 1; i > 0; i--)
            {
                register[i] = register[i - 1];
            }
            register[0] = feedback;
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


        // Thêm các hàm chuyển đổi Base64 <-> Morse vào sau phần #region "Giải mã chung"

        #region "Mã Morse"
        // Hàm chuyển đổi chuỗi sang mã Morse
        private string TextToMorse(string text)
        {
            Dictionary<char, string> morseDict = new Dictionary<char, string>()
    {
        // Chữ hoa
        {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
        {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
        {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
        {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
        {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
        {'Z', "--.."}, 
        
        // Chữ thường - thêm ký hiệu "|" để phân biệt
        {'a', ".-|"}, {'b', "-...|"}, {'c', "-.-.| "}, {'d', "-..|"}, {'e', ".|"},
        {'f', "..-.|"}, {'g', "--.|"}, {'h', "....|"}, {'i', "..|"}, {'j', ".---|"},
        {'k', "-.-|"}, {'l', ".-..|"}, {'m', "--|"}, {'n', "-.|"}, {'o', "---|"},
        {'p', ".--.|"}, {'q', "--.-|"}, {'r', ".-.|"}, {'s', "...|"}, {'t', "-|"},
        {'u', "..-|"}, {'v', "...-|"}, {'w', ".--|"}, {'x', "-..-|"}, {'y', "-.--|"},
        {'z', "--..|"},
        
        // Số và ký tự đặc biệt
        {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
        {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."},
        {'9', "----."}, {'+', ".-.-."}, {'/', "-..-."}, {'=', "-...-"}, {' ', "/"}
    };

            StringBuilder morse = new StringBuilder();

            foreach (char c in text)
            {
                if (morseDict.ContainsKey(c))
                {
                    morse.Append(morseDict[c] + " ");
                }
                else
                {
                    // Với ký tự đặc biệt, lưu mã ASCII của nó 
                    // Ví dụ: ~ sẽ được lưu dưới dạng ~126~ (mã ASCII là 126)
                    morse.Append("~" + ((int)c).ToString() + "~ ");
                }
            }

            return morse.ToString().Trim();
        }

        // Hàm chuyển đổi mã Morse sang chuỗi
        private string MorseToText(string morse)
        {
            Dictionary<string, char> morseDict = new Dictionary<string, char>()
    {
        // Chữ hoa
        {".-", 'A'}, {"-...", 'B'}, {"-.-.", 'C'}, {"-..", 'D'}, {".", 'E'},
        {"..-.", 'F'}, {"--.", 'G'}, {"....", 'H'}, {"..", 'I'}, {".---", 'J'},
        {"-.-", 'K'}, {".-..", 'L'}, {"--", 'M'}, {"-.", 'N'}, {"---", 'O'},
        {".--.", 'P'}, {"--.-", 'Q'}, {".-.", 'R'}, {"...", 'S'}, {"-", 'T'},
        {"..-", 'U'}, {"...-", 'V'}, {".--", 'W'}, {"-..-", 'X'}, {"-.--", 'Y'},
        {"--..", 'Z'},
        
        // Chữ thường - với ký hiệu "|"
        {".-|", 'a'}, {"-...|", 'b'}, {"-.-.|", 'c'}, {"-..|", 'd'}, {".|", 'e'},
        {"..-.|", 'f'}, {"--.|", 'g'}, {"....|", 'h'}, {"..|", 'i'}, {".---|", 'j'},
        {"-.-|", 'k'}, {".-..|", 'l'}, {"--|", 'm'}, {"-.|", 'n'}, {"---|", 'o'},
        {".--.|", 'p'}, {"--.-|", 'q'}, {".-.|", 'r'}, {"...|", 's'}, {"-|", 't'},
        {"..-|", 'u'}, {"...-|", 'v'}, {".--|", 'w'}, {"-..-|", 'x'}, {"-.--|", 'y'},
        {"--..|", 'z'},
        
        // Số và ký tự đặc biệt  
        {"-----", '0'}, {".----", '1'}, {"..---", '2'}, {"...--", '3'},
        {"....-", '4'}, {".....", '5'}, {"-....", '6'}, {"--...", '7'}, {"---..", '8'},
        {"----.", '9'}, {".-.-.", '+'}, {"-..-.", '/'}, {"-...-", '='}, {"/", ' '}
    };
            StringBuilder text = new StringBuilder();
            string[] symbols = morse.Split(' ');

            foreach (string symbol in symbols)
            {
                if (string.IsNullOrEmpty(symbol))
                    continue;

                if (symbol == "/")
                {
                    text.Append(' ');
                }
                else if (symbol.StartsWith("~") && symbol.EndsWith("~") && symbol.Length > 2)
                {
                    // Đây là ký tự đặc biệt được lưu dưới dạng ~ASCII~
                    string asciiStr = symbol.Substring(1, symbol.Length - 2);
                    if (int.TryParse(asciiStr, out int asciiCode))
                    {
                        text.Append((char)asciiCode);
                    }
                }
                else if (morseDict.ContainsKey(symbol))
                {
                    text.Append(morseDict[symbol]);
                }
            }

            return text.ToString();
        }

        // Hàm chuyển Base64 sang Morse
        private string Base64ToMorse(string base64)
        {
            return TextToMorse(base64);
        }

        // Hàm chuyển Morse sang Base64
        private string MorseToBase64(string morse)
        {
            return MorseToText(morse);
        }
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
            string morseCode = "";

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
                Console.WriteLine(ciphertext);
                // Chuyển đổi Base64 sang mã Morse
                morseCode = Base64ToMorse(ciphertext);
                textBoxCiphertext.Text = morseCode;
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
            string morseCode = textBoxCiphertext.Text;
            string selectedAlgorithm = comboBoxAlgorithm.SelectedItem.ToString();

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(morseCode))
            {
                MessageBox.Show("Vui lòng nhập khóa và ciphertext!");
                return;
            }

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            textBoxKeyBits.Text = BytesToBitString(keyBytes);

            try
            {
                // Chuyển mã Morse về text (không phải Base64)
                string plaintextFromMorse = MorseToText(morseCode);
                Console.WriteLine("Decoded from Morse: " + plaintextFromMorse);

                // Chuyển mã Morse về Base64
                string ciphertext = MorseToBase64(morseCode);
                Console.WriteLine(ciphertext);

                // Kiểm tra xem chuỗi có phải là Base64 hợp lệ không
                try
                {
                    Convert.FromBase64String(ciphertext);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Lỗi: Mã Morse không thể chuyển đổi thành Base64 hợp lệ!");
                    return;
                }

            byte[] keystream;
            string decrypted = "";

 
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
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
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
