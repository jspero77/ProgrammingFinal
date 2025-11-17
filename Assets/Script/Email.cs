using TMPro;
using Unity.Hierarchy;
using UnityEditor.VersionControl;
using UnityEngine;

public class Email : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string part1;
    public string part2;
    public string part3;
    public EmailData emailData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            part1 = emailData.part1s[Random.Range(0, emailData.part1s.Length)];
            part2 = emailData.part2s[Random.Range(0, emailData.part2s.Length)];
            part3 = emailData.part3s[Random.Range(0, emailData.part3s.Length)];
            text.text = part1 + "\n" + part2 + "\n" + part3;
        }
    }
}
