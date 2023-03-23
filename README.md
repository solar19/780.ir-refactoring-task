# Refactoring test in C#

## Description

Please refactor the UserService class and, more specifically, its AddUser method. Only focuses on applying clean code principles. Keep in mind acronyms such as SOLID, KISS, DRY and YAGNI.

## Limitations
The Program.cs class in the LegacyApp.Consumer must NOT CHANGE AT ALL. This includes using statements. Assume that this codebase is part of a greater system, and any non-backward compatible change will break the system.

You can change anything in the LegacyApp project except for the UserDataAccess class and its AddUser method. Both the class and the method NEED to stay static.

## Important Point
1. It's better to change "surname" property to "lastName". I've not changed this property because of consistency.
2. For configuration there is no appsetting.json or any other json file to save configuration, so the result of this app will be never sucessful.
3. I think, it's better to use "Interface" instead of "concrete class" for UserService and then inject interface and service via dependency injection. But since you mention, "AddUser" in program.cs shouldn't be changed, I mention this point
