using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUpdate : MonoBehaviour
{
    SpriteRenderer mySR;
    

    private void OnEnable()
    {
        mySR = GetComponent<SpriteRenderer>();
    }

    
}
