using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;

public class MatchingDB : MonoBehaviour
{
    private DatabaseReference database;

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
        database = GameObject.Find("SceneManager").GetComponent<DatabaseManager>().GetDatabase();

        database.Child("MATCHING").Child(main).Child(state).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("FirebaseDatabaseError: IsCanceled: " + task.Exception);
                return;
            }

            if (task.IsFaulted)
            {
                Debug.Log("FirebaseDatabaseError: IsFaulted:" + task.Exception);
                return;
            }
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string others = (string)snapshot.GetValue(true);
                //Debug.Log(others);
                if(string.IsNullOrEmpty(others))
                {
                    others = other;
                }
                else
                {
                    others += "-" + other;
                }               
                database.Child("MATCHING").Child(main).Child(state).SetValueAsync(others);
                return;
            }
        });
    }

    private void Remove(string main, string other, string state)
    {
        database = GameObject.Find("SceneManager").GetComponent<DatabaseManager>().GetDatabase();

        database.Child("MATCHING").Child(main).Child(state).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("FirebaseDatabaseError: IsCanceled: " + task.Exception);
                return;
            }

            if (task.IsFaulted)
            {
                Debug.Log("FirebaseDatabaseError: IsFaulted:" + task.Exception);
                return;
            }
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string others = (string)snapshot.GetValue(true);
                string newOthers = "";
                string[] othersList = others.Split('-');
                foreach(string user in othersList)
                {
                    if (!user.Equals(other))
                    {
                        newOthers += "-" + user;
                    }
                }
                Debug.Log(newOthers);
                database.Child("MATCHING").Child(main).Child(state).SetValueAsync(newOthers);
                return;
            }
        });
    }

    public void FetchAtMatching(string user, string state)
    {
        database = GameObject.Find("SceneManager").GetComponent<DatabaseManager>().GetDatabase();

        database.Child("MATCHING").Child(user).Child(state).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("FirebaseDatabaseError: IsCanceled: " + task.Exception);
                return;
            }

            if (task.IsFaulted)
            {
                Debug.Log("FirebaseDatabaseError: IsFaulted:" + task.Exception);
                return;
            }
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string others = (string)snapshot.GetValue(true);
                Debug.Log(others);
                string[] othersList = others.Split('-');
                gameObject.GetComponent<CurrentMatchesManager>().LoadCurrentMatches(state, othersList);
                return;
            }
        });
    }

    public void FetchStudentQuick(string id, string state)
    {
        database = GameObject.Find("SceneManager").GetComponent<DatabaseManager>().GetDatabase();

        //Debug.Log(id + ", " + state);
        StudentQuick student = null;
        database.Child("QUICK_INFO").Child(id).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("FirebaseDatabaseError: IsCanceled: " + task.Exception);
                return;
            }

            if (task.IsFaulted)
            {
                Debug.Log("FirebaseDatabaseError: IsFaulted:" + task.Exception);
                return;
            }
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                student = JsonUtility.FromJson<StudentQuick>(snapshot.GetRawJsonValue());
                student.SetEmail(id);
                gameObject.GetComponent<CurrentMatchesManager>().LoadCurrentMatchesQuickInfo(state, student);
                return;
            }
        });
    }
}
