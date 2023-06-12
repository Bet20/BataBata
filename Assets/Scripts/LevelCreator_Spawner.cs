using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreator_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject cursor, cellIndicator;
    [SerializeField]
    private LevelCreator_Input input;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private LevelCreator_PrefabsDB db;
    private int selected_block = -1;
    [SerializeField]
    private GameObject gridViz;
    private GameObject placeholderItem;
    [SerializeField]
    private Material translucentMaterial;
    private float rotation = 0f;
    private List<GameObject> map = new List<GameObject>();
    private bool hasSpawn = false;
    [SerializeField]
    private Toggle toggleHasSpawn;
    [SerializeField]
    private Toggle toggleHasEnd;

    public void StartEditing(int ID) {
        StopEditing();
        selected_block = db.objData.FindIndex(data => data.ID == ID);
        if (selected_block < 0) {
            Debug.LogError($"No id found {ID}");
            return;
        }
        gridViz.SetActive(true);
        cellIndicator.SetActive(true);
        input.OnClicked += PlaceBlock;
        input.OnRightClicked += DeleteBlock;
        input.OnExit += StopEditing;
    }

	private void DeleteBlock()
	{
        Vector3 mousePos = input.GetMapPos();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);

		// throw new NotImplementedException();
	}

	private void PlaceBlock() {
        if (input.isHoverUI() || selected_block == 0 && hasSpawn) return;
        if (selected_block == 0 && !hasSpawn) {
            hasSpawn = true;
            toggleHasSpawn.isOn = true;
        };
        Vector3 mousePos = input.GetMapPos();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);
        GameObject gameObject = Instantiate(db.objData[selected_block].Prefab);
        Debug.Log(gameObject);
        gameObject.transform.position = grid.CellToWorld(gridPosition);
        gameObject.GetComponentInChildren<MeshFilter>().transform.rotation = Quaternion.Euler(0, rotation, 0);
        
        // var go = gameObject.GetComponentInChildren<MeshFilter>().transform.rotation;
        // gameObject.GetComponentInChildren<MeshFilter>().transform.rotation = Quaternion.Euler(go.x, 0, rotation);
    }

    void Start()
    {
        selected_block = 0;
        SelectBlock(selected_block);
    }

	private void StopEditing()
	{
        selected_block = -1;
		gridViz.SetActive(false);
        cellIndicator.SetActive(false);
        input.OnClicked -= PlaceBlock;
        input.OnExit -= StopEditing;
	}

	// Update is called once per frame
	void Update()
    {
        if (selected_block < 0 || input.isHoverUI()) {
            return;
        }
        Vector3 mousePos = input.GetMapPos();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
        placeholderItem.transform.position = grid.CellToWorld(gridPosition);

        if (Input.GetKeyDown(KeyCode.R)) {
            MeshFilter obj = placeholderItem.GetComponentInChildren<MeshFilter>();
            rotation = (rotation + 90) % 360;
            placeholderItem.GetComponentInChildren<MeshFilter>().transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }

    public void SelectBlock(int index) {
        StartEditing(index);
        Destroy(placeholderItem);
        placeholderItem = Instantiate(db.objData[index].Prefab);
        placeholderItem.tag = "NotBlock";
        placeholderItem.GetComponentInChildren<MeshFilter>().GetComponent<Renderer>().material = translucentMaterial;
    }
}
