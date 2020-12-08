Andrey Tedeev <andrey.tedeev@outlook.com>
"C#, Уровень 3"
Lesson 4

Changes: + = add, ^ = update, - = remove

+	: The whole solution moved to dotnet 5.0

^	: MailLibrary project
+	: Model.Schedule 
^	: IMailService and implementations
+	: IScheduleStorage
^	: DataStorageInMemory to support IScheduleStorage

+	: MailLibraryTest project
+	: CryptoTest

^	: WpfApp project
-	: DateTimePicker (doesn't support net5.0)
^	: MainViewModel to support IScheduleStorage
+	: ScheduleView (events data grid)
+	: MainViewModel ScheduleEmailCommand


