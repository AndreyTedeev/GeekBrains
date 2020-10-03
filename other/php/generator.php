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

			<h1>Генератор паролей</h1>

			<div class="box">

				<?php 
					$result = "";
					$length=8;
					if (isset($_GET["length"])) {
						$length = (int) $_GET["length"];
						$letters = "abcdefghijklmnopqrstuvwxyz";
						$digits = "0123456789";

						$digitOrLetter = 0; // если 0 то буква, если 1 то цифра
						$letterCase = 0; // если 0 то прописная, если 1 то заглавная
						$n = 0; // позиция в строке

						for ($i = 0; $i<$length; $i++) {
							// первая всегда буква
							if ($i > 0) {
								$digitOrLetter = rand(0, 1);
							}
							if ($digitOrLetter == 0) { // буква
								$n = rand(0, strlen($letters)-1);
								$x = $letters[$n];
								// регистр буквы
								$letterCase = rand(0, 1);
								if ($letterCase == 1) {
									$x = strtoupper($x);
								}
								$result = $result . $x;
							}
							else { // цифра
								$n = rand(0, strlen($digits)-1);
								$result = $result . $digits[$n];
							}
						} // for
					}
				?>
				
				<p id="pwd"><b><?php echo $result?></b></p>
				<form method="GET">
					<p>Введите желаемую длину пароля. Число от 8 до 20. </p>
					<input type="number" name="length" value="<?php echo $length?>" min="8" max="20">

					<br>
					<input type="submit" value="Генерировать">
				</form>
			</div>

        </div>
    </div>
</div>

<?php include "footer.php" ?>

</body>
</html>