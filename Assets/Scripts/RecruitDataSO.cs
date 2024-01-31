using UnityEngine;

namespace Common.UI
{
    [CreateAssetMenu(fileName = "RecruitDataSO", menuName = "RecruitDataSO", order = 0)]
    public class RecruitDataSO : ScriptableObject
    {
         public int mineLevel;
                public int woodLevel;
                public int farmLevel;
                public int engineeringLevel;
                public int damageLevel;
    }
}