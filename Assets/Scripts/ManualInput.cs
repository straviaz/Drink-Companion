using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualInput : MonoBehaviour
{
    [SerializeField] GameObject AlcoholPercentageInput;
    [SerializeField] GameObject DrinkVolumeInput;
    private bool saveData = false;
    
    //Parse user inputs 
    public void parseInputs()
    {
        //alcohol percentage
        float parsedAlcohol;
        float.TryParse(AlcoholPercentageInput.GetComponent<InputField>().text, out parsedAlcohol);
        Debug.Log("alcohol: " + parsedAlcohol);

        //drink volume
        float parsedVolume;
        float.TryParse(DrinkVolumeInput.GetComponent<InputField>().text, out parsedVolume);
        Debug.Log("volume: " + parsedVolume);

        if ( parsedAlcohol > 0 && parsedVolume > 0 )
        {
            saveData = true;
            Debug.Log("Good Data");
            PlayerPrefs.SetFloat("AlcoholLevel", parsedAlcohol);
            PlayerPrefs.SetFloat("Volume", parsedVolume);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Bad Data");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
