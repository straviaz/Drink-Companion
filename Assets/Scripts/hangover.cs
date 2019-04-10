using System.IO;
using UnityEngine;
using Random = System.Random;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class hangover : MonoBehaviour
{
    [SerializeField] List<GameObject> print = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Resources/cures.txt";
        int random = new Random().Next(0, 24);
        string line = File.ReadLines(path).Skip(random-1).Take(1).First();
        string[] row = line.Split(new char[] { '"' });
        print[0].GetComponent<Text>().text = row[1];
        print[1].GetComponent<Text>().text = row[3];
        random = new Random().Next(0, 24);
    }

    
}
