﻿using UnityEngine;
using UnityEngine.UDP;
public class InitListener : MonoBehaviour, IInitListener
{
    public void OnInitialized(UserInfo userInfo)
    {
        Debug.Log("Initialization succeeded");
        // You can call the QueryInventory method here
        // to check whether there are purchases that haven’t be consumed.
    }
    public void OnInitializeFailed(string message)
    {
        Debug.Log("Initialization failed: " + message);
    }
}
