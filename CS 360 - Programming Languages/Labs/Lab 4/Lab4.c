/* CS360 Lab 4: C */

#include <stdio.h>
#include <stdlib.h>

FILE *fp = NULL;

int findHeader(unsigned char * data, size_t bytes)
{
	int i = 0;
	unsigned int next_left;
	while (i < bytes) 
	{
		next_left = data[i+1];
		next_left>>=4;
		
		if (data[i] == 255 && next_left == 15)
		{
			return i;
		}
		i++;
	}
	return -1;
}

void bitRate(int bits[])
{
	int rate = 0;
	if (bits[16] == 1)
	{
		rate += 8;
	}
	if (bits[17] == 1)
	{
		rate += 4;
	}
	if (bits[18] == 1)
	{
		rate += 2;
	}
	if (bits[19] == 1)
	{
		rate += 1;
	}
	if (rate >= 0 && rate <= 10)
	{
		switch (rate)
		{
            case 0 :
				rate = 32;
				break;
			case 1 :
				rate = 40;
				break;
			case 2 :
				rate = 48;
				break;
			case 3 :
				rate = 56;
				break;
			case 4 :
				rate = 64;
				break;
			case 5 :
				rate = 80;
				break;
			case 6 :
				rate = 96;
				break;
			case 7 :
				rate = 112;
				break;
			case 8 :
				rate = 128;
				break;
			case 9 :
				rate = 144;
				break;
			case 10 :
				rate = 160;
				break;			
			default :
				rate = -1;
		}
		printf("Bit Rate: %i\n", rate);
	}
	else
	{
		printf("Failed To Read Bit Rate\n");
	}
}

void frequency(int bits[])
{
	int frequency = 0;
	if (bits[20] == 1)
	{
		frequency += 2;
	}
	if (bits[21] == 1)
	{
		frequency += 1;
	}
	
	switch (frequency)
	{
		case 0:
			frequency = 44100;
			break;
		default:
			frequency = 0;
			break;
	}	
	printf("Frequency: %d\n", frequency);
}

void copyright(int bits[])
{
	if (bits[28] == 1)
	{
		printf("Copyright: Yes\n");
	}
	else
	{
		printf("Copyright: No\n");
	}
}

void original(int bits[])
{
	if (bits[29] == 1)
	{
		printf("Original: Yes\n");
	}
	else
	{
		printf("Original: No\n");
	}
}

int isMP3(int bits[])
{
	if (bits[12] == 1 && bits[13] == 0 && bits[14] == 1)
	{
		return 1;
	}
	return 0;
}

int initialize (int argc, char ** argv)
{
    // Open the file given on the command line
	if( argc != 2 )
	{
		printf("Usage: %s filename.mp3\n", argv[0]);
		return(EXIT_FAILURE);
	}
	
	fp = fopen(argv[1], "rb");
	if( fp == NULL )
	{
		printf("Can't open file %s\n", argv[1]);
		return(EXIT_FAILURE);
	}
    return 0;
}

int readFile (FILE *fp)
{
    const int max_size = 10485760;
    const int min_size = 1;
	// How many bytes are there in the file?  If you know the OS you're
	// on you can use a system API call to find out.  Here we use ANSI standard
	// function calls.
	double size = 0;
      
	fseek(fp, 0, SEEK_END);		// go to 0 bytes from the end
	size = ftell(fp);				// how far from the beginning?
    double sizeMB = size/1048576;
	rewind(fp);						// go back to the beginning
	
	if(size < min_size || size > max_size)
	{
		printf("File size is not within the allowed range\n"); 
		return 0;
	}
    
	// Allocate memory on the heap for a copy of the file
	unsigned char * data = (unsigned char *)malloc(size);
	// Read it into our block of memory
	size_t bytesRead = fread(data, sizeof(unsigned char), size, fp);
	if(bytesRead != size)
	{
		printf( "Error reading file. Unexpected number of bytes read: %I64d\n",bytesRead );
		return 0;
	}
    // We now have a pointer to the first byte of data in a copy of the file, have fun
	// unsigned char * data    <--- this is the pointer    
    int headIndex = findHeader(data, size);
	int bitArray[32] = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	int *bitPtr;
	bitPtr = bitArray;
	int bitCount = 0;
    
	if (headIndex >= 0)
	{
		for (int j = headIndex; j < headIndex + 4; j++)
		{
			for (int k = 0; k < 8; k++)
			{
				*(bitPtr + bitCount) = (data[j] & 0x80)/128;
				data[j] <<= 1;
				bitCount++;
			}
		}
		
	}
	else
	{
		printf("Header not found.");
		free((unsigned char *)data);
		return 0;
	}
	
	if (isMP3(bitArray) == 1)
	{
		printf("File size: %.2f MB\n", sizeMB);
		bitRate(bitArray);
		frequency(bitArray);
		copyright(bitArray);
		original(bitArray);
	}
	else
	{
		printf("File not MP3");
	}
	free((unsigned char *)data);
	return 0;
}

int main(int argc, char ** argv)
{
	initialize(argc, argv);
    readFile(fp);

    fclose(fp);
	exit(EXIT_SUCCESS);
}

