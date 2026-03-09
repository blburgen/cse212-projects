using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with with letters a-f
    // and priority is mixed throughout the queue
    // Expected Result: "b", "d", "f", "c", "e", "a"
    // Defect(s) Found: skipped first item and last item.  It returned the last high priority item thaat was not the first or last item.
    // It did not remove item from queue.  Corrected the following in Dequeue(): 
    // changed starting index to 0 and going to <= in the for loop 
    // removed item from queue before returning
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 4);
        priorityQueue.Enqueue("c", 3);
        priorityQueue.Enqueue("d", 4);
        priorityQueue.Enqueue("e", 2);
        priorityQueue.Enqueue("f", 4);
        string[] expectedResult = ["b", "d", "f", "c", "e", "a"];
        int count = expectedResult.Length;
        int i = 0;
        while (count > 0)
        {

            var next = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], next);
            i++;
            count--;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with with letters a-f
    // and priority increasing throughout the queue
    // Expected Result: "f", "e", "d", "c", "b", "a"
    // Defect(s) Found: skipped first item and last item.  It returned the last high priority item thaat was not the first or last item.
    // It did not remove item from queue.  Corrected the following in Dequeue(): 
    // changed starting index to 0 and going to <= in the for loop 
    // removed item from queue before returning
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 2);
        priorityQueue.Enqueue("c", 3);
        priorityQueue.Enqueue("d", 4);
        priorityQueue.Enqueue("e", 5);
        priorityQueue.Enqueue("f", 6);
        string[] expectedResult = ["f", "e", "d", "c", "b", "a"];
        int count = expectedResult.Length;
        int i = 0;
        while (count > 0)
        {

            var next = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], next);
            i++;
            count--;
        }
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Create a queue with with letters a-f
    // and priority decreasing throughout the queue
    // Expected Result: "a", "b", "c", "d", "e", "f"
    // Defect(s) Found: skipped first item and last item.  It returned the last high priority item thaat was not the first or last item.
    // It did not remove item from queue.  Corrected the following in Dequeue(): 
    // changed starting index to 0 and going to <= in the for loop 
    // removed item from queue before returning
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 6);
        priorityQueue.Enqueue("b", 5);
        priorityQueue.Enqueue("c", 4);
        priorityQueue.Enqueue("d", 3);
        priorityQueue.Enqueue("e", 2);
        priorityQueue.Enqueue("f", 1);
        string[] expectedResult = ["a", "b", "c", "d", "e", "f"];
        int count = expectedResult.Length;
        int i = 0;
        while (count > 0)
        {

            var next = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], next);
            i++;
            count--;
        }
    }

    [TestMethod]
    // Scenario: Create a empty queue and try to dequeue
    // Expected Result: InvalidOperationException with a message of "The queue is empty."
    // Defect(s) Found: none found
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}