using UnityEngine;

[CreateAssetMenu(fileName = "SenderData", menuName = "Email Data/Sender")]
public class SenderData : ScriptableObject
{
    public SenderType type;
    public string displayName;
    public string emailAddress;
    public Sprite emailProfile;
}
