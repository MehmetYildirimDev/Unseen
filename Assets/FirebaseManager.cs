using UnityEngine;
using System;
using Firebase;
using Firebase.Database;


public class FirebaseManager : MonoBehaviour
{

    public static FirebaseManager firebaseManager;

    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public DatabaseReference DBreference;

    private void Awake()
    {
        if (firebaseManager == null)
        {
            firebaseManager = this;
        }
        else if (firebaseManager != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }


        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }


    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase");
        //Set the authentication instance object
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }


    private void Start()
    {

        GetAndroidDeviceId();



    }



    public string GetAndroidDeviceId()
    {
#if UNITY_ANDROID
        AndroidJavaObject context = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject contentResolver = context.Call<AndroidJavaObject>("getContentResolver");
        AndroidJavaClass secure = new AndroidJavaClass("android.provider.Settings$Secure");
        string androidId = secure.CallStatic<string>("getString", contentResolver, "android_id");
        return androidId;
#endif
        return "null";
    }

    public void SetValueDB()
    {
        DBreference.Child("users").Child(GetAndroidDeviceId()).SetValueAsync("testVerisi1");
        Debug.Log("Set Value!");
    }

    public void GetValueDB()
    {
        DBreference.Child("users").Child(GetAndroidDeviceId()).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string readValue = snapshot.Value.ToString();
                Debug.Log("Get Value: " + readValue);
            }
        });

    }

    private void OnApplicationQuit()
    {
        DBreference.Child("users").Child("log").Child(GetAndroidDeviceId()).SetValueAsync("2023");
    }

}//class
