using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update
    string directory;
    DirectoryInfo info;
    [SerializeField] GameObject list;
    [SerializeField] LevelEntry levelEntry;
    void Start()
    {
        // directory = "./Assets/DefaultLevels/";
        // info = new DirectoryInfo(directory);
        // var fileInfo = info.GetFiles();
        // foreach (FileInfo file in fileInfo) {
        //     print(file.Extension);
        //     if (file.Extension == ".json") {
        //         var l = Instantiate(levelEntry);
        //         l.Init(file.Name, "BataBata");
        //         l.transform.parent = list.transform;
        //         print(file.Name);
        //     }
        // }

        directory = Application.persistentDataPath + "/";
        info = new DirectoryInfo(directory);
        var fileInfo = info.GetFiles();

        var i = 0;
        foreach (FileInfo f in fileInfo) {
            if (f.Extension == ".json") {
                i++;
            }
        }
        if (i == 0) {
            var level_1 =  @"
           { 
    ""Items"": [
        {
            ""ID"": 0,
            ""x"": -8.0,
            ""z"": -44.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": -40.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": -36.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": -32.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 2,
            ""x"": -8.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 3,
            ""x"": -4.0,
            ""z"": -28.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 3,
            ""x"": 4.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 3,
            ""x"": 4.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 3,
            ""x"": 4.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 8.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 8.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 8.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 12.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 12.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 12.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 8.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 12.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 20.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 20.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 20.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 20.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 24.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 24.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 28.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 28.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 24.0,
            ""z"": -44.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 28.0,
            ""z"": -44.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 20.0,
            ""z"": -44.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 24.0,
            ""z"": -48.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 28.0,
            ""z"": -48.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 32.0,
            ""z"": -44.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 5,
            ""x"": 32.0,
            ""z"": -48.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 5,
            ""x"": 32.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 5,
            ""x"": 36.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 5,
            ""x"": 36.0,
            ""z"": -48.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 5,
            ""x"": 40.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 5,
            ""x"": 40.0,
            ""z"": -48.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 3,
            ""x"": 36.0,
            ""z"": -44.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": 44.0,
            ""z"": -44.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": 48.0,
            ""z"": -44.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 2,
            ""x"": 52.0,
            ""z"": -44.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": 52.0,
            ""z"": -40.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": 52.0,
            ""z"": -36.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": 52.0,
            ""z"": -32.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": 52.0,
            ""z"": -28.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 2,
            ""x"": 52.0,
            ""z"": -24.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": 48.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": 44.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 9,
            ""x"": 40.0,
            ""z"": -24.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 4,
            ""x"": 36.0,
            ""z"": -8.0,
            ""rotation"": 0.0
        }
    ]
}";
            var level_2 = @"
            {
    ""Items"": [
        {
            ""ID"": 0,
            ""x"": 4.0,
            ""z"": -52.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": 4.0,
            ""z"": -48.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": 4.0,
            ""z"": -44.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": 4.0,
            ""z"": -40.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 2,
            ""x"": 4.0,
            ""z"": -36.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 2,
            ""x"": 8.0,
            ""z"": -36.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 2,
            ""x"": 8.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 4.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 4.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 8.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 4.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 8.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 12.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 12.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 12.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 12.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 8.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": -40.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": 12.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": 16.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": 20.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": 24.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": 28.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 5,
            ""x"": 32.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 32.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 36.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 36.0,
            ""z"": -32.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 36.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 32.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 28.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 28.0,
            ""z"": -28.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 32.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 28.0,
            ""z"": -24.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 28.0,
            ""z"": -20.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 32.0,
            ""z"": -20.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 36.0,
            ""z"": -20.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": 36.0,
            ""z"": -24.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": 40.0,
            ""z"": -24.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 2,
            ""x"": 44.0,
            ""z"": -24.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": 44.0,
            ""z"": -28.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": 44.0,
            ""z"": -32.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 2,
            ""x"": 44.0,
            ""z"": -36.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 9,
            ""x"": 48.0,
            ""z"": -36.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 4,
            ""x"": 24.0,
            ""z"": -16.0,
            ""rotation"": 0.0
        }
    ]
}
            ";
            var level_3 = @"
{
    ""Items"": [
        {
            ""ID"": 0,
            ""x"": -12.0,
            ""z"": 0.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": 0.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 2,
            ""x"": -4.0,
            ""z"": 0.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 9,
            ""x"": -4.0,
            ""z"": -8.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 5,
            ""x"": -4.0,
            ""z"": -4.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": -4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -12.0,
            ""z"": -4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -16.0,
            ""z"": -4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -20.0,
            ""z"": -4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 2,
            ""x"": -24.0,
            ""z"": -4.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 2,
            ""x"": -24.0,
            ""z"": -8.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 2,
            ""x"": -20.0,
            ""z"": -8.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": -20.0,
            ""z"": -12.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 2,
            ""x"": -20.0,
            ""z"": -16.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 5,
            ""x"": -16.0,
            ""z"": -16.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 5,
            ""x"": -12.0,
            ""z"": -16.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 5,
            ""x"": -8.0,
            ""z"": -16.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 2,
            ""x"": -4.0,
            ""z"": -16.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -16.0,
            ""z"": 12.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": -4.0,
            ""z"": -12.0,
            ""rotation"": 270.0
        }
    ]
}
            ";
            var level_4 = @"
            {
    ""Items"": [
        {
            ""ID"": 0,
            ""x"": -32.0,
            ""z"": 8.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -28.0,
            ""z"": 8.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -24.0,
            ""z"": 8.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -20.0,
            ""z"": 8.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -16.0,
            ""z"": 8.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": 8.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -4.0,
            ""z"": 8.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 2,
            ""x"": 0.0,
            ""z"": 8.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 2,
            ""x"": -4.0,
            ""z"": 4.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 2,
            ""x"": 0.0,
            ""z"": 4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": 0.0,
            ""z"": 0.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": 0.0,
            ""z"": -4.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": -4.0,
            ""z"": -8.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": -8.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 5,
            ""x"": -4.0,
            ""z"": 0.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 5,
            ""x"": -4.0,
            ""z"": -4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 5,
            ""x"": -8.0,
            ""z"": 4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 5,
            ""x"": -8.0,
            ""z"": 0.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 5,
            ""x"": -8.0,
            ""z"": -4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 5,
            ""x"": -12.0,
            ""z"": 4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 5,
            ""x"": -12.0,
            ""z"": 4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 5,
            ""x"": -12.0,
            ""z"": 0.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 5,
            ""x"": -12.0,
            ""z"": -4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 2,
            ""x"": -12.0,
            ""z"": -8.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -12.0,
            ""z"": -12.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 2,
            ""x"": -12.0,
            ""z"": -16.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": -16.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -4.0,
            ""z"": -16.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": 0.0,
            ""z"": -16.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": 4.0,
            ""z"": -16.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": 8.0,
            ""z"": -16.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 9,
            ""x"": 12.0,
            ""z"": -16.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -16.0,
            ""z"": 8.0,
            ""rotation"": 0.0
        }
    ]
}
            ";
            var level_5 = @"
            {
    ""Items"": [
        {
            ""ID"": 9,
            ""x"": 20.0,
            ""z"": 12.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 4,
            ""x"": 20.0,
            ""z"": 8.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": 8.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 4,
            ""x"": 16.0,
            ""z"": 4.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 4,
            ""x"": 20.0,
            ""z"": 4.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 5,
            ""x"": 12.0,
            ""z"": 8.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 5,
            ""x"": 12.0,
            ""z"": 4.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 4,
            ""x"": 8.0,
            ""z"": 8.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 4,
            ""x"": 8.0,
            ""z"": 4.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 4,
            ""x"": 0.0,
            ""z"": 8.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 4,
            ""x"": 4.0,
            ""z"": 4.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 4,
            ""x"": 4.0,
            ""z"": 8.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 3,
            ""x"": 8.0,
            ""z"": 4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 4,
            ""x"": 0.0,
            ""z"": 4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 4,
            ""x"": 0.0,
            ""z"": 0.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 4,
            ""x"": 4.0,
            ""z"": 0.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 2,
            ""x"": 0.0,
            ""z"": -4.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -4.0,
            ""z"": -4.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": -4.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -12.0,
            ""z"": -4.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -16.0,
            ""z"": -4.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -20.0,
            ""z"": -4.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 2,
            ""x"": -24.0,
            ""z"": -4.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -24.0,
            ""z"": -8.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": -24.0,
            ""z"": -12.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 3,
            ""x"": 0.0,
            ""z"": -12.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 1,
            ""x"": -24.0,
            ""z"": -16.0,
            ""rotation"": 90.0
        },
        {
            ""ID"": 2,
            ""x"": -24.0,
            ""z"": -20.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": -20.0,
            ""z"": -20.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 0,
            ""x"": -16.0,
            ""z"": -20.0,
            ""rotation"": 0.0
        },
        {
            ""ID"": 1,
            ""x"": -12.0,
            ""z"": -20.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -8.0,
            ""z"": -20.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -4.0,
            ""z"": -20.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 2,
            ""x"": 0.0,
            ""z"": -20.0,
            ""rotation"": 180.0
        },
        {
            ""ID"": 1,
            ""x"": -44.0,
            ""z"": -12.0,
            ""rotation"": 270.0
        },
        {
            ""ID"": 1,
            ""x"": 0.0,
            ""z"": -16.0,
            ""rotation"": 270.0
        }
    ]
}
            ";
            DataHandler.Save(level_1, "Level_1");
            DataHandler.Save(level_2, "Level_2");
            DataHandler.Save(level_3, "Level_3");
            DataHandler.Save(level_4, "Level_4");
            DataHandler.Save(level_5, "Level_5");
            directory = Application.persistentDataPath + "/";
            info = new DirectoryInfo(directory);
            fileInfo = info.GetFiles();
        }


        foreach (FileInfo file in fileInfo) {
             print(file.Extension);
            if (file.Extension == ".json") {
                i++;
            var l = Instantiate(levelEntry);
            l.Init(file.Name, "You");
            l.transform.parent = list.transform;
            print(file.Name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
