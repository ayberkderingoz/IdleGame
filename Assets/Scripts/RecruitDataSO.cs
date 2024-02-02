using Enums;
using UnityEngine;

namespace Common.UI
{
    [CreateAssetMenu(fileName = "RecruitDataSO", menuName = "RecruitDataSO", order = 0)]
    public class RecruitDataSO : ScriptableObject
    {
         public RecruitRarity rarity;
         public int cost;
         public GameObject recruitPrefab;
         public GameObject recruitImage;
    }
}