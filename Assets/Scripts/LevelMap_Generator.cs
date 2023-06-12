using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap_Generator : MonoBehaviour
{
    private List<LevelAsset> blocks;
    [SerializeField]
    private LevelCreator_PrefabsDB db;
    [SerializeField]
    private GameObject player;
    private bool isEditing;
    [SerializeField] PlayManager pm;
    // Start is called before the first frame update

    
    void Start()
    {
        Time.timeScale = 1;
        LoadMap(CurrentLevel.CurrentLevelName);
        foreach(var block in blocks) {
            var blockIndex = db.objData.FindIndex(data => data.ID == block.ID);
            print(block.ID);
            GameObject b = Instantiate(db.objData[blockIndex].Prefab);
            b.transform.position = new Vector3(block.x, b.transform.position.y, block.z);

            print(block.rotation); 

            b.GetComponentsInChildren<Transform>()[1].rotation = Quaternion.Euler(b.transform.rotation.x, block.rotation, b.transform.rotation.z);
            if (block.ID == 0) {
                GameObject obj = Instantiate(player);
                obj.transform.position = b.GetComponentsInChildren<Transform>()[2].position;
                obj.transform.rotation = b.GetComponentsInChildren<Transform>()[2].rotation;
                obj.GetComponentInChildren<Movement>().playManager = pm;
            }

            if (block.ID == 9) {
                pm.finishLine = b;
            }
        }
    }

    float assert_rotations(float rot) {
        if (rot > 10 && rot < 90) return 90;
        if (rot < 180) return 180;
        if (rot < 270) return 270;
        return 0;
    }

    public void LoadMap(string mapName) {
        switch (mapName) {
            case "level_1":
            break;
            case "level_2":
            break;
            case "level_3":
            break;
            case "level_4":
            break;
            case "level_5":
            break;
        }

        blocks = DataHandler.Load(mapName);
    }

    public void SetMode(bool editing) {
        isEditing = editing;
    }

}
