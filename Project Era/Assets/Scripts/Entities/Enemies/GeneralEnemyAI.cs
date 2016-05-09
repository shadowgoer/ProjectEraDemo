using UnityEngine;
using System.Collections;

public class GeneralEnemyAI : MonoBehaviour {

    public static AllEnemyStats enemyHealth;

    public AudioClip deathSound;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        enemyHealth = this.GetComponent<AllEnemyStats>();
        
        if (enemyHealth.health < 0)
        {
           
            SoundManager.instance.PlaySoundEffect(deathSound);
            BattleTime.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
            
        }


    }
}
