using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class exceldata : MonoBehaviour
{
    List<drinkObject> results = new List<drinkObject>();
    [SerializeField] GameObject Inputbox;
    [SerializeField] GameObject dropdown;
    // Start is called before the first frame update
    void Onclick()
    {
        string type = dropdown.GetComponent<Dropdown>().captionText.text;
        string input = Inputbox.GetComponent<InputField>().text;
        TextAsset data = Resources.Load<TextAsset>(type);
        string[] parse = data.text.Split(new char[] { '\n' });
        for(int i = 1; i < parse.Length - 1; i++)
        {
            string[] row = parse[i].Split(new char[] { ',' });
            if (row[0].ToLower().Contains(input.ToLower())){
                drinkObject d = new drinkObject();
                d.name = row[0];
                d.description = row[1];
                d.brand = row[3];
                int.TryParse(row[2], out d.abv);
                results.Add(d);
            }
        }
       foreach(drinkObject d in results)
        {
            Debug.Log(d.name);
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
