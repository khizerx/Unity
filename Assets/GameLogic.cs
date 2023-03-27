using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject hive;
    public GameObject bee;
    private Transform _hive;
    private bool isHivePlaced = false;

    [HideInInspector]
    public List<GameObject> bees = new List<GameObject>();
    public static GameLogic _instance;

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





    void Start()
    {
        _hive = Instantiate(hive.transform, Camera.main.ScreenToWorldPoint(Input.mousePosition),Quaternion.identity);     
    }

    void Update()
    {
        if (!isHivePlaced)
        {
            _hive.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1);
            if (Input.GetMouseButtonDown(0))
            {             
                isHivePlaced = true;

                for (int i = 0; i < 4; i++)
                {
                   bees.Add(Instantiate(bee, _hive.position + new Vector3(Random.Range(-3,3),Random.Range(-3,3),0),Quaternion.identity));
                    bees[i].GetComponent<Bee>().SetHive(_hive.transform);
                }

                _hive = null;
         
            }
        }
    }
}
