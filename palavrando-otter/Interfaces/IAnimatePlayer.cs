using Otter;

namespace Palavrando.Interfaces
{
    public interface IAnimatePlayer
    {
        Spritemap<Animation> GetAnimationGraphic();

        void Animate();

        void SetMove(IMoveSystem moveSystem);
    }

    public enum Animation
    {
        WalkUp,
        WalkDown,
        WalkLeft,
        WalkRight,
        PlayOnce,
        PingPong
    }
}