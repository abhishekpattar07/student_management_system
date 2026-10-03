<?php
session_start();
require_once "config/db.php";
if (!isset($_SESSION["user_id"])) {
 header("Location: login.php");
 exit();
}
$result = $conn->query(
 "SELECT * FROM students ORDER BY id DESC"
);
?>
<!DOCTYPE html>
<html>
<head>
<title>Dashboard</title>
<link rel="stylesheet" href="css/style.css">
<script src="js/script.js"></script>
</head>
<body>
<div class="navbar">
<div><strong>Student Management System</strong></div>
<div>
Welcome,
<?php echo htmlspecialchars($_SESSION["user_name"]); ?>
|
<a href="logout.php">Logout</a>
</div>
</div>
<div class="dashboard">
<h2>Student Dashboard</h2>
<a class="add" href="add_student.php">+ Add Student</a>
<div class="table-container">
<table>
<tr>
<th>ID</th>
<th>Name</th>
<th>Email</th>
<th>Phone</th>
<th>Course</th>
<th>Semester</th>
<th>Actions</th>
</tr>
<?php while ($student = $result->fetch_assoc()): ?>
<tr>
<td><?php echo $student["id"]; ?></td>
<td><?php echo htmlspecialchars($student["name"]); ?></td>
<td><?php echo htmlspecialchars($student["email"]); ?></td>
<td><?php echo htmlspecialchars($student["phone"]); ?></td>
<td><?php echo htmlspecialchars($student["course"]); ?></td>
<td><?php echo $student["semester"]; ?></td>
<td>
<a class="action-btn edit"
href="edit_student.php?id=<?php echo $student["id"]; ?>">
Edit
</a>
<a class="action-btn delete"
href="delete_student.php?id=<?php echo $student["id"]; ?>"
onclick="return confirmDelete();">
Delete
</a>
<a class="action-btn"
href="marks.php?student_id=<?php echo $student["id"]; ?>">
Marks
</a>
</td>
</tr>
<?php endwhile; ?>
</table>
</div>
</div>
</body>
</html>
