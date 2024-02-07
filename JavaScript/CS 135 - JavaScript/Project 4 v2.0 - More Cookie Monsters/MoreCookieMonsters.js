const troop = [{"name":"Selma", "boxes":17},{"name": "Maria", "boxes": 13},{"name": "Jake", "boxes": 22}]//INPUT
// Justin Davis, 2/28/2022


function highestSeller(array)
{
  var max = 0;
  var which_seller = "";
  for (var i = 0; i < array.length; i++)
  {
    if(troop[i].boxes > max)
    {
      max = troop[i].boxes;
      which_seller = troop[i].name;
    }
  }
  return [which_seller, max];
}

sales_and_seller = highestSeller(troop);

console.log(sales_and_seller[0] + " sold " + sales_and_seller[1] + " boxes");