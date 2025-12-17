using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIhover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverSound;
    public GameObject clickSound;
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 1);
        gameObject.GetComponent<Image>().color = Color.yellow;

        hoverSound.GetComponent<AudioSource>().Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        gameObject.GetComponent<Image>().color = Color.white;
    }
}