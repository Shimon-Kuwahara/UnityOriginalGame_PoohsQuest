using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject time_object = null;
    public GameObject target_tet = null;
    public float remaintime;
    public static int remaintarget = 10;
    public static int honeynum = 0;

    // Start is called before the first frame update
    void Start()
    {
        remaintarget = 10;
    }

    void Update()
    {
        Debug.Log(honeynum);

        Text time_text = time_object.GetComponent<Text>();
        Text target_text = target_tet.GetComponent<Text>();

        time_text.text = "残り時間：" + remaintime.ToString("00.00");
        remaintime -= Time.deltaTime;
        target_text.text = "x" + remaintarget.ToString();

        if(remaintime < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(remaintarget == 0)
        {
            Invoke("Load", 1f);
        }
    }

    public void Targetbreaking()
    {
        remaintarget--;
    }

    public void HoneyTaking()
    {
        honeynum++;
    }

    private void Load()
    {
        if(honeynum == 5)
        {
            SceneManager.LoadScene("Ending");
        }
        else
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}
