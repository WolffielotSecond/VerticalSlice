using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstanceHolder : MonoBehaviour
{
    public GameInstance gameInstance;
    public static GameInstanceHolder instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
