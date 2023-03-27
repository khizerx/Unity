using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathVisualisation : MonoBehaviour
{
    public Transform[] path;

    public Color color;

  
    
    private void OnDrawGizmos()
    {
        Gizmos.color = color;

        for (int i = 0; i < path.Length;i++)
        {
            try
            {               
                Gizmos.DrawLine(path[i].position, path[i + 1].position);
            }
            catch
            {
                Gizmos.DrawLine(path[i].position, path[0].position);
            }
        }


    }
    
}
