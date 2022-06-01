using OpenTK.Windowing.Common;

namespace Engine
{
    public abstract class Component
    {
        public Transform Transform => Entity.Transform;
        public Entity Entity { get; private set; }

        public virtual void UpdateFrame(FrameEventArgs args) => OnUpdateFrame(args);

        public virtual void RenderFrame(FrameEventArgs args) => OnRenderFrame(args);

        public virtual void OnInitialize(Entity entity) => Entity = entity;

        public virtual void OnUpdateFrame(FrameEventArgs args) { }

        public virtual void OnRenderFrame(FrameEventArgs args) { }
    }
}