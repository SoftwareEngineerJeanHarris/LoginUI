using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginUI
{
    public partial class CreateUserForm : Form
    {
        private static string connectionString = "Server=89.117.139.52;Port=3306;Database=u428290900_Jean;Uid=u428290900_Jean;Pwd=Jmjmjm_1993;";

        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // New Username Label
            Label lblNewUsername = new Label();
            lblNewUsername.Text = "New Username:";
            lblNewUsername.Location = new System.Drawing.Point(20, 20);

            // New Username TextBox
            TextBox txtNewUsername = new TextBox();
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.Location = new System.Drawing.Point(130, 20);
            txtNewUsername.Width = 150;

            // Submit Button
            Button btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new System.Drawing.Point(100, 60);
            btnSubmit.Click += (sender, e) => BtnSubmit_Click(sender, e, txtNewUsername);

            // Adding Controls to the Form
            Controls.Add(lblNewUsername);
            Controls.Add(txtNewUsername);
            Controls.Add(btnSubmit);

            // Form Properties
            Text = "Create User";
            ClientSize = new System.Drawing.Size(300, 100);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void BtnSubmit_Click(object sender, EventArgs e, TextBox txtNewUsername)
        {
            string newUsername = txtNewUsername.Text;

            if (IsUsernameAvailable(newUsername))
            {
                CreateUser(newUsername);
                MessageBox.Show("User created successfully!");
                Close();
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
        }

        private bool IsUsernameAvailable(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM users WHERE username='{username}'", connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    return !reader.Read(); // Returns true if no existing user with the given username
                }
            }
        }

        private void CreateUser(string username)
        {
            // Code to create the user in the database
        }
    }
}
