const cents= 42 //INPUT
// Justin Davis, 1/18/2022

var temp = cents, quarters = 0, dimes = 0, nickels = 0, pennies = 0;

if(temp % 25 >= 0)
{
  quarters = getCoins(temp, 25);
  temp -= quarters * 25;
}

if (temp % 10 >= 0)
{
  dimes = getCoins(temp, 10);
  temp -= dimes * 10;
}

if (temp % 5 >= 0)
{
  nickels = getCoins(temp, 5);
  temp -= nickels * 5;
}

pennies = temp;

var change = "";

change = getChange(change, "Quarter", quarters);
change = getChange(change, "Dime", dimes);
change = getChange(change, "Nickel", nickels);

if(pennies > 1)
{
  change = getChange(change, "Pennie", pennies);//The s is added in the function
}
else 
{
  change = getChange(change, "Penny", pennies);
}

console.log(change);

function getChange(change, value, ammount) 
//change is string, value is type ie: Quarter, ammount is number of coins
{
  if(ammount > 1)
  {
    change += ammount + " " + value + "s\n";
  }
  else if(ammount == 1)
  {
    change += "1 " + value + "\n";
  }
  else
  {
    change += "0 " + value + "s\n";
  }
  return change;
}

function getCoins(temp, divisor)
{
  var outputTemp = 0
  
  for(var i = 0; temp > divisor; ++i)
  {
    temp -= divisor;
    outputTemp += 1;
  }
  
  if(temp == divisor)
  {
    return 1;
  }
  else
  {
    return outputTemp;
  }
}