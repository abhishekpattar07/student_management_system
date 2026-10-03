<?php
session_start();
require_once "config/db.php";
if (!isset($_SESSION["user_id"])) {
 header("Location: login.php");
 exit();
}
$id = intval($_GET["id"]);
$stmt = $conn->prepare(
 "SELECT * FROM students WHERE id = ?"
);
$stmt->bind_param("i", $id);
$stmt->execute();
$result = $stmt->get_result();
$student = $result->fetch_assoc();
if (!$student) {
 die("Student not found.");
}
if ($_SERVER["REQUEST_METHOD"] == "POST") {
 $name = trim($_POST["name"]);
 $email = trim($_POST["email"]);
 $phone = trim($_POST["phone"]);
 $course = trim($_POST["course"]);
 $semester = intval($_POST["semester"]);
 $stmt = $conn->prepare(
 "UPDATE students
 SET name=?, email=?, phone=?, course=?, semester=?
 WHERE id=?"
 );
 $stmt->bind_param(
 "ssssii",
 $name, $email, $phone, $course, $semester, $id
 );
 $stmt->execute();
 header("Location: dashboard.php");
 exit();
}
?>
<!DOCTYPE html>
<html>
<head>
<title>Edit Student</title>
<link rel="stylesheet" href="css/style.css">
</head>
<body>
<div class="container">
<div class="card">
<h2>Edit Student</h2>
<form method="POST">
<label>Name</label>
<input type="text" name="name"
value="<?php echo htmlspecialchars($student["name"]); ?>"
required>
<label>Email</label>
<input type="email" name="email"
value="<?php echo htmlspecialchars($student["email"]); ?>">
<label>Phone</label>
<input type="text" name="phone"
value="<?php echo htmlspecialchars($student["phone"]); ?>">
<label>Course</label>
<input type="text" name="course"
value="<?php echo htmlspecialchars($student["course"]); ?>">
<label>Semester</label>
<select name="semester">
<?php for ($i = 1; $i <= 6; $i++): ?>
<option value="<?php echo $i; ?>"
<?php if ($student["semester"] == $i) echo "selected"; ?>>
<?php echo $i; ?>
</option>
<?php endfor; ?>
</select>
<button type="submit">Update Student</button>
</form>
<p><a href="dashboard.php">← Back</a></p>
</div>
</div>
</body>
</html>