#include "opencv2/highgui/highgui.hpp" //определяет кросс-платформенные функции взаимодействия с оконной системой;
#include "opencv2/imgproc/imgproc.hpp" // определяет основные/традиционные функции цифровой обработки изображений: отрисовка кривых и тому подобное.
#include <iostream> // Объявляет объекты, управляющие чтением из стандартных потоков и записью в них. Это, как правило, единственный заголовок, необходимый для ввода и вывода из программы на C++.
#include <stdio.h>  // стандартный заголовочный файл ввода-вывода
#include <stdlib.h> // аголовочный файл стандартной библиотеки языка Си, который содержит в себе функции, занимающиеся выделением памяти, контролем процесса выполнения программы, преобразованием типов и другие
using namespace cv; 
using namespace std;
int main()
{

	 //Блок рисования окна
	//int height = 520; // задаем высоту (int - тип данных, целое)
	//int width = 840; // задаем ширину
	//Mat img(height, width, CV_8UC3); // Mat(создание матрицы) (CV_8UC3) 8-разрядная целочисленная матрица / изображение без знака с 3 каналами
	//Point textOrg(300, img.rows / 2); //Point (координаты x,y) , 
	//int fontFace = FONT_HERSHEY_SIMPLEX; //настройка шрифта , FONT_HERSHEY_SIMPLEX - тип шрифта
	//double fontScale = 1; //double - числовой тип данных , fontScale — переменная типа double, коэффициент масштабирования шрифта, умножаемый на базовый размер шрифта.
	//Scalar color(0, 0, 20); // Тип Scalar широко используется в OpenCV для передачи значений пикселей, цвет
	//putText(img, "Step By Step", textOrg, fontFace, fontScale, color); //  используется для рисования текстовой строки на любом изображении
	//namedWindow("Hello World", 0); // название окна
	//	imshow("Hello World", img);  //отображает изображение в градациях серого на рисунке. использует диапазон отображения по умолчанию для типа данных изображения и оптимизирует свойства рисунка, осей и объекта изображения для отображения изображения
	//Запрос от пользователя какой файл ему требуется открыть
	setlocale(LC_ALL, "Russian"); //русификатор
	//string filename; //строчка с названием перменной 
	//cout << "Имя файла "; //вывод значения <<
	//cin >> filename;  // ввод значения >>
	//cout << "Ввели файл "<<filename<<endl; //endl текст будет выведен на след. строке 

	



	//Блок загрузки изображения, Оператор Canny
	Mat img; //создает матрицу
	img = imread("image1.jpg", 1); //image.jpg (imread -  считывает изображение из файла, заданного , выводя формат файла из его содержимого.)
	namedWindow("Hello World", WINDOW_AUTOSIZE); // название окна, авторазмер
	imshow("Hello World", img); // отображает изображение в градациях серого на рисунке. использует диапазон отображения по умолчанию для типа данных изображения и оптимизирует свойства рисунка, осей и объекта изображения для отображения изображения
	Mat src_gray; //Создание матрицы с названием src_gray
	Mat canny_output; // Создание матрицы
	cvtColor(img, src_gray, COLOR_RGB2BGR); //  cvtColor конвертирует изображения из одного цветового пространства в другое
	blur(src_gray, src_gray, Size(3, 3)); // размытие
	/*double otsu_thresh_val = threshold(src_gray, img, 0, 255, THRESH_BINARY | THRESH_OTSU);*/
	/*double high_thresh_val = otsu_thresh_val, lower_thresh_val = otsu_thresh_val * 0.5;*/
	/*cout << otsu_thresh_val;*/
	double lower_thresh_val=100, high_thresh_val= 300; // нижний и верхний порог, нижний отвечает за шумы изображения, если задать много верхнего, то будет просто черное изображение
	Canny(src_gray, canny_output,lower_thresh_val, high_thresh_val, 3); // оператор обнаружения границ изображения
	/*char* source_grey_window = "Серое изображение";*/
	namedWindow("Серое изображение", WINDOW_AUTOSIZE);
	imshow("Серое изображение", canny_output);
	imwrite("canny_output.jpg", canny_output);
	
	     // Моменты и центр масс findContours
		RNG rng(12345); // генератор случайных чисел
		vector<vector<Point>>contours; // вектор
		vector<Vec4i>hierarchy; 
		findContours(canny_output, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE, Point(0, 0)); // нахождение контуров ,RETR_EXTERNAL - удаляет внутренние контуры  ,CHAIN_APPROX_SIMPLE - нужен для экономии памяти: если линия, то хранит только точки начала и конца.
		vector<Moments>mu(contours.size());
		for (int i = 0; i < contours.size(); i++)
		{
			mu[i] = moments(contours[i], false);
		}

		vector <Point2f>mc(contours.size());
		for (int i = 0; i < contours.size(); i++)
		{
			mc[i] = Point2f(mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00);
		}
		
		for (int i = 0; i < contours.size(); i++)
		{
			printf("Контур № %d: центр масс - x = %.2f y=%.2f; длина - %.2f\n", i, mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00, arcLength(contours[i], true));
		}
		// Рисование контуров
		Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3); // CV_8UC3 изображение без знака с 3 каналами
		for (int i = 0; i < contours.size(); i++)
		{
			Scalar color = Scalar(rng.uniform(0, 255), rng.uniform(0, 255), rng.uniform(0, 255)); //Тип Scalar широко используется в OpenCV для передачи значений пикселей, цвет
			drawContours(drawing, contours, i, color, 2, 8, hierarchy, 0, Point()); //Полученные с помощью функции findContours контуры хорошо бы каким-то образом нарисовать в кадре. Машине это не нужно, зато нам это поможет лучше понять как выглядят найденные алгоритмом контуры. Поможет в этом ещё одна полезная функция — drawContours.
			circle(drawing, mc[i], 4, color, -1, 5, 0);
		}
		namedWindow("Контуры", WINDOW_AUTOSIZE);
		imshow("Контуры", drawing);



		waitKey(0);
		system("pause");
		return (0);
		




}
