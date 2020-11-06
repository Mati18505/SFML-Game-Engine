using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Projekt_SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Projekt_SFML
{
    class Object : IUpdateable
    {
        public virtual string ObjectName { get { return "Name"; } }

        public virtual SpriteRenderer spriteRenderer { get; set; }

        public virtual Animator animator { get; set; }


        public Transform transform = new Transform();
        


        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            if (this.spriteRenderer != null) spriteRenderer.Update();
            if (this.animator != null) animator.Update();
        }


        public void AddComponent(Type component)
        {
            if (component == typeof(SpriteRenderer))
                this.spriteRenderer = new SpriteRenderer(this);
            if (component == typeof(Animator))
                this.animator = new Animator(this);
        }

    }
}