using UnityEngine;

namespace Entity
{
    public class Tree : WorkableObject
    {

        void Awake()
        {
            availablePositions = new Vector3[]
            {
                new Vector3(0, 0, 1),
                new Vector3(1, 0, 0),
                new Vector3(0, 0, -1),
                new Vector3(-1, 0, 0)
            };

            rewardType = MaterialType.Wood;
            maxWorkers = 2;
            workingTime = 1f;

        }

        public bool CanWorkOn(GameObject worker)
        {
            return true;
        }
    }
}