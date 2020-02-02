using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel_Script : MonoBehaviour
{
    public GameObject WinText;
    public GameObject LoseText;
    // Start is called before the first frame update
    void Start()
    {
        WinText.SetActive(false);
        LoseText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAwake()
    {
        WinText.SetActive(false);
        LoseText.SetActive(false);
    }

    public void EndWin()
    {
        WinText.SetActive(true);
    }

    public void EndLose()
    {
        LoseText.SetActive(true);
    }

    public void ClickButton(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
