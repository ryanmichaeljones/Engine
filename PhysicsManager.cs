using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class PhysicsManager 
    {
        private readonly List<Collider> colliders;

        public readonly Vector3 gravity = new(0.0f, 9.81f, 0.0f);

        public PhysicsManager()
        {
            colliders = new List<Collider>();
        }

        public void AddCollider(Collider collider) => colliders.Add(collider);

        public void UpdateFrame(FrameEventArgs args)
        {
            foreach (Collider collider1 in colliders)
            {
                foreach (Collider collider2 in colliders
                    .Where(c => !c.Equals(collider1)))
                {
                    if (collider1.CheckCollision(collider2.Entity.Transform))
                    {
                        Console.WriteLine($"Collision Detected! {args.Time}");

                        collider1.OnCollision();
                    }
                }
            }
        }
    }
}
