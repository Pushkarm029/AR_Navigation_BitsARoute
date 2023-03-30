// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ARRotation : MonoBehaviour
// {
//     private bool gyroEnabled;
//     private Gyroscope gyro;
//     private GameObject cameraContainer;
//     private Quaternion rot;
//     // Start is called before the first frame update
//     private void Start()
//     {
//         cameraContainer = new GameObject("Camera Container");
//         cameraContainer.transform.position = transform.position;
//         transform.SetParent(cameraContainer.transform);
//         gyroEnabled = EnableGyro(); 
//     }

//     private bool EnableGyro()
//     {
//         if(SystemInfo.supportsGyroscope){
//             gyro = Input.gyro;
//             gyro.enabled = true;

//             cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
//             rot = new Quaternion(0,0,1,0);

//             return true;
//         }
//         return false;
//     }
//     // Update is called once per frame
//     private void Update()
//     {
//         if(gyroEnabled){
//             transform.localRotation = gyro.attitude * rot;
//         } 
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARRotation : MonoBehaviour
{
    Gyroscope ryro;
    private void Start()
    {
        ryro = Input.gyro;
        ryro.enabled = true;
    }

    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            transform.rotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, 0, Input.gyro.attitude.w);
        }
    }
}

