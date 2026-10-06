namespace StudentManagementSystem
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label titleLabel;
        private Label subtitleLabel;
        private Label userIdLabel;
        private Label passwordLabel;
        private TextBox userIdTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Button clearButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerPanel = new Panel();
            titleLabel = new Label();
            subtitleLabel = new Label();
            userIdLabel = new Label();
            passwordLabel = new Label();
            userIdTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            clearButton = new Button();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(31, 78, 121);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(480, 112);
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(80, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(321, 36);
            titleLabel.Text = "Student Management System";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 9.5F);
            subtitleLabel.ForeColor = Color.FromArgb(220, 235, 250);
            subtitleLabel.Location = new Point(158, 67);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(164, 17);
            subtitleLabel.Text = "Sign in to continue";
            // 
            // userIdLabel
            // 
            userIdLabel.AutoSize = true;
            userIdLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            userIdLabel.ForeColor = Color.FromArgb(45, 45, 45);
            userIdLabel.Location = new Point(54, 146);
            userIdLabel.Name = "userIdLabel";
            userIdLabel.Size = new Size(58, 19);
            userIdLabel.Text = "User ID";
            // 
            // userIdTextBox
            // 
            userIdTextBox.Font = new Font("Segoe UI", 10F);
            userIdTextBox.Location = new Point(54, 169);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.Size = new Size(372, 25);
            userIdTextBox.TabIndex = 0;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            passwordLabel.ForeColor = Color.FromArgb(45, 45, 45);
            passwordLabel.Location = new Point(54, 211);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(72, 19);
            passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Segoe UI", 10F);
            passwordTextBox.Location = new Point(54, 234);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '●';
            passwordTextBox.Size = new Size(372, 25);
            passwordTextBox.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(31, 78, 121);
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(54, 284);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(180, 38);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // clearButton
            // 
            clearButton.BackColor = Color.FromArgb(108, 117, 125);
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            clearButton.ForeColor = Color.White;
            clearButton.Location = new Point(246, 284);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(180, 38);
            clearButton.TabIndex = 3;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
            // 
            // LoginForm
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 252);
            ClientSize = new Size(480, 360);
            Controls.Add(clearButton);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(userIdTextBox);
            Controls.Add(userIdLabel);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Student Management System";
            Load += LoginForm_Load;
            KeyDown += LoginForm_KeyDown;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
