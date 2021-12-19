using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeView : MonoBehaviour
{
    public ChallengeItemView challengeItem;
    public RectTransform content;
    
    private void Start()
    {
        AddItem(new JumpChallenge() { Name = "시작이 반이다!", MaxValue = 1 });
        AddItem(new JumpChallenge() { Name = "하체 운동", MaxValue = 50 });
        AddItem(new JumpChallenge() { Name = "와 이게 되요?", MaxValue = 200 });
        AddItem(new JumpChallenge() { Name = "<size=70><sprite=0></size>화성 갈끄닌깐~", MaxValue = 200 });
        AddItem(new JumpChallenge() { Name = "떡상 가즈아", MaxValue = 500 });

        AddItem(new MaxFallChallenge() { Name = "최초 다이빙", MaxValue = 10 });
        AddItem(new MaxFallChallenge() { Name = "떡락 가즈아", MaxValue = 100 });
        AddItem(new MaxFallChallenge() { Name = "태초마을 단골", MaxValue = 300 });
        AddItem(new MaxFallChallenge() { Name = "치료가 필요할 정도로 심각한 태초마을 단골입니다.", MaxValue = 500 });

        AddItem(new BoundChallenge() { Name = "바운스 바운스", MaxValue = 1 });
        AddItem(new BoundChallenge() { Name = "퀘스트1", MaxValue = 25 });
        AddItem(new BoundChallenge() { Name = "퀘스트2", MaxValue = 100 });
        AddItem(new BoundChallenge() { Name = "퀘스트3", MaxValue = 250 });


        AddItem(new ClearTimeChallenge() { Name = "퀘스트1", MaxValue = 250 });
        AddItem(new ClearTimeChallenge() { Name = "퀘스트2", MaxValue = 250 });
        AddItem(new ClearTimeChallenge() { Name = "퀘스트3", MaxValue = 250 });
        AddItem(new ClearTimeChallenge() { Name = "퀘스트4", MaxValue = 250 });

    }

    public void AddItem(Challenge challenge)
    {
        var item = Instantiate(challengeItem, content);
        item.Name = challenge.Name;
        item.Value = challenge.GetText();
        item.Clear(challenge.IsClear);

    }
}
public abstract class Challenge
{
    public string Name { get; set; }
    public int MaxValue { get; set; }
    public virtual int Value { get; set; }
    public virtual bool IsClear { get; }

    public abstract string GetText();

}

public class JumpChallenge : Challenge
{
    public JumpChallenge()
    {
        Value = PlayerPrefs.GetInt("Jump",0);
    }

    public override bool IsClear
    {
        get => MaxValue <= Value;
    }

    public override string GetText()
    {
        return $"{Value}/{MaxValue}";
    }
}

public class MaxFallChallenge : Challenge
{
    public MaxFallChallenge()
    {
        Value = PlayerPrefs.GetInt("MaxFall",0);
    }


    public override string GetText()
    {
        return $"{MaxValue:D}m 이상 떨어지기";
    }
}

public class BoundChallenge : Challenge
{
    public BoundChallenge()
    {
        Value = PlayerPrefs.GetInt("Bound", 0);
    }


    public override string GetText()
    {
        return $"{MaxValue:D}번 이상 튕기기";
    }
}


public class ClearTimeChallenge : Challenge
{
    public ClearTimeChallenge()
    {
        Value = PlayerPrefs.GetInt("ClearMinTime", 0);
    }


    public override string GetText()
    {
        return $"{MaxValue:D}초 내에 클리어";
    }
}