using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Enemy
{
    protected int damage;
    TargetHealth oppHealth;
    ScoreManager scoreMan;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 120;
        damage = 20;
        //GameManager.Instance.score += 3;
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

    public override void TakeDamage(float amount)
    {
        scoreMan = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        scoreMan.AddScore();
        Destroy(gameObject);
    }
}
