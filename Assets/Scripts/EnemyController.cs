using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 1;

    public float timer;
    public float[] randomTimer = { 0.2f, 0.4f, 0.6f, 1f, 1.5f, 2f, 3f };

    public GameObject bullet;
    public Transform bulletSpawnPoint;

    public int scoreValue;

    private ScoreManager scoreManager;
    private TankController controller;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        controller = FindObjectOfType<TankController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


        if (timer < 0f)
        {
            int randomNumber = Random.Range(0, randomTimer.Length);
       
            Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            timer = randomTimer[randomNumber];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            TakeDamage(1);
        }
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 1)
        {
            scoreManager.UpdateScore(scoreValue);
            Destroy(gameObject);
        }
    }
    

}
