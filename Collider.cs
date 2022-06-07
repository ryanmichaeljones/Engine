using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Collider : Component
    {
        public Collider()
        {
            Core.Instance.PhysicsManager.AddCollider(this);
        }

        public bool CheckCollision(Transform target)
        {
            bool collisionInXAxis = Transform.LocalPosition.X + Transform.LocalScale.X >= target.LocalPosition.X &&
                target.LocalPosition.X + target.LocalScale.X >= Transform.LocalPosition.X;

            bool collisionInYAxis = Transform.LocalPosition.Y + Transform.LocalScale.Y >= target.LocalPosition.Y &&
                target.LocalPosition.Y + target.LocalScale.Y >= Transform.LocalPosition.Y;

            return collisionInXAxis && collisionInYAxis;
        }

        public void OnCollision()
        {

        }
    }
}
