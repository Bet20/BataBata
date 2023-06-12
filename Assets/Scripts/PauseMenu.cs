using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] Button btnGoToMenu;
    bool isActive = false;
    void Start()
    {
        var eventBtn = new Button.ButtonClickedEvent();
        eventBtn.AddListener(GoToMainMenu);

        btnGoToMenu.onClick = eventBtn;
        ui.SetActive(false);
    }

    void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            ui.SetActive(!isActive);
        }
        if (ui.activeSelf == false && isActive == true) {
            Time.timeScale = 1;
        } else if (ui.activeSelf == true && isActive == false) {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        isActive = ui.activeSelf;
    }
}
