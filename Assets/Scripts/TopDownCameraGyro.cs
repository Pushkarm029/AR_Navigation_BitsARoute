using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraGyro : MonoBehaviour
{
    Gyroscope jyro;
    private void Start()
    {
        jyro = Input.gyro;
        jyro.enabled = true;
    }

    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            transform.rotation = new Quaternion(0, Input.gyro.attitude.y, 90f, Input.gyro.attitude.w);
        }
    }
}
