using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class BuffImage : MonoBehaviour
{

    public Image bfImage;
    public Text bfName;
    public Text bfLevel;
    // Start is called before the first frame update
    public float retime;
    public float BuffTime;
    public int bfId;

    void Start()
    {
        this.GetComponent<Image>().fillAmount = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BuffTime != 0) ChangeFillAmount();
      
    }


    public void SetInfo(BuffBase baseInfo)
    {
        bfId=baseInfo.bfId;
        bfImage.sprite = Resources.Load<Sprite>(baseInfo.bfIcon);
        bfName.text=baseInfo.bfName.ToString();
        bfLevel.text = baseInfo.bfHierarchy.ToString();
        retime = baseInfo.reTime;
        BuffTime = baseInfo.existTime;
    }


    public void ChangeFillAmount()
    {
        if (BuffMgr.GetInstance().buff_dic.Values == null) return;
        foreach (var Listitem in BuffMgr.GetInstance().buff_dic)
        {
            foreach (var item in Listitem.Value)
            {
                if (bfId == item.bfId)
                {
                    retime = item.reTime;
                    BuffTime = item.existTime;
                    bfLevel.text=item.bfHierarchy.ToString();
                    this.GetComponent<Image>().fillAmount = (retime / BuffTime);
                    return;
                }
            }
        }
    }
}
