#include <stdio.h>          // I/O
#include <stdlib.h>         // Fork
#include <string.h>         // strlen, strcat
#include <sys/types.h>      // pid_t
#include <sys/wait.h>       // wait
#include <sys/stat.h>       //
#include <termios.h>        //
#include <unistd.h>         // pipe


#define OUTPUT_END 0
#define INPUT_END 1 // Could also do const ints.

int main()
{
    pid_t pid1, pid2;
    int fd[2];  // File Descripter

    if(pipe(fd) < 0)
    {
        perror("Pipe initialization failed\n");
    }

    pid1 = fork();
    
    if(pid1 < 0)
    {
        perror("Fork failed\n");
    }

    if (pid1 == 0)      // Child
    {
        // STDIN:   terminal input  
        // STDOUT:  terminal output
        close(fd[INPUT_END]);
        dup2(fd[OUTPUT_END], STDIN_FILENO); // Duplicated output and copied it to STDIN
        close(fd[OUTPUT_END]);

        execlp("wc", "wc", "-l", (char*) NULL);
        
    }
    else    // Parent
    {
        pid2 = fork();
        if(pid2 < 0) perror("Fork 2 failed");

        if (pid2 == 0) // Child
        {
            close(fd[OUTPUT_END]);
            dup2(fd[INPUT_END], STDOUT_FILENO);
            close(fd[INPUT_END]);
            execlp("ls", "ls", "-l", (char*) NULL);
        }

        close(fd[INPUT_END]);
        close(fd[OUTPUT_END]);

        wait(NULL);
        wait(NULL);

    }

    // ls -l | ws -l


    return 0;
}