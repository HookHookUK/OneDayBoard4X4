using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    [SerializeField] SpriteRenderer mySR;

    float alpha;
    float time = 0f;

    [SerializeField] bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
    }

    public void OnHit()
    {
        if (!invincible)
        {
            --hp;
            StartCoroutine(Twincle());
            if (hp == 2)
            {
                mySR.color = Color.yellow;
            }
            else if (hp == 1)
            {
                mySR.color = Color.red;
            }
            if (hp == 0)
            {
                Destroy(gameObject);
                UIManager.Inst.PlayerDie();
            }
        }
        
    }
    IEnumerator Twincle()
    {
        while (time <= 1.5f)
        {
            invincible = true;
            mySR.color = new Color(mySR.color.r, mySR.color.g, mySR.color.b, 0.2f);
            yield return new WaitForSeconds(0.1f);
            mySR.color = new Color(mySR.color.r, mySR.color.g, mySR.color.b, 1);
            yield return new WaitForSeconds(0.1f);
            time += 0.2f;
        }
        time = 0f;
        invincible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invincible && collision.CompareTag("Obj"))
        {
            OnHit();
        }
    }
}
