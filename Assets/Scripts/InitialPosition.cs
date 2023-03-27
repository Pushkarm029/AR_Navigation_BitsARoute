using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialPosition : MonoBehaviour
{
    Vector3 initialPosition;
    [SerializeField] private float inilat;
    [SerializeField] private float inilong;
    [SerializeField] private float finallat;
    [SerializeField] private float finallong;
    [SerializeField] private float midrotfd;
    public Text lat;
    public Text long1;
    private float anx;
    private float any;
    public float multy = 27500;
    public float multx = -7000;


    // private void LocationCall()
    // {
    //     finallat = (GPS.Instance.latitude);
    //     finallong = (GPS.Instance.longitude);
    // }
    private void Start()
    {
        // LocationCall();
        initialPosition = new Vector3(0, 1, 0);
        initialPosition = transform.position;
        if(inilong>finallong && inilat > finallat){
            multx = 7*multx;
        }
        else if(inilong<finallong && inilat<finallat){
            multx = -multx*4;
        }
        else if(inilong>finallong && inilat < finallat){
            if(finallong<midrotfd){
                multx = -multx*3;
            }
        }
    }
    private void Update()
    {
        // LocationCall();
        anx = -multx*(finallong-inilong);
        any = -multy*(finallat-inilat);
        // Calculate the new position of the game object based on GPS coordinates
        Vector3 newPosition = new Vector3(anx, initialPosition.y, any);
        transform.position = newPosition;
        lat.text=(finallat).ToString();
        long1.text=(finallong).ToString();
    }
}
