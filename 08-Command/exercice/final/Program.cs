using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace _08.Command
{
    // CODER ICI

    class CLI
    {
        private Stack<CommandBase> _history;
        private Calculator _calculator;

        public CLI()
        {
            _calculator = new Calculator();
            _history = new Stack<CommandBase>();
        }
        
        public void Compute(char p0, int p1)
        {
           
        }

        public int Result()
        {
            return _calculator.Result;
        }

        public void Undo()
        {
            var cmd = _history.Pop();
            cmd.Undo();
        }
    }

    abstract class CommandBase
    {
        public abstract void Do();
        public abstract void Undo();
    }

    class MultiplyCommand : CommandBase
    {
        private readonly Calculator _calc;
        private readonly int _value;

        public MultiplyCommand(Calculator calc, int value)
        {
            _calc = calc;
            _value = value;
        }
        
        public override void Do()
        {
            _calc.Multiply(_value);
        }

        public override void Undo()
        {
            _calc.Divide(_value);
        }
    }

    class SumCommand : CommandBase
    {
        private readonly Calculator _calc;
        private readonly int _value;

        public SumCommand(Calculator calc, int value)
        {
            _calc = calc;
            _value = value;
        }
        
        public override void Do()
        {
            _calc.Plus(_value);
        }

        public override void  Undo()
        {
            _calc.Minus(_value);
        }
    }

    public class Calculator
    {
        public int Result { get; private set; }

        public void Plus(int v)
        {
            Result = Result + v;
        }
        
        public void Minus(int v)
        {
            Result = Result - v;
        }
        
        public void Multiply(int v)
        {
            Result = Result * v;
        }
        
        public void Divide(int v)
        {
            Result = Result / v;
        }
    }

    public class Enonce
    {  
             
       [Fact]
        public void _01_Creer_une_classe_Calculator_avec_une_methode_Plus_et_Minus_et_Multiply_et_Divide()
        {
            Calculator calculator = new Calculator();

            Assert.Equal(0, calculator.Result);

            calculator.Plus(4);

            Assert.Equal(4, calculator.Result);

            calculator.Minus(1);

            Assert.Equal(3, calculator.Result);

            calculator.Multiply(2);

            Assert.Equal(6, calculator.Result);

            calculator.Divide(3);

            Assert.Equal(2, calculator.Result);
        }


        [Fact]
        public void _02_Creer_une_classe_SumCommand_avec_une_methode_Do_et_Undo()
        {
            Calculator calculator = new Calculator();

            SumCommand sum = new SumCommand(calculator, 10);

            Assert.Equal(0, calculator.Result);

            sum.Do();

            Assert.Equal(10, calculator.Result);

            sum.Undo();

            Assert.Equal(0, calculator.Result);
        }


        [Fact]
        public void _03_Creer_une_classe_MultiplyCommand_avec_une_methode_Do_et_Undo()
        {
            Calculator calculator = new Calculator();

            SumCommand sum = new SumCommand(calculator, 5);

            MultiplyCommand multiply = new MultiplyCommand(calculator, 10);

            Assert.Equal(0, calculator.Result);

            sum.Do();

            Assert.Equal(5, calculator.Result);

            multiply.Do();

            Assert.Equal(50, calculator.Result);

            multiply.Undo();

            Assert.Equal(5, calculator.Result);
        }

        [Fact]
        public void _04_Creer_une_classe_abstraite_CommandBase_avec_une_methode_Do_et_Undo_pour_unifier_SumCommand_et_MultiplyCommand()
        {
            Calculator calculator = new Calculator();

            CommandBase sum = new SumCommand(calculator, 5);

            Assert.NotNull(sum);

            CommandBase multiply = new MultiplyCommand(calculator, 5);

            Assert.NotNull(multiply);
        }

        
        [Fact]
        public void _05_Creer_une_classe_CLI_avec_une_methode_Compute_et_Undo_et_Result()
        {
            CLI cli = new CLI();

            Assert.Equal(0, cli.Result());

            cli.Compute('+', 2);

            Assert.Equal(2, cli.Result());

            cli.Compute('*', 2);

            Assert.Equal(4, cli.Result());

            cli.Compute('+', 3);

            Assert.Equal(7, cli.Result());

            cli.Undo();

            Assert.Equal(4, cli.Result());

            cli.Undo();

            Assert.Equal(2, cli.Result());

            cli.Undo();

            Assert.Equal(0, cli.Result());
        }
    }
}
