using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Straight : MonoBehaviour
{

    private int nextX;
    private int nextY;
    [SerializeField] private float goSpeed;
    [SerializeField] private float moveXSpeed;
    [SerializeField] private float returnSpeed;

    [SerializeField] private bool isMoveY = false;
    [SerializeField] private bool isMoveX = false;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        if(isMoveY)
            StartCoroutine(CO_UpDown());
        else
            StartCoroutine(CO_LeftRight());
    }

    IEnumerator CO_UpDown()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            while (transform.position.y > -11)
            {
                transform.Translate(0, -goSpeed * Time.deltaTime, 0);
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            nextX = Random.Range(0, 4);
            while (transform.position.x == nextX)
            { nextX = Random.Range(0, 4); }
            while (Mathf.Abs(transform.position.x - nextX) > 0.01f)
            {
                if (transform.position.x > nextX) { transform.Translate(-moveXSpeed * Time.deltaTime, 0, 0); }
                else { transform.Translate(moveXSpeed * Time.deltaTime, 0, 0); }
                yield return null;
            }
            transform.position = new Vector2((int)transform.position.x, transform.position.y);
            yield return new WaitForSeconds(0.1f);
            while (transform.position.y < 8)
            {
                transform.Translate(0, returnSpeed * Time.deltaTime, 0);
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            nextX = Random.Range(0, 4);
            while (transform.position.x == nextX)
            {   nextX = Random.Range(0, 4); }
            while (Mathf.Abs(transform.position.x - nextX) > 0.01f)
            {
                if (transform.position.x > nextX) { transform.Translate(-moveXSpeed * Time.deltaTime, 0, 0); }
                else { transform.Translate(moveXSpeed * Time.deltaTime, 0, 0); }
                yield return null;
            }
            transform.position = new Vector2((int)transform.position.x, transform.position.y);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator CO_LeftRight()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            while (transform.position.x < 11)
            {
                Debug.Log("Move_Right");
                transform.Translate(goSpeed * Time.deltaTime, 0, 0);
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            nextY = Random.Range(0, -4);
            while (transform.position.y == nextY)
            { nextY = Random.Range(0, -4); }
            Debug.Log(nextY);
            while (Mathf.Abs(transform.position.y - nextY) > 0.01f)
            {
                if (transform.position.y > nextY) { transform.Translate(0, -moveXSpeed * Time.deltaTime, 0); }
                else { transform.Translate(0, moveXSpeed * Time.deltaTime, 0); }
                yield return null;
            }
            transform.position = new Vector2(transform.position.x, (int)transform.position.y);
            yield return new WaitForSeconds(0.1f);
            while (transform.position.x > -8)
            {
                Debug.Log(transform.position.x);
                transform.Translate(-returnSpeed * Time.deltaTime, 0, 0);
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            nextY = Random.Range(0, -4);
            while (transform.position.y == nextY)
            { nextY = Random.Range(0, -4); }
            while (Mathf.Abs(transform.position.y - nextY) > 0.01f)
            {
                if (transform.position.y > nextY) { transform.Translate(0, -moveXSpeed * Time.deltaTime, 0); }
                else { transform.Translate(0, moveXSpeed * Time.deltaTime, 0); }
                yield return null;
            }
            transform.position = new Vector2(transform.position.x, (int)transform.position.y);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
}
