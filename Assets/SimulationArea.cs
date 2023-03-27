using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationArea : MonoBehaviour
{
    public float size;
    public Transform mapSprite;


    public GameObject flowerPrefab;

    public int amountOfFlowers;


    private Vector2 center;

    public static SimulationArea _instance;


    public static List<GameObject> flowersObj = new List<GameObject>();

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public static Bounds mapBounds;

    void Start()
    {
        center = Camera.main.transform.position;
        mapSprite.localScale = new Vector3(size, size, 0);

        spawnFlowers(amountOfFlowers);

        mapBounds.center = center;
        mapBounds.size = new Vector3(size,size,5);

    }

   

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(center, new Vector3(size,size,1));
    }


    void spawnFlowers(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            flowersObj.Add(Instantiate(flowerPrefab, new Vector3(Random.Range(-size / 2, size / 2), Random.Range(-size / 2, size / 2),1), Quaternion.identity));
        }

    }
    

   
}
