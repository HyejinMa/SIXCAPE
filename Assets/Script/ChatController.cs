using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChatController : MonoBehaviour
{

    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트


    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키

    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
    }

    void Update()
    {
        foreach (var element in skipButton) // 버튼 검사
        {
            if (Input.GetKeyDown(element))
            {
                isButtonClicked = true;
            }
        }
    }


    IEnumerator NormalChat(string narrator, string narration)
    {
        int a = 0;
        CharacterName.text = narrator;
        writerText = "";

        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        //키를 다시 누를 떄 까지 무한정 대기
        while (true)
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;
                break;
            }
            yield return null;
        }
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("전봉지", "아 과제 해야되는데 전공책 놓고 왔네.. 나가기 귀찮은데.."));
        yield return StartCoroutine(NormalChat("전봉지", "길도 잘 모르고.. 선배한테 전화해봐야겠다.."));
        yield return StartCoroutine(NormalChat("선배", "책 놓고 왔다고? 그거 그렇게 필요하지는 않는데.. 니가 정 필요하다면 갔다와."));
        yield return StartCoroutine(NormalChat("선배", "길 모르면 공6 지도 찾아봐. 나도 어딨는지는 잘 모르는데 건물 어딘가에 있을거야."));
        yield return StartCoroutine(NormalChat("선배", "아 맞다. 공6은 시간 늦어지면 나오려면 카드키가 필요하니까 되는대로 빨리 나오고!"));
    }
}


//
//            if (isButtonClicked)
//            {
//                ChatText.text = narration;
//                a = narration.Length; // 버튼 눌리면 그냥 다 출력하게 함
//                isButtonClicked = false;
//            }