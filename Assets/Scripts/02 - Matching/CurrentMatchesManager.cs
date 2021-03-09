using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentMatchesManager : MonoBehaviour
{
    public Transform acceptedSpawn;
    public Transform requestedSpawn;
    public Transform pendingSpawn;
    public Transform pinnedSpawn;

    public GameObject personPrefab;

    private string userID;

    private string[] pinnedUsers;
    private string[] pendingUsers;
    private string[] requestedUsers;
    private string[] acceptedUsers;

    private List<StudentQuick> pinnedUsersQuick;
    private List<StudentQuick> pendingUsersQuick;
    private List<StudentQuick> requestedUsersQuick;
    private List<StudentQuick> acceptedUsersQuick;

    private bool loading = false;

    private void Start()
    {
        pinnedUsersQuick = new List<StudentQuick>();
        pendingUsersQuick = new List<StudentQuick>();
        requestedUsersQuick = new List<StudentQuick>();
        acceptedUsersQuick = new List<StudentQuick>();
    }

    public void LoadCurrentMatches(string state, string[] users)
    {
        if (users.Length == 1 && string.IsNullOrWhiteSpace(users[0]))
        {
            loading = false;
            return;
        }
        switch(state)
        {
            case "PINNED":
                pinnedUsers = users;
                loading = false;
                return;
            case "PENDING":
                pendingUsers = users;
                loading = false;
                return;
            case "REQUESTED":
                requestedUsers = users;
                loading = false;
                return;
            case "ACCEPTED":
                acceptedUsers = users;
                loading = false;
                return;
        }
    }

    public void LoadCurrentMatchesQuickInfo(string state, StudentQuick user)
    {
        switch (state)
        {
            case "PINNED":
                pinnedUsersQuick.Add(user);
                loading = false;
                return;
            case "PENDING":
                pendingUsersQuick.Add(user);
                loading = false;
                return;
            case "REQUESTED":
                requestedUsersQuick.Add(user);
                loading = false;
                return;
            case "ACCEPTED":
                acceptedUsersQuick.Add(user);
                loading = false;
                return;
        }
    }

    public void LoadState()
    {
        userID = GameObject.Find("SceneManager").GetComponent<MatchingManager>().GetCurrentUser();
        StartCoroutine(LoadMatchedUsers());
    }

    IEnumerator LoadMatchedUsers()
    {
        loading = true;
        gameObject.GetComponent<MatchingDB>().FetchAtMatching(userID, "PINNED");
        yield return new WaitWhile(() => loading == true);

        loading = true;
        gameObject.GetComponent<MatchingDB>().FetchAtMatching(userID, "PENDING");
        yield return new WaitWhile(() => loading == true);

        loading = true;
        gameObject.GetComponent<MatchingDB>().FetchAtMatching(userID, "REQUESTED");
        yield return new WaitWhile(() => loading == true);

        loading = true;
        gameObject.GetComponent<MatchingDB>().FetchAtMatching(userID, "ACCEPTED");
        yield return new WaitWhile(() => loading == true);
        

        StartCoroutine(LoadMatchedUsersQuickInfo());
    }

    IEnumerator LoadMatchedUsersQuickInfo()
    {
        if (pinnedUsers != null)
        {
            foreach (string pinnedUser in pinnedUsers)
            {
                loading = true;
                gameObject.GetComponent<MatchingDB>().FetchStudentQuick(pinnedUser, "PINNED");
                yield return new WaitWhile(() => loading == true);
            }
        }

        if(pendingUsers != null)
        {
            foreach (string pendingUser in pendingUsers)
            {
                loading = true;
                gameObject.GetComponent<MatchingDB>().FetchStudentQuick(pendingUser, "PENDING");
                yield return new WaitWhile(() => loading == true);
            }
        }

        if (requestedUsers != null)
        {
            foreach (string requestedUser in requestedUsers)
            {
                loading = true;
                gameObject.GetComponent<MatchingDB>().FetchStudentQuick(requestedUser, "REQUESTED");
                yield return new WaitWhile(() => loading == true);
            }
        }

        if (acceptedUsers != null)
        {
            foreach (string acceptedUser in acceptedUsers)
            {
                loading = true;
                gameObject.GetComponent<MatchingDB>().FetchStudentQuick(acceptedUser, "ACCEPTED");
                yield return new WaitWhile(() => loading == true);
            }
        }

        InitializeSmallPeople();
    }

    private void InitializeSmallPeople()
    {
        SpawnItems(pinnedUsersQuick, pinnedSpawn);
        SpawnItems(pendingUsersQuick, pendingSpawn);
        SpawnItems(requestedUsersQuick, requestedSpawn);
        SpawnItems(acceptedUsersQuick, acceptedSpawn);
    }

    private void SpawnItems(List<StudentQuick> studentList, Transform spawnPoint)
    {
        foreach (StudentQuick student in studentList)
        {
            GameObject SpawnedItem = Instantiate(personPrefab, spawnPoint.localPosition, spawnPoint.rotation);
            SpawnedItem.transform.SetParent(spawnPoint, false);
            SpawnedItem.GetComponent<SmallPersonScript>().SetPersonData(student.GetEmail(), student);
        }
    }
}
