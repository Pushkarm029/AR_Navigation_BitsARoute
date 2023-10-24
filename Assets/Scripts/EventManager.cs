using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public TextAsset textJSON;
    public Text eventText;

    [Serializable]
    public class EventData
    {
        public string Event;
        public string Venue;
        public string Date;
        public string Time;
    }

    private void Start()
    {
        if (textJSON != null)
        {
            // Parse the JSON array directly into a list of EventData
            List<EventData> mySchedules = new List<EventData>();
            string[] lines = textJSON.text.Split('\n');

            foreach (var line in lines)
            {
                mySchedules.Add(JsonUtility.FromJson<EventData>(line));
            }

            DateTime currentTime = DateTime.Now;
            TimeSpan tenMinutes = TimeSpan.FromMinutes(10);

            foreach (var eventData in mySchedules)
            {
                string eventDateTimeString = eventData.Date + " " + eventData.Time;
                DateTime eventDateTime = DateTime.Parse(eventDateTimeString);

                if (eventDateTime >= currentTime && eventDateTime <= currentTime.Add(tenMinutes))
                {
                    // Show UI for this event
                    eventText.text = $"Event: {eventData.Event}\nVenue: {eventData.Venue}\n";
                    Debug.Log($"Event: {eventData.Event} at {eventData.Venue}");
                    break; // Only show the first event within 10 minutes
                }
            }
        }
        else
        {
            Debug.LogError("No JSON data found.");
        }
    }
}
