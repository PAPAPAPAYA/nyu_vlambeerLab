using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int spawnerCount = 1;
     public int globalFloorCount = 0;
    static public GameManager me;
    // Start is called before the first frame update
    void Start()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        print(spawnerCount);
        print(globalFloorCount);
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
            globalFloorCount = 0;
            spawnerCount = 1;
        }
    }
}
