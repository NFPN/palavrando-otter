using Otter;
using Palavrando.Entities;

namespace Palavrando.Interfaces
{
    public interface IMoveSystem
    {
        void Move(Player player);

        bool Pressed(Key key);
        bool IsPressingUp();
        bool IsPressingLeft();
        bool IsPressingDown();
        bool IsPressingRight();
        //bool IsAnyKeyPressed();
    }
}