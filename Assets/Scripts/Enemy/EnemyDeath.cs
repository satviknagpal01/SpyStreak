using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int enemyHealth = 20;
    public bool isDead = false;
    public GameObject enemyAI;
    public GameObject thisSoldier;
    public GameObject hurtDispplay;
    public GameObject ammoTrigger;

    // Start is called before the first frame update
    void DamageEnemy(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0 && !isDead)
        {
            ammoTrigger.SetActive(true);
            isDead = true;
            thisSoldier.GetComponent<Animator>().Play("Die");
            DisplayStuff.ScoreDisplayNumber += 100;
            FloorComplete.enemyCount++;
            enemyAI.SetActive(false);
            thisSoldier.GetComponent<LookPlayer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            hurtDispplay.SetActive(false);
        }
    }
}
