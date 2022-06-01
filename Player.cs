using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Engine
{
    public class Player : Component
    {
        // Next do a BoxCollider2D - initial way - loop through every entity with a box collider and check for collision
        // Will need a PhysicsManager
        public float movementSpeed = 1.5f;

        public override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
        }

        public override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (Input.IsKeyDown(Keys.W, Keys.Up))
            {
                Transform.Translate(new Vector3(0.0f, movementSpeed * (float)args.Time, 0.0f));
            }
            if (Input.IsKeyDown(Keys.S, Keys.Down))
            {
                Transform.Translate(new Vector3(0.0f, -movementSpeed * (float)args.Time, 0.0f));
            }
            if (Input.IsKeyDown(Keys.A, Keys.Left))
            {
                Transform.Translate(new Vector3(-movementSpeed * (float)args.Time, 0.0f, 0.0f));
            }
            if (Input.IsKeyDown(Keys.D, Keys.Right))
            {
                Transform.Translate(new Vector3(movementSpeed * (float)args.Time, 0.0f, 0.0f));
            }
        }
    }
}
