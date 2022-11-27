using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject restartLogo;
    [SerializeField] TextMeshProUGUI restartText;
    [SerializeField] TextMeshProUGUI timeRecord;

    [SerializeField] public float aliveTime = 0f;

    #region ╫л╠шео
    static private UIManager instance;
    static public UIManager Inst
    {
        get 
        {
            if (instance == null)
            instance = FindObjectOfType<UIManager>();
            if(instance == null)
            { instance = new GameObject("GameMgr").AddComponent<UIManager>(); }
            return instance;
        }
        
    }
    #endregion

    public void Update()
    {
        aliveTime += Time.deltaTime;
        timeRecord.text = aliveTime.ToString();
    }

    public void PlayerDie()
    {
        restartLogo.GetComponent<Image>().enabled = true;
        restartText.enabled = true;
        //transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PressR()
    {
        aliveTime = 0;
        restartLogo.GetComponent<Image>().enabled = false;
        restartText.enabled = false;
        SceneManager.LoadScene(0);
    }    



}
