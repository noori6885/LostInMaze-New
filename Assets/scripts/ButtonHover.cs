using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Text")]
    public TextMeshProUGUI buttonText;

    [Header("Colors")]
    public Color normalColor = Color.red;
    public Color hoverColor = Color.white;

    [Header("Scale")]
    public float hoverScale = 1.1f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;

        if (buttonText != null)
            buttonText.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null)
            buttonText.color = hoverColor;

        transform.localScale = originalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
            buttonText.color = normalColor;

        transform.localScale = originalScale;
    }
}