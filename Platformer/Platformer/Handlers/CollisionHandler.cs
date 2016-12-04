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

class CollisionHandler
{
    public void Update(GameTime time, List<Entity> e, List<Block> b, Player p)
    {
        EntitiesBlockCollision(e, b, p);
        PlayerEnemyCollision(e, p);
    }

    public bool BoxCollision(Rectangle r1, Rectangle r2)
    {
       // return ((r1.Top > r2.Top && r1.Top < r2.Bottom) || (r1.Bottom > r2.Top && r1.Bottom < r2.Bottom))
         //   && ((r1.Left < r2.Right && r1.Left > r2.Left) || (r1.Right < r2.Right && r1.Right > r2.Left));
        return (Between(r1.Top, r2.Top, r2.Bottom) || Between(r1.Bottom, r2.Top, r2.Bottom)) &&
            (Between(r1.Left, r2.Left, r2.Right) || Between(r1.Right, r2.Left, r2.Right));
    }

    public bool Between(int s, int b1, int b2)
    {
        return (s < b2 && s > b1);
    }

    public void EntitiesBlockCollision(List<Entity> entities, List<Block> blocks, Player player)
    {
        foreach (Entity e in entities)
            EntityBlockCollision(e, blocks);
        EntityBlockCollision(player, blocks);
    }

    public void EntityBlockCollision(Entity e, List<Block> blocks)
    {
        e.onGround = false;
        foreach (Block b in blocks)
            if (BoxCollision(e.Boundingbox(), b.Boundingbox()))
            {
                e.onGround = true;
                break;
            }

    }

    public void PlayerEnemyCollision(List<Entity> entities, Player player)
    {
        if (player.invincible)
            return;
        foreach (Entity e in entities)
            if (BoxCollision(e.Boundingbox(), player.Boundingbox()))
                player.Hit(e.position.X > player.position.X);
    }
}