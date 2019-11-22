using Otter;
using Palavrando.Entities;
using Palavrando.Interfaces;

namespace Palavrando.AbstractBase
{
    public abstract class MoveSystem : IMoveSystem
    {
        private Input MyInput { get => MyInput ?? Input.Instance; }

        public void Move(Player player)
        {
            if (MyInput.KeyDown(Key.W) && !MyInput.KeyDown(Key.S)) //Inverse Y value
                player.Y -= player.MoveSpeed;
            if (MyInput.KeyDown(Key.S) && !MyInput.KeyDown(Key.W))
                player.Y += player.MoveSpeed;
            if (MyInput.KeyDown(Key.D) && !MyInput.KeyDown(Key.A))
                player.X += player.MoveSpeed;
            if (MyInput.KeyDown(Key.A) && !MyInput.KeyDown(Key.D))
                player.X -= player.MoveSpeed;
        }
    }
}