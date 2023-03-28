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
    public Text lat;
    public Text long1;
    public Text statusTxt;
    private float anx;
    private float any;
    public float multy = 27500;
    public float multx = -7000;
    private float multxt =0;

    public static InitialPosition Instance { set; get; }
    public float latitude;
    public float longitude;

    // IEnumerator LocationService()
    // {
    //     // Check if the user has location service enabled.
    //     if (!Input.location.isEnabledByUser)
    //         yield break;

    //     // Starts the location service.
    //     Input.location.Start();

    //     // Waits until the location service initializes
    //     int maxWait = 20;
    //     while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
    //     {
    //         yield return new WaitForSeconds(1);
    //         maxWait--;
    //     }

    //     // If the service didn't initialize in 20 seconds this cancels location service use.
    //     if (maxWait < 1)
    //     {
    //         print("Timed out");
    //         yield break;
    //     }

    //     // If the connection failed this cancels location service use.
    //     if (Input.location.status == LocationServiceStatus.Failed)
    //     {
    //         print("Unable to determine device location");
    //         yield break;
    //     }
    //     else
    //     {
    //         // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
    //         latitude = Input.location.lastData.latitude;
    //         longitude = Input.location.lastData.longitude;
    //     }
    // }
    // private IEnumerator StartLocationService()
    // {
    //     if (!Input.location.isEnabledByUser)
    //     {
    //         yield break;
    //     }
    //     Input.location.Start();

    //     int maxWait = 20;
    //     while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
    //     {
    //         yield return new WaitForSeconds(1);
    //         maxWait--;
    //     }

    //     if (maxWait <= 0 || Input.location.status == LocationServiceStatus.Failed)
    //     {
    //         yield break;
    //     }

    //     latitude = Input.location.lastData.latitude;
    //     longitude = Input.location.lastData.longitude;
    // }

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        // GPS = this.GetComponent<GPS>();
        initialPosition = transform.position;
        if(inilong > finallong && inilat > finallat){
            multxt = 7*multx;
        }
        else if(inilong < finallong && inilat < finallat){
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
        if (!Input.location.isEnabledByUser) //FIRST IM CHACKING FOR PERMISSION IF "true" IT MEANS USER GAVED PERMISSION FOR USING LOCATION INFORMATION
        {
            statusTxt.text = "No Permission";
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        else
        {
            statusTxt.text = "Permission Granted";
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
 
        statusTxt.text = "waiting before getting lat and lon";
     
        // Access granted and location value could be retrieve
        longitude = Input.location.lastData.longitude;
        latitude = Input.location.lastData.latitude;
     
        //AddLocation(latitude, longitude);
        statusTxt.text = "" + Input.location.status + "  lat:" + latitude + "  long:" + longitude;
    }
    private void Update()
    {   
        GetUserLocation();
        finallat = (latitude);
        finallong = (longitude);
        // if((multxt/7)==multx && inilong > finallong && inilat < finallat){
        //     if(finallong<midrotfd){
        //         multxt = -multx*3;
        //     }
        // }
        // if((multxt/7)==multx && inilong < finallong && inilat < finallat){
        //     multxt = -multx*4;
        // }
        // if((multxt/4)==(-multx) && inilong > finallong && inilat > finallat){
        //     multxt = 7*multx;
        // }
        // if((multxt/4)==(-multx) && inilong<finallong && inilat<finallat){

        // }
        // if((multxt/7)==multx && inilong<finallong && inilat<finallat){}
        // if((multxt/7)==multx && inilong<finallong && inilat<finallat){}
        if(inilong > finallong && inilat > finallat){
            multxt = 7*multx;
        }
        else if(inilong < finallong && inilat < finallat){
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
        lat.text=(finallat).ToString();
        long1.text=(finallong).ToString();
    }
}
