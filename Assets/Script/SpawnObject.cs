using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class SpawnObject : MonoBehaviour, IInputClickHandler
{
    public GameObject objectPrefab;

    void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (GazeManager.Instance.IsGazingAtObject)
        {
            var hitInfo = GazeManager.Instance.HitInfo;
            Instantiate(objectPrefab, hitInfo.point, Quaternion.identity, transform);
        }
    }
}