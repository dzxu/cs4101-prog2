// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printBegin(t, n, p);
        }

        public override Node eval(Node t, Environment env) {
            if (t.getCdr().isNull() || t.getCdr == null) {
                return Nil.getInstance;
            }

            Environment newEnv = new Environment(env);

            while (!(t.getCdr().isNull()) || t.getCdr() != null) {
              t.getCdr().getCar().eval(newEnv);
              t = t.getCdr();
            }

            return (Node) t.getCar().eval(newEnv);
        }
    }
}
