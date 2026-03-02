using System.Linq.Expressions;

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

        // verify length is greater than 0
        if(length <= 0)
        {
            // return empty array if length is not at least 1
            return []; 
        } 
        else
        {
            // create a starting array with specified length
            double[] array = new double[length];
            
            // create a loop to add each number, in the loop you will add (position + 1) * number.  Position start a 0 and ends at length - 1
            for(int i=0; i < length; i++)
            {
                array[i] = number * (i + 1);
            }
            return array;

        }

        // replace this return statement with your own
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
        // verify data has at least 2 item in it
        if (data.Count > 1)
        {
            // create a loop that loops 'amount' times removeing the last element and adding it to the start
            for(int i = 0; i < amount; i++)
            {
                int temp = data[data.Count-1];
                data.RemoveAt(data.Count-1);
                data.Insert(0, temp);
            }
        }
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
