using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel_setting;
    public GameObject panel_record;
    public GameObject panel_shop;
    public GameObject[] pn_player;
    public GameObject[] pn_ok;
    public GameObject[] pn_buy;
    public Button btn_left;
    public Button btn_right;
    private int count;
    public Button[] buy;
    public Button[] ok;
    private float record;
    private float[] array_record;
    private int[] nomer;
    private string[] user;
    public Text[] record_text;
    public GameObject[] image;
    public AudioSource aud;
    private int count_track;
    public Button track_btn_left;
    public Button track_btn_right;
    public GameObject[] pn_track;
    /// /////
    public GameObject[] btn;
    public GameObject[] star;
    public GameObject panel_feedback;
    public GameObject[] btn_send_ok;
    public InputField inputField;
    public GameObject[] name_text;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        array_record = new float[6];
        nomer = new int[6];
        user = new string[6];
        if (PlayerPrefs.HasKey("player"))
        {
            count = PlayerPrefs.GetInt("player");
        }
        else
            count = 0;

        if (PlayerPrefs.HasKey("track"))
        {
            count_track = PlayerPrefs.GetInt("track");
        }
        else
        {
            count_track = 0;
            PlayerPrefs.SetInt("track",count_track);
        }


        if (PlayerPrefs.HasKey("record"))
        {
            array_record[5] = PlayerPrefs.GetFloat("record");
            PlayerPrefs.DeleteKey("record");
        }
        else
            array_record[5] = 0;

        if (PlayerPrefs.HasKey("nomer"))
        {
            nomer[5] = PlayerPrefs.GetInt("nomer");
            PlayerPrefs.DeleteKey("nomer");
        }
        else
            nomer[5] = 1;

        if (PlayerPrefs.HasKey("user"))
        {
            user[5] = PlayerPrefs.GetString("user");
            PlayerPrefs.DeleteKey("user");
        }
        else
            user[5] = " ";
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("r" + i.ToString()))
            {
                array_record[i] = PlayerPrefs.GetFloat("r" + i.ToString());
            }
            else
                array_record[i] = 0;

            if (PlayerPrefs.HasKey("n" + i.ToString()))
            {
                nomer[i] = PlayerPrefs.GetInt("n" + i.ToString());
            }
            else
                nomer[i] = 0;

            if (PlayerPrefs.HasKey("u" + i.ToString()))
            {
                user[i] = PlayerPrefs.GetString("u" + i.ToString());
            }
            else
                user[i] = "";
        }


    }
    private void sort()
    {
        for (int j = 0; j < array_record.Length; j++)
            for (int k = 0; k < array_record.Length - 1; k++)
            {
                if (array_record[k] < array_record[k + 1])
                {
                    float temp = array_record[k];
                    array_record[k] = array_record[k + 1];
                    array_record[k + 1] = temp;

                    int temp1 = nomer[k];
                    nomer[k] = nomer[k + 1];
                    nomer[k + 1] = temp1;

                    string temp2 = user[k];
                    user[k] = user[k + 1];
                    user[k + 1] = temp2;
                }
            }
    }
    private void Time_records()
    {
        for (int i = 0; i < 5; i++)
        {
            if (array_record[i] != 0)
            {
                int minut = (int)array_record[i];
                int ff = (int)((array_record[i] - minut) * 100);
                int mm = (int)minut / 60;
                int ss = minut % 60;
                record_text[i].text = nomer[i].ToString() + ". " + user[i] + "     " + mm.ToString("00") + ":" + ss.ToString("00") + ":" + ff.ToString("00");
            }
            else
                record_text[i].text = "";

        }
    }
    // Update is called once per frame
    void Update()
    {
        sort();
        for(int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat("r" + i.ToString(), array_record[i]);
            PlayerPrefs.SetInt("n" + i.ToString(), nomer[i]);
            PlayerPrefs.SetString("u" + i.ToString(), user[i]);
        }
        Time_records();
        ////////////////// shop_players
        if (count == 0)
        {
            pn_player[0].SetActive(true);
            pn_player[1].SetActive(false);
            pn_player[2].SetActive(false);
        }
        if (count == 1)
        {
            pn_player[0].SetActive(false);
            pn_player[1].SetActive(true);
            pn_player[2].SetActive(false);
        }
        if (count == 2)
        {
            pn_player[0].SetActive(false);
            pn_player[1].SetActive(false);
            pn_player[2].SetActive(true);
        }
        if (count < 0 || count >= 2)
        {
            btn_right.interactable = false;
        }
        else
            btn_right.interactable = true;

        if (count < 1 || count > 2)
        {
            btn_left.interactable = false;
        }
        else
            btn_left.interactable = true;
        /////////////////     TRACK
        if (count_track == 0)
        {
            pn_track[0].SetActive(true);
            pn_track[1].SetActive(false);
            pn_track[2].SetActive(false);
        }
        if (count_track == 1)
        {
            pn_track[0].SetActive(false);
            pn_track[1].SetActive(true);
            pn_track[2].SetActive(false);
        }
        if (count_track == 2)
        {
            pn_track[0].SetActive(false);
            pn_track[1].SetActive(false);
            pn_track[2].SetActive(true);
        }
        if (count_track < 0 || count_track >= 2)
        {
            track_btn_right.interactable = false;
        }
        else
            track_btn_right.interactable = true;

        if (count_track < 1 || count_track > 2)
        {
            track_btn_left.interactable = false;
        }
        else
            track_btn_left.interactable = true;
        ////////////// BUY PLAYERS

        if (PlayerPrefs.HasKey("buy1"))
        {
            pn_buy[0].SetActive(false);
            pn_ok[1].SetActive(true);
            image[0].SetActive(false);

        }
        if (PlayerPrefs.HasKey("buy2"))
        {
            pn_buy[1].SetActive(false);
            pn_ok[2].SetActive(true);
            image[1].SetActive(false);
        }
        if(array_record[0]>=600)
        {
            buy[0].interactable = true;
            buy[1].interactable = true;
        }
    }
    /// ENTER PLAYERS
    public void Click_Players(int c)
    {
        switch (c)
        {
            case 0:
                {
                    aud.Play();
                    PlayerPrefs.SetInt("player",0);
                }
                break;
            case 1:
                {
                    aud.Play();
                    PlayerPrefs.SetInt("player", 1);
                }
                break;
            case 2:
                {
                    aud.Play();
                    PlayerPrefs.SetInt("player", 2);
                }
                break;
            default:
                break;
        }
    }
    public void Buy(int c)
    {
        switch (c)
        {
            case 1:
                {
                    aud.Play();
                    PlayerPrefs.SetInt("buy1", 1);
                }
                break;
            case 2:
                {
                    aud.Play();
                    PlayerPrefs.SetInt("buy2", 2);
                }
                break;
            default:
                break;
        }
    }
    public void Click_right()
    {
        aud.Play();
        count++;
    }
    public void Click_left()
    {
        aud.Play();
        count--;
    }
    public void Click_menu(int count)
    {
        switch (count)
        {
            case 0:
                {
                    aud.Play();
                    Application.LoadLevel(1);
                }
                break;
            case 1:
                {
                    aud.Play();
                    panel_setting.SetActive(true);
                }
                break;
            case 2:
                {
                    aud.Play();
                    panel_record.SetActive(true);
                }
                break;
            case 3:
                {
                    aud.Play();
                    panel_shop.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    public void Clock_menu(int count)
    {
        switch (count)
        {
            case 0:
                {
                    aud.Play();
                    Application.LoadLevel(1);
                }
                break;
            case 1:
                {
                    aud.Play();
                    panel_setting.SetActive(false);
                }
                break;
            case 2:
                {
                    aud.Play();
                    panel_record.SetActive(false);
                }
                break;
            case 3:
                {
                    aud.Play();
                    panel_shop.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
    public void Click_right_btn()
    {
        aud.Play();
        count_track++;
    }
    public void Click_left_btn()
    {
        aud.Play();
        count_track--;
    }
    public void Click_send()
    {
        aud.Play();
        PlayerPrefs.SetInt("send", 1);
        btn_send_ok[0].SetActive(false);
        btn_send_ok[1].SetActive(true);
        name_text[0].SetActive(false);
        name_text[1].SetActive(true);
        PlayerPrefs.SetString("text_feedback", inputField.text);
        inputField.interactable = false;
        for (int i = 0; i < 5; i++)
        {
            btn[i].SetActive(false);
        }
    }
    public void Click_feedback()
    {
        aud.Play();
        panel_feedback.SetActive(true);
        if (PlayerPrefs.HasKey("send"))
        {
            btn_send_ok[0].SetActive(false);
            btn_send_ok[1].SetActive(true);
            name_text[0].SetActive(false);
            name_text[1].SetActive(true);
            for (int i = 0; i < 5; i++)
            {
                btn[i].SetActive(false);
            }
            if (PlayerPrefs.HasKey("text_feedback"))
            {
                inputField.text = PlayerPrefs.GetString("text_feedback");
                inputField.interactable = false;
            }
            if (PlayerPrefs.HasKey("Star"))
            {
                for (int i = 0; i < PlayerPrefs.GetInt("Star")+1; i++)
                {
                    star[i].SetActive(true);
                }
                for (int i = PlayerPrefs.GetInt("Star") + 1; i < 5; i++)
                {
                    star[i].SetActive(false);
                }
            }
        }
    }
    public void Clock_feedback()
    {
        aud.Play();
        panel_feedback.SetActive(false);
    }
    public void In_menu_feedback()
    {
        aud.Play();
        panel_feedback.SetActive(false);
        panel_setting.SetActive(false);
    }
    public void Click_star(int c)
    {
        aud.Play();
        switch (c)
        {
            case 0:
                {
                    PlayerPrefs.SetInt("Star", 0);
                    star[0].SetActive(true);
                    for(int i = 1; i < 5; i++)
                    {
                        star[i].SetActive(false);
                    }
                }
                break;
            case 1:
                {
                    PlayerPrefs.SetInt("Star", 1);
                    for (int i = 0; i < 2; i++)
                    {
                        star[i].SetActive(true);
                    }
                    for (int i = 2; i < 5; i++)
                    {
                        star[i].SetActive(false);
                    }
                }
                break;
            case 2:
                {
                    PlayerPrefs.SetInt("Star", 2);
                    for (int i = 0; i < 3; i++)
                    {
                        star[i].SetActive(true);
                    }
                    for (int i = 3; i < 5; i++)
                    {
                        star[i].SetActive(false);
                    }
                }
                break;
            case 3:
                {
                    PlayerPrefs.SetInt("Star", 3);
                    for (int i = 0; i < 4; i++)
                    {
                        star[i].SetActive(true);
                    }
                    for (int i = 4; i < 5; i++)
                    {
                        star[i].SetActive(false);
                    }
                }
                break;
            case 4:
                {
                    PlayerPrefs.SetInt("Star", 4);
                    for (int i = 0; i < 5; i++)
                    {
                        star[i].SetActive(true);
                    }
                }
                break;
            default:
                break;
        }
    }
}
