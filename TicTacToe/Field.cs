using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    public class Field
    {
        //поля (статик для обращение через сам класс, а не экземпляр)
        static public ushort  Size  { get; private set; }
        public Cell[,] Cells { get; private set; }

        /// <summary>
        /// Конструктор с размером и контейнером с кнопками
        /// </summary>
        /// <param name="size"></param>
        /// <param name="grid"></param>
        public Field(ushort size, ref Grid grid)
        {
            Size = size;
            
            Cells = new Cell[size, size];
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    Cells[i, j] = new Cell(i, j, MarkType.Free);
            
            //берём контейнер->все дочерние элементы->из них кнопки->из них формируем список->проходимся по всем элементам
            grid.Children.Cast<Button>().ToList().ForEach(buttun =>
            {
                buttun.Content    = string.Empty;
                buttun.Background = Brushes.White;
                buttun.Foreground = Brushes.Blue;
            });
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Field()
        {
            Size = 0;
            Grid grid = new Grid();
        }
    }
}