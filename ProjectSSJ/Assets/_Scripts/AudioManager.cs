using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");

        if (objs.Length > 1){
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
