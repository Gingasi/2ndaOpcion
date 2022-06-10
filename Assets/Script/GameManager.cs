using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    public Text username;
    public GameObject[] Personaje;
    public AudioSource GameAudioSource;
    public GameObject Musica;

    public TextMeshProUGUI Porcentaje;
    public TextMeshProUGUI lastCount;
    public TextMeshProUGUI countnow;

    void Start()
    {
        ApplyUserOptions();
    }


    public void ApplyUserOptions() //Al principio de la escena aplica estas opciones de la Data Persistance. 
    {
        username.text = DataPers.sharedInstance.nameTag;
        for (int i = 0; i < Personaje.Length; i++)
        {
            Personaje[i].SetActive(DataPers.sharedInstance.colorSelected == i);
        }

        if(DataPers.sharedInstance.MusicisOn == 0)
        {
            GameAudioSource.Pause();
            Musica.SetActive(false);
        }
        else
        {
            GameAudioSource.Play();
            Musica.SetActive(true);
        }

        GameAudioSource.volume = DataPers.sharedInstance.sliderMusic;
        Porcentaje.text = ($"{DataPers.sharedInstance.sliderMusic} % de volumen");

        //Refleja las veces que nos movemos entre escenas
        countnow.text = DataPers.sharedInstance.SceneCount.ToString();
        lastCount.text = DataPers.sharedInstance.LastCount.ToString();
    }
}


