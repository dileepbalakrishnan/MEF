using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MethodExports
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(assemblyCatalog);

            var calculator = container.GetExportedValue<Calculator>();
            while (true)
            {
                Console.Write("Enter an expression (+, -, / or *) :");
                var expression = Console.ReadLine();
                Console.WriteLine($"Result = {calculator.Calculate(expression)}");
            }
        }
    }

    public class CalculationModel
    {
        public int Input1 { get; set; }
        public int Input2 { get; set; }
        public string Operation { get; set; }
    }

    public class CalculationHelpers
    {
        [Export("ExpressionParser")]
        public CalculationModel Parse(string expression)
        {
            var regEx = new Regex(@"(\d+)(.)(\d+)");
            var match = regEx.Match(expression);
            return new CalculationModel
            {
                Input1 = int.Parse(match.Groups[1].Value),
                Input2 = int.Parse(match.Groups[3].Value),
                Operation = match.Groups[2].Value
            };
        }
    }

    public class Operations
    {
        [Export]
        [ExportMetadata("Operation", "+")]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [Export]
        [ExportMetadata("Operation", "-")]
        public int Substract(int a, int b)
        {
            return a - b;
        }

        [Export]
        [ExportMetadata("Operation", "/")]
        public int Divide(int a, int b)
        {
            return a / b;
        }

        [Export]
        [ExportMetadata("Operation", "*")]
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
    [Export]
    public class Calculator
    {
        [Import("ExpressionParser")] private Func<string, CalculationModel> _calculationParser;
        [ImportMany] private IEnumerable<Lazy<Func<int, int, int>, Dictionary<string, object>>> _operations;

        public int Calculate(string expression)
        {
            var model = _calculationParser(expression);
            var operation = _operations.First(o => o.Metadata["Operation"].ToString() == model.Operation);
            var result = operation.Value(model.Input1, model.Input2);
            return result;
        }
    }
}