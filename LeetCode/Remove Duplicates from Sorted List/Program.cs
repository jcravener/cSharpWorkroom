// See https://aka.ms/new-console-template for more information

int[] lst = new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 7};

LinkedList linkedList = new LinkedList();

foreach(var i in lst)
{
    linkedList.Append(i);
}

LinkedList returnList = new LinkedList();
HashSet<int> set = new HashSet<int>();

var currNode = linkedList.Head;
while(currNode.Next != null)
{
    currNode = currNode.Next;

    if (!set.Contains(currNode.Val))
    {
        set.Add(currNode.Val);

        returnList.Append(currNode.Val);
    }
}

currNode = linkedList.Head;
while (currNode.Next != null)
{
    currNode = currNode.Next;
    Console.WriteLine(currNode.Val);
}

Console.WriteLine("------");

currNode = returnList.Head;
while(currNode.Next != null)
{
    currNode = currNode.Next;
    Console.WriteLine(currNode.Val);
}

Console.WriteLine("------");

currNode = linkedList.Head;
var savedNode = new ListNode();
set.Clear();
while (currNode.Next != null)
{
    currNode = currNode.Next;

    if (!set.Contains(currNode.Val)) // We have not seen this one yet
    {
        set.Add(currNode.Val);
        savedNode = currNode;
    }

    // we have seen this one, so check the other one

    // As soon as we see a new one, point the save one to the new one
}

Console.WriteLine("------");


currNode = linkedList.Head;
while (currNode.Next != null)
{
    currNode = currNode.Next;
    Console.WriteLine(currNode.Val);
}


// Definition for singly-linked list node.
public class ListNode
{
    public int Val { get; set; }
    public ListNode? Next { get; set; } = null;
}

public class LinkedList
{
    public ListNode Head { get; set; }
    public ListNode Tail { get; set; }
    
    public LinkedList()
    {
        Head = new ListNode();
        Tail = Head;
    }

    public void Append(int data)
    {
        var newNode = new ListNode
        { 
            Val = data
        };
        Tail.Next = newNode;
        Tail = newNode;
    }
}
public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        while(head.Next != null)
        {

        }

        return new ListNode();
    }
}