from iterative_file_lister import IterativeFileLister
from ifilelister import IFileLister
from recursive_file_lister import RecursiveFileLister

# iterative_file_lister = IterativeFileLister()
# iterative_file_lister.list_files(r'C:\Temp')

recursive_file_lister = RecursiveFileLister()
recursive_file_lister.list_files(r'C:\Users')
