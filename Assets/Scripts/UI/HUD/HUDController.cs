using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] private GameObject _interactionUI;

    public void SetInteractionUI(bool state)
    {
        _interactionUI.SetActive(state);
    }
}
