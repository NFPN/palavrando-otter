using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palavrando_otter.Entities
{
    class PlayerAnimation
    {
        //    static void Main(string[] args)
        //    {
        //        // Create a game that's 160 x 120
        //        var game = new Otter.Game("Spritemap Animation", 160, 120);
        //        // Set the window scale to 3x to see the sprite better.
        //        game.SetWindowScale(3);
        //        // Set the background color to a bluish hue.
        //        game.Color = new Color(0.3f, 0.5f, 0.7f);

        //        // Create a scene.
        //        var scene = new Scene();
        //        // Add the animating entity to the scene.
        //        scene.Add(new AnimatingEntity(game.HalfWidth, game.HalfHeight));

        //        // Start the game with the scene that was just created.
        //        game.Start(scene);
        //    }
    }

    class AnimatingEntity : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            WalkUp,
            WalkDown,
            WalkLeft,
            WalkRight,
            PlayOnce,
            PingPong
        }

        // Create the Spritemap to use. Use Sprite.png as the texture, and define the cell size as 32 x 32.
        Spritemap<Animation> spritemap = new Spritemap<Animation>(@"C:\Users\nico_\source\repos\GameOtter\JamUc9.2\PlayerMasc.png", 64, 32);

        public AnimatingEntity(float x, float y) : base(x, y)
        {
            // Add the animation data for walking upward.
            spritemap.Add(Animation.WalkDown, "0,1,2", 40); //Inicial WalkUp
            // Add the animation data for walking to the right.
            spritemap.Add(Animation.WalkLeft, "3,4,5", 40);
            // Add the animation data for walking downward.
            spritemap.Add(Animation.WalkRight, "6,7,8", 40);
            // Add the animation data for walking to the left.
            spritemap.Add(Animation.WalkUp, "9,10,11", 40);//Inicial WalkLeft
            // Add the animation data for the PlayOnce test.
            spritemap.Add(Animation.PlayOnce, "2,5,8,1,2,5,8,1", 60).NoRepeat();
            // Add the animation data for the PingPong test.
            spritemap.Add(Animation.PingPong, "2,5,8,11", 80).PingPong();

            // Center the spritemap's origin.
            spritemap.CenterOrigin();
            // Play the walking down animation immediately.
            spritemap.Play(Animation.WalkDown);

            // Add the graphic to the Entity so that it renders.
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            base.Update();

            if (Input.KeyPressed(Key.Up))
            {
                // Play the walk up animation when the up key is pressed.
                spritemap.Play(Animation.WalkUp);
            }
            if (Input.KeyPressed(Key.Down))
            {
                // Play the walk down animation when the down key is pressed.
                spritemap.Play(Animation.WalkDown);
            }
            if (Input.KeyPressed(Key.Left))
            {
                // Play the walk left animation when the left key is pressed.
                spritemap.Play(Animation.WalkLeft);
            }
            if (Input.KeyPressed(Key.Right))
            {
                // Play the walk right animation when the right key is pressed.
                spritemap.Play(Animation.WalkRight);
            }
            if (Input.KeyPressed(Key.X))
            {
                // Play the PlayOnce test animation.
                spritemap.Play(Animation.PlayOnce);
            }
            if (Input.KeyPressed(Key.C))
            {
                // Play the PingPong test animation.
                spritemap.Play(Animation.PingPong);
            }
        }
    }
}
