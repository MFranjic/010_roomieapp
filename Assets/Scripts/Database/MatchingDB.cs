using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingDB : MonoBehaviour
{
    public void Pin(string sender, string receiver)
    {
        // sender: ADD reciever to PINNED

        Add(sender, receiver, "PINNED");
    }

    public void UnPin(string sender, string receiver)
    {
        // sender: REMOVE reciever from PINNED

        Remove(sender, receiver, "PINNED");
    }

    public void Request(string sender, string receiver)
    {
        // sender: ADD reciever to REQUESTED
        // reciever: ADD sender to PENDING

        Add(sender, receiver, "REQUESTED");
        Add(receiver, sender, "PENDING");
    }

    public void UnRequest(string sender, string receiver)
    {
        // sender: REMOVE reciever from REQUESTED
        // reciever: REMOVE sender from PENDING

        Remove(sender, receiver, "REQUESTED");
        Remove(receiver, sender, "PENDING");
    }

    public void DeclineRequest(string sender, string receiver)
    {
        // sender: REMOVE reciever from PENDING
        // reciever: REMOVE sender from REQUESTED

        Remove(sender, receiver, "PENDING");
        Remove(receiver, sender, "REQUESTED");
    }

    public void AcceptRequest(string sender, string receiver)
    {
        // sender: REMOVE reciever from PENDING
        //          ADD reciver to ACCEPTED
        // reciever: REMOVE sender from REQUESTED
        //          ADD sender to ACCEPTED

        Remove(sender, receiver, "PENDING");
        Add(sender, receiver, "ACCEPTED");
        Remove(receiver, sender, "REQUESTED");
        Add(receiver, sender, "ACCEPTED");        
    }

    private void Add(string main, string other, string state)
    {

    }

    private void Remove(string main, string other, string state)
    {

    }
}
