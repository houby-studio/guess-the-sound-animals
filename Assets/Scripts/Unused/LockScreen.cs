using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScreen : MonoBehaviour
{
    private void Start()
	{
        StartLockScreen();
	}

    public string StartLockScreen()
    {
        //AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        //AndroidJavaObject context = activity.Call<AndroidJavaObject>("getApplicationContext");

        //var plugin = new AndroidJavaClass("eu.houbystudio.unityplugin.LockTask");
        //plugin.CallStatic("StartLockScreen", context);

        //AndroidJavaClass activityClass;
        //AndroidJavaObject activity;

        //activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

        //Debug.Log("Doing java magic");

        //var plugin = new AndroidJavaClass("eu.houbystudio.unityplugin.PluginClass");
        //plugin.CallStatic<string>("StartLockScreen", activity);
        //return "uno";

        //AndroidJavaClass activityClass;
        //AndroidJavaObject activity; //, packageManager;
        //AndroidJavaObject launch;

        //activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //activityClass.Call<AndroidJavaObject>("startLockTask");
        //activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        //Debug.Log(activity.ToString());
        //Debug.Log(activity.GetRawObject().ToString());
        //packageManager = activity.Call<AndroidJavaObject>("getPackageManager");
        //launch = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", package);
        //activity.CallStatic("startLockTask");

        return "this does not work";
    }
}
