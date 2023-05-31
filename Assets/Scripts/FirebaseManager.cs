using UnityEngine;
using System;
using Firebase;
using Firebase.Database;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class FirebaseManager : MonoBehaviour
{

    public static FirebaseManager instance;

    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public DatabaseReference DBreference;

    DateTime exitTime;
    DateTime loginTime;

    private void Awake()
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

        GetValueDB();
    }


    private void Start()
    {
        loginTime = DateTime.Now;

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

#if UNITY_STANDALONE
    // Sadece Standalone (Windows, macOS, Linux) için geçerli olan kodlar buraya yazýlýr
    return "PC";
#endif

#if UNITY_EDITOR
        // Sadece Unity Editor'da geçerli olan kodlar buraya yazýlýr
        return "myEditor";
#endif

        return "null";
    }

    public void SetValueDB()
    {
        DBreference.Child("users").Child(GetAndroidDeviceId()).SetValueAsync("testVerisi1");
        Debug.Log("Set Value!");

    }


    public List<string> data = new List<string>();

    private void GetValueDB()
    {
        FirebaseDatabase database = FirebaseDatabase.DefaultInstance;

        DatabaseReference reference = database.GetReference("/users/log/myEditor");
        reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot != null && snapshot.Exists)
                {
                    foreach (DataSnapshot childSnapshot in snapshot.Children)
                    {
                        // Çocuk verileri okuma
                        string value = childSnapshot.Value.ToString();
                        data.Add(value);
                        print(value.ToString());
                        // Ýþlemlerinizi burada yapabilirsiniz
                    }
                }
            }
        });
    }

    public List<string> getdata()
    {
        return data;
    }

    private void OnApplicationQuit()
    {
        exitTime = DateTime.Now;

        TimeSpan calismaSuresi = exitTime - loginTime;

        string exitTimeString = exitTime.ToString();
        string loginTimeString = loginTime.ToString();
        string runTimeString = calismaSuresi.TotalSeconds.ToString("F0");

        DBreference.Child("users").Child("log").Child(GetAndroidDeviceId()).Child("login").SetValueAsync(loginTimeString);
        DBreference.Child("users").Child("log").Child(GetAndroidDeviceId()).Child("exit").SetValueAsync(exitTimeString);
        DBreference.Child("users").Child("log").Child(GetAndroidDeviceId()).Child("runTime").SetValueAsync(runTimeString);
    }

    private IEnumerator ItemGet()
    {
        //Get the currently logged in user data
        var DBTask = DBreference.Child("users").Child("log").Child("myEditor").GetValueAsync();//myEditor

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //veri null 
            Debug.Log("items is null");
        }
        else
        {

            DataSnapshot snapshot = DBTask.Result;

            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                //ItemNameList.Add(childSnapshot.Child("Name").Value.ToString());
                print(childSnapshot.Child("exit").Value.ToString());
            }

        }
    }

}//class
