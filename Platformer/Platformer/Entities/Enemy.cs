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

class Enemy : Entity
{
    Player player;
    //public AIState state;
    public List<Entity> view;
    int counter = 0;
    bool count;

    public Enemy(string name, Vector2 position, Player player) : base(name, position)
    {
        view = new List<Entity>();
        this.player = player;
        //state = new Follow(player);
    }

    public override void Update(GameTime time)
    {
        if (counter == 100)
            count = false;
        if (counter == 0)
            count = true;
        if (count)
        {
            position.X += 1;
            counter++;
        }
        else
        {
            position.X -= 1;
            counter--;
        }
        //if (view.Contains(player))
        
          //  if (Math.Abs(position.X - player.position.X) > 100)
           //     state = new Follow(player);

        // else { state = patrol / search; }

        //position = state.UpdatePosition(time, position, velocity);
    }
}

