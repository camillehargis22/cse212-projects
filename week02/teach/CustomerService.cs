/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Does the max size default to 10 when input is 0 or less?
        // Expected Result: 
        Console.WriteLine("Test 1");
        var serve = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {serve}");

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Adding and serving 1 customer
        // Expected Result: Display customer added
        Console.WriteLine("Test 2");
        serve = new CustomerService(4);
        serve.AddNewCustomer();
        serve.ServeCustomer();

        // Defect(s) Found: 
        // - get customer info before removing customer

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Serve a customer when no customer
        // Expected Result: Display an error message
        Console.WriteLine("Test 3");
        serve = new CustomerService(4);
        serve.ServeCustomer();

        // Defect(s) Found: 
        // - need to check queue size and display error message

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Serving customers in correct order
        // Expected Result: Display customer in order of adding
        Console.WriteLine("Test 4");
        serve = new CustomerService(4);
        serve.AddNewCustomer();
        serve.AddNewCustomer();
        serve.AddNewCustomer();
        Console.WriteLine($"In Queue: {serve}");
        serve.ServeCustomer();
        serve.ServeCustomer();
        serve.ServeCustomer();
        Console.WriteLine($"Queue empty: {serve}");

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Adding more customers than queue size
        // Expected Result: An error message display.
        Console.WriteLine("Test 5");
        serve = new CustomerService(2);
        serve.AddNewCustomer();
        serve.AddNewCustomer();
        serve.AddNewCustomer();
        Console.WriteLine($"Queue: {serve}");

        // Defect(s) Found: 
        // - had to change > to >= when comparing queue length and max size

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("There are no customers in the queue.");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            
            Console.WriteLine(customer);   
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}