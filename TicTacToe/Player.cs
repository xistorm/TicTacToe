using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace TicTacToe
{
    public class Player
    {
        //Поля
        protected MarkType _markType;
        public Field       Field     { get; set; }
        public List<Cell>  Turns     { get; private set; }
        public Grid        Container { get; private set; }

        /// <summary>
        /// конструктор с передаваемыми символом и контейнером
        /// </summary>
        /// <param name="markType"></param>
        /// <param name="grid"></param>
        public Player(MarkType markType, ref Grid grid)
        {
            _markType = markType;
            Field     = new Field(3, ref grid);
            Turns     = new List<Cell>();
            Container = grid;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Player()
        {
            _markType = MarkType.Free;
            Container = new Grid();
        }

        /// <summary>
        /// Сделать ход
        /// </summary>
        /// <param name="clicked"></param>
        /// <returns></returns>
        public virtual bool DoTurn(ref Button clicked)
        {
            int x = clicked.Name[6] - '0';
            int y = clicked.Name[8] - '0';
            var newCell = new Cell(x, y, _markType);
            
            if (CorrectTurn(clicked))
            {
                Field.Cells[x, y] = newCell;
                Turns.Add(newCell);

                clicked.Content = (char) _markType;

                return true;
            }
            else
            {
                MessageBox.Show("This is incorrect. Try again.");

                return false;
            }
        }

        /// <summary>
        /// Проиграл ли игрок
        /// </summary>
        /// <returns></returns>
        public bool IsLost() => !CheckDiagonal() || !CheckStraight() || !CheckTie();

        /// <summary>
        /// Свободна ли клетка
        /// </summary>
        /// <param name="clicked"></param>
        /// <returns></returns>
        static public bool CorrectTurn(Button clicked) => clicked.Content is string;

        /// <summary>
        /// Проверка строк и столбцов
        /// </summary>
        /// <returns></returns>
        protected bool CheckStraight()
        {
            for (int i = 0; i < Field.Size; ++i)
            {
                bool row = false;
                bool col = false;
                if (Field.Cells[i, i].Type != MarkType.Free)
                {
                    for (int j = 1; j < Field.Size; ++j)
                    {
                        if (Field.Cells[i, j].Type != Field.Cells[i, j - 1].Type)
                            row = true;
                        if (Field.Cells[j, i].Type != Field.Cells[j - 1, i].Type)
                            col = true;
                    }

                    if (!(col && row))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Проверка диагоналей
        /// </summary>
        /// <returns></returns>
        protected bool CheckDiagonal()
        {
            int n = Field.Size;
            bool diag1 = false;
            bool diag2 = false;
            
            for (int i = 1; i < n; ++i)
            {
                if (Field.Cells[i, i].Type == MarkType.Free || Field.Cells[i, i].Type != Field.Cells[i - 1, i - 1].Type)
                    diag1 = true;
                if (Field.Cells[i, n - i - 1].Type == MarkType.Free || Field.Cells[i, n - i - 1].Type != Field.Cells[i - 1, n - i].Type)
                    diag2 = true;
            }

            return diag1 && diag2;
        }

        /// <summary>
        /// проверка ничьи
        /// </summary>
        /// <returns></returns>
        protected bool CheckTie() => Container.Children.Cast<Button>().ToList().Any(x => x.Content is string);
    }
}