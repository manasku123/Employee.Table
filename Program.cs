// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


class Employee
{
    public int EmployeeId {get; set;}
    public string Name {get; set;}
    public string Position {get; set;}
    public double Salary {get; set;}
    public DateTime JoinDate {get; set;}

    public Employee(int id, string name, string position, double salary, DateTime joinDate)
    {
        EmployeeId = id;
        Name = name;
        Position = position;
        Salary = salary;
        JoinDate = joinDate;
    }

    public override string ToString()
    {
        return $"{EmployeeId,-10}  {Name,-20}  {Position,-25}  {Salary,-15}  {JoinDate.ToShortDateString(),-10}";
    }
}

class Program
{
    static void Main(string[] args)
    {

        List<Employee> employees = new List<Employee>
        {
            new Employee(1, "Saloni", "SeniorDev.", 55000, new DateTime(2024, 4, 10)),
            new Employee(2, "Prajyot", "SeniorDev.", 60000, new DateTime(2024, 4, 20)),
            new Employee(3, "Ashutosh", "JuniorDev.", 50000, new DateTime(2024, 4, 10)),
            new Employee(4, "Rajat", "Consulting", 40000, new DateTime(2024, 4, 15)),
            new Employee(5, "Rakesh", "JuniorDev.", 50000, new DateTime(2024, 4, 15))
        };


        Console.WriteLine("All employees:");
        PrintEmployeeList(employees);


        Employee secondHighestPaidEmployee = GetSecondHighestPaidEmployee(employees);
        Console.WriteLine("\n  The 2nd highest salary Employee :");
        Console.WriteLine(secondHighestPaidEmployee);


        DateTime startDate = new DateTime(2024, 1, 1);
        DateTime endDate = new DateTime(2024, 5, 31);


        List<Employee> employeesInRange = GetEmployeesInRange(employees, startDate, endDate);
        Console.WriteLine($"\nEmployees joined between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}:");
        PrintEmployeeList(employeesInRange);


        AddEmployee(employees);


        Console.WriteLine("\nList of all employees after adding a new employee:");
        PrintEmployeeList(employees);
    }

    static void AddEmployee(List<Employee> employees)
    {
        Console.WriteLine("Add Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Add Position:");
        string position = Console.ReadLine();
        Console.WriteLine("Add Salary:");
        double salary = double.Parse(Console.ReadLine());
        Console.WriteLine("Add JoinDate (YYYY-MM-DD):");
        DateTime joinDate = DateTime.Parse(Console.ReadLine());

        int newEmployeeId = employees.Count + 1;
        Employee newEmployee = new Employee(newEmployeeId, name, position, salary, joinDate);
        employees.Add(newEmployee);
    }

    static Employee GetSecondHighestPaidEmployee(List<Employee> employees)
    {
        if (employees.Count < 2)
        {
            throw new InvalidOperationException("There are not enough employees to find the second-highest paid employee.");
        }

        Employee highestPaid = employees[0];
        Employee secondHighestPaid = employees[1];

        foreach (var employee in employees)
        {
            if (employee.Salary > highestPaid.Salary)
            {
                secondHighestPaid = highestPaid;
                highestPaid = employee;
            }
            else if (employee.Salary > secondHighestPaid.Salary && employee != highestPaid)
            {
                secondHighestPaid = employee;
            }
        }

        return secondHighestPaid;
    }

    static List<Employee> GetEmployeesInRange(List<Employee> employees, DateTime startDate, DateTime endDate)
    {
        List<Employee> employeesInRange = new List<Employee>();

        foreach (var employee in employees)
        {
            if (employee.JoinDate >= startDate && employee.JoinDate <= endDate)
            {
                employeesInRange.Add(employee);
            }
        }

        return employeesInRange;
    }

    static void PrintEmployeeList(List<Employee> employees)
    {
        Console.WriteLine($"{"ID",-10} {"Name",-20} {"Position",-25} {"Salary",-15} {"Join Date",-10}");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
        Employee employeeWithLowestSalary = GetEmployeeWithLowestSalary(employees);
        Console.WriteLine("\nEmployee with lowest salary:");
        Console.WriteLine(employeeWithLowestSalary);


        UpdateEmployeePositionAndSalary(employeeWithLowestSalary, "Consulting", 45000);


        Console.WriteLine("\nEmployee with update value:");
        Console.WriteLine(employeeWithLowestSalary);
    }

    static Employee GetEmployeeWithLowestSalary(List<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
        {
            Console.WriteLine("List of employees is empty");
        }

        Employee lowestPaidEmployee = employees[0];
        foreach (var employee in employees)
        {
            if (employee.Salary < lowestPaidEmployee.Salary)
            {
                lowestPaidEmployee = employee;
            }
        }
        return lowestPaidEmployee;
    }

    static void UpdateEmployeePositionAndSalary(Employee employee, string newPosition, double newSalary)
    {
        employee.Position = newPosition;
        employee.Salary = newSalary;
    }
}
