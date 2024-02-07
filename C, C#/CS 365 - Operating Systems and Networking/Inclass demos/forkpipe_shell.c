#include <fcntl.h>     //
#include <stdio.h>     // I/O
#include <stdlib.h>    // Fork
#include <string.h>    // strlen, strcat
#include <sys/types.h> // pid_t
#include <sys/wait.h>  // wait
#include <sys/stat.h>  //
#include <termios.h>   //
#include <unistd.h>

#define OUTPUT_END 0
#define INPUT_END 1

int main()
{
    pid_t pid1, pid2;
    int fd[2];

    if (pipe(fd) < 0)
    {
        perror("Pipe initialization failed\n");
    }

    pid1 = fork();

    if (pid1 < 0)
    {
        perror("Fork failed\n");
    }

    if (pid1 == 0) // Child
    {
        close(fd[INPUT_END]);
        dup2(fd[OUTPUT_END], STDIN_FILENO);
        close(fd[OUTPUT_END]);

        execlp("wc", "wc", "-l", (char *)NULL);
    }
    else // Parent
    {
        pid2 = fork();
        if (pid2 < 0)
            perror("Fork 2 failed\n");

        if (pid2 == 0) // Child
        {
            close(fd[OUTPUT_END]);
            dup2(fd[INPUT_END], STDOUT_FILENO);
            close(fd[INPUT_END]);
            execlp("ls", "ls", "-l", (char *)NULL);
        }

        close(fd[OUTPUT_END]);
        close(fd[INPUT_END]);
        wait(NULL);
        wait(NULL);

    }

    // ls -l | wc -l

    return 0;
}