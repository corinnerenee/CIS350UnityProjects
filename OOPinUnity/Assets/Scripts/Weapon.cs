﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    public int damageBonus;
    public void Recharge()
    {
        Debug.Log("Recharging weapon");
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
