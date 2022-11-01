using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected float speed;
    protected int health;

    //create reference to creature script and specific enemy holding item
    /*public Enemy enemyHoldingWeapon 
     * private void Awake()
     * enemyHoldingWeapon = gameObject.GetComponent<Enemy>(); //polymorphism getting creature subclass
     * EnemyEatsWeapon(enemyHoldingWeapon);
     */

    protected void EnemyEatsWeapon(Enemy enemy)
    {
        Debug.Log("Enemy Eats Weapon");
    }

    [SerializeField] protected Weapon weapon; 
    protected virtual void Awake() //virtual allows for override in c#
    {
        weapon = gameObject.AddComponent<Weapon>(); //adds instance of game object to each enemy
        speed = 5F;
        health = 100;
    }
    protected abstract void Attack(int amount); //forces us to make sure every enemy has certain functions
    protected abstract void TakeDamage(int amount);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
