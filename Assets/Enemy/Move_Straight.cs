using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Straight : MonoBehaviour
{
    int dir = 0;
    [SerializeField] float speed;
    [SerializeField] Vector2[] startPos;

    [SerializeField] float aliveTime = 0f;
    [SerializeField] float DeadTime = 5f;

    private void Awake()
    {
        startPos = new Vector2[4];
        startPos[0] = new Vector2 (10, Random.Range(0,-4));
        startPos[1] = new Vector2 (-10, Random.Range(0, -4));
        startPos[2] = new Vector2 (Random.Range(0, 4), -10);
        startPos[3] = new Vector2 (Random.Range(0, 4), 10);
    }

    private void OnEnable()
    {
        aliveTime = 0f;

        dir = Random.Range(0, 4);
        transform.position = startPos[dir];
    }

    private void OnDisable()
    {
        transform.position = Vector2.zero;
    }


    // Update is called once per frame
    void Update()
    {
        aliveTime += Time.deltaTime;
        if(aliveTime >= DeadTime)
        {
            gameObject.SetActive(false);
        }

        if(dir == 0) // Left
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (dir == 1) // Right
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
            
        if (dir == 2) // Up
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
            
        if (dir == 3) // Down
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
            
    }
}
