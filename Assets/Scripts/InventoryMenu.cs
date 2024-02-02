using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class InventoryMenu : MonoBehaviour
    {
        [SerializeField] private GameObject itemBorder;
        [SerializeField] private GridLayoutGroup gridLayoutGroup;



        private void Start()
        {
            /*
            foreach(var materialType in System.Enum.GetValues(typeof(MaterialType)))
            {
                var border = Instantiate(itemBorder, gridLayoutGroup.transform);
            }*/


            for (int i = 0; i < 40; i++)
            {
                var border = Instantiate(itemBorder, gridLayoutGroup.transform);
            }

        }



    }
}