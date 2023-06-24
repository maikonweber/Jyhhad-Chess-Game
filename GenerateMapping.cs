using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HexPrefab;
    public int numRows = 30;
    public int numColumns = 60;
    
    private Hex[,] Hexes;

    private Dictionary<Hex, GameObject> hexToGameObjectMap;

    [System.NonSerialized] public bool AllowWrapEastWest = true;
    [System.NonSerialized] public bool AllowWrapNortSouth = false;
   
    // Update is called once per frame
   
    virtual public void GenerateMap() {
    Hexes = new Hex[numRows, numColumns];
    hexToGameObjectMap = new Dictionary<Hex, GameObject>();
    
    for(int column = 0; column < numColumns; column++) {
        for(int row = 0; row < numRows; row++){
            Hex h = new Hex(column, row);
            h.Elavation = -1f;

            
            GameObject hexGo = (GameObject)Instantiate(
                HexPrefab,
                h.Position(),
                new Quaternion(1.0f, 0, 0, 1),
                this.transform
            );
            

            hexToGameObjectMap[h] = hexGo;

            hexGo.name = string.Format("Hex: {0}, {1}, {2}", column, row, h.Elavation);
            var collission = hexGo.AddComponent<BoxCollider>();

        }
    }


    }

    // public Vector3 GetHexPosition(int q, int r)
    // {
    //     Hex hex = GetHexAt(q, r);
    //     return GetHexPosition(hex);
    // }

    public Hex GetHexAt(int x, int y) {
    if(Hexes == null)
    {
        Debug.LogError("Hexes array not yed instantiated");
        return null;
    }


        if(AllowWrapEastWest) 
        {
            x = x % numColumns;
            if(x < 0)
            {
                x += numColumns;
            }
        }

        if (AllowWrapNortSouth) {
            y = y % numRows;
            if(y < 0) 
            {
                 y += numRows;
            }
        }

    return Hexes[x, y];
    }
}
