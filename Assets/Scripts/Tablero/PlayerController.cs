using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameObject[] _cells;
    

    int _currentCellIndex = 0;

    [SerializeField] float _moveSpeed = 5f;


    void Start()
    {
        // Initialization logic if needed
    }

    void Update()
    { 
    
    }

    private IEnumerator MoveCoroutine(Vector3 targetPosition, int newCellIndex)
    {
        while (transform.position != targetPosition)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);

            yield return null; // Wait for the next frame
        }

        // Update the current cell index once the movement is complete
        _currentCellIndex = newCellIndex;
    }

    private void Move(int rolledNumber)
    {
        // Calculate the new cell index based on the rolled number
        int newCellIndex = (_currentCellIndex + rolledNumber) % _cells.Length;

        Vector3 targetPosition = _cells[newCellIndex].transform.position + new Vector3 (0, 1.1f, 0);



        StartCoroutine(MoveCoroutine(targetPosition, newCellIndex));
    }

    
    private void RollD6()
    {
        // Implement your dice rolling logic here, for example:
        int rolledNumber = Random.Range(1, 7); // This will return a random number between 1 and 6 (inclusive)

        Move(rolledNumber);
    }


}
