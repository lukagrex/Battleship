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
        public MainForm()
        {
            grid1 = new Button[100, 100];
            grid2 = new Button[100, 100];
            InitializeComponent();
            InitailizeGrid(grid1, "p1", 0);
            InitailizeGrid(grid2, "p2", 350);
        }

        public void InitailizeGrid(Button[,] grid, string name, int offset)
        {
            this.SuspendLayout();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = new System.Windows.Forms.Button();
                    grid[i, j].Location = new System.Drawing.Point(offset + 20 + j * 30, 70 + i * 30);
                    grid[i, j].Name = name + "button" + i.ToString() + j.ToString();
                    grid[i, j].Size = new System.Drawing.Size(30, 30);
                    grid[i, j].TabIndex = 0;
                    grid[i, j].UseVisualStyleBackColor = true;
                    this.Controls.Add(grid[i, j]);
                }
            }

            this.ResumeLayout(false);
        }

        private readonly Button[,] grid1;
        private readonly Button[,] grid2;

        private void button1_Click(object sender, EventArgs e)
        {
            FleetGrid fleetGrid = new FleetGrid(10, 10);
            EnemyGrid enemyGrid = new EnemyGrid(10, 10);
            if (playerRadioButton.Checked)
            {
                //
            }
        }
    }
}
