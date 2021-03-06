using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;

namespace MonoGameJamProject.Towers
{
    /// <summary>
    /// Goal: Base class for the game's towers.
    /// </summary>
    abstract class Tower
    {
        private const float highlightOffset = 0.07F;
        public Color towerColor;
        protected int minRange, maxRange;
        protected bool disabled = false;
        protected CoolDownTimer attackTimer;
        public Utility.TowerType type;
        public int Damage
        {
            get; set;
        }
        public string towerInfo;
        int _x;
        int _y;
        public Tower(int iX, int iY, float iAttackCooldown, int iHotkeyNumber)
        {
            _x = iX;
            _y = iY;
            attackTimer = new CoolDownTimer(iAttackCooldown);
            attackTimer.Reset();
            attackTimer.SecondsElapsed = iAttackCooldown / 2;
            towerInfo = "undefined";
            HotkeyNumber = iHotkeyNumber;
        }
        public virtual void Update(GameTime gameTime)
        {
            attackTimer.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch s)
        {
            if (disabled)
                s.FillRectangle(new RectangleF(Utility.GameToScreen(_x), Utility.GameToScreen(_y), Utility.board.GridSize, Utility.board.GridSize), Color.Gray);
            else
                s.FillRectangle(new RectangleF(Utility.GameToScreen(_x), Utility.GameToScreen(_y), Utility.board.GridSize, Utility.board.GridSize), towerColor);
            s.DrawString(Utility.assetManager.GetFont("Jura"), HotkeyNumber.ToString(), new Vector2(Utility.GameToScreen(_x) + Utility.board.GridSize / 2.5F, Utility.GameToScreen(_y) + Utility.board.GridSize / 4), Color.Black, 0f, Vector2.Zero, 0.010f * Utility.board.GridSize, SpriteEffects.None, 0);
            DrawCoolDownTimer(s);
        }

        private void DrawCoolDownTimer(SpriteBatch s)
        {
            Vector2 position = new Vector2(Utility.GameToScreen(X), Utility.GameToScreen(Y) + Utility.board.GridSize / 8);
            RectangleF coolDownRectangle = new RectangleF(position.X, position.Y, 1 * ((attackTimer.MaxTime - attackTimer.SecondsElapsed) / attackTimer.MaxTime) * Utility.board.GridSize, Utility.board.GridSize / 8);
            s.FillRectangle(coolDownRectangle, Color.Yellow);
            RectangleF outlineRectangle = new RectangleF(position.X, position.Y, Utility.board.GridSize , Utility.board.GridSize / 8);
            s.DrawRectangle(outlineRectangle, Color.Black, 2F);
        }

        public void DrawSelectionHightlight(SpriteBatch s)
        {
            s.FillRectangle(new RectangleF(Utility.GameToScreen(_x) - Utility.board.GridSize * highlightOffset / 2, Utility.GameToScreen(_y) - Utility.board.GridSize * highlightOffset / 2, Utility.board.GridSize + highlightOffset * Utility.board.GridSize, Utility.board.GridSize + highlightOffset * Utility.board.GridSize), Color.Yellow);
        }
        protected bool IsWithinRange(int iX, int iY)
        {
            return !(Math.Abs(iX) > minRange || Math.Abs(iY) > minRange);
        }

        protected bool RangeChecker(float iX, float iY, int range)
        {
            bool top = iY < _y - range;
            bool right = iX > _x + 1 + range;
            bool bottom = iY > _y + 1 + range;
            bool left = iX < _x - range;

            return !(top || right || bottom || left);
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public bool IsDisabled
        {
            get { return disabled; }
            set { disabled = value; }
        }
        public int MinimumRange
        {
            get { return minRange; }
        }
        public int MaximumRange
        {
            get { return maxRange; }
        }

        public int HotkeyNumber
        {
            get; set;
        }
    }
}

