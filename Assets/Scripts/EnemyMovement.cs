using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool stopMovement;

    [SerializeField]
    private bool isMovingLeft = true;
    public float move;

    private float timerSide;
    private float timerDown;
    [SerializeField]
    private float moveTimeSide;
    [SerializeField]
    private float moveTimeDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopMovement)
        {
            return;
        }

        timerSide += Time.deltaTime;
        timerDown += Time.deltaTime;

        if(timerSide > moveTimeSide)
        {
            if (isMovingLeft && transform.position.x > -3.5f)
                transform.position = new Vector2(transform.position.x - move, transform.position.y);
            else if (isMovingLeft && transform.position.x <= -3.5f)
            {
                isMovingLeft = false;
            }
                

            if (!isMovingLeft && transform.position.x < 3.5f)
                transform.position = new Vector2(transform.position.x + move, transform.position.y);
            else if (!isMovingLeft && transform.position.x >= 3.5f)
                isMovingLeft = true;

            timerSide = 0f;
        }
        if(timerDown > moveTimeDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - move);
            timerDown = 0f;
        }
    }
}
