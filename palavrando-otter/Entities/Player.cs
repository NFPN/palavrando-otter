using Otter;
using Palavrando.Extensions;
using Palavrando.Interfaces;

namespace Palavrando.Entities
{
    public class Player : Entity
    {
        private Sound ItemPickupSFX { get; set; }
        private IAnimatePlayer Animator { get; set; }
        private IMoveSystem MoveSystem { get; set; }

        public int MoveSpeed { get; private set; } = 5;
        public Vector2 PlayerSize { get; private set; } = new Vector2(25, 25);

        //Base Player, Instancing with x & y empty will make the player spaw at the center of screen
        public Player(Game currentGame, IMoveSystem moveSystem, IAnimatePlayer animation = null, float posX = 0, float posY = 0, Graphic graphic = null, Collider collider = null, string name = "")
            : base(posX, posY, graphic, collider, name)
        {
            var pX = (int)PlayerSize.X;
            var pY = (int)PlayerSize.Y;

            X = posX == 0 ? currentGame.HalfWidth : 0;
            Y = posY == 0 ? currentGame.HalfHeight : 0;

            //ItemPickupSFX = new Sound("PickupItem.wav");
            Collider = new BoxCollider(pX, pY, Tag.Player);
            MoveSystem = moveSystem;
            Collider.CenterOrigin();

            if (animation != null)
            {
                Animator = animation;
                Animator.SetMove(MoveSystem);
                AddGraphic(Animator.GetAnimationGraphic());
            }
            else
                Graphic = graphic ?? Image.CreateRectangle(pX, pY, Color.Blue);

            Graphic.CenterOrigin();
        }

        public override void Update()
        {
            MoveSystem.Move(this);
            Animator.Animate();

            var collisions = Collider.CollideEntities(X, Y, Tag.PickupItem);
            if (collisions != null)
                foreach (var entity in collisions)
                {
                    (entity as PickupItem).ChangePosition();
                    Program.Manager.AddScore(10);
                    //ItemPickupSFX.Play();
                }

            base.Update();
        }
    }
}