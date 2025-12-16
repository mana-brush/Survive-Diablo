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
        private readonly int _passageToBloodRavenSceneIndex = 6;
        private readonly int _burialGroundsSceneIndex = 7;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            switch (gameObject.name)
            {
                case "Tilemap_LoadTown":
                    Debug.Log("Load Town");
                    SceneManager.LoadSceneAsync(_townSceneIndex);
                    break;
                case "Tilemap_LoadBloodMoor":
                    Debug.Log("Load Blood Moor");
                    SceneManager.LoadSceneAsync(_bloodMoorSceneIndex);
                    break;
                case "Tilemap_LoadDenOfEvil":
                    Debug.Log("Load Den Of Evil");
                    SceneManager.LoadSceneAsync(_denOfEvilSceneIndex);
                    break;
                case "Tilemap_LoadColdPlains":
                    Debug.Log("Load Cold Plains");
                    SceneManager.LoadSceneAsync(_coldPlainsSceneIndex);
                    break;
                case "Tilemap_LoadPassageToBloodRaven":
                    Debug.Log("Load Passage To Blood Raven");
                    SceneManager.LoadSceneAsync(_passageToBloodRavenSceneIndex);
                    break;
                case "Tilemap_LoadBurialGrounds":
                    Debug.Log("Load Burial Grounds");
                    SceneManager.LoadSceneAsync(_burialGroundsSceneIndex);
                    break;
            }
        }
    }
}