using Palavrando.Entities;
using Palavrando.Extensions;
using System.Collections.Generic;

namespace Palavrando.Managers
{
    public class PickupItemSpawnManager
    {
        private const int MAXITEMS = 5;

        public List<PickupItem> PickupItems { get; private set; }

        public PickupItemSpawnManager() => Start();

        private void Start()
        {
            PickupItems = new List<PickupItem>();
            for (int i = 0; i < MAXITEMS; i++)
                PickupItems.Add(new PickupItem().ChangePosition());
        }
    }
}