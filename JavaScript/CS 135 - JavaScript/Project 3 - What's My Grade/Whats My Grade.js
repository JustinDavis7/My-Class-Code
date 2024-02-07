const grade = 79.9 //INPUT
// Justin Davis, 2/1/2022
if (typeof(grade) != 'number' || grade < 0)
{
  console.log("Incorrect input type, we need a number greater than 0!");
}
else
{
  if(grade >= 90)
    console.log("A");
  else if (grade < 90 && grade >= 80)
    console.log("B");
  else if (grade < 80 && grade >= 70)
    console.log("C");
  else if (grade < 70 && grade >= 60)
    console.log("D");
  else
    console.log("F");
}