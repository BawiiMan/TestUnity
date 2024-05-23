using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    public Entity_Dialog entity_Dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Entity_Dialog.Param GetParamData(int npc, int gamestate)
    {
        foreach(Entity_Dialog.Param param in entity_Dialog.sheets[0].list)
        {
            if(param.npc == npc && param.gamestate == gamestate)
            {
                return param;
            }
        }
        //�ش� �����Ͱ� ���� ��� null ��ȯ
        return null;
    }
}
