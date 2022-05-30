using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public Text score_text;
    public Text record_score_text;
    public static double time = 0;
    public GameObject panel_game_over;
    private int ff;
    private int ss;
    private int mm;
    public AudioSource aud;
    public GameObject pn_yelow;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minut = (int)time;
         ff = (int)((time - minut) *100);
         mm = (int)minut/60;
         ss = minut % 60;
        score_text.text = mm.ToString("00") + ":" + ss.ToString("00") + ":" + ff.ToString("00");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("card"))
        {
            aud.Play();
            if (PlayerPrefs.HasKey("max_record")){
                if (PlayerPrefs.GetFloat("max_record") < time)
                {
                    pn_yelow.SetActive(true);
                }
                else
                    pn_yelow.SetActive(false);
            }
            else
                pn_yelow.SetActive(true);

            panel_game_over.SetActive(true);
            Time.timeScale = 0;
            record_score_text.text = mm.ToString("00") + ":" + ss.ToString("00") + ":" + ff.ToString("00");
            PlayerPrefs.SetFloat("record", (float)time);
            PlayerPrefs.SetFloat("max_record", (float)time);
            PlayerPrefs.SetInt("nomer",PlayerPrefs.GetInt("player")+1);
            PlayerPrefs.SetString("user", "user" + PlayerPrefs.GetInt("player").ToString());
        }
    }
}
