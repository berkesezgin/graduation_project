using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
public class ball : MonoBehaviour
{
    public GameObject scoreText;
    public int collectable;
    // Start is called before the first frame update
    public Transform Ball; // Drag & drop ball in inspector
    public float Frequency = 1f; // Every 1 second
    private float timer = 0.0f;
    private List<Vector3> positions = new List<Vector3>(128);
    public string filePathx;
    public string filename;
    void Start()
    {
        collectable = 0;
        //filePathx = GetFilePath();
        //Debug.Log(filePathx);
    }
    string GetFilePath()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string filePath = Path.Combine(@"C:\Users\HP\Documents\testtxt", sceneName + ".txt");
        for (int i = 1; File.Exists(filePath); ++i)
        {
            filename = sceneName + "_(" + i + ").txt";
            filePath = Path.Combine(@"C:\Users\HP\Documents\testtxt", filename);
            Debug.Log(filename);
            Debug.Log(filePath);
            Debug.Log("jkhjkhlı");
        }

        return filePath;
    }
    void AppendPositionsToFile()
    {
        File.AppendAllLines(filePathx, positions.ConvertAll(position => position.ToString()));

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE: " + collectable;
        timer += Time.deltaTime;

        if (timer > Frequency)
        {
            Vector3 a = gameObject.transform.position;
            positions.Add(a);

            positions.ForEach(num => Debug.Log(num + ", "));
            if (positions.Count > 1)
            {
                Debug.Log("meh");
                //AppendPositionsToFile();
                //positions.Clear();
            }
            timer -= Frequency;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.name == "goal")
        {

            SceneManager.LoadScene("GameOver");

            Destroy(gameObject);
           
            
        }

        if (other.gameObject.tag == "Collectable")
        {
            collectable++;
            
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "platform_Cube")
        {
            Destroy(col.gameObject);
        }
    }
}