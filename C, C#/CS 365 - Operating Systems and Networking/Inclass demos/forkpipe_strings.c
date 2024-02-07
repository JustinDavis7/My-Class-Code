// C program to demonstrate use of fork() and pipe()
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <unistd.h>

int main()
{
	// We use two pipes
	// First pipe to send input string from parent
	// Second pipe to send concatenated string from child

	int pipe_1_file_descriptor[2]; // Used to store two ends of first pipe
	int pipe_2_file_descriptor[2]; // Used to store two ends of second pipe

	char fixed_str[] = " Lucas";
	char input_str[100];
	pid_t process_id;

	if (pipe(pipe_1_file_descriptor) == -1) {
		fprintf(stderr, "Pipe Failed");
		return 1;
	}
	if (pipe(pipe_2_file_descriptor) == -1) {
		fprintf(stderr, "Pipe Failed");
		return 1;
	}

    printf("Enter the greeting based on the time of day: ");
	// scanf("%s", input_str);
	fgets(input_str, 100, stdin);
	process_id = fork();

	if (process_id < 0) {
		fprintf(stderr, "fork Failed");
		return 1;
	}

	// Parent process
	else if (process_id > 0) {
		char concat_str[100];

		close(pipe_1_file_descriptor[0]); // Close reading end of first pipe

		// Write input string and close writing end of first
		// pipe.
		write(pipe_1_file_descriptor[1], input_str, strlen(input_str) + 1);
		close(pipe_1_file_descriptor[1]);

		// Wait for child to send a string
		wait(NULL);

		close(pipe_2_file_descriptor[1]); // Close writing end of second pipe

		// Read string from child, print it and close
		// reading end.
		read(pipe_2_file_descriptor[0], concat_str, 100);
		printf("Concatenated string: %s\n", concat_str);
		close(pipe_2_file_descriptor[0]);
	}

	// child process
	else {
		close(pipe_1_file_descriptor[1]); // Close writing end of first pipe

		// Read a string using first pipe
		char concat_str[100];
		read(pipe_1_file_descriptor[0], concat_str, 100);

		// Concatenate a fixed string with it
		int k = strlen(concat_str);
		int i;
		for (i = 0; i < strlen(fixed_str); i++)
			concat_str[k++] = fixed_str[i];

		concat_str[k] = '\0'; // string ends with '\0'

		// Close both reading ends
		close(pipe_1_file_descriptor[0]);
		close(pipe_2_file_descriptor[0]);

		// Write concatenated string and close writing end
		write(pipe_2_file_descriptor[1], concat_str, strlen(concat_str) + 1);
		close(pipe_2_file_descriptor[1]);

		exit(0);
	}
}
