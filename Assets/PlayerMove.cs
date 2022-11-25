using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] SpriteRenderer mySR;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(transform.position.x == 0)
            { transform.Translate(3, 0, 0); }
            else
            { transform.Translate(-1, 0, 0); }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x == 3)
            { transform.Translate(-3, 0, 0); }
            else
            { transform.Translate(1, 0, 0); }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (transform.position.y == 0)
            { transform.Translate(0, -3, 0); }
            else
            { transform.Translate(0, 1, 0); }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (transform.position.y == -3)
            { transform.Translate(0, 3, 0); }
            else
            { transform.Translate(0, -1, 0); }
        }
    }

    public void GetHit()
    {
        transform.GetChild(0).gameObject.GetComponent<PlayerHit>().OnHit();
    }

}
