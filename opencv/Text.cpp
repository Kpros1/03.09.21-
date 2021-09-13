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

