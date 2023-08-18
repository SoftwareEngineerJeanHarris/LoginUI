using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginUI
{
    public partial class Form1 : Form
    {
        static string connectionString = "Server=89.117.139.52;Port=3306;Database=u428290900_Jean;Uid=u428290900_Jean;Pwd=Jmjmjm_1993;";

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Username Label
            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new System.Drawing.Point(20, 20);

            // Username TextBox
            TextBox txtUsername = new TextBox();
            txtUsername.Name = "txtUsername";
            txtUsername.Location = new System.Drawing.Point(130, 20);
            txtUsername.Width = 150;

            // Password Label
            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new System.Drawing.Point(20, 60);

            // Password TextBox
            TextBox txtPassword = new TextBox();
            txtPassword.Name = "txtPassword";
            txtPassword.Location = new System.Drawing.Point(130, 60);
            txtPassword.Width = 150;
            txtPassword.PasswordChar = '*';

            // Login Button
            Button btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new System.Drawing.Point(100, 100);
            btnLogin.Click += (sender, e) => BtnLogin_Click(sender, e, txtUsername, txtPassword);

            // Adding Controls to the Form
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);

            // Form Properties
            Text = "Login Screen";
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(300, 150);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void BtnLogin_Click(object sender, EventArgs e, TextBox txtUsername, TextBox txtPassword)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Login(username, password);
        }

        private  void Login(String username, String password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM users WHERE username='{username}' AND password_hash='{password}'", connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ProfileForm profileForm = new ProfileForm(username, this);
                        profileForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login failed!");
                    }
                }
            }
        }
    }
}
