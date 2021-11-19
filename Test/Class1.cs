using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mak1
{
    public class PasswordChecker //Ключевое слово public является модификатором доступа для типов и членов типов
    {
        public static bool validatePassword(string password) // Если член класса объявляется как static, то он становится доступным до создания любых объектов своего класса и без ссылки на какой-нибудь объект. С помощью ключевого слова static можно объявлять как переменные, так и методы
        {
            if (password.Length < 8 || password.Length > 20) // условие if(если)
                return false; // возвращает ложь
            if (!password.Any(Char.IsLower)) // Any определяет, соответствует ли коллекция определенному условию, и в зависимости от результата они возвращают true или false. IsLower показывает, относится ли символ Юникода к категории букв нижнего регистра.
                return false;
            if (!password.Any(Char.IsUpper))  // ! - не равно. IsUpper показывает, относится ли символ Юникода к категории букв верхнего регистра.
                return false;
            if (!password.Any(Char.IsDigit)) // IsDigit показывает, относится ли символ Юникода к категории десятичных цифр.
                return false;
            if (password.Intersect("#$%^&_").Count() == 0)  // Intersect получение пересечения последовательностей, то есть общих для обоих наборов элементов
                return false;

            return true; // возвращает правду
        }
        static void Main(string[] args)
        {
            bool arr = PasswordChecker.validatePassword("sasafsaasgsggsa342"); // тип bool — это псевдоним для типа структуры System.Boolean .NET, представляющий логическое значение: true или false.
            Console.WriteLine("res = " + arr); // Console.WriteLine записывает указанные данные с текущим признаком конца строки в стандартный выходной поток.
            //string password = 
            //Console.ReadKey(); //Получает следующий нажатый пользователем символ или функциональную клавишу.
        }
    }
}
