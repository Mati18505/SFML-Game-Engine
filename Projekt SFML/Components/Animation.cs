using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_SFML
{
    class Animation
    {
        List<AnimationFrame> frames = new List<AnimationFrame>();
        public int currentFrame { get; private set; }
        Clock clock = new Clock();
        public SpriteRenderer spriteRenderer;
        Animator parentAnimator;
        bool hasRotated;
        bool animationChanged;


        public Animation(Object parentObject)
        {
            this.spriteRenderer = parentObject.spriteRenderer;
            this.parentAnimator = parentObject.animator;
        }


        public void Update()
        {
            if(clock.ElapsedTime.AsMilliseconds() >= frames[currentFrame].time || animationChanged)
            {
                if (animationChanged) animationChanged = false;
                clock.Restart();
                currentFrame++;
                if (currentFrame > frames.Count - 1) 
                    currentFrame = 0;

                if (spriteRenderer != null)
                {
                    spriteRenderer.ChangeTexture(frames[currentFrame].originalTexture, frames[currentFrame].rotatedTexture);

                    if (parentAnimator.isRotated && hasRotated) //Obsługuje obrót animowanego sprite
                        spriteRenderer.Rotate(true);
                    else
                        spriteRenderer.Rotate(false);
                }
                    
            }
        }

        public void AddAnimationFrame(AnimationFrame frame, bool isMakeRotated)
        {
            if (isMakeRotated)
            {
                frame.AddRotatedTexture();
                if (!hasRotated)
                    hasRotated = true;
            }
            
            frames.Add(frame);
        }

        public void AddAnimationFrames(AnimationFrame[] frames, bool isMakeRotated)
        {
            for (int i = 0; i < frames.Length; i++)
            {
                AddAnimationFrame(frames[i], isMakeRotated);
            }
        }

        public void StartAnimation()
        {
            animationChanged = true;
        }

        public int GetFramesCount()
        {
            return frames.Count;
        }
    }
}
