using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;

namespace Engine
{
    public class Core : GameWindow
    {
        public static Core Instance { get; private set; }

        public Camera MainCamera { get; }
        private Entity Player { get; }

        private readonly List<Entity> entities;

        public PhysicsManager PhysicsManager { get; }

        public Core(string name, int width, int height)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Title = name, Size = new Vector2i(width, height) })
        {
            Instance = this;

            entities = new List<Entity>();

            PhysicsManager = new PhysicsManager();

            MainCamera = AddEntity("Camera").AddComponent<Camera>();

            Player = AddEntity("Player");
            Player.AddComponent<Player>();
            Player.AddComponent<Collider>();
        }

        public Entity AddEntity(string name = "Entity")
        {
            var entity = new Entity(name);
            entities.Add(entity);

            entity.AddComponent<Transform>();

            return entity;
        }

        public Entity FindEntity(string name)
        {
            if (entities.TryGetValue(e => e.Name.Equals(name), out Entity entity))
            {
                return entity;
            }
            else throw new ArgumentException($"Entity '{name}' could not be found");
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            var renderer = Player.AddComponent<Renderer>();
            renderer.SetShader("Assets/Shaders/texture-vertex.vert", "Assets/Shaders/texture-fragment.frag");
            renderer.SetMesh("Assets/Models/square.obj");
            renderer.SetTexture("Assets/Textures/energy.jpg");

            var obstacle = AddEntity("Obstacle");
            obstacle.AddComponent<Collider>();
            var obstacleRenderer = obstacle.AddComponent<Renderer>();
            obstacleRenderer.SetShader("Assets/Shaders/texture-vertex.vert", "Assets/Shaders/texture-fragment.frag");
            obstacleRenderer.SetMesh("Assets/Models/square.obj");
            obstacleRenderer.SetTexture("Assets/Textures/energy.jpg");
            obstacle.Transform.LocalPosition = new Vector3(2, 0, 0);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.ClearColor(0.4f, 0.4f, 0.4f, 0.4f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (var entity in entities)
            {
                entity.RenderFrame(args);
            }
            
            Context.SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            foreach (var entity in entities)
            {
                entity.UpdateFrame(args);
            }

            PhysicsManager.UpdateFrame(args);
        }

        protected override void OnResize(ResizeEventArgs args)
        {
            base.OnResize(args);

            GL.Viewport(0, 0, args.Width, args.Height);
        }

        public override void Run()
        {
            base.Run();
        }
    }
}
