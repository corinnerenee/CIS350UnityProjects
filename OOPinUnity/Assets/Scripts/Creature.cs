using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Enemy
{
    protected int damage;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 120;
        damage = 20;
        GameManager.instance.score += 3;
    }
    protected override void Attack(int amount)
    {
        base.Awake();
        health = 120;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Creature Attacks!");
    }

    protected override void TakeDamage(int amount)
    {
        Debug.Log("You've taken " + damage + " points of damage");
    }
}
