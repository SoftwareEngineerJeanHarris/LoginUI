using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginUI
{
    public partial class ChangePasswordForm : Form
    {
        private static string connectionString = "Server=89.117.139.52;Port=3306;Database=u428290900_Jean;Uid=u428290900_Jean;Pwd=Jmjmjm_1993;";
        private string username;

        public ChangePasswordForm(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // New Password Label
            Label lblNewPassword = new Label();
            lblNewPassword.Text = "New Password:";
            lblNewPassword.Location = new System.Drawing.Point(20, 20);

            // New Password TextBox
            TextBox txtNewPassword = new TextBox();
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Location = new System.Drawing.Point(130, 20);
            txtNewPassword.Width = 150;
            txtNewPassword.PasswordChar = '*';

            // Submit Button
            Button btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new System.Drawing.Point(100, 60);
            btnSubmit.Click += (sender, e) => BtnSubmit_Click(sender, e, txtNewPassword);

            // Adding Controls to the Form
            Controls.Add(lblNewPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(btnSubmit);

            // Form Properties
            Text = "Change Password";
            ClientSize = new System.Drawing.Size(300, 100);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void BtnSubmit_Click(object sender, EventArgs e, TextBox txtNewPassword)
        {
            string newPassword = txtNewPassword.Text;
            ChangePassword(newPassword);
            MessageBox.Show("Password changed successfully!");
            Close();
        }

        private void ChangePassword(string newPassword)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE users SET password_hash='{newPassword}' WHERE username='{username}'", connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
