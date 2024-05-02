using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME
{
    public class Enums
    {
        public enum StoryType
        {
            MAIN,
            SUB,
            SERIAL
        }

        public enum EventType
        {
            NONE,
            GoToBattle = 100,
            CheckSTR = 1000,
            CheckDEX,
            CheckCON,
            CheckINT,
            ChecktWIS,
            CheckCHA
        }

       public enum ResultType
        {
            ChangeHp,
            ChangeSp,
            AddExperience = 100,
            GoToShop = 1000,
            GoToNextStlory = 2000,
            GoToRandomStory = 3000,
            GoToEnding = 10000
        }
    }
    [System.Serializable]
    public class Stats
    {
        // ü�°� ���ŷ�
        public int hpPoint;
        public int spPoint;

        public int currentHpPoint;
        public int currentSpPoint;
        public int currentXpPoint;

        //�⺻ ���� ���� (Ex D&D)
        public int strength;    //STR ��
        public int dexterity;   //DEX ��ø
        public int constitution; //CON �ǰ�
        public int intelligence; //INT ����
        public int wisdom;  //WIS ����
        public int charisma;    //CHA �ŷ�
    }
}
