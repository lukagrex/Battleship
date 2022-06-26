using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vsite.Battleship.Model;

namespace GUI
{
    public partial class MainForm : Form
    {

        private readonly int playerGridHorizotalOffset = 20;
        private readonly int playerGridVerticalOffset = 70;
        private readonly int computerToPlayerGridHorizontalOffset = 350;
        private readonly int gridButtonSize = 30;

        private readonly Color hitColor = Color.Yellow;
        private readonly Color sunkColor = Color.Red;
        private readonly Color missedColor = Color.Black;
        public MainForm()
        {
            playerGrid = new GridButton[100, 100];
            computerGrid = new GridButton[100, 100];
            InitializeComponent();
            InitailizeGrid(playerGrid, "p1", 0, false);
            InitailizeGrid(computerGrid, "p2", computerToPlayerGridHorizontalOffset, true);
        }

        private GridButton[,] playerGrid;
        private GridButton[,] computerGrid;
        bool playerTurn;
        private Shipwright shipwright;
        //private Shipwright shipwrightEnemy;
        private Fleet playerFleet;
        private Fleet enemyFleet;
        private Gunnery gunnery;
        IEnumerable<int> shipLengths = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };

        public void InitailizeGrid(GridButton[,] grid, string name, int computerToPlayerGridHorizontalOffset, bool enemyGrid)
        {
            this.SuspendLayout();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = new GridButton(i, j, !enemyGrid);
                    grid[i, j].Location = new System.Drawing.Point(computerToPlayerGridHorizontalOffset + playerGridHorizotalOffset + j * gridButtonSize, playerGridVerticalOffset + i * gridButtonSize);
                    grid[i, j].Name = name + "button" + i.ToString() + j.ToString();
                    grid[i, j].Size = new System.Drawing.Size(gridButtonSize, gridButtonSize);
                    grid[i, j].TabIndex = 0;
                    grid[i, j].UseVisualStyleBackColor = true;

                    if (enemyGrid)
                        grid[i, j].Click += new System.EventHandler(this.EnemyGridButton_Click);
                    if (!enemyGrid)
                        grid[i, j].Enabled = false;

                    this.Controls.Add(grid[i, j]);
                }
            }

            this.ResumeLayout(false);
        }

        

        private void startGameButton_Click(object sender, EventArgs e)
        {

            shipwright = new Shipwright(10, 10, shipLengths);
            playerFleet = shipwright.CreateFleet();
            enemyFleet = shipwright.CreateFleet();
            gunnery = new Gunnery(10, 10, shipLengths);

            foreach (Ship ship in playerFleet.Ships)
            {
                foreach (Square square in ship.Squares)
                {
                    playerGrid[square.Row, square.Column].BackColor = Color.Blue;
                }
            }

            if (playerRadioButton.Checked)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
                this.ComputerTurn();
            }

            this.startGameButton.Enabled = false;

            /*
            foreach (Ship ship in enemyFleet.Ships)
            {
                foreach (Square square in ship.Squares)
                {
                    computerGrid[square.Row, square.Column].BackColor = Color.Red;
                }
            }
            */
        }

        private void EnemyGridButton_Click(object sender, EventArgs e)
        {
            if (playerTurn)
            {

                playerTurn = false;

                var pressedButton = sender as GridButton;
                pressedButton.BackColor = Color.Black;

                var hitResult = this.enemyFleet.Shoot(pressedButton.row, pressedButton.column);
                this.ShowShotResult(pressedButton, hitResult);

                if (enemyFleet.Ships.All(x => x.Squares.All(y => y.SquareState == SquareState.Sunken)))
                {
                    infoTextBox.Text = "PLAYER WINS!";
                    DisableButtons();
                    return;
                }

                this.ComputerTurn();

            }

        }

        private void ComputerTurn()
        {
            var targetSquare = this.gunnery.NextTarget();

            if (targetSquare == null)
            {
                infoTextBox.Text = "COMPUTER WINS!";
                DisableButtons();
                return;
            }
            var selectedButton = this.playerGrid[targetSquare.Row, targetSquare.Column];

            if (!playerTurn)
            {
                playerTurn = true;

                var hitResult = this.playerFleet.Shoot(selectedButton.row, selectedButton.column);
                this.gunnery.ProcessHitResult(hitResult);
                this.ShowShotResult(selectedButton, hitResult);

                if (playerFleet.Ships.All(x => x.Squares.All(y => y.SquareState == SquareState.Sunken)))
                {
                    infoTextBox.Text = "COMPUTER WINS!";
                    DisableButtons();
                    return;
                }
            }
        }

        private void DisableButtons()
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    computerGrid[i, j].Enabled = false;
                }
            }
        }

        private void ShowShotResult(GridButton button, HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Hit:
                    button.BackColor = hitColor;
                    break;

                case HitResult.Missed:
                    button.BackColor = missedColor;
                    break;

                case HitResult.Sunken:
                    ChangeColorOfSunkenShip(button);
                    break;
            }
        }

        private void ChangeColorOfSunkenShip(GridButton button)
        {
            var ships = button.isPlayerButton ? playerFleet.Ships : enemyFleet.Ships;
            var grid = button.isPlayerButton ? playerGrid : computerGrid;
            foreach (Ship ship in ships)
            {
                if (ship.Squares.All(x => x.SquareState == SquareState.Sunken))
                {
                    foreach (Square square in ship.Squares)
                    {
                        grid[square.Row, square.Column].BackColor = sunkColor;
                    }
                }
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            
            this.gunnery = new Gunnery(10, 10, shipLengths);
            if (playerFleet != null && (enemyFleet != null))
            {
                this.playerFleet = this.shipwright.CreateFleet();
                this.enemyFleet = this.shipwright.CreateFleet();
            }
            infoTextBox.Clear();
            startGameButton.Enabled = true;

            for(int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    playerGrid[i, j].BackColor = System.Drawing.SystemColors.Control;
                    computerGrid[i, j].BackColor = System.Drawing.SystemColors.ControlLight;
                    computerGrid[i, j].Enabled = true;
                }
            }
      
        }
    }

    public class GridButton : Button
    {
        public GridButton(int row, int column, bool isPlayerButton) : base()
        {
            this.row = row;
            this.column = column;
            this.isPlayerButton = isPlayerButton;
        }

        public int row;
        public int column;
        public bool isPlayerButton;
    }
}
