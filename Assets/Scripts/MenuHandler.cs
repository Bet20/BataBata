using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public Texture2D cursor_texture;
    public CursorMode cursor_mode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    public TMP_InputField usernameInput;
    [SerializeField]
    private GameObject usernameInputMenu;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private TMP_Text username;
    [SerializeField]
    private Button btnPlayground;
    [SerializeField] Button btnPlay;
    [SerializeField] Button btnLevelCreation;
    [SerializeField] GameObject LevelsUI;
    [SerializeField] GameObject logoBig;
    [SerializeField] GameObject logoSmall;
    [SerializeField] Button btnGoBack;
    [SerializeField] GameObject btnGoBackObj;

    private void OnMouseEnter() {
        Cursor.SetCursor(cursor_texture, hotspot, cursor_mode);
    }

    private void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, cursor_mode);
    }

    void Start()
    {
        var inputEvent = new TMP_InputField.SubmitEvent();
        inputEvent.AddListener(UpdateUsername);
        usernameInput.onEndEdit = inputEvent;

        var btnEventPlayground = new Button.ButtonClickedEvent();
        btnEventPlayground.AddListener(ChangeToPlayground);

        var btnEventPlay = new Button.ButtonClickedEvent();
        btnEventPlay.AddListener(ChangeToPlay);

        var btnEventGoBack = new Button.ButtonClickedEvent();
        btnEventGoBack.AddListener(ChangeToMenu);

        var btnEventLevelCreation = new Button.ButtonClickedEvent();
        btnEventLevelCreation.AddListener(ChangeToLevelCreation);

        btnPlayground.onClick = btnEventPlayground;
        btnPlay.onClick = btnEventPlay;
        btnGoBack.onClick = btnEventGoBack;
        btnLevelCreation.onClick = btnEventLevelCreation;
    }

    void ChangeToMenu() {
        LevelsUI.SetActive(false);
        logoBig.SetActive(true);
        logoSmall.SetActive(false);
        mainMenu.SetActive(true);
        btnGoBackObj.SetActive(false);
    }

    void ChangeToPlay() {
        mainMenu.SetActive(false);
        logoBig.SetActive(false);
        logoSmall.SetActive(true);
        LevelsUI.SetActive(true);
        btnGoBackObj.SetActive(true);
    }

    void ChangeToPlayground() {
        SceneManager.LoadScene("LevelTestChamber", LoadSceneMode.Single);
    }

    void ChangeToLevelCreation() {
        SceneManager.LoadScene("LevelCreation", LoadSceneMode.Single);
    }


    public void UpdateUsername(string input) {
        Singleton.username = input;
        print(input);
        usernameInputMenu.SetActive(false);
        mainMenu.SetActive(true);
        username.text = "Hello " + input;
    }
}

public class Singleton : MonoBehaviour {
    public static string username;
    public static Singleton Instance { get; private set; }
    private void Awake() {
        if (Instance!=null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }
}