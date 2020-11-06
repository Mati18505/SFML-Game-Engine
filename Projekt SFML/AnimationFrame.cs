using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_SFML
{
    struct AnimationFrame
    {
        public Texture originalTexture;
        public double time;
        public Texture reverseTexture;

        public AnimationFrame(Texture texture, double time)
        {
            this.originalTexture = texture;
            this.time = time;
            this.reverseTexture = null;
        }

        public void AddReverseTexture()
        {
            Image image = originalTexture.CopyToImage();
            image.FlipHorizontally();
            this.reverseTexture = new Texture(image);
        }
    }
}
