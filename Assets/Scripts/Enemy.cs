using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    public int health;
    //Animator anim;

    public void Damage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        transform.tag = "Untagged";
        Gold goldManager = GameObject.Find("Gold Manager").GetComponent<Gold>();
        goldManager.addMoney();
        //anim = GetComponent<Animator>();
        //anim.SetTrigger ("Dead");
    }

    // this update will check whether the enemy reach the game over point (the last way point) or not
    void Update()
    {
        Transform[] test2 = Tracker.wayPoints;

        if (Vector3.Distance(test2[test2.Length-1].position, this.transform.position) <= 0.5f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
