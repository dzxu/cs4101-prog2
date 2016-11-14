// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printRegular(t, n, p);
        }

        public override Node eval(Node t, Environment env) {

            Node first = t.getCar();
            Node args = getArgVals(t.getCdr(), env);

            while (first.isSymbol()) {
                first = env.lookup(first);
            }

            if (first.isNull() || first == null) {
                //error, return null
                return Nil.getInstance();
            }

            if (first.isProcedure()) {
                return first.apply(args);
            }
            else {
              return first.eval(env).apply(args);
            }
        }

        public Node getArgVals(Node t, Environment env) {
            if (t.isNull() || t == null) {
                return Nil.getInstance();
            }
            else if (t.getCar().isSymbol()) {
                return new Cons(env.lookup(t.getCar()), getArgVals(t.getCdr(), env));
            }
            else {
                return new Cons(t.getCar(), getArgVals(t.getCdr(), env));
            }

        }

    }
}
