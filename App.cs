using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace App
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch sprite;

        string page;
        string tab;
        float time = 5.4f;
        Rectangle theVoid;
        MouseState mState = Mouse.GetState();

        Texture2D splashScreen;
        Rectangle splashScreenPos;

        Texture2D bgImage;
        Rectangle bgImagePos;
        Texture2D sidebar;
        Rectangle sidebarPos;
        Texture2D homeBtn;
        Rectangle homeBtnPos;
        Texture2D settings;
        Rectangle settingsPos;
        Texture2D codeBtn;
        Rectangle codePos;
        Texture2D sidebar2;
        Rectangle sidebar2Pos;

        Texture2D langTab;
        Rectangle langTabPos;

        // Cards

        Texture2D pythonCard;
        Rectangle pythonCardPos;
        Texture2D csCard;
        Rectangle csCardPos;
        Texture2D cppCard;
        Rectangle cppCardPos;
        Texture2D javaCard;
        Rectangle javaCardPos;
        Texture2D javaScriptCard;
        Rectangle javaScriptCardPos;
        Texture2D typeScriptCard;
        Rectangle typeScriptCardPos;
        Texture2D phpCard;
        Rectangle phpCardPos;
        Texture2D swiftCard;
        Rectangle swiftCardPos;

        Texture2D cardDeck;
        Rectangle cardDeckPos;
        Rectangle dock;
        bool resize;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            page = "Splash Screen";
            splashScreenPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 + 310, graphics.PreferredBackBufferHeight / 2 - 25, 500, 500);
            theVoid = new Rectangle(10000, 10000, 0, 0); resize = false;

            // Props

            bgImagePos = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 650, graphics.PreferredBackBufferHeight / 2 - 255, 2500, 2500);
            sidebarPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 400, graphics.PreferredBackBufferHeight / 2 - 255, 75, 2500);
            homeBtnPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 393, graphics.PreferredBackBufferHeight / 2 - 45, 55, 70);
            settingsPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 393, graphics.PreferredBackBufferHeight / 2 + 200, 55, 55);
            codePos = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 393, graphics.PreferredBackBufferHeight / 2 + 450, 55, 55);
            sidebar2Pos = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 105, graphics.PreferredBackBufferHeight / 2 - 255, 1425, 73);

            langTabPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 25, graphics.PreferredBackBufferHeight / 2 - 235, 190, 45);

            // Cards

            pythonCardPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 75, graphics.PreferredBackBufferHeight / 2 - 90, 250, 350);
            csCardPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 + 280, graphics.PreferredBackBufferHeight / 2 - 90, 250, 350);
            cppCardPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 + 640, graphics.PreferredBackBufferHeight / 2 - 90, 250, 350);
            javaCardPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 + 1000, graphics.PreferredBackBufferHeight / 2 - 90, 250, 350);
            javaScriptCardPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 75, graphics.PreferredBackBufferHeight / 2 + 315, 250, 350);
            typeScriptCardPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 + 280, graphics.PreferredBackBufferHeight / 2 + 315, 250, 350);
            phpCardPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 + 640, graphics.PreferredBackBufferHeight / 2 + 315, 250, 350);
            swiftCardPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 + 1000, graphics.PreferredBackBufferHeight / 2 + 315, 250, 350);

            cardDeckPos = new Rectangle(graphics.PreferredBackBufferWidth / 2 + 1000, graphics.PreferredBackBufferHeight / 2 + 100, 300, 600);
            dock = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 75, graphics.PreferredBackBufferHeight / 2 - 90, 500, 700);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sprite = new SpriteBatch(GraphicsDevice);

            splashScreen = Content.Load<Texture2D>("Maven Builds");
            bgImage = Content.Load<Texture2D>("Props/BG Image");
            sidebar = Content.Load<Texture2D>("Props/Sidebar");
            homeBtn = Content.Load<Texture2D>("Props/Home Btn");
            settings = Content.Load<Texture2D>("Props/Settings Btn");
            codeBtn = Content.Load<Texture2D>("Props/Code");
            sidebar2 = Content.Load<Texture2D>("Props/Sidebar2");

            langTab = Content.Load<Texture2D>("Props/LangTab");

            // Cards

            pythonCard = Content.Load<Texture2D>("Cards/Python Thumbnail");
            csCard = Content.Load<Texture2D>("Cards/C# Thumbnail");
            cppCard = Content.Load<Texture2D>("Cards/C++ Thumbnail");
            javaCard = Content.Load<Texture2D>("Cards/Java Thumbnail");
            javaScriptCard = Content.Load<Texture2D>("Cards/JavaScript Thumbnail");
            typeScriptCard = Content.Load<Texture2D>("Cards/TypeScript Thumbnail");
            phpCard = Content.Load<Texture2D>("Cards/PHP Thumbnail");
            swiftCard = Content.Load<Texture2D>("Cards/Swift Thumbnail");
            cardDeck = Content.Load<Texture2D>("Cards/Card Deck");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            time -= elapsedTime;

            if (time <= 0.0f && page == "Splash Screen")
            {
                page = "Home";
            }

            if (pythonCardPos.Contains(mState.Position) && mState.LeftButton == ButtonState.Pressed)
            {
                pythonCardPos.Width = 500; pythonCardPos.Height = 700;
            }

            if (settingsPos.Contains(mState.Position) && mState.LeftButton == ButtonState.Pressed)
            {
                page = "Settings";
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            sprite.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            if (page == "Splash Screen")
            {
                sprite.Draw(splashScreen, splashScreenPos, Color.White);
            }

            else
            {
                sprite.Draw(splashScreen, theVoid, Color.White);
            }

            if (page == "Home")
            {
                sprite.Draw(bgImage, bgImagePos, Color.White);
                sprite.Draw(sidebar, sidebarPos, Color.White);
                sprite.Draw(homeBtn, homeBtnPos, Color.White);
                sprite.Draw(settings, settingsPos, Color.White);
                sprite.Draw(codeBtn, codePos, Color.White);
                sprite.Draw(sidebar2, sidebar2Pos, Color.White);
                sprite.Draw(langTab, langTabPos, Color.White);

                sprite.Draw(pythonCard, pythonCardPos, Color.White);
                sprite.Draw(csCard, csCardPos, Color.White);
                sprite.Draw(cppCard, cppCardPos, Color.White);
                sprite.Draw(javaCard, javaCardPos, Color.White);
                sprite.Draw(javaScriptCard, javaScriptCardPos, Color.White);
                sprite.Draw(typeScriptCard, typeScriptCardPos, Color.White);
                sprite.Draw(phpCard, phpCardPos, Color.White);
                sprite.Draw(swiftCard, swiftCardPos, Color.White);
            }

            sprite.End();  

            base.Draw(gameTime);
        }
    }
}
