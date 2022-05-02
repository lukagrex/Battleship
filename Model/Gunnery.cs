using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    if (currentTactics == ShootingTactics.Inline)
                        return;
                    break;
                case HitResult.Sunken:
                    break;
                default:
                    Debug.Assert(false);
                    return;
            }
            ChangeCurrentTactics(hitResult);
        }

        private ShootingTactics currentTactics = ShootingTactics.Random;
        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }

        private void ChangeCurrentTactics(HitResult hitResult)
        {
            if (hitResult == HitResult.Sunken)
            {
                ChangeToRandomTactics();
            }
            else
            {
                switch(currentTactics)
                {
                    case ShootingTactics.Random:
                        ChangeToSurroundingTactics();
                        break;
                    case ShootingTactics.Surrounding:
                        ChangeToInlineTactics();
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
        }

        private void ChangeToSurroundingTactics()
        {
            currentTactics = ShootingTactics.Surrounding;
        }

        private void ChangeToInlineTactics()
        {
            currentTactics = ShootingTactics.Inline;
        }

        private void ChangeToRandomTactics()
        {
            currentTactics = ShootingTactics.Random;
        }
    }
}
