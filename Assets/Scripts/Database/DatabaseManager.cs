using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;

public class DatabaseManager : MonoBehaviour
{
    private DatabaseReference database;

    private void Start()
    {
        database = FirebaseDatabase.DefaultInstance.RootReference;

    }

    public void FetchStudentMain(string id)
    {       
        if(database == null)
        {
            Debug.Log("ERROR: Database not connected.");
            return;
        }

        StudentMain student = null;
        database.Child("MAIN_INFO").Child(id).GetValueAsync().ContinueWithOnMainThread(task =>
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
                student = JsonUtility.FromJson<StudentMain>(snapshot.GetRawJsonValue());
                gameObject.GetComponent<MyProfileManager>().LoadStudentMainFromDatabase(student);
                return;
            }
        });
    }

    public void FetchStudentAlgo(string id)
    {
        StudentAlgo student = null;
        database.Child("ALGO_INFO").Child(id).GetValueAsync().ContinueWithOnMainThread(task =>
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
                student = JsonUtility.FromJson<StudentAlgo>(snapshot.GetRawJsonValue());
                gameObject.GetComponent<MyProfileManager>().LoadStudentAlgoFromDatabase(student);
                return;
            }
        });
    }

    public void AddStudentMain(StudentMain student)
    {
        string json = JsonUtility.ToJson(student);
        AddStudent("MAIN_INFO", student.GetEmail(), json);
    }

    public void AddStudentQuick(StudentQuick student)
    {
        string json = JsonUtility.ToJson(student);
        AddStudent("QUICK_INFO", student.GetEmail(), json);
    }

    public void AddStudentAlgo(StudentAlgo student)
    {
        string json = JsonUtility.ToJson(student);
        AddStudent("ALGO_INFO", student.GetEmail(), json);
    }

    private void AddStudent(string table, string id, string json)
    {
        database.Child(table).Child(id).SetRawJsonValueAsync(json).ContinueWithOnMainThread((task) =>
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
                Debug.Log("SUCCESS");
            }
        });
    }
}
