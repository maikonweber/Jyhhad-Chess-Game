using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    
    
    void Start()
    {
        score = 0;
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IncrementeScore();
        }

    void IncrementeScore() 
    {
        score++;
        Debug.Log("Score: " + score);
    }

    }
}
