#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>

void fork3()
{
    printf("\n [%d] L0 \n", getpid());
    fork();
    printf("\n [%d] L2 \n", getpid());
    fork();
    printf("\n [%d] Bye \n", getpid());
}

int main ()
{
    fork3();
    return 0;
}
