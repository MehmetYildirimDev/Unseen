using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notifications : MonoBehaviour
{
    public static Notifications instance;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {

        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification = new AndroidNotification();
        notification.Title = "Escape Vision";
        notification.Text = "Come here and play!";
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";

        notification.FireTime = System.DateTime.Now.AddMinutes(10);//kac dk sonra gidicek


        AndroidNotificationCenter.SendNotification(notification, "channel_id");


    }





}
