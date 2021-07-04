using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppInitializer : MonoBehaviour
{
    void Awake()
    {
        AppManager.LoadData();
    }
}
