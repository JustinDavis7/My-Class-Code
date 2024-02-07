using Coordinator.Lib.Interfaces;
using System.Collections;

namespace Coordinator.Lib
{
    public class Coordinator
    {
        private IList<PriorityJob> _inputJobs = new List<PriorityJob>();
        private IList<PriorityJob> _orderedInputJobs = new List<PriorityJob>();
        private IList<PriorityJob> _finishedJobs = new List<PriorityJob>();

        private IList<JobQueue> _listOfQueues = new List<JobQueue>();
        private List<PriorityJob> _ioQueue = new List<PriorityJob>();

        private List<int> _quantas = new List<int>();

        private int _ioCompleteChance = 10;
        private int _ioRequestChance = 4;
        private Random _random = new Random();

        private bool IsIoComplete()
        {
            if (_random.Next() % _ioCompleteChance == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool HasIoRequest()
        {
            if (_random.Next() % _ioRequestChance == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ReadJobs(string filename)
        {
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var data = line.Split(":");

                _inputJobs.Add(new PriorityJob
                {
                    PID = int.Parse(data[0].Trim()),
                    ArrivalTime = int.Parse(data[1].Trim()),
                    BurstTime = int.Parse(data[2].Trim()),
                    Priority = int.Parse(data[3].Trim())
                });
            }
            _orderedInputJobs = _inputJobs.OrderBy(a => a.Priority).ThenBy(b => b.PID).ToList();
        }

        private void LoadQueues(IJob job)
        {
            switch (job.Priority)
            {
                case 0:
                    _listOfQueues[0].Enqueue(job);
                    break;
                case 1:
                    _listOfQueues[1].Enqueue(job);
                    break;
                case 2:
                    _listOfQueues[2].Enqueue(job);
                    break;
                case 3:
                    _listOfQueues[3].Enqueue(job);
                    break;
                case 4:
                    _listOfQueues[4].Enqueue(job);
                    break;
                case 5:
                    _listOfQueues[5].Enqueue(job);
                    break;
                case 6:
                    _listOfQueues[6].Enqueue(job);
                    break;
                default:
                    _listOfQueues[7].Enqueue(job);
                    break;
            }
        }

        public PriorityJob PickNewJob()
        {
            var workingJob = new PriorityJob { PID = -1};
            foreach (var queue in _listOfQueues)
            {
                if (!queue.IsEmpty())
                {
                    workingJob = (PriorityJob)queue.Dequeue();
                    workingJob.JobState = JobState.Running;
                    switch(workingJob.Priority)
                    {
                        case 0:
                            workingJob.WorkingQuanta = _quantas[0];
                            break;
                        case 1:
                            workingJob.WorkingQuanta = _quantas[1];
                            break;
                        case 2:
                            workingJob.WorkingQuanta = _quantas[2];
                            break;
                        case 3:
                            workingJob.WorkingQuanta = _quantas[3];
                            break;
                        case 4:
                            workingJob.WorkingQuanta = _quantas[4];
                            break;
                        case 5:
                            workingJob.WorkingQuanta = _quantas[5];
                            break;
                        case 6:
                            workingJob.WorkingQuanta = _quantas[6];
                            break;
                        default:
                            workingJob.WorkingQuanta = _quantas[7];
                            break;
                    }
                    break;
                }
            }  
            return workingJob;
        }

        public void CheckReadyStates()
        {
            foreach (var queue in _listOfQueues)
            {
                if (!queue.IsEmpty())
                {
                    for (var i = 0; i < queue._queue.Count; i++)
                    {
                        var job = (PriorityJob)queue.Dequeue();
                        if (job.JobState == JobState.Ready)
                        {
                            job.ReadyTime++;
                        }
                        queue.Enqueue(job);
                    }
                }
            }
        }

        public void CheckWaitingStates(List<PriorityJob> ioQueue)
        {
            if(ioQueue.Count() == 0)
            {
                return;
            }
            foreach (var job in ioQueue)
            {
                if (job.JobState == JobState.Waiting)
                {
                    job.WaitingTime++;
                }
            }
        }

        public void SetUpCommandLineArgs(string[]args)
        {
            for (int i = 0; i < 8; i++)
            {
                _quantas.Add(i * 2);
            }
            _quantas[0] = 1;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-s":
                        _random = new Random(Int32.Parse(args[++i]));
                        break;
                    case "-r":
                        _ioRequestChance = Int32.Parse(args[++i]);
                        break;
                    case "-c":
                        _ioCompleteChance = Int32.Parse(args[++i]);
                        break;
                    case "-0":
                        _quantas[0] = Int32.Parse(args[++i]);
                        break;
                    case "-1":
                        _quantas[1] = Int32.Parse(args[++i]);
                        break;
                    case "-2":
                        _quantas[2] = Int32.Parse(args[++i]);
                        break;
                    case "-3":
                        _quantas[3] = Int32.Parse(args[++i]);
                        break;
                    case "-4":
                        _quantas[4] = Int32.Parse(args[++i]);
                        break;
                    case "-5":
                        _quantas[5] = Int32.Parse(args[++i]);
                        break;
                    case "-6":
                        _quantas[6] = Int32.Parse(args[++i]);
                        break;
                    case "-7":
                        _quantas[7] = Int32.Parse(args[++i]);
                        break;
                }
            }
        }

        public void Run(string[] args)
        {   
            var longestJob = new PriorityJob() { PID = -1 };
            var shortestJob = new PriorityJob() { PID = -1 };
            var workingJob = new PriorityJob();
                        
            var clock = 0;
            var currentWorkingTime = 0;
            var finishedIOCount = 0;
            var idleTime = 0;

            var currentlyWorking = false;  

            ReadJobs("SchedulingJobs.txt");
            SetUpCommandLineArgs(args);

            // Setting up the queues to add jobs
            for (var i = 0; i < 8; i++)
            {
                _listOfQueues.Add(new JobQueue());
            }

            while (_finishedJobs.Count != _orderedInputJobs.Count)
            {
                // Putting each job into a queue as they come in according to the clock time and their arrival time
                foreach (var job in _orderedInputJobs)
                {
                    if (job.ArrivalTime == clock)
                    {
                        job.JobState = JobState.Ready;
                        LoadQueues(job);
                    }
                }

                // Check if any jobs have finished IO requested
                var tempIOQueue = new List<PriorityJob>();
                if(_ioQueue.Count > 0)
                {
                    tempIOQueue = new();
                    foreach(var job in _ioQueue)
                    {
                        if(IsIoComplete())
                        {
                            job.JobState = JobState.Ready;
                            LoadQueues(job);
                            finishedIOCount++;
                            continue;
                        }
                        tempIOQueue.Add(job);
                    }
                }
                _ioQueue = tempIOQueue;

                // Checks if a job is currently working or not and picks a new one
                if (!currentlyWorking)
                {
                    workingJob = PickNewJob();
                    // Checks to see if the queues are empty
                    if(workingJob.PID == -1)
                    {
                        CheckReadyStates();
                        CheckWaitingStates(_ioQueue);
                        clock++;
                        idleTime++;
                        continue;
                    }
                    currentlyWorking = true;  
                }

                // Checks to see if a job needs IO
                if (HasIoRequest())
                {
                    workingJob.JobState = JobState.Waiting;
                    _ioQueue.Add(workingJob);
                    currentlyWorking = false;
                }
                else
                {
                    // Doing work on the current job
                    workingJob.BurstTime -= 1;
                    workingJob.RunningTime += 1;
                    currentWorkingTime++;

                    // Checking for a job to be finished
                    if (workingJob.BurstTime == 0)
                    {
                        workingJob.UpdateTotalElapsedTime();

                        if (workingJob.ElapsedTime > longestJob.ElapsedTime || longestJob.PID == -1)
                        {
                            longestJob = workingJob;
                        }
                        else if (workingJob.ElapsedTime < shortestJob.ElapsedTime || shortestJob.PID == -1)
                        {
                            shortestJob = workingJob;
                        }

                        workingJob.JobState = JobState.Terminated;         

                        _finishedJobs.Add(workingJob);

                        currentWorkingTime = 0;
                        currentlyWorking = false;
                    }// Checking if the working quanta is fulfilled ---- This is the swapping
                    else if (currentWorkingTime == workingJob.WorkingQuanta)
                    {
                        workingJob.JobState = JobState.Ready;
                        if (workingJob.Priority < 7)
                        {
                            workingJob.Priority = workingJob.Priority + 1;
                        }
                        LoadQueues(workingJob);
                        currentlyWorking = false;
                        currentWorkingTime = 0;
                    }
                }

                CheckReadyStates();
                CheckWaitingStates(_ioQueue);
                clock++;
            }
            Console.WriteLine($"Longest Job was PID: {longestJob.PID}\nIt took {longestJob.ReadyTime + longestJob.WaitingTime + longestJob.RunningTime} tick(s) to complete.\n");
            Console.WriteLine($"Shortest Job was PID: {shortestJob.PID}\nIt took {shortestJob.ReadyTime + shortestJob.WaitingTime + shortestJob.RunningTime} tick(s) to complete.\n");
            Console.WriteLine($"Number IO requests satisfied: {finishedIOCount}");
            Console.WriteLine($"\nThe system was at idle for {idleTime} ticks.\n");
            Console.WriteLine($"Total time elapsed: {clock} ticks.");
        }  
    }
}
