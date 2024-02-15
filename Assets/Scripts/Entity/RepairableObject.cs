using System;
using System.Collections;
using Recruit;
using UnityEngine;
using UnityEngine.UI;

namespace Entity
{
    public class RepairableObject : WorkableObject
    {
        [SerializeField] Slider repairSlider;
        [SerializeField] GameObject repairReward;
        [SerializeField] public float repairTime;
        
        public float repairTimer;

        

        void Awake()
        {
            maxWorkers = 1;
            workingTime = 1f;
            availablePositions = new Vector3[]
            {
                new Vector3(0, 0, 1),
            };
            
        }


        public override IEnumerator Work(Stats stats)
        {
            while (isWorking)
            {
                //wait for 1 second
                yield return new WaitForSeconds(workingTime);
                if (repairTimer < repairTime)
                {
                    repairTimer += 1f;
                    repairSlider.value = repairTimer / repairTime;
                }
                else
                {
                    repairSlider.value = 1;
                    isWorking = false;
                    repairTimer = 0;
                    OnWorkComplete();
                }
            }
            yield return null;
        }

        private void OnWorkComplete()
        {
            repairReward.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }
}