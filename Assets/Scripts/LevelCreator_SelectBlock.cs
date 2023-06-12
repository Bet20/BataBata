using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelCreator_SelectBlock : MonoBehaviour
{
    int selected_block = 0;
    [SerializeField] private Button[] blockButtons;
    [SerializeField] private LevelCreator_Spawner spawner;
    private void Awake() {
        int i = 0;
        foreach( Button btn in blockButtons ) {
            int j = i;
            btn.onClick.AddListener(() => {SelectBlock(j);});
            i++;
        }
    }

    private void SelectBlock(int index) {
        spawner.SelectBlock(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
