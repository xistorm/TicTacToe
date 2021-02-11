namespace TicTacToe
{
    //Реализация наследования
    public class Cell : Coordinates
    {
        public MarkType Type { get; private set; }

        public Cell(int x, int y) : base(x, y) {}
        public Cell(int x, int y, MarkType type) : base(x, y)
        {
            Type = type;
        }
    }
}