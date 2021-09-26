using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMenu : MonoBehaviour
{
     public GameObject Menu;
     public GameObject Level;
     public GameObject How;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(true);
        Level.SetActive(false);
        How.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MenuButton()
    {
        Menu.SetActive(true);
        Level.SetActive(false);
        How.SetActive(false);
    }
    public void LevelButton()
    {
        Menu.SetActive(false);
        Level.SetActive(true);
        How.SetActive(false);
    }
    public void HowButton()
    {
        Menu.SetActive(false);
        Level.SetActive(false);
        How.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
