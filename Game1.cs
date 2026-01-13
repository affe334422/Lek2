using System;
using System.Linq;
using Lek2.Tester;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lek2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D texture;
    private SpriteFont Font;
    private Camera2D camera2D;
    KeyboardState kstate;
    bool Start = true;
    Test6 tes;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferHeight = 1000;
        _graphics.PreferredBackBufferWidth = 1800;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        
        camera2D = new Camera2D(GraphicsDevice);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Font = Content.Load<SpriteFont>("Font1");
        texture = new Texture2D(GraphicsDevice, 1, 1);
        texture.SetData(new[] { Color.White });
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        kstate = Keyboard.GetState();
        if (Start)
        {
            tes = new Test6(_graphics, _spriteBatch, texture, Font);
            Start = false;
        }

        string a = "12,3,12";
        int[] b = a.Split(',').Select(int.Parse).ToArray();
        foreach(int c in b)
        {
            Console.WriteLine(c);
        }
    
    

        //tes.Update(gameTime);
        //camera2D.Pos=tes.cam;
        


        if (kstate.IsKeyDown(Keys.Escape))
        {
            Exit();
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(transformMatrix: camera2D.get_transformation());
            
            //tes.Draw();
        _spriteBatch.End();
        _spriteBatch.Begin();
            tes.Draw();
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
