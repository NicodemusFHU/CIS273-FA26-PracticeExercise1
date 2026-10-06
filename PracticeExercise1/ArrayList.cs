namespace PracticeExercise1;

public class ArrayList : IList
{
    private int[] array;
    private int length;

    public ArrayList()
    {

    }

    /// <summary>
    /// Returns first element in list, null if empty.
    /// </summary>
    public int? First => IsEmpty ? null : array[0];

    // TODO
    /// <summary>
    /// Returns last element in list, null if empty.
    /// </summary>
    public int? Last => IsEmpty ? null : array[length - 1];

    /// <summary>
    /// Returns true if list is has no elements; false otherwise.
    /// </summary>
    public bool IsEmpty => length == 0;

    /// <summary>
    /// Number of elements in list.
    /// </summary>
    public int Length => length;

    // TODO 
    /// <summary>
    /// Adds given value to end of list.
    /// </summary>
    /// <param name="value">value to add to the list</param>
    public void Append(int value)
    {

    }

    /// <summary>
    /// Checks if the list contains the given value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>true if value is in list; false otherwise</returns>
    public bool Contains(int value)
    {
        return true;
    }

    // TODO
    /// <summary>
    /// Find index of first element with matching value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Index of first element with value; -1 if element is not found</returns>
    public int FirstIndexOf(int value)
    {
        throw new NotImplementedException();
    }

    // TODO
    /// <summary>
    /// Insert new value after first instance of existing value.
    /// If existingValue is not in list, then add new value to end of list.
    /// </summary>
    /// <param name="newValue"></param>
    /// <param name="existingValue"></param>
    public void InsertAfter(int newValue, int existingValue)
    {
        throw new NotImplementedException();
    }

    // TODO
    /// <summary>
    /// Insert value at given index 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="index"></param>
    public void InsertAt(int value, int index)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Add value to beginning of list
    /// </summary>
    /// <param name="value"></param>
    public void Prepend(int value)
    {
        throw new NotImplementedException();

    }

    // TODO
    /// <summary>
    /// Remove first item with given value
    /// </summary>
    /// <param name="value">value of item to be removed</param>
    public void Remove(int value)
    {

    }

    // TODO
    /// <summary>
    /// Remove item at specififed index.
    /// </summary>
    /// <param name="index"></param>
    /// <exception > Throws IndexOutOfRangeException </exception>
    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        string str = "[ ";

        for (int i = 0; i < Length - 1; i++)
        {
            str += array[i] + ", ";
        }

        if (!IsEmpty)
        {
            str += array[Length - 1];
        }

        str += "]";

        return str;
    }

    /// <summary>
    /// Return the element at the given index or null if the index is out of range.
    /// </summary>
    /// <param name="index"></param>
    /// <returns>The element at the given index; null if index is negative or not less than Length.</returns>
    public int? Get(int index)
    {


        return null;
    }

    /// <summary>
    /// Remove all elements from list
    /// </summary>
    public void Clear()
    {

    }

    /// <summary>
    /// Return a new copy of list in reverse order
    /// </summary>
    /// <returns></returns>
    public IList Reverse()
    {
        throw new NotImplementedException();
    }

    private void ShiftRight(int startingIndex)
    {

    }

    private void ShiftLeft(int startingIndex)
    {

    }

    private void Resize()
    {
        Array.Resize(ref array, 2 * array.Length);
    }

}


