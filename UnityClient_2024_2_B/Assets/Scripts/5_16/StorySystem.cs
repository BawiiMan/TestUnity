using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StorySystem : MonoBehaviour
{
    public static StorySystem instance;                         //�̱���

    public StoryModel currentStoryModel;
    public enum TEXTSYSTEM
    {
        DOING,
        SELECT,
        DONE
    }

    public float delay = 0.1f;                                       //���ڰ� ��Ÿ���� �� �ɸ��� �ð�
    public string fullText;                                            //��ü ǥ���� �ؽ�Ʈ
    public string currentText = "";                              //������� ǥ�õ� �ؽ�Ʈ
    public Text textComponent;                                //�ؽ�Ʈ ������Ʈ   
    public Text storyIndex;                                       //story ��ȣ
    public Image imageComponent;                       //������ �̹���

    public Button[] buttonWay = new Button[3];          //������ ��ư
    public Text[] buttonWayText = new Text[3];           //��ư �ؽ�Ʈ

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonWay.Length; i++)
        {
            int wayIndex = i;       //Ŭ����(colsure) ���� �ذ� �ϱ� ���� ���� ����
            //Ŭ���� ���� -> ���ٽ� �Ǵ� �͸� �Լ��� �ܺ� ������ ĸó�� �� �߻��ϴ� ����
            buttonWay[i].onClick.AddListener(() => OnWayClick(wayIndex));
        }

        StoryModelInit();
        StartCoroutine(ShowText());
    }

    public void StoryModelInit()                                            //�޾ƿ� �� ������ ����
    {
        fullText = currentStoryModel.storyText;
        storyIndex.text = currentStoryModel.storyNumber.ToString();

        for (int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWayText[i].text = currentStoryModel.options[i].buttonText;
        }
    }

    IEnumerator ShowText()
    {
        if(currentStoryModel.MainImage != null)
        {
            //Texture2D => Sprite �� ��ȯ
            Rect rect = new Rect(0, 0, currentStoryModel.MainImage.width, currentStoryModel.MainImage.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);                    //��������Ʈ ��(�߽�) ����
            Sprite sprite = Sprite.Create(currentStoryModel.MainImage, rect, pivot);

            imageComponent.sprite = sprite;
        }
        else
        {
            Debug.LogError("Texture�� ������ �� �����ϴ�.");
        }

        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);                     //���ڿ� 0���� i���� �����ش�.
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
    public void OnWayClick(int index)   //��ư ������ ȣ�� �Ǵ� �Լ�
    {
        Debug.Log("OnWayClick : " + index);
    }
}
