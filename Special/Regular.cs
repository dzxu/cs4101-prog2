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

        public override Node eval(Node node, Environment env) {

            Node first = node.getCar();
            Node args = node.getCdr();

            while (first.isSymbol()) {
            }

            return this;
        }



    }
}
