using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class BoxCollider2D : Component
    {
        public static bool HasCollisionOccurred(Transform transform1, Transform transform2)
        {
            bool collisionInXAxis = transform1.LocalPosition.X + transform1.LocalScale.X >= transform2.LocalPosition.X &&
                transform2.LocalPosition.X + transform2.LocalScale.X >= transform1.LocalPosition.X;

            bool collisionInYAxis = transform1.LocalPosition.Y + transform1.LocalScale.Y >= transform2.LocalPosition.Y &&
                transform2.LocalPosition.Y + transform2.LocalScale.Y >= transform1.LocalPosition.Y;

            return collisionInXAxis && collisionInYAxis;
        }
    }
}
