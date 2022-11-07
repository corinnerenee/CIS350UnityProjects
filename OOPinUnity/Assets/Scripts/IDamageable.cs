using UnityEngine;
using System.Collections;

public interface IDamageable
{
    //specify methods that all classes will have to use

    ///add like attack, tke dmg, blah blah
    void TakeDamage(float amount);

    //void Attack(int amount);
}
