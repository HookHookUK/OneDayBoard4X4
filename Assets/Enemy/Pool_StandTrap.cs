using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_StandTrap : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    int posX = 0;
    int posY = 0;

    GameObject temp;
    GameObject tempChild;

    int type = 0;

    void Start()
    {
        StartCoroutine(CO_Gen_Trap());
    }

    IEnumerator CO_Gen_Trap()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            type = Random.Range(1, 4);
            switch(type)
            {
                /*case 0:
                    PoolInstRandom(Random.Range(0, 16));
                    break;*/
                case 1:
                    PoolInstLine();
                    break;
                case 2:
                    PoolInstCross();
                    break;
                case 3:
                    PoolInstBomb();
                    break;
            }
        }
    }

    public void PoolInstRandom(int i)
    {
        if (transform.GetChild(i).gameObject.activeSelf)
        {
            while(!transform.GetChild(i).gameObject.activeSelf)
                i = Random.Range(0, 16);
        }

        transform.GetChild(i).gameObject.SetActive(true);
    }

    public void PoolInstLine()
    {
        int dir = Random.Range(0, 4);
        switch(dir)
        {
            case 0:
                StartCoroutine(Line_Left());
                break;
            case 1:
                StartCoroutine(Line_Right());
                break;
            case 2:
                StartCoroutine(Line_Up());
                break;
            case 3:
                StartCoroutine(Line_Down());
                break;
        }
    }

    public void PoolInstCross()
    {
        int xy = Random.Range(0, 2);
        if (xy == 0)
        {
            StartCoroutine(CrossWave_X());
        }
        else
        {
            StartCoroutine(CrossWave_Y());
        }
    }

    public void PoolInstBomb()
    {
        StartCoroutine(Bomb());
    }

    IEnumerator Bomb()
    {
        int num = Random.Range(0, 2);
        if(num == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(10).gameObject.SetActive(true);
            transform.GetChild(15).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(true);
            transform.GetChild(9).gameObject.SetActive(true);
            transform.GetChild(12).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(7).gameObject.SetActive(true);
            transform.GetChild(8).gameObject.SetActive(true);
            transform.GetChild(11).gameObject.SetActive(true);
            transform.GetChild(13).gameObject.SetActive(true);
            transform.GetChild(14).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(7).gameObject.SetActive(true);
            transform.GetChild(8).gameObject.SetActive(true);
            transform.GetChild(11).gameObject.SetActive(true);
            transform.GetChild(13).gameObject.SetActive(true);
            transform.GetChild(14).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(true);
            transform.GetChild(9).gameObject.SetActive(true);
            transform.GetChild(12).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(10).gameObject.SetActive(true);
            transform.GetChild(15).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);

        }
    }

    #region CrossWave
    IEnumerator CrossWave_X()
    {
        int num = Random.Range(0, 2);
        if(num == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                transform.GetChild(0 + i).gameObject.SetActive(true);
                transform.GetChild(8 + i).gameObject.SetActive(true);
                transform.GetChild(7 - i).gameObject.SetActive(true);
                transform.GetChild(15 - i).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.2f);
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                transform.GetChild(4 + i).gameObject.SetActive(true);
                transform.GetChild(12 + i).gameObject.SetActive(true);
                transform.GetChild(3 - i).gameObject.SetActive(true);
                transform.GetChild(11 - i).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.2f);
            }
        }        
    }

    IEnumerator CrossWave_Y()
    {
        int num = Random.Range(0, 2);
        if (num == 0)
        {
            int pos = 0;
            for (int i = 0; i < 4; i++)
            {
                
                transform.GetChild(0 + pos).gameObject.SetActive(true);
                transform.GetChild(2 + pos).gameObject.SetActive(true);
                transform.GetChild(13 - pos).gameObject.SetActive(true);
                transform.GetChild(15 - pos).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                pos += 4;
            }
        }
        else
        {
            int pos = 0;
            for (int i = 0; i < 4; i++)
            {
                
                transform.GetChild(1 + pos).gameObject.SetActive(true);
                transform.GetChild(3 + pos).gameObject.SetActive(true);
                transform.GetChild(12 - pos).gameObject.SetActive(true);
                transform.GetChild(14 - pos).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                pos += 4;
            }
        }
    }

    #endregion

    #region LineWave
    IEnumerator Line_Right()
    {
        for(int i = 0; i < 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i+4).gameObject.SetActive(true);
            transform.GetChild(i+8).gameObject.SetActive(true);
            transform.GetChild(i+12).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator Line_Left()
    {
        for (int i = 3; i >= 0; i--)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i + 4).gameObject.SetActive(true);
            transform.GetChild(i + 8).gameObject.SetActive(true);
            transform.GetChild(i + 12).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator Line_Up()
    {
        int pos = 12;
        for (int i = 0; i < 4; i++)
        {
            
            transform.GetChild(pos).gameObject.SetActive(true);
            transform.GetChild(pos+1).gameObject.SetActive(true);
            transform.GetChild(pos+2).gameObject.SetActive(true);
            transform.GetChild(pos+3).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            pos -= 4;
        }
    }

    IEnumerator Line_Down()
    {
        int pos = 0;
        for (int i = 0; i < 4; i++)
        {
            
            transform.GetChild(pos).gameObject.SetActive(true);
            transform.GetChild(pos + 1).gameObject.SetActive(true);
            transform.GetChild(pos + 2).gameObject.SetActive(true);
            transform.GetChild(pos + 3).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            pos += 4;
        }
    }

    #endregion

}
