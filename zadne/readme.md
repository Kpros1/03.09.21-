```
using System;
using CoreLib1;

namespace App3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Utils.GenNumOrder("Иванов Иван Иванович", DateTime.Now));
            Console.ReadKey();
        }
    }
}
```

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib1
{
    public static class Utils
    {
        public static string GenNumOrder(string client, DateTime date)
        {
            var fullName = client.Split(' ');
            return $"{fullName[0]} {fullName[1].Substring(0, 1)}.{fullName[2].Substring(0, 1)}._{date.ToString("MM.dd.yyyy")}.{date.ToString("HH")}_{date.ToString("mm")}";

        }
    }
}
```
![Белянкинклассы](https://user-images.githubusercontent.com/90038602/153351448-db1bf6cd-d705-41e9-9e70-6c3213a30f64.png)

```
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLib1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoreLib1.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        [TestMethod()]
        public void CheckPasswprdTestTrue()
        {
            string password = "Admin1*df";
            string expected = "Хороший пароль";
            string actual = Utils.CheckPasswprd(password);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]

        public void CheckPasswprdTestFalse()
        {
            string password = "Aq1$";
            bool expected = false;
            string actual = Utils.CheckPasswprd(password);
            Assert.IsFalse(expected, actual); 
        }



    }
}
```
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib1
{
    public static class Utils
    {
        public static string GenNumOrder(string client, DateTime date)
        {
            var fullName = client.Split(' ');
            return $"{fullName[0]} {fullName[1].Substring(0, 1)}.{fullName[2].Substring(0, 1)}._{date.ToString("MM.dd.yyyy")}.{date.ToString("HH")}_{date.ToString("mm")}";

        }
        public static string CheckPasswprd(string Password)
        {
            if (Password.Length<6 && Password.Length > 10)
            {
                return "Пароль должен быть не менее 6 и не больше 10 букв";
            }
            else
            {
                bool isSpec = false;
                foreach(var item in Password)
                {
                    if ("-*|$".Contains(item))
                    {
                        isSpec = true;
                    }
                }
                bool isDigigit = false;
                foreach(var item in Password)
                {
                    if (char.IsDigit(item))
                    {
                        isDigigit = true;
                    }

                }
                if (isDigigit == false)
                {
                    return "Не содержит спец символов";
                }
                bool Isnumber = false;
                foreach(var item in Password) 
                {
                    if (char.IsNumber(item))
                    {
                        Isnumber = true;
                    }
                }
                if (Isnumber == false)
                {
                    return ("Не содержит цифр");
                }
                bool Isupper = false;
                foreach (var item in Password)
                {
                    if (char.IsUpper(item))
                    {
                        Isupper = true;
                    }
                }
                if (Isupper == false)
                {
                    return ("Не содержит больших букв");
                }
                bool Islower = false;
                foreach (var item in Password)
                {
                    if (char.IsLower(item))
                    {
                        Islower = true;
                    }
                }
                if (Islower == false)
                {
                    return ("Не содержит маленьких букв");
                }
                if (isSpec == false)
                {
                    return "Не содержит спец символы";
                }
                return "Хороший пароль";


            }
        }
    }
}
```
![Screenshot_19](https://user-images.githubusercontent.com/90038602/153558898-eaba349d-1b22-4fb7-9f74-7548322026fb.png)

