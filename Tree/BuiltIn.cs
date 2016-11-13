// BuiltIn -- the data structure for built-in functions

// Class BuiltIn is used for representing the value of built-in functions
// such as +.  Populate the initial environment with
// (name, new BuiltIn(name)) pairs.

// The object-oriented style for implementing built-in functions would be
// to include the C# methods for implementing a Scheme built-in in the
// BuiltIn object.  This could be done by writing one subclass of class
// BuiltIn for each built-in function and implementing the method apply
// appropriately.  This requires a large number of classes, though.
// Another alternative is to program BuiltIn.apply() in a functional
// style by writing a large if-then-else chain that tests the name of
// the function symbol.

using System;
using Parse;

namespace Tree
{
    public class BuiltIn : Node
    {
        private Environment global; 
        private Node symbol;            // the Ident for the built-in function

        public BuiltIn(Node s)      { 
            global = Scheme4101.global;
            symbol = s; 
        }

        public Node getSymbol()     { return symbol; }

        // TODO: The method isProcedure() should be defined in
        // class Node to return false.
        public /* override */ bool isProcedure()    { return true; }

        public override void print(int n)
        {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.Write("#{Built-in Procedure ");
            if (symbol != null)
                symbol.print(-Math.Abs(n));
            Console.Write('}');
            if (n >= 0)
                Console.WriteLine();
        }

        // TODO: The method apply() should be defined in class Node
        // to report an error.  It should be overridden only in classes
        // BuiltIn and Closure.
        public /* override */ Node apply (Node args)
        {

            if (args == null) {
                return null;
            }

            Node arg1 = args.getCar();
            if (arg1 == null || arg1.isNull()) {
                arg1 = Nil.getInstance();
            }

            Node arg2 = args.getCdr();
            if (arg2 == null || arg2.isNull()) {
                arg2 = Nil.getInstance();
            }
            else { 
                arg2 = arg2.getCar();
            }

            String symbolName = symbol.getName();

            switch (symbolName) {
                case "symbol?": 
                    return BoolLit.getInstance(arg1.isSymbol());

                case "b+":
                    if (arg1.isNumber() && arg2.isNumber()){
                        Console.WriteLine("hello");
                        return new IntLit(arg1.getVal() + arg2.getVal());
                    }
                    else
                        return new StringLit("Error: Improper input");    

                case "b-":
                    if (arg1.isNumber() && arg2.isNumber())
                        return new IntLit(arg1.getVal() - arg2.getVal());
                    else
                        return new StringLit("Error: Improper input");    

                case "b*":
                    if (arg1.isNumber() && arg2.isNumber())
                        return new IntLit(arg1.getVal() * arg2.getVal());
                    else
                        return new StringLit("Error: Improper input");    

                case "b/":
                    if (arg1.isNumber() && arg2.isNumber())
                        return new IntLit(arg1.getVal() / arg2.getVal());
                    else
                        return new StringLit("Error: Improper input");   

                case "b=":
                    if (arg1.isNumber() && arg2.isNumber())
                        return BoolLit.getInstance(arg1.getVal() == arg2.getVal());
                    else
                        return new StringLit("Error: Improper input");

                case "b<":
                    if (arg1.isNumber() && arg2.isNumber())
                        return BoolLit.getInstance(arg1.getVal() < arg2.getVal());
                    else
                    return new StringLit("Error: Improper input");


                case "car":
                    if (arg1.isNull()) 
                        return arg1;
                    else
                        return arg1.getCar();

                case "cdr":
                    if (arg1.isNull()) 
                        return arg1;
                    else
                        return arg1.getCdr();

                case "cons":
                    return new Cons(arg1, arg2);

                case "set-car!":
                    arg1.setCar(arg2);
                    return arg1;

                case "set-cdr!":
                    arg1.setCdr(arg2);
                    return arg1;

                case "null?":
                    return BoolLit.getInstance(arg1.isNull());

                case "pair?":
                    return BoolLit.getInstance(arg1.isPair());

                case "eq?":
                    return BoolLit.getInstance(arg1 == arg2);

                case "procedure?":
                    return BoolLit.getInstance(arg1.isProcedure());

                case "read":
                    Parser parser = new Parser(new Scanner(Console.In), new TreeBuilder);
                    return (Node)parser.parseExp();

                case "write":
                    arg1.print(0);
                    return new StringLit("");

                case "display":
                    return arg1;

                case "newline":
                    return new StringLit("");

                case "eval":
                    return arg1.eval(arg2);

                case "apply":
                    return arg1.apply(arg2);

                case "interaction-environment":
                    return global;

                default: return new StringLit("Error: BuiltIn.apply not yet implemented");
            }
        }
    }    
}

