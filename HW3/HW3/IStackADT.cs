using System;

namespace HW3
{
    /// <summary>
    /// Interface defining a Stack.
    /// 
    /// This code is referenced from a similar Java class written by Scot Morse.
    /// </summary>
    public interface IStackADT
    {
        /// <summary>
        /// Push an item onto the top of the stack. Pushing an object
        /// that doesn't exist should result in an error and should not
        /// succeed. Pushing an object that is not an item should result
        /// in an error. This operation returns a reference (pointer or
        /// link, but not a copy) to the item pushed so that an anonymous
        /// object can be pushed and then used.
        /// </summary>
        /// <param name="newItem">The object to push onto the top of the 
        /// stack. Should not be null.</param>
        /// <returns>A reference to the object that was pushed, or null if
        /// newItem == null.</returns>
        Object Push(Object newItem);

        /// <summary>
        /// Remove and return the top item on the stack. This operation
        /// should result in an error if the stack is empty. Returns a
        /// refernce to the item removed.
        /// </summary>
        /// <returns>A reference that was popped (and removed) from the
        /// stack or null if the stack is empty.</returns>
        Object Pop();

        /// <summary>
        /// Return the top item but do not remove it. Generally should
        /// result in an error if the stack is empty. An acceptable alternative
        /// is to return something which the user can use to check to see if
        /// the stack was in fact empty.
        /// </summary>
        /// <returns>A reference to the item currently on the top of the
        /// stack or null if the stack is empty.</returns>
        Object Peek();

        /// <summary>
        /// Query the stack to see if it is empty or not. Cannot produce
        /// an error.
        /// </summary>
        /// <returns>True if the stack is empty, false otherwise.</returns>
        bool IsEmpty();

        /// <summary>
        /// Rest the stack by emptying it. The exact technique used to 
        /// clear the stack is up to the implementor. The use should pay
        /// attention to what this behavior is.
        /// </summary>
        void Clear();
    }
}
