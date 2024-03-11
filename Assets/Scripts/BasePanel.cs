using UnityEngine;
using UnityEngine.EventSystems;

public class BasePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipPanel;
    public GameObject Buffobject;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltipPanel != null)
        {
            // ��ʾ��ʾ���
            tooltipPanel.SetActive(true);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltipPanel != null)
        {
            // ������ʾ���
            tooltipPanel.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼʱ������ʾ���
        if (tooltipPanel != null)
            tooltipPanel.SetActive(false);

    }


    

}
