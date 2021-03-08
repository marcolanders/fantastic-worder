Hi,

This is my public repository for a coding test as part of a recruiting process. The idea is to write a program to solve a word puzzle. Given a start four letter word i.e. “same” and an end four letter word i.e. “cost” the application has to come up with a list of words that move from the start word to the end word by changing only one letter between any two words. Each intermediate step should be a real word from a given dictionary file.

The application should receive the dictionary file name from the console. Reading and parsing the file is an obvious logic to extract to its own object so I created the DictionaryReader class. The logic of this class is simple as it uses a regex to filter words that have non-letter characters and/or do not have four letters. These are not needed for the problem and should be ignored from the start.

I then abstracted the System.IO.File.ReadAllLines line to another FileReader class in order to be able to create unit tests for the DictionaryReader class. These simple tests assert the dictionary only contains four letter words.

After the user inputs the dictionary file name (or full path if not on the same location as the application executable) on the console, the path is tested and if it exists, an asynchronous task is created to read the dictionary to memory. In this example, the dictionary is not huge and reading it does not take long, but since the user still has to input other elements, it makes sense to use this time to read the dictionary to memory.

The application then proceeds to collect the start and finish word from the console, parsing user input and checking, by via another regex, that the user inputs two four letter words.

After the application has collected both four letter words, it starts another asynchronous task to perform the transformation and solve the exercise while it collects the output file name from the user. Again, since these are just four letter words the transformation does not take long, even if it cannot complete, but it makes sense to use as much time available as we can in order to keep the user from having to wait for results.

The transformation from the first word to the last is accomplished in another object  as to leave the main application method only responsible for collecting user inputs and to allow the transformation logic to be easily tested.

After the application has collected the output file name the application waits for the transformation to finish, prints the results to the console and writes them on the output file. The logic to create and write to an output file is in its own class to allow for correct separation of concerns. These other “components” created are merely other classes, for simplicity purposes, but could be other projects.

I have added a SimpleInjector from a NuGet package in order to manage the dependencies for all components, simplify the abstraction between each, and allow for easier creation of unit tests. In the tests, I have added the framework Moq from another NuGet package to allow for the creation of mock objects. If this were a complete implementation, I would have created more tests but since this is a demonstration, I believe these should suffice.

In order to solve the problem, my first idea was to focus on each letter and solve it at a time, so I made a method to find the first letter transformation. It seemed feasible if it was from the start or last word. However, I hit a dead end if it was the third. It started to seem obvious that the application would need some kind of recursive behavior and that it would need to discard attempts and try again with other results.

If you look in the Git log you will see the mental process from the first solution to this last. It is also a bit of a test driven development/extreme programing/agile demonstration. I pushed the first working version, still thinking about solving the word letter by letter, with unit tests and then thought about refactoring. I started to remove the duplicate code and it led to the simpler version that is on the last push.

There are  enhancements to be made to this solution, the dictionary file is a simple list of strings. The puzzle solving logic is four letter strict and could be more generic. Again, from a demonstration point of view and given the size of the dictionary, this seems perfectly feasible.

Any comments, errors or omissions, please let me know,
