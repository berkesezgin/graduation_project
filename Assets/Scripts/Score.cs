using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject scoreText;
    public int collectable;
    //public AudioSource collectSound;
    private void start()
    {
        collectable = 0;
    }

    private void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE: " + collectable;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectable")
        {
            collectable++;
            other.gameObject.SetActive(false);
        }
       
        
        
    }

}
