using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public AudioClip sound;
    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
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
