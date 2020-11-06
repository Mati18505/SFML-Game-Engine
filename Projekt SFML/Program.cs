using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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
    
    class Program
    {
        public static readonly RenderWindow window = new RenderWindow(new VideoMode(800, 600, 32), "Projekt SFML");
        static Scene currentScene;
        static public double DeltaTime { get; private set; } = 1000;
        
        
        
        
        
        static void Main(string[] args)
        {
            Scene game = new Scene();
            game.currentCamera = new Camera(new Vector2f(0, 0), 30, Color.White);
            game.currentCamera.view.Viewport = new FloatRect(0.05f, 0.05f, 0.90f, 0.90f);

            Editor.Init();

            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;

            SetScene(game);

            window.SetView(currentScene.currentCamera.view);

            Button button = new Button(new Vector2f(250, 250), new Vector2f(200, 100), Color.Cyan);
            button.ListOfSubsribes += Button_Click;


            ObjektTestowy objekt1 = new ObjektTestowy();
            game.AddObject(objekt1, "Lis");

            objekt1.AddComponent(typeof(SpriteRenderer));

            objekt1.spriteRenderer.ChangeTexture("Assets/Img/Player/Idle/idle-1.png", true);
            objekt1.transform.origin = (Vector2f)objekt1.spriteRenderer.sprite.Texture.Size / 2;

            Font font = new Font("Assets/Fonts/unispace_bd.ttf");
            
            Text fps = new Text("FPS: ", font, 20);
            fps.FillColor = Color.Black;
            fps.Position = new Vector2f(0, 0);


            Console.WriteLine(Math.Atan2(0.5, 0.5)*180.0/Math.PI); //Kąt z wektora
            Console.WriteLine("X: "+ Math.Round(Math.Cos(45 / 180.0 * Math.PI), 5));
            Console.WriteLine("Y: "+ Math.Round(Math.Sin(45 / 180.0 * Math.PI), 5));
            
            game.Start();

            Stopwatch clockDeltaTime = new Stopwatch();
            Stopwatch clock1 = new Stopwatch();

            WriteInfo(clock1, true, game, fps, objekt1);

            clockDeltaTime.Start();
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                Input.Update();

                currentScene.Update();


                window.Clear(currentScene.currentCamera.bgColor);


                window.SetView(window.DefaultView); //Na tym rysować GUI
                window.Draw(fps);
                
                window.SetView(currentScene.currentCamera.view);
                currentScene.Draw();

                window.Display();

                WriteInfo(clock1, false, game, fps, objekt1);

                DeltaTime = clockDeltaTime.Elapsed.TotalMilliseconds;
                clockDeltaTime.Restart();
            }

        }

        private static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }

        private static void Button_Click()
        {
            Console.WriteLine("Kliknięto przycisk!!!");
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }

        private static void SetScene(Scene scene)
        {
            if(currentScene != null)
                currentScene.isActive = false;
            currentScene = scene;
            currentScene.isActive = true;
        }

        private static void WriteInfo(Stopwatch clock1, bool isFirst, Scene game, Text fps, ObjektTestowy objekt1)
        {
            if (clock1.Elapsed.TotalMilliseconds >= 1000 || isFirst)
            {
                /*for (int i = 0; i < 25; i++)
                    Console.WriteLine("\n");*/
                /*
                Console.WriteLine("LISTA OBJEKTÓW");
                game.WriteObjects();*/
                //Console.WriteLine(objekt1.animator.GetAllAnimationsNames());

                fps.DisplayedString = "FPS: "+((int)(1000 / DeltaTime)).ToString();
                clock1.Restart();
            }
        }


    }
}
