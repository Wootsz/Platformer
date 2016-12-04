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

public class Game : Microsoft.Xna.Framework.Game
{
    protected GraphicsDeviceManager graphics;
    protected SpriteBatch spriteBatch;
    public Point screen;
    protected Matrix spriteScale;

    public State currentState;

    protected InputHelper inputHelper;
    public static AssetHandler assetHandler;
    public static Environment environment;


    public Game()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        assetHandler = new AssetHandler(Content);
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        DrawingHelper.Initialize(GraphicsDevice);
        inputHelper = new InputHelper();
        currentState = new Playing();
        environment = new Environment();
        screen = new Point(600, 400);
        SetFullScreen(false);
    }

    protected override void Update(GameTime gameTime)
    {
        if (inputHelper.IsKeyDown(Keys.Escape) && inputHelper.IsKeyDown(Keys.Tab))
            Exit();
        if (inputHelper.KeyPressed(Keys.F5))
            SetFullScreen(!graphics.IsFullScreen);

        inputHelper.Update();
        currentState.Update(gameTime);
        currentState.Input(inputHelper, gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);
        currentState.Draw(spriteBatch, gameTime);
        spriteBatch.End();
    }

    public void SetFullScreen(bool fullscreen = true)
    {
        float scalex = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (float)screen.X;
        float scaley = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / (float)screen.Y;
        float finalscale = 1f;

        if (!fullscreen)
        {
            if (scalex < 1f || scaley < 1f)
                finalscale = Math.Min(scalex, scaley);
        }
        else
        {
            finalscale = scalex;
            if (Math.Abs(1 - scaley) < Math.Abs(1 - scalex))
                finalscale = scaley;
        }

        graphics.PreferredBackBufferWidth = (int)(finalscale * screen.X);
        graphics.PreferredBackBufferHeight = (int)(finalscale * screen.Y);
        graphics.IsFullScreen = fullscreen;
        graphics.ApplyChanges();
        inputHelper.Scale = new Vector2((float)GraphicsDevice.Viewport.Width / screen.X,
                                        (float)GraphicsDevice.Viewport.Height / screen.Y);
        spriteScale = Matrix.CreateScale(inputHelper.Scale.X, inputHelper.Scale.Y, 1);
    }
}
