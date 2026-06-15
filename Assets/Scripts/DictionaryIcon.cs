using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DictionaryIcon : MonoBehaviour, IPointerClickHandler
{
    public BookPanel bookPanel;
    private bool isOpen = false;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        isOpen = !isOpen;
        if (isOpen) bookPanel.OpenBook();
        else bookPanel.CloseBook();
    }
}
