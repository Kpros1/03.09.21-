добавляем к коду с canny русификацию setlocale(LC_ALL, "Russian");

и такой код 

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
	for (int i = 0;i < contours.size(); i++)
  
  {
  
		printf("контур № %d:цент масс - x = %.2f y = %.2f; длина - %.2f \n", i, mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00, arcLength(contours[i], true));
  
	}
  
  запускаем приложение
  
  ![image](https://user-images.githubusercontent.com/90038602/133050889-50348ea0-62b5-40d9-9838-ab94e3664f89.png)

  
