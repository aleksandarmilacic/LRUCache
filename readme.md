# LRU Cache

This repository contains a Least Recently Used (LRU) Cache implementation in C#. It's a common interview question for software engineering roles at various tech companies.

## Problem Statement

Design a data structure that follows the constraints of a Least Recently Used (LRU) cache. Implement it with the following operations:

- `Get(int key)`: Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
- `Put(int key, int value)`: Set or insert the value if the key is not already present. When the cache reaches its capacity, it should invalidate the least recently used item before inserting the new item.

The LRU Cache is initialized with a positive capacity.

## Solution

The implemented solution uses a `Dictionary` and a `LinkedList`. The `Dictionary` stores keys and values for quick access, and the `LinkedList` keeps track of the order of the elements (most recent at the head, least recent at the tail). Then we can move the 'recently used' item to the head of the LinkedList every time the item is used.

## Running the Code

The solution is implemented as a Console Application in C#. To run the code, you need to have .NET Core installed on your machine. Follow these steps:

1. Clone the repository to your local machine.
2. Open a terminal and navigate to the directory of the cloned repository.
3. Run the command `dotnet run`.

The program will execute, and you will see the output of various cache operations in the console.

## Contributing

This is a simple educational project. Contributions are not expected, but if you see something that could be improved, feel free to open a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.
