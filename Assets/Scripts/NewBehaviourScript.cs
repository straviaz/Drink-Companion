using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject HeightBoxFT;
    [SerializeField] GameObject HeightBoxIN;
    [SerializeField] GameObject WeightBox;
    [SerializeField] GameObject AgeBox;
    [SerializeField] GameObject SexBox;
    [SerializeField] GameObject NextScene;
    [SerializeField] GameObject ThisScene;
    private bool saveData = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void updatePrefs()
    {
        //try to parse an age
        int parsedAge;
        int.TryParse(AgeBox.GetComponent<InputField>().text, out parsedAge);

        //try to parse an age
        int parsedWeight;
        int.TryParse(WeightBox.GetComponent<InputField>().text.ToString(), out parsedWeight);

        //parse out height in both FT and IN
        int parsedHeightFT;
        int parsedHeightIN;
        int.TryParse(HeightBoxFT.GetComponent<InputField>().text, out parsedHeightFT);
        int.TryParse(HeightBoxIN.GetComponent<InputField>().text, out parsedHeightIN);
        //convert height in inches
        int finalHeight = (parsedHeightFT * 12) + parsedHeightIN;
        Debug.Log(AgeBox.GetComponent<InputField>().text + "  " + WeightBox.GetComponent<InputField>().text + "   ");
        Debug.Log(parsedAge + "  " + parsedWeight + "   " + finalHeight + "  ");

        if (parsedAge> 21 && parsedAge < 120 && finalHeight >0 && parsedWeight >0)
        {
            saveData = true;
            Debug.Log("Good Data");
            SetAgePref(parsedAge);
            SetHeightPref(finalHeight);
            SetWeightPref(parsedWeight);
            PlayerPrefs.Save();
            NextScene.SetActive(true);
            ThisScene.SetActive(false);
        }
        else
        {
            Debug.Log("Bad Data");
        }
        
    }

    public void SetAgePref(int age)
    {
        PlayerPrefs.SetInt("Age", age);
    }

    public void SetWeightPref(int weight)
    {
        PlayerPrefs.SetInt("Weight", weight);
    }

    public void SetHeightPref(int height)
    {
        PlayerPrefs.SetInt("Height", height);
    }

    public void SetSexPref(string sex)
    {
        PlayerPrefs.SetString("Sex", sex);
    }
}
