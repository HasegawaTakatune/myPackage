using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    private Vector3 acceleration;
    private Compass compass;
    private Quaternion gyro;

    [SerializeField] private Text acceleTxt;
    [SerializeField] private Text compassTxt;
    [SerializeField] private Text gyroTxt;

    void Start()
    {
        Input.compass.enabled = true;

        Debug.Log(Input.compass.headingAccuracy + ":" + Input.compass.timestamp);

        Input.gyro.enabled = true;
    }

    void Update()
    {
        acceleration = Input.acceleration;
        compass = Input.compass;
        gyro = Input.gyro.attitude;

        acceleTxt.text = "Acceleration:" + acceleration;
        compassTxt.text = "Compass:" + compass;
        gyroTxt.text = "Gyro:" + gyro;
    }
}
