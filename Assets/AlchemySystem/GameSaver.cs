using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSaver : MonoBehaviour
{
    public delegate void OnSaveListener();
    public static event OnSaveListener OnSaveEvent;

    public delegate void OnLoadListener();
    public static event OnLoadListener OnLoadEvent;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    public void Save()
    {
        OnSaveEvent.Invoke();
        //PlayerPrefs.SetInt(saveKey, myIntToSave);
    }

    public void Load()
    {
        OnLoadEvent.Invoke();
        //if (PlayerPrefs.HasKey(saveKey))
        //{
        //     myIntToSave = PlayerPrefs.GetInt(saveKey);
        //}
    }
}
