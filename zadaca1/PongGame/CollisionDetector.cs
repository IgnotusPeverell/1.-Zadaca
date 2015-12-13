using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class CollisionDetector
    {
        private const int PaddleHeight = 20;
        private const int PaddleWidth = 200;
        private const int GameHeigt = 900;
        public const int BallSize = 50;
        public const int BouncArea = 10;
        
        
        public static bool Overlaps(Sprite s1, Sprite s2)
        {
            if (s1.Position.Y < PaddleHeight - BouncArea || s1.Position.Y + BallSize > GameHeigt - PaddleHeight + BouncArea)
                return false;

            if (s1.Position.X+BallSize >= s2.Position.X && s1.Position.X <= s2.Position.X + PaddleWidth && (s1.Position.Y <= PaddleHeight || s1.Position.Y+BallSize >= GameHeigt - PaddleHeight))
            { 
                return true;
            }
                
            return false;
        }
    }
}
