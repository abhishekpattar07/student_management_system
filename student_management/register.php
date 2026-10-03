<?php
session_start();
require_once "config/db.php";
$message = "";
if ($_SERVER["REQUEST_METHOD"] == "POST") {
 $name = trim($_POST["name"]);
 $email = trim($_POST["email"]);
 $password = $_POST["password"];
 $confirm_password = $_POST["confirm_password"];
 if (empty($name) || empty($email) || empty($password)) {
 $message = "All fields are required.";
 } elseif ($password !== $confirm_password) {
 $message = "Passwords do not match.";
 } else {
 $check = $conn->prepare("SELECT id FROM users WHERE email = ?");
 $check->bind_param("s", $email);
 $check->execute();
 $result = $check->get_result();
 if ($result->num_rows > 0) {
 $message = "Email already registered.";
 } else {
 $hashed_password = password_hash($password, PASSWORD_DEFAULT);
 $stmt = $conn->prepare(
 "INSERT INTO users (name, email, password) VALUES (?, ?, ?)"
 );
 $stmt->bind_param("sss", $name, $email, $hashed_password);
 if ($stmt->execute()) {
 header("Location: login.php?registered=1");
 exit();
 } else {
 $message = "Registration failed.";
 }
 }
 }
}
?>
<!DOCTYPE html>
<html>
<head>
<title>Registration</title>
<link rel="stylesheet" href="css/style.css">
</head>
<body>
<div class="container">
<div class="card">
<h2>Create Account</h2>
<?php if ($message != ""): ?>
<div class="error"><?php echo $message; ?></div>
<?php endif; ?>
<form method="POST">
<label>Name</label>
<input type="text" name="name" required>
<label>Email</label>
<input type="email" name="email" required>
<label>Password</label>
<input type="password" name="password" required>
<label>Confirm Password</label>
<input type="password" name="confirm_password" required>
<button type="submit">Register</button>
</form>
<p>Already have an account? <a href="login.php">Login</a></p>
</div>
</div>
</body>
</html>
