using System;
using UnityEngine;

public class URLOpener : MonoBehaviour
{
    // The grasstouchers url is the default string,
    // to change it you must edit in the editor, on the t-shirt link button
    [SerializeField] private string url = "https://www.grasstouchers.com";

    public void Open()
    {
        Application.OpenURL(url);
    }
}