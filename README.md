# DisplayNumberLibrary constructor
constructor takes in a IDisplayNumberTask that is either a **DisplayNumbersWithCustomOptionsTask** or a **DisplayNumbersWithDefaultOptionsTask**.

### DisplayNumbersWithDefaultOptionsTask
**DisplayNumbersWithDefaultOptionsTask** will only take in an upperbound and will return a list of string of:
- numbers from 1 to the upperBound 
- **Fizz** for any number divisible by 3
- **Buzz** for any number divisible by 5
- Maximum acceptable upperBound is 125,000,000

### DisplayNumbersWithCustomOptionsTask
**DisplayNumbersWithCustomOptionsTask** will accept and upperbound and customOptions, then return a list of string of:
- numbers from 1 to the upperBound with custom string if the number in that range is divisible by the int in the custom option
- numbers from 1 to the upperBound if no option is passed in
- Maximum acceptable upperBound is 125,000,000
  
#Methods
#### GetList(int upperBound, Dictionary<int, string> customOptions = null)
returns a list of string based on which **IDisplayNumbersTask** was passed in the constructor
#### WriteToConsole(int upperBound, Dictionary<int, string> customOptions = null)
prints the list of string from GetList to console

# Difficulty when writing the program
Part of the assignment requires that the Max int value supported by .NET is passed in: **2,147,483,647**. However, during testing, I ran received an error: `System.OutOfMemoryException: Array dimensions exceeded supported range`.

- .NET has been configured to allow only a maximum of **2GB** per object. Since the list to be return will hold pointers to strings, and each pointer takes up 4 bytes and 8 bytes for 32bit and 64bits system, respectively.

- I tried enabling gcallowverylargeobjects by creating an app.config in my Test project, but that did not work. 

- I tried decreasing the number from **2,147,483,647** to **250 000 000** by dividing 2GB by 8B, and I stopped receiving the `System.OutOfMermoyException` error. But was not able to complete one unit test when using that number since my program is O(n*m) time.

- The upper bound was decided by diving **1GB/8B = 125,000,000**

#### Some articles that helped when dealing with this problem
- https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element
- https://stackoverflow.com/questions/140468/what-is-the-maximum-possible-length-of-a-net-string
