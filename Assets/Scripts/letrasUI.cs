using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers
using UnityEngine.SceneManagement;

public class letrasUI : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {



    }
    public void OnButtonPressJugar()
    {
        SceneManager.LoadScene("Juego");
        Time.timeScale = 1.0f;

    }
    public void OnButtonPressGimnasio()
    {
        SceneManager.LoadScene("Gimnasio");
        Time.timeScale = 1.0f;

    }
    public void OnButtonPressExit()
    {

        SceneManager.LoadScene("Start");

    }
    public void OnButtonPressCredits()
    {

        SceneManager.LoadScene("Creditos");

    }
    public void OnButtonPressExitGame()
    {

        Application.Quit();

    }
}
