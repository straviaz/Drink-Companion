using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    [SerializeField] GameObject DrinkCounter;
    [SerializeField] GameObject BACCounter;
    [SerializeField] GameObject Level;

    double BAC = 0;
    int alcoholLevel = 2;
    int alcoholVolumeLB = 24;
    String level = "";

    //-----------------------------------------------------
    // CONVERSION METHODS
    //-----------------------------------------------------

    //Convert height from imperial to metric
    double convertHeight()
    {
        float temp = PlayerPrefs.GetInt("Height") * 0.025f;
        return (double)temp;
    }

    //Convert weight from imperial to metric
    double convertWeight()
    {
        float temp = PlayerPrefs.GetInt("Weight") * 0.454f;
        return (double)temp;
    }

    //Convert alcoholVolume
    double convertVolume()
    {
        float temp = PlayerPrefs.GetFloat("AlcoholLevel") * 29.5f;
        return (double)temp;
    }

    //Convert alcoholLevel to percentage
    double convertAlcoholLevel()
    {
        float temp = PlayerPrefs.GetFloat("Volume") * 0.01f;
        return (double)temp;
    }

    //-----------------------------------------------------
    // CALCULATIONS 
    //-----------------------------------------------------

    /** 
     * Calculate the number of Standard Drink 
     * (drink volume(ml) * (alcohol content %/12.5ml)
     **/
    double standardDrink()
    {
        double temp = convertAlcoholLevel() * convertVolume();
        return temp / 12.5;
    }

    //Calculate BAC
    double calculateBAC()
    {
        double drink = standardDrink();

        //each linear equation depends on the user's weight
        if ((convertWeight()* 2.2046) < 100)
        {
            BAC = (23 / 100) * drink;
            BAC = BAC - (1 / 1000);
        } else if ((convertWeight() * 2.2046) < 120)
        {
            BAC = (27 / 1000) * drink;
        } else if ((convertWeight() * 2.2046) < 140)
        {
            BAC = 23.0 / 1000.0;
            BAC = BAC * drink;
        } else if ((convertWeight() * 2.2046) < 160)
        {
            BAC = (1 / 50) * drink;
        } else if ((convertWeight() * 2.2046) < 180) {
            BAC = (9 / 500) * drink;
        } else
        {
            BAC = (81 / 1000) * drink;
            BAC = BAC - (1 / 5000);
        }

        PlayerPrefs.SetFloat("BAC", (float)BAC);
        return BAC;
    }

    //-----------------------------------------------------
    // UI UPDATES
    //-----------------------------------------------------

    //Return the level of Intoxication
    String getIntoxicationLevel()
    {
        if( BAC < 0.02 ) //Sober
        {
            level = "0: Sober";
        } else if( BAC < 0.05 ) //Sub-Clinical 
        {
            level = "1: Sub-Clinical";
        } else if( BAC < 0.08 ) //Euphoria
        {
            level = "2: Euphoria";
        } else if( BAC < 0.10 ) //Excitement
        {
            level = "3: Excitement";
        } else if( BAC < 0.3 ) //Excitement/Confusion
        {
            level = "4: Excitement/Confusion";
        } else if( BAC < 0.40 ) //Confusion/Stuper 
        {
            level = "5: Confusion/Stupor";
        } else if(BAC < 0.50 ) //Coma
        {
            level = "6: Coma";
        } else //Death
        {
            level = "7: Death";
        }

        PlayerPrefs.SetString("Level", level);
        return level;
    }
    
    public void updateCounters()
    {

        Debug.Log("Alcohol " + PlayerPrefs.GetInt("AlcoholLevel"));
        Debug.Log("Volume " + PlayerPrefs.GetInt("Volume"));
        Debug.Log("Volume (ml) " + convertVolume());
        Debug.Log("Alcohol (%) " + convertAlcoholLevel());


        Debug.Log("Calculate BAC: " + calculateBAC() + " %");
        Debug.Log("Level: " + getIntoxicationLevel());

        //Standard Drink Counter
        double parsedDrink = standardDrink();
        DrinkCounter.GetComponent<Text>().text = parsedDrink.ToString();

        //BAC Counter
        double parsedBAC = calculateBAC();
        BACCounter.GetComponent<Text>().text = parsedBAC.ToString();

        //Level of Intoxication
        String parsedLevel = getIntoxicationLevel();
        Level.GetComponent<Text>().text = parsedLevel;
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
