-- Remove relations, easy since we named them
ALTER TABLE [ToDoItem] DROP CONSTRAINT [Item_Fk_Person];
ALTER TABLE [CompletedTask] DROP CONSTRAINT [CTask_Fk_Person];
ALTER TABLE [ItemTask] DROP CONSTRAINT [ITask_Fk_Item];
ALTER TABLE [ItemTask] DROP CONSTRAINT [ITask_Fk_Completed];

-- then delete tables.  If we hadn't removed relations first then we'd have to drop these
-- tables in a very specific order to avoid trying to violate constraints
DROP TABLE [CompletedTask];
DROP TABLE [ItemTask];
DROP TABLE [Person];
DROP TABLE [ToDoItem];
