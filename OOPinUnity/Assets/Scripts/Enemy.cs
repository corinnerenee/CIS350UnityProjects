using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected float speed;
    protected float health;

    //create reference to creature script and specific enemy holding item
    /*public Enemy enemyHoldingWeapon 
     * private void Awake()
     * enemyHoldingWeapon = gameObject.GetComponent<Enemy>(); //polymorphism getting creature subclass
     * EnemyEatsWeapon(enemyHoldingWeapon);
     */

    public Enemy enemyCube;

    protected void EnemyEatsWeapon(Enemy enemy)
    {
        Debug.Log("Enemy Eats Weapon");
    }

    [SerializeField] protected Weapon weapon; 
    protected virtual void Awake() //virtual allows for override in c#
    {
        enemyCube = gameObject.GetComponent<Enemy>(); //polymorphism
        weapon = gameObject.AddComponent<Weapon>(); //adds instance of game object to each enemy
        speed = 5F;
        health = 100;
    }
    protected abstract void Attack(int amount); //forces us to make sure every enemy has certain functions
    public abstract void TakeDamage(float amount);
 

    // Update is called once per frame
    void Update()
    {
        
    }
}
