using Engine;
using OpenTK.Mathematics;

namespace Engine
{
    public class Transform : Component
    {
        public Vector3 LocalPosition { get; set; }
        public Vector3 LocalRotation { get; set; }
        public Vector3 LocalScale { get; set; }

        public Transform()
        {
            LocalScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        public Matrix4 GetModel()
        {
            Matrix4 model = Matrix4.Identity;

            model = Matrix4.Mult(model, Matrix4.CreateTranslation(LocalPosition));
            model = Matrix4.Mult(model, Matrix4.CreateRotationX(LocalRotation.X));
            model = Matrix4.Mult(model, Matrix4.CreateRotationY(LocalRotation.Y));
            model = Matrix4.Mult(model, Matrix4.CreateRotationZ(LocalRotation.Z));
            model = Matrix4.Mult(model, Matrix4.CreateScale(LocalScale));

            return model;
        }

        public void Translate(Vector3 translation) => LocalPosition += translation;

        public void Rotate(Vector3 rotation) => LocalRotation += rotation;

        public void Scale(Vector3 scale) => LocalScale += scale;
    }
}
