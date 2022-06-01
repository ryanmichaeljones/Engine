using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using Graphics;

namespace Engine
{
    public class Renderer : Component
    {
        private readonly Shader shader;
        private readonly Mesh mesh;
        private readonly Texture texture;

        public Renderer()
        {
            shader = new Shader();
            mesh = new Mesh();
            texture = new Texture();
        }

        public void SetShader(string vertexPath, string fragmentPath) => shader.Parse(vertexPath, fragmentPath);

        public void SetMesh(string modelPath) => mesh.Parse(modelPath);

        public void SetTexture(string texturePath) => texture.Parse(texturePath);

        public override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            
            mesh.SetTexture("texture0", texture);

            shader.SetMatrix4("projection", Core.Instance.MainCamera?.GetProjectionMatrix() ?? Matrix4.Identity);
            shader.SetMatrix4("view", Core.Instance.MainCamera?.GetViewMatrix() ?? Matrix4.Identity);
            shader.SetMatrix4("model", Transform.GetModel());
            shader.SetMesh(mesh);

            shader.Render();
        }
    }
}
