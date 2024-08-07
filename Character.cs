using System;

namespace PLATAFORMAS
{
    public class Character
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PreviousPositionX { get; set; }
        public int PreviousPositionY { get; set; }
        public int Speed { get; set; }
        private int JumpVelocity { get; set; }
        private int HorizontalSpeed { get; set; }
        public bool IsFalling { get; set; }
        public bool CanJump { get; private set; } = true;

        public Character(int x, int y)
        {
            PositionX = x = 10;
            PositionY = y;
            PreviousPositionX = x;
            PreviousPositionY = y;
            IsFalling = false;
            Speed = 0;
            JumpVelocity = 0;
            HorizontalSpeed = 0;
        }
        public void DrawPlayer()
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("ö");
            Console.ResetColor();
            
        }
        public void UndrawPlayer(Level currentLevel)
        {
            Console.SetCursorPosition(PreviousPositionX, PreviousPositionY);

            if (currentLevel.IsOnPlatform(PreviousPositionX + 1, PreviousPositionY))
            {
                Console.Write('_');
            }
            else
            {
                Console.Write(' ');
            }
        }
        public void MoveRight(int speed, Level currentLevel)
        {
            UpdatePosition(() =>
            {
                PositionX += speed;
            }, currentLevel);
        }
        public void Jump(int initialJumpVelocity, Level currentLevel)
        {
            if (CanJump)
            {
                UpdatePosition(() =>
                {
                    JumpVelocity = initialJumpVelocity;
                    IsFalling = true;
                    CanJump = false;
                }, currentLevel);
            }
        }
        public void ApplyGravity(int gravity, Level currentLevel)
        {
            if (IsFalling)
            {
                UpdatePosition(() =>
                {
                    if (JumpVelocity > 0)
                    {
                        FallDuringJump();
                    }
                    else
                    {
                        FallFromPlatform(gravity, currentLevel);
                    }
                }, currentLevel);
            }
            else if (!IsOnGround(currentLevel))
            {
                StartFalling();
            }
        }
        private void FallDuringJump()
        {
            PositionY -= JumpVelocity;
            JumpVelocity--;

            if (JumpVelocity <= 0)
            {
                IsFalling = false;
            }           
        }
        private void FallFromPlatform(int gravity, Level currentLevel)
        {
            PositionY += gravity;

            if (IsOnGround(currentLevel))
            {
               StopFalling();
            }
            else
            {
                IsFalling = true;
                PositionX -= HorizontalSpeed;

                if (!IsNearPlatform(currentLevel))
                {
                    IsFalling = true;
                    PositionX -= HorizontalSpeed;
                }
                else
                {
                    StopFalling();
                }
            }
        }
        public bool IsOnGround(Level currentLevel)
        {
            int checkX = PositionX;
            bool onGround = currentLevel.IsOnPlatform(checkX, PositionY) ||
                            currentLevel.IsOnPlatform(checkX + 1, PositionY);
            if (onGround)
            {
                UpdatePosition(() =>
                {
                    IsFalling = false;
                    CanJump = true;
                }, currentLevel);
            }
            return onGround;
        }
        public bool IsBelowGround()
        {
            return PositionY >= 24;
        }
        private void StartFalling()
        {            
           IsFalling = true;
           HorizontalSpeed = 0;
        }
        public void StopFalling()
        {
            IsFalling = false;
            CanJump = true;
        }
        private bool IsNearPlatform(Level currentLevel)
        {
            // Ajusta la verificación para comprobar si hay una plataforma cerca y dibujar '_' o ' ' antes de llegar y después.
            int offsetX = 10 + 1; // corrección del margen para la verificacion
            int relativeX = PositionX - offsetX;
            int relativeY = PositionY - 17;

            // Comprueba en una región alrededor del personaje
            for (int dx = -1; dx <= 1; dx++)
            {
                if (currentLevel.IsOnPlatform(PositionX + dx, PositionY + 1))
                {
                    return true;
                }
            }
            return false;
        }
        private void UpdatePosition(Action positionUpdateAction, Level currentLevel)
        {
            UndrawPlayer(currentLevel);
            positionUpdateAction();
            PreviousPositionX = PositionX;
            PreviousPositionY = PositionY;
            DrawPlayer();
        }
        public void ResetPosition(int x, int y, Level currentLevel)
        {
            UpdatePosition(() =>
            {
                PositionX = x;
                PositionY = y;
                IsFalling = false;
                CanJump = true;
                HorizontalSpeed = 0;
            }, currentLevel);
        }
    }
}


