﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Fleet
    {
        public void CreateShip(IEnumerable<Square> squares)
        {
            //DZ Pozvati ctor broda i dodati u kolekciju shipova
        }

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }

        private List<Ship> ships = new List<Ship>();
    }
}