<?php
session_start();
require_once "config/db.php";
if (!isset($_SESSION["user_id"])) {
 header("Location: login.php");
 exit();
}
$student_id = intval($_GET["student_id"]);
$stmt = $conn->prepare(
 "SELECT name FROM students WHERE id = ?"
);
$stmt->bind_param("i", $student_id);
$stmt->execute();
$result = $stmt->get_result();
$student = $result->fetch_assoc();
if (!$student) {
 die("Student not found.");
}
if ($_SERVER["REQUEST_METHOD"] == "POST") {
 $subject = trim($_POST["subject"]);
 $marks = intval($_POST["marks"]);
 if ($marks < 0 || $marks > 100) {
 die("Marks must be between 0 and 100.");
 }
 $stmt = $conn->prepare(
 "INSERT INTO marks
 (student_id, subject, marks)
 VALUES (?, ?, ?)"
 );
 $stmt->bind_param(
 "isi",
 $student_id, $subject, $marks
 );
 $stmt->execute();
 header(
 "Location: marks.php?student_id=" . $student_id
 );
 exit();
}
?>
<!DOCTYPE html>
<html>
<head>
<title>Add Marks</title>
<link rel="stylesheet" href="css/style.css">
</head>
<body>
<div class="container">
<div class="card">
<h2>Add Marks</h2>
<p>
Student:
<strong><?php echo htmlspecialchars($student["name"]); ?></strong>
</p>
<form method="POST">
<label>Subject</label>
<input type="text" name="subject"
placeholder="Python" required>
<label>Marks</label>
<input type="number" name="marks"
min="0" max="100" required>
<button type="submit">Save Marks</button>
</form>
<p>
<a href="marks.php?student_id=<?php echo $student_id; ?>">
← Back
</a>
</p>
</div>
</div>
</body>
</html>