#include <sys/types.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/wait.h>
#include <string.h>
#include <ctype.h>

const char* PIPE = "|";
const char* REDIRECT = ">";
const char* SPACE = " ";
// Unsigned Long for numbers that aren't negative
size_t split(const char* delimiter, const char* command, char** commands /*This is the array of commands*/); 
void trim(char* str);
 
int main(int argc, char* argv[])
{
    char command[1024]; // With 1024, this is static so we don't need malloc or *.
    char* commands[64]; // Could do [64][64] so we dont need malloc, but wasting memory.

    printf("$ ");
    fgets(command, 1024, stdin); // Can do scanf but it will stop at spaces.

    size_t num_commands = split(PIPE, command, commands);

    printf("You typed in: %s\n", command);

    size_t i;

    for(i = 0; i < num_commands; ++i)
    {
        printf("%d - >%s<\n", (int) i, commands[i]);

        char * subcommand[64];

        size_t num_args = split(SPACE, commands[i], subcommand);

        int j = 0;

        for (j = 0; j < num_args; ++j)
        {
            printf("%d - >%s<\n", (int) j, subcommand[j]);
        }

    }

    return 0;
}

size_t split(const char* delimiter, const char* command, char** commands)
{
    char *token;
    char* command_copy = strdup(command);
    size_t num_commands = 0;

    /* get the first token */
    token = strtok(command_copy, delimiter);

    /* walk through other tokens */
    while (token != NULL)
    {
        commands[num_commands] = malloc(sizeof(char) * strlen(token));
        trim(token);
        strcpy(commands[num_commands++], token); // commands[] removes 1 * and returns what is there.

        token = strtok(NULL, delimiter);
    }

    return num_commands;
}

void trim(char* str)
{
    char *pstr = str;
    int len = strlen(str);    

    while (isspace(pstr[len - 1]))
    {
        pstr[--len] = '\0'; // Cuts off everything in the back, and decrements len.
    }

    while (*pstr && isspace(*pstr))
    {
        ++pstr; // Advances the pointer over 1 to cut the space at the begenning.
        --len;
    }

    memmove(str, pstr, len + 1); // This relocates the pointer.
}