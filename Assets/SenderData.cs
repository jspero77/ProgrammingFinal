using UnityEngine;

[CreateAssetMenu(fileName = "SenderData", menuName = "Email Data/Sender")]
public class SenderData : ScriptableObject
{
    public SenderType type;
    public string displayName;
    public string firstName;
    public string lastName;
    public string emailAddress;
    public Sprite emailProfile;
}
