// See https://aka.ms/new-console-template for more information

int[] lst = new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 7};

LinkedList linkedList = new LinkedList();

foreach(var i in lst)
{
    linkedList.Append(i);
}

// I knew we just needed to updated the pointers, but had trouble keeping track of them.
//
// This is the solution from Leetcode: Note comments below.  

var currNode = linkedList.Head; // Start at the head.  Jump in while loop if head is not null and head is connected to another node
while(currNode != null && currNode.Next != null)
{
    if(currNode.Val == currNode.Next.Val) // if current node's val is equal to the next node's val, the tow are duplicates
    {
        currNode.Next = currNode.Next.Next; // if the two are duplicates, point current node to what the next one is pointing to (i.e. the third one)
    }
    else
    {
        currNode = currNode.Next; // in this case the two are not duplicate, so just move to the next node
    }
}

currNode = linkedList.Head;

while(currNode != null && currNode.Next != null)
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
