using NUnit.Framework;
using TMPro;
using Unity.Hierarchy;
using UnityEditor.VersionControl;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class Email : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textInfo;
    public string greetings;
    public string part1;
    public string part2;
    public string part3;
    public string subject;
    public string signoff;
    public string from;
    public string froms;
    public string senderAddress;
    public EmailCollection emailCollectionGood;
    public EmailCollection emailCollectionBad;
    public EmailSequence sequence;
    public SenderDirectory directory;
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
        signoff = emailData.signoffs[Random.Range(0, emailData.signoffs.Length)];
        from = emailData.senderType.ToString();
        subject = emailData.subjects[Random.Range(0, emailData.subjects.Length)];
        
        foreach(var category in directory.categories)
        {
            if (category.type == emailData.senderType)
            {
                int number = Random.Range(0, category.senders.Length);
                from = category.senders[number].displayName;
                senderAddress = category.senders[number].emailAddress;
            }
        }
        signoff = signoff.Replace("Q1", from);
        text.text = greetings + "\n" + part1 + "\n" + part2 + "\n" + part3 + "\n" + signoff;
        textInfo.text = $"From: {from} ({senderAddress})\n{subject}";

    }
}
