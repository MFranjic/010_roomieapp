using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;

public class DatabaseManager : MonoBehaviour
{
    private DatabaseReference database;

    public void FindDatabase()
    {
        database = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void FetchAllAlgo()
    {
        if (database == null)
        {
            Debug.Log("ERROR: Database not connected.");
            return;
        }

        database.Child("ALGO_INFO").GetValueAsync().ContinueWithOnMainThread(task =>
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
                List<StudentAlgo> studentAlgoList = new List<StudentAlgo>();
                foreach (DataSnapshot studentAlgo in snapshot.Children)
                {
                    StudentAlgo student = JsonUtility.FromJson<StudentAlgo>(studentAlgo.GetRawJsonValue());
                    //Debug.Log(studentAlgo.Key);
                    student.SetEmail(studentAlgo.Key);
                    studentAlgoList.Add(student);
                }
                gameObject.GetComponent<MatchingManager>().GetStudentsAlgoFromDB(studentAlgoList);
            }
        });
    }

    public void FetchAllQuick()
    {
        if (database == null)
        {
            Debug.Log("ERROR: Database not connected.");
            return;
        }

        database.Child("QUICK_INFO").GetValueAsync().ContinueWithOnMainThread(task =>
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
                List<StudentQuick> studentQuickList = new List<StudentQuick>();
                foreach (DataSnapshot studentQuick in snapshot.Children)
                {
                    StudentQuick student = JsonUtility.FromJson<StudentQuick>(studentQuick.GetRawJsonValue());
                    student.SetEmail(studentQuick.Key);
                    studentQuickList.Add(student);
                }
                gameObject.GetComponent<MatchingManager>().GetStudentsQuickFromDB(studentQuickList);
            }
        });
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
                student.SetEmail(id);
                gameObject.GetComponent<UserManager>().LoadStudentMainFromDatabase(student);
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
                student.SetEmail(id);
                gameObject.GetComponent<UserManager>().LoadStudentAlgoFromDatabase(student);
                return;
            }
        });
    }

    public void FetchDetailsMain(string id)
    {
        if (database == null)
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
                student.SetEmail(id);
                gameObject.GetComponent<MatchingManager>().GetDetailsMainFromDB(student);
                return;
            }
        });
    }

    public void FetchDetailsAlgo(string id)
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
                student.SetEmail(id);
                gameObject.GetComponent<MatchingManager>().GetDetailsAlgoFromDB(student);
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
        //Debug.Log(id);
        //Debug.Log(json);
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
                Debug.Log("Student successfully added to DB.");
            }
        });
    }

    public void ChangeStudentMain(StudentMain student)
    {
        string json = JsonUtility.ToJson(student);
        ChangeStudent("MAIN_INFO", student.GetEmail(), json);
    }

    public void ChangeStudentQuick(StudentQuick student)
    {
        string json = JsonUtility.ToJson(student);
        ChangeStudent("QUICK_INFO", student.GetEmail(), json);
    }

    public void ChangeStudentAlgo(StudentAlgo student)
    {
        string json = JsonUtility.ToJson(student);
        ChangeStudent("ALGO_INFO", student.GetEmail(), json);
    }

    private void ChangeStudent(string table, string id, string json)
    {
        //Debug.Log(id);
        //Debug.Log(json);
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
                Debug.Log("Student successfully changed in DB.");
                gameObject.GetComponent<UserManager>().SetSavingCompleted();
            }
        });
    }
}
