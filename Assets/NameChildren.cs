using System;
using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NameChildren : MonoBehaviour
{
    public int password;

    public int enteredNumber;

    public TextMeshProUGUI enteredNumberUGUI;

    public TextMeshProUGUI successUGUI;
    public TextMeshProUGUI failUGUI;
    
    public bool stopInput = false;

    public void ButtonPressed(int Number)
    {
        if (stopInput)
            return;
        
        enteredNumber *= 10;
        enteredNumber += Number;
        enteredNumberUGUI.text = enteredNumber.ToString();

        if (enteredNumber > 1000)
        {
            ValidateNumber();
        }
    }

    public void ValidateNumber()
    {

        if (enteredNumber == password)
        {
            Success?.Invoke();
            stopInput = true;
        }
        else
        {
            enteredNumber = 0;
            enteredNumberUGUI.text = "";
            Fail?.Invoke();
        } 
        
        StartCoroutine(ClearResult());
        
    }

    public void CLOSEGAME()
    {
        Application.Quit();
    }

    IEnumerator ClearResult()
    {
        yield return new WaitForSeconds(5f);
        successUGUI.gameObject.SetActive(false);
        failUGUI.gameObject.SetActive(false);
        
    }

    [Button]
    // Update is called once per frame
    void Name()
    {
        int number = 0;
        foreach (Transform child in transform)
        {
            child.gameObject.name = number.ToString();
            child.GetComponentInChildren<TextMeshProUGUI>().text = number.ToString();
            
            number++;
            
        }
        
    }

    public UnityEvent Success;
    public UnityEvent Fail;
}
