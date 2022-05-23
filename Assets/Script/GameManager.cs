using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] personajePrefab;

    // Start is called before the first frame update
    void Start()
    {
        CargarPersonaje();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CargarPersonaje()
    {
        int SpriteIndex = PlayerPrefs.GetInt("SpriteIndex");
        Instantiate(personajePrefab[SpriteIndex]);
    }


}
