using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class DataPersistance : MonoBehaviour
{
    public string NameofPlayer;
    public string SaveName;

    public Text InputText;
    public Text LoadedName;
    
 

    public GameObject[] ChooseCharacter;
    public GameObject[] Personajes;
    private int PersonajesIndex;
    private int SpriteIndex;

    // Update is called once per frame
    public void LoadNames()
    {
        NameofPlayer = PlayerPrefs.GetString("name", "none");
        LoadedName.text = NameofPlayer;
    }

    public void SetName()
    {
        SaveName = InputText.text;
        PlayerPrefs.SetString("name", SaveName);
    }

    public void CharacterSelection(int index)
    {
        for (int i = 0; i < Personajes.Length; i++)
        {
            Personajes[i].SetActive(false);
        }
        this.PersonajesIndex = index;
        Personajes[index].SetActive(true);
    }

   
}
