using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BuffMgr : SingletonAutoMono<BuffMgr>
{


    public Dictionary<GameObject, List<BuffBase>> buff_dic = new Dictionary<GameObject, List<BuffBase>>();

    public List<GameObject> uibuff=new List<GameObject> ();
    /// <summary>
    /// ���buff
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="buffOwner"></param>
    /// <param name="buffProvider"></param>
    /// <param name="buffid"></param>
    public void AddBuff<T>(GameObject buffOwner,string buffProvider,int buffid)where T:BuffBase,new()
    {
       
        if (buff_dic.ContainsKey(buffOwner))
        {
            int indexOfBuff = -1;
            bool hasmutual = false;
            for (int i = 0; i < buff_dic[buffOwner].Count; i++)
            {
                if (buff_dic[buffOwner][i].bfId == buffid)
                {
                    indexOfBuff = i; continue;
                }
                if(buff_dic[buffOwner][i].bfType == BuffType.mutual)
                {
                    hasmutual=true;
                }
            }
            if (indexOfBuff != -1)
            {   //����ͬ��buff
                //�ɵ���
                if (buff_dic[buffOwner][indexOfBuff].bfType == BuffType.additivity)
                {
                    buff_dic[buffOwner][indexOfBuff].GetBuff();
                    buff_dic[buffOwner][indexOfBuff].InCreateBuff();
                    DelectBuffObj(buffOwner, buff_dic[buffOwner][indexOfBuff].bfId);
                    return;

                }
                else
                {
                    return;
                }
            }
            else
            {
                
                for (int i = 0; i < buff_dic[buffOwner].Count; i++)
                {
                    
                    if (buff_dic[buffOwner][i].bfType == BuffType.mutual && (BuffType)Player_Buff.Get(buffid).buff_type == buff_dic[buffOwner][i].bfType)//��ͬ�Ļ���
                    {
                       
                        T item2 = new T();
                        item2.Initbuff(buffOwner, buffProvider, buffid);
                        //���һ��buff
                        buff_dic[buffOwner].Add(item2);

                        DelectBuffObj(buffOwner, buff_dic[buffOwner][i].bfId);
                        //�Ƴ���ǰ���buff
                        buff_dic[buffOwner].Remove(buff_dic[buffOwner][i]);
                       
                        return;
                    }

                    else if (!hasmutual || (BuffType)Player_Buff.Get(buffid).buff_type != BuffType.mutual)//��ͬ�Ŀɵ��Ӻ͹�����Ϊ������
                    {
                        T item3 = new T();
                        item3.Initbuff(buffOwner, buffProvider, buffid);
                        buff_dic[buffOwner].Add(item3);
                        return;
                    }
                  
                }

                
            }
            T item31 = new T();
            item31.Initbuff(buffOwner, buffProvider, buffid);
            buff_dic[buffOwner].Add(item31);
            return;
        }


        //����ǵ�һ�����buff
        T item = new T();
        item.Initbuff(buffOwner, buffProvider, buffid);
        List<BuffBase> tempList = new List<BuffBase>();
        tempList.Add(item);
        //���һ��buff
        buff_dic.Add(buffOwner, tempList);

    }

    /// <summary>
    /// buffһ��ʱ�䵽�˺�ɾ���ò�buff
    /// </summary>
    /// <param name="buffOwner"></param>
    /// <param name="buffid"></param>
    public void RemoveBuff(GameObject buffOwner, int buffid)
    {
        if (buff_dic.ContainsKey(buffOwner))
        {
            

            for (int i = 0; i < buff_dic[buffOwner].Count; i++)
            {
                if (buff_dic[buffOwner][i].bfId == buffid)
                {
                    buff_dic[buffOwner].Remove(buff_dic[buffOwner][i]);
                    
                    break;
                }
            }
            DelectBuffObj(buffOwner, buffid);

        }
    }

    public void DelectDicBuff(GameObject obj) {

        if (buff_dic.ContainsKey(obj))
        {
            buff_dic[obj].Clear();
            buff_dic[obj]=null;
        }
    }


    public void ClearAllBuff()
    {
        buff_dic.Clear();
        buff_dic = null;
    }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public string GetBuffName(GameObject obj)
    {
        string allbuffName = "";
        string buffInfo = "";
        if (buff_dic[obj]== null)
        {
            Debug.Log("û��buff");
            return "";
        }
        foreach (var item in buff_dic[obj]) { 
        
           allbuffName+=item.bfName+"+";
            buffInfo+=item.bfName + ":" + item.bfHierarchy.ToString() + "��\n";

        }
        Debug.Log(buffInfo);
        return allbuffName;
    }

    

    public float GetBuffPower(GameObject obj)
    {
        float power = 0;

        if (!buff_dic.ContainsKey(obj))
        {
            power = 0; 
            Debug.Log("û��buff");
            return power;
        }


        if (buff_dic[obj] == null|| buff_dic[obj].Count==0)
        {
            power = 0; 
            Debug.Log("û��buff");
            return power;
        }

        foreach (var item in buff_dic[obj])
        {
            
            item.UpdateBuff();
            power += item.Power;

            if(item.reTime<=0&&item.existTime!=0)
            {
                item.DecreaseBuff();
                break;
            }
        }
     
        //Debug.Log(string.Format("����buff�������˺���:{0}", power));
        return power;
    }

    /// <summary>
    /// AB�����غ�ʵ����
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public List<GameObject> GetBuffABObj(GameObject obj)
    {
        List<GameObject> list = new List<GameObject>();
        if (buff_dic.ContainsKey(obj))
        {
            foreach (var item in buff_dic[obj])
            {
                GameObject tempobj =ABMgr.GetInstance().LoadRes<GameObject>("art", "BuffImage");
                list.Add(Instantiate(tempobj));
            }
        }
        return list;
    }


    public void GetBuffObj(GameObject obj,int buffid)
    {
        
        if (buff_dic.ContainsKey(obj))
        {

            foreach (var item in buff_dic[obj])
            {
                if (item.bfId == buffid)
                {

                    if (item.bfType != BuffType.additivity) {
                        foreach (var uiitem in uibuff)
                        {
                            if (uiitem.GetComponent<BuffImage>().bfId == buffid) return;
                        }
                    }
                   

                    GameObject tempobj = Resources.Load<GameObject>("Prefabs/BuffImage");
                    tempobj.name = item.bfName;
                    var scriptComponent = tempobj.GetComponent<BuffImage>();
                    //��ʼ��ͼ��
                    scriptComponent.SetInfo(item);
                    uibuff.Add(Instantiate(tempobj));
                    break;
                }

            }

        }

    }


    public void DelectBuffObj(GameObject obj,int buffid)
    {
        if (uibuff.Count == 0) return;
        foreach (var item in uibuff)
        {
            if (item.GetComponent<BuffImage>().bfId == buffid)
            {
                Destroy(item.gameObject);
                uibuff.Remove(item);
                break;
            }
        }
    }


    public void ClearallBuffobj()
    {
        foreach (var item in uibuff)
        {
            Destroy(item);
        }
        uibuff.Clear();
        uibuff= null;   
    }

}
