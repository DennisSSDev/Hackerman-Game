using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hackerman
{
    class Sprite
    {
        public Texture2D Texture { get; private set; }

        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; }

        public Vector2 Origin { get; set; }
        public Color Color { get; set; }

        public Sprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(this.Texture,
                             this.Position,
                             null,
                             this.Color,
                             this.Rotation,
                             this.Origin,
                             this.Scale,
                             SpriteEffects.None,
                             0f);
        }
    }
}
