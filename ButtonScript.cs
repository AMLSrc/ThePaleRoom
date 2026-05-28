using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public void MMButton()
    {

        SceneManager.LoadScene("MainMenu");

    }
    
    public void HButton()
    {

        SceneManager.LoadScene("Help");

    }
    
    public void PButton()
    {

        SceneManager.LoadScene("Test");

    }

}
