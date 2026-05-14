using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAsset : MonoBehaviour
{
    
    void Awake()
    {
        GameInstanceHolder.instance.ResetGame();
    }

    
}
