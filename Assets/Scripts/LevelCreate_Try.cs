using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelCreate_Try : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private GameObject player_object;
    private bool is_testing;
    [SerializeField] Button playBtn;
    [SerializeField] TMP_InputField inputLevelName;
    private string levelName = "temp";
    void Start()
    {
        var inputEvent = new Button.ButtonClickedEvent();
        inputEvent.AddListener(TestMap);
        playBtn.onClick = inputEvent;

        var nameInputEvent = new TMP_InputField.SubmitEvent();
        nameInputEvent.AddListener(SetName);
        inputLevelName.onSubmit = nameInputEvent;
    }

    void SetName(string name) {
        print(name);
        levelName = name; 
    }

    void TestMap() {
        Save(levelName);
        CurrentLevel.CurrentLevelName = levelName + ".json";
        SceneManager.LoadScene("LevelPlay", LoadSceneMode.Single);

        if (is_testing) {
            Destroy(player_object, 0);
            is_testing = false;
            Cursor.visible = true;
        } else {
            player_object = Instantiate(player);
            is_testing = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Save(string levelName) {
        List<LevelAsset> map = new List<LevelAsset>();
        var objects = GameObject.FindGameObjectsWithTag("Block");

        foreach (var item in objects)
        {
            print(item.transform.position);
            var rot = item.GetComponentsInChildren<Transform>()[1].rotation.eulerAngles.y;
            map.Add(new LevelAsset(item.GetComponent<AssetPrefabId>().ID, item.transform.position.x, item.transform.position.z, rot));
        }

        DataHandler.Save(map, levelName);
        // print(map.ToString());
    }
}
