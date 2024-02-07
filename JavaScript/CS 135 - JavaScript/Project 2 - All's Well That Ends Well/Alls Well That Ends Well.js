const value = 1000 // INPUT
// Justin Davis, 1/13/2022
if(value > 1000)
{
  console.log("The number is too big!");
  return 0;
}
else if (value < 1)
{
  console.log("The number is too small!");
  return 0;
}
if(value > 10 && value < 14)
{
  console.log(value + "th");
  return 0;
}
else
{
  switch (value%10)
  {
    case 1:
      console.log(value + "st");
      break;
    case 2:
      console.log(value + "nd");
      break;
    case 3:
      console.log(value + "rd");
      break;
    default:
      console.log(value + "th");
      break;
  }
}
