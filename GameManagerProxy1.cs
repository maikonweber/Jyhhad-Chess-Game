using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDebuger : MonoBehaviour
{
    private GameManager gameManager;
    private HexGenerate hexGenerate;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        hexGenerate = FindObjectOfType<HexGenerate>();
        Debug.Log("Current Game State: " + gameManager.currentState);
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0)) {
         LogGameState();
        }
    }
    public void LogGameState()
    {
        Debug.Log("Hex Generate" + hexGenerate);
        Debug.Log("Current Game State: " + gameManager.currentState);
    }
}
