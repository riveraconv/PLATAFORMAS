using System;

namespace PLATAFORMAS
{
    public class Character
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool IsFalling { get; set; }
        public bool CanJump { get; private set; } = true;
        private int jumpVelocity;
        private int horizontalSpeed;
        public Character(int x, int y)
        {
            PositionX = x;
            PositionY = y;
            IsFalling = false;
            jumpVelocity = 0;
            horizontalSpeed = 0;
        }
        public void DrawPlayer()
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("ö");
            Console.ResetColor();
        }
        public void MoveRight(int speed)
        {
            horizontalSpeed = speed;
            PositionX += horizontalSpeed;
            
        }
        public void Jump(int initialJumpVelocity)
        {
            if (CanJump)
            {

                jumpVelocity += initialJumpVelocity;
                IsFalling = true;
                CanJump = false;
            }
        }
        public void ApplyGravity(int gravity, Level currentLevel)
        {
            if (IsFalling)
            {
                if (jumpVelocity > 0)
                {
                    FallDuringJump();
                }
                else
                {
                    FallFromPlatform(gravity, currentLevel);
                }
            }
            else
            {
                if (!IsOnGround(currentLevel))
                {
                    IsFalling = true;
                    horizontalSpeed = 0;
                }
            }
        }
        public void FallDuringJump()
        {
            PositionY -= jumpVelocity;
            jumpVelocity--;

            if(jumpVelocity <= 0)
            {
                IsFalling = true;
            }
        }
        private void FallFromPlatform(int gravity, Level currentLevel)
        {
            PositionY += gravity;

            if (!IsOnGround(currentLevel) && CanJump)
            {
                IsFalling = true;
                PositionX -= horizontalSpeed;
            }
            else
            {
                IsFalling = false;
                CanJump = true;
            }
        }
        public bool IsOnGround(Level currentLevel)
        {
            int checkX = Math.Max(PositionX - 1, 0);
            bool onGround = currentLevel.IsOnPlatform(checkX, PositionY);
            if (onGround)
            {
                CanJump = true;
                IsFalling = false;
            }
            return onGround;
        }
        public bool IsBelowGround(Level currentLevel)
        {
            return PositionY >= 24;
        }
        public void Fall(int fallSpeed)
        {
            PositionY += fallSpeed;
        }
        public void StopFalling()
        {
            IsFalling = false;
        }
        public void ResetPosition(int x, int y)
        {
            PositionX = x;
            PositionY = y;
            IsFalling = false;
            CanJump = true;
            horizontalSpeed = 0;
        }
      
    }
}

