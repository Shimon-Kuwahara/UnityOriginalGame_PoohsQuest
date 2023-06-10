using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public AudioClip sound;
    public AudioClip sound1;
    AudioSource audioSource;

    public GameObject target_te = null;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);

    }
    void Update()
    {
        Text target_text = target_te.GetComponent<Text>();
        target_text.text = "more    x " + GameManager.remaintarget.ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            audioSource.PlayOneShot(sound1);
            Debug.Log("click Ok");
            Invoke("Load", 2.0f);
        }
    }

    private void Load()
    {
        SceneManager.LoadScene("Stage1");
    }
}
