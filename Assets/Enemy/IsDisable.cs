using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDisable : MonoBehaviour
{
    private float alpha = 0f;
    SpriteRenderer SR;
    BoxCollider2D BoxCol;

    private void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        BoxCol = GetComponent<BoxCollider2D>();
        StartCoroutine(SetAble());
    }
    
    IEnumerator SetAble()
    {
        while(alpha < 0.99f)
        {
            SR.color = new Color(1, 0.4f, 0.4f, alpha);
            alpha += 0.3f * Time.deltaTime;
            yield return new WaitForSecondsRealtime(0.001f);
        }
        BoxCol.enabled = true;
    }
}
