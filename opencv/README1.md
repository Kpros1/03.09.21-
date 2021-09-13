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

![image](https://user-images.githubusercontent.com/90038602/133053275-4a1c226b-48d2-4959-89fa-1bdd58c51306.png)


	
	
	
	#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include <iostream>
#include <stdio.h>
#include <stdlib.h>

using namespace cv;
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	Mat img;
	img = imread("2.jpg", 1);
	namedWindow("okno", WINDOW_AUTOSIZE);
	imshow("okno", img);
	Mat src_gray;
	Mat canny_output;
	cvtColor(img, src_gray, COLOR_RGB2BGR);
	blur(src_gray, src_gray, Size(3, 3));
	double lower_thresh_val = 100, high_thresh_val = 300;
	Canny(src_gray, canny_output, lower_thresh_val, high_thresh_val, 3);
	namedWindow("Серое изображение", WINDOW_AUTOSIZE);
	imshow("Серое изображение", canny_output);
	imwrite("canny_output.jpeg", canny_output);
	RNG rng(12345);
	vector<vector<Point>>contours;
	vector<Vec4i>hierarchy;
	findContours(canny_output, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE, Point(0, 0));
	vector<Moments>mu(contours.size());
	for (int i = 0; i < contours.size(); i++)
{
mu[i] = moments(contours[i], false);
}
	vector<Point2f>mc(contours.size());
	for (int i = 0; i < contours.size(); i++) 
	{
		mc[i] = Point2f(mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00);
	}
	for (int i = 0;i < contours.size(); i++) {
		printf("контур № %d:цент масс - x = %.2f y = %.2f; длина - %.2f \n", i, mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00, arcLength(contours[i], true));
	}
	
	Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
	for (int i = 0; i < contours.size(); i++)
	{
		Scalar color = Scalar(rng.uniform(0, 255), rng.uniform(0, 255), rng.uniform(0, 255));
		drawContours(drawing, contours, i, color, 2, 8, hierarchy, 0, Point());
		circle(drawing, mc[i], 4, color, -1, 5, 0);
	}
	namedWindow("контуры", WINDOW_AUTOSIZE);
	imshow("контуры", drawing);

	waitKey(0);
	system("pause");
	return(0);

}
					    
   


