public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Step 1: Create a new array of size 'length' to store the multiples.
        // Step 2: Loop from index 0 up to length - 1.
        // Step 3: For each index i, compute number * (i + 1).
        // Step 4: Store the result in the array at index i.
        // Step 5: After the loop finishes, return the array.
        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
        result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Step 1: Determine the starting index of the last 'amount' elements.
        // Step 2: Use GetRange to copy the last 'amount' elements into lastPart.
        // Step 3: Use GetRange to copy the first part of the list (everything before the last 'amount') into firstPart.
        // Step 4: Clear the original list.
        // Step 5: Add lastPart first, then add firstPart after to complete the rotation.
        int splitIndex = data.Count - amount;

        List<int> lastPart = data.GetRange(splitIndex, amount);
        List<int> firstPart = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
