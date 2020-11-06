using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Projekt_SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Projekt_SFML
{
    static class Editor
    {
        public static readonly Camera cam = new Camera(new Vector2f(0f, 0f), 30, new Color(50, 50, 150));
        
        public static void Init()
        {
            Program.window.MouseWheelScrolled += Window_MouseWheelScrolled;
        }

        private static void Window_MouseWheelScrolled(object sender, MouseWheelScrollEventArgs e)
        {
            cam.ChangeSize((float)(cam.view.Size.X + -e.Delta));
        }

        public static void Update()
        { 
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                cam.view.Move(new Vector2f(-0.01f, 0f));
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                cam.view.Move(new Vector2f(0.01f, 0f));
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                cam.view.Move(new Vector2f(0f, -0.01f));
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                cam.view.Move(new Vector2f(0f, 0.01f));
            }

            //if(Mouse.)
        }

        public static void GenerateMesh()
        {
            for (int x = 0; x <= 10; x+=8)
            {
                Vertex[] line = new Vertex[2]// definiujemy linię za pomocą 2 wierzchołków
                {
                    new Vertex( new Vector2f(x, int.MaxValue)),
                    new Vertex( new Vector2f(x, int.MinValue))
                };
                Program.window.Draw(line, (PrimitiveType)2, RenderStates.Default); // i ją rysujemy
            }
            
            for (int y = 0; y <= 10; y+=10)
            {
                Vertex[] line = new Vertex[2]// definiujemy linię za pomocą 2 wierzchołków
                {
                    new Vertex( new Vector2f(int.MaxValue, y)),
                    new Vertex( new Vector2f(int.MinValue, y))
                };
                Program.window.Draw(line, (PrimitiveType)2, RenderStates.Default); // i ją rysujemy
            }

            
        }
    }
}
