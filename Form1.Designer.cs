namespace StudentManagementSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label titleLabel;
        private Label subtitleLabel;
        private GroupBox detailsGroupBox;
        private Label studentIdLabel;
        private Label fullNameLabel;
        private Label courseLabel;
        private Label ageLabel;
        private Label phoneLabel;
        private TextBox studentIdTextBox;
        private TextBox fullNameTextBox;
        private TextBox courseTextBox;
        private TextBox ageTextBox;
        private TextBox phoneTextBox;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Button clearButton;
        private GroupBox searchGroupBox;
        private TextBox searchTextBox;
        private Button searchButton;
        private DataGridView studentsDataGridView;
        private Label recordsLabel;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerPanel = new Panel();
            titleLabel = new Label();
            subtitleLabel = new Label();
            detailsGroupBox = new GroupBox();
            studentIdLabel = new Label();
            fullNameLabel = new Label();
            courseLabel = new Label();
            ageLabel = new Label();
            phoneLabel = new Label();
            studentIdTextBox = new TextBox();
            fullNameTextBox = new TextBox();
            courseTextBox = new TextBox();
            ageTextBox = new TextBox();
            phoneTextBox = new TextBox();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            clearButton = new Button();
            searchGroupBox = new GroupBox();
            searchTextBox = new TextBox();
            searchButton = new Button();
            studentsDataGridView = new DataGridView();
            recordsLabel = new Label();
            headerPanel.SuspendLayout();
            detailsGroupBox.SuspendLayout();
            searchGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)studentsDataGridView).BeginInit();
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
            headerPanel.Size = new Size(1060, 92);
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(26, 13);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(324, 37);
            titleLabel.Text = "Student Management System";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 9.5F);
            subtitleLabel.ForeColor = Color.FromArgb(220, 235, 250);
            subtitleLabel.Location = new Point(29, 57);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(284, 17);
            subtitleLabel.Text = "Manage student records quickly and easily";
            // 
            // detailsGroupBox
            // 
            detailsGroupBox.Controls.Add(studentIdLabel);
            detailsGroupBox.Controls.Add(fullNameLabel);
            detailsGroupBox.Controls.Add(courseLabel);
            detailsGroupBox.Controls.Add(ageLabel);
            detailsGroupBox.Controls.Add(phoneLabel);
            detailsGroupBox.Controls.Add(studentIdTextBox);
            detailsGroupBox.Controls.Add(fullNameTextBox);
            detailsGroupBox.Controls.Add(courseTextBox);
            detailsGroupBox.Controls.Add(ageTextBox);
            detailsGroupBox.Controls.Add(phoneTextBox);
            detailsGroupBox.Controls.Add(addButton);
            detailsGroupBox.Controls.Add(updateButton);
            detailsGroupBox.Controls.Add(deleteButton);
            detailsGroupBox.Controls.Add(clearButton);
            detailsGroupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            detailsGroupBox.Location = new Point(24, 108);
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.Size = new Size(1012, 151);
            detailsGroupBox.TabStop = false;
            detailsGroupBox.Text = "Student Details";
            // labels
            studentIdLabel.AutoSize = true;
            studentIdLabel.Font = new Font("Segoe UI", 9F);
            studentIdLabel.Location = new Point(20, 34);
            studentIdLabel.Text = "Student ID *";
            fullNameLabel.AutoSize = true;
            fullNameLabel.Font = new Font("Segoe UI", 9F);
            fullNameLabel.Location = new Point(218, 34);
            fullNameLabel.Text = "Full Name *";
            courseLabel.AutoSize = true;
            courseLabel.Font = new Font("Segoe UI", 9F);
            courseLabel.Location = new Point(416, 34);
            courseLabel.Text = "Course *";
            ageLabel.AutoSize = true;
            ageLabel.Font = new Font("Segoe UI", 9F);
            ageLabel.Location = new Point(614, 34);
            ageLabel.Text = "Age *";
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new Font("Segoe UI", 9F);
            phoneLabel.Location = new Point(712, 34);
            phoneLabel.Text = "Phone Number *";
            // input fields
            studentIdTextBox.Location = new Point(20, 55);
            studentIdTextBox.Size = new Size(180, 24);
            studentIdTextBox.TabIndex = 0;
            fullNameTextBox.Location = new Point(218, 55);
            fullNameTextBox.Size = new Size(180, 24);
            fullNameTextBox.TabIndex = 1;
            courseTextBox.Location = new Point(416, 55);
            courseTextBox.Size = new Size(180, 24);
            courseTextBox.TabIndex = 2;
            ageTextBox.Location = new Point(614, 55);
            ageTextBox.Size = new Size(80, 24);
            ageTextBox.TabIndex = 3;
            phoneTextBox.Location = new Point(712, 55);
            phoneTextBox.Size = new Size(180, 24);
            phoneTextBox.TabIndex = 4;
            // action buttons
            addButton.BackColor = Color.FromArgb(40, 167, 69);
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.ForeColor = Color.White;
            addButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            addButton.Location = new Point(20, 96);
            addButton.Size = new Size(105, 34);
            addButton.Text = "Add Student";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            updateButton.BackColor = Color.FromArgb(0, 123, 255);
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.ForeColor = Color.White;
            updateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            updateButton.Location = new Point(135, 96);
            updateButton.Size = new Size(115, 34);
            updateButton.Text = "Update Student";
            updateButton.UseVisualStyleBackColor = false;
            updateButton.Click += updateButton_Click;
            deleteButton.BackColor = Color.FromArgb(220, 53, 69);
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.ForeColor = Color.White;
            deleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            deleteButton.Location = new Point(260, 96);
            deleteButton.Size = new Size(105, 34);
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            clearButton.BackColor = Color.FromArgb(108, 117, 125);
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.ForeColor = Color.White;
            clearButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            clearButton.Location = new Point(375, 96);
            clearButton.Size = new Size(105, 34);
            clearButton.Text = "Clear Form";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
            // 
            // searchGroupBox
            // 
            searchGroupBox.Controls.Add(searchTextBox);
            searchGroupBox.Controls.Add(searchButton);
            searchGroupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            searchGroupBox.Location = new Point(24, 273);
            searchGroupBox.Name = "searchGroupBox";
            searchGroupBox.Size = new Size(1012, 65);
            searchGroupBox.TabStop = false;
            searchGroupBox.Text = "Search Students";
            searchTextBox.Font = new Font("Segoe UI", 9F);
            searchTextBox.Location = new Point(20, 27);
            searchTextBox.Size = new Size(350, 23);
            searchTextBox.PlaceholderText = "Search by ID, name, course, or phone...";
            searchTextBox.KeyDown += searchTextBox_KeyDown;
            searchButton.BackColor = Color.FromArgb(31, 78, 121);
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.ForeColor = Color.White;
            searchButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            searchButton.Location = new Point(382, 25);
            searchButton.Size = new Size(100, 27);
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // recordsLabel
            // 
            recordsLabel.AutoSize = true;
            recordsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            recordsLabel.ForeColor = Color.FromArgb(31, 78, 121);
            recordsLabel.Location = new Point(24, 353);
            recordsLabel.Text = "Students (0)";
            // 
            // studentsDataGridView
            // 
            studentsDataGridView.AllowUserToAddRows = false;
            studentsDataGridView.AllowUserToDeleteRows = false;
            studentsDataGridView.AllowUserToResizeRows = false;
            studentsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            studentsDataGridView.BackgroundColor = Color.White;
            studentsDataGridView.BorderStyle = BorderStyle.Fixed3D;
            studentsDataGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(31, 78, 121), ForeColor = Color.White, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Alignment = DataGridViewContentAlignment.MiddleLeft };
            studentsDataGridView.ColumnHeadersHeight = 35;
            studentsDataGridView.EnableHeadersVisualStyles = false;
            studentsDataGridView.Location = new Point(24, 377);
            studentsDataGridView.MultiSelect = false;
            studentsDataGridView.ReadOnly = true;
            studentsDataGridView.RowHeadersVisible = false;
            studentsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentsDataGridView.Size = new Size(1012, 250);
            studentsDataGridView.CellClick += studentsDataGridView_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 252);
            ClientSize = new Size(1060, 650);
            Controls.Add(studentsDataGridView);
            Controls.Add(recordsLabel);
            Controls.Add(searchGroupBox);
            Controls.Add(detailsGroupBox);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Management System";
            Load += Form1_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            detailsGroupBox.ResumeLayout(false);
            detailsGroupBox.PerformLayout();
            searchGroupBox.ResumeLayout(false);
            searchGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)studentsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
