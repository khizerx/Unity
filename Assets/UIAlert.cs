using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAlert : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(fadeOff());   
    }

  
    IEnumerator fadeOff()
    {
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("fade");
        yield return new WaitForSeconds(1.3f);
        Destroy(this.gameObject);
    }
}
