using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Variable para almacenar el estado de pausa
    public static bool GameIsPaused = false;

    // Referencia al menú de pausa 
    public GameObject pauseMenuUI;

  
    void Update()
    {
        // Detecta si el jugador presiona la tecla "Esc" o el botón que quieras para pausar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();  
            }
            else
            {
                Pause();  
            }
        }
    }



    // Función para reanudar el juego
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  
        Time.timeScale = 1f;           
        GameIsPaused = false;          
    }

    // Función para pausar el juego
    void Pause()
    {
        pauseMenuUI.SetActive(true);   
        Time.timeScale = 0f;           
        GameIsPaused = true;           
    }

    // Función para salir al Menú Principal
    public void LoadMenu()
    {
        Time.timeScale = 1f;           
        SceneManager.LoadScene("Menu");  // Cambia a la escena del Menú Principal
    }

    // Función para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
