In T-SQL, Control Flow is used to execute a block of code based on certain conditions. This helps to make the code more flexible and dynamic.

One example of a Control Flow statement in T-SQL is the `IF` statement. It allows us to execute a block of code only if a certain condition is true. Here's an example:

```sql
DECLARE @Num INT = 10;

IF @Num > 0
BEGIN
   PRINT 'The number is positive';
END
```

In this example, we declare a variable `@Num` and assign it a value of `10`. We then use an `IF` statement to check if the value of `@Num` is greater than `0`. If it is, then the code inside the `BEGIN` and `END` block will be executed, which in this case is a simple print statement.

Control Flow statements like `IF` can also be combined with other T-SQL features like loops, cursors, and functions to create more complex and powerful scripts.