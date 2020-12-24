using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankController : MonoBehaviour
{
    public float moveSpeed;

    public GameObject[] lifeImages;
    public GameObject gameOverScreen;

    bool isGameOver = false;

    public GameObject tankBullet;
    public Transform bulletSpawnPoint;


    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) && transform.position.x > -7.5f)
        {
            MoveLeft();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && transform.position.x < 7.5f)
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    public void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
    }
    public void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
    }

    public void Fire()
    {
        Instantiate(tankBullet, bulletSpawnPoint.position, Quaternion.identity);
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReduceLife();
        }
    }

    int life;

    public void ReduceLife()
    {
        if (life > 0)
        {
            life--;
            lifeImages[life].SetActive(false);
        }

        if (life == 0)
        {
            GameOver();
            Destroy(gameObject);
        }
    }
    void GameOver()
    {
        isGameOver = true;

        gameOverScreen.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            GameOver();
        }
    }
}
