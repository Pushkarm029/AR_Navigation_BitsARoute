using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class InitialPosition : MonoBehaviour
{
    
    Vector3 initialPosition;
    [SerializeField] private float inilat;
    [SerializeField] private float inilong;
    private float finallat;
    private float finallong;
    [SerializeField] private float midrotfd;
    private float anx;
    private float any;
    public float multy = -27500;
    public float multx = 7000;
    private float multxt =0;

    public static InitialPosition Instance { set; get; }
    public float latitude;
    public float longitude;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        initialPosition = transform.position;
        if(inilong > finallong && inilat > finallat){
            multxt = 7*multx;
        }
        else if(inilong < finallong && inilat < finallat){
            multx = 6000;
            multxt = -multx*4;
        }
        else if(inilong > finallong && inilat < finallat){
            if(finallong<midrotfd){
                multxt = -multx*3;
            }
        }
    }
    public void GetUserLocation()
    {
        if (!Input.location.isEnabledByUser)
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        else
        {
            StartCoroutine(GetLatLonUsingGPS());
        }
    }
 
    IEnumerator GetLatLonUsingGPS()
    {
        Input.location.Start();
        int maxWait = 5;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
     
        // Access granted and location value could be retrieve
        longitude = Input.location.lastData.longitude;
        latitude = Input.location.lastData.latitude;
    }
    private void Update()
    {   
        GetUserLocation();
        finallat = (latitude);
        finallong = (longitude);
        if(inilong > finallong && inilat > finallat){
            multxt = 7*multx;
        }
        else if(inilong < finallong && inilat < finallat){
            multx = 6000;
            multxt = -multx*4;
        }
        else if(inilong > finallong && inilat < finallat){
            if(finallong<midrotfd){
                multxt = -multx*3;
            }
        }
        anx = -multxt*(finallong-inilong);
        any = -multy*(finallat-inilat);
        // Calculate the new position of the game object based on GPS coordinates
        Vector3 newPosition = new Vector3(anx, initialPosition.y, any);
        transform.position = newPosition;
    }
}