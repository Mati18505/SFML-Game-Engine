using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_SFML
{
    class Animator
    {
        private List<Animation> animations = new List<Animation>();
        private Dictionary<string, int> animationsNames = new Dictionary<string, int>();
        private int currentAnimation;
        private Object parentObject;

        public bool isRotated;

        public Animator(Object parentObject)
        {
            this.parentObject = parentObject;
        }

        public void Update()
        {
            animations[currentAnimation].Update();
        }

        public void ChangeAnimation(string animationName)
        {
            if (animationsNames.ContainsKey(animationName))
            {
                currentAnimation = animationsNames[animationName];
                animations[currentAnimation].StartAnimation();
            }
            else
                throw new Exception("Animation with this key does not exist!");
        }

        public void AddAnimation(string animationName)
        {
            animations.Add(new Animation(parentObject));
            animationsNames.Add(animationName, animations.Count - 1);
        }
        
        public string GetCurrentAnimationName()
        {
            if (animationsNames.ContainsValue(currentAnimation))
            {
                foreach (string key in animationsNames.Keys)
                {
                    if (animationsNames[key] == currentAnimation)
                        return key;
                }
            }
            return null;
        }

        public Animation GetAnimationByName(string name)
        {
            if (animationsNames.ContainsKey(name))
                return animations[animationsNames[name]];
            else
                return null;
        }
    
        public string GetAllAnimationsNames()
        {
            string allAnimationsNames = "";
            foreach (var item in animationsNames)
            {
                allAnimationsNames += item.Key;
                allAnimationsNames += '\n';
            }
            allAnimationsNames = allAnimationsNames.Remove(allAnimationsNames.Length - 1, 1);
            return allAnimationsNames;
        }
    }
}
