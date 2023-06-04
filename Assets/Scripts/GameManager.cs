using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject time_object = null;
    public GameObject target = null;
    public float remaintime = 100;
    public float remaintarget = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        Text time_text = time_object.GetComponent<Text>();
        Text target_text = target.GetComponent<Text>();

        time_text.text = "残り時間：" + remaintime.ToString("000.00");
        remaintime -= Time.deltaTime;
        target_text.text = "x" + remaintarget.ToString();

        if(remaintarget == 0)
        {
            SceneManager.LoadScene("GameClear");
        }
    }

    public void Targetbreaking()
    {
        remaintarget--;
    }
}
