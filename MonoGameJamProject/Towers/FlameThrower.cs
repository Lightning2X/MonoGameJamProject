﻿using Microsoft.Xna.Framework;

namespace MonoGameJamProject.Towers
{
    class FlameThrower : Tower
    {
        public FlameThrower(int iX, int iY) : base(iX, iY)
        {
            towerColor = Color.Orange;
            type = Utility.TowerType.FlameThrower;
            minimumRange = 0;
        }
    }
}