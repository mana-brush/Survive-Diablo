using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Map
{
    public class WaypointManager : MonoBehaviour
    {
        
        [SerializeField] private GameObject canvas;

        private bool _playerInWaypoint;
        private bool _waypointMenuOn;
        
        private bool _foundColdPlainsWaypoint;
        private InputAction _spaceKey;

        private void Start()
        {
            _spaceKey = InputSystem.actions["Jump"];
        }

        void Update()
        {
            if (_spaceKey.triggered && _playerInWaypoint)
            {
                _waypointMenuOn = !_waypointMenuOn;
                canvas.SetActive(_waypointMenuOn);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (!other.CompareTag("Player"))
            {
                return;
            }

            _playerInWaypoint = true;

            switch (gameObject.name)
            {
                case "Tilemap_ColdPlainsWaypoint":
                    Debug.Log("Found Cold Plains");
                    _foundColdPlainsWaypoint = true;
                    break;
            }

        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _playerInWaypoint = false;
        }
    }
}