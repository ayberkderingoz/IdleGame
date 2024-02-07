using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

namespace DefaultNamespace
{
    public class Helpers
    {
        private static LayerMask UILayer = 5;
        //Returns 'true' if we touched or hovering on Unity UI element.
        public static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
        {
            for (int index = 0; index < eventSystemRaysastResults.Count; index++)
            {
                RaycastResult curRaysastResult = eventSystemRaysastResults[index];
                if (curRaysastResult.gameObject.layer == UILayer)
                    return true;
            }
            return false;
        }

        public static IEnumerator IsInternetAvailable(System.Action<bool> callback)
        {
            using (UnityWebRequest www = UnityWebRequest.Get("https://google.com"))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    callback(false);
                }
                else
                {
                    callback(true);
                }
            }
        }
    }
}