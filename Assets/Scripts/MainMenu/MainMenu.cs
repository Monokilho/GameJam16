using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {


    public EventSystem eventsystem;
    public GameObject defaultButton;

    public void startGame() {

        Application.LoadLevel(1);

    }


    public void exitGame() {

        Application.Quit();

    }

    void Start() {
        Time.timeScale = 1f;
        eventsystem.SetSelectedGameObject(defaultButton, null);
    }
}
