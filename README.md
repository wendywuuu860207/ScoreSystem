# ScoreSystem
 ManageScoreWindow

 建立Students Access資料庫，資料型態為
	StudentId (primary key) (string)
	StudentName (string) 
	Gender (string) 
	MidExam (number) 
	FinalExam (number)
 Window Form連結Studnets Access資料庫，功能如下
	1. 計算FinalScore (MidExam和FinalExam的平均)
	2. 依FinalScore分數顯示蘋果數(4: >=90, 3: >=80, 2: >=70, 1: >=60, 0: <60)
	3. 具備新增、修改、刪除、搜尋功能
	4. 新增資料時檢查ID是否已存在
	5. 檢查輸入的MidExam和FinalExam，必須介於0~100的整數，否則警告錯誤輸入