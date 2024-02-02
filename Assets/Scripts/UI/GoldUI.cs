using TMPro;
using UnityEngine;

namespace Common.UI.UI
{
    public class GoldUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldText;

        void Awake()
        {
            
        }

        void Start()
        {
            PlayerDataManager.Instance.OnGoldChange += OnGoldChange;
            
        }


        public void OnGoldChange(int goldCount)
        {
            goldText.text = goldCount.ToString();
        }
    }
}