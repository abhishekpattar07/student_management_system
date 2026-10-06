namespace StudentManagementSystem
{
    public partial class LoginForm : Form
    {
        private readonly List<LoginUser> users = new()
        {
            new LoginUser("admin", "admin123")
        };

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            userIdTextBox.Focus();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userId = userIdTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
            {
                ShowLoginMessage("Please enter both your User ID and password.");
                return;
            }

            bool validCredentials = users.Any(user =>
                string.Equals(user.UserId, userId, StringComparison.OrdinalIgnoreCase) &&
                user.Password == password);

            if (!validCredentials)
            {
                ShowLoginMessage("Invalid User ID or password.");
                passwordTextBox.SelectAll();
                passwordTextBox.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            userIdTextBox.Clear();
            passwordTextBox.Clear();
            userIdTextBox.Focus();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private static void ShowLoginMessage(string message)
        {
            MessageBox.Show(message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    internal sealed class LoginUser
    {
        public LoginUser(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }

        public string UserId { get; }
        public string Password { get; }
    }
}
