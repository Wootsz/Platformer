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

class Playing : State
{
    public List<Entity> entities;
    public List<Block> blocks;
    public Player player;
    CollisionHandler collisionHandler;
    
    public Playing()
    {
        entities = new List<Entity>();
        blocks = new List<Block>();

        player = new Player("player", new Vector2(100, 200));
        Enemy e1 = new Enemy("enemy", new Vector2(100, 100), player);
        Enemy e2 = new Enemy("enemy", new Vector2(0, 0), player);

        entities.Add(player);
        entities.Add(e1);
        entities.Add(e2);

        Block b1 = new Block("block", new Vector2(200, 300), BlockType.SolidBlock);
        Block b2 = new Block("block", new Vector2(300, 300), BlockType.Platform);
        Block ground = new Block("block", new Vector2(0, 350), BlockType.SolidBlock);
        ground.size.X = 600;
        b2.size.X = 100;

        blocks.Add(b1);
        blocks.Add(b2);
        blocks.Add(ground);

        collisionHandler = new CollisionHandler();
    }

    public override void Input(InputHelper input, GameTime time)
    {
        player.Input(input, time);
    }

    public override void Update(GameTime time)
    {
        foreach (Entity e in entities)
            e.Update(time);
        collisionHandler.Update(time, entities, blocks, player);

    }

    public override void Draw(SpriteBatch spriteBatch, GameTime time)
    {
        foreach (Block b in blocks)
            b.Draw(spriteBatch, time);
        foreach (Entity e in entities)
            e.Draw(spriteBatch, time);
    }
}

