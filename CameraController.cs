using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Engine
{
    public class CameraController : Component
    {
        private static Camera Camera => Core.Instance.MainCamera;

        public override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            const float cameraSpeed = 1.5f;
            const float sensitivity = 0.2f;

            if (Input.IsKeyDown(Keys.W, Keys.Up))
            {
                Camera.Position += Camera.Front * cameraSpeed * (float)args.Time;
            }
            if (Input.IsKeyDown(Keys.S, Keys.Down))
            {
                Camera.Position -= Camera.Front * cameraSpeed * (float)args.Time;
            }
            if (Input.IsKeyDown(Keys.A, Keys.Left))
            {
                Camera.Position -= Camera.Right * cameraSpeed * (float)args.Time;
            }
            if (Input.IsKeyDown(Keys.D, Keys.Right))
            {
                Camera.Position += Camera.Right * cameraSpeed * (float)args.Time;
            }
            if (Input.IsKeyDown(Keys.Space))
            {
                Camera.Position += Camera.Up * cameraSpeed * (float)args.Time;
            }
            if (Input.IsKeyDown(Keys.LeftShift))
            {
                Camera.Position -= Camera.Up * cameraSpeed * (float)args.Time;
            }

            Camera.Yaw += Input.GetMousePositionOffset().X * sensitivity;
            Camera.Pitch -= Input.GetMousePositionOffset().Y * sensitivity;
            Camera.Fov -= Input.GetMouseWheelOffset().Y;
        }
    }
}
