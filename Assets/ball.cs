using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Ball; // Drag & drop ball in inspector
    public float Frequency = 1f; // Every 1 second
    private float timer = 0.0f;
    private List<Vector3> positions = new List<Vector3>(128);
    public string filePathx;
    public string filename;
    void Start()
    {

        filePathx = GetFilePath();
        Debug.Log(filePathx);
    }
    string GetFilePath()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string filePath = Path.Combine(@"C:\Users\HP\Documents\GitHub\graduation_project\testtxt", sceneName + ".txt");
        for (int i = 1; File.Exists(filePath); ++i)
        {
            filename = sceneName + "_(" + i + ").txt";
            filePath = Path.Combine(Application.persistentDataPath, filename);
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
        timer += Time.deltaTime;


        if (timer > Frequency)
        {
            Vector3 a = gameObject.transform.position;
            positions.Add(a);

            positions.ForEach(num => Debug.Log(num + ", "));
            if (positions.Count > 1)
            {
                Debug.Log("meh");
                AppendPositionsToFile(); // To be implemented
                positions.Clear();
            }
            timer -= Frequency;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.name == "goal")
        {
            Destroy(gameObject);
            Debug.Log("You win!!!");
        }
    }

}