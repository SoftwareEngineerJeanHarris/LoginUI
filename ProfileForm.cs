using System;
using System.Windows.Forms;

namespace LoginUI
{
    public partial class ProfileForm : Form
    {
        public string Username { get; set; }
        private Label lblWelcome; // Declare lblWelcome as a field
        private Form1 loginForm; // Field to store a reference to Form1

        public ProfileForm(string username, Form1 loginForm)
        {
            InitializeComponent();
            Username = username;
            lblWelcome.Text = $"Welcome, {Username}!"; // Access lblWelcome here
            this.loginForm = loginForm;
            this.FormClosing += ProfileForm_FormClosing;
        }

        private void InitializeComponent()
        {
            // Welcome Label
            lblWelcome = new Label(); // Initialize lblWelcome here
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Text = "Welcome!"; // You can set a default text here
            lblWelcome.Location = new System.Drawing.Point(20, 20);

            // Change Username Button
            Button btnChangeUsername = new Button();
            btnChangeUsername.Text = "Change Username";
            btnChangeUsername.Location = new System.Drawing.Point(20, 60);
            btnChangeUsername.Width = 180;
            btnChangeUsername.Click += BtnChangeUsername_Click;

            // Change Password Button
            Button btnChangePassword = new Button();
            btnChangePassword.Text = "Change Password";
            btnChangePassword.Location = new System.Drawing.Point(20, 100);
            btnChangePassword.Width = 180;
            btnChangePassword.Click += BtnChangePassword_Click;

            // Logout Button
            Button btnLogout = new Button();
            btnLogout.Text = "Logout";
            btnLogout.Location = new System.Drawing.Point(20, 140);
            btnLogout.Width = 180;
            btnLogout.Click += BtnLogout_Click;

            // Adding Controls to the Form
            Controls.Add(lblWelcome);
            Controls.Add(btnChangeUsername);
            Controls.Add(btnChangePassword);
            Controls.Add(btnLogout);

            // Form Properties
            Text = "Welcome Back";
            ClientSize = new System.Drawing.Size(220, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void ProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Close(); // Close Form1
        }

        private void BtnChangeUsername_Click(object sender, EventArgs e)
        {
            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.ShowDialog();
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(Username);
            changePasswordForm.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            Close();
        }
    }
}
