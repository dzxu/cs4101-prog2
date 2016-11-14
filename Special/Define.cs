// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printDefine(t, n, p);
        }
        public override Node eval(Node t, Environment env) {

            Node id = t.getCdr().getCar();
            Node val = t.getCdr().getCdr().getCar();

            if (id.isSymbol()) {
                env.define(id, val);
            }
            else { //function

                Closure funcArgs = new Closure(new Cons(id.getCdr(), t.getCdr().getCdr()), env);
                Node lambda = new Cons(new Ident("lambda"), funcArgs).eval(env);
                env.define(id.getCar(), lambda);
            }

            return new StringLit("; defined");
        }
    }
}
