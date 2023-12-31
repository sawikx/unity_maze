using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wokół : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform aroundBody;
    public float orbitalPeriod = 27.3f; // earth days for one complete orbit
    public float gametimePerDay = 24f; // realtime seconds per game earth day
                                       // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float deltaAngle = (360.0f / (gametimePerDay * orbitalPeriod)) *
        Time.deltaTime;
        transform.RotateAround(aroundBody.position, Vector3.up, deltaAngle);
    }
}
