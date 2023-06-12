using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEntry : MonoBehaviour
{
    private string _levelName;
    private string _author;
    private string _time;
    [SerializeField] TMP_Text[] fields;
    [SerializeField] Button playBtn;
    void Start()
    {
        var play = new Button.ButtonClickedEvent();
        play.AddListener(Play);

        playBtn.onClick = play;
    }

    private void Play() {
        CurrentLevel.CurrentLevelName = _levelName;
        SceneManager.LoadScene("LevelPlay", LoadSceneMode.Single);
    }

    public void Init(string levelName, string author) {
        _levelName = levelName;
        _author = author;
        var time = PlayerPrefs.GetString(levelName);
        if (time == "No Name") {
            time = "Not Completed";
        }
        fields[0].text = levelName.Replace(".json", "");
        fields[1].text = author;
        fields[2].text = time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
