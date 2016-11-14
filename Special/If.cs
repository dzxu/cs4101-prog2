// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
    public If() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printIf(t, n, p);
        }

        public override Node eval(Node t, Environment env){
            if(BoolLit.getInstance(true).Equals(t.getCdr().getCar().eval(env))){
                return t.getCdr().getCdr().getCar().eval(env);
            }
            else{
                return t.getCdr().getCdr().getCdr().getCar().eval(env);
            }


	}

    }
}

