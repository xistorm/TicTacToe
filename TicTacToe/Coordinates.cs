using System;

namespace TicTacToe
{
    public class Coordinates
    {
        /// <summary>
        /// поле X координаты с доступом для чтения только
        /// </summary>
        public int X { get; protected set; }
        /// <summary>
        /// поле X координаты с доступом для чтения только
        /// </summary>
        public int Y { get; protected set; }

        /// <summary>
        /// Конструктор с данными
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <exception cref="Exception"></exception>
        public Coordinates(int x, int y)
        {
            if (!IsCorrect(x) || !IsCorrect(y))
                throw new Exception("Incorrect value");
            
            X = x;
            Y = y;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Coordinates() : this(0, 0) {}

        
        /// <summary>
        /// Проверка на выход за границы поля
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        static protected bool IsCorrect(int coord)
        {
            if (coord < 0 || coord >= Field.Size)
                return false;
            return true;
        }

        
        /// <summary>
        /// Перегрузка метода по преобразованию в строку (написано через лямбду, тк одна строка)
        /// </summary>
        /// <returns></returns>
        public override string ToString() => X.ToString() + ", " + Y.ToString();
    }
}