using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincible : MonoBehaviour
{
    SpriteRenderer mySR;
    float alpha;
    float time = 0f;
    public void Awake()
    {
        mySR = GetComponent<SpriteRenderer>();
    }
    private void Hit()
    {
        StartCoroutine(Twincle());
    }

    IEnumerator Twincle()
    {
        while(time >= 2f)
        {
            alpha = -1 * Time.deltaTime;
            mySR.color = new Color(mySR.color.r, mySR.color.g, mySR.color.b, alpha);
            yield return new WaitForSeconds(1f);
            alpha = 1 * Time.deltaTime;
            mySR.color = new Color(mySR.color.r, mySR.color.g, mySR.color.b, alpha);
            yield return new WaitForSeconds(1f);
            time += Time.deltaTime;
        }
        time = 0f;
    }
}
