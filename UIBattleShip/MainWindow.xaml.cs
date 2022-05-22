using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Model;
using Grid = System.Windows.Controls.Grid;

namespace UIBattleShip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class BattleShipButton : Button
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Brush initColor = new SolidColorBrush(Colors.Aquamarine);
        private Brush hitColor = new SolidColorBrush(Colors.Red);
        private Brush sunkenColor = new SolidColorBrush(Colors.DarkBlue);
        private Brush missedColor = new SolidColorBrush(Colors.DodgerBlue);
        private Brush shipColor = new SolidColorBrush(Colors.Silver);
        private Brush notHitShipsColor = new SolidColorBrush(Colors.DarkMagenta);

        public readonly int gridNumOfRows = 10;
        public readonly int gridNumOfColumns = 10;
        public readonly List<int> initShips = new List<int>() { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };

        private Shipwright shipwright;
        private Fleet computersFleet;
        private Gunnery computersGunnary;
        private Fleet playersFleet;
        private bool playersTurn;

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < gridNumOfRows; i++)
            {
                for (int j = 0; j < gridNumOfColumns; j++)
                {
                    var playersLabel = this.GetInitGridLabel(true);
                    playersLabel.X = i;
                    playersLabel.Y = j;
                    PlayersGrid.Children.Add(playersLabel);
                    Grid.SetRow(playersLabel, i);
                    Grid.SetColumn(playersLabel, j);

                    var computerLabel = this.GetInitGridLabel(false);
                    computerLabel.X = i;
                    computerLabel.Y = j;
                    ComputersGrid.Children.Add(computerLabel);
                    Grid.SetRow(computerLabel, i);
                    Grid.SetColumn(computerLabel, j);
                }
            }

            this.shipwright = new Shipwright(gridNumOfRows, gridNumOfColumns, initShips);
            this.computersFleet = this.shipwright.CreateFleet();
            this.computersGunnary = new Gunnery(gridNumOfRows, gridNumOfColumns, initShips);
        }

        private void ShowRestOfComputersFleet()
        {
            foreach (var ship in this.computersFleet.Ships)
            {
                foreach (var square in ship.Squares.Where(s => s.SquareState != SquareState.Sunken && s.SquareState != SquareState.Hit))
                {
                    var button = this.GetComputersGridsSquare(square.Row, square.Column);
                    button.Background = this.notHitShipsColor;
                }
            }
        }

        private BattleShipButton GetInitGridLabel(bool isPlayerFleet)
        {
            var button = new BattleShipButton();
            button.Background = initColor;
            button.BorderBrush = new SolidColorBrush(Colors.Black);
            button.BorderThickness = new Thickness(1);
            button.Click += isPlayerFleet ? PlayerButton_OnClick : ComputerButton_OnClick;
            return button;
        }

        private void PlayerButton_OnClick(object sender, RoutedEventArgs args)
        {
            if (playersTurn || this.Random.IsEnabled)
                return;

            playersTurn = true;
            var battleButton = sender as BattleShipButton;
            var hitResult = this.playersFleet.Shoot(battleButton.X, battleButton.Y);
            this.computersGunnary.ProcessHitResult(hitResult);
            this.ProcessShotResult(battleButton, hitResult, true);

            if (!this.computersGunnary.HaveLiveShips())
            {
                this.ComputerWins();
            }

        }

        private void ProcessShotResult(BattleShipButton battleButton, HitResult hitResult, bool isPlayerFleet)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    battleButton.Background = this.missedColor;
                    break;

                case HitResult.Hit:
                    battleButton.Background = this.hitColor;
                    break;

                case HitResult.Sunken:
                    this.ProcessSunken(isPlayerFleet);
                    break;
            }
        }

        private void ProcessSunken(bool isPlayerFleet)
        {
            var fleet = isPlayerFleet ? this.playersFleet : this.computersFleet;

            foreach (var fleetShip in fleet.Ships)
            {
                if (fleetShip.Squares.First().SquareState == SquareState.Sunken)
                {
                    foreach (var fleetShipSquare in fleetShip.Squares)
                    {
                        var button = isPlayerFleet
                            ? this.GetPlayersGridsSquare(fleetShipSquare.Row, fleetShipSquare.Column)
                            : this.GetComputersGridsSquare(fleetShipSquare.Row, fleetShipSquare.Column);

                        button.Background = this.sunkenColor;
                    }
                }
            }
        }

        private void ComputerButton_OnClick(object sender, RoutedEventArgs args)
        {
            if (!playersTurn || this.Random.IsEnabled)
                return;

            playersTurn = false;

            var battleButton = sender as BattleShipButton;
            var hitResult = this.computersFleet.Shoot(battleButton.X, battleButton.Y);
            this.ProcessShotResult(battleButton, hitResult, false);

            if (this.AllComputersShipsAreSunken())
            {
                this.PlayerWins();
                return;
            }

            this.ComputersTurn();
        }

        private bool AllComputersShipsAreSunken()
        {
            foreach (var computersFleetShip in this.computersFleet.Ships)
            {
                if (computersFleetShip.Squares.First().SquareState != SquareState.Sunken)
                {
                    return false;
                }
            }

            return true;
        }

        private void ComputersTurn()
        {
            var computersTarget = this.computersGunnary.NextTarget();
            if (computersTarget == null)
            {
                this.ComputerWins();
                return;
            }
            var playersButton = this.GetPlayersGridsSquare(computersTarget.Row, computersTarget.Column);
            this.PlayerButton_OnClick(playersButton, null);
        }

        private void ComputerWins()
        {
            this.ShowRestOfComputersFleet();
            string messageBoxText = "Computer wins :-)";
            string caption = "End of the Game";

            MessageBox.Show(messageBoxText, caption);
            this.RestartGame();
        }

        private void PlayerWins()
        {
            string messageBoxText = "Player wins :-)";
            string caption = "End of the Game";

            MessageBox.Show(messageBoxText, caption);
            this.RestartGame();
        }


        private void RestartGame()
        {
            this.computersFleet = this.shipwright.CreateFleet();
            this.computersGunnary = new Gunnery(gridNumOfRows, gridNumOfColumns, initShips);
            this.Start.IsEnabled = false;
            this.Random.IsEnabled = true;
            this.ResetPlayersGridToInitState();
            this.ResetComputersGridToInitState();
        }

        private void Random_OnClick(object sender, RoutedEventArgs e)
        {
            if (!this.Random.IsEnabled)
            {
                return;
            }

            if (!this.Start.IsEnabled)
            {
                this.Start.IsEnabled = true;
            }

            this.playersFleet = this.shipwright.CreateFleet();
            this.ResetPlayersGridToInitState();
            this.DrawPlayersFleet();
        }

        private void ResetPlayersGridToInitState()
        {
            foreach (BattleShipButton playersButton in PlayersGrid.Children.OfType<BattleShipButton>())
            {
                playersButton.Background = initColor;
            }
        }

        private void ResetComputersGridToInitState()
        {
            foreach (BattleShipButton computersButton in ComputersGrid.Children.OfType<BattleShipButton>())
            {
                computersButton.Background = initColor;
            }
        }

        private void DrawPlayersFleet()
        {
            foreach (var ship in this.playersFleet.Ships)
            {
                foreach (var shipSquare in ship.Squares)
                {
                    this.ShowPlayersShipSquare(shipSquare.Row, shipSquare.Column);
                }
            }
        }

        private void ShowPlayersShipSquare(int row, int column)
        {
            var button = this.GetPlayersGridsSquare(row, column);
            button.Background = this.shipColor;
        }

        private BattleShipButton GetPlayersGridsSquare(int row, int column)
        {
            return PlayersGrid.Children
                .OfType<BattleShipButton>()
                .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);
        }

        private BattleShipButton GetComputersGridsSquare(int row, int column)
        {
            return ComputersGrid.Children
                .OfType<BattleShipButton>()
                .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);
        }

        private void Start_OnClick(object sender, RoutedEventArgs e)
        {
            if (!this.Start.IsEnabled)
            {
                return;
            }

            this.Start.IsEnabled = false;
            this.Random.IsEnabled = false;

            var rand = new Random();
            this.playersTurn = rand.Next(2) == 1;

            if (!playersTurn)
            {
                this.ComputersTurn();
            }
        }
    }
}