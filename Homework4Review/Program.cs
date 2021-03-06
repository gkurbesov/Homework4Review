﻿using System;
using System.Linq;

namespace Homework4Review
{

    public enum Seasons
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Задание 1.
             * Написать метод GetFullName(string firstName, string lastName, string patronymic), 
             * принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. 
             * Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
             */

            // Это задание легко решается. Вся задача сводится к объединеню строк.
            // Строки можно объеденять разными способами, например через конкатенацию

            var text1 = "строка 1";
            var text2 = "строка 2";

            var concatenationResult = text1 + " " + text2; // Результатом будет: "строка 1 строка 2"

            // Так же можно объеденить строки при помощи интерполяции. См.: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/tokens/interpolated

            var interpolationResult = $"{text1} {text2}"; // Результатом будет всё тот же текст: "строка 1 строка 2"

            // Вам нужно только написать метод и применить в нем один из приведенных методов решения, что бы вернуть строку с ФИО


            /*
             * Задание 2.
             * Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, 
             * и возвращающую число — сумму всех чисел в строке. 
             * Ввести данные с клавиатуры и вывести результат на экран.
             */

            // Что бы разделить строку на массив строк, используя пробелы, мы можем:
            // 1. пройтись посимвольно по строке через цикл
            // 2. получать подстроки отталкиваясь от нужных индексов. Для поиска индекса символа можно использовать метод IndexOf() для любой строки
            // 3. Использовать метод .Split() для любой строки. Он сделает всю сложную работу по разделению строки и поместит значения в массив

            var inputText = "1 2   3 4  5"; // В этой строке специально заданы несколько пробелов подряд


            // Вызываем у переменной inputText метод Split() и указываем какой символ использовать как разделитель
            var resultArr1 = inputText.Split(' ');

            var resultArrLength1 = resultArr1.Length; // в массиве будет содержаться 8 значений, 3 из которых будут пустыми.

            // Вызываем у переменной inputText метод Split() и указываем какой символ использовать как разделитель
            // Но в этот раз мы длополнительно указываем специальный флаг, что бы не включать в массив пустые строки
            // См.: https://docs.microsoft.com/ru-ru/dotnet/csharp/how-to/parse-strings-using-split
            var resultArr2 = inputText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var resultArrLength2 = resultArr2.Length; // в массиве будет содержаться 5 значений

            // У нас есть массив строк. Тепер, что бы получить сумму чисел необходимо перебрать массив
            // Преобразовать элементы массива в число и сложить их в сумму. Есть два способа решения

            // Через цикл:
            int sum1 = 0;
            for (int i = 0; i < resultArr2.Length; i++)
            {
                // Проверяем конвертируется ли строка в число. Если число сконвертировалось, оно поместиться в переменную num
                // а само выполнение программы продолжиться с заходом в блок условия
                if (int.TryParse(resultArr2[i], out var num)) // См.: https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
                {
                    // плюсуем число
                    sum1 += num;
                }
            }

            Console.WriteLine($"Сумма найденная через цикл: {sum1}");

            // Но есть более читрый способ решения: с помощью применения методов расширения Linq:

            int sum2 = resultArr2.Select(numText => int.Parse(numText)) // Обращаемся к каждому элементу массива и конвертируем его в число
                                    .Sum();  // Вызываем метод подсчета суммы - он сам посчитает общую сумму и поместит ее в переменную

            Console.WriteLine($"Сумма найденная через Linq: {sum2}");

            /*
             * Задание 3.
             * Написать метод по определению времени года. 
             * На вход подаётся число – порядковый номер месяца. 
             * На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn. 
             * Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года (зима, весна, лето, осень). 
             * Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года. 
             * Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».             * 
             */

            // Главный вопрос, который может появиться: "как лучше проверить введенное число?"
            // Можно:
            // 1. написать несклько условий
            // 2. использовать проваливание операторов switch case. См.: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/switch#the-switch-section
            // 3. Использовать новый более свежий синтаксический сахар конструкции switch

            // в методах GetSeasonsVariable1 GetSeasonsVariable2 и GetSeasonsVariable3 приведены примеры использования всех трех вариантов:


            int number = 3;
            try
            {
                Console.WriteLine($"Месяц {number} - это {GetSeasonsVariable3(number)}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        public static Seasons GetSeasonsVariable1(int montheNumber)
        {
            if (montheNumber >= 1 && montheNumber <= 12)
            {
                if (montheNumber <= 2 || montheNumber == 12)
                    return Seasons.Winter;
                else if (montheNumber >= 3 && montheNumber <= 5)
                    return Seasons.Spring;
                else if (montheNumber >= 6 && montheNumber <= 8)
                    return Seasons.Summer;
                else if (montheNumber >= 9 && montheNumber <= 11)
                    return Seasons.Autumn;
            }
            throw new Exception($"Вы ввели некоректное число ({montheNumber}), нужно от 1 до 12!");
        }

        public static Seasons GetSeasonsVariable2(int montheNumber)
        {
            switch (montheNumber)
            {
                case 1: // Если после оператора case не идет оператор break; то выполнение кода будет проваливаться до первого его появления
                case 2:
                case 12:
                    return Seasons.Winter;
                case 3:
                case 4:
                case 5:
                    return Seasons.Spring;
                case 6:
                case 7:
                case 8:
                    return Seasons.Summer;
                case 9:
                case 10:
                case 11:
                    return Seasons.Summer;
                default:
                    throw new Exception($"Вы ввели некоректное число ({montheNumber}), нужно от 1 до 12!");
            }
        }

        public static Seasons GetSeasonsVariable3(int montheNumber)
        {
            var selectedSeason = montheNumber switch
            {
                /*
                 * Этот код работает только наичная с .NET 5
                 * 
                 * 1 or 2 or 12 => Seasons.Winter,
                 * 3 or 4 or 5 => Seasons.Spring,
                 * 6 or 7 or 8 => Seasons.Summer,
                 * 9 or 10 or 11 => Seasons.Autumn,
                 * 
                 */

                1 => Seasons.Winter,
                2 => Seasons.Winter,
                3 => Seasons.Spring,
                4 => Seasons.Spring,
                5 => Seasons.Spring,
                6 => Seasons.Summer,
                7 => Seasons.Summer,
                8 => Seasons.Summer,
                9 => Seasons.Autumn,
                10 => Seasons.Autumn,
                11 => Seasons.Autumn,
                12 => Seasons.Winter,
                _ => throw new Exception($"Вы ввели некоректное число ({montheNumber}), нужно от 1 до 12!") // Если ввели число за пределами 1-12 - выбрасываем исключение с ссобщением
            };
            return selectedSeason;
        }
    }
}
