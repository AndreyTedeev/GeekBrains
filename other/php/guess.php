<?php
// Start the session
session_start();
?>
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

				<h1>Игра угадайка</h1>

				<div class="box">

					<?php 
						// Переменные сессии чтобы не запутаться
						$_GUESS_DIGIT= "dgt";
						$_PLAYER_ID= "pid";
						$_TRY_NUM= "try";

						// Переменные программы
						$playerId = 1;
						$tryNum = 0;
						$tryTotal = 7;
						$message = "Угадайте число от 1 до 100.<br>";
						$gameOver = false;
						
						function end_game($text) {
							global $gameOver, $message;
							$gameOver = true;
							$message = $text;
							session_destroy();
						}
						
						$isNewGame = !isset($_SESSION[$_GUESS_DIGIT]) || !isset($_GET["userAnswer"]) ;
					 	if ($isNewGame) {
					 		// Число не загадано или первый заход на страницу, начинаем новую игру
							$guessDigit = rand(1,100); 
					 		$_SESSION[$_GUESS_DIGIT] = $guessDigit;
							$_SESSION[$_PLAYER_ID] = $playerId;
							$_SESSION[$_TRY_NUM] = $tryNum;
							$message = $message . "Ходит первый игрок<br>";
							$message = $message . "У вас осталось " . ($tryTotal - $tryNum) . " попыток.<br>";
					 	}
					 	else {
					 		// Число уже загадано, продолжаем игру
					 		$guessDigit = $_SESSION[$_GUESS_DIGIT];
							$playerId = $_SESSION[$_PLAYER_ID];
							$tryNum = $_SESSION[$_TRY_NUM] + 1;
							$userAnswer = $_GET["userAnswer"];

							// Попытки кончились
							if ($tryNum >= $tryTotal) {
								end_game("Вы проиграли! Правильный ответ " . $guessDigit);
							}
							// Проверяем ответ
							else if ($userAnswer == $guessDigit) {
								end_game("Поздравляю! Игрок " . $playerId . " победил.");
					 		}
					 		else {
								// Продолжаем игру
								if (($userAnswer < $guessDigit)) {
					 				$message = $message . "Число " . $userAnswer . " слишком маленькое.<br>";
					 			}
					 			else if (($userAnswer > $guessDigit)) {
					 				$message = $message. "Число " . $userAnswer . " слишком большое.<br>";
					 			}
								// Меняем игрока
								if ($playerId == 1) {
									$message = $message . "Ходит второй игрок<br>";
									$playerId = 2;
								}
								else if ($playerId == 2) {
									$message = $message . "Ходит первый игрок<br>";
									$playerId = 1;
								}
								$_SESSION[$_PLAYER_ID] = $playerId;
								$_SESSION[$_TRY_NUM] = $tryNum;
								$message = $message . "У вас осталось " . ($tryTotal - $tryNum) . " попыток.<br>";
							}
					 	}
					 
					?>
					
					<form method="GET" onsubmit="validateInput();">

						<p id="info"><?php echo $message?></p>
						
						<?php if (!$gameOver) { ?>
							<input type="number" name="userAnswer" value="1" min="1" max="100">
							<br>
							<input type="submit" value="Ответить" name="">
						<?php } ?>	

					</form>
				</div>

			</div>
		</div>
	</div>

<?php include "footer.php" ?>

</body>
</html>