using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand_Trap : MonoBehaviour
{
    [SerializeField] bool isAttack = false;

    SpriteRenderer mySR;
    float alpha = 0f;
    bool isDoneUpdate = false;
    float turnTime = 0f;

    private void Awake()
    {
        mySR = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        alpha = 0.1f;
        
        StartCoroutine(SetStart());
        
    }

    IEnumerator SetStart()
    {
        while(alpha <= 0.99f)
        {
            mySR.color = new Color(255, 175, 0, alpha);
            yield return new WaitForSeconds(0.02f * Time.deltaTime);
            alpha += 1 * Time.deltaTime;
        }
        mySR.color = new Color(255, 0, 0, 1);
        isAttack = true;
        yield return new WaitForSeconds(10f * Time.deltaTime);
        isAttack = false;
        mySR.color = new Color(255, 0, 0, 0);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isAttack && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHit>().OnHit();
        }
    }
}
