using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hackerman
{//Dennis Made this 
    class Sprite
    {
        private Rectangle position;
        private Texture2D objTexture;
        private float rotation;
        private float scale;
        private Vector2 origin;
        private Color color;
        public int X { get { return position.X; } set { position.X = value; } }
        public int Y { get {return position.Y; } set { position.Y = value; } }
        public Texture2D Texture { get { return objTexture; } set { objTexture = value; } }
        public Rectangle Position { get { return position; } set { position = value; } }

        public float Rotation { get { return rotation; } set { rotation = value; } }
        public float Scale { get { return scale; } set { scale = value; } }

        public Vector2 Origin { get { return origin; } set { origin = value; } }
        public Color Color { get { return color; } set { color = value; } }

        public Sprite(int xR, int yR, int height, int width, int xV, int yV, float pRotation, float pScale, Color pColor)
        {
            this.position.X = xR;
            this.position.Y = yR;
            this.position.Width = width;
            this.position.Height = height;
            this.origin.X = xV;
            this.origin.Y = yV;
            this.rotation = pRotation;
            this.scale = pScale;
            this.color = pColor;
        }

        public Sprite()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(this.Texture,
                             this.Position,
                             null,
                             this.Color,
                             this.Rotation,
                             this.Origin,
                             SpriteEffects.None,
                             0f);
                             
        }
    }
}