using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

class ChaseController : MonoBehaviour
{
    public static ChaseController _instance;
    public float detectionRange;
    public GameObject[] birds;

    [Header("UI")]
    public Transform alertPrefab;
    public Transform UI_Holder;





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


    

    public Transform[] BeesInRange(Transform chaser)
    {
        List<Transform> _beesInRange = new List<Transform>();

        foreach (GameObject b in GameLogic._instance.bees)
        {
            if (Vector2.Distance(chaser.position, b.transform.position) < detectionRange)
            {
                _beesInRange.Add(b.transform);
            }
        }

        if (_beesInRange.Count == 0)
        {
            return null;
        }

        return _beesInRange.ToArray();
    }

    public Transform closestObject(Vector3 origin,Transform[] objects)
    {
        float minDist = Mathf.Infinity;
        Transform tMin = null;

        foreach (Transform t in objects)
        {
            float dist = Vector3.Distance(t.position, origin);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }

        return tMin;
    }

    public bool IsAnyBirdInRange(Bee bee)
    {
        if(Vector3.Distance(birds[0].transform.position, bee.transform.position) < detectionRange)
        {
            return true;
        }
        if (Vector3.Distance(birds[1].transform.position, bee.transform.position) < detectionRange)
        {
            return true;
        }
        return false;
    }


  
    public void Killed(Bird chaser, Bee bee)
    {
        Transform t = Instantiate(alertPrefab, UI_Holder);
        t.GetChild(0).GetComponent<Text>().text = bee.name + " was killed by: " + chaser.transform.name + " !";
        t.GetChild(0).GetComponent<Text>().color = Color.red;
    }

    public void Escaped(Bird chaser,Bee bee)
    {
        Transform t = Instantiate(alertPrefab, UI_Holder);
        t.GetChild(0).GetComponent<Text>().text = bee.name + " Escaped !";
    }


    /*
    IEnumerator beeDetection(Transform bird)
    {
        while (true)
        {
            if (BeesInRange(bird) != null)
            {
                Transform[] _beesInRange = BeesInRange(bird);
                bird.GetComponent<Bird>().SetState(new ChasingState(bird.GetComponent<Bird>(), closestObject(bird.position, _beesInRange)));

                closestObject(bird.position, _beesInRange).GetComponent<Bee>().SetState(new FleeingState(closestObject(bird.position, _beesInRange).GetComponent<Bee>(), null));
               // yield break;
            }
            yield return null;
        }
    
    }

    */

    void Update()
    {
        if(BeesInRange(birds[0].transform) != null)
        {
            foreach(Transform b in BeesInRange(birds[0].transform))
            {
                b.GetComponent<Bee>().SetState(new FleeingState(b.GetComponent<Bee>(), null));
            }
            if (!birds[0].GetComponent<Bird>().isChasing)
            {
                birds[0].GetComponent<Bird>().SetState(new ChasingState(birds[0].GetComponent<Bird>(), BeesInRange(birds[0].transform)[Random.Range(0, BeesInRange(birds[0].transform).Length)].GetComponent<Bee>()));
                birds[0].GetComponent<Bird>().isChasing = true;
            }
        }
        if (BeesInRange(birds[1].transform) != null && !birds[1].GetComponent<Bird>().isChasing)
        {
            foreach (Transform b in BeesInRange(birds[1].transform))
            {
                b.GetComponent<Bee>().SetState(new FleeingState(b.GetComponent<Bee>(), null));
            }
            if (!birds[1].GetComponent<Bird>().isChasing)
            {
                birds[1].GetComponent<Bird>().SetState(new ChasingState(birds[1].GetComponent<Bird>(), BeesInRange(birds[1].transform)[Random.Range(0, BeesInRange(birds[1].transform).Length)].GetComponent<Bee>()));
                birds[1].GetComponent<Bird>().isChasing = true;
            }
        }


    }
   
}

