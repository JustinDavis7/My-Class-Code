const worker = ["Samantha", 15.25, 43.5]; //INPUT
// Justin Davis, 3/7/2022
class Employee{
  constructor(workerArray) {
    this.name = workerArray[0];
    this.hourlyWage = workerArray[1];
    this.hoursWorked = workerArray[2];
  }
  calculateGrossPay (){
    if(this.hoursWorked > 40){
      let overtime = this.hoursWorked - 40;
      return (this.hourlyWage * 40) + (overtime * (this.hourlyWage * 1.5));
    }
    return (this.hourlyWage * this.hoursWorked);
  }
  WorkerPayStatementNoOvertime (){
    return (this.name + " earned $" + this.calculateGrossPay().toFixed(2) + " this week, for " +
              this.hoursWorked + " \n\thours at $" + this.hourlyWage + " per hour")
  }
  printWorkerPayStatement (){
    if(this.hoursWorked > 40)
    {
      return (this.WorkerPayStatementNoOvertime() + " plus 1.5x overtime");
    }
    else{
      return this.WorkerPayStatementNoOvertime();
    }
  }
}

let myWorker = new Employee(worker);
console.log(myWorker.printWorkerPayStatement())