using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerV02 : MonoBehaviour
{
    [SerializeField] GameObject[] _crossRoads;

    [SerializeField] GameObject[] chosenPath;

    [SerializeField] int _currentCellIndex = 0, _currentCrossRoadsIndex;

    [SerializeField] float _moveSpeed = 5f;

    [SerializeField] Button _crossRoads1Left, _crossRoads1Right;

    bool _canMoveBoard = true;

    Vector3 targetPosition;

    int CrossRoadsIndex = 0;

    private void Awake()
    {
        
    }


    public void Update()
    {
        
    }

    private IEnumerator CrossRoadsCoroutine(int _currentCrossRoadsIndex)
    {
        Vector3 crossRoadsTarget = _crossRoads[_currentCrossRoadsIndex].transform.position + new Vector3(0, 1.1f, 0);

        while (transform.position != crossRoadsTarget)
        {
            yield return null;
        }

        _canMoveBoard = false;
        _crossRoads1Left.enabled = _crossRoads1Right.enabled = true;

        
    }
   
    public void ChoosePath(GameObject[] path)
    {
        chosenPath = path;
        
    }

    public void MoveBoard(int rolledNumber)
    {
        // Calculate the new cell index based on the rolled number
        int newCellIndex = (_currentCellIndex + rolledNumber) % chosenPath.Length;

        Vector3 targetPosition = chosenPath[newCellIndex].transform.position + new Vector3(0, 1.1f, 0);

        StartCoroutine(MoveCoroutine(targetPosition, newCellIndex));
    }


    private IEnumerator MoveCoroutine(Vector3 targetPosition, int newCellIndex)
    {
        while (transform.position != targetPosition && _canMoveBoard == true)
        {
            int nextCellToGo = (_currentCellIndex + 1) % chosenPath.Length;

            Vector3 nextCellTarget = chosenPath[nextCellToGo].transform.position + new Vector3(0, 1.1f, 0);

            if (transform.position == nextCellTarget)
            {
                if (transform.position == _crossRoads[CrossRoadsIndex].transform.position)
                {
                    StartCoroutine(CrossRoadsCoroutine(CrossRoadsIndex));
                }

                yield return StartCoroutine(CrossRoadsCoroutine(CrossRoadsIndex));
                _currentCellIndex++;
            }

            // Move towards the target position

            if ( _canMoveBoard == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextCellTarget, _moveSpeed * Time.deltaTime);
            }
              


            yield return null; // Wait for the next frame
        }

        // Update the current cell index once the movement is complete
        _currentCellIndex = newCellIndex;
    }
}
