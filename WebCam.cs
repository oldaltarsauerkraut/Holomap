using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCam : MonoBehaviour {

    public string deviceName;
    WebCamTexture tex;
    private Vector2 resSize = new Vector2(1920, 1080);

    // Use this for initialization
    IEnumerator Start() {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam)) {
            WebCamDevice[] devices = WebCamTexture.devices;
            deviceName = devices[0].name;
            tex = new WebCamTexture(deviceName, (int)resSize.x, (int)resSize.y, 60);
            GetComponent<Renderer>().material.mainTexture = tex;
            tex.Play();
        }
    }
}
