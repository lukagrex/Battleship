﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public enum ShootingTactics
    {
        Random,
        Surrounding,
        Inline
    }

    public class Gunnery
    {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {

        }
        public void ProcessHitResult(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    return;
                case HitResult.Hit:
                    switch (ShootingTactics)
                    {
                        case ShootingTactics.Random:
                            currentTactics = ShootingTactics.Surrounding;
                            return;
                        case ShootingTactics.Surrounding:
                            currentTactics = ShootingTactics.Inline;
                            return;
                        case ShootingTactics.Inline:
                            return;
                    }
                    return;
                case HitResult.Sunken:
                    currentTactics = ShootingTactics.Random;
                    return;
            }
        }

        private ShootingTactics currentTactics = ShootingTactics.Random;

        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }
    }
}
