// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
        public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            Printer.printCond(t, n, p);
        }

        public override Node eval(Node t, Environment env){
            while(!t.getCdr().isNull()){
                t = t.getCdr();

                if (BoolLit.getInstance(true).Equals(t.getCar().getCar().eval(env))){
                    t = t.getCar();

                    return t.getCdr().getCar().eval(env);
                }

            }
	}
    }
}


