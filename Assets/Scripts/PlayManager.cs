using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text guitimer;
    [SerializeField] GameObject guiTimerObj;
    public GameObject finishLine;
    [SerializeField] GameObject endUI;
    [SerializeField] TMPro.TMP_Text guiFinalTime;
    [SerializeField] Button btnGoBack;
    string endMessage = "Your final time was ";
    float timer;
    void Start()
    {
        endUI.SetActive(false);
        var btnEvent = new Button.ButtonClickedEvent();
        btnEvent.AddListener(GoToMainMenu);

        btnGoBack.onClick = btnEvent;
    }

    void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Init(GameObject finishLine) {
        this.finishLine = finishLine;
    }

    public void EndRace() {
        print("RACE ENDED");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        var endTime = timer;
        finishLine.GetComponentInChildren<Camera>().depth = 100;
        guiTimerObj.SetActive(false);
        endUI.SetActive(true);
        guiFinalTime.text = endMessage + endTime;
        var lastRecord = PlayerPrefs.GetString(CurrentLevel.CurrentLevelName);
        if (lastRecord == "") {
            PlayerPrefs.SetString(CurrentLevel.CurrentLevelName, endTime.ToString("#.000"));
            return;
        }
        var lRecordFloat = float.Parse(lastRecord);
        if (lRecordFloat > endTime) {
            PlayerPrefs.SetString(CurrentLevel.CurrentLevelName, endTime.ToString("#.000"));
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        	
		timer += Time.deltaTime;
		int seconds = (int)timer;
		guitimer.text = "" + seconds;
	
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
