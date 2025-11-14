using UnityEngine;

[CreateAssetMenu(menuName = "Data/Email", fileName = "NewEmail.asset")]
public class EmailData : ScriptableObject {
    public SenderType senderType;

    public PhishingType phishingType;

    public string[] subjects;
    public string[] greetings;
    public string[] part1s;
    public string[] part2s;
    public string[] part3s;
}