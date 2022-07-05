using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    //
    [SerializeField] private Vector2 sizeMap = new Vector2(10f, 10f);
    [SerializeField] private GameObject tileFloorPrefab = null;

    //Prefab des éléments qui composent le sol.
    Vector3 planePrefabSize = new Vector3();

    //List des éléments qui composent le sol.
    private List<List<GameObject>> tileList = new List<List<GameObject>>();

    //Parent des éléments de la carte de jeu.
    private GameObject mapMagazine = null;

    private bool isInTileSelection = false;

    GameObject previousTile = null;

    // Start is called before the first frame update
    void Start()
    {
        mapMagazine = new GameObject("Map");
        tileFloorPrefab = Instantiate(tileFloorPrefab);

        planePrefabSize = tileFloorPrefab.GetComponent<MeshRenderer>().bounds.size;
        Destroy(tileFloorPrefab);

        GenerateMap(sizeMap);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateMap(Vector2 pSizemap)
    {
        for (int x = 0; x < pSizemap.x; x++)
        {
            tileList.Add(new List<GameObject>());
            for (int z = 0; z < pSizemap.y; z++)
            {
                Vector3 tmpPos = Vector3.zero;
                tmpPos.x += x * tileFloorPrefab.GetComponent<MeshRenderer>().bounds.size.x;
                tmpPos.y = 0f;
                tmpPos.z += z * tileFloorPrefab.GetComponent<MeshRenderer>().bounds.size.z;

                tileList[x].Add(Instantiate(tileFloorPrefab, mapMagazine.transform));
                tileList[x][tileList[x].Count - 1].transform.localPosition = tmpPos;
            }
        }
        previousTile = tileList[0][0];
    }

    public List<List<GameObject>> GetMap()
    {
        return tileList;
    }

    public GameObject GetTileByPosition(Vector3 pPosition)
    {
        return tileList[(int)((pPosition.x + planePrefabSize.x / 2) / planePrefabSize.x) ] [(int)((pPosition.z + planePrefabSize.x / 2) / planePrefabSize.z )];
    }

    public void ColorTile(GameObject pGameObject)
    {
        if (previousTile != null)
        {
            if (previousTile != pGameObject)
            {
                previousTile.GetComponent<MeshRenderer>().material.color = Color.white;
                pGameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                previousTile = pGameObject;
            }
        }
    }
}
