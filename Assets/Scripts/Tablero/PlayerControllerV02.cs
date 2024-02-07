using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerV02 : MonoBehaviour
{
    
    [SerializeField] GameObject[] _cells;


    [SerializeField] int _currentCellIndex = 0;

    [SerializeField] float _moveSpeed = 5f;

    Vector3 targetPosition;

    public void RollD6()
    {
        // Implement your dice rolling logic here, for example:
        int rolledNumber = Random.Range(1, 7); // This will return a random number between 1 and 6 (inclusive)

        Move(rolledNumber);
    }


    private void Move(int rolledNumber)
    {
        // Calculate the new cell index based on the rolled number
        int newCellIndex = (_currentCellIndex + rolledNumber) % _cells.Length;

        Vector3 targetPosition = _cells[newCellIndex].transform.position + new Vector3(0, 1.1f, 0);



        StartCoroutine(MoveCoroutine(targetPosition, newCellIndex));
    }


    private IEnumerator MoveCoroutine(Vector3 targetPosition, int newCellIndex)
    {
        while (transform.position != targetPosition)
        {
            int nextCellToGo = (_currentCellIndex + 1) % _cells.Length;

            Vector3 nextCellTarget = _cells[nextCellToGo].transform.position + new Vector3(0, 1.1f, 0);

            if (transform.position == nextCellTarget)
            {
                _currentCellIndex++;
            }

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, nextCellTarget, _moveSpeed * Time.deltaTime);

            yield return null; // Wait for the next frame
        }

        // Update the current cell index once the movement is complete
        _currentCellIndex = newCellIndex;
    }


}