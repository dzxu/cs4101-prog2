// SPP -- The main program of the Scheme pretty printer.


using System;
using Parse;
using Tokens;
using Tree;
using Environment = Tree.Environment;

public class Scheme4101
{
    public static Environment global;

    public static int Main(string[] args)
    {
        // Create scanner that reads from standard input
        Scanner scanner = new Scanner(Console.In);

        if (args.Length > 1 ||
            (args.Length == 1 && ! args[0].Equals("-d")))
        {
            Console.Error.WriteLine("Usage: mono SPP [-d]");
            return 1;
        }

        // If command line option -d is provided, debug the scanner.
        if (args.Length == 1 && args[0].Equals("-d"))
        {
            // Console.Write("Scheme 4101> ");
            Token tok = scanner.getNextToken();
            while (tok != null)
            {
                TokenType tt = tok.getType();

                Console.Write(tt);
                if (tt == TokenType.INT)
                    Console.WriteLine(", intVal = " + tok.getIntVal());
                else if (tt == TokenType.STRING)
                    Console.WriteLine(", stringVal = " + tok.getStringVal());
                else if (tt == TokenType.IDENT)
                    Console.WriteLine(", name = " + tok.getName());
                else
                    Console.WriteLine();

                // Console.Write("Scheme 4101> ");
                tok = scanner.getNextToken();
            }
            return 0;
        }

        // Create parser
        TreeBuilder builder = new TreeBuilder();
        Parser parser = new Parser(scanner, builder);
        Node root;

        // TODO: Create and populate the built-in environment and
        // create the top-level environment

        Environment builtInEnv = new Environment();

        Ident func = new Ident("symbol?");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("number?");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("b+");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("b-");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("b*");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("b/");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("b=");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("b<");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("car");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("cdr");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("cons");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("set-car!");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("set-cdr!");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("null?");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("pair?");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("eq?");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("procedure?");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("read");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("write");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("display");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("newline");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("eval");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("apply");
        builtInEnv.define(func, new BuiltIn(func));
        func = new Ident("interaction-environment");
        builtInEnv.define(func, new BuiltIn(func));

        // Read-eval-print loop

        // TODO: print prompt and evaluate the expression
        root = (Node) parser.parseExp();
        while (root != null)
        {
            Console.WriteLine("root");
            root.eval(builtInEnv).print(0);
            root = (Node) parser.parseExp();
        }

        return 0;
    }
}
