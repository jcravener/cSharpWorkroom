// See https://aka.ms/new-console-template for more information

int[] lst = new int[] { 1, 2, 2, 3, 4, 5, 5, 5, 5};

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

currNode = returnList.Head;
while(currNode.Next != null)
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
    
    public LinkedList()
    {
        Head = new ListNode();
    }

    public void Append(int data)
    {
        var newNode = new ListNode
        { 
            Val = data
        };
        var curr = Head;
        while(curr.Next != null)
        {
            curr = curr.Next;
        }
        curr.Next = newNode;
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