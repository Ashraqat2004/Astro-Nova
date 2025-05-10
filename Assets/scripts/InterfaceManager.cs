using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour

{

    public GameObject InfoText;

    void Update()
    {
        if (Input.anyKey)
        {
            InfoText.SetActive(true);
        }
        else
        {
            InfoText.SetActive(false);
        }
    }


}