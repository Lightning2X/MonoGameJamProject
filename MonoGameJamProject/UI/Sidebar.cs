﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJamProject.Towers;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using System;

namespace MonoGameJamProject.UI
{
    class Sidebar
    {
        private float towerInfoOffset;
        int effectTick;
        Vector2 position, offset;
        public Sidebar(Vector2 iOffset)
        {
            effectTick = 0;
            offset = iOffset;
            towerInfoOffset = 190;
        }

        public void Update(GameTime gameTime)
        {
            position = new Vector2(Utility.Window.ClientBounds.Width - offset.X, offset.Y);
            effectTick++;
            if (effectTick > 100)
                effectTick = 0;
        }

        public void Draw(SpriteBatch s)
        {
            DrawPlayTime(s);

            Color placetowerscolor = Color.Gray;
            if (Utility.MaxTowers - Utility.TowerList.Count > 0)
            {
                if (effectTick > 50)
                {
                    placetowerscolor = Color.Red;
                }
                else
                    placetowerscolor = Color.White;
            }
            s.DrawString(Utility.assetManager.GetFont("Jura"), "Lives: " + Utility.numberOfLives, new Vector2(position.X, position.Y + 30), Color.Green, 0f, Vector2.Zero, 0.5F, SpriteEffects.None, 0);
            s.DrawString(Utility.assetManager.GetFont("Jura"), "Difficulty: " + Utility.GameDifficulty, new Vector2(position.X, position.Y + 60), Color.Aqua, 0f, Vector2.Zero, 0.5F, SpriteEffects.None, 0);
            s.DrawString(Utility.assetManager.GetFont("Jura"), "Kills: " + Utility.totalNumberOfKills, new Vector2(position.X, position.Y + 90), Color.White, 0f, Vector2.Zero, 0.5F, SpriteEffects.None, 0);
            s.DrawString(Utility.assetManager.GetFont("Jura"), "Score: " + Utility.Score, new Vector2(position.X, position.Y + 120), Color.White, 0f, Vector2.Zero, 0.5F, SpriteEffects.None, 0);
            s.DrawString(Utility.assetManager.GetFont("Jura"), "Placeable towers: " + (Utility.MaxTowers - Utility.TowerList.Count), new Vector2(position.X, position.Y + 150), placetowerscolor, 0f, Vector2.Zero, 0.5F, SpriteEffects.None, 0);
           
            s.DrawString(Utility.assetManager.GetFont("Jura"), "Music by YERZMYEY", new Vector2(position.X, position.Y + 440), Color.LightGray, 0f, Vector2.Zero, 0.45F, SpriteEffects.None, 0);

        }

        public void DrawTowerInfo(SpriteBatch s, Tower tower)
        {
            s.FillRectangle(new RectangleF(position.X + 20, position.Y + towerInfoOffset, Utility.board.GridSize, Utility.board.GridSize), tower.towerColor);
            s.DrawRectangle(new RectangleF(position.X + 20, position.Y + towerInfoOffset, Utility.board.GridSize, Utility.board.GridSize), Color.White, 1);
            s.DrawString(Utility.assetManager.GetFont("Jura"), tower.towerInfo, new Vector2(position.X, position.Y + (towerInfoOffset + Utility.board.GridSize + 5)), Color.Yellow, 0f, Vector2.Zero, 0.35F, SpriteEffects.None, 0);
        }

        public void DrawPlayTime(SpriteBatch s)
        {
            string time = Utility.tdGameTimer.Minutes.ToString("D2") + ":" + Utility.tdGameTimer.Seconds.ToString("D2");
            s.DrawString(Utility.assetManager.GetFont("Jura"), time, position, Color.Red, 0f, Vector2.Zero, 0.5F, SpriteEffects.None, 0);
        }
    }
}
