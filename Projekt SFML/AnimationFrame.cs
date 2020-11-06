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
        public Texture rotatedTexture;

        public AnimationFrame(Texture texture, double time)
        {
            this.originalTexture = texture;
            this.time = time;
            this.rotatedTexture = null;
        }

        public void AddRotatedTexture()
        {
            Image image = originalTexture.CopyToImage();
            image.FlipHorizontally();
            this.rotatedTexture = new Texture(image);
        }
    }
}
