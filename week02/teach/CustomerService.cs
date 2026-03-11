using System.Reflection;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Test queue size.  if queue size is -10, size will be 10.  If queue size is 0, size will be 10. If the queue size is 10, the size will be 10
        // Expected Result: queue size = 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(-10);
        Console.WriteLine(cs);
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);
        var cs2 = new CustomerService(10);
        Console.WriteLine(cs2);
        // Defect(s) Found: no defects found

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Test queue size. If queue size is 12 and 1
        // Expected Result: queue size will be 12 and 1 
        Console.WriteLine("Test 2");
        
        var cs3 = new CustomerService(12);
        Console.WriteLine(cs3);
        var cs4 = new CustomerService(1);
        Console.WriteLine(cs4);
        // Defect(s) Found: no defects found

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: When adding a customer they are added to the queue.
        // Expected Result: customer added to end of queue 
        Console.WriteLine("Test 3");
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine(cs);
        // Defect(s) Found: no defects found

        Console.WriteLine("=================");

        // Test 4
        // Scenario: When adding a customer to a full queue a error happens.
        // Expected Result: customer added to end of queue 
        Console.WriteLine("Test 4");
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        Console.WriteLine(cs4);
        // Defect(s) Found: An extra person was able to be added.  Changed > in addnewcustomer to >=

        Console.WriteLine("=================");

        // Test 5
        // Scenario: when dequing a customer the first customer is removed
        // Expected Result: customer removed from front of queue 
        Console.WriteLine("Test 5");
        cs.ServeCustomer();
        cs.ServeCustomer();
        Console.WriteLine(cs);
        // Defect(s) Found: returning first person after removal

        Console.WriteLine("=================");

        // Test 6
        // Scenario: when dequing a customer from an empty queue you get an error
        // Expected Result: error 
        Console.WriteLine("Test 6");
        cs4.ServeCustomer();
        cs4.ServeCustomer();
        Console.WriteLine(cs4);
        // Defect(s) Found: returning first person after removal

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
        if (_queue.Count <= 0) {
            Console.WriteLine("Queue is Empty.");
            return;
        } 
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
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