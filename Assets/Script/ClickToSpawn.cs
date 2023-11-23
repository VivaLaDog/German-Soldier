using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ClickToSpawn : MonoBehaviour
{
    Camera cam;

    [SerializeField]
    GameObject cedule;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 20f))
            {
                Instantiate(cedule, hit.point, Quaternion.identity);
            }

        }
    }
}
