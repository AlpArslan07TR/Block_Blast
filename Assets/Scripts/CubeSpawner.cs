using UnityEngine;
using DG.Tweening;
using System.Linq;

public class CubeSpawner : MonoBehaviour
{
    public GameObject redCubePrefab;
    public GameObject greenCubePrefab;
    public GameObject blueCubePrefab;
    public GameObject yellowCubePrefab;
    public Transform[] tiles; // Griddeki tile'lar

    private GameObject[] cubes;
    private Transform submitArea;
    private int maxCubes = 16;

    void Start()
    {
        submitArea = GameObject.Find("SubmitArea").transform;
        SpawnCubes();
    }

    void SpawnCubes()
    {
        GameObject[] cubePrefabs = { redCubePrefab, greenCubePrefab, blueCubePrefab, yellowCubePrefab };
        int cubesPerColor = 3;
        int totalCubes = Mathf.Min(maxCubes, cubesPerColor * cubePrefabs.Length);
        cubes = new GameObject[totalCubes];

        int index = 0;
        foreach (GameObject prefab in cubePrefabs)
        {
            for (int i = 0; i < cubesPerColor; i++)
            {
                cubes[index++] = prefab;
            }
        }

        // Shuffle cubes
        System.Random rng = new System.Random();
        cubes = cubes.OrderBy(x => rng.Next()).ToArray();

        for (int i = 0; i < totalCubes; i++)
        {
            Vector3 spawnPosition = tiles[i].position;
            GameObject cube = Instantiate(cubes[i], spawnPosition, Quaternion.identity);
            cube.GetComponent<Cube>().SetTileIndex(i);

            // Önündeki küp kontrolü
            if (i > 0 && tiles[i - 1].transform.childCount > 0)
            {
                cube.GetComponent<Cube>().SetInteractive(false);
            }
            else
            {
                cube.GetComponent<Cube>().SetInteractive(true);
            }
        }
    }
}
