using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelObject : MonoBehaviour
{
    public Transform model;
    public bool left;
    // Start is called before the first frame update
    void Awake()
    {
        if (left)
        {
            model = GameObject.FindGameObjectWithTag("LeftController").transform;
        }
        else
        {
            model = GameObject.FindGameObjectWithTag("RightController").transform;
        }
       
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.SetPositionAndRotation(model.position, model.rotation);
    }
}
