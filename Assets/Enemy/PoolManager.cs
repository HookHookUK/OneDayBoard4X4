using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public float stageCount;

    void Update()
    {

        if (UIManager.Inst.aliveTime > 10)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if(UIManager.Inst.aliveTime > 30)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);

            transform.GetChild(2).gameObject.SetActive(true);
        }
        if (UIManager.Inst.aliveTime > 70)
        {
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (UIManager.Inst.aliveTime > 100)
        {
            transform.GetChild(4).gameObject.SetActive(true);
        }
    }
}
