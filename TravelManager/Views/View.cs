using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelManager.Views
{
    class View
    {
        static Stack<View> viewStack = new Stack<View>();
        public virtual void OpenView(View view)
        {
            viewStack.Push(view);
            Console.Clear();
        }

        public virtual void CloseView()
        {
            viewStack.Pop();

            if (viewStack.Count > 1)
            {
                View topView = viewStack.Peek();
                topView.OpenView(topView);
            }
        }
    }
}
