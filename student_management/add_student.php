<?php
session_start();

require_once "config/db.php";

// Check if user is logged in
if (!isset($_SESSION["user_id"])) {
    header("Location: login.php");
    exit();
}

$message = "";

if ($_SERVER["REQUEST_METHOD"] === "POST") {

    // Get form data
    $name = trim($_POST["name"] ?? "");
    $email = trim($_POST["email"] ?? "");
    $phone = trim($_POST["phone"] ?? "");
    $course = trim($_POST["course"] ?? "");
    $semester = intval($_POST["semester"] ?? 0);

    // Validate required fields
    if ($name === "") {
        $message = "Student name is required.";
    } elseif ($semester < 1 || $semester > 6) {
        $message = "Please select a valid semester.";
    } else {

        // Insert student
        $stmt = $conn->prepare(
            "INSERT INTO students
            (name, email, phone, course, semester)
            VALUES (?, ?, ?, ?, ?)"
        );

        if (!$stmt) {
            $message = "Database error. Please try again.";
        } else {

            $stmt->bind_param(
                "ssssi",
                $name,
                $email,
                $phone,
                $course,
                $semester
            );

            if ($stmt->execute()) {

                $stmt->close();

                // Student added successfully
                header("Location: dashboard.php");
                exit();

            } else {

                $message = "Student could not be added.";
                $stmt->close();
            }
        }
    }
}
?>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="UTF-8">

    <meta name="viewport"
          content="width=device-width, initial-scale=1.0">

    <title>Add Student - Student Management System</title>

    <link rel="stylesheet" href="css/style.css">

</head>

<body>

<div class="container">

    <div class="card">

        <h2>Student Management System</h2>

        <h3>Add Student</h3>

        <?php if ($message !== ""): ?>

            <div class="error">
                <?= htmlspecialchars(
                    $message,
                    ENT_QUOTES,
                    "UTF-8"
                ) ?>
            </div>

        <?php endif; ?>

        <form method="POST" action="">

            <label for="name">Name</label>

            <input
                type="text"
                id="name"
                name="name"
                placeholder="Enter student name"
                value="<?= htmlspecialchars(
                    $_POST["name"] ?? "",
                    ENT_QUOTES,
                    "UTF-8"
                ) ?>"
                required
            >

            <label for="email">Email</label>

            <input
                type="email"
                id="email"
                name="email"
                placeholder="student@example.com"
                value="<?= htmlspecialchars(
                    $_POST["email"] ?? "",
                    ENT_QUOTES,
                    "UTF-8"
                ) ?>"
            >

            <label for="phone">Phone</label>

            <input
                type="text"
                id="phone"
                name="phone"
                placeholder="Enter phone number"
                value="<?= htmlspecialchars(
                    $_POST["phone"] ?? "",
                    ENT_QUOTES,
                    "UTF-8"
                ) ?>"
            >

            <label for="course">Course</label>

            <input
                type="text"
                id="course"
                name="course"
                placeholder="BCA"
                value="<?= htmlspecialchars(
                    $_POST["course"] ?? "",
                    ENT_QUOTES,
                    "UTF-8"
                ) ?>"
            >

            <label for="semester">Semester</label>

            <select id="semester" name="semester" required>

                <option value="">Select Semester</option>

                <?php for ($i = 1; $i <= 6; $i++): ?>

                    <option
                        value="<?= $i ?>"
                        <?= (
                            intval($_POST["semester"] ?? 0) === $i
                        ) ? "selected" : "" ?>
                    >
                        Semester <?= $i ?>
                    </option>

                <?php endfor; ?>

            </select>

            <button type="submit">
                Add Student
            </button>

        </form>

        <p>
            <a href="dashboard.php">
                ← Back to Dashboard
            </a>
        </p>

    </div>

</div>

</body>

</html>
