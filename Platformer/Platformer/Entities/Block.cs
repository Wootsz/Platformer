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

public enum BlockType
{
    SolidBlock,
    Platform
}

class Block : Entity
{
    public BlockType type;

    public Block(string name, Vector2 position, BlockType type) : base(name, position)
    {
    }

}