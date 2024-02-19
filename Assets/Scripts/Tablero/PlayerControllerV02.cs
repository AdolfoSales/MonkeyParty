using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerV02 : MonoBehaviour
{
    [SerializeField] GameObject[] _crossRoads;

    [SerializeField] GameObject[] _roadA;
    [SerializeField] GameObject[] _roadB;

    [SerializeField] GameObject[] chosenPath;


    [SerializeField] int _currentCellIndex = 0;

    [SerializeField] float _moveSpeed = 5f;


    [SerializeField] Button _crossRoads1Left, _crossRoads1Right;

    bool _canMove = true;

    Vector3 targetPosition;

    int newCrossRoadsIndex = 0;

    private void Awake()
    {
        chosenPath = _roadA;
    }


    public void Update()
    {
        
    }

    private IEnumerator CrossRoadsCoroutine(int newCrossRoadsIndex)
    {
        Vector3 crossRoadsTarget = _crossRoads[newCrossRoadsIndex].transform.position + new Vector3(0, 1.1f, 0);

        while (transform.position != crossRoadsTarget)
        {
            yield return null;
        }

        _canMove = false;
        _crossRoads1Left.enabled = _crossRoads1Right.enabled = true;

        
    }
    public void ChooseCrossRoads(GameObject[] pathToChoose)
    {

    }
        
    public void RollD6()
    {
        // Implement your dice rolling logic here, for example:
        int rolledNumber = Random.Range(1, 7); // This will return a random number between 1 and 6 (inclusive)

        Move(rolledNumber);
    }
    public void ChoosePath(GameObject[] path)
    {

        chosenPath = path;
    }

    private void Move(int rolledNumber)
    {
        // Calculate the new cell index based on the rolled number
        int newCellIndex = (_currentCellIndex + rolledNumber) % chosenPath.Length;

        Vector3 targetPosition = chosenPath[newCellIndex].transform.position + new Vector3(0, 1.1f, 0);

        StartCoroutine(MoveCoroutine(targetPosition, newCellIndex));
    }


    private IEnumerator MoveCoroutine(Vector3 targetPosition, int newCellIndex)
    {
        while (transform.position != targetPosition && _canMove == true)
        {
            int nextCellToGo = (_currentCellIndex + 1) % chosenPath.Length;

            Vector3 nextCellTarget = chosenPath[nextCellToGo].transform.position + new Vector3(0, 1.1f, 0);

            if (transform.position == nextCellTarget)
            {
                if (transform.position == _crossRoads[newCrossRoadsIndex].transform.position)
                {
                    StartCoroutine(CrossRoadsCoroutine(newCrossRoadsIndex));
                }

                yield return StartCoroutine(CrossRoadsCoroutine(newCrossRoadsIndex));
                _currentCellIndex++;
            }

            // Move towards the target position

            if ( _canMove == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextCellTarget, _moveSpeed * Time.deltaTime);
            }
              


            yield return null; // Wait for the next frame
        }

        // Update the current cell index once the movement is complete
        _currentCellIndex = newCellIndex;
    }
}
