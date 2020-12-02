Andrey Tedeev <andrey.tedeev@outlook.com>
"C#, Уровень 3"

Все сервисы (IMailService, IStorage) сделал и вынес в библиотеку. 
Все переделал полностью на MVVM. Сделал три UserControl. Один для Recipients и два Servers, Senders.
Пока не выяснил как сделать один MVVM USerControl для Servers и Senders. 
Все кнопки в них работают и пока показывают MessageBox с именем вызванного ICommand.
Они одинаковые визуально, только данные разные.
Переход в планировщик тоже переписал на MVVM.
Сделал кнопку Send Mail. Кнопки все используют ICommand.

Отправка пока работает с DebugMailService, но реальный MailService тоже рабочий.

