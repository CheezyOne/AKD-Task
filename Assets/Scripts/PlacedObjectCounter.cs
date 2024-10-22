using TMPro;
using UnityEngine;

public class PlacedObjectCounter : MonoBehaviour
{
    [SerializeField] private int _objectsToCollect = 9;
    [SerializeField] private TMP_Text _collectedObjectsText;

    private int _collectedObjectsCounter = 0;
    private void OnEnable()
    {
        UpdateText();
        PickupTrunk.onObjectPlacedIn += AddObject;
        PickupTrunk.onObjectTakenOut += SubtractObject;
    }
    private void OnDisable()
    {
        PickupTrunk.onObjectPlacedIn -= AddObject;
        PickupTrunk.onObjectTakenOut -= SubtractObject;
    }
    private void AddObject()
    {
        _collectedObjectsCounter++;
        if (_collectedObjectsCounter >= _objectsToCollect)
            _collectedObjectsText.text = "ВСЁ СОБРАНО!";
        UpdateText();
    }
    private void SubtractObject()
    {
        _collectedObjectsCounter--;
        UpdateText();
    }
    private void UpdateText()
    {
        _collectedObjectsText.text = "Собрано: "+_collectedObjectsCounter + " из " + _objectsToCollect;
    }
}
