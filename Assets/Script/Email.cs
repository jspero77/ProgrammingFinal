using NUnit.Framework;
using TMPro;
using Unity.Hierarchy;
using UnityEditor.VersionControl;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Email : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textInfo;
    public string greetings;
    public string part1;
    public string part2;
    public string part3;
    public string subject;
    public string from;
    public EmailCollection emailCollectionGood;
    public EmailCollection emailCollectionBad;
    public EmailSequence sequence;
    List<EmailData> list;
    public int emailNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        list = new List<EmailData>();
        sequence.GetSequence(list);
        populateEmail(0);
    }
    /*
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            populateEmail(emailCollectionBad);
        }
        if (Input.GetMouseButtonDown(1))
        {
            populateEmail(emailCollectionGood);
        }
    }*/
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            emailNumber++;
            if (emailNumber >= list.Count)
            {
                emailNumber = 0;

            }
                populateEmail(emailNumber);
            
        }
        
    }

    public void populateEmail(int emailNumber)
    {
        this.emailNumber = emailNumber;

        var emailData = list[emailNumber];
        greetings = emailData.greetings[Random.Range(0, emailData.greetings.Length)];
        part1 = emailData.part1s[Random.Range(0, emailData.part1s.Length)];
        part2 = emailData.part2s[Random.Range(0, emailData.part2s.Length)];
        part3 = emailData.part3s[Random.Range(0, emailData.part3s.Length)];
        from = emailData.senderType.ToString();
        subject = emailData.subjects[Random.Range(0, emailData.subjects.Length)];
        text.text = greetings + "\n" + part1 + "\n" + part2 + "\n" + part3;
        textInfo.text = "From: " + from + "\n" + subject;
    }
}
