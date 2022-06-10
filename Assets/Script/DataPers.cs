using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPers : MonoBehaviour
{
    //Valores que utilizaremos para el datapersistant
    public static DataPers sharedInstance;
    public int colorSelected;
    public string nameTag;
    public int MusicisOn;
    public float sliderMusic;

    private int _colorSelected;

    public int SceneCount;
    public int LastCount;


    private void Awake()
    {
        //Miramos que no haya un data persistant creado y si lo hay lo eliminamos si no, se mantiene entre escenas
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public void SaveForFutureGames() //Datos que se guardan para cuando se vuelva a entrar en la partida
    {
        PlayerPrefs.SetInt("_COLORSELECTED", colorSelected);
        PlayerPrefs.SetInt("MUSICISON", MusicisOn);
        PlayerPrefs.SetString("NOMBRE", nameTag);
        PlayerPrefs.SetFloat("VOLUMEN", sliderMusic);
        PlayerPrefs.SetInt("COUNT", LastCount);
    }

}
