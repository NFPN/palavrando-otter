using Otter;
using Palavrando.Interfaces;
using Palavrando.Systems;

namespace Palavrando.Utilities
{
    public class PlayerAnimation : IAnimatePlayer
    {
        private Spritemap<Animation> MySpritemap { get; set; } = new Spritemap<Animation>(PathFolder.GetDirectory() + @"\Images\PlayerMasc.png", 64, 32);
        private IMoveSystem MoveSystem { get; set; }

        public PlayerAnimation()
        {
            MySpritemap.Add(Animation.WalkDown, "0,1,2", 5); //Inicial WalkUp
            MySpritemap.Add(Animation.WalkLeft, "3,4,5", 5);
            MySpritemap.Add(Animation.WalkRight, "6,7,8", 5);
            MySpritemap.Add(Animation.WalkUp, "9,10,11", 5);//Inicial WalkLeft
            MySpritemap.Add(Animation.PlayOnce, "2,5,8,1,2,5,8,1", 60).NoRepeat();
            MySpritemap.Add(Animation.PingPong, "2,5,8,11", 80).PingPong();

            MySpritemap.CenterOrigin();
        }

        public void Animate()
        {
            if (MoveSystem == null)
                return;

            if (MoveSystem.IsPressingUp())
                if (MySpritemap.CurrentAnim != Animation.WalkUp)
                    MySpritemap.Play(Animation.WalkUp);

            if (MoveSystem.IsPressingDown())
                if (MySpritemap.CurrentAnim != Animation.WalkDown)
                    MySpritemap.Play(Animation.WalkDown);

            if (MoveSystem.IsPressingLeft())
                if (MySpritemap.CurrentAnim != Animation.WalkLeft)
                    MySpritemap.Play(Animation.WalkLeft);

            if (MoveSystem.IsPressingRight())
                if (MySpritemap.CurrentAnim != Animation.WalkRight)
                    MySpritemap.Play(Animation.WalkRight);

            if (MoveSystem.Pressed(Key.X))
                if (MySpritemap.CurrentAnim != Animation.PlayOnce)
                    MySpritemap.Play(Animation.PlayOnce);

            if (MoveSystem.Pressed(Key.C))
                if (MySpritemap.CurrentAnim != Animation.PingPong)
                    MySpritemap.Play(Animation.PingPong);

            //TODO: make stop animation method
        }

        public Spritemap<Animation> GetAnimationGraphic() => MySpritemap;

        public void SetMove(IMoveSystem moveSystem) => MoveSystem = moveSystem;
    }
}