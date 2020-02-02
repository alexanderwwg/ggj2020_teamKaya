using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButton_Script : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCredits()
    {
        AudioStatics.PlayOneShotAttached("event:/UI/ui_click", this.gameObject);
        credits.SetActive(true);
    }

    public void HideCredits()
    {
        AudioStatics.PlayOneShotAttached("event:/UI/ui_click", this.gameObject);
        credits.SetActive(false);
    }

    public void ShowButtons()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
    }

    public void LoadScene(string scene)
    {
        AudioStatics.PlayOneShotAttached("event:/UI/ui_click", this.gameObject);
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        AudioStatics.PlayOneShotAttached("event:/UI/ui_click", this.gameObject);
        Application.Quit();
    }
}
