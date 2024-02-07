namespace HW1_Test;
using NUnit.Framework;
using HW1.ViewModels;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    private static TeamsVM MakeValidTeamsVM()
    {
        return new TeamsVM
        {
            TeamNames = "Aardvark\nAbyssinian\nAdelie Penguin\nAffenpinscherBearded Collie\n"
                        + "Bearded Dragon\nBeaver\nBedlington Terrier\nBeetle\nBengal Tiger\n"
                        + "Galapagos Penguin\nGalapagos Tortoise\nGar\nGecko\nGentoo Penguin\n"
                        + "Geoffroys Tamarin\nGerbil\nOstrich\nOtter\nOyster\nPademelon\nPanther\n"
                        + "Parrot\nPatas Monkey\nPeacock",
            MemberNames = "Kent T\nDan J\nKeaton K\nShawn h\nJosh S\nCade D\nBrigham G\nGabrielle D\n"
                        + "Koala C",
            TeamSize = 2
        };
    }
    
    [Test]
    public void splitMemberNamesResultsInList()
    {
        //Arrange 
        TeamsVM vm = MakeValidTeamsVM();
        var allMembers = vm.splitMemberNames();
        var pass = true;
        //Act
        if(allMembers.Count() < 9)
        {
            pass = false;
        }
        foreach(var i in allMembers)
        {
            if(i == null)
            {
                pass = false;
            }
        }
        //Assert
        Assert.IsTrue(pass);
    }

    [Test]
    public void randomizeMemberNamesCorrectly()
    {
        //Arrange 
        TeamsVM vm = MakeValidTeamsVM();
        var allMembers = vm.splitMemberNames();
        //Act
        var MemberNames = vm.MemberNames;
        var RandomMemberNames = vm.randomizeMembersNames(allMembers);
        //Assert
        CollectionAssert.AreNotEqual(MemberNames, RandomMemberNames);
    }

    [Test]
    public void MakeCorrectTeamsWithEvenNumberMembers()
    {
        //Arrange
        TeamsVM vm = MakeValidTeamsVM();
        var allMembers = vm.splitMemberNames();
        //Act
        while(allMembers.Count()%2 > 0)
        {
            allMembers.Add("Justin D");
        }
        allMembers = vm.randomizeMembersNames(allMembers);
        var teams = vm.makeRandomTeams(2, allMembers);
        //Assert
        foreach(var team in teams)
        {
            Assert.AreEqual(2, team.Count());
        }
        Assert.AreEqual(5, teams.Count());
    }

    [Test]
    public void MakeCorrectTeamsWithOddNumberMembers()
    {
        //Arrange
        TeamsVM vm = MakeValidTeamsVM();
        var allMembers = vm.splitMemberNames();
        var checker = 0;
        //Act
        while(allMembers.Count()%2 == 0)
        {
            allMembers.Add("Justin D");
        }
        allMembers = vm.randomizeMembersNames(allMembers);
        var teams = vm.makeRandomTeams(2, allMembers);
        //Assert
        foreach(var team in teams)
        {
            if(team.Count() < 2)
            checker++;
        }
        Assert.AreEqual(1, checker);
        Assert.AreEqual(5, teams.Count());
    }

    [Test]
    public void WontMakeTeamsWithTooManyMembers()
    {
        //Arrange
        TeamsVM vm = MakeValidTeamsVM();
        var allMembers = vm.splitMemberNames();
        var checker = 0;
        //Act
        allMembers = vm.randomizeMembersNames(allMembers);
        var teams = vm.makeRandomTeams(2, allMembers);
        foreach(var team in teams)
        {
            if(team.Count() > vm.TeamSize)
            checker++;
        }
        //Assert
        Assert.AreEqual(0, checker);
    }

    [Test]
    public void WillMakeOneTeamWithLessMembersThanTeamSizeWanted()
    {
        //Arrange
        TeamsVM vm = MakeValidTeamsVM();
        var allMembers = vm.splitMemberNames();
        //Act
        allMembers = vm.randomizeMembersNames(allMembers);
        var teams = vm.makeRandomTeams(10, allMembers);
        //Assert
        Assert.AreEqual(1, teams.Count());
    }
}