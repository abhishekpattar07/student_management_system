namespace StudentManagementSystem
{
    public partial class Form1 : Form
    {
        private readonly List<Student> students = new();
        private string? selectedStudentId;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshGrid(students);
            studentIdTextBox.Focus();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!TryReadStudent(out Student? student))
            {
                return;
            }

            if (students.Any(existing => string.Equals(existing.StudentId, student.StudentId, StringComparison.OrdinalIgnoreCase)))
            {
                ShowValidationMessage("A student with this Student ID already exists.");
                studentIdTextBox.Focus();
                return;
            }

            students.Add(student);
            RefreshGrid(students);
            ClearForm();
            MessageBox.Show("Student added successfully.", "Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!TryReadStudent(out Student? updatedStudent))
            {
                return;
            }

            string idToFind = selectedStudentId ?? updatedStudent.StudentId;
            Student? existingStudent = students.FirstOrDefault(student =>
                string.Equals(student.StudentId, idToFind, StringComparison.OrdinalIgnoreCase));

            if (existingStudent is null)
            {
                ShowValidationMessage("Select a student row or enter an existing Student ID to update.");
                return;
            }

            bool duplicateId = students.Any(student =>
                !ReferenceEquals(student, existingStudent) &&
                string.Equals(student.StudentId, updatedStudent.StudentId, StringComparison.OrdinalIgnoreCase));

            if (duplicateId)
            {
                ShowValidationMessage("Another student already uses this Student ID.");
                studentIdTextBox.Focus();
                return;
            }

            existingStudent.StudentId = updatedStudent.StudentId;
            existingStudent.FullName = updatedStudent.FullName;
            existingStudent.Course = updatedStudent.Course;
            existingStudent.Age = updatedStudent.Age;
            existingStudent.PhoneNumber = updatedStudent.PhoneNumber;

            RefreshGrid(students);
            ClearForm();
            MessageBox.Show("Student updated successfully.", "Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string idToDelete = selectedStudentId ?? studentIdTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(idToDelete))
            {
                ShowValidationMessage("Select a student row or enter a Student ID to delete.");
                return;
            }

            Student? student = students.FirstOrDefault(existing =>
                string.Equals(existing.StudentId, idToDelete, StringComparison.OrdinalIgnoreCase));

            if (student is null)
            {
                ShowValidationMessage("No student was found with that Student ID.");
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Delete the record for {student.FullName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            students.Remove(student);
            RefreshGrid(students);
            ClearForm();
            MessageBox.Show("Student deleted successfully.", "Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchStudents();
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchStudents();
                e.SuppressKeyPress = true;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Clear();
            RefreshGrid(students);
            ClearForm();
        }

        private void studentsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= studentsDataGridView.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = studentsDataGridView.Rows[e.RowIndex];
            studentIdTextBox.Text = Convert.ToString(row.Cells[nameof(Student.StudentId)].Value) ?? string.Empty;
            fullNameTextBox.Text = Convert.ToString(row.Cells[nameof(Student.FullName)].Value) ?? string.Empty;
            courseTextBox.Text = Convert.ToString(row.Cells[nameof(Student.Course)].Value) ?? string.Empty;
            ageTextBox.Text = Convert.ToString(row.Cells[nameof(Student.Age)].Value) ?? string.Empty;
            phoneTextBox.Text = Convert.ToString(row.Cells[nameof(Student.PhoneNumber)].Value) ?? string.Empty;
            selectedStudentId = studentIdTextBox.Text;
        }

        private void SearchStudents()
        {
            string searchTerm = searchTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                RefreshGrid(students);
                return;
            }

            List<Student> matches = students.Where(student =>
                student.StudentId.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                student.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                student.Course.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                student.PhoneNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

            RefreshGrid(matches);
        }

        private bool TryReadStudent(out Student student)
        {
            string id = studentIdTextBox.Text.Trim();
            string fullName = fullNameTextBox.Text.Trim();
            string course = courseTextBox.Text.Trim();
            string ageText = ageTextBox.Text.Trim();
            string phoneNumber = phoneTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(course) || string.IsNullOrWhiteSpace(ageText) ||
                string.IsNullOrWhiteSpace(phoneNumber))
            {
                ShowValidationMessage("Please complete all required fields.");
                student = null!;
                return false;
            }

            if (!int.TryParse(ageText, out int age) || age < 1 || age > 120)
            {
                ShowValidationMessage("Age must be a whole number between 1 and 120.");
                ageTextBox.Focus();
                student = null!;
                return false;
            }

            string phoneDigits = new string(phoneNumber.Where(char.IsDigit).ToArray());
            if (phoneDigits.Length < 7 || phoneDigits.Length > 15 ||
                phoneNumber.Any(character => !char.IsDigit(character) && !"+ -()".Contains(character)))
            {
                ShowValidationMessage("Enter a valid phone number using 7 to 15 digits.");
                phoneTextBox.Focus();
                student = null!;
                return false;
            }

            student = new Student
            {
                StudentId = id,
                FullName = fullName,
                Course = course,
                Age = age,
                PhoneNumber = phoneNumber
            };
            return true;
        }

        private void RefreshGrid(IEnumerable<Student> records)
        {
            studentsDataGridView.DataSource = null;
            studentsDataGridView.DataSource = records.ToList();
            recordsLabel.Text = $"Students ({studentsDataGridView.Rows.Count})";
        }

        private void ClearForm()
        {
            studentIdTextBox.Clear();
            fullNameTextBox.Clear();
            courseTextBox.Clear();
            ageTextBox.Clear();
            phoneTextBox.Clear();
            selectedStudentId = null;
            studentsDataGridView.ClearSelection();
            studentIdTextBox.Focus();
        }

        private static void ShowValidationMessage(string message)
        {
            MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public sealed class Student
    {
        public string StudentId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
