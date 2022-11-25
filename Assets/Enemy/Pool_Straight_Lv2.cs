using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Straight_Lv2 : MonoBehaviour
{
        [SerializeField] GameObject Obj;
        int dir = 0;
        [SerializeField] float delay = 0.5f;
        [SerializeField] float startPos_X;
        [SerializeField] float startPos_Y;

        GameObject temp;
        GameObject tempChild;

        void Start()
        {
            StartCoroutine(CO_Gen_Straight());
        }

        IEnumerator CO_Gen_Straight()
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                PoolInst();
            }
        }

        public Vector2 StartPos() // 초기 방향값
        {
            dir = Random.Range(0, 4);
            switch (dir)
            {
                case 0: // Left
                    return new Vector2(startPos_X, Random.Range(0, -4));
                case 1: // Right
                    return new Vector2(-startPos_X, Random.Range(0, -4));
                case 2: // Up
                    return new Vector2(Random.Range(0, 4), -startPos_Y);
                default: // Down
                    return new Vector2(Random.Range(0, 4), startPos_Y);
            }
        }

        public void PoolInst()
        {
            Vector2 setPos = StartPos();
            if (transform.childCount == 0)
            {
                temp = Instantiate(Obj, setPos, Quaternion.identity);
                temp.transform.SetParent(transform);
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (!transform.GetChild(i).gameObject.activeSelf)
                    {
                        tempChild = transform.GetChild(i).gameObject;
                        tempChild.SetActive(true);
                        //tempChild.transform.position = setPos;
                        break;
                    }

                    if (i == transform.childCount - 1)
                    {
                        temp = Instantiate(Obj, setPos, Quaternion.identity);
                        temp.transform.SetParent(transform);
                        break;
                    }
                }
            }
        }
    }
