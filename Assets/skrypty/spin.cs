using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    // Start is called before the first frame update
    public float gametimePerDay = 24.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaAngle = (360.0f / gametimePerDay) * Time.deltaTime;
        transform.Rotate(0f, deltaAngle, 0f);
    }
}
