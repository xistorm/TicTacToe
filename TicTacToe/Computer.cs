using System;
using System.Linq;
using System.Windows.Controls;

namespace TicTacToe
{
    //Реализоция наследования
    public class Computer : Player
    {
        //поля
        private Random _rand;

        /// <summary>
        /// Конструктор с передаваемыми символом и контейнером
        /// </summary>
        /// <param name="markType"></param>
        /// <param name="grid"></param>
        public Computer(MarkType markType, ref Grid grid) : base(markType, ref grid)
        {
            _rand = new Random();
        }

        //реализация полиморфизма
        /// <summary>
        /// Сделать ход
        /// </summary>
        /// <param name="clicked"></param>
        /// <returns></returns>
        public override bool DoTurn(ref Button clicked)
        {
            if (!CheckTie())
                return true;
            
            int x, y;
            var buttons = Container.Children.Cast<Button>().ToList();

            do
            {
                x = _rand.Next(Field.Size);
                y = _rand.Next(Field.Size);
            } while (!CorrectTurn(buttons[x * Field.Size + y]));
            Cell newCell = new Cell(x, y);
            
            Field.Cells[x, y] = newCell;
            Turns.Add(newCell);

            buttons[x * Field.Size + y].Content = (char) _markType;

            return true;
        }
    }
}