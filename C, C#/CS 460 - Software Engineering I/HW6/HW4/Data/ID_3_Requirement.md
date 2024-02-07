# ID 3
<hr>

## Title

*As a user I want to add tasks to items already in the system and then be reminded of them so I won't forget to do all the tasks I need to do*

## Description

This user story is all about giving the user the ability to add tasks to an item that is already in their item list.  A reminder: a task is a recurring activity that occurs for an item.  For example, for an item "Car", a task might be "Change the air filter".  It might re-occur every 1 year.  

To give the user value in this user story, we will also show them a list of upcoming tasks.  That way, if they create a task that occurs soon, they'll be able to see that it is there, whereas if we only had the create functionality, they would be left wondering if it was even in the system or not.  

### Details:

At our Sprint Planning meeting, we have decided that a **task** has:

1. *Description* -- details of what the actual task is, i.e. change the engine air filter.  This cannot be empty or an empty string.
2. *Start date* -- when is the first occurrance supposed to happen.  This is required and cannot be in the past.  It could be today, tomorrow or anytime in the future.  We only want a date, NOT hours, minutes and seconds.
3. *Interval* -- starting from the start date, how frequently, in days, until the next occurrence.  Cannot be less than 1 day.

To create a task we want it to be super fast and easy, which rules out a separate page and subsequent redirect and page load.  So, we'll do this on the items page (this is the users home page, i.e. `/user/sandra%20hart`) using AJAX.  Since this page displays all items, we'll use a click on a particular item to bring up a modal that holds the form.  Submitting the form closes the modal, but the user could also just dismiss the modal.  See the UI mockup below.  Make sure to show the user the title of the item in the modal so they know for sure which item they're adding a task for.

Now for showing the upcoming tasks:

1. Prominently show a list or table of the tasks that will occur within the next 7 days.  Don't worry about hours, minutes and seconds, just whether or not the date is 7 days or less ahead of the users current date.
2. Display the text of the task, the date on which it needs to be finished, and the title of the item so the user knows what item it refers to, because they could conceivably have "change the air filter" for two different cars and they need to know which one it's for.
3. Display them in chronological order, so the first/top one is the one that needs to be finished the soonest.
4. You may be tempted to show past-due tasks (perhaps in red) but this user story has not included that; if desired, it'll be in a future user story. 
5. If a task has a short enough interval it will appear multiple times in the task list. i.e. a task with interval 1 day will show up 7 times

We'll need to do this with AJAX as well so the page doesn't reload after the user enters a new task.

#### Implementation Details

1. Use an API Controller for the CRUD functionality.

## Acceptance Criteria
Please see the associated .feature file

## Assumptions/Preconditions
None

## Dependencies
ID 2

## Effort Points
4

## Owner

## Git Feature Branch
`Rmnd-US-3-add-tasks`

## Modeling and Other Documents

1. Create Task mockup: [Create Task](CreateTask.png "Mockup of the Task creation modal")
2. [Bootstrap Modal](https://getbootstrap.com/docs/5.2/components/modal/)

## Tasks
1. Get all tests adjusted to your own code, and make sure they run and fail
2. Build **GetAllTasksTodoWithinTimeWindow** method
3. Pass all tests provided
4. Adjust user interface to have a button for adding tasks
5. Create the form that allows a user to input task info
6. Create the controller that handles the AJAX request and adds the task to the DB
7. Manually test the interface and functionality