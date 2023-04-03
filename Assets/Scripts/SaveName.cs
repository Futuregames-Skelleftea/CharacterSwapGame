using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveName : MonoBehaviour
{
    public TMP_InputField inputField;
    public void Save()
    {
        PlayerPrefs.SetString("Name", inputField.text);
        Debug.Log("Name Saved");
    }

    public void Start(){
        if(PlayerPrefs.HasKey("Name")){
            inputField.text = PlayerPrefs.GetString("Name");
        }
    }
}
