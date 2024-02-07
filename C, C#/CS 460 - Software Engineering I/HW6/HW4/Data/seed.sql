INSERT INTO [Person](FirstName, LastName)
    VALUES
    ('Justin','Davis'),
    ('Sandra','Hart'),
    ('Joe','Stone'),
    ('Justin','Tryon')

INSERT INTO [ToDoItem](Name, Description, PersonID)
    VALUES
    ('Car','Personal car, white BMW',1),
    ('Dog','Golden Retriever',1),
    ('Yard','Front yard, some grass with lots of clover', 3),
    ('Car','Tesla Model 3', 2)

INSERT INTO [ItemTask] (Name, Notes, Complete, Frequency, FirstCompletion, ItemID)
    VALUES
    -- ('Car','Change the cabin air filter', 0, 365, '12/2/2022', 4),
    -- ('Car','Rotate the tires', 0, 180, '12/5/2022', 4),
    -- ('Car','Vaccum the interior', 0, 90, '12/8/2022', 4)--,
--     ('Car', 'Wash Car', 0, 21, '11/17/2022 0:00:00', 1),
--     ('House', 'Paint', 0, 365, '11/27/2022 0:00:00', 2),
--     ('Dog', 'Short walk', 0, 2, '11/26/2022 0:00:00', 3),
--     ('Dog', 'Long Walk', 0, 4, '11/25/2022 0:00:00', 3),
--     ('Yard', 'Mow', 0, 6, '11/22/2022 0:00:00', 4),
--     ('Car', 'Clean windshield', 0, 3, '11/26/2022 0:00:00', 1),
    