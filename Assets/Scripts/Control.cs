using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public GameObject[] ball;
    public GameObject[] players;
    public Button[] btn;
    public AudioSource aud;
    private float times;
    private int c_up;
    private float times_rotate;
    private int c_rotate;
    private float times_left_right;
    private int c_left_right;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("player"))
        {
            players[PlayerPrefs.GetInt("player")].SetActive(true);
        }
        else
        {
            players[0].SetActive(true);
            PlayerPrefs.SetInt("player", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        times += Time.deltaTime;
        times_rotate += Time.deltaTime;
        times_left_right += Time.deltaTime;
        if (times > 1 && PlayerPrefs.GetInt("player")==0 && c_up==1)
        {
            c_up = 0;
            btn[1].interactable = true;
            btn[2].interactable = true;
        }
        if (times > 1 && PlayerPrefs.GetInt("player") == 1 && c_up==1)
        {
            c_up = 0;
            btn[1].interactable = true;
            btn[2].interactable = true;
        }
        if (times > 1 && PlayerPrefs.GetInt("player") == 2 && c_up==1)
        {
            c_up = 0;
            btn[1].interactable = true;
            btn[2].interactable = true;
        }
        ////////
        if (times_rotate > 2 && PlayerPrefs.GetInt("player") == 0 && c_rotate== 1)
        {
            c_rotate = 0;
            btn[0].interactable = true;
            btn[2].interactable = true;
        }
        if (times_rotate > 2 && PlayerPrefs.GetInt("player") == 1 && c_rotate==1)
        {
            c_rotate = 0;
            btn[0].interactable = true;
            btn[2].interactable = true;
        }
        if (times_rotate > 1.5 && PlayerPrefs.GetInt("player") == 2 && c_rotate==1)
        {
            c_rotate = 0;
            btn[0].interactable = true;
            btn[2].interactable = true;
        }
        /////////////
        if (times_left_right > 1 && PlayerPrefs.GetInt("player") == 0 && c_left_right == 1)
        {
            c_left_right = 0;
            btn[0].interactable = true;
            btn[1].interactable = true;
        }
        if (times_left_right > 1 && PlayerPrefs.GetInt("player") == 1 && c_left_right == 1)
        {
            c_left_right = 0;
            btn[0].interactable = true;
            btn[1].interactable = true;
        }
        if (times_left_right > 1 && PlayerPrefs.GetInt("player") == 2 && c_left_right == 1)
        {
            c_left_right = 0;
            btn[0].interactable = true;
            btn[1].interactable = true;
        }
    }
    public void Click_up()
    {
        switch (PlayerPrefs.GetInt("player"))
        {
            case 0:
                {
                    c_up = 1;
                    times = 0;
                    aud.Play();
                    btn[1].interactable = false;
                    btn[2].interactable = false;
                    ball[0].GetComponent<Animation>().Play("up");

                }
                break;
            case 1:
                {
                    c_up = 1;
                    times = 0;
                    aud.Play();
                    btn[1].interactable = false;
                    btn[2].interactable = false;
                    ball[1].GetComponent<Animation>().Play("up");

                }
                break;
            case 2:
                {
                    c_up = 1;
                    times = 0;
                    aud.Play();
                    btn[1].interactable = false;
                    btn[2].interactable = false;
                    ball[2].GetComponent<Animation>().Play("up_hok");
                }
                break;
            default:
                break;
        }
    }
    public void Click_rotate()
    {

        switch (PlayerPrefs.GetInt("player"))
        {
            case 0:
                {
                    c_rotate = 1;
                    times_rotate = 0;
                    aud.Play();
                    btn[0].interactable = false;
                    btn[2].interactable = false;
                    ball[0].GetComponent<Animation>().Play("rotate");
                }
                break;
            case 1:
                {
                    c_rotate = 1;
                    times_rotate = 0;
                    aud.Play();
                    btn[0].interactable = false;
                    btn[2].interactable = false;
                    ball[1].GetComponent<Animation>().Play("rotate");
                }
                break;
            case 2:
                {
                    c_rotate = 1;
                    times_rotate = 0;
                    aud.Play();
                    btn[0].interactable = false;
                    btn[2].interactable = false;
                    ball[2].GetComponent<Animation>().Play("rotate_hok");
                }
                break;
            default:
                break;
        }
    }
    public void Click_left_right()
    {
        switch (PlayerPrefs.GetInt("player"))
        {
            case 0:
                {
                    times_left_right = 0;
                    c_left_right = 1;
                    aud.Play();
                    btn[0].interactable = false;
                    btn[1].interactable = false;
                    ball[0].GetComponent<Animation>().Play("left_right");
                }
                break;
            case 1:
                {
                    times_left_right = 0;
                    c_left_right = 1;
                    aud.Play();
                    btn[0].interactable = false;
                    btn[1].interactable = false;
                    ball[1].GetComponent<Animation>().Play("left_right");
                }
                break;
            case 2:
                {
                    times_left_right = 0;
                    c_left_right = 1;
                    aud.Play();
                    btn[0].interactable = false;
                    btn[1].interactable = false;
                    ball[2].GetComponent<Animation>().Play("left_right_hok");
                }
                break;
            default:
                break;
        }
    }

}
