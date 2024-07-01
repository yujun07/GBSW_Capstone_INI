using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ChatManager : MonoBehaviour
{
    public TextMeshProUGUI ChatText;
    public TextMeshProUGUI CharacterName;
    public GameObject NameBox;
    private bool NameBoxChecker;
    public int ScenceHistory;
    private int choseCount = 0;
    
    public string writerText = "";

    public IEnumerator NormalChat(string narrator,string narration, int namebox)
    {
        int a = 0;
        
        writerText = "";
        if (namebox == 0 && NameBoxChecker)
        {
            NameBox.SetActive(false);
        }
        else NameBox.SetActive(true);

        CharacterName.text = narrator;

        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            yield return new WaitForSeconds(0.04f);
            ChatText.text = writerText;
            yield return null;
        }

        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                ChatText.text = "";
                break;
            }
            if(Input.GetKeyDown(KeyCode.Return))
            {
                ChatText.text = "";
                break;
            }
            yield return null;
        }
    }

    public IEnumerator ChoiceText()
    {
       
            Debug.Log("������ ����");
            
            StartCoroutine(NormalChat("", "a. ��ȭ���� ���� \r\nb. ������ ����.", 0));
            while (choseCount < 2)
            {


                GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[0];
                if (Input.GetKeyDown(KeyCode.A))
                {
                    choseCount++;
                    GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[4];
                    yield return StartCoroutine(NormalChat("", "���� ���� �;��� �ֽ� ��ȭ�� ��¥�� ���� �ô�.", 0));
                    yield return StartCoroutine(NormalChat("", "a. ��ȭ���� ���� \r\nb. ������ ����.", 0));

                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    choseCount++;
                    GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[0];
                    yield return StartCoroutine(NormalChat("", "�ҹ��� ������ �߰����� �� �ȼ��� ���� �Ծ���.", 0));
                    yield return StartCoroutine(NormalChat("", "a. ��ȭ���� ���� \r\nb. ������ ����.", 0));
                    
                }

                yield return null;
            }

    }
    IEnumerator TextPractice()
    {
        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[4];
        AudioManager.instance.PlaySfx(AudioManager.Sfx.ass2);
        //�������
        yield return StartCoroutine(NormalChat("������", "���� ���� ������ ����\r\n����ó�� ���� ���� ����",1));
        yield return StartCoroutine(NormalChat("������", " �׸��� �� �뵷 �������� ������",1));
        yield return StartCoroutine(NormalChat("������", "4500�� �� ~ �����佺 ��԰�~",1));
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[2];
        ColorSet(1);
        GameManager.Instance.image2.color = new Color(255, 255, 255,1f);
        yield return StartCoroutine(NormalChat("������", "�� �ȵ� ������",1));
        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[3];
        ColorSet(2);
        GameManager.Instance.image2.color = new Color(255, 255, 255,1f);

        yield return StartCoroutine(NormalChat("������", "�׷��� �θ��� �����!  ¥�� �� �� �׳� ���� �������� ������. ",1));
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        ColorSet(4);
        ColorSet(3);
        GameManager.Instance.image2.color = new Color(255, 255, 255,1f);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        yield return StartCoroutine(NormalChat("������", "�� �ȉ´ٰ�;;",1));
        yield return StartCoroutine(NormalChat("������", "...",1));
      
       
        
        yield return StartCoroutine(NormalChat("������", "�� �б� ���� ������;",1));
        ChatText.color = Color.blue;
        
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        yield return StartCoroutine(NormalChat("", "���� ħ�뿡�� �Ͼ �ξ����� ���ߴ�",0));
        ChatText.color = Color.black;

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("����", "��� �б� ��Ȱ�� ���?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("������", "�������� �ϰ� �־��",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("����", "������ ���� �� �ص� �� �ʸ� �ູ�ϸ� �� �ٵ� ������ �� �ϸ� ���ھ�",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("����", "�� �´� ���� �����̴� �̹��� \r\n���ǰ�� �� ���� 1~2��� �¾Ҵٰ� �ϴ���  ",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("������", "�˰ڴٰ��",1));

        ChatText.color = Color.blue;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("", "���� ��Ź�� �ɾ� ���� �Ծ���",0));
        ChatText.color = Color.black;


        /*
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[5];
        GameManager.Instance.image.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("������", "���� ��� 5�� ���� ��� ������ ������ �ſ���!"));

        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[5];
        GameManager.Instance.image.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("����", "������� ���� �� �Ծ� ���� 1���� ġ �� �����־�. �׸��� �� �԰� ��Ÿ�� �� ì�� �Ծ��~"));

        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[5];
        GameManager.Instance.image.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("", "���� ��Ź�� �ɾ� ���� �Ծ���"));

        */

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("����", "�б� �� ���ٿ���",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("������", "�ٳ���ڽ��ϴ�",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[1];
        yield return StartCoroutine(NormalChat("������", "��! ���� �� �� ��� �� �ְ� �����!!",1));

  
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        ChatText.color = Color.blue;
        GameManager.Instance.backGroundImage.color = Color.black;
        yield return StartCoroutine(NormalChat("������", "�̰��� ���� ���� �ΰ��� �Ǳ� ���� ����� ��� �� �ϳ��̴�",0));
        ColorSet(5);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("������", "�׷���. ���� ���� ���� �ΰ��� �Ǿ���� ���̴�!",0));
        ChatText.color = Color.black;
        
       
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("������", "�� �ٵ� ������ ��� ����?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("������", "�׷� �� ������ ������?!",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("������", "�� �´� �� ������ �б� ���� �� ����! �̷��� �� �� �׳� � ������~",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "�غ��� ���� �͵��� ���ö� ���� �ó��� ���ߴ�",0));
        ColorSet(6);
        
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[0];
        GameManager.Instance.backGroundImage.color = Color.white;
        yield return StartCoroutine(NormalChat("", "�ó��� ������ ������ ���� ����?",0));
        yield return StartCoroutine(ChoiceText());
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[0];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "��ɿ� �񸮴� �ϵ� ������ �׷��� �ʹ� ����־���",0));
        ChatText.color = Color.black;
        

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[5];
        ChatText.color = Color.black;
        yield return StartCoroutine(NormalChat("������", "�ٳ�Խ��ϴ�",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("", ".......",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("", ".......",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("������", "����? ������?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "�ƹ��� �ҷ��� �ƹ��� ����� ���ƿ��� �ʾҴ�",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "���� ���� �ξ����� �޷�����.",0));
        ChatText.color = Color.black;

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("������", "����~, �� ����� ����~",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[1];
        yield return StartCoroutine(NormalChat("������", "����! ������ �� ������!",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        yield return StartCoroutine(NormalChat("������", "�� �뵷...�����.. �״ϱ� ���� ����",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("������", "��, ���⿡ �ִµ�?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("������", "����! ����ī�޶󿴾�?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("������", "���� ���̳� ����",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "������ ���� �����ϸ� �ξ����� ����",0));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        ChatText.color = Color.black;
        yield return StartCoroutine(NormalChat("����", "����...",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        yield return StartCoroutine(NormalChat("������", "������..?",1));

        yield return StartCoroutine(NormalChat("����", "����... ������ ����...",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        yield return StartCoroutine(NormalChat("������", "�� ���� �������̾�?",1));

        yield return StartCoroutine(NormalChat("����", "���� ���� ���� ���ݾ� �׷��� �����ϴ� �ɷ� �߾�",1));

        yield return StartCoroutine(NormalChat("����", "�� ���� ������ ȥ�� ������ ȥ�� ���� ��� �ʹ� �������� ������ ������ �� �ǳ�",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        yield return StartCoroutine(NormalChat("������", "�׷� �� ���� �� �� �� �ž�",1));

        yield return StartCoroutine(NormalChat("����", "�׷���... �� �ò��� ��¥ ���� ���ص� �ǰ� ���� ���� �� ���� �����ϱ�.. �� ����",1));
        
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("������", "��? �̰�...��?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "���� ���� �� ������ ���ĳ�����",0));
        
        GameManager.Instance.backGroundImage.color = Color.black;
        ColorSet(5);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "�󸶳� �پ�����",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "���� �پ�� ���� ��� �ڸ� ��������, �������� ������ ���� ������� �ʾҴ�",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "�ʹ� ��ģ ������ �ٴڿ� �ɾ� ������ �ѷ��ô�",0));
       
        ColorSet(6);
        GameManager.Instance.backGroundImage.color = Color.white;
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[1];
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "���� ������� ���� ������ �Һ��� ����ߴ�",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "���� Ŀ�õ�� ���� ������ ���ư��� ���� �л�, ����ϰ� �ִ� �����ε��� �������� �־���",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "������ �� ������ ������ �ٴڿ� �ɾ��ִ� ���� �������� ���� �ʾҴ�",0));
        ChatText.color = Color.black;

        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("����", "����������?",1));

        ChatText.color = Color.blue;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "�Ƹ������� ������� ���� ���� �׳���� ù �����̾���.",0));
        ChatText.color = Color.black;
        
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("������", "���� ����?",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("����", "��..��...?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("������", "�� �Ҹ��ļ� �̾�...�ؿ�..!",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("����", "�翬�� ������ ���� ���...?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("������", "��¥ �̾��ѵ� Ȥ�� �ٸ� ��������� ���� ���̴��� ����� �ٷ���?",1));
        ColorSet(3);
        ChatText.color = Color.blue;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("", "���� ���̴� ��Ȳ������������ �׷����� ����� �־���",0));
        ChatText.color = Color.black;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("����", "Ȥ�� ���� ������ ���̽ó���?",1));
        
        yield return StartCoroutine(NormalChat("����1", "�ƴ�, �ƹ��͵� ���µ���?",1));
        
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("����", "��?! ��,�Ⱥ��δٰ��? �ֿ�?",1));
        
        ChatText.color = Color.blue;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "���ھ��̴� ���� ���̰� ���� ���ƿԴ�.",0));
        ChatText.color = Color.black;
        
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("������", "���ε���?",1));
        
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("����", "�ƴ�.. �ƴ� ��,,, �׷��ϱ� ���� �� ������ ,�� �Ⱥ�,, �� ",1));
        
        yield return StartCoroutine(NormalChat("����", ".....",1));
        
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("����", "������ �ѵ�....... ���� �ҽ��ϱ⵵ �ϰ� \r\n ������ �ظ� ���� �� ���� �����ϱ� �ϴ� �������� ",1));
        ChatText.color = Color.black;
            
        yield return StartCoroutine(NormalChat("����", ".....",1));
        
        yield return StartCoroutine(NormalChat("����", "��ǡ� �����䡦.. �װ͵� �� ",1));
        
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("����", "�ס� ���̶� ��⵵ �ϰ� ��� ���� ����ϽǷ���?",1));

        ColorSet(4);
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[7];
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "���ھ��̸� ���� ������ ���� ������ ���̾���.",0));
        ChatText.color = Color.black;
        
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("����", "���� �л��̶� ���� �� �� �ִ� ���� ���ۿ� �����.?",1));
        
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[4];
        yield return StartCoroutine(NormalChat("����", "����� �ٸ� �� ���� ���� ������ �� �濡�� �־�� �ؿ䡦",1));
        
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "����� ��θ�",0));
        
        ChatText.color = Color.black;
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[6];
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[5];
        yield return StartCoroutine(NormalChat("???", "�߿�~",1));
        
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "���� ���ڸ��� ����̰� ���ھ��̸� �ݰ��.",0));
        
        yield return StartCoroutine(NormalChat("", "���� ���̴� ����̸� ��縸����, �ڱ��� ������ �ȳ��ߴ�.",0));
        ChatText.color = Color.black;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[4];
        
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("����", "�츮 ������ �뼺�� �� �ߴµ� ���� �뼺���̶� ���ֽǷ���?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("����", "�翬����, ���� ������ , 17�� �Դϴ�.",1));
        ColorSet(2);
        yield return StartCoroutine(NormalChat("����", "�׸��� �Ʊ� ����̴� �޷ο���.",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("����", "���� ���̰� �����ϱ� �ݸ��ص� ��������?",1)); 
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("����", "�� , ��������",1));
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("����", "�׷��� ���� ���� �־��� �ſ���?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("����", "�׷��ϱ�..",1)); 
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "���� ���� ��ﳪ�� ���� �������־���.",0)); 
        ChatText.color = Color.black;
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("����", "�š��� ������ �׷� ���� �ִٰ��? ������?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("����", "���ٽ��� �� �� ���±��� ��·�� �ٸ� ��� ���� ���� �� �� �־��������� ��¥��",1)); 
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("����", "�� �׷��� ��� ������ ���̰ŵ��!",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("����", "��, �̾� �̾� �׷� �ǹ̿��� ������ �� ������?",1)); 
        ColorSet(2);
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "�����̴� ��� ����ϴ� ���ߴ�.",0));
        ChatText.color = Color.black;
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("����", "���� ����μ��� �� ����� �����ְų� �� �� �ִ� ����� ���� �� ������?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("����", "�ϴ���. ��",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("����", "�˾Ҿ�� �����ٰԿ�.. �ٵ� ������ �����ϰų� ������ �� ���� ���� �� �Ұſ���!",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("����", "�� ��ü ã�� �� ������ �� ������?",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("����", "��,��ü��?!",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("����", "��, �� ��ü���̾�.",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("����", "�� ��ü��? Ȥ�� �׾����? �����̿���?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("����", "�ƴ�.. Ȯ������ �ʾ� �ٴ� ���� ���� �� ����. �װ� ã���� ���ƿ� �� ���⵵ �ϰ�",1));
        ColorSet(2);
        yield return StartCoroutine(NormalChat("����", "��. �˾Ҿ�� �׷� ��ü ã�� ���ȿ��� �� �� �����ּž� �ſ�. ���� �ʿ��ϰŵ�� �� �ٸ� ���� �ʿ� �ϰŵ��", 1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("����", "�׷� ! ��������",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("����", "�׷��� ���� �� �������� ���� ����� ��� �� �����ּ���. \r\n �೯ ���ϴ°� �� ��� ���̿���",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("����", "��? �װ� ���ڵ� ���� �ʾ�?",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[4];
        yield return StartCoroutine(NormalChat("����", ":���� �׷��� �����ϰ� ���� �� �˾Ҿ�. �ƽ��Ե� ���� �д� ���ڿ���",1));
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("����", "��������� ���� ź�� �ƴϸ� �̿� �̷� ������ �����־��",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("����", " ��¥? ó�� �˾Ҵµ� �� ���� ������ ���� �����ٰ�.",1));
        ColorSet(4);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "�� ������ ������", 0));
        
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[2];
        yield return StartCoroutine(NormalChat("", "�� ���� ������!! �������� ���� �;��ϴ� �����̸� ���� ������ ���� �����ϰ� ����� �ּ���",0));
        ChatText.color = Color.black;
        SceneManager.LoadScene(1);
        
        
        
        
            
        yield return StartCoroutine(NormalChat("����", "",1));
        yield return StartCoroutine(NormalChat("����", "",1));

        
        
        
        
        
        

       
    }
    void Start()
    {
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5]; // ���� 
        StartCoroutine(TextPractice());
        NameBoxChecker = true;
    }

    void ColorSet(int arrow)
    {
        if (arrow == 1)
        {
            GameManager.Instance.image1.color = new Color(0, 0, 0);
            GameManager.Instance.image2.color = new Color(255, 255, 255,0.8f);
        }

        if (arrow == 2)
        {
           GameManager.Instance.image2.color = new Color(0, 0, 0);
           GameManager.Instance.image1.color = new Color(255, 255, 255);
           
        }

        if (arrow == 3)
        {
            GameManager.Instance.image1.color = new Color(255, 255, 255);
        }

        if (arrow == 4)
        {
            GameManager.Instance.image2.color = new Color(255, 255, 255,0.8f);
        }

        if (arrow == 6)
        {
            GameManager.Instance.image2.color = new Color(255, 255, 255, 0.8f);
        }
        if (arrow == 5)
        {
            GameManager.Instance.image2.color = new Color(255, 255, 255, 0.5f);
        }
    }
}
