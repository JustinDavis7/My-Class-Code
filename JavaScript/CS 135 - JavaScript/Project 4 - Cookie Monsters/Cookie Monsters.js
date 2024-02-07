const sales_array = [3,23,7,5,13,2] //INPUT
// Justin Davis, 2/22/2022
const troup = ["Amy","Becky","Belinda","Jessica","Jill","Kim"]  // copy-paste for program line 3 

function highestSeller(array)
{
  var max = 0;
  var which_seller = 0;
  for (var i = 0; i < array.length; i++)
  {
    if(sales_array[i] > max)
    {
      max = sales_array[i];
      which_seller = i;
    }
  }
  return [which_seller, max];
}

sales_and_seller = highestSeller(sales_array);

console.log(troup[sales_and_seller[0]] + " sold " + sales_and_seller[1] + " boxes");