# -- This file is best viewed with a Gherkin syntax highlighter, e.g. Cucumber (Gherkin) Full Support extension in VS Code

Feature: Add Task to Item
  As a user I want to add tasks to items already in the system and then be reminded of them so I won't forget to do all the tasks I need to do

Background:
  Given that today is TODAY

  Given the following user exists:
    | FirstName      | LastName        |
    | Sandra         | Hart            |

  Given the following items exist:
    | Title          | Description     | Owner       |
    | Car            | Tesla Model 3   | Sandra Hart |

  Given the following tasks exist:
    | Description                 | StartDate      | Interval      | Item    |
    | Change the cabin air filter | TODAY + 2 days | 365           | Car     |
    | Rotate the tires            | TODAY + 5 days | 180           | Car     |
    | Vacuum the interior         | TODAY + 8 days | 90            | Car     |

Scenario: User page displays upcoming tasks
  Given I am "Sandra Hart" 
    And I am on their "user" page
  Then I should see a list of tasks that includes "Change the cabin air filter"

Scenario: User page displays another upcoming task
  Given I am "Sandra Hart" 
    And I am on their "user" page
  Then I should see a list of tasks that includes "Rotate the tires"

Scenario: User page does not display task outside window
  Given I am "Sandra Hart" 
    And I am on their "user" page
  Then I should not see a list of tasks that includes "Vacuum the interior"

Scenario: User page displays empty upcoming tasks
  Given I am "Sandra Hart" 
    And I am on their "user" page
    And today is "TODAY - 7 days"
  Then I should see an empty list of tasks

Scenario: Add task form exists
  Given I am "Sandra Hart" 
    And I am on their "user" page
  When I click on add task for "Car"
  Then I should see a form to enter a new task for "Car"

Scenario Outline: Add task for item and it shows up in task list
  Given I am "Sandra Hart" 
    And I am on their "user" page
  When I click on add task for "Car"
    And I enter <Description> and <StartingDate> and <Interval>
    And I submit the add task form
  Then I should see <Description> in the list of tasks if <StartingDate> is within TODAY + 7 days
  Examples:
    | Description    | StartingDate | Interval |
    | Wash exterior  | TODAY + 6    | 34       |
    | Check brakes   | TODAY + 30   | 100      |
    | Do something   | TODAY + 1    | 300      |

Scenario Outline: Add task for item with short interval shows up multiple times
  Given I am "Sandra Hart" 
    And I am on their "user" page
  When I click on add task for "Car"
    And I enter <Description> and <StartingDate> and <Interval>
    And I submit the add task form
  Then I should see <Description> in the list of tasks multiple times if <StartingDate> is within TODAY + 7 days
  Examples:
    | Description    | StartingDate | Interval |
    | Wash exterior  | TODAY + 3    | 2        |
    | Check brakes   | TODAY + 30   | 2        |
    | Do something   | TODAY + 1    | 2        |

Scenario: Add new task form has validation
  Given I am "Sandra Hart" 
    And I am on their "user" page
  When I click on add task for "Car"
    And I enter invalid information
    And I submit the add task form
  Then I will see an validation error message

Scenario: Add new task uses AJAX
  Given I am "Sandra Hart" 
    And I am on their "user" page
  When I click on add task for "Car"
    And I enter "Clean cameras" and "TODAY" and "5"
    And I submit the add task form
  Then I should see the task list modified without a page reload