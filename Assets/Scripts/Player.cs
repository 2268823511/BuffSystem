using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float NowHp;

    public string BuffName = "";

    public Text textHP;
    public TextMeshProUGUI textBuffName;




    private void Start()
    {
        NowHp =1000;
    }

    // Update is called once per frame
    void Update()
    {
        textHP.text = string.Format("HP:{0}", NowHp);
        textBuffName.text = string.Format("BUFF:{0}", BuffName);
    }

     

}
