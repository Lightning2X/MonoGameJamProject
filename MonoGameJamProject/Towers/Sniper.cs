﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace MonoGameJamProject.Towers
{
    class Sniper : Tower
    {
        Minion targetedMinion;
        public Sniper(int iX, int iY) : base(iX, iY)
        {
            towerColor = Color.White;
            type = Utility.TowerType.Sniper;
            minRange = 2;
            towerInfo = "Sniper Tower\n MinRange: " + minRange + "\nMaxRange: INFINITE!\nPosX:";
        }

        public override void Update(GameTime gameTime, List<Minion> iMinionList)
        {
            TargetClosestMinion(iMinionList);
            base.Update(gameTime, iMinionList);
        }

        public override void Draw(SpriteBatch s)
        {
            base.Draw(s);
            if (!disabled && !(targetedMinion == null))
                s.DrawLine(Utility.GameToScreen(this.X) + Utility.board.GridSize / 2, Utility.GameToScreen(this.Y) + Utility.board.GridSize / 2, Utility.GameToScreen(targetedMinion.Position.X), Utility.GameToScreen(targetedMinion.Position.Y), Color.Red, 2f);
        }

        private void TargetClosestMinion(List<Minion> minionList)
        {
            if (minionList.Count > 0)
            {
                foreach (Minion m in minionList)
                {
                    if(CheckMinimumRange((int)Math.Floor(m.Position.X), (int)Math.Floor(m.Position.Y)))
                    {

                    }
                    targetedMinion = m;
                    break;

                }
            }
            else
                targetedMinion = null;
            
        }

    }
}
