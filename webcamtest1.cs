using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcamtest1 : MonoBehaviour {

    private string deviceName;
    private WebCamTexture tex;
    //private Vector2 resSize = new Vector2(1920, 1080);
    //private Vector2 resSize = new Vector2(640,480);  

    private Vector2 resSize = new Vector2(16, 12);
    
    // Use this for initialization  
    void Start() {
        StartCoroutine(InitCamera());
    }

    // Update is called once per frame  
    void Update() {

    }

    protected IEnumerator InitCamera() {
        //获取授权  
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam)) {
            WebCamDevice[] devices = WebCamTexture.devices;
            Debug.Log("devices.Length " + devices.Length);
            if (devices.Length > 0) {
                deviceName = devices[0].name;
                Debug.Log("deviceName " + deviceName);
                tex = new WebCamTexture(deviceName, (int)resSize.x, (int)resSize.y, 30);
                Debug.Log("tex.width " + tex.width);
                Debug.Log("tex.height " + tex.height);
                GetComponent<Renderer>().material.mainTexture = tex;
                tex.Play();
                Debug.Log("tex.width " + tex.width);
                Debug.Log("tex.height " + tex.height);
            }
        }
    }
}
