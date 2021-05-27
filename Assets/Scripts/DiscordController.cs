﻿using UnityEngine;

public class DiscordController : MonoBehaviour
{

    public Discord.Discord Discord;
    public long applicationID;
    public string rpcStatus;
    public string rpcDetails;
    public string rpcLargeImage;
    public string rpcLargeImageText;

    // Use this for initialization
    void Start () {
        Discord = new Discord.Discord(applicationID, (System.UInt64)global::Discord.CreateFlags.NoRequireDiscord);
        var activityManager = Discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = rpcStatus,
            Details = rpcDetails,
            Assets =
            {
                LargeImage = rpcLargeImage,
                LargeText = rpcLargeImageText
            }
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == global::Discord.Result.Ok)
            {
                Debug.LogWarning("Everything is fine!");
            }
        });
        
        activityManager.ClearActivity((result) =>
        {
            if (result == global::Discord.Result.Ok)
            {
                Debug.Log("Success!");
            }
            else
            {
                Debug.LogError("Failed");
            }
        });
    }
	
    // Update is called once per frame
    void Update () {
        Discord.RunCallbacks();
    }
}
