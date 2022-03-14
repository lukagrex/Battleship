namespace Model
{
    public class Square
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Square(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
