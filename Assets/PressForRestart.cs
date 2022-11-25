using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressForRestart : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            UIManager.Inst.PressR();
        }
    }
}
