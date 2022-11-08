using System.Security.Cryptography.X509Certificates;


public enum Operation
{
    Sum,
    Subtract,
    Multiply
}
public class OperationManager
{
    private int _first;
    private int _second;
    private ExecutionManager _executionManager;
    public OperationManager(int first, int second)
    {
        _first = first;
        _second = second;
        _executionManager = new ExecutionManager(this);
    }
    public int Sum()
    {
        return _first + _second;
    }
    public int Subtract()
    {
        return _first - _second;
    }
    public int Multiply()
    {
        return _first * _second;
    }
    public int Execute(Operation operation)
    {
        return _executionManager.FuncExecute[operation].Invoke();
    }
}

//Implement functionality
public class ExecutionManager
{
    public Dictionary<Operation, Func<int>> FuncExecute { get; set; }
    //Add delegates for sum, substrat and multiply here
    private OperationManager _operationManager;

    public ExecutionManager(OperationManager operationManager)
    {
        _operationManager = operationManager;
        FuncExecute = new Dictionary<Operation, Func<int>>();
        PrepareExecution();
    }

    public void PopulateFunctions(Operation op, Func<int> func)
    {
        FuncExecute.Add(op, func);
    }
    public void PrepareExecution()
    {
        FuncExecute.Add(Operation.Sum, _operationManager.Sum);
        FuncExecute.Add(Operation.Subtract, _operationManager.Subtract);
        FuncExecute.Add(Operation.Multiply, _operationManager.Multiply);
        //fill dictionary here
    }
}

class Program
{
    static void Main(string[] args)
    {
        var opManager = new OperationManager(20, 10);
        
        Console.WriteLine($"The result of the operation Sum is {opManager.Execute(Operation.Sum)}");
        Console.WriteLine($"The result of the operation Substract is {opManager.Execute(Operation.Subtract)}");
        Console.WriteLine($"The result of the operation Multiply is {opManager.Execute(Operation.Multiply)}");
        Console.ReadKey();
    }
}