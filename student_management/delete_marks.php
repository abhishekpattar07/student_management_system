<?php
session_start();
require_once "config/db.php";
if (!isset($_SESSION["user_id"])) {
 header("Location: login.php");
 exit();
}
$id = intval($_GET["id"]);
$stmt = $conn->prepare(
 "SELECT student_id FROM marks WHERE id = ?"
);
$stmt->bind_param("i", $id);
$stmt->execute();
$result = $stmt->get_result();
$mark = $result->fetch_assoc();
if (!$mark) {
 die("Mark record not found.");
}
$student_id = $mark["student_id"];
$stmt = $conn->prepare(
 "DELETE FROM marks WHERE id = ?"
);
$stmt->bind_param("i", $id);
$stmt->execute();
header(
 "Location: marks.php?student_id=" . $student_id
);
exit();
?>