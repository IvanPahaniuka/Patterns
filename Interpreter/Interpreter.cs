using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public static class InterpreterTest
    {
        public static void Test()
        {
            Context context = new Context();
            context.SetValue("x", 2);
            context.SetValue("y", 5);
            context.SetValue("z", 7);

            IExpression expression = new SubtractExpression(
                new AddExpression(
                    new NumberExpression("x"), 
                    new NumberExpression("z")),
                new NumberExpression("y")
                );

            Console.WriteLine($"{context.GetValue("x")} + {context.GetValue("z")} - {context.GetValue("y")} = {expression.Interpret(context)}");
        }
    }

    public class Context
    {
        Dictionary<string, int> variables = new Dictionary<string, int>();

        public int GetValue(string name)
        {
            return variables[name];
        }

        public void SetValue(string name, int value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }
    }

    public interface IExpression
    {
        int Interpret(Context context);
    }

    public class NumberExpression: IExpression
    {
        public string Name { get; set; }

        public NumberExpression(string name)
        {
            Name = name;
        }

        public int Interpret(Context context)
        {
            return context.GetValue(Name);
        }
    }

    public class AddExpression : IExpression
    {
        public IExpression Left { get; protected set; }
        public IExpression Right { get; protected set; }

        public AddExpression(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        public int Interpret(Context context)
        {
            return Left.Interpret(context) + Right.Interpret(context);
        }
    }

    public class SubtractExpression : IExpression
    {
        public IExpression Left { get; protected set; }
        public IExpression Right { get; protected set; }

        public SubtractExpression(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        public int Interpret(Context context)
        {
            return Left.Interpret(context) - Right.Interpret(context);
        }
    }
}
