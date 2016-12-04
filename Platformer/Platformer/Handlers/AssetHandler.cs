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


public class AssetHandler
{
    ContentManager contentManager;

    public AssetHandler(ContentManager contentManager)
    {
        this.contentManager = contentManager;
    }

    public Texture2D GetTexture(string name)
    {
        return contentManager.Load<Texture2D>(name);
    }

    public SoundEffect GetSoundEffect(string name)
    {
        return contentManager.Load<SoundEffect>(name);
    }
}

