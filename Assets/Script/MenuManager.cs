using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


public class MenuManager : MonoBehaviour
{
    public AudioMixer audiomixer;
    public AudioSource Music;

    public AudioClip Sh1;
    public bool musicisOn;
    public int colorSelected;

    public GameObject[] PersonajesColor;

    public string nameTag;
    public int MusicisOn;
    public TMP_InputField Nametag;
    public int _colorSelected;
    public int CancionSi;
    



    public Toggle SoundMusic;
    public Slider SliderMusic;
    public TextMeshProUGUI lastCount;
    public TextMeshProUGUI countnow;

    void Start()
    {
        SaveMusicValue(); //Que nos guarde si la canción estaba sonando o no
        LoadUserOptions(); //Aplica las opciones de usuario guardadas previamente
    }

    private void Update()
    {
        ChangeColorPers(); //Cambia el color del personaje cuando seleccionamos el boton de color. 
    }

    public void NewGame()
    {
        DataPers.sharedInstance.SceneCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Pase a la siguiente escena. 
    }

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("Volume", volume);  //Relaciona el slider volumen con nuestro audiomixer
    }
   
    public void ChangeColorSelection(int colorChoose)
    {
        colorSelected = colorChoose; //Cambia el color del personaje para la próxima escena (Linkado al botón)
        
    }

    public void ChangeColorPers() //Reconoce los distintos personajes con distinto color
    {
        for (int i = 0; i < PersonajesColor.Length; i++)
        {
            PersonajesColor[i].SetActive(colorSelected == i);
        }
    }

    public void SaveMusicValue() //Mira si el toogle está activado y lo convierte a un int
    {
      
        musicisOn = SoundMusic.isOn;
        MusicisOn = BoolToInt(musicisOn);
        
        
    }
    private int BoolToInt(bool b)
    {
        return b ? 1 : 0;
    }
    public void SaveUserOptions() //Guarda las opciones creadas por el jugador
    {
        DataPers.sharedInstance.colorSelected = colorSelected;
        DataPers.sharedInstance.nameTag = Nametag.text; 
        DataPers.sharedInstance.MusicisOn = MusicisOn;
        DataPers.sharedInstance.sliderMusic = SliderMusic.value;
        DataPers.sharedInstance.SaveForFutureGames();
    }



    public void LoadUserOptions() //Carga las opciones que el jugador ha seleccionado
    {
        if (PlayerPrefs.HasKey("NOMBRE")) //Comprueba si en este caso, el nombre está guardado, en caso afirmativo carga todo lo demás, porque reconoce que está guardado
        {
            if (PlayerPrefs.GetInt("MUSICISON") == 0)

            {
                Music.Pause();
                SoundMusic.isOn = false;
            }
            else
            {
                Music.PlayOneShot(Sh1, 1f);
                SoundMusic.isOn = true;
            }
            colorSelected = PlayerPrefs.GetInt("_COLORSELECTED");
            Nametag.text = PlayerPrefs.GetString("NOMBRE");
            SliderMusic.value = PlayerPrefs.GetFloat("VOLUMEN");
            countnow.text = DataPers.sharedInstance.SceneCount.ToString(); //Carga el último contador de la partida anterior
            DataPers.sharedInstance.LastCount = PlayerPrefs.GetInt("COUNT");
        }

    }
}
