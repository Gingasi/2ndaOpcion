using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMenu : MonoBehaviour
{
    public void BackMenu()
    {
        DataPers.sharedInstance.SceneCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Volvemos a la escena del Menu
    }

    public void Exit() //Salimos del juego y guardamos el contador actual como contador anterior para la proxima partida
    {

        DataPers.sharedInstance.LastCount = DataPers.sharedInstance.SceneCount;
        DataPers.sharedInstance.SaveForFutureGames();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
