using Otter;
using Palavrando.Entities;
using Palavrando.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Palavrando.Systems
{
    public class MoveSystem : IMoveSystem
    {
        private Input MyInput { get => Input.Instance; }

        #region Keylist Properties

        private List<Key> UpKeys { get; set; } = new List<Key>();
        private List<Key> LeftKeys { get; set; } = new List<Key>();
        private List<Key> DownKeys { get; set; } = new List<Key>();
        private List<Key> RightKeys { get; set; } = new List<Key>();

        #endregion Keylist Properties

        public MoveSystem() => SetupDefaultKeys();

        public void Move(Player player)
        {
            //Inverse Y value
            if (PressedUp() && !PressedDown())
                player.Y -= player.MoveSpeed;
            if (PressedDown() && !PressedUp())
                player.Y += player.MoveSpeed;
            if (PressedRight() && !PressedLeft())
                player.X += player.MoveSpeed;
            if (PressedLeft() && !PressedRight())
                player.X -= player.MoveSpeed;
        }

        public void SetupDefaultKeys()
        {
            UpKeys.AddRange(new Key[] { Key.Up, Key.W });
            LeftKeys.AddRange(new Key[] { Key.Left, Key.A });
            DownKeys.AddRange(new Key[] { Key.Down, Key.S });
            RightKeys.AddRange(new Key[] { Key.Right, Key.D });
        }

        #region Key Adders

        public void AddUpkey(Key up) => UpKeys.Add(up);

        public void AddLeftkey(Key left) => LeftKeys.Add(left);

        public void AddDownkey(Key down) => DownKeys.Add(down);

        public void AddRightkey(Key right) => RightKeys.Add(right);

        #endregion Key Adders

        #region Input Validation

        private bool PressedUp() => UpKeys.Any(k => MyInput.KeyDown(k));

        private bool PressedLeft() => LeftKeys.Any(k => MyInput.KeyDown(k));

        private bool PressedDown() => DownKeys.Any(k => MyInput.KeyDown(k));

        private bool PressedRight() => RightKeys.Any(k => MyInput.KeyDown(k));

        #endregion Input Validation
    }
}