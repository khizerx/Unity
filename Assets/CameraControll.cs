using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float moveSpeed = 1;
    public float zoomSped = 1;

    private Camera cam;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;


        cam.transform.Translate(horizontal, vertical, 0);

        
        cam.orthographicSize -= Input.mouseScrollDelta.y * zoomSped * Time.deltaTime;

       
    }



}
