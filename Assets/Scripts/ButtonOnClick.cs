using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnClick : MonoBehaviour
{
    // Quit ��ư
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Quit Application");
    }
}
