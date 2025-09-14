using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Make sure Enqueue adds to the back
    // Expected Result: Purple: 3, Green: 2, Blue: 4, Pink: 1
    // Defect(s) Found: Added the GetValue function to test the order of the list when using Enqueue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        // Create Priority Items
        var purple = new PriorityItem("Purple", 3);
        var green = new PriorityItem("Green", 2);
        var blue = new PriorityItem("Blue", 4);
        var pink = new PriorityItem("Pink", 1);

        // expected results
        PriorityItem[] expectedResult = [purple, green, blue, pink];

        // Add each item to priority queue
        priorityQueue.Enqueue(purple.Value, purple.Priority);
        priorityQueue.Enqueue(green.Value, green.Priority);
        priorityQueue.Enqueue(blue.Value, blue.Priority);
        priorityQueue.Enqueue(pink.Value, pink.Priority);

        // Loop through priority queue to make sure values are saved as expected
        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.GetValue(i);
            Assert.AreEqual(expectedResult[i].Value, item);
        }
    }

    [TestMethod]
    // Scenario: Test the Dequeue works by dequeueing the highest priority
    // Expected Result: Blue: 4, Purple: 3, Green: 2, Pink: 1
    // Defect(s) Found: Dequeue function did not remove the value
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        // Create Priority Items
        var purple = new PriorityItem("Purple", 3);
        var green = new PriorityItem("Green", 2);
        var blue = new PriorityItem("Blue", 4);
        var pink = new PriorityItem("Pink", 1);

        // expected results
        PriorityItem[] expectedResult = [blue, purple, green, pink];

        // Add each item to priority queue
        priorityQueue.Enqueue(purple.Value, purple.Priority);
        priorityQueue.Enqueue(green.Value, green.Priority);
        priorityQueue.Enqueue(blue.Value, blue.Priority);
        priorityQueue.Enqueue(pink.Value, pink.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, value);
        }
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Test the queue is empty
    // Expected Result: The queue is empty message
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        // expected results
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

     [TestMethod]
    // Scenario: Test the Dequeue works by dequeueing the highest priority with multiple of the same priority
    // Expected Result: Blue: 4, Purple: 3, Orange: 3, Green: 2, Red: 2, Pink: 1
    // Defect(s) Found: The if statement in the loop in dequeue needed to be just > rather than >=. The loop also needed to start at 0 and be less than the Count rather than the Count - 1.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        // Create Priority Items
        var purple = new PriorityItem("Purple", 3);
        var green = new PriorityItem("Green", 2);
        var blue = new PriorityItem("Blue", 4);
        var pink = new PriorityItem("Pink", 1);
        var red = new PriorityItem("Red", 2);
        var orange = new PriorityItem("Orange", 3);

        // expected results
        PriorityItem[] expectedResult = [blue, purple, orange, green, red, pink];

        // Add each item to priority queue
        priorityQueue.Enqueue(purple.Value, purple.Priority);
        priorityQueue.Enqueue(green.Value, green.Priority);
        priorityQueue.Enqueue(blue.Value, blue.Priority);
        priorityQueue.Enqueue(pink.Value, pink.Priority);
        priorityQueue.Enqueue(red.Value, red.Priority);
        priorityQueue.Enqueue(orange.Value, orange.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, value);
        }
    }
}