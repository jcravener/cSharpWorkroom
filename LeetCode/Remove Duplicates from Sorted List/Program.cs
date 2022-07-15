// See https://aka.ms/new-console-template for more information

int[] lst = new int[] { 1, 2, 3, 4, 5};

ListNode head = new ListNode();

foreach(var i in lst)
{
    head.Val = i;
    var newNode = new ListNode();
    newNode.Next = head;
    head = newNode;
}

var currNode = head;
while(currNode.Next != null)
{
    Console.WriteLine(currNode.Val);
    currNode = currNode.Next;
}

// Definition for singly-linked list.
public class ListNode
{
    public int Val { get; set; } = 500;
    public ListNode? Next { get; set; } = null;
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