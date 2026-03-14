using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Original code had no empty check at all — it crashed with an
    // IndexOutOfRangeException instead of throwing InvalidOperationException.
    public void TestDequeue_EmptyQueue()
    {
        var queue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue(), "The queue is empty.");
    }

    [TestMethod]
    // Scenario: Enqueue one item, then dequeue
    // Expected Result: The same item is returned, queue becomes empty
    // Defect(s) Found: Original code did not call RemoveAt, so the item was returned
    // but never actually removed. The queue never became empty.
    public void TestDequeue_SingleItem()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        var result = queue.Dequeue();
        Assert.AreEqual("A", result);
        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with different priorities
    // Expected Result: Highest priority item (largest number) is returned first
    // Defect(s) Found: Original loop did not check all items correctly, so the
    // highest priority item was not always found and returned.
    public void TestDequeue_DifferentPriorities()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Low", 1);
        queue.Enqueue("Medium", 5);
        queue.Enqueue("High", 10);
        queue.Enqueue("AnotherLow", 2);
        Assert.AreEqual("High", queue.Dequeue());
        Assert.AreEqual("Medium", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same highest priority
    // Expected Result: The first one enqueued among those with highest priority is returned (FIFO)
    // Defect(s) Found: Original code used >= instead of >, which meant the last item
    // with the highest priority was removed instead of the first (broke FIFO ordering).
    public void TestDequeue_SamePriorityFIFO()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("First", 5);
        queue.Enqueue("Second", 3);
        queue.Enqueue("Third", 5);
        queue.Enqueue("Fourth", 1);
        Assert.AreEqual("First", queue.Dequeue());
        Assert.AreEqual("Third", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Ensure that after dequeue the item is actually removed
    // Expected Result: Count decreases and item is no longer present
    // Defect(s) Found: Original code did not call RemoveAt, so dequeued items
    // remained in the list and the queue never shrank.
    public void TestDequeue_RemovesItem()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 2);
        queue.Dequeue();
        Assert.AreEqual("A", queue.Dequeue());
    }
}