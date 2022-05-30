using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject panel_pause;
    public AudioSource aud;
    public AudioSource aud1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click_Pause()
    {
        aud.Play();
        panel_pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Click_Resume()
    {
        aud.Play();
        panel_pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Click_Restart()
    {
        aud.Play();
        Application.LoadLevel(2);
        Time.timeScale = 1;
    }
    public void Click_Menu()
    {
        aud1.Play();
        Application.LoadLevel(0);
        Time.timeScale = 1;
    }
}
