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



	

