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


class Follow : AIState
{
    Player player;

    public Follow(Player player)
    {
        this.player = player;
    }

    public override Vector2 UpdatePosition(GameTime time, Vector2 position, float velocity)
    {
        if (player.position.X < position.X)
            position.X -= velocity * time.ElapsedGameTime.Milliseconds;
        if (player.position.X > position.X)
            position.X -= velocity * time.ElapsedGameTime.Milliseconds;
        return position;
    }
}

