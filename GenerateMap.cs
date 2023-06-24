using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMap : MonoBehaviour
{   
    // public GameObject: prefab;
    public GameObject hexPrefab;
    public int numRows = 30;
    public int numColumns = 60;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
        

        // newPlayer.AddComponent<RigidBody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMap()
{
    for (int column = 0; column < numColumns; column++)
    {
        for (int row = 0; row < numRows; row++)
        {
            Vector3 position = CalculateHexPosition(column, row);
            Instantiate(hexPrefab, position, Quaternion.identity);
        }
    }
}
 


private Vector3 CalculateHexPosition(int column, int row)
{
    // Aqui você pode implementar uma fórmula para calcular a posição de cada hexágono com base na coluna e linha.
    // Isso depende do layout hexagonal que você deseja usar (ponto a ponto, flat-top, etc.).
    // Por exemplo, suponha que você queira um layout flat-top com tamanho de hexágono fixo:
    float hexWidth = 1.0f;
    float hexHeight = 1.0f;
    float xOffset = hexWidth * 0.75f;
    float yOffset = hexHeight * 0.865f;

    float xPos = column * xOffset;
    float yPos = row * yOffset;

    // Desloque as colunas ímpares para baixo para criar o padrão hexagonal
    if (column % 2 != 0)
    {
        yPos -= yOffset * 0.5f;
    }

    return new Vector3(xPos, 0f, yPos);
}


}
