using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update 
    public GameObject gameOverPanel;

    private void Start()
    {
        // Desactivamos el panel al inicio del juego
        gameOverPanel.SetActive(false);
    }
    public void MostrarGameOver(){
        Time.timeScale=0;
        gameOverPanel.SetActive(true);
        
    }

    public void ReiniciarNivel(){
        Time.timeScale=1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void IrAlMenuPrincipal(){
        Time.timeScale=1; 
        SceneManager.LoadScene( "Menu");
    }

}
