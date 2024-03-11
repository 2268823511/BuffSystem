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
            // 显示提示面板
            tooltipPanel.SetActive(true);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltipPanel != null)
        {
            // 隐藏提示面板
            tooltipPanel.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 初始时隐藏提示面板
        if (tooltipPanel != null)
            tooltipPanel.SetActive(false);

    }


    

}
