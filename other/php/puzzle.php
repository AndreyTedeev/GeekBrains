<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<title>Личный сайт студента GeekBrains</title>
	<link rel="stylesheet" href="style.css"> 
</head>
<body>

<div class="content">
	
	<?php include "menu.php" ?>

	<div class="contentWrap">
    	<div class="content">
        	<div class="center">

			<h1>Игра в загадки</h1>

			<div class="box">

				<?php 

					function checkAnswer($paramName, $answers) {
						$userAnswer = mb_strtolower($_GET[$paramName]);
						for ($i = 0; $i < count($answers); $i++) {
							if ($userAnswer == $answers[$i]) {
								return 1;
							}
						};
						return 0;
					};

					if (isset($_GET["userAnswer1"]) &&
						isset($_GET["userAnswer2"]) &&
						isset($_GET["userAnswer3"]) &&
						isset($_GET["userAnswer4"])) {

						$score = 0;
						
						$score += checkAnswer("userAnswer1", array("петух"));
						$score += checkAnswer("userAnswer2", array("овца", "баран", "овечка"));
						$score += checkAnswer("userAnswer3", array("кошка", "кот"));
						$score += checkAnswer("userAnswer4", array("ножницы"));

						echo "Вы угадали " . $score . " загадок";
					}

				?>

				<form method="GET">
					<p>Не ездок, а со шпорами, не сторож, а всех будит?</p>
					<input type="text" name="userAnswer1">

					<p>По горам, по долам ходит шуба да кафтан?</p>
					<input type="text" name="userAnswer2">

					<p>Зелёные глаза — всем мышам гроза?</p>
					<input type="text" name="userAnswer3">


					<p>Зелёные глаза — всем мышам гроза?</p>
					<input type="text" name="userAnswer4">

					<br>
					<input type="submit" value="Ответить">
				</form>
			</div>

        </div>
    </div>
</div>

<?php include "footer.php" ?>

</body>
</html>