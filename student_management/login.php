<?php
session_start();

require_once "config/db.php";

$message = "";

// Show registration success message
if (isset($_GET["registered"])) {
    $message = "Registration successful. Please login.";
}

// Handle login form submission
if ($_SERVER["REQUEST_METHOD"] === "POST") {

    // Get form values safely
    $email = trim($_POST["email"] ?? "");
    $password = $_POST["password"] ?? "";

    if ($email === "" || $password === "") {
        $message = "Please enter your email and password.";
    } else {

        // Find user by email
        $stmt = $conn->prepare(
            "SELECT id, name, email, password
             FROM users
             WHERE email = ?
             LIMIT 1"
        );

        if (!$stmt) {
            $message = "Something went wrong. Please try again.";
        } else {

            $stmt->bind_param("s", $email);

            if ($stmt->execute()) {

                $result = $stmt->get_result();

                if ($result && $result->num_rows === 1) {

                    $user = $result->fetch_assoc();

                    // Verify hashed password
                    if (password_verify($password, $user["password"])) {

                        // Prevent session fixation
                        session_regenerate_id(true);

                        // Store user information in session
                        $_SESSION["user_id"] = $user["id"];
                        $_SESSION["user_name"] = $user["name"];
                        $_SESSION["user_email"] = $user["email"];

                        // Redirect to dashboard
                        header("Location: dashboard.php");
                        exit();

                    } else {
                        $message = "Invalid email or password.";
                    }

                } else {
                    $message = "Invalid email or password.";
                }

            } else {
                $message = "Something went wrong. Please try again.";
            }

            $stmt->close();
        }
    }
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>Login - Student Management System</title>

    <link rel="stylesheet" href="css/style.css">
</head>

<body>

<div class="container">

    <div class="card">

        <h2>Student Management System</h2>

        <h3>Login</h3>

        <?php if ($message !== ""): ?>
            <div class="message">
                <?= htmlspecialchars($message, ENT_QUOTES, "UTF-8") ?>
            </div>
        <?php endif; ?>

        <form method="POST" action="">

            <label for="email">Email</label>

            <input
                type="email"
                id="email"
                name="email"
                placeholder="Enter your email"
                value="<?= htmlspecialchars($_POST["email"] ?? "", ENT_QUOTES, "UTF-8") ?>"
                required
            >

            <label for="password">Password</label>

            <input
                type="password"
                id="password"
                name="password"
                placeholder="Enter your password"
                required
            >

            <button type="submit">Login</button>

        </form>

        <p>
            Don't have an account?
            <a href="register.php">Register</a>
        </p>

    </div>

</div>

</body>
</html>

