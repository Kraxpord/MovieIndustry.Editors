using System;

namespace MovieIndustry.Editing
{
    internal class MenuItem
    {
        private string v;
        private object value;
        private string v1;
        private Action showAsText;
        private bool v2;
        private Action createTestingData;

        public MenuItem(string v, object value)
        {
            this.v = v;
            this.value = value;
        }

        public MenuItem(string v, Action createTestingData)
        {
            this.v = v;
            this.createTestingData = createTestingData;
        }

        public MenuItem(string v, object value, bool v1)
        {
            this.v = v;
            this.value = value;
        }

        public MenuItem(string v1, Action showAsText, bool v2)
        {
            this.v1 = v1;
            this.showAsText = showAsText;
            this.v2 = v2;
        }
    }
}