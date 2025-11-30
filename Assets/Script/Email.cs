using NUnit.Framework;
using TMPro;
using Unity.Hierarchy;
using UnityEditor.VersionControl;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using static SenderDirectory;

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
    public string Q1;
    public string Q1first;
    public string Q1last;
    public string R1;
    public string R1first;
    public string R1last;
    public string froms;
    public string senderAddress;
    public EmailCollection emailCollectionGood;
    public EmailCollection emailCollectionBad;
    public EmailSequence sequence;
    public SenderDirectory directory;
    List<EmailData> list;
    public int emailNumber;
    public string Q2;
    public string playerName;
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
        subject = emailData.subjects[Random.Range(0, emailData.subjects.Length)];



        foreach (var category in directory.categories)
        {
            if (category.type == emailData.senderType)
            {
                int number = Random.Range(0, category.senders.Length);
                Q1 = category.senders[number].displayName;
                senderAddress = category.senders[number].emailAddress;
                Q1first = category.senders[number].firstName;
                Q1last = category.senders[number].lastName;
                int number2 = Random.Range(0, category.senders.Length);
                if (number == number2)
                {
                    number2 = Random.Range(0, category.senders.Length);
                }
                R1 = category.senders[number2].displayName;
                R1first = category.senders[number2].firstName;
                R1last = category.senders[number2].lastName;
            }
        }
        
        text.text = greetings + "\n" + part1 + "\n" + part2 + "\n" + part3 + "\n" + signoff;
        text.text = text.text.Replace("Q1", Q1);
        text.text = text.text.Replace("Q2", Q1first);
        text.text = text.text.Replace("Q3", Q1last);
        text.text = text.text.Replace("R1", R1);
        text.text = text.text.Replace("R2", R1first);
        text.text = text.text.Replace("R3", R1last);
        text.text = text.text.Replace("P1", playerName);
        textInfo.text = $"From: {Q1} ({senderAddress})\n{subject}";

    }
}
