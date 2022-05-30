using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    private float value;
    void Start()
    {
        value = 0;
        load(level);
    }
    private void load(int level)
    {
        //Application.LoadLevel(level);
        StartCoroutine(LoadAsync());
    }
    IEnumerator LoadAsync()
    {
        // AsyncOperation asyncload = Application.LoadLevelAsync(level);
        while (value <= 10)
        {
            //sl.value = asyncload.progress;
            value += Time.deltaTime * 4;
            if (value >= 10)
            {
                Application.LoadLevel(level);
            }
            yield return 0;
        }
    }
}
