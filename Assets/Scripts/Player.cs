using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth=100;
    public int curHealth;

    public HealthBar healthBar;

    void Start()
    {
        curHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
   public void TakeDamage(int damage){
    if(curHealth > 0 ){
        curHealth -= damage;
        healthBar.SetHealth(curHealth);

    if(curHealth <= 0){
        Die();
    }
   }

   void Die(){
    Destroy(gameObject);
   }
}
}
