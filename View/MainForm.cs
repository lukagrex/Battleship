using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Vsite.Battleship.Model;
using System.Linq;

namespace View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Visible = true;
            Debug.WriteLine($"Button clicked---{sender}");
        }

        private FleetGrid fleetGrid = new FleetGrid(10, 10);
        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var square = fleetGrid.Squares.Where(s => s.Row == e.Row && s.Column == e.Column).First();
            switch (square.SquareState)
            {
                case SquareState.Initial:
                    e.Graphics.FillRectangle(Brushes.DimGray, e.CellBounds);
                    break;
                case SquareState.Missed:
                    e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
                    break;
                case SquareState.Hit:
                    e.Graphics.FillRectangle(Brushes.DarkSeaGreen, e.CellBounds);
                    break;
                case SquareState.Sunken:
                    e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds);
                    break;
                default:
                    throw new NotImplementedException();
            }

        }
        private int row1 = 1;
        private int col1 = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            fleetGrid.Squares.Where(s => s.Row == row1 && s.Column == col1).First().ChangeState(SquareState.Sunken);
            row1 += 1;
            col1 += 2;
            tableLayoutPanel1.Refresh();
        }
    }
}
