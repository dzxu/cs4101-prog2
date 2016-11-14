// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printLet(t, n, p);
        }
        public override Node eval(Node t, Environment env) {

            Environment newEnv = new Environment(env);

            Node exp = t.getCdr().getCar();
            while (!(exp.isNull()) || exp != null) {

                Node expId = exp.getCar().getCar();
                Node expVal = exp.getCar().getCdr().getCar();
                newEnv.define(expId, expVal);

                exp = exp.getCdr();
            }

            //eval rest of let
            return t.getCdr().getCdr().eval(newEnv);

        }
    }
}
