using MathTrigonometry;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_SFML
{
    class ObjektTestowy : Object
    {
        public override string ObjectName { get { return "Objekt testowy"; } }
        public override SpriteRenderer spriteRenderer { get; set; }



        public float speed = 0.07f;
        public Vector2 currentSpeed;


        public override void Start()
        {
            base.Start();
            
            transform.scale = new Vector2f(1f, 1f);

            
            AddComponent(typeof(Animator));
            
            animator.AddAnimation("Idle");

            int animationFPS = 6;
            int animationFrameTime = 1000 / animationFPS;

            AnimationFrame[] idleAnimationFrames = new AnimationFrame[4] {
                new AnimationFrame(new Texture("Assets/Img/Player/Idle/idle-1.png"), animationFrameTime),  new AnimationFrame(new Texture("Assets/Img/Player/Idle/idle-2.png"), animationFrameTime),
                new AnimationFrame(new Texture("Assets/Img/Player/Idle/idle-3.png"), animationFrameTime),  new AnimationFrame(new Texture("Assets/Img/Player/Idle/idle-4.png"), animationFrameTime) };

            animator.GetAnimationByName("Idle").AddAnimationFrames(idleAnimationFrames, true);
            
            
            animator.AddAnimation("Run");

            AnimationFrame[] runAnimationFrames = new AnimationFrame[6] {
                new AnimationFrame(new Texture("Assets/Img/Player/Run/run-1.png"), animationFrameTime),    new AnimationFrame(new Texture("Assets/Img/Player/Run/run-2.png"), animationFrameTime),
                new AnimationFrame(new Texture("Assets/Img/Player/Run/run-3.png"), animationFrameTime),    new AnimationFrame( new Texture("Assets/Img/Player/Run/run-4.png"), animationFrameTime),
                new AnimationFrame(new Texture("Assets/Img/Player/Run/run-5.png"), animationFrameTime),    new AnimationFrame( new Texture("Assets/Img/Player/Run/run-6.png"), animationFrameTime) };

            animator.GetAnimationByName("Run").AddAnimationFrames(runAnimationFrames, true);
            
            
            RenderTexture renderTexture = new RenderTexture(30, 30);
            /*RenderTarget renderTarget;
            Program.window.Draw(renderTarget);*/
            
        }

        public override void Update()
        {
            base.Update();
            currentSpeed = new Vector2f(0, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                currentSpeed += Vector2.left;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                currentSpeed += Vector2.right;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                currentSpeed += Vector2.down;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                currentSpeed += Vector2.up;
            }

            if (Input.IsKeyUp(Keyboard.Key.G))
            {
                transform.ChangeScale(new Vector2f(-0.1f, -0.1f));
            }

            if (Input.IsKeyDown(Keyboard.Key.F))
            {
                transform.Rotate(45f);
            }

            currentSpeed.Normalize();
            currentSpeed *= speed * (float)Program.DeltaTime;
            transform.Translate(currentSpeed);

            AnimationSupport();

        }
        //Wątki, Testy
        public void AnimationSupport()
        {
            //Obsluga animatora
            if (animator.GetCurrentAnimationName() == "Run")
            {
                if (currentSpeed == new Vector2f(0f, 0f))
                    animator.ChangeAnimation("Idle");
            }
            else if (animator.GetCurrentAnimationName() == "Idle")
            {
                if (currentSpeed != new Vector2f(0f, 0f))
                    animator.ChangeAnimation("Run");
            }

            if (animator.isRotated)
            {
                if (currentSpeed.x > 0f)
                    animator.isRotated = false;
            }
            else
            {
                if (currentSpeed.x < 0f)
                    animator.isRotated = true;
            }
        }
    }
    
    

};
