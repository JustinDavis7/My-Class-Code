# CS 460 Software Engineering I -- Fall 2022
&ensp;&ensp;This was the start to my senior sequence. This class was a purely solo effort where we were finalizing our skills and proving what we had learned through the degree.

&ensp;&ensp;This was by no means an easy class, quite the contraire. Most everyone in this, and the year prior, struggled quite a large amount with the topics. Both years classes complained about obvious gaps in knowledge that we were supposed to have learned in prior classes such as CS366. This was a very lecture/info dense class, so we didn't have any time to really spend on topics that students were struggling with. I really think that Western needs to revamp their Junior level classes to better mesh with their senior sequence. The sequence itself is very good, and provides students with a solid challenge while also pushing us to cement our knowledge/skills and that's completly invaluable. The classes that were supposed to teach us the starting skill sets however are almost non-existant in the degree. I did well in this class because I went out of my way to take elective classes in HTML and JavaScript that helped immensely.

&ensp;&ensp;I feel that with a bit of adjustment, and some better checks-and-balances on the way earlier classes are taught, this sequence would go much more smoothly. The first class of the sequence (460, 461, and 462) starts off extremely hard, and then for the next two classes we are just displaying our skills in our senior project groups which becomes extreemly easier. All in all, this class, and the following two classes, were a ton of fun, and a good challenge. 

# HW 1
&ensp;&ensp;This assignment was giving to us on day one, with no instruction. Purely meant to see what we could do with nothing provided. It wasn't easy considering the experience we had prior, but I felt like I did a solid job on it and got full marks. We were given a list of team names, and had to create a program that would sort our class into teams of four - little did we know this was literally the program that would be used to create our project teams at the end of the term. We were given very few guidelines, and no info on how to achieve the task at hand. 

# HW 2
&ensp;&ensp;For this assignment, we were given a pre-existing data model, and had to implement the data layer for it. This was essentially meant to be something like Netflix's interface that we had to implement. 

# HW 3
&ensp;&ensp;The Github viewer assignment. This was a challenging one because of how weak our JavaScript and AJAX skills were. Most students struggled quite a bit with the AJAX part, and it was never really explained to us how it worked or was to be used. I managed to figure it out, and I feel, made a really nice looking display for it. I do have a demo video for this, but it's not included in this repo. If anyone would like to see demo videos for any of these projects, let me know and I can a YouTube link to you.

# HW 4
&ensp;&ensp;This was our first experience working with user scenarios. We were provided with 9 for this project, and we were given two feature to implement as part of the assignment.\
\
&ensp;&ensp;1. **As a visitor I would like a minimal but informative web app so I can get ready to use features of the application.**\
&ensp;&ensp;&ensp;&ensp;--Acceptance Criteria
<ul>

    Given I am on the homepage
    Then I will see a navbar
    And I will see a banner image
    And I will see a welcome message

    Given i am on the homepage
    Then I will not see a privacy link on the navbar
    And I will not see a copyright message

    Given i am on the homepage
    Then Bootstrap will be loaded
    And Bootstrap will be used for main content
</ul>

&ensp;&ensp;1. **As a user I want to be able to enter and then view items in the system so I will be able to add tasks for them at a later time.**\
&ensp;&ensp;&ensp;&ensp;--Acceptance Criteria
<ul>

    Given I am on the home page
    When I navigate to /user/sandra%20hart
    Then I should see a list of items with their titles and descriptions

    Given I am on the home page
    When I navigate to /user/nota%20realuser
    Then I should see a message telling me that the user could not be found

    Given I am on the page at /user/sandra%20hart
    Then I should see a form where I can enter a new item

    Given I am on the page at /user/sandra%20hart
    And I fill out the item form with valid information
    And I submit the form
    Then I should be returned to the same page where I can see that the item I entered can be found in the list of items

    Given I am on the page at /user/sandra%20hart
    And I fill out the item form with invalid information
    And I submit the form
    Then I should be notified that some of the information is incorrect
    And I should not see a new item created
</ul>

# HW 5
&ensp;&ensp;This assignment was all about writing requirements and BDD tests. Not much to mention here, you can see all of that in the relative file.

# HW 6
&ensp;&ensp;Expanding on HW4, we added a few more user stories and requirements to be implemented. Both of the .md files can be found in the HW6 folder under ID Requirements 3 and 4, as well as the starting code we were provided. This was the first time we were given a .feature file with BDD Tests.