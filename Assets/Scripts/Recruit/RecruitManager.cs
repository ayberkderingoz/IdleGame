using UnityEngine;

namespace Recruit
{
    public class RecruitManager: MonoBehaviour
    {
        //singleton
        private static RecruitManager _instance;
        public static RecruitManager Instance => _instance;

        public GameObject characterParent;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        void Update()
        {
            //TODO: remove this later
            if (Input.GetKeyDown(KeyCode.R))
            {
                RecruitRandom();
            }
        }
        
        
        
        public void RecruitRandom()
        {
            Stats stats = GetRandomStats();
            var characterPooledObject = ObjectPool.Instance.GetPooledObject(PooledObjectType.Character);
            var characterGameObject = characterPooledObject.gameObject;
            characterGameObject.GetComponent<Character>().SetCharacter(stats,characterPooledObject);
            characterGameObject.transform.SetParent(characterParent.transform);
            characterGameObject.SetActive(true);
            characterGameObject.transform.position = new Vector3(0, 0, 0); //TODO: add spawn point later on
            
        }
        
        public void Recruit(Stats stats)
        {
            
            
        }

        public Stats GetRandomStats() //TODO: Stats will be scaled with players current level
        {
            int mineLevel = Random.Range(1, 10);
            int woodLevel = Random.Range(1, 10);
            int farmLevel = Random.Range(1, 10);
            int engineeringLevel = Random.Range(1, 10);
            int damageLevel = Random.Range(1, 10);
            return new Stats(mineLevel, woodLevel, farmLevel, engineeringLevel, damageLevel);
        }
    }
    
    
    public class Stats 
    { //TODO: Stats are completely random, need to think about stats
        public int mineLevel;
        public int woodLevel;
        public int farmLevel;
        public int engineeringLevel;
        public int damageLevel;


        public Stats(int mineLevel, int woodLevel, int farmLevel, int engineeringLevel, int damageLevel)
        {
            this.mineLevel = mineLevel;
            this.woodLevel = woodLevel;
            this.farmLevel = farmLevel;
            this.engineeringLevel = engineeringLevel;
            this.damageLevel = damageLevel;
        }
    }
}