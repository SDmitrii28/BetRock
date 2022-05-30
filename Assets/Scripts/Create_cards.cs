using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_cards : MonoBehaviour
{
    public GameObject[] card;
    private float[] pos = { -1.59f, 0.15f, 1.76f };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn_card());
    }

    IEnumerator spawn_card()
    {
        while (true)
        {
            
                Instantiate(card[Random.Range(0, card.Length)], new Vector3(Random.Range(-1.59f, 1.76f), 8, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            yield return new WaitForSeconds(2f);
        }
    }

}
