<?php
session_start();
require_once "config/db.php";
if (!isset($_SESSION["user_id"])) {
 header("Location: login.php");
 exit();
}
$student_id = intval($_GET["student_id"]);
$stmt = $conn->prepare(
 "SELECT * FROM students WHERE id = ?"
);
$stmt->bind_param("i", $student_id);
$stmt->execute();
$student_result = $stmt->get_result();
$student = $student_result->fetch_assoc();
if (!$student) {
 die("Student not found.");
}
$stmt = $conn->prepare(
 "SELECT * FROM marks
 WHERE student_id = ?
 ORDER BY id DESC"
);
$stmt->bind_param("i", $student_id);
$stmt->execute();
$marks_result = $stmt->get_result();
$total = 0;
$count = 0;
?>
<!DOCTYPE html>
<html>
<head>
<title>Student Marks</title>
<link rel="stylesheet" href="css/style.css">
<script src="js/script.js"></script>
</head>
<body>
<div class="dashboard">
<h2>Marks - <?php echo htmlspecialchars($student["name"]); ?></h2>
<p>
Course: <?php echo htmlspecialchars($student["course"]); ?>
</p>
<a class="add"
href="add_marks.php?student_id=<?php echo $student_id; ?>">
+ Add Marks
</a>
<div class="table-container">
<table>
<tr>
<th>ID</th>
<th>Subject</th>
<th>Marks</th>
<th>Actions</th>
</tr>
<?php while ($mark = $marks_result->fetch_assoc()): ?>
<?php
$total += $mark["marks"];
$count++;
?>
<tr>
<td><?php echo $mark["id"]; ?></td>
<td><?php echo htmlspecialchars($mark["subject"]); ?></td>
<td><?php echo $mark["marks"]; ?></td>
<td>
<a class="action-btn edit"
href="edit_marks.php?id=<?php echo $mark["id"]; ?>">
Edit
</a>
<a class="action-btn delete"
href="delete_marks.php?id=<?php echo $mark["id"]; ?>"
onclick="return confirmDelete();">
Delete
</a>
</td>
</tr>
<?php endwhile; ?>
</table>
<?php if ($count > 0): ?>
<h3>Total Marks: <?php echo $total; ?></h3>
<h3>
Average:
<?php echo round($total / $count, 2); ?>
</h3>
<?php else: ?>
<p>No marks added yet.</p>
<?php endif; ?>
</div>
<p>
<a href="dashboard.php">← Back to Students</a>
</p>
</div>
</body>
</html>