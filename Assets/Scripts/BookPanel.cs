using UnityEngine;

public class BookPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void OpenBook()
    {
        gameObject.SetActive(true);
    }
    public void CloseBook()
    {
        gameObject.SetActive(false);
    }
}
