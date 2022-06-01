using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;

namespace Engine
{
    public class Entity
    {
        public string Name { get; set; }
        public Transform Transform => GetComponent<Transform>();

        private readonly List<Component> components;

        public Entity(string name)
        {
            Name = name;
            components = new List<Component>();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            if (components.Exists(c => c.GetType().Equals(typeof(T))))
                throw new ArgumentException($"Entity already has a '{typeof(T).Name}' component attached");

            T component = new();
            components.Add(component);

            component.OnInitialize(this);

            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is T component) return component;
            }

            return default;
        }

        public void UpdateFrame(FrameEventArgs args)
        {
            foreach (Component component in components)
            {
                component.UpdateFrame(args);
            }
        }

        public void RenderFrame(FrameEventArgs args)
        {
            foreach (Component component in components)
            {
                component.RenderFrame(args);
            }
        }
    }
}