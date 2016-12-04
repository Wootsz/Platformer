using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Timer
{
    public bool on;
    private float counter = 0;
    private float end;

    public void Start(float time)
    {
        end = time;
        on = true;
    }

    public void Update(GameTime time)
    {
        if (on)
        {
            counter += time.ElapsedGameTime.Milliseconds;
            if (counter >= end)
            {
                on = false;
                counter = 0;
            }
        }
    }
}

