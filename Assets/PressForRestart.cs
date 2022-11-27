using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressForRestart : MonoBehaviour
{
    Image myImg;
    private void Start()
    {
        myImg = GetComponent<Image>();
    }
    void Update()
    {
        if(myImg.enabled && Input.GetKey(KeyCode.R))
        {
            UIManager.Inst.PressR();
        }
    }
}
