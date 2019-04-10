using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class exceldata : MonoBehaviour
{
    List<drinkObject> results = new List<drinkObject>();
    [SerializeField] List<GameObject> print = new List<GameObject>();
    [SerializeField] GameObject Inputbox;
    [SerializeField] GameObject dropdown;
    //public TextAsset data;
    // Start is called before the first frame update
    void Onclick()
    {
        results.Clear();
        for(int i = 0; i < 5; i++)
        {
            print[i].GetComponent<Text>().text = " ";
        }
        string type = dropdown.GetComponent<Dropdown>().captionText.text;
        string input = Inputbox.GetComponent<InputField>().text;
        string path = "Assets/Resources/"+type+".txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        //using (var reader = new StreamReader("Assets/Resources/"+ type + ".csv"))
        //Debug.Log(type + ".csv");
        //TextAsset data = Resources.Load<TextAsset>(type+".csv");
        
        while (!reader.EndOfStream) {
            string ro = reader.ReadLine();
                string[]row=ro.Split(new char[] { ',' });
            if (row[0].ToLower().Contains(input.ToLower())){
                drinkObject d = new drinkObject();
                d.Dname = row[0];
                d.description = row[1];
                for(int i = 2; i < 10; i++)
                {
                    var isdouble = Double.TryParse(row[i], out double result);
                    if (isdouble == true)
                    {
                        d.abv = Convert.ToInt32(result);
                        d.brand = row[i+1];
                        break;
                    }
                }
                results.Add(d);
            }
        }
       int count = 0;
       foreach(drinkObject d in results)
        {
            if (count == 5)
            {
                break;
            }
            print[count].GetComponent<Text>().text = d.Dname +"     abv: "+d.abv+"%";
            count++;
        }

    }

    // Update is called once per frame
    void run()
    {
        /*
        Excel.Range range;
        
        

        range = xlWorkSheet.UsedRange;
        int rw = range.Rows.Count;
        int cl = range.Columns.Count;


        for (int rCnt = 1; rCnt <= rw; rCnt++)
        {
            //for (int cCnt = 1; cCnt <= 10; cCnt++)
            //{
            String str = (string)(range.Cells[rCnt, 1] as Excel.Range).Value2;
            if (str.ToLower().Contains(input.ToLower()))
            {
                results.Add(str);
            }
            // }
        }
        Debug.Log(results);
      */

    }
}
