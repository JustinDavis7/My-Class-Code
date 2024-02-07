
# ID 4
<hr>

## Title
*As a user I want an easily accessible version of the site deployed at a public IP address*

## Description
Deploy the application to Azure.  Make sure **all** your secrets are hidden. Only open the DB firewall to your developer machine's IP address as well as Azure addresses.

## Acceptance Criteria
No .feature file for this one

    Given I am any user
    When I navigate to the homepage
    Then the URL will end with ".azurewebsites.net"

    ... And all the other features still work ...

## Assumptions/Preconditions
1. We must have an Azure account with a valid subscription in order to provision the database and web app in the cloud.

## Dependencies
None, can deploy at any time

## Effort Points

## Owner

## Git Feature Branch
Rmnd-US-4-deploy

## Modeling and Other Documents

## Tasks
1. ...
2. ...