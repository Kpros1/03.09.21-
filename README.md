# 03.09.21 1з
1. Скачать open CV с сайта https://opencv.org/
2. Создать пустой проект на языке c++ в visual studio
3. подключить open CV
   3.1 нажать на имя проекта и зайтм в свойства
   ![image](https://user-images.githubusercontent.com/90038602/131995796-155ffdd4-56a2-444a-a655-a4b466f03064.png)
    
   ![image](https://user-images.githubusercontent.com/90038602/131996109-80c9b7fb-4ae5-413e-a752-97de93e47267.png)
  
   ![image](https://user-images.githubusercontent.com/90038602/131996185-1d44f9c5-a896-4ba0-b939-ecb19f02d495.png)
 4. Пишем код
 5. #include"opencv2/highgui/highgui.hpp"
#include"opencv2/imgproc/imgproc.hpp"
#include<iostream>
#include<stdio.h>
#include<stdlib.h>
using namespace cv;
using namespace std;
int main(int argc, char** argv)
{
	int height = 520;
	int wight = 840;
	Mat img(height, wight, CV_8UC3);
	Point textOrg(100, img.rows / 2);
	int fontFace = FONT_HERSHEY_SCRIPT_SIMPLEX;
	double fontScale = 2;
	Scalar color(50, 400, 50);
	putText(img, "DIPLOM", textOrg, fontFace, fontScale, color);
	namedWindow("hello word", 0);
	imshow("hello world", img);
	waitKey(0);
	return 0;
}

 6. Запускаем код 
 7. Понимаем то что нечего не работает
 8. Добавляем opencv_world453.dll и opencv_world453d.dll из C:\Users\Администратор\Downloads\opencv\build\x64\vc15\bin в C:\Users\Администратор\source\repos\Project1 BK\x64\Debug
 9. Меняем код
   #include"opencv2/highgui/highgui.hpp"
#include"opencv2/imgproc/imgproc.hpp"
#include<iostream>
#include<stdio.h>
#include<stdlib.h>
using namespace cv;
using namespace std;
int main(int argc, char** argv)
{
	int height = 520;
	int wight = 840;
	Mat img(height, wight, CV_8UC3);
	Point textOrg(100, img.rows / 2);
	int fontFace = FONT_HERSHEY_SCRIPT_SIMPLEX;
	double fontScale = 2;
	Scalar color(50, 400, 50);
	putText(img, "DIPLOM", textOrg, fontFace, fontScale, color);
	//namedWindow("hello word", 0);
	imshow("hello world", img);
	waitKey(0);
	system("pause");
	return 0;
}
10. Рабочая программа 
   ![image](https://user-images.githubusercontent.com/90038602/131997063-f980a9de-6d7d-47c0-ad57-e630baaf7509.png)



   


