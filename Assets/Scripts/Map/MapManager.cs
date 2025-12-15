using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Map
{
    
    public class MapManager : MonoBehaviour
    {
    
        private readonly int BloodMoorSceneIndex = 2;
        private readonly int DenOfEvilSceneIndex = 3;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.name);
            if (!other.CompareTag("Player"))
            {
                return;
            }
            
            if (gameObject.name == "Tilemap_LoadTown")
            {
                Debug.Log("Load Town");
            }
            else if (gameObject.name == "Tilemap_LoadBloodMoor")
            {
                Debug.Log("Load Blood Moor");
                SceneManager.LoadScene(BloodMoorSceneIndex);
            }
            else if (gameObject.name == "Tilemap_LoadDenOfEvil")
            {
                Debug.Log("Load Den Of Evil");
                SceneManager.LoadScene(DenOfEvilSceneIndex);
            } 
            else if (gameObject.name == "Tilemap_LoadColdPlains")
            {
                Debug.Log("Load Cold Plains");
            }
        }
    }
}