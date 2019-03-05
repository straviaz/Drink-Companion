using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    public void OnClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
