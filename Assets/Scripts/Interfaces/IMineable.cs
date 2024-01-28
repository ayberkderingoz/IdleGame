using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMineable
{
    IEnumerator Mine();
    void StopMining();
}
