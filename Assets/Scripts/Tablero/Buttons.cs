using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    public GameObject[] _roadA, _roadB;

    PlayerControllerV02 _playerController;
    public void RollD6()
    {
        // Implement your dice rolling logic here, for example:
        int rolledNumber = Random.Range(1, 7); // This will return a random number between 1 and 6 (inclusive)

        _playerController.MoveBoard(rolledNumber);
    }

    public void ChooseRoad(RoadType roadType)
    {
        GameObject[] chosenRoad = GetRoadArray(roadType);
        _playerController.ChoosePath(chosenRoad);
    }

    private GameObject[] GetRoadArray(RoadType roadType)
    {
        switch (roadType)
        {
            case RoadType.RoadA:
                return _roadA;
            case RoadType.RoadB:
                return _roadB;
            
            default:
                return _roadA; 
        }
    }
}

public enum RoadType
{
    RoadA,
    RoadB
    // Add more road types as needed
}
