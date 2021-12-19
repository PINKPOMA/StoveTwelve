using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeView : MonoBehaviour
{
    public ChallengeItemView challengeItem;
    public RectTransform content;
    
    private void Start()
    {
        AddItem(new JumpChallenge() { Name = "������ ���̴�!", MaxValue = 1 });
        AddItem(new JumpChallenge() { Name = "��ü �", MaxValue = 50 });
        AddItem(new JumpChallenge() { Name = "�� �̰� �ǿ�?", MaxValue = 200 });
        AddItem(new JumpChallenge() { Name = "<size=70><sprite=0></size>ȭ�� �����ѱ�~", MaxValue = 200 });
        AddItem(new JumpChallenge() { Name = "���� �����", MaxValue = 500 });

        AddItem(new MaxFallChallenge() { Name = "���� ���̺�", MaxValue = 10 });
        AddItem(new MaxFallChallenge() { Name = "���� �����", MaxValue = 100 });
        AddItem(new MaxFallChallenge() { Name = "���ʸ��� �ܰ�", MaxValue = 300 });
        AddItem(new MaxFallChallenge() { Name = "ġ�ᰡ �ʿ��� ������ �ɰ��� ���ʸ��� �ܰ��Դϴ�.", MaxValue = 500 });

        AddItem(new BoundChallenge() { Name = "�ٿ �ٿ", MaxValue = 1 });
        AddItem(new BoundChallenge() { Name = "����Ʈ1", MaxValue = 25 });
        AddItem(new BoundChallenge() { Name = "����Ʈ2", MaxValue = 100 });
        AddItem(new BoundChallenge() { Name = "����Ʈ3", MaxValue = 250 });


        AddItem(new ClearTimeChallenge() { Name = "����Ʈ1", MaxValue = 250 });
        AddItem(new ClearTimeChallenge() { Name = "����Ʈ2", MaxValue = 250 });
        AddItem(new ClearTimeChallenge() { Name = "����Ʈ3", MaxValue = 250 });
        AddItem(new ClearTimeChallenge() { Name = "����Ʈ4", MaxValue = 250 });

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
        return $"{MaxValue:D}m �̻� ��������";
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
        return $"{MaxValue:D}�� �̻� ƨ���";
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
        return $"{MaxValue:D}�� ���� Ŭ����";
    }
}