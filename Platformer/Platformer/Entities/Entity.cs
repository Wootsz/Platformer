using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


class Entity
{
    public Vector2 position;
    public Texture2D sprite;
    public Vector2 size;
    public float velocity;
    public bool onGround;
    public int health;

    protected float falltimer = 0;
    protected float jumpvelocity = 0;
    protected bool jump = false;
    protected float maxjumpvelocity = 0.5f;

    public Entity (string name, Vector2 position)
    {
        this.position = position;
        sprite = Game.assetHandler.GetTexture(name);
        size = new Vector2(sprite.Width / 2, sprite.Height / 2);
    }

    public virtual void Input(InputHelper input, GameTime time) { }
    public virtual void Update(GameTime time) { }

    public virtual Rectangle Boundingbox()
    {
        if (sprite == null)
            return Rectangle.Empty;
        return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
    }

    public virtual void Draw(SpriteBatch spriteBatch, GameTime time)
    {
        spriteBatch.Draw(sprite, Boundingbox(), Color.White);
    }
}