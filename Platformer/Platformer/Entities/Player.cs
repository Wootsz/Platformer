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


class Player : Entity
{
    public bool invincible;
    bool knockbackleft;
    Timer invincibility;
    Timer knockbacktimer;

    float knockbackdistance = 0.4f;

    public Player(string name, Vector2 position) : base(name, position)
    {
        velocity = 0.1f;
        health = 100;
        invincible = false;
        invincibility = new Timer();
        knockbacktimer = new Timer();
    }

    public override void Input(InputHelper input, GameTime time)
    {
        if (input.IsKeyDown(Keys.D))
            position.X += velocity * time.ElapsedGameTime.Milliseconds;
        if (input.IsKeyDown(Keys.A))
            position.X -= velocity * time.ElapsedGameTime.Milliseconds;
        if (input.IsKeyDown(Keys.W) && onGround)
        {
            jump = true;
            jumpvelocity = maxjumpvelocity;
        }
    }

    public override void Update(GameTime time)
    {
        float passedTime = time.ElapsedGameTime.Milliseconds;

        // Invincibility
        invincibility.Update(time);
        invincible = invincibility.on;

        // Knockback
        knockbacktimer.Update(time);
        if (knockbacktimer.on)
        {
            float n = 1;
            if (onGround)
                n = 0.5f;
            if (knockbackleft)
                n *= -1;
            position.X += knockbackdistance * passedTime * n;
        }

        // Jumping
        if (jump)
            Jump(passedTime);

        // Falling
        if (!jump && !onGround)
            Fall(passedTime);
        else
            falltimer = 0;
    }

    public void Jump(float time)
    {
        position.Y -= time * jumpvelocity;
        jumpvelocity -= time * .001f + jumpvelocity * 0.001f;
        if (jumpvelocity <= 0.00f)
        {
            jump = false;
            jumpvelocity = 0;
        }
    }

    public void Fall(float time)
    {
        float acceleration = 0.01f * falltimer;
        float fallspeed = 0.002f;

        position.Y += falltimer * time * Game.environment.gravity;
        if (falltimer < 1)
            falltimer += time * fallspeed + acceleration;
    }

    public void Hit(bool left)
    {
        health -= 10;
        KnockBack(left);
        invincibility.Start(1000);
    }

    public void KnockBack(bool left)
    {
        knockbackleft = left;
        knockbacktimer.Start(400);
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime time)
    {
        if (invincible)
            spriteBatch.Draw(sprite, Boundingbox(), Color.Red);
        else
            base.Draw(spriteBatch, time);
    }
}
