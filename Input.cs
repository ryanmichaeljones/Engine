using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Linq;

namespace Engine
{
    public static class Input
    {
        private static KeyboardState KeyboardState => Core.Instance.KeyboardState;
        private static MouseState MouseState => Core.Instance.MouseState;

        public static bool IsKeyDown(params Keys[] keys) => keys.Any(key => KeyboardState.IsKeyDown(key));

        public static Vector2 GetMousePositionOffset() => MouseState.Delta;

        public static Vector2 GetMouseWheelOffset() => MouseState.ScrollDelta;
    }
}
