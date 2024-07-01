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
       
            Debug.Log("선택지 진입");
            
            StartCoroutine(NormalChat("", "a. 영화관을 간다 \r\nb. 시장을 간다.", 0));
            while (choseCount < 2)
            {


                GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[0];
                if (Input.GetKeyDown(KeyCode.A))
                {
                    choseCount++;
                    GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[4];
                    yield return StartCoroutine(NormalChat("", "원래 보고 싶었던 최신 영화를 공짜로 실컷 봤다.", 0));
                    yield return StartCoroutine(NormalChat("", "a. 영화관을 간다 \r\nb. 시장을 간다.", 0));

                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    choseCount++;
                    GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[0];
                    yield return StartCoroutine(NormalChat("", "소문난 맛집에 닭강정을 줄 안서고 몰래 먹었다.", 0));
                    yield return StartCoroutine(NormalChat("", "a. 영화관을 간다 \r\nb. 시장을 간다.", 0));
                    
                }

                yield return null;
            }

    }
    IEnumerator TextPractice()
    {
        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[4];
        AudioManager.instance.PlaySfx(AudioManager.Sfx.ass2);
        //배경음악
        yield return StartCoroutine(NormalChat("나유나", "오빠 밥쫌 먹으러 나와\r\n저번처럼 지각 하지 말고",1));
        yield return StartCoroutine(NormalChat("나유나", " 그리고 나 용돈 떨어졌어 갚을게",1));
        yield return StartCoroutine(NormalChat("나유나", "4500원 만 ~ 츄파춥스 사먹게~",1));
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[2];
        ColorSet(1);
        GameManager.Instance.image2.color = new Color(255, 255, 255,1f);
        yield return StartCoroutine(NormalChat("나태현", "아 안돼 돼지아",1));
        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[3];
        ColorSet(2);
        GameManager.Instance.image2.color = new Color(255, 255, 255,1f);

        yield return StartCoroutine(NormalChat("나유나", "그렇게 부르지 말라고!  짜증 나 나 그냥 오빠 지갑에서 빼간다. ",1));
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        ColorSet(4);
        ColorSet(3);
        GameManager.Instance.image2.color = new Color(255, 255, 255,1f);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        yield return StartCoroutine(NormalChat("나태현", "아 안됀다고;;",1));
        yield return StartCoroutine(NormalChat("나태현", "...",1));
      
       
        
        yield return StartCoroutine(NormalChat("나태현", "아 학교 가기 귀찮다;",1));
        ChatText.color = Color.blue;
        
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        yield return StartCoroutine(NormalChat("", "나는 침대에서 일어나 부엌으로 향했다",0));
        ChatText.color = Color.black;

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("엄마", "요새 학교 생활은 어떠니?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("나태현", "열심히는 하고 있어요",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("엄마", "엄마는 공부 못 해도 되 너만 행복하면 되 근데 꼴지는 안 하면 좋겠어",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("엄마", "아 맞다 옆집 강민이는 이번에 \r\n모의고사 전 과목 1~2등급 맞았다고 하더라  ",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("나태현", "알겠다고요",1));

        ChatText.color = Color.blue;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("", "나는 식탁에 앉아 밥을 먹었다",0));
        ChatText.color = Color.black;


        /*
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[5];
        GameManager.Instance.image.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("나태현", "엄마 어떻게 5일 연속 사골 국물만 나오는 거예요!"));

        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[5];
        GameManager.Instance.image.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("엄마", "편식하지 말고 다 먹어 아직 1주일 치 더 남아있어. 그리고 다 먹고 비타민 꼭 챙겨 먹어라~"));

        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[5];
        GameManager.Instance.image.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("", "나는 식탁에 앉아 밥을 먹었다"));

        */

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("엄마", "학교 잘 갔다오렴",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("나태현", "다녀오겠습니다",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[1];
        yield return StartCoroutine(NormalChat("나유나", "아! 같이 가 나 대려 다 주고 가라고!!",1));

  
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        ChatText.color = Color.blue;
        GameManager.Instance.backGroundImage.color = Color.black;
        yield return StartCoroutine(NormalChat("나태현", "이것이 내가 투명 인간이 되기 전의 희미한 기억 중 하나이다",0));
        ColorSet(5);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("나태현", "그렇다. 나는 오늘 투명 인간이 되어버린 것이다!",0));
        ChatText.color = Color.black;
        
       
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("나태현", "아 근데 성적은 어떻게 하지?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[2];
        yield return StartCoroutine(NormalChat("나태현", "그럼 내 수도권 대학은?!",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("나태현", "아 맞다 나 어차피 학교 수업 안 듣지! 이렇게 된 거 그냥 놀러 가야지~",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "해보고 싶은 것들이 떠올라 곧장 시내로 향했다",0));
        ColorSet(6);
        
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[0];
        GameManager.Instance.backGroundImage.color = Color.white;
        yield return StartCoroutine(NormalChat("", "시내로 도착한 나태현 어디로 갈까?",0));
        yield return StartCoroutine(ChoiceText());
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[0];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "양심에 찔리는 일도 했지만 그래도 너무 재미있었다",0));
        ChatText.color = Color.black;
        

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[5];
        ChatText.color = Color.black;
        yield return StartCoroutine(NormalChat("나태현", "다녀왔습니다",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("", ".......",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("", ".......",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("나태현", "엄마? 돼지야?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "아무리 불러도 아무런 대답이 돌아오지 않았다",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "나는 곧장 부엌으로 달려갔다.",0));
        ChatText.color = Color.black;

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("나태현", "엄마~, 왜 대답이 없어~",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[1];
        yield return StartCoroutine(NormalChat("나유나", "오빠! 엄마가 밥 먹으래!",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        yield return StartCoroutine(NormalChat("나유나", "나 용돈...줘야지.. 그니까 빨리 나와",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("나태현", "나, 여기에 있는데?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("나태현", "뭐야! 몰래카메라였어?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("나태현", "빨리 밥이나 먹자",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "동생은 나를 무시하며 부엌으로 갔다",0));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        ChatText.color = Color.black;
        yield return StartCoroutine(NormalChat("엄마", "먹자...",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        yield return StartCoroutine(NormalChat("나유나", "오빠는..?",1));

        yield return StartCoroutine(NormalChat("엄마", "아직... 연락이 없네...",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        yield return StartCoroutine(NormalChat("나유나", "왜 하필 갈비찜이야?",1));

        yield return StartCoroutine(NormalChat("엄마", "오빠 언제 올지 모르잖아 그래서 좋아하는 걸로 했어",1));

        yield return StartCoroutine(NormalChat("엄마", "너 오늘 현관문 혼자 나가고 혼자 오는 모습 너무 낯설더라 적응이 아직도 안 되네",1));

        GameManager.Instance.image1.sprite = GameManager.Instance.naYuNa[2];
        yield return StartCoroutine(NormalChat("나유나", "그런 말 하지 마 곧 올 거야",1));

        yield return StartCoroutine(NormalChat("엄마", "그렇지... 곧 올꺼야 진짜 공부 못해도 되고 좋은 대학 안 가도 좋으니깐.. 올 꺼야",1));
        
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("나태현", "어? 이게...왜?",1));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "나는 곧장 집 밖으로 뛰쳐나갔다",0));
        
        GameManager.Instance.backGroundImage.color = Color.black;
        ColorSet(5);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "얼마나 뛰었을까",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "나는 뛰어가는 도중 잠시 뒤를 돌았지만, 여동생과 엄마는 나를 따라오지 않았다",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "너무 지친 나머지 바닥에 앉아 주위를 둘러봤다",0));
       
        ColorSet(6);
        GameManager.Instance.backGroundImage.color = Color.white;
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[1];
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "밤이 깊어지고 여러 간판의 불빛이 즐비했다",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "여러 커플들과 아직 집으로 돌아가지 않은 학생, 퇴근하고 있는 직장인들이 지나가고 있었다",0));

        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "하지만 그 누구도 더러운 바닥에 앉아있는 내게 눈길조차 주지 않았다",0));
        ChatText.color = Color.black;

        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("아윤", "괜찮으세요?",1));

        ChatText.color = Color.blue;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "아름답지만 비극적인 눈을 가진 그녀와의 첫 만남이었다.",0));
        ChatText.color = Color.black;
        
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("나태현", "내가 보여?",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("아윤", "네..네...?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("나태현", "아 소리쳐서 미안...해요..!",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("아윤", "당연히 보이지 않을 까요...?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("나태현", "진짜 미안한데 혹시 다른 사람들한테 내가 보이는지 물어봐 줄래요?",1));
        ColorSet(3);
        ChatText.color = Color.blue;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[1];
        yield return StartCoroutine(NormalChat("", "여자 아이는 당황스러워했지만 그럼에도 물어봐 주었다",0));
        ChatText.color = Color.black;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("아윤", "혹시 저기 저분이 보이시나요?",1));
        
        yield return StartCoroutine(NormalChat("행인1", "아뇨, 아무것도 없는데요?",1));
        
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("아윤", "네?! ㅇ,안보인다고요? 왜요?",1));
        
        ChatText.color = Color.blue;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("", "여자아이는 고개를 숙이고 내게 돌아왔다.",0));
        ChatText.color = Color.black;
        
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("나태현", "보인데요?",1));
        
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("아윤", "아뇨.. 아니 읏,,, 그러니깐 저도 안 보여요 ,… 안보,, ㅇ ",1));
        
        yield return StartCoroutine(NormalChat("아윤", ".....",1));
        
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("아윤", "무섭긴 한데....... 뭔가 불쌍하기도 하고 \r\n 나에게 해를 가할 건 같지 않으니깐 일단 도와주자 ",1));
        ChatText.color = Color.black;
            
        yield return StartCoroutine(NormalChat("아윤", ".....",1));
        
        yield return StartCoroutine(NormalChat("아윤", "사실… 보여요….. 그것도 잘 ",1));
        
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("아윤", "그… 밖이라 춥기도 하고 어디에 들어가서 얘기하실래요?",1));

        ColorSet(4);
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[7];
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "여자아이를 따라 도착한 곳은 아이의 집이었다.",0));
        ChatText.color = Color.black;
        
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[1];
        yield return StartCoroutine(NormalChat("아윤", "제가 학생이라서 지금 갈 수 있는 곳이 집밖에 없어요.?",1));
        
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[4];
        yield return StartCoroutine(NormalChat("아윤", "절대로 다른 방 가지 말고 얌전히 제 방에만 있어야 해요…",1));
        
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "띠띠띠띠 띠로리",0));
        
        ChatText.color = Color.black;
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[6];
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[5];
        yield return StartCoroutine(NormalChat("???", "야용~",1));
        
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "집에 들어가자마자 고양이가 여자아이를 반겼다.",0));
        
        yield return StartCoroutine(NormalChat("", "여자 아이는 고양이를 어루만지다, 자기의 방으로 안내했다.",0));
        ChatText.color = Color.black;
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[4];
        
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("아윤", "우리 만나서 통성명도 안 했는데 먼저 통성명이라도 해주실래요?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("태현", "당연하죠, 저는 나태현 , 17살 입니다.",1));
        ColorSet(2);
        yield return StartCoroutine(NormalChat("아윤", "그리고 아까 고양이는 메로에요.",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("태현", "내가 나이가 많으니깐 반말해도 괜찮을까?",1)); 
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("아윤", "내 , 물론이죠",1));
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("아윤", "그래서 무슨 일이 있었던 거에요?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("태현", "그러니까..",1)); 
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "나는 내가 기억나는 일을 예기해주었다.",0)); 
        ChatText.color = Color.black;
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("아윤", "거…ㄱ 거짓말 그런 일이 있다고요? 실제로?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("태현", "보다시피 아 못 보는구나 어쨌든 다른 사람 반응 들어보고 알 수 있었겠지만… 진짜야",1)); 
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("아윤", "저 그래도 어느 정도는 보이거든요!",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("태현", "아, 미안 미안 그런 의미에서 도와줄 수 있을까?",1)); 
        ColorSet(2);
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "아윤이는 잠시 고민하다 말했다.",0));
        ChatText.color = Color.black;
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("아윤", "지금 현재로서는 저 말고는 도와주거나 볼 수 있는 사람이 없는 거 같…죠?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[0];
        yield return StartCoroutine(NormalChat("태현", "일단은. …",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("아윤", "알았어요 도와줄게요.. 근데 저에게 위험하거나 무리인 건 절대 절대 안 할거에요!",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("태현", "내 시체 찾는 걸 도와줄 수 있을까?",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("아윤", "ㅅ,시체요?!",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("태현", "응, 내 시체말이야.",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[3];
        yield return StartCoroutine(NormalChat("아윤", "웬 시체요? 혹시 죽었어요? 유령이에요?",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[3];
        yield return StartCoroutine(NormalChat("태현", "아니.. 확실하진 않아 근대 왠지 있을 것 같아. 그걸 찾으면 돌아올 거 같기도 하고",1));
        ColorSet(2);
        yield return StartCoroutine(NormalChat("아윤", "…. 알았어요 그럼 시체 찾는 동안에는 꼭 저 도와주셔야 돼요. 저도 필요하거든요 또 다른 눈이 필요 하거든요", 1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("태현", "그래 ! 물론이지",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("아윤", "그러면 먼저 저 편의점에 가서 음료수 사는 거 도와주세요. \r\n 멘날 원하는거 못 샀단 말이에요",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[6];
        yield return StartCoroutine(NormalChat("태현", "왜? 그건 점자도 있지 않아?",1));
        ColorSet(2);
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[4];
        yield return StartCoroutine(NormalChat("아윤", ":역시 그렇게 생각하고 있을 줄 알았어. 아쉽게도 제가 읽는 점자에는",1));
        GameManager.Instance.image1.sprite = GameManager.Instance.aYun[0];
        yield return StartCoroutine(NormalChat("아윤", "음료수들은 보통 탄산 아니면 이온 이런 식으로 적혀있어요",1));
        ColorSet(1);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[4];
        yield return StartCoroutine(NormalChat("태현", " 진짜? 처음 알았는데 말 만해 오늘은 내가 도와줄게.",1));
        ColorSet(4);
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5];
        GameManager.Instance.image1.sprite = GameManager.Instance.naTehyeon[5];
        ChatText.color = Color.blue;
        yield return StartCoroutine(NormalChat("", "집 밖으로 나간다", 0));
        
        GameManager.Instance.backGroundImage.sprite = GameManager.Instance.backGround[2];
        yield return StartCoroutine(NormalChat("", "집 밖은 위험해!! 편의점을 가고 싶어하는 아윤이를 위해 편의점 까지 무사하게 대려다 주세요",0));
        ChatText.color = Color.black;
        SceneManager.LoadScene(1);
        
        
        
        
            
        yield return StartCoroutine(NormalChat("아윤", "",1));
        yield return StartCoroutine(NormalChat("태현", "",1));

        
        
        
        
        
        

       
    }
    void Start()
    {
        GameManager.Instance.image2.sprite = GameManager.Instance.naTehyeon[5]; // 삭제 
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
