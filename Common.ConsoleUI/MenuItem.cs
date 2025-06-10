using System;

namespace Common.ConsoleUI
{

    public class MenuItem
    {

        public string CommandName;
        public Action Operation;
        public bool Stopping;

        public MenuItem(string commandName, Action operation, bool stopping = false)
        {

            this.CommandName = commandName;
            this.Operation = operation;
            this.Stopping = stopping;
        }
    }
}
