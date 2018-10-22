using System;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Sets the URL of a Video Player to point to a streaming asset, whose
/// location can vary platform to platform.
/// </summary>
[RequireComponent(typeof(VideoPlayer))]
[Obsolete("We no longer use videos.")]
public class VideoStream : MonoBehaviour
{
    public string path;

    void Start()
    {
        var player = GetComponent<VideoPlayer>();
        player.url = Path.Combine(Application.streamingAssetsPath, path);
    }
}
