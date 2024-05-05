using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBulder : MonoBehaviour
{
    public Texture2D[] maps;
    public GameObject wallPrefab;
    public GameObject gemPrefab;
    public GameObject zoombiePrefab;

    private Texture2D selectedMap;

    private List<Vector3> openPositions = new List<Vector3>();

    private Color wallColor = Color.black;

    public static MapBulder instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        GenerateNewMap();
        GenerateGems();
    }

    public void GenerateNewMap()
    {
        openPositions.Clear();

        selectedMap = maps[Random.Range(0, maps.Length)];

        for (int x = 0; x < selectedMap.width; x++) {
            for (int y = 0; y < selectedMap.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = selectedMap.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            openPositions.Add(new Vector3(x, 0, y));
            return;
        }

        if (pixelColor == wallColor)
        {
            Instantiate(wallPrefab, new Vector3(x, 0, y), Quaternion.identity, transform);
        }

    }


    private void GenerateZoombies()
    {

    }

    private void GenerateGems()
    {
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, openPositions.Count);
            Instantiate(gemPrefab, openPositions[index], Quaternion.identity);
            openPositions.RemoveAt(index);
        }


    }



}
