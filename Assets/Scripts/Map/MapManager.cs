using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Map
{
    
    public class MapManager : MonoBehaviour
    {
    
        private readonly int _townSceneIndex = 2;
        private readonly int _bloodMoorSceneIndex = 3;
        private readonly int _denOfEvilSceneIndex = 4;
        private readonly int _coldPlainsSceneIndex = 5;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            
            if (gameObject.name == "Tilemap_LoadTown")
            {
                Debug.Log("Load Town");
                SceneManager.LoadSceneAsync(_townSceneIndex);
            }
            else if (gameObject.name == "Tilemap_LoadBloodMoor")
            {
                Debug.Log("Load Blood Moor");
                SceneManager.LoadSceneAsync(_bloodMoorSceneIndex);
            }
            else if (gameObject.name == "Tilemap_LoadDenOfEvil")
            {
                Debug.Log("Load Den Of Evil");
                SceneManager.LoadSceneAsync(_denOfEvilSceneIndex);
            } 
            else if (gameObject.name == "Tilemap_LoadColdPlains")
            {
                Debug.Log("Load Cold Plains");
                SceneManager.LoadSceneAsync(_coldPlainsSceneIndex);
            }
        }
    }
}